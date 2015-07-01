package com.learnoba.models;

import java.io.File;
import java.io.IOException;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.Scanner;

import com.learnoba.UserSettings;

import javafx.scene.control.ChoiceBox;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

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
    	setFileSelected(selected.getAbsolutePath().toString().replace('\\', '/'));

    }
    //This function is responsible for reading in the class roster.
    public void readInRoster() throws IOException, SQLException{
    	int count=0;
    	String temp;
       	Scanner scan = new Scanner(new File(fileSelected));
        scan.useDelimiter("\n");
    	while(scan.hasNext()){
    		Student currentStudent = new Student();
    		temp=scan.next();  
    		if(count!=0){	
	    		String[] parts=temp.split("\t");
	    		currentStudent.setFirstName(parts[0]);
	    		currentStudent.setLastName(parts[1]);
	    		currentStudent.setEmail(parts[2]);
	    		currentStudent.setUniversityID(parts[3]);
	    		System.out.println(newClass.getClassID());
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
    public void populateScores(ChoiceBox choiceBox){
    	for(int x=0; x<100; x++){
    		choiceBox.getItems().add(Integer.toString(x));
    	}
    }
    //Responsible for creating a class and storing into the database. Sets the class ID of the basic class. 
    public void createClass(int maxScore, String name, String semester, int year) throws SQLException{
    	newClass.setMaxScore(maxScore);
    	newClass.setName(name);
    	newClass.setSemester(semester);
    	newClass.setYear(year);
    	System.out.println(userSettings.getCurrentUserID());
    	newClass.setUserID(userSettings.getCurrentUserID());
    	int ID= getFacade().getInsert().insertClass(newClass);
    	setClassID(ID);
    }
}
