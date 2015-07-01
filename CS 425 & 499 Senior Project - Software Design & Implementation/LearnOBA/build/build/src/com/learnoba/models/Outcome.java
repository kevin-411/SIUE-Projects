package com.learnoba.models;

public class Outcome {
    private float outcomeValue;
    private int studentID;
    private int taskID;
    private int skillID;

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



}
