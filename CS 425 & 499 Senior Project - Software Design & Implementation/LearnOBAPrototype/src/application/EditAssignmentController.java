package application;

import java.net.URL;
import java.util.ResourceBundle;

import javax.swing.event.DocumentEvent.EventType;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.Dialogs.DialogOptions;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class EditAssignmentController extends AbstractController<AnchorPane> {
	@FXML
    private Label nameLabel;
    @FXML
    private Label selectedNameLabel;
    @FXML
    private Label typeLabel;
    @FXML
    private Label selectedTypeLabel;
    @FXML
    private Label percentLabel;
    @FXML
    private Label selectedPercentLabel;
    @FXML
    private Label questionsLabel;
    @FXML
    private ListView questionsListView;
    @FXML
    private Button editSkillsButton;
    @FXML
    private Button deleteQuestionButton;
    @FXML
    private Button createQuestionButton;
    @FXML
    private RadioButton addQuestionRadio;
    @FXML
    private RadioButton viewRadioButton;
    @FXML
    private Label hiddenNameLabel;
    @FXML
    private TextField nameTextBox;
    @FXML
    private Label hiddenTypeLabel;
    @FXML
    private ComboBox typeComboBox;
    @FXML
    private Label shortLabel;
    @FXML
    private Label questionLabel;
    @FXML
    private TextArea questionTextBox;
    @FXML
    private Label solutionLabel;
    @FXML
    private TextArea solutionTextBox;
    @FXML
    private Button saveButton;
    @FXML
    private AnchorPane editAssignmentPanel;
    @FXML
    private Label initialNameLabel;
    @FXML
    private Label initialNameLabel2;
    @FXML
    private Label initialTypeLabel;
    @FXML
    private Label initialQuestionLabel;
    @FXML
    private Label initialQuestionLabel2;
    @FXML
    private Label initialSolutionLabel;
    @FXML
    private Label initialSolutionLabel2;

    public EditAssignmentController() {
        super();
    }
    @FXML
    private void addQuestionFired(ActionEvent event) {
    	enableAddQuestions();
    }

    @FXML
    private void deleteQuestionFired(ActionEvent event) {
    	Dialogs.showInformationDialog(new Stage(), "Are you sure you would like to delete this Question?", "Success!", "Delete Student?");
          
    }
    @FXML
    private void viewQuestionsFired(ActionEvent event) {
   
          enableQuestionLabels();
    }
    @FXML
    private void selectFired(ActionEvent event) {
   
    }
    @FXML
    private void createQuestionFired(ActionEvent event) {
   
    }
    @FXML
    private void saveFired(ActionEvent event) {
   
    }
    private void enableQuestionLabels() {
    	disableAddQuestions();
    	initialNameLabel.setVisible(true);
    	initialNameLabel2.setVisible(true);
    	initialTypeLabel.setVisible(true);
    	shortLabel.setVisible(true);
    	initialQuestionLabel.setVisible(true);
    	initialQuestionLabel2.setVisible(true);
    	initialSolutionLabel.setVisible(true);
    	initialSolutionLabel2.setVisible(true);
    	deleteQuestionButton.setVisible(true);
    }
    private void disableQuestionLabels() {
    	initialNameLabel.setVisible(false);
    	initialNameLabel2.setVisible(false);
    	initialTypeLabel.setVisible(false);
    	shortLabel.setVisible(false);
    	initialQuestionLabel.setVisible(false);
    	initialQuestionLabel2.setVisible(false);
    	initialSolutionLabel.setVisible(false);
    	initialSolutionLabel2.setVisible(false);
    	deleteQuestionButton.setVisible(false);
    }
    private void enableAddQuestions() {
    	disableQuestionLabels();
    	hiddenNameLabel.setVisible(true);
    	hiddenTypeLabel.setVisible(true);
    	typeComboBox.setVisible(true);
    	nameTextBox.setVisible(true);
    	questionLabel.setVisible(true);
    	questionTextBox.setVisible(true);
    	solutionLabel.setVisible(true);
    	solutionTextBox.setVisible(true);
    	createQuestionButton.setVisible(true);
    }
    private void disableAddQuestions() {
    	hiddenNameLabel.setVisible(false);
    	hiddenTypeLabel.setVisible(false);
    	typeComboBox.setVisible(false);
    	nameTextBox.setVisible(false);
    	questionLabel.setVisible(false);
    	questionTextBox.setVisible(false);
    	solutionLabel.setVisible(false);
    	solutionTextBox.setVisible(false);
    	createQuestionButton.setVisible(false);
    }
    @Override
    public void initialize(URL location, ResourceBundle resources) {
    	ObservableList<String> items =FXCollections.observableArrayList (
    	    "Question 1", "Question 2", "Question 3", "Question 4", "Question 5", "Question 6",
    	    "Question 7", "Question 8");
    	questionsListView.setItems(items);
    	
    questionsListView.getSelectionModel().selectedItemProperty().addListener(
    		new ChangeListener<String>() {
                public void changed(ObservableValue<? extends String> ov, 
                    String old_val, String new_val) {
                	viewRadioButton.setDisable(false);
            }});
    	
    }
    
    
}
