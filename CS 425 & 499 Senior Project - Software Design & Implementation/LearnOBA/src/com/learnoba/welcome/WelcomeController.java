package com.learnoba.welcome;

import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Hyperlink;
import javafx.scene.control.Label;
import javafx.scene.control.Separator;
import javafx.scene.control.TextArea;
import javafx.scene.layout.AnchorPane;

import com.database.DatabaseFacade;
import com.learnoba.AbstractController;
import com.learnoba.UserSettings;
import com.learnoba.tab.TabController;

public class WelcomeController extends AbstractController<AnchorPane> {

	@FXML
	private AnchorPane welcomeScreenAnchorPane;
	@FXML
	private Label welcomeTitle;
	@FXML
	private Label quickLinks;
	@FXML
	private Label recentClasses;
	@FXML
    private Label whatLabel;
    @FXML
    private Label howLabel;
    @FXML
    private Label whereLabel;
    @FXML
    private Hyperlink addClassLink;
    @FXML
    private Hyperlink selectClassLink;
    @FXML
    private Hyperlink recentClassOne;
    @FXML
    private Hyperlink recentClassTwo;
    @FXML
    private Hyperlink recentClassThree;
	@FXML
	private Separator separatorOne;
	@FXML
	private Separator separatorTwo;
	@FXML
    private TextArea whatTextArea;
    @FXML
    private TextArea howTextArea;
    @FXML
    private TextArea whereTextArea;

    private TabController tabController;

    private DatabaseFacade facade;
    private UserSettings settings;
    private List<Integer> ids;

	public WelcomeController(){
		super();
        ids = new ArrayList<Integer>();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        try {
            facade = DatabaseFacade.getInstance();
            settings = UserSettings.getInstance();
            tabController = settings.getTabController();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        setUpRecentClasses();
	}

	@FXML
    public void addClassClick(ActionEvent event) {
        ((TabController) tabController).loadCreateClass();
	}
	@FXML
    public void selectClassClick(ActionEvent event) {
        ((TabController) tabController).loadSelectClass();
	}

	private void setUpRecentClasses(){
        clearLabel(recentClassOne);
        clearLabel(recentClassTwo);
        clearLabel(recentClassThree);

        ids.clear();
        try {
            ResultSet rs = facade.getSelect().getMostRecentClasses(settings.getCurrentUserID());
            int count = 1;
            while (rs.next()) {
                String className = rs.getString("class_name");
                Integer classID = rs.getInt("class_id");
                if (count == 1) {
                    recentClassOne.setText(className);
                    recentClassOne.setDisable(false);
                } else if (count == 2) {
                    recentClassTwo.setText(className);
                    recentClassTwo.setDisable(false);
                } else {
                    recentClassThree.setText(className);
                    recentClassThree.setDisable(false);
                }
                ids.add(classID);
                count++;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
	}

    @FXML
    private void recentClassOneClick() {
        UserSettings.setCurrentClassID(ids.get(0));
        ((TabController) tabController).loadSelectClass();
    }

    @FXML
    private void recentClassTwoClick() {
        UserSettings.setCurrentClassID(ids.get(1));
        ((TabController) tabController).loadSelectClass();
    }

    @FXML
    private void recentClassThreeClick() {
        UserSettings.setCurrentClassID(ids.get(2));
        ((TabController) tabController).loadSelectClass();
    }

    private void clearLabel(Hyperlink label) {
        label.setText("");
        label.setDisable(true);
    }

}
