package com.learnoba;

/**
 * This singleton class is to be used for all global settings provided by the user it can be
 * extended in the future to hold more than simply the current userID and classID.
 */
public class UserSettings {
    private static UserSettings instance = null;
    private static int currentUserID;
    private static int currentClassID;
    private String workingDirectory;

    private UserSettings() {
        currentUserID = -1;
        currentClassID = -1;
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
    }

    /**
     * @return the workingDirectory
     */
    public String getWorkingDirectory() {
        return workingDirectory;
    }

    /**
     * @param workingDirectory the workingDirectory to set
     */
    public void setWorkingDirectory(String workingDirectory) {
        this.workingDirectory = workingDirectory;
    }

}
