package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import com.database.DatabaseFacade;
import com.learnoba.UserSettings;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.ListView;
import javafx.scene.control.TreeView;

public class Assignment {
    private int assignmentID;
    private int classID;
    private String assignmentName;
    private DatabaseFacade facade;
    private UserSettings userSettings;
    private ObservableList<Assignment> assignments;
    private ObservableList<Task> tasks;
    public Assignment() throws SQLException{
    	facade = DatabaseFacade.getInstance();
    	userSettings = UserSettings.getInstance();
    	assignments = FXCollections.observableArrayList();
    	tasks = FXCollections.observableArrayList();
    	setClassID(userSettings.getCurrentClassID());
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
    public int getNewQuestionNum(){
    	return tasks.size() + 1;
    }
  
    public void addAssignment(String name) throws SQLException{
    	Assignment ass = new Assignment();
    	ass.setAssignmentName(name);
    	int id =facade.getInsert().insertAssignment(ass);
    	ass.setAssignmentID(id);
    	assignments.add(ass);
    }
    public void deleteAssignment(int selectedIndex) throws SQLException{
    	facade.getDelete().deleteAssignment(assignments.get(selectedIndex));
    	assignments.remove(selectedIndex);
    }
    //Adds a task to the database
    //TODO: Change the enum type, right now hardcoded as multiple choice
    public void addTask(int assIndex, String answer, String text, QuestionType type) throws SQLException{
    	Task task = new Task();
    	task.setAssignmentID(assignments.get(assIndex).getAssignmentID());
    	task.setQuestionAnswer(answer);
    	task.setQuestionText(text);
    	task.setType(type);
    	task.setQuestionNumber(tasks.size()+1);
    	int id = facade.getInsert().insertTask(task);
    	task.setTaskID(id);
    	tasks.add(task);
    }	
    public Task populateTask(int selectedIndex){
    	return tasks.get(selectedIndex);
    }
    //This function is responsible for updating the task
    public void updateTask(int selectedIndex, String answer, String text, QuestionType type) throws SQLException{
      	tasks.get(selectedIndex).setQuestionAnswer(answer);
    	tasks.get(selectedIndex).setQuestionText(text);
    	tasks.get(selectedIndex).setType(type);
    	facade.getUpdate().updateTask(tasks.get(selectedIndex));
    }
    public void deleteTask(int selectedIndex) throws SQLException{
    	facade.getDelete().deleteTask(tasks.get(selectedIndex));
    	tasks.remove(selectedIndex);
    }
    
    public void addSkill(int questionIndex, Skill skill) throws SQLException{
        //get all students in class
        ResultSet set = facade.getSelect().getStudents(userSettings.getCurrentClassID());
        ArrayList<Integer> studentID = new ArrayList<Integer> ();
        //get all student IDs
        while(set.next())
            studentID.add(set.getInt("student_id"));
        //for each student, add the skill to selected question
        for(int x=0; x<studentID.size(); x++){
            Outcome out = new Outcome(studentID.get(x), tasks.get(questionIndex).getTaskID(), skill.getPrefilledOutcomeValue(),
                    skill.getSkillID(), tasks.get(questionIndex).getQuestionNumber(), skill.getName());
            facade.getInsert().insertOutcomes(out); 
        }
    }
    public void deleteSkill(int questionIndex, Skill skill) throws SQLException{
        //get all students in class
        ResultSet set = facade.getSelect().getStudents(userSettings.getCurrentClassID());
        ArrayList<Integer> studentID = new ArrayList<Integer> ();
        //get all student IDs
        while(set.next())
            studentID.add(set.getInt("student_id"));
        //for each student, add the skill to selected question
        for(int x=0; x<studentID.size(); x++){
            Outcome out = new Outcome(studentID.get(x), tasks.get(questionIndex).getTaskID(), skill.getPrefilledOutcomeValue(),
                    skill.getSkillID(), tasks.get(questionIndex).getQuestionNumber(), skill.getName());
            facade.getDelete().deleteOutcomes(out);
        }
    }
    
    public void getSkillNames(int questionIndex, TreeView tree) throws SQLException{
        Skill skillModel = new Skill("root");
        skillModel.getAllSkillsForTask(tasks.get(questionIndex).getTaskID());
        skillModel.reloadTree(tree);
    }
    //This is going to be responsible for populating the appropriate elements.
    //TODO: Figure out the QuestionType
    public ObservableList populateElement(char type, int assignIndex, int questionIndex) throws SQLException{
    	ObservableList<String> values = FXCollections.observableArrayList();
    	ResultSet set=selectQuery(type, assignIndex, questionIndex);
    	if(type=='a')
    		assignments.clear();
    	else if(type=='q')
    		tasks.clear();
    	while(set.next()){
    		if(type == 'a'){
    			Assignment assign = new Assignment();
    			assign.setAssignmentID(set.getInt(1));
    			assign.setAssignmentName(set.getObject("assignment_name").toString());
    			assign.setClassID(userSettings.getCurrentUserID());
    			assignments.add(assign);
    			values.add(set.getObject("assignment_name").toString());
    		
    		}
    		else if(type=='q'){
    			Task task = new Task();
        		task.setAssignmentID(assignments.get(assignIndex).getAssignmentID());
        		task.setQuestionAnswer(set.getObject("question_answer").toString());
        		task.setQuestionText(set.getObject("question_text").toString());
        		if(set.getObject("question_type").toString().compareTo("0") == 0){
        			task.setType(QuestionType.MULTIPLE_CHOICE);
        		}
        		else if(set.getObject("question_type").toString().compareTo("1") == 0){
        			task.setType(QuestionType.SHORT_ESSAY);
        		}
        		else if(set.getObject("question_type").toString().compareTo("2") == 0){
        			task.setType(QuestionType.ESSAY);
        		}
        		else if(set.getObject("question_type").toString().compareTo("3") == 0){
        			task.setType(QuestionType.DIAGRAM);
        		}
        		else if(set.getObject("question_type").toString().compareTo("4") == 0){
        			task.setType(QuestionType.FILL_IN_THE_BLANK);
        		}
        		task.setQuestionNumber((int)set.getObject("question_number"));
        		task.setTaskID((int)set.getObject("task_id"));
        		tasks.add(task);
    			values.add(set.getObject("question_number").toString());
    		}
    		else
    			values.add(set.getObject("skill_name").toString());
    	}
    	return values;
    }
    //This is going to be responsible for running the appropriate query.
    public ResultSet selectQuery(char type, int assignIndex, int questionIndex) throws SQLException{
    	ResultSet set;
    	
    	if(type=='a')
    		set= facade.getSelect().getAssignmentByClass(userSettings.getCurrentClassID());
    	//TODO:Change these to the correct queries once matt has them completed.
    	else if(type =='q'){
    	
    		set= facade.getSelect().getQuestionsForAssignment(assignments.get(assignIndex).getAssignmentID());
    	}
    	else{
    		set= facade.getSelect().getTaskSpecificSkills(questionIndex);
    	}
    	return set;
    }
  
}
