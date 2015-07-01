package com.learnoba.fileoutput;

import java.io.IOException;
import java.sql.SQLException;

import org.apache.pdfbox.exceptions.COSVisitorException;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import com.database.QueryTestHelper;

public class FileOutputTest {
    FileOutput fileOut;
    QueryTestHelper helper;

    @BeforeClass
    public static void setUpClass() throws ClassNotFoundException {
        Class.forName("org.sqlite.JDBC");
    }

    @Before
    public void setUp() throws Exception {
        Class.forName("org.sqlite.JDBC");
        fileOut = FileOutput.getInstance();
        helper = QueryTestHelper.getInstance();
    }

    @Test
    public void test() throws COSVisitorException, IOException, SQLException {

       // fileOut.createStudentOutput(helper.createStudents().get(0),
         //       helper.createAssignments().get(0));
    }

}
