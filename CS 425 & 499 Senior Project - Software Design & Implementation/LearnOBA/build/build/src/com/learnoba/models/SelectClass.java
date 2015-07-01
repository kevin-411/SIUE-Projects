package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListView;
import com.learnoba.UserSettings;
public class SelectClass extends BasicClass {
	private ObservableList<Student> students;
	private UserSettings userSettings; 
    public SelectClass() throws SQLException {
    	students =   FXCollections.observableArrayList();
    	userSettings = UserSettings.getInstance();
    }
 
    //This function is responsible for populating the students within a class
    public ObservableList populateStudents(ListView rosterListView, String year, String semester) throws SQLException{
    	ObservableList<String> values = FXCollections.observableArrayList();
    	students.clear();
    	ResultSet set;
    	userSettings.setCurrentClassID((int)(getFacade().getSelect().getClass(year, semester, userSettings.getCurrentUserID()).getObject(1)));
    	set=getFacade().getSelect().getStudents(userSettings.getCurrentClassID());
    	//Have to convert result set to a list so we can add to dropdown.
    	while(set.next()){
    			Student newStudent = new Student();
    			newStudent.setFirstName(set.getObject("first_name").toString());
    			newStudent.setLastName(set.getObject("last_name").toString());
    			newStudent.setUniversityID(set.getObject("student_id_code").toString());
    			students.add(newStudent);
    			students.get(students.size()-1).setStudentID(set.getInt("student_id"));
    			values.add(set.getObject(2).toString() + " " + set.getObject(3).toString());
    	}
    	return values;
    }
    
    //This function is responsible for adding a student to a class
    //****NEEDS TESTING
    public void addStudent(String first, String last, String universityID) throws SQLException{
    	Student student = new Student();
    	//TODO: figure out why its reversed? Makes no sense
    	student.setFirstName(last);
    	student.setLastName(first);
    	student.setUniversityID(universityID);
    	students.add(student);
        int studentId = getFacade().getInsert().insertStudentClass(student, userSettings.getCurrentClassID());
        students.get(students.size()-1).setStudentID(studentId);
    	
    }
    
    //This function is responsible for deleting a student. Goes through all of the students
    //and find the one that is selected to be deleted
    //****NEEDS TESTING
    public void deleteStudent(int index) throws SQLException{
    	ResultSet set=getFacade().getSelect().getStudents(userSettings.getCurrentClassID());
    	Student selectedStudent = new Student();
    	while(set.next()){
    		//TODO: here is where I need to compare student ID's find the right student and remove from database.
    		if(set.getObject("student_id_code").toString().equals(students.get(index).getUniversityID())){
    			selectedStudent =  students.get(index);
    		}
    	}
    	System.out.println(index);
    	students.remove(index);
    	for(int x=0; x<students.size(); x++){
    		System.out.println(students.get(x).getFirstName());
    	}
       getFacade().getDelete().deleteStudent(selectedStudent);
    }
    
    //Responsible for populating a particular element.
    public ObservableList populateElement(char type, String year, String semester) throws SQLException{
    	ObservableList<String> values = FXCollections.observableArrayList();
    	ResultSet set = null;
    	set=selectQuery(type, year, semester);
    	while(set.next()){
    			if(type == 'y' || type == 's')
    				values.add(set.getObject(1).toString());
    			else
    				values.add(set.getObject(5).toString());
    	}
    	return values;
    }
    //Function that calls the appropriate query to load the correct dropdown
    private ResultSet selectQuery(char type, String year, String semester) throws SQLException{
    	if(type=='y'){
    		return getFacade().getSelect().getYears();
    	}
    	else if(type=='s'){
    		System.out.println(year);
    		return getFacade().getSelect().getSemesters(year);
    		
    	}
    	else if (type=='c'){ 
    		//TODO:Need to get the right user id
    		return getFacade().getSelect().getClass(year, semester, userSettings.getCurrentUserID());
    		
    	}
    	return null;
    }
}
