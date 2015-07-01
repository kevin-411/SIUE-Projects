package com.learnoba.models;

import java.io.File;
import java.io.IOException;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.Scanner;

import javafx.scene.control.ChoiceBox;
import javafx.scene.control.ComboBox;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import com.learnoba.UserSettings;

public class CreateClass extends BasicClass {
	
	private String fileSelected;
	private UserSettings userSettings;
	BasicClass newClass;
    // Responsible for getting an instance of the database facade
    public CreateClass() throws SQLException {
    	newClass = new BasicClass();
    	userSettings = UserSettings.getInstance();
    }
    public String getFileSelected(){
    	return fileSelected;
    }
    public void setFileSelected(String fileSelected){
    	this.fileSelected=fileSelected;
    }
    //This function is responsible for loading a filePicker and sets the
    //File selected
    public void showFilePicker(){
    	Stage popUp = new Stage();
    	popUp.setHeight(200);
    	popUp.setWidth(200);
    	FileChooser fileChooser = new FileChooser();
    	fileChooser.setTitle("Select Class File");
    	File selected=fileChooser.showOpenDialog(popUp);
        if (selected != null) {
            setFileSelected(selected.getAbsolutePath().toString().replace('\\', '/'));
        }
    }
    //This function is responsible for reading in the class roster.
    // The roster should be in this order:
    // Last Name First Name Username Student ID
    public void readInRoster() throws IOException, SQLException{
    	int count=0;
    	String temp;
       	Scanner scan = new Scanner(new File(fileSelected), "UTF-16LE");
        scan.useDelimiter("\n");
    	while(scan.hasNext()){
    		Student currentStudent = new Student();
        	temp = scan.next();
    		if(count!=0 && temp.length()!=1){	
    	    	String[] parts=temp.split("\t");
                currentStudent.setFirstName(parts[1]);
                currentStudent.setLastName(parts[0]);
                currentStudent.setEmail(parts[2]);
    	    	currentStudent.setUniversityID(parts[3]);
                getFacade().getInsert().insertStudentClass(currentStudent, getClassID());
        	}
        		count=1;
    			
    		}
      }
    //This function is responsible for grabbing the current year and adding appropriate values
    //to the year choiceBox
    public void findYears(ChoiceBox choiceBox){
    	int year = Calendar.getInstance().get(Calendar.YEAR);
    	for(int x=year; x<year +10; x++){
    		choiceBox.getItems().add(Integer.toString(x));
    	}
    }
    public void populateScores(ComboBox combo){
    	for(int x=0; x<101; x++){
    		combo.getItems().add(Integer.toString(x));
    	}
    }
    //Responsible for creating a class and storing into the database. Sets the class ID of the basic class. 
    public void createClass(int maxScore, String name, String semester, int year) throws SQLException{
    	newClass.setMaxScore(maxScore);
    	newClass.setName(name);
    	newClass.setSemester(semester);
    	newClass.setYear(year);
    	newClass.setUserID(userSettings.getCurrentUserID());
    	int ID= getFacade().getInsert().insertClass(newClass);
        userSettings.setCurrentClassID(ID);
        userSettings.setCurrentMaxOutcome(maxScore);
    	setClassID(ID);
    }
}
