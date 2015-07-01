package com.learnoba.welcome;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.Separator;
import javafx.scene.control.TextArea;
import javafx.scene.layout.AnchorPane;

import com.learnoba.AbstractController;

public class WelcomeController extends AbstractController<AnchorPane> {

	@FXML
	private AnchorPane welcomeScreenAnchorPane;
	@FXML
	private Label welcomeTitle;
	@FXML
	private Label quickLinks;
	@FXML
	private Label recentClasses;
	@FXML
    private Label whatLabel;
    @FXML
    private Label howLabel;
    @FXML
    private Label whereLabel;
	@FXML
	private Label addClassLabel;
	@FXML
	private Label selectClassLabel;
    @FXML
    private Label recentClassOne;
    @FXML
    private Label recentClassTwo;
    @FXML
    private Label recentClassThree;
	@FXML
	private Separator separatorOne;
	@FXML
	private Separator separatorTwo;
	@FXML
    private TextArea whatTextArea;
    @FXML
    private TextArea howTextArea;
    @FXML
    private TextArea whereTextArea;

	public WelcomeController(){
		super();
	}
	@Override
	public void initialize(URL location, ResourceBundle resources) {

	}

	@FXML
	private void addClassClick(ActionEvent event){
		//TODO move to the manage classes tab and make sure that "add a class" is selected
	}
	@FXML
	private void selectClassClick(ActionEvent event){
		//TODO move to the manage classes tab and make sure that "select a class" is selected
	}
	@FXML
	private void setUpRecentClasses(){
		//TODO set up the recent class labels so that they either display a recent class or are removed.  Make sure they go to the correct page as well when clicked
	}
}
