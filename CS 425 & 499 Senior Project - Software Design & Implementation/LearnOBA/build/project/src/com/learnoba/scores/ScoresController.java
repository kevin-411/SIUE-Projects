package com.learnoba.scores;

import java.net.URL;
import java.util.ResourceBundle;

import com.learnoba.AbstractController;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.control.TreeItem;
import javafx.scene.control.TreeView;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;


public class ScoresController extends AbstractController<AnchorPane>{

    @FXML
    AnchorPane enterScoresPane;
    @FXML
    ListView<String> studentsListView;
    @FXML
    ListView<String> assignmentsListView;
    @FXML
    TreeView<String> tasksTreeView;
    @FXML
    Label editScoresLabel;
    @FXML
    Label studentsLabel;
    @FXML
    Label assignmentsLabel;
    @FXML
    Label tasksLabel;
    @FXML
    Pane studentInfoPane;
    @FXML
    TextField firstNameTextField;
    @FXML
    TextField middleNameTextField;
    @FXML
    TextField lastNameTextField;
    @FXML
    TextField studentIDTextField;
    @FXML
    TextField emailTextField;
    
    ObservableList<String> students = FXCollections.observableArrayList(
            "Baggins, Frodo", "Christ, Jesus", "Bond, James", "Wayne, Bruce", "Squarepants, Spongebob");
    ObservableList<String> assignments = FXCollections.observableArrayList(
            "Assignment 1", "Assignment 2", "Assignment 3", "Assignment 4", "Assignment 5",
            "Assignment 6", "Assignment 7", "Assignment 8", "Assignment 9", "Assignment 10");
    ObservableList<TreeItem<String>> questions;
    
    public ScoresController() {
        super();
    }


    @SuppressWarnings("unchecked")
    @Override
    public void initialize(URL location, ResourceBundle resources) {
        FXCollections.sort(students);
        studentsListView.setItems(students);
        questions = FXCollections.observableArrayList();
        //set up task items
        TreeItem<String> root = new TreeItem<String>("Tasks");
    	for(int i = 0; i < 7; i++){
    		TreeItem<String> question = new TreeItem<String>("Question " + i);
    		for(int x = 0; x < 3; x++){
    			TextField text = new TextField("5");
    			text.setMaxWidth(40);
    			TreeItem<String> task = new TreeItem<String>("   Task" + x, text);
    			question.getChildren().add(task);
    		}
    		questions.add(question);
        }
        tasksTreeView.setRoot(root);
        
        root.setExpanded(false);
        tasksTreeView.setShowRoot(false);
        
        //When the selected student is changed, clear assignment selection and clear task items
        studentsListView.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>(){
            @Override
            public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue){
            	assignmentsListView.getItems().clear();
            	assignmentsListView.getItems().addAll(assignments);
            	tasksTreeView.getRoot().getChildren().removeAll(questions);
            }
        });
        //When the selected student is changed, clear assignment selection and clear task items
        assignmentsListView.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>(){
            @Override
            public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue){
                tasksTreeView.getRoot().getChildren().removeAll(questions);
                tasksTreeView.getRoot().getChildren().addAll(questions);
            }
        });
        
    }
}
