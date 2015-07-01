package com.learnoba.classes.create;

import java.io.IOException;
import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import com.learnoba.AbstractController;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Dialogs;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

import com.learnoba.models.CreateClass;

public class CreateClassController extends AbstractController<AnchorPane> {
@FXML
private Label createLabel;
@FXML
private Label classInfoLabel;
@FXML
private Label rosterLabel;
@FXML
private Label rosterTitleLabel;
@FXML
private Label yearLabel;
@FXML
private Label semesterLabel;
@FXML
private Label nameLabel;
@FXML
private Label scoreLabel;
@FXML
private ChoiceBox yearChoiceBox;
@FXML    
private ChoiceBox semesterChoiceBox;
@FXML
private ChoiceBox scoreChoiceBox;
@FXML
private TextField nameTextField;
@FXML
private TextField rosterTextField;
@FXML
private Button browseButton;
@FXML
private Button createButton;
@FXML
private AnchorPane createAnchorPane;

private CreateClass classModel;

	public CreateClassController() throws SQLException {
	    super();
	    classModel= new CreateClass();
	
	}
	@Override
	public void initialize(URL location, ResourceBundle resources) {
		   populateYears();
		   populateScores();
	}
	@FXML
	public void browseButtonFired(){
		classModel.showFilePicker();
		rosterTextField.setText(classModel.getFileSelected());
	}
	@FXML
	public void createButtonFired() throws IOException, SQLException{
		Dialogs.showInformationDialog(new Stage(), "You have successfully added a class.", "Added Class!", "Added Class!");
		classModel.createClass(Integer.parseInt(scoreChoiceBox.getValue().toString()), nameTextField.getText(), 
				semesterChoiceBox.getValue().toString(), Integer.parseInt(yearChoiceBox.getValue().toString()));
		classModel.readInRoster();
	}
	@FXML
	public void populateYears(){
		classModel.findYears(yearChoiceBox);
		
	}
	//This functions is responsible for populating the scores into the choiceBox
	@FXML
	public void populateScores(){
		classModel.populateScores(scoreChoiceBox);
	}
}
