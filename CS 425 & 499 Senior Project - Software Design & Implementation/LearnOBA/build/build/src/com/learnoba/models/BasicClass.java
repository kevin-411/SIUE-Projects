package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.ChoiceBox;

import com.database.DatabaseFacade;
import com.learnoba.AbstractModel;
public class BasicClass extends AbstractModel {

    private String name;
    private int year;
    private String semester;
    private int classID;
    private int userID;
    private int maxScore;
    private DatabaseFacade facade;
    
    public BasicClass() throws SQLException{
    	facade = DatabaseFacade.getInstance();
    }
    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }


    /**
     * @return the year
     */
    public int getYear() {
        return year;
    }

    /**
     * @param year the year to set
     */
    public void setYear(int year) {
        this.year = year;
    }

    /**
     * @return the season
     */
    public String getSemester() {
        return semester;
    }

    /**
     * @param season the season to set
     */
    public void setSemester(String season) {
        this.semester = season;
    }

    /**
     * @return the classID
     */
    public int getClassID() {
        return classID;
    }

    /**
     * @param classID the classID to set
     */
    public void setClassID(int classID) {
        this.classID = classID;
    }
    
    /**
     * @return the maxScore
     */
    public int getMaxScore() {
        return maxScore;
    }

    /**
     * @param maxScore the maxScore to set
     */
    public void setMaxScore(int maxScore) {
        this.maxScore = maxScore;
    }
    
    /**
     * @return the userID
     */
    public int getUserID() {
        return userID;
    }

    /**
     * @param classID the userID to set
     */
    public void setUserID(int userID) {
        this.userID = userID;
    }
    
    /**
     * @return the students
     */
    public DatabaseFacade getFacade() {
        return facade;
    }

    /**
     * @param students the students to set
     */
    public void setFacade(DatabaseFacade facade) {
        this.facade = facade;
    }

}
