package com.learnoba.skills;

import java.net.URL;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.input.*;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;
import javafx.util.Callback;

import com.learnoba.AbstractController;
import com.learnoba.models.Skill;

public class SkillsController extends AbstractController<AnchorPane>{
    
    @FXML
    private AnchorPane skillsAnchorPane;
    @FXML
    private TreeView<String> skillsTreeView;
    @FXML
    private TextArea uploadInstructions;
    @FXML
    private TextField editSkillTextBox;
    @FXML
    private TextField newSkillTextBox;
    @FXML
    private ComboBox<String> editSkillParentComboBox;
    @FXML
    private ComboBox<String> newSkillParentComboBox;
    @FXML
    private Pane uploadPane;
    @FXML
    private Pane editSkillPane;
    @FXML
    private Pane createSkillPane;
    @FXML
    private Label editSkillsTitle;
    @FXML
    private Label skillsLabel;
    @FXML
    private Label editSkillsLabel;
    @FXML
    private Label newSkillsLabel;
    @FXML
    private Label editSkillNameLabel;
    @FXML
    private Label editSkillParentLabel; 
    @FXML
    private Label newSkillNameLabel;
    @FXML
    private Label newSkillParentLabel; 
    @FXML
    private Button updateSkillButton;
    @FXML
    private Button deleteSkillButton;
    @FXML
    private Button createSkillButton;
    @FXML
    private Button uploadButton;
    @FXML
    private Button expandButton;
    @FXML
    private Button collapseButton;
    @FXML
    private Tooltip expandTooltip;
    @FXML
    private Tooltip collapseTooltip;
   
    
    private Skill skillModel;
    private TreeItem<String> tempItem = null;
    private String rootSkill = "None";
    
    
    public SkillsController() throws SQLException {
        super();
        skillModel = new Skill(rootSkill);
        skillModel.getAllSkills(0);
    }

    @SuppressWarnings("unchecked")
    @Override
    public void initialize(URL location, ResourceBundle resources){
        //create root node for the tree and set tree properties
        TreeItem<String> root = new TreeItem<String>(rootSkill);
        skillsTreeView.setRoot(root);
        root.setExpanded(true);
        skillsTreeView.setShowRoot(false);
        skillsTreeView.setEditable(false);
        editSkillPane.setDisable(true);
        reloadTree();
        // Clears any selected TreeView item when the mouse is clicked. This is so that the
        // selection is cleared when white space is clicked on
        skillsTreeView.addEventFilter(MouseEvent.MOUSE_PRESSED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                skillsTreeView.getSelectionModel().clearSelection();
            }
        });
        //The following cell factory handles drag and drop.  
        //-----START CELL FACTORY-----
        skillsTreeView.setCellFactory(new Callback<TreeView<String>, TreeCell<String>>() {
            @Override
            public TreeCell<String> call(TreeView<String> stringTreeView) {
                final TreeCell<String> treeCell = new TreeCell<String>() {
                    protected void updateItem(String item, boolean empty) {
                        super.updateItem(item, empty);
                        if (item != null) {
                            setText(item);
                        }
                    }
                };
                //when a drag event is detected
                treeCell.setOnDragDetected(new EventHandler<MouseEvent>() {
                    public void handle(MouseEvent event) {
                        //get selected item and start drag event
                        TreeItem<String> item = skillsTreeView.getSelectionModel().getSelectedItem();
                        Dragboard db = skillsTreeView.startDragAndDrop(TransferMode.MOVE);
                        ClipboardContent content = new ClipboardContent();
                        //if selected item is null, return
                        if (item == null){
                            return;
                        }
                        content.putString(String.valueOf(treeCell.getIndex()));
                        db.setContent(content);
                        //set a temporary item to the item being dragged
                        tempItem = item;
                        event.consume();
                    }
                });
                //when item is dragged over something else
                treeCell.setOnDragOver(new EventHandler<DragEvent>() {
                    public void handle(DragEvent event) {
                        //only transfer mode accepted is move
                        event.acceptTransferModes(TransferMode.MOVE);
                        event.consume();
                    }
                });
                //when dragged item enters another item
                treeCell.setOnDragEntered(new EventHandler<DragEvent>() {
                    public void handle(DragEvent event) {
                        //get entered item
                        TreeItem<String> item = treeCell.getTreeItem();
                        //if item is null, clear selection and return, otherwise, select the item
                        if (item == null){
                            skillsTreeView.getSelectionModel().clearSelection();
                            return;
                        }else{
                            skillsTreeView.getSelectionModel().select(item);
                        }
                        event.consume();
                    }
                });
                //when the dragged item is dropped
                treeCell.setOnDragDropped(new EventHandler<DragEvent>() {
                    public void handle(DragEvent event) {
                        TreeItem<String> temp;
                        //get the selected item
                        TreeItem<String> newParent =
                                skillsTreeView.getSelectionModel().getSelectedItem();
                        boolean success = false, isChild = false;
                        //if the item and its new parent are not null
                        if(tempItem != null && newParent != null){
                            temp = newParent;
                            //check to see if the item was dragged to one of its children
                            while(temp.getParent() != null){
                                temp = temp.getParent();
                                if(temp == tempItem)
                                    isChild = true;
                            }
                            if(!isChild){
                                //if new parent and item are the same, do nothing, otherwise add the item to the new parent
                                if(newParent == tempItem){
                                    success = false;
                                }else{
                                    tempItem.getParent().getChildren().removeAll(tempItem);
                                    newParent.getChildren().add(tempItem);
                                    success = true;
                                    //TODO:Update items parent in the database
                                }
                            }
                        //if the item being dragged is not null, but its new parent is, add to the root
                        }else if (tempItem != null && newParent == null){
                            tempItem.getParent().getChildren().removeAll(tempItem);
                            skillsTreeView.getRoot().getChildren().add(tempItem);
                            success = true;
                            //TODO:Update items parent in the database
                        }
                        //set drop completed and temp item back to null
                        event.setDropCompleted(success);
                        tempItem = null;
                        event.consume();
                    }
                });
                return treeCell;
            }
        });
    }
    //-----END CELL FACTORY-----

    
    private void resetTree(TreeItem<String> tree, List<Skill> list){
        TreeItem<String> item;
        if(list == null)
            return;
        //loop through list of items and add them to the tree
        for(int i = 0; i < list.size(); i++){
        	//System.out.println(list.get(i).getSkillID() + ": " + list.get(i).getName());
        	//System.out.println(tree.toString());
            item = new TreeItem<String>(list.get(i).getName());
            tree.getChildren().add(item);
         
            //if item has children, recurse down
            if(list.get(i).getSkills() != null){
            	resetTree(item, list.get(i).getSkills());
            }
        }
    }
    //function that reloads the tree after its been updated
    private void reloadTree(){
    	ObservableList<String> list;
    	skillsTreeView.getRoot().getChildren().clear();
    	resetTree(skillsTreeView.getRoot(), skillModel.getSkills());
    	list = skillModel.getAllSkillNames();
    	if(list != null){
    		FXCollections.sort(list);
    		editSkillParentComboBox.setItems(list);
    		newSkillParentComboBox.setItems(list);
    	}
        newSkillParentComboBox.getSelectionModel().select(rootSkill);
        editSkillParentComboBox.getSelectionModel().select(rootSkill);
        skillsTreeView.getSelectionModel().clearSelection();
        selectSkill();
    }
    //When the mouse is clicked inside of the TreeView, this handles populating the edit skill pane with the correct information
    @FXML
    private void selectSkill(){
        TreeItem<String> item = skillsTreeView.getSelectionModel().getSelectedItem();
        TreeItem<String> parent;
        ObservableList<String> tempSkills = FXCollections.observableList(new ArrayList<String>());
        tempSkills.addAll(skillModel.getSkillNames());
        //if nothing is selected, clear the text and combo boxes, and disable the pane
        //otherwise, enable the pane and update the information to the selected item
        if (item == null){
            editSkillTextBox.clear();
            editSkillParentComboBox.getSelectionModel().select(rootSkill);
            editSkillPane.setDisable(true);
        }else{
            parent = item.getParent();
            editSkillPane.setDisable(false);
            editSkillTextBox.setText(item.getValue());
            tempSkills = removeAllChildren(item, tempSkills);
            editSkillParentComboBox.setItems(tempSkills);
            editSkillParentComboBox.getSelectionModel().select(parent.getValue());
        }
    }
    //This function either expands or collapses the tree of skills depending on the input boolean
    private void expandChildren(TreeItem<String> root, boolean expand){
        ObservableList<TreeItem<String>> list = root.getChildren();
        int length = list.size();
        TreeItem<String> skill;
        for(int i = 0; i < length; i++){
            skill = list.get(i);
            if(!skill.isLeaf()){
                skill.setExpanded(expand);
                expandChildren(skill, expand);
            }
        }
    }
    //This function expands the tree of skills
    @FXML
    private void expandSkills(){
        expandChildren(skillsTreeView.getRoot(), true);
    }
    //This function collapses the tree of skills
    @FXML
    private void collapseSkills(){
        expandChildren(skillsTreeView.getRoot(), false);
    }
    //This is responsible for uploading a file of skills
    @FXML
    private void uploadFile() throws SQLException{
        skillModel.uploadSkills();
        reloadTree();
    }
    //this function removes all children of the given treeItem from the edit skills combobox
    private ObservableList<String> removeAllChildren(TreeItem<String> root, ObservableList<String> tempSkills){
        ObservableList<TreeItem<String>> list = root.getChildren();
        TreeItem<String> skill;
        tempSkills.remove(root.getValue());
        for(int i = 0; i < list.size(); i++){
            skill = list.get(i);
            tempSkills.remove(skill.getValue());
            if(!skill.isLeaf()){
                tempSkills = removeAllChildren(skill, tempSkills);
            }
        }
        return tempSkills;
    }
    //Handles the insert skill function
    @FXML
    private void insertSkill() throws SQLException{
        //if the item is inserted, then reset combo and text boxes and make sure that nothing in the treview is selected
        if(skillModel.insert(newSkillTextBox.getText(), newSkillParentComboBox.getSelectionModel().getSelectedItem(), rootSkill)){
            newSkillTextBox.clear();
            reloadTree();
            newSkillParentComboBox.getSelectionModel().select(rootSkill);
        }
    }
    //handles the delete skill function
    @FXML
    private void deleteSkill() throws SQLException{
        TreeItem<String> item = skillsTreeView.getSelectionModel().getSelectedItem();
        if(item == null)
            Dialogs.showErrorDialog(new Stage(), "Please select a skill before clicking delete!", "Delete a Skill");
        else if(skillModel.delete(item.getValue(), item.getParent().getValue())){
            reloadTree();
        }
    }
    //handles the update skill function
    @FXML
    private void updateSkill() throws SQLException{
        TreeItem<String> item = skillsTreeView.getSelectionModel().getSelectedItem();
        if(skillModel.update(item.getValue(), item.getParent().getValue(), 
                editSkillTextBox.getText(), editSkillParentComboBox.getValue())){
        	reloadTree();
        }
    }  
}
