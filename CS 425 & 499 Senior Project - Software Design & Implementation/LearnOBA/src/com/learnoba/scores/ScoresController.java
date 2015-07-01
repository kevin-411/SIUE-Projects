package com.learnoba.scores;

import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;

import com.learnoba.AbstractController;
import com.learnoba.models.Assignment;
import com.learnoba.models.Outcome;
import com.learnoba.models.Student;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.control.Dialogs;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.control.TreeItem;
import javafx.scene.control.TreeView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;


public class ScoresController extends AbstractController<AnchorPane>{

    @FXML
    AnchorPane enterScoresPane;
    @FXML
    ListView<String> studentsListView;
    @FXML
    ListView<String> assignmentsListView;
    @FXML
    TreeView<String> tasksTreeView;
    @FXML
    Label editScoresLabel;
    @FXML
    Label studentsLabel;
    @FXML
    Label assignmentsLabel;
    @FXML
    Label tasksLabel;
    @FXML
    Pane studentInfoPane;
    @FXML
    TextField firstNameTextField;
    @FXML
    TextField middleNameTextField;
    @FXML
    TextField lastNameTextField;
    @FXML
    TextField studentIDTextField;
    @FXML
    TextField emailTextField;
    
    private Outcome outcomeModel;
    private ObservableList<String> students = FXCollections.observableArrayList();
    private ObservableList<String> assignments = FXCollections.observableArrayList();
    private int assignmentID;
    private int studentID;
    
    public ScoresController() throws SQLException {
        super();
        outcomeModel = new Outcome();
    }


    @SuppressWarnings("unchecked")
    @Override
    public void initialize(URL location, ResourceBundle resources) {
        TreeItem<String> root = new TreeItem<String>("Tasks");
        //Get students and assignments
        for(Student item : outcomeModel.getAllStudents())
            students.add(item.getLastName() + ", " + item.getFirstName());
        for(Assignment item : outcomeModel.getAllAssignments())
            assignments.add(item.getAssignmentName());
        FXCollections.sort(students);
        //Set up list views
        studentsListView.setItems(students);
        assignmentsListView.setItems(assignments);
        //Set up tree view
        tasksTreeView.setRoot(root);
        root.setExpanded(false);
        tasksTreeView.setShowRoot(false);
        tasksTreeView.setEditable(false);
   
        //When the selected student is changed, set up the student information text boxes & clear assignment selection
        studentsListView.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>(){
            @Override
            public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue){
                if(newValue == null){
                    studentsListView.getSelectionModel().select(0);
                }else{
                    //Get student name
                    String[] name = newValue.split("[,]");
                    Student student = outcomeModel.findStudent(name[1].substring(1), name[0]);
                    studentID = student.getStudentID();
                    //Fill text fields
                    firstNameTextField.setText(student.getFirstName());
                    setTextField(middleNameTextField, student.getMiddleName());
                    lastNameTextField.setText(student.getLastName());
                    setTextField(studentIDTextField, student.getUniversityID());
                    setTextField(emailTextField, student.getEmail());
                    if(assignmentsListView.getSelectionModel().getSelectedItem() != null)
                        try {
                            reloadTasks();
                        } catch (SQLException e) {
                            e.printStackTrace();
                        }
                }
            }
        });
        //When the selected assignment is changed, update the tasks accordingly
        assignmentsListView.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>(){
            @Override
            public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue){
                if(newValue != null){
                    assignmentID = outcomeModel.findAssignment(assignmentsListView.getSelectionModel().getSelectedIndex()).getAssignmentID();
                    try {
                        reloadTasks();
                    } catch (SQLException e) {
                        e.printStackTrace();
                    }
                }else{
                    assignmentID = -1;
                    tasksTreeView.getRoot().getChildren().clear();
                }
            }
        });
        //Select first student & assignment
        //studentsListView.getSelectionModel().select(0);
       // assignmentsListView.getSelectionModel().select(0);
    }
    
    //Sets the given textfield with the given string.  If string is null, clears and disables textfield.
    private void setTextField(TextField text, String item){
        if(item.equals(null)){
            text.setText("");
            text.setDisable(true);
        }else{
            text.setDisable(false);
            text.setText(item);
        }
    }
    
    private void updateOutcomeValue(String newValue, Outcome out){
        float number;
        try{
            number = Float.valueOf(newValue);
            out.setOutcomeValue(number);
            outcomeModel.updateOutcome(out);
        }catch(NumberFormatException | NullPointerException e){
            e.printStackTrace();
            //TODO: Why does this not work?!?!?
            //Dialogs.showErrorDialog(new Stage(), "Invalid number entered in the text field!", "Update Outcomes");
        }catch (SQLException e) {
            e.printStackTrace();
        }
    }
    
    //Reloads the task tree with the given assignment name
    private void reloadTasks() throws SQLException{
        List<Integer> questionNums = new ArrayList<Integer>();
        int question;
        String name;
        TreeItem<String> task = tasksTreeView.getRoot();
        outcomeModel.getOutcomes(studentID, assignmentID);
        //Clear the tree and then fill it
        tasksTreeView.getRoot().getChildren().clear();
        for(final Outcome out : outcomeModel.getOutcomes()){
            question = out.getQuestionNumber();
            name = "Task #" + question;
            //if the task has not already been created, create it
            if(!(questionNums.contains(question))){
                questionNums.add(question);
                task = null;
                task = new TreeItem<String>(name);
                tasksTreeView.getRoot().getChildren().add(task);
            //if the task already exists, find it
            }else{
                if(task.getValue() != name){
                    task = tasksTreeView.getRoot();
                    //loop through tree items and find task
                    for(TreeItem<String> item : tasksTreeView.getRoot().getChildren()){
                        if(item.getValue().equals(name)){
                            task = item;
                            break;
                        }
                    }
                }
            }
            //Create textfield that only allows input of numbers or decimal place
            final TextField text = new TextField(String.valueOf(out.getOutcomeValue())){
                @Override
                public void replaceText(int start, int end, String text) {
                    if (text.matches("^\\d*\\.?$")) {
                        super.replaceText(start, end, text);   
                    }
                }
                @Override
                public void replaceSelection(String text) {
                    if (!text.matches("^\\d*\\.?$")) {
                        super.replaceSelection(text);
                    }
                }
            };
            //update the database when enter is pressed within textfield
            text.setOnKeyPressed(new EventHandler<KeyEvent>() {
                public void handle(final KeyEvent keyEvent) {
                    if (keyEvent.getCode() == KeyCode.ENTER) {
                        updateOutcomeValue(text.getText(), out);
                        keyEvent.consume();
                    }
                }
            });
            //when the textbox loses focus, update the database
            text.focusedProperty().addListener(new ChangeListener<Boolean>(){
                @Override
                public void changed(ObservableValue<? extends Boolean> observable, Boolean oldProperty, Boolean newProperty) {
                    if(!newProperty){
                        updateOutcomeValue(text.getText(), out);
                    }
                }
            });
            text.setMaxWidth(50);   
            text.getStylesheets().add("com/learnoba/application.css");
            text.getStyleClass().add("text-field");
            text.getStyleClass().add("textbox1");
            TreeItem<String> skill = new TreeItem<String>(out.getSkillName(), text);
            task.getChildren().add(skill);
        }
    }
}
