package com.learnoba.fileoutput;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javafx.stage.DirectoryChooser;
import javafx.stage.Stage;

import org.apache.pdfbox.exceptions.COSVisitorException;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.pdmodel.edit.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDFont;
import org.apache.pdfbox.pdmodel.font.PDType1Font;
import org.apache.pdfbox.pdmodel.graphics.xobject.PDJpeg;
import org.apache.pdfbox.pdmodel.graphics.xobject.PDXObjectImage;

import com.database.DatabaseFacade;
import com.learnoba.UserSettings;
import com.learnoba.export.OutcomeOperation;
import com.learnoba.models.Assignment;
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
    private float MAX_SKILL_NAME_WIDTH;
    final private float TASKS_PER_PAGE = 10;
    /**
     * Font Constants
     */
    final private PDFont FONT = PDType1Font.COURIER;
    final private PDFont BOLD_FONT = PDType1Font.COURIER_BOLD;
    /**
     * Text Constants
     */
    final private String HEADER = "Assignment Feedback";
    final private String SKILL_NAME_HEADER = "Skill Name";
    final private String ICON_FILEPATH = UserSettings.getInstance().translatePath("LearnOBA.jpg");

    PDXObjectImage image = null;

    private float startX;
    private float startY;
    private float skillHeaderSize = 0f;
    private float width;// defined from page

    private FileOutput() {
        // Create a document and add a page to it
        try {
            document = new PDDocument();
            facade = DatabaseFacade.getInstance();
            userSettings = UserSettings.getInstance();
            MAX_SKILL_NAME_WIDTH = getStringWidth("1234567890123456789012345",
                    FONT_SIZE);
            image = new PDJpeg(document, new FileInputStream(ICON_FILEPATH));
        } catch (IOException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static FileOutput getInstance() {
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
        if (selectedDirectory == null) {
            return null;
        }
        return selectedDirectory.getAbsolutePath().toString().replace('\\', '/');
    }

    public void generateCsvFile(String delimiter, OutcomeOperation op) {
        List<List<String>> content = new ArrayList<List<String>>();

        content.add(new ArrayList<String>());
        content.get(0).add("Last Name");
        content.get(0).add("First Name");
        try {
            ResultSet rs = facade.getSelect().getSkillsByClass(userSettings.getCurrentClassID());
            List<Integer> skillids = new ArrayList<Integer>();

            while (rs.next()) {
                content.get(0).add(rs.getString("skill_name"));
                skillids.add(rs.getInt("skill_id"));
            }

            rs = facade.getSelect().getStudents(userSettings.getCurrentClassID());
            List<Integer> studentids = new ArrayList<Integer>();

            while (rs.next()) {
                content.add(new ArrayList<String>());
                int rowIndex = content.size() - 1;
                content.get(rowIndex).add(rs.getString("last_name"));
                content.get(rowIndex).add(rs.getString("first_name"));
                studentids.add(rs.getInt("student_id"));
                for (int i = 0; i < skillids.size(); i++) {
                    content.get(rowIndex).add("N/A");
                }
            }
            
            rs = facade.getSelect().getClassByID(userSettings.getCurrentClassID());

            String filename = "/" + rs.getString("class_name");

            switch (op) {
                case AVG:
                    filename += " (AVG) - ";
                    rs = facade.getSelect().getStudentAvgByClass(userSettings.getCurrentClassID());

                    while (rs.next()) {
                        int studentindex = studentids.indexOf(rs.getInt("student_id")) + 1;
                        int skillindex = skillids.indexOf(rs.getInt("skill_id")) + 2;
                        String value = Double.toString(rs.getDouble("average"));
                        content.get(studentindex).set(skillindex, value);
                    } 
                    break;
                case SUM:
                    filename += " (SUM) - ";
                    rs = facade.getSelect().getStudentSumByClass(userSettings.getCurrentClassID());
                    
                    while (rs.next()) {
                        int studentindex = studentids.indexOf(rs.getInt("student_id")) + 1;
                        int skillindex = skillids.indexOf(rs.getInt("skill_id")) + 2;
                        String value = Double.toString(rs.getDouble("sum"));
                        content.get(studentindex).set(skillindex, value);
                    } 
                    break;
                case TOP3:
                    filename += " (TOP3) - ";
                    rs = facade.getSelect().getStudentTop3AvgByClass(userSettings.getCurrentClassID());
                    
                    while (rs.next()) {
                        int studentindex = studentids.indexOf(rs.getInt("student_id")) + 1;
                        int skillindex = skillids.indexOf(rs.getInt("skill_id")) + 2;
                        String value = Double.toString(rs.getDouble("average"));
                        content.get(studentindex).set(skillindex, value);
                    } 
                    break;
                default:
                    return;
            }

            SimpleDateFormat sdf = new SimpleDateFormat("MM-dd-yyyy HHmm");
            Date dt = new Date();
            String dateString = sdf.format(dt);

            String file = showFilePickerSaver("Save Blackboard File", new Stage());
            filename += dateString + ".csv";
            if (file != null) {
                FileWriter writer =
                        new FileWriter(file + filename);

                for (List<String> rows : content) {
                    for (String item : rows) {
                        writer.append(item);
                        writer.append(delimiter);
                    }
                    writer.append('\n');
                }
                writer.flush();
                writer.close();
            }

        } catch (IOException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void createOutputForAllStudents(Assignment assignment) {
        try {
            ResultSet rs = facade.getSelect().getStudents(userSettings.getCurrentClassID());
            String directory = showFilePickerSaver("Save Blackboard File", new Stage());
            if (directory != null) {
                while (rs.next()) {
                    Student student = new Student();
                    student.setFirstName(rs.getString("first_name"));
                    student.setMiddleName(rs.getString("middle_name"));
                    student.setLastName(rs.getString("last_name"));
                    student.setEmail(rs.getString("email_address"));
                    student.setStudentID(rs.getInt("student_id"));
                    student.setUniversityID(rs.getString("student_id_code"));
                    createStudentOutput(student, assignment, directory);
                }
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * @param student
     * @param assignment
     * @throws IOException
     * @throws COSVisitorException
     * @throws SQLException
     */
    public void createStudentOutput(Student student, Assignment assignment, String directory) {

        List<List<String>> content = new ArrayList<List<String>>();

        content.add(new ArrayList<String>());
        content.get(0).add(SKILL_NAME_HEADER);
        
        try {
            skillHeaderSize = getStringWidth(SKILL_NAME_HEADER, FONT_SIZE);

            ResultSet rs =
                    facade.getSelect().getQuestionsForAssignment(assignment.getAssignmentID());
            int maxQuestionNumber = 0;

            while (rs.next()) {
                content.get(0).add("Q" + Integer.toString(rs.getInt("question_number")));
                if (rs.getInt("question_number") > maxQuestionNumber) {
                    maxQuestionNumber = rs.getInt("question_number");
                }
            }

            rs = facade.getSelect().getStudentOutcomesByAssignment(assignment.getAssignmentID(),
                    student.getStudentID());

            int count = 1;
            content.add(new ArrayList<String>());
            int rowIndex = content.size() - 1;
            while (rs.next()) {
                int questionNumber = rs.getInt("question_number");

                if (count == maxQuestionNumber && questionNumber < maxQuestionNumber) {
                    content.get(rowIndex).add("N/A");
                }

                if (count >= maxQuestionNumber) {
                    String skillName = rs.getString("skill_name");
                    float skillNameWidth = getStringWidth(skillName, FONT_SIZE);

                    if (questionNumber == maxQuestionNumber) {
                        content.get(rowIndex).add(Double.toString(rs.getDouble("outcome_value")));
                    }

                    content.get(rowIndex).add(0, skillName);

                    if (skillNameWidth >= MAX_SKILL_NAME_WIDTH) {
                        skillHeaderSize = MAX_SKILL_NAME_WIDTH;
                    } else if (skillNameWidth > skillHeaderSize) {
                        skillHeaderSize = skillNameWidth;
                    }
                    content.add(new ArrayList<String>());
                    rowIndex = content.size() - 1;
                    count = 1;
                }

                while (count < questionNumber) {
                    content.get(rowIndex).add("N/A");
                    count++;
                }
                if (questionNumber != maxQuestionNumber) {
                    content.get(rowIndex).add(Double.toString(rs.getDouble("outcome_value")));
                    count++;
                }

            }
        } catch (IOException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        // removes the extra ArrayList<String> at the end
        content.remove(content.size() - 1);

        // testContentGenerator(content);
        makeDocument(student, assignment, content, directory);
    }

    private void testContentGenerator(List<List<String>> content) {
        content = new ArrayList<List<String>>();
        int r = 7;
        int c = 25;
        String testSkillNames = "Skill Name";
        try {
            skillHeaderSize = getStringWidth(testSkillNames, FONT_SIZE);
        } catch (IOException e) {
            e.printStackTrace();
        }
        content = new ArrayList<List<String>>();
        for (int i = 0; i <= r; i++) {
            content.add(new ArrayList<String>());
            content.get(i).add(testSkillNames);
            if (i % 2 == 0) {
                testSkillNames = "12345";
            } else {
                testSkillNames = "12345";
            }

            for (int j = 0; j <= c; j++) {
                if (i == 0 && j > 0) {
                    content.get(0).add("Q" + Integer.toString(j));
                }
                else if (i > 0 && j > 0) {
                    content.get(i).add("300");
                }
            }
        }
        skillHeaderSize =
                (skillHeaderSize > MAX_SKILL_NAME_WIDTH) ? MAX_SKILL_NAME_WIDTH
                                                        : skillHeaderSize;
    }

    private void makeDocument(Student student, Assignment assignment, List<List<String>> content,
                              String directory) {
        PDPage page;
        PDPageContentStream contentStream;
        int from;
        int to;
        int numPages = (int) Math.ceil(content.get(0).size() / TASKS_PER_PAGE);
        int numTasksOnLastPage = (int) ((content.get(0).size() % TASKS_PER_PAGE) - 1);
        numTasksOnLastPage = (int) (numTasksOnLastPage == 0 ? TASKS_PER_PAGE : numTasksOnLastPage);

        for (int i = 0; i < numPages; i++) {
            page = new PDPage();
            document.addPage(page);
            mediabox = page.findMediaBox();
            width = mediabox.getWidth() - 2 * MARGIN;
            startX = mediabox.getLowerLeftX() + MARGIN;
            startY = mediabox.getUpperRightY() - MARGIN;
            from = (int) (i * TASKS_PER_PAGE + (1 * (i + 1)));
            to = (int) (from + (i == numPages - 1 ? numTasksOnLastPage : TASKS_PER_PAGE));

            try {
                // Start a new content stream which will "hold" the to be created content
                contentStream = new PDPageContentStream(document, page);
                writeHeader(student, assignment, contentStream);
                writeBody(contentStream, content, from, to);
                // Make sure that the content stream is closed:
                contentStream.close();
            } catch (IOException e) {
                e.printStackTrace();
                System.err.println("Document Making: " + e.getMessage());
            }
        }

        // Save the results and ensure that the document is properly closed:
        try {
            String saveFilename = directory + "/" + assignment.getAssignmentName() + " - "
                + student.getLastName().replaceAll("\\s", "")
                + student.getFirstName().replaceAll("\\s", "") + ".pdf";
            document.save(saveFilename);
            document.close();
            document = new PDDocument();
        } catch (COSVisitorException | IOException e) {
            e.printStackTrace();
        }

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
        contentStream
                .drawString("Name: " + student.getFirstName() + " " + student.getLastName());
        contentStream.moveTextPositionByAmount(0, -LEADING);
        contentStream.drawString("Assignment: " + assignment.getAssignmentName());
        contentStream.endText();
        contentStream.drawImage(image, mediabox.getLowerLeftX() + 7.5f,
                mediabox.getUpperRightY() - (image.getHeight() + 7.5f));
    }

    private void writeBody(PDPageContentStream contentStream, List<List<String>> content, int from,
                           int to) throws IOException {
        List<List<String>> subContent = new ArrayList<List<String>>();

        for (List<String> rowContent : content) {
            subContent.add(rowContent.subList(from, to));
            subContent.get(subContent.size() - 1).add(0, rowContent.get(0));
        }
        drawTable(650, subContent, contentStream);
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
