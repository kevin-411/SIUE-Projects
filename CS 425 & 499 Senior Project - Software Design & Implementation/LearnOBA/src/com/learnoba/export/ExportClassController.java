package com.learnoba.export;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;

import com.database.DatabaseFacade;
import com.learnoba.AbstractController;
import com.learnoba.models.Assignment;
import com.learnoba.models.ExportClass;
import com.learnoba.models.Student;

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
    private ToggleGroup delimiterGroup;

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
    private ToggleGroup filetypeGroup;

    @FXML
    private RadioButton oneStudentRadio;

    @FXML
    private ToggleGroup operationGroup;

    @FXML
    private Pane optionsPane;

    @FXML
    private RadioButton pdfFileRadio;

    @FXML
    private ListView<?> selectAssignmentListView;

    @FXML
    private ListView<?> selectStudentListView;

    @FXML
    private ToggleGroup studentQuantityGroup;

    @FXML
    private RadioButton sumRadio;

    @FXML
    private RadioButton top3AverageRadio;

    @FXML
    private RadioButton tsvRadio;

    ExportClass exportClass;
    DatabaseFacade facade;

    public ExportClassController() {
        super();
        exportClass = new ExportClass();
        try {
            facade = DatabaseFacade.getInstance();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void initialize(URL fxmlFileLocation, ResourceBundle resources) {
        updateLists();
    }

    private void updateLists() {
        try {
            selectAssignmentListView.getItems().addAll(exportClass.populateAssignments());
            selectStudentListView.getItems().addAll(exportClass.populateStudents());

            if (selectAssignmentListView.getItems().size() > 0) {
                selectAssignmentListView.getSelectionModel().selectFirst();
            }
            if (selectStudentListView.getItems().size() > 0) {
                selectStudentListView.getSelectionModel().selectFirst();
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @FXML
    public void exportClick() {
        if (pdfFileRadio.isSelected()) {
            Student student = null;
            if (!allStudentsRadio.isSelected()) {
                student =
                    exportClass.getStudent(selectStudentListView.getSelectionModel()
                            .getSelectedIndex());
            }

            Assignment assignment =
                    exportClass.getAssignment(selectAssignmentListView.getSelectionModel()
                            .getSelectedIndex());
            exportClass.generatePDFOutputFiles(allStudentsRadio.isSelected(), student, assignment);
        } else {
            OutcomeOperation op =
                    averageRadio.isSelected() ? OutcomeOperation.AVG :
                                             sumRadio.isSelected() ? OutcomeOperation.SUM :
                                                                  OutcomeOperation.TOP3;
            exportClass.generateBlackboardDelimitedFiles(csvRadio.isSelected(), op);
        }

    }

    @FXML
    public void quantityRadioButtonClick() {
        selectStudentListView.setDisable(allStudentsRadio.isSelected());
    }


}
