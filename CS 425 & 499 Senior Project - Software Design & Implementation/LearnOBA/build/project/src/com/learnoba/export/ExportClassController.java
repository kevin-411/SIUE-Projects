package com.learnoba.export;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;

import com.learnoba.AbstractController;

public class ExportClassController extends AbstractController<AnchorPane> {
    
    @FXML
    private ResourceBundle resources;

    @FXML
    private URL location;

    @FXML
    private RadioButton allStudentsRadio;

    @FXML
    private RadioButton averageRadio;

    @FXML
    private RadioButton blackboardFileRadio;

    @FXML
    private RadioButton csvRadio;

    @FXML
    private AnchorPane exportAnchorPane;

    @FXML
    private Button exportButton;

    @FXML
    private Label exportClassLabel;

    @FXML
    private Pane exportPane;

    @FXML
    private Pane filePane;

    @FXML
    private ToggleGroup file_group;

    @FXML
    private RadioButton oneStudentRadio;

    @FXML
    private Pane optionsPane;

    @FXML
    private RadioButton pdfFileRadio;

    @FXML
    private ListView<?> selectAssignmentListView;

    @FXML
    private ListView<?> selectStudentListView;

    @FXML
    private RadioButton sumRadio;

    @FXML
    private RadioButton top3AverageRadio;

    @FXML
    private RadioButton tsvRadio;

    @FXML
    private ToggleGroup x1;

    @FXML
    private ToggleGroup x2;

    
    public ExportClassController() throws SQLException {
        super();
    }

    @Override
    public void initialize(URL fxmlFileLocation, ResourceBundle resources) {
        assert allStudentsRadio != null : "fx:id=\"allStudentsRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert averageRadio != null : "fx:id=\"averageRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert blackboardFileRadio != null : "fx:id=\"blackboardFileRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert csvRadio != null : "fx:id=\"csvRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert exportAnchorPane != null : "fx:id=\"exportAnchorPane\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert exportButton != null : "fx:id=\"exportButton\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert exportClassLabel != null : "fx:id=\"exportClassLabel\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert exportPane != null : "fx:id=\"exportPane\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert filePane != null : "fx:id=\"filePane\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert file_group != null : "fx:id=\"file_group\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert oneStudentRadio != null : "fx:id=\"oneStudentRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert optionsPane != null : "fx:id=\"optionsPane\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert pdfFileRadio != null : "fx:id=\"pdfFileRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert selectAssignmentListView != null : "fx:id=\"selectAssignmentListView\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert selectStudentListView != null : "fx:id=\"selectStudentListView\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert sumRadio != null : "fx:id=\"sumRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert top3AverageRadio != null : "fx:id=\"top3AverageRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert tsvRadio != null : "fx:id=\"tsvRadio\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert x1 != null : "fx:id=\"x1\" was not injected: check your FXML file 'ExportClass.fxml'.";
        assert x2 != null : "fx:id=\"x2\" was not injected: check your FXML file 'ExportClass.fxml'.";
    }
}
