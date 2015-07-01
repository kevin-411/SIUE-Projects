package com.learnoba.models;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

public class AssignmentTest {
    private Assignment ass;
    private List<Task> tasks;
    private int assignmentID;
    private String assignmentName;

    @Before
    public void setUp() throws Exception {
        ass = new Assignment();
        tasks = new ArrayList<Task>();
        assignmentID = 5;
        assignmentName = "name";
    }

    @Test
    public void testGetSetAssignmentID() {
        ass.setAssignmentID(assignmentID);
        assertEquals(assignmentID, ass.getAssignmentID());
    }

    @Test
    public void testGetSetAssignmentName() {
        ass.setAssignmentName(assignmentName);
        assertEquals(assignmentName, ass.getAssignmentName());
    }

}
