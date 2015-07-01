package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class SelectClassController extends AbstractController<AnchorPane> {
	@FXML
    private ComboBox semesterCombo;
    @FXML
    private ComboBox yearCombo;
    @FXML
    private ComboBox courseCombo;
    @FXML
    private ListView rosterList;
    @FXML
    private ListView courseworkList;
	@FXML
    private RadioButton addStudentRadio;
    @FXML
    private RadioButton createAssignmentRadio;
    @FXML
    private RadioButton deleteStudentRadioButton;
    @FXML
    private RadioButton deleteAssignmentRadioButton;
    @FXML
    private Label firstLabel;
	@FXML
    private Label lastLabel;
    @FXML
    private Label idLabel;
    @FXML
    private Button saveStudentButton;
    @FXML
    private TextField firstTextBox;
    @FXML
    private TextField lastTextBox;
    @FXML
    private TextField idTextBox;
    @FXML
    private Label assignmentNameLabel;
	@FXML
    private Label typeLabel;
    @FXML
    private Button saveAssignmentButton;
    @FXML
    private TextField assignmentNameTextBox;
    @FXML
    private ComboBox typeComboBox;
    @FXML
    private AnchorPane selectClassPane;



    public SelectClassController() {
        super();
    }
    @FXML
    private void addStudentFired(ActionEvent event) {
    		handleStudentEnable();  	
    }

    @FXML
    private void createAssignmentFired(ActionEvent event) {
    		handleAssignEnable();
    }
    @FXML
    private void deleteStudentFired(ActionEvent event) {
   
    	Dialogs.showInformationDialog(new Stage(), "Are you sure you would like to delete this Student?", "Delete Student?", "Delete Student?");
    	ObservableList<String> items =FXCollections.observableArrayList (
        	    "Zach Benchley", "Logan Maughan", "Brian Olsen", "Matt Lievens", "Jeremy Mintun", "Haley Evans",
        	    "Bryce Starkey");
    	rosterList.setItems(items);
    }

    @FXML
    private void editAssignmentFired(ActionEvent event) {
       	EditAssignmentController controller= new EditAssignmentController();
    	controller.setPrimaryView(new EditAssignmentGUI("EditAssignment.fxml", "Edit Assignment Screen"));
    	controller.getPrimaryView().show();
    	
    }
    @FXML
    private void deleteAssignmentFired(ActionEvent event) {
    	Dialogs.showInformationDialog(new Stage(), "Are you sure you would like to delete this Assignment?", "Delete Assignment?", "Delete Student?");
    	ObservableList<String> items2 =FXCollections.observableArrayList (
        	    "Exam 1", "Exam 2", "Final Exam", "Assignment 1", "Assignment 2", "Assignment 3",
        	    "Assignment 4");
    	courseworkList.setItems(items2); 
    }
    @FXML
    private void saveStudentFired(ActionEvent event) {
    	ObservableList<String> items =FXCollections.observableArrayList (
        	    "Zach Benchley", "Logan Maughan", "Brian Olsen", "Matt Lievens", "Jeremy Mintun", "Haley Evans",
        	    "Bryce Starkey", "Jared Burton");
    	rosterList.setItems(items);
    	
    }
    @FXML
    private void saveAssignmentFired(ActionEvent event) {
      	ObservableList<String> items2 =FXCollections.observableArrayList (
        	    "Exam 1", "Exam 2", "Final Exam", "Assignment 1", "Assignment 2", "Assignment 3",
        	    "Assignment 4", "Assignment 5", "Exam23");
    	courseworkList.setItems(items2);
    }
  
    public void handleStudentEnable(){
    	firstLabel.setVisible(true);
    	lastLabel.setVisible(true);
    	idLabel.setVisible(true);
    	saveStudentButton.setVisible(true);
    	firstTextBox.setVisible(true);
    	lastTextBox.setVisible(true);
    	idTextBox.setVisible(true);
    }
    public void handleStudentDisable(){
    	firstLabel.setVisible(false);
    	lastLabel.setVisible(false);
    	idLabel.setVisible(false);
    	saveStudentButton.setVisible(false);
    	firstTextBox.setVisible(false);
    	lastTextBox.setVisible(false);
    	idTextBox.setVisible(false);
    }
    public void handleAssignEnable(){
    	typeComboBox.setVisible(true);
    	assignmentNameTextBox.setVisible(true);
    	saveAssignmentButton.setVisible(true);
    	typeLabel.setVisible(true);
    	assignmentNameLabel.setVisible(true);
    }
    public void handleAssignDisable(){
    	typeComboBox.setVisible(false);
    	assignmentNameTextBox.setVisible(false);
    	saveAssignmentButton.setVisible(false);
    	typeLabel.setVisible(false);
    	assignmentNameLabel.setVisible(false);
    }
    public void loadListView(){
    	ObservableList<String> items =FXCollections.observableArrayList (
        	    "Zach Benchley", "Logan Maughan", "Brian Olsen", "Matt Lievens", "Jeremy Mintun", "Haley Evans",
        	    "Bryce Starkey", "Cole Burton");
    	rosterList.setItems(items);
    	ObservableList<String> items2 =FXCollections.observableArrayList (
        	    "Exam 1", "Exam 2", "Final Exam", "Assignment 1", "Assignment 2", "Assignment 3",
        	    "Assignment 4", "Assignment 5");
    	courseworkList.setItems(items2);
    }
    
    @Override
    public void initialize(URL location, ResourceBundle resources) {
    	courseCombo.getSelectionModel().selectedItemProperty().addListener(
  	    		new ChangeListener<String>() {
  	                public void changed(ObservableValue<? extends String> ov, 
  	                    String old_val, String new_val) {
  	                	loadListView();
  	            }});
    	
    	   rosterList.getSelectionModel().selectedItemProperty().addListener(
    	    		new ChangeListener<String>() {
    	                public void changed(ObservableValue<? extends String> ov, 
    	                    String old_val, String new_val) {
    	                	deleteStudentRadioButton.setDisable(false);
    	            }});
    	   courseworkList.getSelectionModel().selectedItemProperty().addListener(
    	    		new ChangeListener<String>() {
    	                public void changed(ObservableValue<? extends String> ov, 
    	                    String old_val, String new_val) {
    	                	deleteAssignmentRadioButton.setDisable(false);
    	            }});
    }

}
