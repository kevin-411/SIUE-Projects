package com.learnoba.classes.select;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.Dialogs.DialogOptions;
import javafx.scene.control.Dialogs.DialogResponse;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

import com.learnoba.AbstractController;
import com.learnoba.UserSettings;
import com.learnoba.models.SelectClass;
import com.learnoba.tab.TabController;



public class SelectClassController extends AbstractController<AnchorPane> {
	@FXML
	private Label errorLabel;
	@FXML
	private Label rosterLabel;
	@FXML
	private Label firstLabel;
	@FXML
	private Label lastLabel;
	@FXML
	private Label idLabel;
	@FXML
	private Label yearLabel;
	@FXML
	private Label semesterLabel;
	@FXML
	private Label courseLabel;
	@FXML
	private ComboBox yearComboBox;
	@FXML
	private ComboBox semesterComboBox;
	@FXML
	private ComboBox courseComboBox;
	@FXML
	private ListView rosterListView;
	@FXML
	private Button saveButton;
	@FXML
	private Button addStudentButton;
	@FXML
	private Button newStudentButton;
	@FXML
	private Button deleteClassButton;
	@FXML
	private Button deleteStudentButton;
	@FXML
	private TextField firstTextField;
	@FXML
	private TextField lastTextField;
	@FXML
	private TextField idTextField;
	@FXML
	private Pane firstPane;
	@FXML
	private Pane secondPane;
	@FXML
	private Label mainLabel;
	private int tempIndex;
	private SelectClass classModel = new SelectClass();
	
    private TabController tabController;

    private UserSettings userSettings;

	public SelectClassController() throws SQLException {
	        super();
	}
	@Override
	public void initialize(URL location, ResourceBundle resources) {
        userSettings = UserSettings.getInstance();
        tabController = userSettings.getTabController();

		if(UserSettings.getCurrentClassID() >= 0){
			try {
				classModel.populateSelectClass(rosterListView, yearComboBox, semesterComboBox, courseComboBox);
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}else{
            try {
                populateYears();
            } catch (SQLException e) {
                e.printStackTrace();
            }
		}
		hideItemsFired();
	}
	
	@FXML
	private void hideItemsFired(){
		firstLabel.setVisible(false);
		lastLabel.setVisible(false);
		idLabel.setVisible(false);
		firstTextField.setVisible(false);
		lastTextField.setVisible(false);
		idTextField.setVisible(false);
		saveButton.setVisible(false);
	}
	@FXML 
	private void showItemsFired(){
		firstLabel.setVisible(true);
		lastLabel.setVisible(true);
		idLabel.setVisible(true);
		firstTextField.setVisible(true);
		lastTextField.setVisible(true);
		idTextField.setVisible(true);
		saveButton.setVisible(true);
	}
	@FXML
	private void deleteClassFired() throws SQLException{
		errorLabel.setVisible(false);
	    DialogResponse response = Dialogs.showConfirmDialog(new Stage(), "Are you sure you want to delete this class? This operation cannot be undone!", "Deleting " + courseComboBox.getValue(), "Delete Class", DialogOptions.YES_NO);
        //if the user says yes, then delete the class
        if(response == DialogResponse.YES){
    		classModel.deleteClass();
    		Dialogs.showInformationDialog(new Stage(), "Your class has successfully been deleted.", "Delete Class", "Delete Class");
            tabController.refreshClassChildren();
        }
	}
	@FXML
	private void deleteStudentFired(){
		errorLabel.setVisible(false);
		deleteStudentButton.setDisable(false);
		hideItemsFired();
	}
	//This function is responsible for adding a student to a class
	@FXML
	private void addStudentFired() throws SQLException{
		if(firstTextField.getText().isEmpty() || lastTextField.getText().isEmpty() || idTextField.getText().isEmpty()){
			errorLabel.setVisible(true);
		}
		else{
			errorLabel.setVisible(false);
			classModel.addStudent(firstTextField.getText(), lastTextField.getText(), idTextField.getText());
			populateStudents();
			firstTextField.setText("");
			lastTextField.setText("");
			idTextField.setText("");
			deleteStudentButton.setDisable(true);
			Dialogs.showInformationDialog(new Stage(), "You have successfully added a student.", "Added Student!", "Added Student!");
			rosterListView.setDisable(false);
		}
	}
	//This function is responsible for populating students into the list.
	@FXML
	private void populateStudents() throws SQLException{
		deleteClassButton.setDisable(false);
		newStudentButton.setDisable(false);
		rosterListView.getItems().clear();
		ObservableList list = classModel.populateStudents(rosterListView, yearComboBox.getValue().toString(), semesterComboBox.getValue().toString(), courseComboBox.getSelectionModel().getSelectedIndex());
        tabController.refreshClassDependentChildren();
        if (courseComboBox.getSelectionModel().isEmpty()) {
            // add clear text somehow
            semesterComboBox.getItems().clear();
            courseComboBox.getItems().clear();

        }
        classModel.getFacade().getUpdate().updateClassTimeStamp(userSettings.getCurrentClassID());
      
		rosterListView.getItems().addAll(list);
		if(list.size()>0){
			rosterListView.setDisable(false);
		}
		else{
			rosterListView.setDisable(true);
		}
	}
	//This function is responsible for deleting a student
	@FXML
	private void deleteStudents() throws SQLException{
		errorLabel.setVisible(false);
		hideItemsFired();
		DialogResponse response = Dialogs.showConfirmDialog(new Stage(), "Are you sure you want to delete this student? This operation cannot be undone!", "Deleting " + rosterListView.getSelectionModel().getSelectedItem(), "Delete Student", DialogOptions.YES_NO);
		if(response == DialogResponse.YES){
			classModel.deleteStudent(rosterListView.getSelectionModel().getSelectedIndex());
			Dialogs.showInformationDialog(new Stage(), "You have successfully deleted a student.", "Deleted Student!", "Deleted Student!");
			populateStudents();
			if(rosterListView.getItems().isEmpty()){
				rosterListView.setDisable(true);
			}
			deleteStudentButton.setDisable(true);
		}
	}
	@FXML
	private void populateYears() throws SQLException{
		ObservableList list = classModel.populateElement('y', null, null);
		yearComboBox.getItems().addAll(list);
	}
	@FXML
	private void populateSemesters() throws SQLException{
		semesterComboBox.getItems().clear();
		rosterListView.getItems().clear();
		courseComboBox.getItems().clear();
		semesterComboBox.setDisable(false);
		ObservableList list = classModel.populateElement('s', yearComboBox.getValue().toString(), null);
		semesterComboBox.getItems().addAll(list);
	}
	@FXML
	private void populateCourses() throws SQLException{
		courseComboBox.getItems().clear();
		courseComboBox.setDisable(false);
		ObservableList list = classModel.populateElement('c', yearComboBox.getValue().toString(), semesterComboBox.getValue().toString() );
		courseComboBox.getItems().addAll(list);
	}
}
