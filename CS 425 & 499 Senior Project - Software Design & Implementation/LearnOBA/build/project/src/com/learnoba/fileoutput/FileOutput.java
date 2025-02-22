package com.learnoba.fileoutput;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import javafx.stage.DirectoryChooser;
import javafx.stage.Stage;

import org.apache.pdfbox.exceptions.COSVisitorException;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.pdmodel.edit.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDFont;
import org.apache.pdfbox.pdmodel.font.PDType1Font;

import com.database.DatabaseFacade;
import com.learnoba.UserSettings;
import com.learnoba.models.Assignment;
import com.learnoba.models.Skill;
import com.learnoba.models.Student;

public class FileOutput {
    private static FileOutput instance = null;
    private PDDocument document;
    private PDRectangle mediabox;
    private DatabaseFacade facade;
    private UserSettings userSettings;

    /**
     * Size Constants
     */
    final private float HEADER_SIZE = 32;
    final private float FONT_SIZE = 12;
    final private float LEADING = 1.5f * FONT_SIZE;
    final private float MARGIN = 72;
    private float CELL_MARGIN = 2.5f;
    final private int MAX_SKILL_NAME_STRING_LENGTH = 25;
    final private float MAX_SKILL_NAME_WIDTH;
    final private float TASKS_PER_PAGE = 10;
    /**
     * Font Constants
     */
    final private PDFont FONT = PDType1Font.COURIER;
    final private PDFont BOLD_FONT = PDType1Font.COURIER_BOLD;
    /**
     * Text Constants
     */
    final private String HEADER = "Output";
    final private String SKILL_NAME_HEADER = "Skill Name";

    private float startX;
    private float startY;
    private float skillHeaderSize = 0f;
    private float width;// defined from page

    private FileOutput() throws IOException, SQLException {
        // Create a document and add a page to it
        document = new PDDocument();
        facade = DatabaseFacade.getInstance();
        userSettings = UserSettings.getInstance();
        MAX_SKILL_NAME_WIDTH = getStringWidth("1234567890123456789012345",
                FONT_SIZE);
    }

    public static FileOutput getInstance() throws IOException, SQLException {
        if (instance == null) {
            instance = new FileOutput();
        }
        return instance;
    }

    public String showFilePickerSaver(final String title, Stage stage) {
        DirectoryChooser chooser = new DirectoryChooser();
        chooser.setTitle(title);
        File defaultDirectory = new File(userSettings.getWorkingDirectory());
        chooser.setInitialDirectory(defaultDirectory);
        File selectedDirectory = chooser.showDialog(stage);

        return selectedDirectory.getAbsolutePath().toString().replace('\\', '/');
    }

    public void generateCsvFile() throws SQLException
    {
        List<List<String>> content = new ArrayList<List<String>>();

        content.add(new ArrayList<String>());
        content.get(0).add("Last Name");
        content.get(0).add("First Name");
        ResultSet rs = facade.getSelect().getSkillsByClass(userSettings.getCurrentClassID());
        ResultSetMetaData rsmd = rs.getMetaData();
        List<Integer> skillids = new ArrayList<Integer>();

        while (rs.next()) {
            content.get(0).add(rs.getString("skill_name"));
            int index = content.get(0).size() - 1;
            skillids.add(rs.getInt("skill_id"));
        }

        rs = facade.getSelect().getStudents(userSettings.getCurrentClassID());
        rsmd = rs.getMetaData();
        List<Integer> studentids = new ArrayList<Integer>();

        while (rs.next()) {
            content.add(new ArrayList<String>());
            content.get(content.size() - 1).add(rs.getString("last_name"));
            content.get(content.size() - 1).add(rs.getString("first_name"));
            int index = content.get(0).size() - 1;
            studentids.add(rs.getInt("student_id"));
            for (int i = 0; i < skillids.size(); i++) {
                content.get(content.size() - 1).add("N/A");
            }
        }

        rs = facade.getSelect().getStudentAvgByClass(userSettings.getCurrentClassID());

        while (rs.next()) {
            int studentindex = studentids.indexOf(rs.getInt("student_id")) + 1;
            int skillindex = skillids.indexOf(rs.getInt("skill_id")) + 2;
            String value = Double.toString(rs.getDouble("average"));
            
            content.get(studentindex).set(skillindex, value);
        }

        try
        {
            String filename = "/test.csv";
            FileWriter writer =
                    new FileWriter(showFilePickerSaver("Save Blackboard File", new Stage())
                        + filename);

            for (List<String> rows : content) {
                for (String item : rows) {
                    writer.append(item);
                    writer.append(',');
                }
                writer.append('\n');
            }

            writer.flush();
            writer.close();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    public void createOutputForAllStudents(Assignment assignment) {

    }

    /**
     * @param student
     * @param assignment
     * @throws IOException
     * @throws COSVisitorException
     * @throws SQLException
     */
    public void createStudentOutput(Student student, Assignment assignment)
                                                                                        throws IOException,
                                                                           COSVisitorException,
                                                                           SQLException {
        List<List<String>> content = new ArrayList<List<String>>();
        List<Skill> skills = new ArrayList<Skill>();
        Set<Integer> skillIDSet = new HashSet<Integer>();

        content.add(new ArrayList<String>());
        content.get(0).add(SKILL_NAME_HEADER);
        
        

        ResultSet rs = facade.getSelect().getQuestionsForAssignment(assignment.getAssignmentID());
        
        int maxQuestionNumber = 0;
        while(rs.next()){
            content.get(0).add("Q" + Integer.toString(rs.getInt("question_number")));
            if (rs.getInt("question_number") > maxQuestionNumber) {
                maxQuestionNumber = rs.getInt("question_number");
            }
        }
                
                
                
            rs =    facade.getSelect().getStudentOutcomesByAssignment(assignment.getAssignmentID(),
                        student.getStudentID());
        int count = 1;
        content.add(new ArrayList<String>());
        while (rs.next()) {

            int rowIndex = content.size() - 1;
            int questionNumber = rs.getInt("question_number");
            while (count != questionNumber) {
                content.get(rowIndex).add("N/A");
                count++;
            }
            content.get(rowIndex).add(Double.toString(rs.getDouble("outcome_value")));
            count++;
            if (count >= maxQuestionNumber) {
                content.get(rowIndex).add(0, rs.getString("skill_name"));
                content.add(new ArrayList<String>());
                count = 1;
            }
        }
        


        skillHeaderSize = getStringWidth(SKILL_NAME_HEADER, FONT_SIZE);
        int row = 0;
        for (Skill skill : skills) {
            content.add(new ArrayList<String>());
            content.get(content.size() - 1).add(skill.getName());
            row++;
            float skillNameWidth = getStringWidth(skill.getName(), FONT_SIZE);
            if (skillNameWidth >= MAX_SKILL_NAME_WIDTH) {
                skillHeaderSize = MAX_SKILL_NAME_WIDTH;
            }
            else if (skillNameWidth > skillHeaderSize) {
                skillHeaderSize = skillNameWidth;
            }
            // for (Task task : tasks) {
            // content.get(row).add(
            // Integer.toString(facade.getSelect().getOutcomeValue(student.getStudentID(),
            // task.getTaskID(),
            // skill.getSkillID())));
            // // content.get(row).add("5");
            // }
        }

        // /**
        // * Test stuff
        // */
        // int r = 7;
        // int c = 25;
        // String testSkillNames = "Skill Name";
        // skillHeaderSize = getStringWidth(testSkillNames, FONT_SIZE);
        // content = new ArrayList<List<String>>();
        // for (int i = 0; i <= r; i++) {
        // content.add(new ArrayList<String>());
        // content.get(i).add(testSkillNames);
        // if (i % 2 == 0) {
        // testSkillNames = "12345";
        // } else {
        // testSkillNames = "12345";
        // }
        //
        // for (int j = 0; j <= c; j++) {
        // if (i == 0 && j > 0) {
        // content.get(0).add("Q" + Integer.toString(j));
        // }
        // else if (i > 0 && j > 0) {
        // content.get(i).add("300");
        // }
        // }
        // }
        // skillHeaderSize =
        // (skillHeaderSize > MAX_SKILL_NAME_WIDTH) ? MAX_SKILL_NAME_WIDTH
        // : skillHeaderSize;
        // /**
        // * End Test Stuff 1
        // */

        int numPages = (int) Math.ceil(content.get(0).size() / TASKS_PER_PAGE);
        int numTasksOnLastPage = (int) ((content.get(0).size() % TASKS_PER_PAGE) - 1);
        numTasksOnLastPage = (int) (numTasksOnLastPage == 0 ? TASKS_PER_PAGE : numTasksOnLastPage);

        for (int i = 0; i < numPages; i++) {

            PDPage page;
            PDPageContentStream contentStream;
            page = new PDPage();
            document.addPage(page);
            mediabox = page.findMediaBox();

            width = mediabox.getWidth() - 2 * MARGIN;
            startX = mediabox.getLowerLeftX() + MARGIN;
            startY = mediabox.getUpperRightY() - MARGIN;

            // Start a new content stream which will "hold" the to be created content
            contentStream = new PDPageContentStream(document, page);

            writeHeader(student, assignment, contentStream);

            List<List<String>> subContent = new ArrayList<List<String>>();
            int from = (int) (i * TASKS_PER_PAGE + (1 * (i + 1)));
            int to = (int) (from + (i == numPages - 1 ? numTasksOnLastPage : TASKS_PER_PAGE));

            for (List<String> rowContent : content) {
                subContent.add(rowContent.subList(from, to));
                subContent.get(subContent.size() - 1).add(0, rowContent.get(0));
            }

            drawTable(650, subContent, contentStream);

            // Make sure that the content stream is closed:
            contentStream.close();
        }

        // Save the results and ensure that the document is properly closed:
        document.save(assignment.getAssignmentName() + "-" + student.getLastName()
            + student.getFirstName() + ".pdf");
    }

    private void writeHeader(Student student, Assignment assignment,
                             PDPageContentStream contentStream) throws IOException {
        contentStream.beginText();
        contentStream.setFont(BOLD_FONT, HEADER_SIZE);
        contentStream.moveTextPositionByAmount(
                getCenterXPosFromWidth(getStringWidth(HEADER, HEADER_SIZE)), 700);
        contentStream.drawString(HEADER);
        contentStream.endText();
        startY -= HEADER_SIZE + 5;

        contentStream.beginText();
        contentStream.setFont(FONT, FONT_SIZE);
        contentStream.moveTextPositionByAmount(startX, startY);
        contentStream.drawString("Name: " + student.getFirstName() + " " + student.getLastName());
        contentStream.moveTextPositionByAmount(0, -LEADING);
        contentStream.drawString("Assignment: " + assignment.getAssignmentName());
        contentStream.endText();
    }

    /**
     * Helper Methods
     */
    
    private float getStringWidth(String str, float fontSize) throws IOException {
        float stringWidth = fontSize * FONT.getStringWidth(str) / 1000;

        return stringWidth;
    }

    private float getCenterXPosFromWidth(float stringWidth) {
        return (mediabox.getWidth() / 2) - (stringWidth / 2);
    }

    public void drawTable(float y, List<List<String>> content, PDPageContentStream contentStream)
                                                                                                 throws IOException {

        final int rows = content.size();
        final int cols = content.get(0).size();
        
        int numRowHeight = rows;

        final float rowHeight = LEADING;
        final float tableWidth = width;
        final float skillColWidth = skillHeaderSize + 2 * CELL_MARGIN;
        final float colWidth = (tableWidth - skillColWidth) / ((float) cols - 1);

        // add the text
        contentStream.setFont(FONT, FONT_SIZE);

        float textx = MARGIN + CELL_MARGIN;
        float texty = y - 15;
        boolean doubleLineRow = false;
        float tempTextY;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {

                String text = content.get(i).get(j);

                if (text.length() > MAX_SKILL_NAME_STRING_LENGTH && j == 0) {
                    numRowHeight++;
                    String[] strs = new String[2];
                    if (text.contains("\n")) {
                        strs = text.split("\n",2);
                    } else {
                        strs[0] = text.substring(0, MAX_SKILL_NAME_STRING_LENGTH);
                        strs[1] = text.substring(MAX_SKILL_NAME_STRING_LENGTH, text.length() - 1);
                    }
                    doubleLineRow = true;
                    tempTextY = texty;
                    for (int k=0; k <= strs.length - 1;k++){
                        contentStream.beginText();
                        contentStream.moveTextPositionByAmount(textx, tempTextY);
                        contentStream.drawString(strs[k]);
                        contentStream.endText();
                        tempTextY -= rowHeight;
                    }
                }else{
                    // set texty to half the length to center outcome value if double line.
                    tempTextY = doubleLineRow ? texty - rowHeight / 2 : texty;
                    contentStream.beginText();
                    contentStream.moveTextPositionByAmount(textx, tempTextY);
                    contentStream.drawString(text);
                    contentStream.endText();
                }
                // set textx to move the length of the skill width to write
                // the column directly after the skill names.
                textx += (j == 0 ? skillColWidth + CELL_MARGIN : colWidth);
            }

            texty -= doubleLineRow ? 2 * rowHeight : rowHeight;
            doubleLineRow = false;
            textx = MARGIN + CELL_MARGIN;
        }

        // draw the rows
        float nexty = y;
        for (int i = 0; i <= rows; i++) {
            contentStream.drawLine(MARGIN, nexty, MARGIN + tableWidth, nexty);

            doubleLineRow =
                    i == rows ? false
                             : content.get(i).get(0).length() > MAX_SKILL_NAME_STRING_LENGTH;

            nexty -= doubleLineRow ? 2 * rowHeight : rowHeight;
        }

        final float tableHeight = rowHeight * numRowHeight;

        // draw the columns
        float nextx = MARGIN;

        contentStream.drawLine(nextx, y, nextx, y - tableHeight);
        nextx += skillColWidth;

        for (int i = 1; i <= cols; i++) {
            contentStream.drawLine(nextx, y, nextx, y - tableHeight);
            nextx += colWidth;
        }
    }

    public void disposeDocument() throws IOException, COSVisitorException {
        document.close();
    }

}
