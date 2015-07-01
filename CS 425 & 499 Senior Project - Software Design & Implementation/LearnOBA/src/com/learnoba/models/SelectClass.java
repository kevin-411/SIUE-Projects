package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListView;

import com.learnoba.UserSettings;
public class SelectClass extends BasicClass {
	private ObservableList<Student> students;
	private ObservableList<BasicClass> classes;
	private UserSettings userSettings; 
	
    public SelectClass() throws SQLException {
    	students =   FXCollections.observableArrayList();
    	classes = FXCollections.observableArrayList();
    	userSettings = UserSettings.getInstance();
    }
    //This function is responsible for populating the select class tab if a class was created
    public void populateSelectClass(ListView rosterListView, ComboBox yearComboBox, ComboBox semesterComboBox, ComboBox courseComboBox) throws SQLException{
    	ResultSet set;
    	ObservableList<String> values = FXCollections.observableArrayList();
    	set = getFacade().getSelect().getClassByID(userSettings.getCurrentClassID());
    	values = populateElement('y', "", "" );
    	yearComboBox.getItems().addAll(values);
    	yearComboBox.getSelectionModel().select(set.getObject("calander_year").toString());
    	semesterComboBox.getSelectionModel().select(set.getObject("semester").toString());
    	courseComboBox.getSelectionModel().select(0);    	
    }
    //This function is responsible for deleting a class.
    public void deleteClass() throws SQLException{
    	BasicClass selectedClass = new BasicClass();
    	selectedClass.setClassID(userSettings.getCurrentClassID());
    	getFacade().getDelete().deleteClass(selectedClass);
    }
    public void populateClasses(String year, String semester) throws SQLException{
    	ResultSet set = getFacade().getSelect().getClass(year, semester, userSettings.getCurrentUserID());
    	while(set.next()){
    		BasicClass newClass =  new BasicClass();
    		newClass.setClassID(set.getInt("class_id"));
    		newClass.setMaxScore(set.getInt("max_score"));
    		newClass.setName(set.getObject("class_name").toString());
    		newClass.setSemester(set.getObject("semester").toString());
    		newClass.setYear(set.getInt("calander_year"));
    		newClass.setUserID(set.getInt("user_id"));
    		classes.add(newClass);
    	}
    }
    //This function is responsible for populating the students within a class
    public ObservableList populateStudents(ListView rosterListView, String year, String semester, int selectedIndex) throws SQLException{
    	ObservableList<String> values = FXCollections.observableArrayList();
    	students.clear();
    	ResultSet set;
    	classes.clear();
    	populateClasses(year, semester);
    	userSettings.setCurrentClassID(classes.get(selectedIndex).getClassID());
    	userSettings.setCurrentMaxOutcome(classes.get(selectedIndex).getMaxScore());
    	set=getFacade().getSelect().getStudents(userSettings.getCurrentClassID());
    	//Have to convert result set to a list so we can add to dropdown.
    	while(set.next()){
    			Boolean check = false;
    			int tempSize = students.size();
    			int insertIndex = 0;
    			Student newStudent = new Student();
    			newStudent.setFirstName(set.getObject("first_name").toString());
    			newStudent.setLastName(set.getObject("last_name").toString());
    			newStudent.setUniversityID(set.getObject("student_id_code").toString());
    			for(int x =0; x<tempSize; x++){
    				if(students.get(x).getLastName().compareTo(newStudent.getLastName()) > 0){
    					insertIndex = x;
    					check = true;
    					break;
    				}
    			}
    			if(check){
    				students.add(insertIndex, newStudent);
					values.add(insertIndex, newStudent.getLastName()+ " " + newStudent.getFirstName());
					students.get(insertIndex).setStudentID(set.getInt("student_id"));
    			}
    			else if(!check){
    				students.add(newStudent);
    				values.add(newStudent.getLastName()+ " " + newStudent.getFirstName());
    				students.get(students.size()-1).setStudentID(set.getInt("student_id"));
    			}
    	}
    	return values;
    }
    
    //This function is responsible for adding a student to a class
    public void addStudent(String first, String last, String universityID) throws SQLException{
    	Student student = new Student();
        student.setFirstName(first);
        student.setLastName(last);
    	student.setUniversityID(universityID);
    	int studentId = getFacade().getInsert().insertStudentClass(student, userSettings.getCurrentClassID());
    }
    
    //This function is responsible for deleting a student. Goes through all of the students
    //and find the one that is selected to be deleted
    public void deleteStudent(int index) throws SQLException{
    	ResultSet set=getFacade().getSelect().getStudents(userSettings.getCurrentClassID());
    	Student selectedStudent = new Student();
    	while(set.next()){
    		//TODO: here is where I need to compare student ID's find the right student and remove from database.
    		if(set.getObject("student_id_code").toString().equals(students.get(index).getUniversityID())){
    			selectedStudent =  students.get(index);
    		}
    	}
    	students.remove(index);
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
    		return getFacade().getSelect().getYears(userSettings.getCurrentUserID());
    	}
    	else if(type=='s'){
    		return getFacade().getSelect().getSemesters(year, userSettings.getCurrentUserID());
    		
    	}
    	else if (type=='c'){ 
    		//TODO:Need to get the right user id
    		return getFacade().getSelect().getClass(year, semester, userSettings.getCurrentUserID());
    		
    	}
    	return null;
    }
}
