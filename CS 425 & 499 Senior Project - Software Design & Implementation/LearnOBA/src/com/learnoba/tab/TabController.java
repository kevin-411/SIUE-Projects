package com.learnoba.tab;

import java.awt.Desktop;
import java.io.*;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;

import com.learnoba.AbstractController;
import com.learnoba.UserSettings;
import com.learnoba.assignment.AssignmentView;
import com.learnoba.classes.manage.ManageClassController;
import com.learnoba.classes.manage.ManageClassView;
import com.learnoba.export.ExportClassView;
import com.learnoba.login.LoginView;
import com.learnoba.scores.ScoresView;
import com.learnoba.skills.SkillsView;
import com.learnoba.welcome.WelcomeView;

public class TabController extends AbstractController<AnchorPane> {
	@FXML
	private TabPane mainTabPane;
	@FXML
	private Tab welcomeTab;
    @FXML
    private Label classNameLabel;
    @FXML
    private Label usernameLabel;
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
    private Hyperlink logOutLink;
    
    private UserSettings userSettings;
    
    public TabController() {
        super();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    	userSettings = UserSettings.getInstance();
        headerImageView.setImage(new Image("file:" + userSettings.translatePath("Header.png")));
        userSettings.setTabController(this);
        setUpWelcomeAndClassTabs();
    }

    private void setUpWelcomeAndClassTabs() {
        WelcomeView welcomeGUI = new WelcomeView("Welcome.fxml", "Welcome");
        ManageClassView manageClassGUI = new ManageClassView("ManageClass.fxml", "Manage Class");
        toggleClassDependentTabs();

        welcomeAnchorPane.getChildren().add(welcomeGUI.getBasePane());
        welcomeAnchorPane.getChildren().add(new Label());
        manageClassAnchorPane.getChildren().add(manageClassGUI.getBasePane());
        manageClassAnchorPane.getChildren().add(new Label());
    }
    
    private void toggleClassDependentTabs() {
        skillsTab.setDisable(!skillsTab.isDisable());
        editAssignmentTab.setDisable(!editAssignmentTab.isDisable());
        enterScoresTab.setDisable(!enterScoresTab.isDisable());
        exportClassTab.setDisable(!exportClassTab.isDisable());
    }

    @FXML
    private void showManualPDF() {
        if (Desktop.isDesktopSupported()) {
            File file = new File(userSettings.translatePath("LOBA-MANUAL R 1.0.pdf"));
            try {
                if (!file.exists()) {
                    // In JAR
                    InputStream inputStream = ClassLoader.getSystemClassLoader()
                            .getResourceAsStream(userSettings.translatePath("LOBA-MANUAL R 1.0.pdf"));
                    // Copy file
                    OutputStream outputStream;

                    outputStream = new FileOutputStream(file);

                    byte[] buffer = new byte[1024];
                    int length;
                    while ((length = inputStream.read(buffer)) > 0) {
                        outputStream.write(buffer, 0, length);
                    }
                    outputStream.close();
                    inputStream.close();
                }
                // Open file
                Desktop.getDesktop().open(file);

            } catch (FileNotFoundException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    @FXML
    private void performLogout() {
        Thread newLoginThread = new LoginViewThread();
        newLoginThread.setDaemon(true);
        newLoginThread.start();
        try {
            Thread.sleep(500);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        this.getPrimaryView().close();
    }

    private ManageClassView selectClassTab() {
        SingleSelectionModel<Tab> selectionModel = mainTabPane.getSelectionModel();
        ManageClassView manageClassGUI = new ManageClassView("ManageClass.fxml", "Manage Class");

        selectionModel.select(1);
        manageClassAnchorPane.getChildren().clear();
        manageClassAnchorPane.getChildren().add(manageClassGUI.getBasePane());
        manageClassAnchorPane.getChildren().add(new Label());
        return manageClassGUI;
    }

    public void loadSelectClass() {
        SingleSelectionModel comboBox =
                ((ManageClassController) selectClassTab().getController()).getOptionComboBox()
                .getSelectionModel();
        comboBox.select(0);

    }

    public void loadCreateClass() {
        SingleSelectionModel comboBox =
                ((ManageClassController) selectClassTab().getController()).getOptionComboBox()
                        .getSelectionModel();
        comboBox.select(1);
    }



    private void deleteClassDependentChildren(Boolean skillTab) {
    	if(skillTab && skillsPane.getChildren() != null && editAssignmentAnchorPane.getChildren()  != null && enterScoresAnchorPane.getChildren()  != null&& exportClassAnchorPane.getChildren() != null){
	    	skillsPane.getChildren().clear();
	        editAssignmentAnchorPane.getChildren().clear();
	        enterScoresAnchorPane.getChildren().clear();
	        exportClassAnchorPane.getChildren().clear();
    	}
    }

    public void refreshClassChildren() {
        deleteChildren();
        setUpWelcomeAndClassTabs();
        updateClassName("(No Class Selected)");
        loadCreateClass();
    }

    private void deleteChildren() {
        welcomeAnchorPane.getChildren().clear();
        manageClassAnchorPane.getChildren().clear();
        skillsPane.getChildren().clear();
        editAssignmentAnchorPane.getChildren().clear();
        enterScoresAnchorPane.getChildren().clear();
        exportClassAnchorPane.getChildren().clear();
    }
    
    public void refreshClassDependentChildren() {
        deleteClassDependentChildren(true);
        setUpClassDependentTabs(true);
    }
    
    public void tabChangeRefreshChildren(){
    	deleteClassDependentChildren(false);
        setUpClassDependentTabs(false);
    }

    // This function is responsible for setting up all of the tabs. It is called by
    // the login controller to help on the load of the tabs.
    private void setUpClassDependentTabs(Boolean skillTab) {
        SkillsView skillsGUI;
        AssignmentView editAssignmentGUI = new AssignmentView("Assignment.fxml", "Edit Assignment");
        ScoresView enterScoresGUI = new ScoresView("Scores.fxml", "Enter Outcomes");
        ExportClassView exportClassGUI = new ExportClassView("ExportClass.fxml", "Export Files");
        if (skillsTab.isDisable()) {
            toggleClassDependentTabs();
        }
        if (skillTab) {
            skillsGUI = new SkillsView("Skills.fxml", "Manage Skills");
            skillsPane.getChildren().add(skillsGUI.getBasePane());
            skillsPane.getChildren().add(new Label());
        }

        editAssignmentAnchorPane.getChildren().add(editAssignmentGUI.getBasePane());
        editAssignmentAnchorPane.getChildren().add(new Label());
        enterScoresAnchorPane.getChildren().add(enterScoresGUI.getBasePane());
        enterScoresAnchorPane.getChildren().add(new Label());
        exportClassAnchorPane.getChildren().add(exportClassGUI.getBasePane());
        exportClassAnchorPane.getChildren().add(new Label());
    }

    public void updateClassName(String newName) {
        classNameLabel.setText(newName);
    }

    public void updateUserName(String newName) {
        usernameLabel.setText(newName);
    }

    public class LoginViewThread extends Thread {
        public void run() {
            Platform.runLater(new Runnable() {
                @Override
                public void run() {
                    LoginView loginView = new LoginView("Login.fxml", "Login Screen");
                    loginView.show();
                }
            });

        }
    }

}
