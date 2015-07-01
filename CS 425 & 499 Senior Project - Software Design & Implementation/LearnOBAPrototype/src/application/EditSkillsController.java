package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TreeItem;
import javafx.scene.control.TreeView;
import javafx.scene.layout.AnchorPane;

public class EditSkillsController extends AbstractController<AnchorPane> {
	@FXML
    private Label questionLabel;
    @FXML
    private Label selectedQuestionLabel;
    @FXML
    private Label solutionLabel;
    @FXML
    private Label selectedSolutionLabel;
    @FXML
    private Label allSkillsLabel;
    @FXML
    private Label skillsForQuestionLabel;
    @FXML
    private TreeView allSkillsTreeView;
    @FXML
    private ListView skillsForQuestionListView;
    @FXML
    private Button addButton;
    @FXML
    private Button deleteButton;
    @FXML
    private Button saveButton;
    @FXML
    private AnchorPane editSkillsPane;
  	public static final ObservableList names = 
	        FXCollections.observableArrayList();
    public EditSkillsController() {
          super();
  
    }
    @FXML
    private void addSkillsFired(ActionEvent event) {
    	TreeItem newItem = new TreeItem();
    	newItem=(TreeItem)allSkillsTreeView.getSelectionModel().getSelectedItem();
        names.add(newItem.getValue());
    	skillsForQuestionListView.setItems(names);
    	
    }

    @FXML
    private void removeSkillsFired(ActionEvent event) {
    	skillsForQuestionListView.getItems().remove(skillsForQuestionListView.getSelectionModel().getSelectedIndex());
    	
    }
    @FXML
    private void saveFired(ActionEvent event) {
    
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        TreeItem<String> root = new TreeItem<String>("General Problem Solving");
        TreeItem<String> top = new TreeItem<String>("Skills");
        TreeItem<String> root1 = new TreeItem<String>("Newton Law Heuristics");
        TreeItem<String> root2 = new TreeItem<String>("Conservation of Energy");
        TreeItem<String> root3 = new TreeItem<String>("Kinematics Heuristics");
        TreeItem<String> root4 = new TreeItem<String>("Torque Heurisitics");
    	   //Add TreeItems to the root
        root.getChildren().addAll(
            new TreeItem<String>("GP Skill 1"),
            new TreeItem<String>("GP Skill 2"),
            new TreeItem<String>("GP Skill 3"));
        
        root1.getChildren().addAll(
                new TreeItem<String>("NL Skill 1"),
                new TreeItem<String>("NL Skill 2"),
                new TreeItem<String>("NL Skill 3")); 
        root2.getChildren().addAll(
                new TreeItem<String>("CE Skill 1"),
                new TreeItem<String>("CE Skill 2"),
                new TreeItem<String>("CE Skill 3"));
        root3.getChildren().addAll(
                new TreeItem<String>("KH Skill 1"),
                new TreeItem<String>("KH Skill 2"),
                new TreeItem<String>("KH Skill 3"));
        root4.getChildren().addAll(
                new TreeItem<String>("TH Skill 1"),
                new TreeItem<String>("TH Skill 2"),
                new TreeItem<String>("TH Skill 3"));
        top.getChildren().addAll(root, root1, root2, root3, root4);
        
        //Use the setRoot method to set the root TreeItem
        allSkillsTreeView.setRoot(top);

    }
    
 
}
