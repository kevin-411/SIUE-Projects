package com.learnoba.classes.select;

import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ResourceBundle;

import com.database.DatabaseFacade;
import com.learnoba.AbstractController;
import com.learnoba.models.SelectClass;
import com.learnoba.models.Student;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Dialogs;
import javafx.scene.control.Hyperlink;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.RadioButton;
import javafx.scene.control.Tab;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;



public class SelectClassController extends AbstractController<AnchorPane> {
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
	private RadioButton addRadioButton;
	@FXML
	private RadioButton deleteRadioButton;
	@FXML
	private TextField firstTextField;
	@FXML
	private TextField lastTextField;
	@FXML
	private TextField idTextField;
	private SelectClass classModel = new SelectClass();
	
	
	public SelectClassController() throws SQLException {
	        super();
	        

	}
	@Override
	public void initialize(URL location, ResourceBundle resources) {
		try {
			populateYears();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
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
	private void deleteStudentFired(){
		deleteRadioButton.setDisable(false);
	}
	//This function is responsible for adding a student to a class
	@FXML
	private void addStudentFired() throws SQLException{
		classModel.addStudent(firstTextField.getText(), lastTextField.getText(), idTextField.getText());
		populateStudents();
		Dialogs.showInformationDialog(new Stage(), "You have successfully added a student.", "Added Student!", "Added Student!");
	}
	//This function is responsible for populating students into the list.
	@FXML
	private void populateStudents() throws SQLException{
		rosterListView.getItems().clear();
		ObservableList list = classModel.populateStudents(rosterListView, yearComboBox.getValue().toString(), semesterComboBox.getValue().toString());
		rosterListView.getItems().addAll(list);
	}
	//This function is responsible for deleting a student
	@FXML
	private void deleteStudents() throws SQLException{
		//TODO: figure out why thats failing
		hideItemsFired();
		classModel.deleteStudent(rosterListView.getSelectionModel().getSelectedIndex());
		Dialogs.showInformationDialog(new Stage(), "You have successfully deleted a student.", "Deleted Student!", "Deleted Student!");
		populateStudents();
	}
	@FXML
	private void populateYears() throws SQLException{
		ObservableList list = classModel.populateElement('y', null, null);
		yearComboBox.getItems().addAll(list);
	}
	@FXML
	private void populateSemesters() throws SQLException{
		semesterComboBox.getItems().clear();
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
