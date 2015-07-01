package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;

import com.database.DatabaseFacade;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.ListView;

public class Assignment {
    private int assignmentID;
    private int classID;
    private String assignmentName;
    private DatabaseFacade facade;
    public Assignment() throws SQLException{
    	facade = DatabaseFacade.getInstance();
    }
    /**
     * @return the assignmentID
     */
    public int getAssignmentID() {
        return assignmentID;
    }

    /**
     * @param assignmentID the assignmentID to set
     */
    public void setAssignmentID(int assignmentID) {
        this.assignmentID = assignmentID;
    }

    /**
     * @return the assignmentName
     */
    public String getAssignmentName() {
        return assignmentName;
    }

    /**
     * @param assignmentName the assignmentName to set
     */
    public void setAssignmentName(String assignmentName) {
        this.assignmentName = assignmentName;
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
    //TODO: Work on these insert queries and what not with matt.
    public void addAssignment(String name, String type) throws SQLException{
    	Assignment ass = new Assignment();
    	ass.setAssignmentName("name");
    	facade.getInsert().insertAssignment(ass);
    }
    public void deleteAssignment(Assignment ass) throws SQLException{
    	facade.getDelete().deleteAssignment(ass);
    }
    public void addTask(Assignment ass, String answer, String text, QuestionType type) throws SQLException{
    	Task task = new Task();
    	task.setAssignmentID(ass.getAssignmentID());
    	task.setQuestionAnswer(answer);
    	task.setQuestionText(text);
    	task.setType(type);
    	facade.getInsert().insertTask(task);
    }
    public void editTask(Assignment ass, Task task){
    	//Grab the question from database
    	//Set its new content
    	//Store back in database
    }
    public void deleteTask(Task task) throws SQLException{
    	facade.getDelete().deleteTask(task);
    }
    public void addSkills() throws SQLException{

    }
    public void deleteSkills(){
    	
    }
    //This is going to be responsible for populating the appropriate elements.
    public ObservableList populateElement(char type) throws SQLException{
    	ObservableList<String> values = FXCollections.observableArrayList();
    	ResultSet set=selectQuery(type);
    	while(set.next()){
			values.add(set.getObject(1).toString());
    	}
    	return values;
    }
    //This is going to be responsible for running the appropriate query.
    public ResultSet selectQuery(char type) throws SQLException{
    	ResultSet set;
    	if(type=='a')
    		set= facade.getSelect().getAssignmentByClass(getClassID());
    	//TODO:Change these to the correct queries once matt has them completed.
    	else if(type =='q'){
    		set= facade.getSelect().getAssignmentByClass(getClassID());
    	}
    	else{
    		set= facade.getSelect().getAssignmentByClass(getClassID());
    	}
    	return set;
    }
}
