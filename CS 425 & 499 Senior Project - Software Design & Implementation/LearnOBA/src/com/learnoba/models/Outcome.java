package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;

import com.database.DatabaseFacade;
import com.learnoba.UserSettings;

public class Outcome {
    private int studentID;
    private int taskID;
    private float outcomeValue;
    private int skillID;
    private int questionNumber;
    private String skillName;
    private ObservableList<Outcome> outcomes;
    
    private ObservableList<Student> allStudents;
    private ObservableList<Assignment> allAssignments;
    
    private DatabaseFacade facade;
    private UserSettings settings;
    
    public Outcome() throws SQLException{
        settings.getInstance();
        facade.getInstance();
        allStudents = FXCollections.observableList(new ArrayList<Student>());
        allAssignments = FXCollections.observableList(new ArrayList<Assignment>());
        outcomes = FXCollections.observableList(new ArrayList<Outcome>());
        studentID = -1;
        taskID = -1;
        outcomeValue = -1;
        skillID = -1;
        questionNumber = -1;
        skillName = "";
        getStudents();
        getAssignments();
    }
    
    public Outcome(int studentID, int taskID, float outcomeValue, int skillID, int questionNumber, String skillName){
        this.studentID = studentID;
        this.taskID = taskID;
        this.outcomeValue = outcomeValue;
        this.skillID = skillID;
        this.questionNumber = questionNumber;
        this.skillName = skillName;
        outcomes = null;
        allStudents = null;
        allAssignments = null;
        facade = null;
        settings = null;
    }

    /**
     * @return the studentID
     */
    public int getStudentID() {
        return studentID;
    }
    /**
     * @param studentID the studentID to set
     */
    public void setStudentID(int studentID) {
        this.studentID = studentID;
    }
    
    /**
     * @return the taskID
     */
    public int getTaskID() {
        return taskID;
    }
    /**
     * @param taskID the taskID to set
     */
    public void setTaskID(int taskID) {
        this.taskID = taskID;
    }

    /**
     * @return the outcomeValue
     */
    public float getOutcomeValue() {
        return outcomeValue;
    }
    /**
     * @param outcomeValue the outcomeValue to set
     */
    public void setOutcomeValue(float outcomeValue) {
        this.outcomeValue = outcomeValue;
    }
    
    /**
     * @return the skillID
     */
    public int getSkillID() {
        return skillID;
    }
    /**
     * @param skillID the skillID to set
     */
    public void setSkillID(int skillID) {
        this.skillID = skillID;
    }

    /**
     * @return the outcomes
     */
    public ObservableList<Outcome> getOutcomes() {
        return outcomes;
    }

    /**
     * @param outcomes the outcomes to set
     */
    public void setOutcomes(ObservableList<Outcome> outcomes) {
        this.outcomes = outcomes;
    }
    
    /**
     * @return the questionNumber
     */
    public int getQuestionNumber() {
        return questionNumber;
    }
    /**
     * @param questionNumber the questionNumber to set
     */
    public void setQuestionNumber(int questionNumber) {
        this.questionNumber = questionNumber;
    }
    
    /**
     * @return the skillName
     */
    public String getSkillName() {
        return skillName;
    }
    /**
     * @param questionNumber the questionNumber to set
     */
    public void setSkillName(String skillName) {
        this.skillName = skillName;
    }

    /**
     * @return all students
     */
    public ObservableList<Student> getAllStudents(){
        return allStudents;
    }
    /**
     * @return all assignments
     */
    public ObservableList<Assignment> getAllAssignments(){
        return allAssignments;
    }

    /**
     * @return Student given first and last name.  If student is not found, return null.
     */
    public Student findStudent(String first, String last){
        for(Student student : allStudents){
            if(student.getFirstName().equals(first) && student.getLastName().equals(last))
                return student;
        }
        return null;
    }
    /**
     * @return Assignment index of selected assignment.  If index is too big or small, return null.
     */
    public Assignment findAssignment(int index){
        if(index > allAssignments.size() - 1 || index < 0)
            return null;
        return allAssignments.get(index);
    }
    
    /**
     * Gets all of the students from the current class from the database and put them in a list
     */
    private void getStudents() throws SQLException{
        ResultSet set = facade.getSelect().getStudents(settings.getCurrentClassID());
        //create a list of all students in the class
        while(set.next())
            allStudents.add(new Student(set.getInt("student_id"), set.getString("student_id_code"), set.getString("first_name"), set.getString("last_name"), set.getString("middle_name"), set.getString("email_address")));
    }
    
    /**
     * Gets all of the assignments and tasks associated with those assignments
     * in the current class from the database and put them in a list
     */
    private void getAssignments() throws SQLException{
        ResultSet set = facade.getSelect().getAssignmentByClass(settings.getCurrentClassID());
        Assignment tempAssignment;
        //Create a list of all assignments in the class.  
        //Not an initialization constructor, so have to enter values manually into a temporary variable.
        while(set.next()){
            tempAssignment = null;
            tempAssignment = new Assignment();
            tempAssignment.setAssignmentID(set.getInt("assignment_id"));
            tempAssignment.setAssignmentName(set.getString("assignment_name"));
            allAssignments.add(tempAssignment);
        }
    }
    
    /**
     * Gets all of the tasks for a specific assignment and student from the database and puts them in a list
     * @throws SQLException 
     */
    public void getOutcomes(int studentID, int assignmentID) throws SQLException{
        ResultSet set = facade.getSelect().getStudentOutcomesByAssignment(assignmentID, studentID);
        if(outcomes != null)
            outcomes.clear();
        //Loop through tasks of this assignment and pull out task ID and question number
        while(set.next())
            outcomes.add(new Outcome(studentID, set.getInt("task_id"), set.getFloat("outcome_value"), set.getInt("skill_id"), set.getInt("question_number"), set.getString("skill_name")));
    }
    /**
     * Update the database for the specific outcome
     * @throws SQLException 
     */
    public void updateOutcome(Outcome out) throws SQLException{
        facade.getUpdate().updateOutcomes(out);
    }
}
