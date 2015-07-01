package com.learnoba.classes.create;

import java.io.IOException;
import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

import com.learnoba.AbstractController;
import com.learnoba.UserSettings;
import com.learnoba.models.CreateClass;

public class CreateClassController extends AbstractController<AnchorPane> {
@FXML
private Pane firstPane;
@FXML
private Pane secondPane;
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
private ComboBox scoreComboBox;
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
		classModel.createClass(Integer.parseInt(scoreComboBox.getValue().toString()), nameTextField.getText(), 
                semesterChoiceBox.getValue().toString(),
                Integer.parseInt(yearChoiceBox.getValue().toString()));

        if (rosterTextField.getText() != null){
        	try{
        		classModel.readInRoster();
        	}
        	catch(IOException ex){
        		Dialogs.showInformationDialog(new Stage(), "You entered an invalid file path. Please try again.", "Invalid path!", "Invalid path.");
        		rosterTextField.clear();
        	}
        	Dialogs.showInformationDialog(new Stage(), "You have successfully added a class.", "Added Class!", "Added Class!");
        }
        nameTextField.setText("");
        rosterTextField.setText("");
        yearChoiceBox.getSelectionModel().clearSelection();
        semesterChoiceBox.getSelectionModel().clearSelection();
        scoreComboBox.getSelectionModel().clearSelection();

        UserSettings.getInstance().getTabController().loadSelectClass();
        
	}
	@FXML
	public void populateYears(){
		classModel.findYears(yearChoiceBox);
		
	}
	//This functions is responsible for populating the scores into the choiceBox
	@FXML
	public void populateScores(){
		classModel.populateScores(scoreComboBox);
	}

}
