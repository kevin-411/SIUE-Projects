package com.learnoba.classes.manage;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.RadioButton;
import javafx.scene.layout.AnchorPane;


import com.learnoba.AbstractController;
import com.learnoba.classes.create.CreateClassView;
import com.learnoba.classes.select.SelectClassView;
import com.learnoba.models.BasicClass;



public class ManageClassController extends AbstractController<AnchorPane> {
	@FXML
	private Label manageLabel;
	@FXML
	private Label optionLabel;
	@FXML
	private AnchorPane manageClassesAnchorPane;
	@FXML
	private AnchorPane switchAnchorPane;
	@FXML
	private ComboBox optionComboBox;
	SelectClassView selectClassGUI;
  	CreateClassView createClassGUI;
    private BasicClass classModel;
    public ManageClassController() throws SQLException{
        super();
    }
    @Override
    public void initialize(URL location, ResourceBundle resources) {
    	 
    }
    @FXML
    public void selectionFired(){
    	if( optionComboBox.getSelectionModel().getSelectedIndex() == 0){
    		switchAnchorPane.getChildren().clear();
    	}
    	else if(optionComboBox.getSelectionModel().getSelectedIndex() == 1){
    		selectClassGUI = new SelectClassView("SelectClass.fxml", "Select Class");
    		switchAnchorPane.getChildren().clear();
    		switchAnchorPane.getChildren().add(new Label(""));
    		switchAnchorPane.getChildren().add((AnchorPane) selectClassGUI.getBasePane());	
    	}
    	else if(optionComboBox.getSelectionModel().getSelectedIndex() == 2){
    		createClassGUI = new CreateClassView("CreateClass.fxml", "Add Class");
    		switchAnchorPane.getChildren().clear();
    		switchAnchorPane.getChildren().add(new Label(""));
    		switchAnchorPane.getChildren().addAll(createClassGUI.getBasePane());
    	}
    }
 
}
