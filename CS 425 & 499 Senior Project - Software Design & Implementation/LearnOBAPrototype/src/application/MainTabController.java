  package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.scene.control.Hyperlink;
import javafx.scene.control.Tab;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;

public class MainTabController extends AbstractController<AnchorPane> {
	@FXML
	private Tab welcomeTab;
	@FXML
	private Tab manageClassTab;
	@FXML
	private Tab editAssignTab;
	@FXML
	private Tab editQuestionTab;
	@FXML
	private Tab editSkillsTab;
	@FXML
	private Tab enterScoresTab;
	@FXML
	private AnchorPane welcomePane;
	@FXML
	private AnchorPane manageClassPane;
	@FXML
	private AnchorPane editAssignPane;
	@FXML
	private AnchorPane editQuestionPane;
	@FXML
	private AnchorPane editSkillsPane;
	@FXML
	private AnchorPane enterScoresPane;
	@FXML
	private ImageView learnobaImage;
	@FXML
	private Hyperlink helpLink;
	@FXML
	private Hyperlink contactLink;
	@FXML
	private Hyperlink exitLink;
	
    
    public MainTabController() {
        super();

    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        setUpTabs();
    }
    //This function is responsible for setting up all of the tabs. It is called by 
    //the login controller to help on the load of the tabs.
    private void setUpTabs() {
        WelcomeGUI welcomeGUI = new WelcomeGUI("WelcomeGUI.fxml", "Welcome");
        ManageClassGUI manageClassGUI = new ManageClassGUI("ManageClass.fxml", "Select Class");
        EditAssignmentGUI editAssignmentGUI =
                new EditAssignmentGUI("EditAssignment.fxml", "Edit Assignment");
        EditSkillsGUI editSkillsGUI = new EditSkillsGUI("EditSkills.fxml", "Edit Skills");
        EnterScoresGUI enterScoresGUI = new EnterScoresGUI("EnterScores.fxml", "Enter Scores");

        welcomePane.getChildren().add(welcomeGUI.getBasePane());
        manageClassPane.getChildren().add(manageClassGUI.getBasePane());
        editAssignPane.getChildren().add(editAssignmentGUI.getBasePane());
        editSkillsPane.getChildren().add(editSkillsGUI.getBasePane());
        enterScoresPane.getChildren().add(enterScoresGUI.getBasePane());
    }


}
