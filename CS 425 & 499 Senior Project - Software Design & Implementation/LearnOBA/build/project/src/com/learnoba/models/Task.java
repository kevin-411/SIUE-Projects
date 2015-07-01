package com.learnoba.models;

import com.learnoba.AbstractModel;

public class Task extends AbstractModel {
    private int taskID;
    private int assignmentID;
    private QuestionType type;
    private int questionNumber;
    private String questionText;
    private String questionAnswer;

    /**
     * @return the taskId
     */
    public int getTaskID() {
        return taskID;
    }

    /**
     * @param taskId the taskId to set
     */
    public void setTaskID(int taskID) {
        this.taskID = taskID;
    }

    /**
     * @return the type
     */
    public QuestionType getType() {
        return type;
    }

    /**
     * @param type the type to set
     */
    public void setType(QuestionType type) {
        this.type = type;
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
     * @return the questionText
     */
    public String getQuestionText() {
        return questionText;
    }
    /**
     * @param questionText the questionText to set
     */
    public void setQuestionText(String questionText) {
        this.questionText = questionText;
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
     * @return the questionAnswer
     */
    public String getQuestionAnswer() {
        return questionAnswer;
    }

    /**
     * @param questionAnswer the questionAnswer to set
     */
    public void setQuestionAnswer(String questionAnswer) {
        this.questionAnswer = questionAnswer;
    }

}
