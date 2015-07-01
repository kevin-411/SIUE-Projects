package com.learnoba.assignment;

import java.net.URL;
import java.sql.SQLException;
import java.util.List;
import java.util.ResourceBundle;

import com.learnoba.AbstractController;
import com.learnoba.UserSettings;
import com.learnoba.models.Assignment;
import com.learnoba.models.QuestionType;
import com.learnoba.models.Skill;
import com.learnoba.models.Task;
import com.learnoba.skills.SkillsController;
import com.learnoba.tab.TabController;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
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
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;


public class AssignmentController extends AbstractController<AnchorPane> {
	
	@FXML
	private Label addAssignmentLabel;
	@FXML
	private AnchorPane manageAssignmentsAnchorPane;
	@FXML
	private Pane firstPane;
	@FXML
	private Pane secondPane;
	@FXML
	private Pane thirdPane;
	@FXML
	private Label manageLabel;
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
	private Label questionLabel;
	@FXML
	private Label selectLabel;
	@FXML
	private ListView assignmentListView;
	@FXML
	private Button assignmentButton;
	@FXML
	private Button questionButton;
	@FXML
	private Button skillButton;
	@FXML
	private ListView questionListView;
	@FXML
	private TextArea questionTextArea;
	@FXML
	private TextArea solutionTextArea;
	@FXML
	private TextField nameAssignTextField;
	@FXML
	private ComboBox<QuestionType> typeComboBox;
	@FXML
	private Button saveAssignButton;
	@FXML
	private Button saveButton;
	@FXML
	private TreeView <String> allSkillsTreeView;
	@FXML
	private TreeView <String> skillsTreeView;
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
	@FXML 
	private Button saveTaskButton;
	
	private Assignment assignmentModel;
	int questionSelected;
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
	    
	    TreeItem<String> root = new TreeItem <String>("root");
	    allSkillsTreeView.setRoot(root);
	    root.setExpanded(true);
	    allSkillsTreeView.setShowRoot(false);
	    allSkillsTreeView.setEditable(false);
	    
	    
	    TreeItem<String> root2 = new TreeItem <String>("root2");
	    skillsTreeView.setRoot(root2);
	    root.setExpanded(true);
	    skillsTreeView.setShowRoot(false);
	    skillsTreeView.setEditable(false);
	    
	    
	    populateQuestionTypes();
	    try {
			assignmentLoadedFired();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    if(assignmentListView.getItems().isEmpty()){
	    	assignmentListView.setDisable(true);
	    }
	    if(questionListView.getItems().isEmpty()){
	    	questionListView.setDisable(true);
	    }
	    if(skillsTreeView.getRoot().getChildren().isEmpty()){
			skillsTreeView.setDisable(true);
		}
}
	//This function is responsible for populating the question types
	public void populateQuestionTypes(){
		ObservableList<QuestionType> values = FXCollections.observableArrayList();
		values.add(QuestionType.DIAGRAM);
		values.add(QuestionType.ESSAY);
		values.add(QuestionType.FILL_IN_THE_BLANK);
		values.add(QuestionType.MULTIPLE_CHOICE);
		values.add(QuestionType.SHORT_ESSAY);
		typeComboBox.getItems().addAll(values);
	}
	@FXML
	public void addAssignmentFired() throws SQLException{
		assignmentModel.addAssignment(nameAssignTextField.getText());
		assignmentLoadedFired();
		nameAssignTextField.setText("");
	}
	@FXML 
	public void deleteAssignmentFired() throws SQLException{
		assignmentModel.deleteAssignment(assignmentListView.getSelectionModel().getSelectedIndex());
		assignmentLoadedFired();
		questionListView.getItems().clear();
		questionListView.setDisable(true);
		skillsTreeView.getRoot().getChildren().clear();
		if(assignmentListView.getItems().isEmpty()){
			deleteAssignButton.setDisable(true);
			assignmentListView.setDisable(true);
		}
		if(assignmentListView.getItems().isEmpty()){
			questionButton.setDisable(true);
		}
	}
	@FXML
	public void addTask() throws SQLException{
		assignmentModel.addTask(assignmentListView.getSelectionModel().getSelectedIndex(), solutionTextArea.getText(), questionTextArea.getText(), typeComboBox.getValue());
		assignmentClickedFired();
		questionTextArea.setText("");
		solutionTextArea.setText("");
		typeComboBox.getSelectionModel().select(0);
	}
	@FXML
	public void deleteTask() throws SQLException{
		assignmentModel.deleteTask(questionSelected);
		assignmentClickedFired();
		if(questionListView.getItems().isEmpty()){
			deleteQuestionButton.setDisable(true);
			questionListView.setDisable(true);
		}
		skillsTreeView.getRoot().getChildren().clear();
		skillsTreeView.setDisable(true);
		hideManageSkillsFired();
		hideAddAssignmentFired();
		hideEditQuestionFired();
	}
	@FXML
	public void updateTaskFired() throws SQLException{
		assignmentModel.updateTask(questionSelected, solutionTextArea.getText(), questionTextArea.getText(), typeComboBox.getValue());
	}
	@FXML
	public void loadSkillsFired() throws SQLException{
		Skill skillModel = new Skill("root");
		skillModel.getAllSkills();
		skillModel.reloadTree(allSkillsTreeView);
	}
	//The three functions below are responsible for populating the correct ListViews.
	@FXML
	public void assignmentLoadedFired() throws SQLException{
		assignmentListView.getItems().clear();
		ObservableList<String> values = FXCollections.observableArrayList();
		values = assignmentModel.populateElement('a', -1, -1);
		assignmentListView.getItems().addAll(values);
		if(!assignmentListView.getItems().isEmpty()){
			assignmentListView.setDisable(false);
		}
			
	}
	//TODO: Test this function.
	@FXML
	public void assignmentClickedFired() throws SQLException{
		deleteAssignButton.setDisable(false);
		questionListView.getItems().clear();
		questionButton.setDisable(false);
		ObservableList <String> values = FXCollections.observableArrayList();
		values = assignmentModel.populateElement('q', assignmentListView.getSelectionModel().getSelectedIndex(), -1);
		questionListView.getItems().addAll(values);
		if(!questionListView.getItems().isEmpty()){
			questionListView.setDisable(false);
		}
		else{
			questionListView.setDisable(true);
		}
	}
	//TODO: Test this function
	@FXML
	public void questionClickedFired() throws SQLException{
		questionSelected = questionListView.getSelectionModel().getSelectedIndex();
		if(questionSelected == -1)
		    return;
		skillButton.setDisable(false);
		//Handles the showing and hiding elements appropriately
		hideAddAssignmentFired();
		hideManageSkillsFired();
		hideEditQuestionFired();
		showEditQuestionFired();
		saveButton.setVisible(false);
		
		//Handles loading in the skills
		skillsTreeView.getRoot().getChildren().clear();
		deleteQuestionButton.setDisable(false);
		Task task = new Task();
		task = assignmentModel.populateTask(questionSelected);
		
		//Handles loading in the text areas with question properties and the tree view with the correct skills.
		solutionTextArea.setText(task.getQuestionAnswer());
		questionTextArea.setText(task.getQuestionText());
		detailLabel.setText("Question " + task.getQuestionNumber() + " Details");
		if(task.getType().toString().compareTo("MULTIPLE_CHOICE") == 0){
			typeComboBox.getSelectionModel().select(task.getType());
		}
		else if(task.getType().toString().compareTo("SHORT_ESSAY") == 0){
			typeComboBox.getSelectionModel().select(task.getType());
		}
		else if(task.getType().toString().compareTo("ESSAY") == 0){
			typeComboBox.getSelectionModel().select(task.getType());
		}
		else if(task.getType().toString().compareTo("DIAGRAM") == 0){
			typeComboBox.getSelectionModel().select(task.getType());;
		}
		else if(task.getType().toString().compareTo("FILL_IN_THE_BLANK") == 0){
			typeComboBox.getSelectionModel().select(task.getType());
		}
		assignmentModel.getSkillNames(questionSelected, skillsTreeView);
		
		if(!skillsTreeView.getRoot().getChildren().isEmpty()){
			skillsTreeView.setDisable(false);
		}
		
	}
	//TODO: Need to go back and make this connected with a query.
	@FXML
	public void addSkillToQuestionFired() throws SQLException{
	    List<Skill> skillList;
        Skill skill = new Skill("root2");
        skill.getAllSkills();
        //get the selected skill
        String currentSkillName = allSkillsTreeView.getSelectionModel().getSelectedItem().getValue();
        Skill currentSkill = skill.find(currentSkillName);
        skillList=currentSkill.getSkills();
        //recursively add all children of selected skill to the skill tree view
        assignmentModel.addSkill(questionSelected, currentSkill);
        skillsTreeView.setDisable(false);
        skillsTreeView.getRoot().getChildren().add(recursiveSkill(skillList, new TreeItem<String>(currentSkillName)));
	}
	public TreeItem<String> recursiveSkill(List<Skill> skillList, TreeItem<String> root) throws SQLException{
	    TreeItem<String> lastItem;
        //for each skill in the list
        for(Skill skill: skillList){
            //add skill to the treeview
            lastItem = new TreeItem<String>(skill.getName());
            root.getChildren().add(lastItem);
            assignmentModel.addSkill(questionSelected, skill);
            if(!(skill.getSkills().isEmpty())){
                //recurse down to child skills
                lastItem = recursiveSkill(skill.getSkills(), root.getChildren().get(root.getChildren().size() - 1));
            }
        }
        return root;
	}
	@FXML
	public void skillClickedFired(){
		deleteSkillButton.setDisable(false);
	
	}
	@FXML
	public void deleteSkillFired() throws SQLException{
	    TreeItem<String> item = skillsTreeView.getSelectionModel().getSelectedItem();
	    Skill skillModel = new Skill("root2");
	    if(item == null)
	        return;
        skillModel.getAllSkills();
        recursiveDelete(item, skillModel);
        assignmentModel.deleteSkill(questionSelected, skillModel.find(item.getValue()));
        skillsTreeView.getSelectionModel().getSelectedItem().getParent().getChildren().remove(item);
	}
	
	private void recursiveDelete(TreeItem<String> root, Skill skillModel) throws SQLException{
        Skill skill;
        for(TreeItem<String> item : root.getChildren()){
            skill = skillModel.find(item.getValue());
            assignmentModel.deleteSkill(questionSelected, skill);
            if(!(skill.getSkills().isEmpty())){
                //recurse down to child skills
                recursiveDelete(root.getChildren().get(root.getChildren().size() - 1), skillModel);
            }
        }
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
		addAssignmentLabel.setVisible(true);
		nameAssignLabel.setVisible(true);
		nameAssignTextField.setVisible(true);
		saveAssignButton.setVisible(true);
	}
	@FXML
	public void hideAddAssignmentFired(){
		addAssignmentLabel.setVisible(false);
		nameAssignLabel.setVisible(false);
		nameAssignTextField.setVisible(false);
		saveAssignButton.setVisible(false);
	}
	//The option parameter lets you know which button to disable, update Button? add button? or Both
	@FXML
	public void showEditQuestionFired() throws SQLException{
		
		/* TODO: Zach, is this necessary?  This is what was causing the question to become unselected when clicked on...
		 * assignmentClickedFired();
		 */
		detailLabel.setVisible(true);
		typeLabel.setVisible(true);
		typeComboBox.setVisible(true);
		questionLabel.setVisible(true);
		questionTextArea.setVisible(true);
		solutionLabel.setVisible(true);
		solutionTextArea.setVisible(true);
		saveButton.setVisible(true);
		saveTaskButton.setVisible(true);
		
	}
	@FXML
	public void hideEditQuestionFired(){
		detailLabel.setVisible(false);
		typeLabel.setVisible(false);
		typeComboBox.setVisible(false);
		questionLabel.setVisible(false);
		questionTextArea.setVisible(false);
		solutionLabel.setVisible(false);
		solutionTextArea.setVisible(false);
		saveButton.setVisible(false);
		saveTaskButton.setVisible(false);
	}
	@FXML
	private void AssignmentButtonClicked(){
		showAddAssignmentFired();
		hideManageSkillsFired();
		hideEditQuestionFired();
		solutionTextArea.setText("");
		questionTextArea.setText("");
		typeComboBox.getSelectionModel().select(2);
	}
	@FXML
	private void QuestionButtonClicked() throws SQLException{
		detailLabel.setText("Question " + assignmentModel.getNewQuestionNum() + " Details:");
		questionTextArea.setText("");
		solutionTextArea.setText("");
		typeComboBox.getSelectionModel().select(0);
		showEditQuestionFired();
		hideManageSkillsFired();
		hideAddAssignmentFired();
		saveTaskButton.setVisible(false);
	}
	@FXML
	private void SkillButtonClicked() throws SQLException{
		showManageSkillsFired();
		hideEditQuestionFired();
		hideAddAssignmentFired();
		loadSkillsFired();
	}
}
