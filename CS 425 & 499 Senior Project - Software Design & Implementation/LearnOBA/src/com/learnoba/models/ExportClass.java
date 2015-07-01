package com.learnoba.models;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.stage.Stage;

import com.database.DatabaseFacade;
import com.learnoba.AbstractModel;
import com.learnoba.UserSettings;
import com.learnoba.export.OutcomeOperation;
import com.learnoba.fileoutput.FileOutput;

public class ExportClass extends AbstractModel {
    private FileOutput fileOutput;
    private UserSettings userSettings;
    private DatabaseFacade facade;
    private List<Student> students;
    private List<Assignment> assignments;
    private ObservableList<String> values;

    public ExportClass() {
        fileOutput = FileOutput.getInstance();
        userSettings = UserSettings.getInstance();
        students = new ArrayList<Student>();
        assignments = new ArrayList<Assignment>();
        try {
            facade = DatabaseFacade.getInstance();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void generatePDFOutputFiles(boolean isAllStudents, Student student, Assignment assignment) {
        if (isAllStudents) {
            fileOutput.createOutputForAllStudents(assignment);
        } else {
            String file = fileOutput.showFilePickerSaver("Save Blackboard File", new Stage());
            if (file != null) {
                fileOutput.createStudentOutput(student, assignment, file);
            }
        }
    }

    public void generateBlackboardDelimitedFiles(boolean isCSVDilimiter, OutcomeOperation op) {
        String delimiter = isCSVDilimiter ? "," : "\t";
        fileOutput.generateCsvFile(delimiter, op);

    }

    public Student getStudent(int index) {
        return students.get(index);
    }

    public Assignment getAssignment(int index) {
        return assignments.get(index);
    }

    // This function is responsible for populating the students within a class
    public ObservableList populateStudents() throws SQLException {
        values = FXCollections.observableArrayList();
        students.clear();
        ResultSet set;

        set = facade.getSelect().getStudents(userSettings.getCurrentClassID());
        // Have to convert result set to a list so we can add to dropdown.
        while (set.next()) {
            Student newStudent = new Student();
            newStudent.setFirstName(set.getString("first_name"));
            newStudent.setLastName(set.getString("last_name"));
            newStudent.setUniversityID(set.getString("student_id_code"));
            newStudent.setStudentID(set.getInt("student_id"));
            students.add(newStudent);
            values.add(set.getString("first_name") + " " + set.getString("last_name"));
        }
        return values;
    }

    // This function is responsible for populating the students within a class
    public ObservableList populateAssignments() throws SQLException {
        values = FXCollections.observableArrayList();
        assignments.clear();
        ResultSet set;

        set = facade.getSelect().getAssignmentByClass(userSettings.getCurrentClassID());
        // Have to convert result set to a list so we can add to dropdown.
        while (set.next()) {
            Assignment assignment = new Assignment();
            assignment.setAssignmentID(set.getInt("assignment_id"));
            assignment.setAssignmentName(set.getString("assignment_name"));
            assignment.setClassID(userSettings.getCurrentClassID());
            assignments.add(assignment);
            values.add(set.getString("assignment_name"));
        }
        return values;
    }

}
