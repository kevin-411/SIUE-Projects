package com.learnoba.assignment;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import com.learnoba.AbstractController;
import com.learnoba.models.Assignment;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Hyperlink;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.RadioButton;
import javafx.scene.control.Tab;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.control.TreeItem;
import javafx.scene.control.TreeView;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;


public class AssignmentController extends AbstractController<AnchorPane> {
	
	@FXML
	private AnchorPane manageAssignmentsAnchorPane;
	@FXML
	private Label manageLabel;
	@FXML
	private Label nameLabel;
	@FXML
	private Label detailLabel;
	@FXML
	private Label solutionLabel;
	@FXML
	private Label typeLabel;
	@FXML
	private Label intialQuestionLabel;
	@FXML
	private Label assignmentLabel;
	@FXML
	private Label nameAssignLabel;
	@FXML
	private Label typeAssignLabel;
	@FXML
	private Label questionLabel;
	@FXML
	private Label selectLabel;
	@FXML
	private ListView<String> assignmentListView;
	@FXML
	private ComboBox optionComboBox;
	@FXML
	private ListView<String> questionListView;
	@FXML
	private TextField nameTextField;
	@FXML
	private TextArea questionTextArea;
	@FXML
	private TextArea solutionTextArea;
	@FXML
	private TextField nameAssignTextField;
	@FXML
	private ComboBox typeComboBox;
	@FXML
	private ComboBox typeAssignComboBox;
	@FXML
	private Button saveAssignButton;
	@FXML
	private Button saveButton;
	@FXML
	private TreeView allSkillsTreeView;
	@FXML
	private TreeView skillsTreeView;
	@FXML
	private Button addSkillButton;
	@FXML
	private Label allSkillsLabel;
	@FXML
	private Button deleteAssignButton;
	@FXML
	private Button deleteQuestionButton;
	@FXML
	private Button deleteSkillButton;
	private Assignment assignmentModel;
	public static final ObservableList skills = FXCollections.observableArrayList();
	public AssignmentController() throws SQLException {
        super();
        assignmentModel = new Assignment();
    }
	@Override
	public void initialize(URL location, ResourceBundle resources) {
	    hideEditQuestionFired();
	    hideAddAssignmentFired();
	    hideManageSkillsFired();
	    try {
			assignmentLoadedFired();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	//The three functions below are responsible for populating the correct ListViews.
	//TODO:Test this function.
	@SuppressWarnings("unchecked")
	@FXML
	public void assignmentLoadedFired() throws SQLException{
		ObservableList<String> values = FXCollections.observableArrayList();
		values = assignmentModel.populateElement('a');
		assignmentListView.getItems().addAll(values);
		
	}
	//TODO: Test this function.
	@FXML
	public void assignmentClickedFired() throws SQLException{
		deleteAssignButton.setDisable(false);
		ObservableList <String> values = FXCollections.observableArrayList();
		values = assignmentModel.populateElement('q');
		questionListView.getItems().addAll(values);
	}
	//TODO: Test this function
	@FXML
	public void questionClickedFired() throws SQLException{
		deleteQuestionButton.setDisable(false);
		ObservableList <String> values = FXCollections.observableArrayList();
		values = assignmentModel.populateElement('s');
		//skillsTreeView.getItems().addAll(values);
	}
	@FXML
	public void skillClickedFired(){
		deleteSkillButton.setDisable(false);
	}
	//This function is responsible for showing info according to which item is selected.
	@FXML
	public void optionSelectedFired(){
		if(optionComboBox.getSelectionModel().isSelected(0)){
			hideManageSkillsFired();
			hideAddAssignmentFired();
			hideEditQuestionFired();
		}
		else if(optionComboBox.getSelectionModel().isSelected(1)){
			showAddAssignmentFired();
			hideManageSkillsFired();
			hideEditQuestionFired();
		}
		else if(optionComboBox.getSelectionModel().isSelected(2)){
			showEditQuestionFired();
			hideManageSkillsFired();
			hideAddAssignmentFired();
		}
		else if(optionComboBox.getSelectionModel().isSelected(3)){
			showEditQuestionFired();
			hideManageSkillsFired();
			hideAddAssignmentFired();
		}
		else if(optionComboBox.getSelectionModel().isSelected(4)){
			showManageSkillsFired();
			hideEditQuestionFired();
			hideAddAssignmentFired();
		}
	       
	}
	//
    @FXML
    private void addSkillsFired(ActionEvent event) {
    	    	
    }
    //Remove skills from listView, need to add code to also be removed from database
    @FXML
    private void removeSkillsFired(ActionEvent event) {
    }  
	@FXML
	public void showManageSkillsFired(){
		allSkillsTreeView.setVisible(true);
		skillsTreeView.setVisible(true);
		addSkillButton.setVisible(true);
		allSkillsLabel.setVisible(true);
		
	}
	@FXML
	public void hideManageSkillsFired(){
		allSkillsTreeView.setVisible(false);
		addSkillButton.setVisible(false);
		allSkillsLabel.setVisible(false);
		
	}
	@FXML
	public void showAddAssignmentFired(){
		nameAssignLabel.setVisible(true);
		nameAssignTextField.setVisible(true);
		typeAssignLabel.setVisible(true);
		typeAssignComboBox.setVisible(true);
		saveAssignButton.setVisible(true);
	}
	@FXML
	public void hideAddAssignmentFired(){
		nameAssignLabel.setVisible(false);
		nameAssignTextField.setVisible(false);
		typeAssignLabel.setVisible(false);
		typeAssignComboBox.setVisible(false);
		saveAssignButton.setVisible(false);
	}
	@FXML
	public void showEditQuestionFired(){
		addOrEditQuestion();
		detailLabel.setVisible(true);
		nameLabel.setVisible(true);
		nameTextField.setVisible(true);
		typeLabel.setVisible(true);
		typeComboBox.setVisible(true);
		questionLabel.setVisible(true);
		questionTextArea.setVisible(true);
		solutionLabel.setVisible(true);
		solutionTextArea.setVisible(true);
		saveButton.setVisible(true);
	}
	@FXML
	public void hideEditQuestionFired(){
		detailLabel.setVisible(false);
		nameLabel.setVisible(false);
		nameTextField.setVisible(false);
		typeLabel.setVisible(false);
		typeComboBox.setVisible(false);
		questionLabel.setVisible(false);
		questionTextArea.setVisible(false);
		solutionLabel.setVisible(false);
		solutionTextArea.setVisible(false);
		saveButton.setVisible(false);
	}
	//Handles whether the user is add or editing questions. The appropriate
	//values will need to be grabbed from the database
	@FXML
	public void addOrEditQuestion(){
		//IF add is selected
		if(optionComboBox.getSelectionModel().isSelected(2)){
			solutionTextArea.setText("");
			questionTextArea.setText("");
			nameTextField.setText("");
			typeComboBox.getSelectionModel().select(2);
			
		}
		//IF edit is selected
		else if(optionComboBox.getSelectionModel().isSelected(3)){
			solutionTextArea.setText("Mass and Acceleration");
			questionTextArea.setText("What are the factors affecting force?");
			nameTextField.setText("Question1");
			typeComboBox.getSelectionModel().select(2);
		}
	}
}
