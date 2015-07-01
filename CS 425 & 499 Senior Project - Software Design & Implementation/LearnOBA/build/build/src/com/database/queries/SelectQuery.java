package com.database.queries;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.database.AbstractQuery;

public class SelectQuery extends AbstractQuery  {

	
	public SelectQuery() throws SQLException {
		super();
	}

    /**
     * SELECTS against class_table
     * 
     * @return
     * @throws SQLException
     */
    public ResultSet getYears() throws SQLException {
    	appendSqlQuery("SELECT DISTINCT calander_year FROM class_table WHERE calander_year > 2012");
        ResultSet rs = executeSelectQuery();
        return rs;
    }

    public ResultSet getSemesters(String selectedYear) throws SQLException {
    	appendSqlQuery("SELECT DISTINCT semester FROM class_table WHERE calander_year = " + selectedYear);
        ResultSet rs = executeSelectQuery();
        return rs;
    }

    public ResultSet getAllClass() throws SQLException {
    	appendSqlQuery("SELECT * FROM class_table");
            ResultSet rs = executeSelectQuery();
            return rs;

    }
    
    public ResultSet getClass(String selectedYear, String selectedSemester, int userID) throws SQLException {
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT * FROM class_table WHERE calander_year = ?"
        		+ "AND semester = ? AND user_id = ?;");
    	selectStmt.setString(1, selectedYear);
    	selectStmt.setString(2, selectedSemester);
    	selectStmt.setInt(3, userID);
    	
    	ResultSet rs = selectStmt.executeQuery();
        return rs;
    }
    
    /**
     * Returns all of the skills for a certain class
     * 
     * @param class_id
     * @return
     * @throws SQLException
     */
    public ResultSet getSkillsByClass(int class_id) throws SQLException {
    	appendSqlQuery("SELECT * FROM skill_table WHERE class_id = " + class_id +";");
    	ResultSet rs = executeSelectQuery();
        return rs;

	}


    /**
     * SELECTS against student_table
     * 
     * @param classID
     * @return
     * @throws SQLException
     */
    public ResultSet getStudents(int classID) throws SQLException {
    	appendSqlQuery("SELECT s.* FROM student_table s INNER JOIN student_class_association_table sca ON s.student_id = sca.student_id WHERE sca.class_id = " + classID);
        ResultSet rs = executeSelectQuery();
        return rs;
    }

    /**
     * SELECTS Against Assignment
     * 
     * @return
     * @throws SQLException
     */
    public ResultSet getAllAssignments() throws SQLException {
    	appendSqlQuery("SELECT * FROM assignment_table;");
         ResultSet rs = executeSelectQuery();
         return rs;  
         }
    
    public ResultSet getAssignmentByClass(int classId) throws SQLException {
    	appendSqlQuery("SELECT * FROM assignment_table WHERE class_id = " + classId + ";");
         ResultSet rs = executeSelectQuery();
         return rs;   
         }   
    
    /**
     * SELECTS Against Task
     * 
     * @param classID
     * @return
     * @throws SQLException 
     */
    public ResultSet getQuestionsForAssignment(int assignmentID) throws SQLException {
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT * FROM task_table WHERE assignment_id = ?;");
    	selectStmt.setInt(1, assignmentID);    	
    	ResultSet rs = selectStmt.executeQuery();
        return rs;

    }

    /**
     * SELECTS Against Skills
     * 
     * @param taskID
     * @return
     */
    public ResultSet getTaskSpecificSkills(int taskID) throws SQLException {
		PreparedStatement selectStmt = getConnection().prepareStatement("SELECT DISTINCT skill_table.* FROM skill_table INNER JOIN outcome_table WHERE task_id = ?");
    	selectStmt.setInt(1, taskID);    	
    	ResultSet rs = selectStmt.executeQuery();
        return rs;
    }
    
    /**
     * SELECTS Against User
     * 
     * @param userName
     * @return
     * @throws SQLException
     */
    public boolean validateUser(String userName) throws SQLException {
    	appendSqlQuery("SELECT COUNT(user_id) FROM users_table WHERE user_name = '" + userName + "';");
        ResultSet rs = executeSelectQuery();
        if (rs.getInt(1) == 0)
            return true;
        return false;
    }
    
    /**
     * SELECTS Against User
     * 
     * @param userName
     * @return
     * @throws SQLException
     */
    public boolean validatePassword(String userName, String password) throws SQLException {
    	appendSqlQuery("SELECT COUNT(user_id) FROM users_table WHERE user_name = '" + userName + "' AND user_password = '" + password + "';");
            ResultSet rs = executeSelectQuery();
            if (rs.getInt(1) > 0)
                return true;
            return false;
    }
    
    public int getUserID(String userName) throws SQLException{
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT user_id FROM users_table WHERE user_name = ?;");
    	selectStmt.setString(1, userName);
    	
    	ResultSet rs = selectStmt.executeQuery();
        return rs.getInt(1);
    }
    
    /**
     * SELECT MAX_ID's For Inserts
     * 
     * @return
     * @throws SQLException
     */
    
    public int maxSkill() throws SQLException {
    	appendSqlQuery("SELECT skill_id FROM skill_table;");
    	ResultSet rs = executeSelectQuery();
    	return rs.getInt(1);
    }
    
    /**
     * SELECT student results by class
     * 
     * @return Result Set that includes the average, skill_id, student_id, student.first_name, student.middle_name, student.last_name, skill_name
     * 			ORDER BY student_name, parent_id, skill_name 
     * @throws SQLException
     */
    public ResultSet getStudentAvgByClass(int classID) throws SQLException{
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT AVG(o.outcome_value) AS 'average', sk.skill_id AS 'skill_id', s.student_id AS 'student_id', s.first_name AS 'first_name', s.middle_name AS 'middle_name', s.last_name AS 'last_name', sk.skill_name AS 'skill_name'" +
    			"FROM skill_table sk, (SELECT  sca.student_id, s.first_name, s.middle_name, s.last_name FROM student_class_association_table sca " +
    			"INNER JOIN student_table s ON s.student_id = sca.student_id WHERE sca.class_id = ?) s " +
    			"LEFT OUTER JOIN outcome_table o ON o.student_id = s.student_id AND sk.skill_id = o.skill_id " +
    			"WHERE sk.class_id = ? GROUP BY sk.skill_id, s.student_id, s.first_name, s.middle_name, s.last_name, sk.skill_name, sk.parent_id " +
    			"ORDER BY s.last_name, s.first_name, sk.parent_id, sk.skill_name;");
    	selectStmt.setInt(1, classID);
    	selectStmt.setInt(2, classID);
    	
    	ResultSet rs = selectStmt.executeQuery();
        return rs;
    }
    
    /**
     * SELECT student results by class
     * 
     * @return Result Set that includes the sum, skill_id, student_id, student.first_name, student.middle_name, student.last_name, skill_name
     * 			ORDER BY student_name, parent_id, skill_name 
     * @throws SQLException
     */
    public ResultSet getStudentTop3AvgByClass(int classID) throws SQLException{
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT (SELECT AVG(outcome_value) FROM " + 
    			"(SELECT (o.outcome_value) FROM outcome_table o WHERE o.student_id = s.student_id AND o.skill_id = sk.skill_id ORDER BY o.outcome_value DESC LIMIT 3 ) ) AS 'average', " +
    			"sk.skill_id AS 'skill_id', s.student_id AS 'student_id', s.first_name AS 'first_name', s.middle_name AS 'middle_name', s.last_name AS 'last_name', sk.skill_name AS 'skill_name' FROM skill_table sk, " +
    			"(SELECT sca.student_id, s.first_name, s.middle_name, s.last_name FROM student_class_association_table sca "+
    			"INNER JOIN student_table s ON s.student_id = sca.student_id WHERE sca.class_id = ? ) s WHERE sk.class_id = ? " +
    			"GROUP BY sk.skill_id, s.student_id, s.first_name, s.middle_name, s.last_name, sk.skill_name, sk.parent_id " +
    			"ORDER BY s.last_name, s.first_name, sk.parent_id, sk.skill_name;");
    	
    	selectStmt.setInt(1, classID);
    	selectStmt.setInt(2, classID);
    	ResultSet rs = selectStmt.executeQuery();
        return rs;
    }
    
    /**
     * SELECT student results by class
     * 
     * @return Result Set that includes the sum, skill_id, student_id, student.first_name, student.middle_name, student.last_name, skill_name
     * 			ORDER BY student_name, parent_id, skill_name 
     * @throws SQLException
     */
    public ResultSet getStudentSumByClass(int classID) throws SQLException{
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT SUM(o.outcome_value) AS 'sum', sk.skill_id AS 'skill_id', s.student_id AS 'student_id', s.first_name AS 'first_name', s.middle_name AS 'middle_name', s.last_name AS 'last_name', sk.skill_name AS 'skill_name'" +
    			"FROM skill_table sk, (SELECT  sca.student_id, s.first_name, s.middle_name, s.last_name FROM student_class_association_table sca " +
    			"INNER JOIN student_table s ON s.student_id = sca.student_id WHERE sca.class_id = ?) s " +
    			"LEFT OUTER JOIN outcome_table o ON o.student_id = s.student_id AND sk.skill_id = o.skill_id " +
    			"WHERE sk.class_id = ? GROUP BY sk.skill_id, s.student_id, s.first_name, s.middle_name, s.last_name, sk.skill_name, sk.parent_id " +
    			"ORDER BY s.last_name, s.first_name, sk.parent_id, sk.skill_name;");
    	
    	selectStmt.setInt(1, classID);
    	selectStmt.setInt(2, classID);
    	ResultSet rs = selectStmt.executeQuery();
        return rs;
    }    
    
    /**
     * SELECT student results by assignment
     * 
     * @return Result Set that includes the outcome_value, question_number, skill_name
     * 			ORDER BY t.question_number, s.skill_name 
     * @throws SQLException
     */
    public ResultSet getStudentOutcomesByAssignment(int assignmentID, int studentID) throws SQLException{
    	PreparedStatement selectStmt = getConnection().prepareStatement("SELECT o.outcome_value AS 'outcome_value', t.question_number AS 'question_number', s.skill_name AS 'skill_name'" +
			"FROM task_table t " +
			"LEFT OUTER JOIN outcome_table o ON o.task_id = t.task_id " +
			"LEFT OUTER JOIN skill_table s ON s.skill_id = o.skill_id " +
			"WHERE t.assignment_id = ? " +
			"AND o.student_id = ? " +
                                    "ORDER BY s.parent_id, s.skill_name, t.question_number;");
    	
    	selectStmt.setInt(1, assignmentID);
    	selectStmt.setInt(2, studentID);
    	ResultSet rs = selectStmt.executeQuery();
        return rs;
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
