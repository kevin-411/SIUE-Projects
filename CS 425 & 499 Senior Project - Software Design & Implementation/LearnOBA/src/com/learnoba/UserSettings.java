package com.learnoba;

import java.io.File;
import java.net.URISyntaxException;
import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.database.DatabaseFacade;
import com.learnoba.tab.TabController;

/**
 * This singleton class is to be used for all global settings provided by the user it can be
 * extended in the future to hold more than simply the current userID and classID.
 */
public class UserSettings {
    private static UserSettings instance = null;
    private static int currentUserID;
    private static int currentClassID;
    private static int currentMaxOutcome;
    private String workingDirectory;
    private TabController tabController;

    private UserSettings() {
        currentUserID = -1;
        currentClassID = -1;
        currentMaxOutcome = -1;
        workingDirectory = null;
    }

    public static UserSettings getInstance() {
        if (instance == null) {
            instance = new UserSettings();
        }
        return instance;
    }

    /**
     * @return the currentUserID
     */
    public static int getCurrentUserID() {
        return currentUserID;
    }

    /**
     * @param currentUserID the currentUserID to set
     */
    public static void setCurrentUserID(int currentUserID) {
        UserSettings.currentUserID = currentUserID;
    }

    /**
     * @return the currentClassID
     */
    public static int getCurrentClassID() {
        return currentClassID;
    }

    /**
     * @param currentClassID the currentClassID to set
     */
    public static void setCurrentClassID(int currentClassID) {
        UserSettings.currentClassID = currentClassID;
        updateClassName();
    }

    private static void updateClassName() {
        try {
            ResultSet set = DatabaseFacade.getInstance().getSelect().getClassByID(currentClassID);
            set.next();
            instance.getTabController().updateClassName(set.getString("class_name"));
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * @return the currentMaxOutcome
     */
    public static int getCurrentMaxOutcome() {
        return currentMaxOutcome;
    }

    /**
     * @param currentMaxOutcome the currentMaxOutcome to set
     */
    public static void setCurrentMaxOutcome(int currentMaxOutcome) {
        UserSettings.currentMaxOutcome = currentMaxOutcome;
    }

    /**
     * @return the workingDirectory
     */
    public String getWorkingDirectory() {
        if (workingDirectory == null) {
            determineDefaultDirectory();
        }
        return workingDirectory;
    }

    /**
     * @param workingDirectory the workingDirectory to set
     */
    public void setWorkingDirectory(String workingDirectory) {
        this.workingDirectory = workingDirectory;
    }

    /**
     * This is separating the default directory by operating system. Windows has to get set
     * differently from OS X and Linux. OS X and Linux are kept separate even thought they still
     * have the same user.home variable being set just for completeness.
     */
    private static void determineDefaultDirectory() {
        String OS = (System.getProperty("os.name")).toUpperCase();
        if (OS.contains("WIN")) {
            instance.setWorkingDirectory(System.getenv("USERPROFILE"));
        }
        else if (OS.contains("MAC")) {
            // in either case, we would start in the user's home directory
            instance.setWorkingDirectory(
                    System.getProperty("user.home"));
        }
        else {
            instance.setWorkingDirectory(System.getProperty("user.home"));
        }
    }

    /**
     * @return the tabController
     */
    public TabController getTabController() {
        return tabController;
    }

    /**
     * @param tabController the tabController to set
     */
    public void setTabController(TabController tabController) {
        this.tabController = tabController;
    }
    
    public String translatePath(String resource){
        URL url = getClass().getProtectionDomain().getCodeSource().getLocation();
        File myfile = null;
        try {
            myfile = new File(url.toURI());
        } catch (URISyntaxException e1) {
            e1.printStackTrace();
        }
        File dir = myfile.getParentFile();
        //uncomment me for testing
        return dir.getAbsolutePath().concat("/resources/" + resource);
        //uncomment me for implementation
        // return dir.getAbsolutePath().concat("/" + resource);
    }

}
