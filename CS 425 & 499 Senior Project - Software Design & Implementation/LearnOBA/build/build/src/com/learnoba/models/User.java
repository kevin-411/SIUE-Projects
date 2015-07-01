package com.learnoba.models;

public class User {
    private int userID;
    private String userName;
    private String password;

    /**
     * @return the userId
     */
    public int getUserID() {
        return userID;
    }

    /**
     * @param userId the userId to set
     */
    public void setUserID(int userID) {
        this.userID = userID;
    }

    /**
     * @return the userName
     */
    public String getUserName() {
        return userName;
    }

    /**
     * @param userName the userName to set
     */
    public void setUserName(String userName) {
        this.userName = userName;
    }

    /**
     * @return the password
     */
    public String getPassword() {
        return password;
    }

    /**
     * @param password the password to set
     */
    public void setPassword(String password) {
        this.password = password;
    }
}
