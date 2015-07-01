package com.database.queries;

import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;

import com.database.AbstractQuery;
import com.learnoba.models.*;

public class InsertQuery extends AbstractQuery {

    public InsertQuery() throws SQLException {
		super();
	}
    
    /**
     * Insert task into task table
     * 
     * @param task
     * @return
     * @throws SQLException
     */
    public int insertTask(Task task) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO task_table(assignment_id, question_number, question_text, question_answer, question_type) VALUES(?,?,?,?,?);", Statement.RETURN_GENERATED_KEYS); 
    	insertStmt.setInt(1, task.getAssignmentID());
		insertStmt.setInt(2, task.getQuestionNumber());
		insertStmt.setString(3, task.getQuestionText());
		insertStmt.setString(4, task.getQuestionAnswer());
		insertStmt.setInt(5, task.getType().ordinal());
        int i = insertStmt.executeUpdate();
        if (i > 0)
            return insertStmt.getGeneratedKeys().getInt(1);
		return -1;
    }

    /**
     * Insert assignment into assignment table
     * 
     * @param assignment
     * @return
     * @throws SQLException
     */
    public int insertAssignment(Assignment assignment) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO assignment_table(class_id, assignment_name) VALUES(?,?);", Statement.RETURN_GENERATED_KEYS); 
        insertStmt.setInt(1, assignment.getClassID());
        insertStmt.setString(2, assignment.getAssignmentName());
        int i = insertStmt.executeUpdate();
        if (i > 0)
            return insertStmt.getGeneratedKeys().getInt(1);
		return -1;
    }
    
    /**
     * Insert outcome into outcome table
     * 
     * @param outcome
     * @return
     * @throws SQLException
     */
    public int insertOutcomes(Outcome outcome) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO outcome_table(task_id, student_id, skill_id, outcome_value) VALUES(?,?,?,?);", Statement.RETURN_GENERATED_KEYS); 
    	insertStmt.setInt(1, outcome.getTaskID());
		insertStmt.setInt(2, outcome.getStudentID());
		insertStmt.setInt(3, outcome.getSkillID());
		insertStmt.setFloat(4, outcome.getOutcomeValue());
        int i = insertStmt.executeUpdate();
        if (i > 0)
            return insertStmt.getGeneratedKeys().getInt(1);
		return -1;
    }

    /**
     * Insert class into class table
     * 
     * @param clas
     * @return
     * @throws SQLException
     */
    public int insertClass(BasicClass clas) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO class_table(semester, calander_year, class_name, max_score, user_id) VALUES(?,?,?,?,?);", Statement.RETURN_GENERATED_KEYS); 
    	insertStmt.setString(1, clas.getSemester());
		insertStmt.setInt(2, clas.getYear());
		insertStmt.setString(3, clas.getName());
		insertStmt.setInt(4, clas.getMaxScore());
		int temp = clas.getUserID();
		insertStmt.setInt(5, temp);
        int i = insertStmt.executeUpdate();
        if (i > 0)
            return insertStmt.getGeneratedKeys().getInt(1);
		return -1;

    }

    /**
     * New insert, that associates students to a class immediately after inserting the students into
     * the table
     * 
     * @param student
     * @param classID
     * @param executeQuery
     * @return
     * @throws SQLException
     */
    public int insertStudentClass(Student student, int classID) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO student_table(first_name, last_name, middle_name, email_address, student_id_code) VALUES(?,?,?,?,?);", Statement.RETURN_GENERATED_KEYS); 
    	insertStmt.setString(1, student.getFirstName());
		insertStmt.setString(2, student.getLastName());
		insertStmt.setString(3, student.getMiddleName());
		insertStmt.setString(4, student.getEmail());
		insertStmt.setString(5, student.getUniversityID());
		int i = insertStmt.executeUpdate();
		if (i>0){
			PreparedStatement insertAssociation = getConnection().prepareStatement("INSERT INTO student_class_association_table(class_id, student_id) VALUES(?,?);", Statement.RETURN_GENERATED_KEYS);
			insertAssociation.setInt(1, classID);
			insertAssociation.setInt(2, insertStmt.getGeneratedKeys().getInt(1));
			i = insertAssociation.executeUpdate();
			if (i>0){
				return i;
			}
		}		
		return -1;
    }

    /**
     * Insert user into user table
     * 
     * @param user
     * @param executeQuery
     * @return
     * @throws SQLException
     */
    public int insertUser(User user) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO users_table(user_name, user_password) VALUES(?,?);", Statement.RETURN_GENERATED_KEYS); 
		insertStmt.setString(1, user.getUserName());
		insertStmt.setString(2, user.getPassword());
        int i = insertStmt.executeUpdate();
        if (i > 0)
            return insertStmt.getGeneratedKeys().getInt(1);
		return -1;
    	
        }

    /**
     * Insert skill into skills table
     * 
     * @param skill
     * @param executeQuery
     * @return
     * @throws SQLException
     */
    public int insertSkill(Skill skill) throws SQLException {
    	PreparedStatement insertStmt = getConnection().prepareStatement("INSERT INTO skill_table(skill_name, prefilled_outcome_value, class_id, parent_id) VALUES(?,?,?,?);", Statement.RETURN_GENERATED_KEYS); 
		insertStmt.setString(1, skill.getName());
		insertStmt.setFloat(2, skill.getPrefilledOutcomeValue());
		insertStmt.setInt(3, skill.getClassID());
		insertStmt.setInt(4, skill.getParentID());
        int i = insertStmt.executeUpdate();
        if (i > 0)
            return insertStmt.getGeneratedKeys().getInt(1);
		return -1;

    }

    /**
     * Keep this as protected so our tests have access to it but it doesn't "leak" to other areas of
     * our code
     * 
     * @return
     */
    protected String getSQLQuery() {
        return getSqlQuery();
    }


}

