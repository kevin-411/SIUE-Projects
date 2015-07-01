package com.database.queries;

import java.sql.PreparedStatement;
import java.sql.SQLException;

import com.database.AbstractQuery;
import com.learnoba.models.*;

public class UpdateQuery extends AbstractQuery {

    public UpdateQuery() throws SQLException {
		super();
	}
		
    public boolean updateTask(Task task) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE task_table SET assignment_id = ?, question_number = ?,"
        		+ "question_text = ?, question_answer = ?, question_type = ? WHERE task_id = ?;");
    	updateStmt.setInt(1, task.getAssignmentID());
    	updateStmt.setInt(2, task.getQuestionNumber());
    	updateStmt.setString(3, task.getQuestionText());
    	updateStmt.setString(4, task.getQuestionAnswer());
    	updateStmt.setInt(5, task.getType().ordinal());
    	updateStmt.setInt(6, task.getTaskID());
  
        int result = updateStmt.executeUpdate();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean updateAssignment(Assignment assignment) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE assignment_table SET class_id = ?, assignment_name = ?"
        		+ " WHERE assignment_id = ?;");
    	updateStmt.setInt(1, assignment.getClassID());
    	updateStmt.setString(2, assignment.getAssignmentName());
    	updateStmt.setInt(3, assignment.getAssignmentID());    	
    	
       	int result = updateStmt.executeUpdate();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean updateOutcomes(Outcome outcome) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE outcome_table SET outcome_value = ?"
        		+ "WHERE task_id = ? AND student_id = ? AND skill_id = ?;");
    	updateStmt.setFloat(1, outcome.getOutcomeValue());
    	updateStmt.setInt(2, outcome.getTaskID());
    	updateStmt.setInt(3, outcome.getStudentID());
    	updateStmt.setInt(4, outcome.getSkillID());

    	int result = updateStmt.executeUpdate();
    	if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean updateClass(BasicClass clas) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE class_table SET semester = ?, calander_year = ?,"
        		+ "class_name = ?, max_score = ?, last_used_timestamp = CURRENT_TIMESTAMP WHERE class_id = ?;");
    	updateStmt.setString(1, clas.getSemester());
    	updateStmt.setInt(2, clas.getYear());
    	updateStmt.setString(3, clas.getName());
    	updateStmt.setInt(4, clas.getMaxScore());
    	updateStmt.setInt(5, clas.getClassID());
  
        int result = updateStmt.executeUpdate();
        if (result > 0) {
            return true;
        }
        return false;
    }
    
    public boolean updateClassTimeStamp(int classId) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE class_table SET last_used_timestamp "
    			+ "= CURRENT_TIMESTAMP WHERE class_id = ?;");
       	updateStmt.setInt(1, classId);
        int result = updateStmt.executeUpdate();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean updateStudent(Student student) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE student_table SET first_name = ?, last_name = ?,"
        		+ "middle_name = ?, email_address = ?, student_id_code = ? WHERE student_id = ?;");
    	updateStmt.setString(1, student.getFirstName());
    	updateStmt.setString(2, student.getLastName());
    	updateStmt.setString(3, student.getMiddleName());
    	updateStmt.setString(4, student.getEmail());
    	updateStmt.setString(5, student.getUniversityID());
    	updateStmt.setInt(6, student.getStudentID());
  
        int result = updateStmt.executeUpdate();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean updateUser(User user) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE users_table SET user_name = ?, user_password = ?"
        		+ " WHERE user_id = ?;");
    	int result = 0;
    	try{
	    	updateStmt.setString(1, user.getUserName());
	    	updateStmt.setString(2, getSaltedHash(user.getPassword()));
	    	updateStmt.setInt(3, user.getUserID());    
	    	
	    	result = updateStmt.executeUpdate();
	    } catch (Exception e) {
			e.printStackTrace();
		}	
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean updateSkill(Skill skill) throws SQLException {
    	PreparedStatement updateStmt = getConnection().prepareStatement("UPDATE skill_table SET skill_name = ?, prefilled_outcome_value = ?,"
        		+ "class_id = ?, parent_id = ? WHERE skill_id = ?;");
    	updateStmt.setString(1, skill.getName());
    	updateStmt.setInt(2, skill.getPrefilledOutcomeValue());
    	updateStmt.setInt(3, skill.getClassID());
    	updateStmt.setInt(4, skill.getParentID());
    	updateStmt.setInt(5, skill.getSkillID());
  
        int result = updateStmt.executeUpdate();

        if (result > 0) {
            return true;
        }
        return false;
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
