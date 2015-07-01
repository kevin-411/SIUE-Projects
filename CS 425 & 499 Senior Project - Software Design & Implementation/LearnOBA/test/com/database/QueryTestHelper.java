package com.database;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import org.mockito.Mockito;

import com.learnoba.models.*;

/**
 * Query Test Helper Class This class is used to make a generic dummy class for all the test classes
 * to use and avoid the recoding of dummy classes in test cases. This will also assist in keeping
 * test cases cleaner. This class uses a Google stubbing API called Mockito. It is useful when
 * utilizing Test Driven Development since it doesn't require the objects to actually be implemented
 * to test them. NOTE: The term "Class" used in the comments below are referring to a class in a
 * school and not a Java class.
 */

public class QueryTestHelper {
    /**
     * Singleton Class
     */
    private static QueryTestHelper instance = null;

    private QueryTestHelper() {

    }

    public static QueryTestHelper getInstance() {
        if (instance == null) {
            instance = new QueryTestHelper();
        }
        return instance;
    }
    
    
    /**
     * Create Users is a dummy mock class of Users
     * 
     * @return ArrayList<User>
     */
    public static List<User> createUsers() {
        List<User> users = new ArrayList<User>();
        int userID = 0;

        // users.add(makeMockUser(++userID, "bolsen", "123"));
        // users.add(makeMockUser(++userID, "mlieven", "123"));
        // users.add(makeMockUser(++userID, "zbenchl", "123"));
        users.add(makeMockUser(++userID, "lmaugha", "123"));

        return users;
    }

    /**
     * Makes each individual mock User
     * 
     * @param userID
     * @param Username
     * @param Password
     * @return
     */
    private static User makeMockUser(int userID, String username, String password) {

        User user = Mockito.mock(User.class);

        Mockito.when(user.getUserID()).thenReturn(userID);
        Mockito.when(user.getUserName()).thenReturn(username);
        Mockito.when(user.getPassword()).thenReturn(password);

        return user;
    }
    
    /**
     * Create Classes is a dummy class object that contains all class meta data and uses dummy mock
     * data below for it's other objects.
     * 
     * @return ArrayList<Class>
     */
    public static List<BasicClass> createClasses() {

        List<BasicClass> classes = new ArrayList<BasicClass>();
        List<User> users = createUsers();
        int classID = 0;

        for(User user: users){
        	classes.add(makeMockClass("Physics 111", ++classID, "Fall", 2013, 5, user.getUserID()));
        	classes.add(makeMockClass("Physics 111", ++classID, "Spring", 2014, 4, user.getUserID()));
        }

        return classes;

    }

    /**
     * Makes each individual mock Class
     * 
     * @param name
     * @param classID
     * @param semester
     * @param year
     * @param maxScore
     * @return
     */
    private static BasicClass makeMockClass(String name, int classID, String semester, int year,
                                     int maxScore, int userID) {

        BasicClass clas = Mockito.mock(BasicClass.class);

        Mockito.when(clas.getName()).thenReturn(name);
        Mockito.when(clas.getClassID()).thenReturn(classID);
        Mockito.when(clas.getSemester()).thenReturn(semester);
        Mockito.when(clas.getYear()).thenReturn(year);
        Mockito.when(clas.getMaxScore()).thenReturn(maxScore);
        Mockito.when(clas.getUserID()).thenReturn(userID);

        return clas;
    }

    /**
     * Create Assignments is a dummy mock class of Assignments
     * 
     * @return ArrayList<Assignment>
     */
    public static List<Assignment> createAssignments() {

        List<BasicClass> classes = createClasses();
        List<Assignment> assignments = new ArrayList<Assignment>();
        int assignemtnID = 0;

        for (BasicClass clas : classes) {
            assignments.add(makeMockAssignment("Quiz 1", ++assignemtnID, clas.getClassID()));
            assignments.add(makeMockAssignment("Exam 1", ++assignemtnID, clas.getClassID()));
        }

        return assignments;

    }

    /**
     * Makes each individual mock Assignment
     * 
     * @param name
     * @param assignmentID
     * @param classID
     * @return
     */
    private static Assignment makeMockAssignment(String name, int assignmentID, int classID) {

        Assignment assignment = Mockito.mock(Assignment.class);

        Mockito.when(assignment.getAssignmentName()).thenReturn(name);
        Mockito.when(assignment.getAssignmentID()).thenReturn(assignmentID);
        Mockito.when(assignment.getClassID()).thenReturn(classID);

        return assignment;
    }

    /**
     * Create Students is a dummy mock class of Students
     * 
     * @return ArrayList<Student>
     */

    public static List<Student> createStudents() {

        List<Student> students = new ArrayList<Student>();
        int studentID = 0;

        students.add(makeMockStudent("Brian", "Olsen", "Dale", "bolsen@siue.edu", ++studentID, "123"));
        students.add(makeMockStudent("Matt", "Lievens", "Bartholomew", "mlieven@siue.edu",
                ++studentID, "321"));
        students.add(makeMockStudent("Zach", "Benchley", "Gosling", "zbenchl@siue.edu", ++studentID,
                "213"));
        students.add(makeMockStudent("Logan", "Maughan", "Danger", "lmaugha@siue.edu", ++studentID,
                "312"));

        return students;
    }

    /**
     * Makes each individual mock Student
     * 
     * @param fName
     * @param lName
     * @param mName
     * @param email
     * @param studentID
     * @param universityID
     * @return
     */
    private static Student makeMockStudent(String fName, String lName, String mName, String email,
                                    int studentID, String universityID) {

        Student student = Mockito.mock(Student.class);

        Mockito.when(student.getFirstName()).thenReturn(fName);
        Mockito.when(student.getLastName()).thenReturn(lName);
        Mockito.when(student.getMiddleName()).thenReturn(mName);
        Mockito.when(student.getEmail()).thenReturn(email);
        Mockito.when(student.getStudentID()).thenReturn(studentID);
        Mockito.when(student.getUniversityID()).thenReturn(universityID);

        return student;
    }

    /**
     * Create Tasks is a dummy mock class of Tasks
     * 
     * @return ArrayList<Task>
     */
    public static List<Task> createTasks() {

        List<Assignment> assignments = createAssignments();
        List<Task> tasks = new ArrayList<Task>();
        int taskID = 0;

        for (Assignment assignment : assignments) {
            tasks.add(makeMockTask(++taskID, assignment.getAssignmentID(), QuestionType.DIAGRAM, 1,
                    "Graph the relation between temperature and pressure.",
                    "Pressure is directly porportional to temperature."));
            tasks.add(makeMockTask(++taskID, assignment.getAssignmentID(), QuestionType.ESSAY, 2,
                    "Explain the why the relations between temperature and pressure exists.",
                    "Temperature excites atoms and makes collisions occur more often raising pressure."));
        }


        return tasks;
    }


    /**
     * Makes each individual mock Task
     * 
     * @param taskID
     * @param assignmentID
     * @param type
     * @param questionNumber
     * @param questionText
     * @param questionAnswer
     * @return
     */
    private static Task makeMockTask(int taskID, int assignmentID, QuestionType type,
                                     int questionNumber,
                              String questionText, String questionAnswer) {

        Task task = Mockito.mock(Task.class);

        Mockito.when(task.getTaskID()).thenReturn(taskID);
        Mockito.when(task.getAssignmentID()).thenReturn(assignmentID);
        Mockito.when(task.getType()).thenReturn(type);
        Mockito.when(task.getQuestionNumber()).thenReturn(questionNumber);
        Mockito.when(task.getQuestionText()).thenReturn(questionText);
        Mockito.when(task.getQuestionAnswer()).thenReturn(questionAnswer);

        return task;
    }

    /**
     * Create Skills is a dummy mock class of Skills
     * 
     * @return ArrayList<Skill>
     */
    public static List<Skill> createSkills() {
        List<BasicClass> classes = createClasses();
        List<Skill> skills = new ArrayList<Skill>();
        int skillID = 0;

        for (BasicClass clas : classes) {
            skills.addAll(createSkillsPerClass(clas.getClassID(), skillID));
            skillID += 5;
        }

        return skills;
    }

    private static List<Skill> createSkillsPerClass(int classID, int skillID) {
        List<Skill> skills = new ArrayList<Skill>();
        List<Skill> childSkills = new ArrayList<Skill>();
        List<Skill> childSkills2 = new ArrayList<Skill>();

        int parentSkillID = skillID;

        childSkills.add(makeMockSkill("Temperature Concepts", ++skillID, parentSkillID,
                classID,
                null, 5));
        childSkills.add(makeMockSkill("Pressure Concepts", ++skillID, parentSkillID,
                classID,
                null, 5));
        skills.add(makeMockSkill("Gas Laws", parentSkillID, -1, classID, childSkills,
                5));
        parentSkillID = ++skillID;
        childSkills2.add(makeMockSkill("Laws Of Thermodynamics", ++skillID, parentSkillID,
                classID, null, 5));
        skills.add(makeMockSkill("Thermodynamics", parentSkillID, -1, classID,
                childSkills2, 5));
        return skills;
    }


    /**
     * Makes each individual mock Skill
     * 
     * @param name
     * @param skillID
     * @param parentID
     * @param classID
     * @param childSkills
     * @param prefilledValue
     * @return
     */
    private static Skill makeMockSkill(String name, int skillID, int parentID, int classID,
                                List<Skill> childSkills, int prefilledValue) {

        Skill skill = Mockito.mock(Skill.class);

        Mockito.when(skill.getName()).thenReturn(name);
        Mockito.when(skill.getParentID()).thenReturn(parentID);
        Mockito.when(skill.getSkillID()).thenReturn(skillID);
        Mockito.when(skill.getClassID()).thenReturn(classID);
        Mockito.when(skill.getSkills()).thenReturn(childSkills);
        Mockito.when(skill.getPrefilledOutcomeValue()).thenReturn(prefilledValue);

        return skill;
    }


    /**
     * Create Outcomes is a dummy mock class of Outcomes
     * 
     * @return ArrayList<Outcome>
     */
    public static List<Outcome> createOutcomes() {
        List<Outcome> outcomes = new ArrayList<Outcome>();
        List<Student> students = createStudents();
        List<Skill> skills = createSkills();
        List<Task> tasks = createTasks();
        int min = 0;
        int max = 5;
        Random r = new Random();


        for (Student student : students) {
            for (Skill skill : skills) {
                for (Task task : tasks) {
                    float value = r.nextInt(max - min + 1) + min;
                    outcomes.add(makeMockOutcome(value, skill.getSkillID(), student.getStudentID(),
                            task.getTaskID())
                            );
                }
            }
        }

        return outcomes;
    }

    /**
     * Makes each individual mock Outcome
     * 
     * @param value
     * @param skillID
     * @param studentID
     * @param taskID
     * @return
     */
    private static Outcome makeMockOutcome(float value, int skillID, int studentID, int taskID) {

        Outcome outcome = Mockito.mock(Outcome.class);

        Mockito.when(outcome.getOutcomeValue()).thenReturn(value);
        Mockito.when(outcome.getSkillID()).thenReturn(skillID);
        Mockito.when(outcome.getStudentID()).thenReturn(studentID);
        Mockito.when(outcome.getTaskID()).thenReturn(taskID);

        return outcome;
    }



}
