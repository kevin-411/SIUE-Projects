package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.layout.AnchorPane;

public class EditSkillsController extends AbstractController {
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
    private ListView allSkillsListView;
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
    
    public EditSkillsController() {
        super();
    }
    @FXML
    private void addSkillsFired(ActionEvent event) {

    }

    @FXML
    private void removeSkillsFired(ActionEvent event) {

    }
    @FXML
    private void saveFired(ActionEvent event) {
    
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        // TODO Auto-generated method stub

    }

   
}
