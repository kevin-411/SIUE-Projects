package com.database.queries;

import java.sql.SQLException;

import com.database.AbstractQuery;
import com.learnoba.models.*;

public class DeleteQuery extends AbstractQuery {

    public DeleteQuery() throws SQLException {
		super();
	}

    public boolean deleteTask(Task task) throws SQLException {
        appendSqlQuery("DELETE FROM task_table WHERE task_id = " + task.getTaskID() + ";");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean deleteAssignment(Assignment assignment) throws SQLException {
        appendSqlQuery("DELETE FROM assignment_table WHERE assignment_id = "
            + assignment.getAssignmentID() + ";");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean deleteOutcomes(Outcome outcome) throws SQLException {
        appendSqlQuery("DELETE FROM outcome_table WHERE task_id = " + outcome.getTaskID() + 
        		" AND student_id = " + outcome.getStudentID() + " AND skill_id = " + outcome.getSkillID() + ";");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean deleteClass(BasicClass clas) throws SQLException {
        appendSqlQuery("DELETE FROM class_table WHERE class_id = " + clas.getClassID() + " AND class_id <> 0;");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;

    }

    public boolean deleteStudentFromClass(Student student, int classID) throws SQLException {
        appendSqlQuery("DELETE FROM student_class_association_table WHERE student_id = " + student.getStudentID() 
        		+ " AND class_id = " + classID
            + ";");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;
    }
    
    public boolean deleteStudent(Student student) throws SQLException {
        appendSqlQuery("DELETE FROM student_table WHERE student_id = " + student.getStudentID()
            + ";");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean deleteUser(User user, boolean executeQuery) throws SQLException {
        appendSqlQuery("DELETE FROM users_table WHERE user_id = " + user.getUserID() + ";");
        int result = executeUpdates();
        if (result > 0) {
            return true;
        }
        return false;
    }

    public boolean deleteSkill(Skill skill) throws SQLException {
        if (skill == null)
    		return false;
        appendSqlQuery("DELETE FROM skill_table WHERE skill_id = " + skill.getSkillID()
            + " AND skill_id > 0;");
            int result = executeUpdates();
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
