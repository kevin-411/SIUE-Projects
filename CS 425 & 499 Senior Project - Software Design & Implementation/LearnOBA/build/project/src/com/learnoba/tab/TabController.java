package com.learnoba.tab;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.scene.control.Hyperlink;
import javafx.scene.control.Tab;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;

import com.learnoba.AbstractController;
import com.learnoba.assignment.AssignmentView;
import com.learnoba.classes.manage.ManageClassView;
import com.learnoba.export.ExportClassView;
import com.learnoba.scores.ScoresView;
import com.learnoba.skills.SkillsView;
import com.learnoba.welcome.WelcomeView;

public class TabController extends AbstractController<AnchorPane> {
	@FXML
	private Tab welcomeTab;
	@FXML
	private Tab manageClassTab;
	@FXML
	private Tab skillsTab;
	@FXML
	private Tab editAssignmentTab;
	@FXML
	private Tab enterScoresTab;
	@FXML
    private Tab exportClassTab;
	@FXML
	private AnchorPane tabAnchorPane;
	@FXML
	private AnchorPane welcomeAnchorPane;
	@FXML
	private AnchorPane manageClassAnchorPane;
	@FXML
	private AnchorPane skillsPane;
	@FXML
	private AnchorPane editAssignmentAnchorPane;
	@FXML
	private AnchorPane enterScoresAnchorPane;
	@FXML
    private AnchorPane exportClassAnchorPane;
	@FXML
	private ImageView headerImageView;
	@FXML
	private Hyperlink helpLink;
	@FXML
	private Hyperlink contactLink;
    
    public TabController() {
        super();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        setUpTabs();
    }
    //This function is responsible for setting up all of the tabs. It is called by 
    //the login controller to help on the load of the tabs.
    private void setUpTabs() {
    	WelcomeView welcomeGUI = new WelcomeView("Welcome.fxml", "Welcome");
        ManageClassView manageClassGUI = new ManageClassView("ManageClass.fxml", "Manage Class");
        SkillsView skillsGUI = new SkillsView("Skills.fxml", "Manage Skills");
        AssignmentView editAssignmentGUI =
                new AssignmentView("Assignment.fxml", "Edit Assignment");
        ScoresView enterScoresGUI = new ScoresView("Scores.fxml", "Enter Scores");
        ExportClassView exportClassGUI = new ExportClassView("ExportClass.fxml", "Export Files");

        welcomeAnchorPane.getChildren().add(welcomeGUI.getBasePane());
        manageClassAnchorPane.getChildren().add(manageClassGUI.getBasePane());
        skillsPane.getChildren().add(skillsGUI.getBasePane());
        editAssignmentAnchorPane.getChildren().add(editAssignmentGUI.getBasePane());
        enterScoresAnchorPane.getChildren().add(enterScoresGUI.getBasePane());
        exportClassAnchorPane.getChildren().add(exportClassGUI.getBasePane());
    }


}
