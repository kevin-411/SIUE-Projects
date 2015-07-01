package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;

public class EditAssignmentController extends AbstractController {
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
    private RadioButton addQuestionRadio;
    @FXML
    private Label hiddenNameLabel;
    @FXML
    private TextField nameTextBox;
    @FXML
    private Label hiddenTypeLabel;
    @FXML
    private TextField typeTextBox;
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
    public EditAssignmentController() {
        super();
    }
    @FXML
    private void addQuestionFired(ActionEvent event) {
    	enableAddQuestions();
    }

    @FXML
    private void editSkillsFired(ActionEvent event) {
    	EditSkillsController controller= new EditSkillsController();
    	controller.setPrimaryView(new EditSkillsGUI("EditSkills.fxml", "Select Class Screen"));
    	controller.getPrimaryView().show();
    }
    @FXML
    private void deleteQuestionFired(ActionEvent event) {
   
          
    }

    @FXML
    private void selectFired(ActionEvent event) {
   
    }
    @FXML
    private void saveFired(ActionEvent event) {
   
    }
    private void enableAddQuestions() {
    	hiddenNameLabel.setVisible(true);
    	hiddenTypeLabel.setVisible(true);
    	typeTextBox.setVisible(true);
    	nameTextBox.setVisible(true);
    	questionLabel.setVisible(true);
    	questionTextBox.setVisible(true);
    	solutionLabel.setVisible(true);
    	solutionTextBox.setVisible(true);
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        // TODO Auto-generated method stub

    }
}
