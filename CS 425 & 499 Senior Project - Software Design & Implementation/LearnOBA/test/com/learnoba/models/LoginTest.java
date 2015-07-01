package com.learnoba.models;

import static org.junit.Assert.*;
import javafx.scene.control.*;

import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import org.mockito.Mockito;

public class LoginTest {
    Login loginModel;
    TextField username;
    PasswordField password;
    CharSequence userChars;
    CharSequence passChars;

    Button loginButton;
    Label loginInstruction;
    Hyperlink newAccountLink;

    /**
     * Before Class is run before the testing class is instantiated. In this case setting the driver
     * for the use of the JDBC. It's done this way as it only needs to be used once.
     * 
     * @throws ClassNotFoundException
     */
    @BeforeClass
    public static void beforeClass() throws ClassNotFoundException {
        java.lang.Class.forName("org.sqlite.JDBC");
    }

    /**
     * Setup is run before each individual test to start with a fresh set of objects to the
     * independent unit tests.
     * 
     * @throws Exception
     */
    @Before
    public void setUp() throws Exception {
        loginModel = new Login();
        username = Mockito.mock(TextField.class);
        password = Mockito.mock(PasswordField.class);
        userChars = Mockito.mock(CharSequence.class);
        passChars = Mockito.mock(CharSequence.class);
        
        loginButton = new Button();
        loginInstruction = new Label();
        newAccountLink = new Hyperlink();
        
        Mockito.when(userChars.toString()).thenReturn("testUN");
        Mockito.when(passChars.toString()).thenReturn("testPass");
        Mockito.when(username.getCharacters()).thenReturn(userChars);
        Mockito.when(password.getCharacters()).thenReturn(passChars);
    }

    /**
     * Test Is Login verifies that login defaults to true and changes between toggles.
     */
    @Test
    public void testIsLogin() {
        assertTrue(loginModel.isLogin());
        loginModel.toggleScreen();
        assertFalse(loginModel.isLogin());
        loginModel.toggleScreen();
        assertTrue(loginModel.isLogin());
    }


    /**
     * Test Toggle Screen verifies settings between different modes.
     */
    @Test
    public void testToggleScreen() {
        loginModel.toggleScreen();
        assertEquals("Create", loginButton.getText());
        assertEquals("Create New Account.", loginInstruction.getText());
        assertEquals("Already have an account? Click Here.", newAccountLink.getText());
        loginModel.toggleScreen();
        assertEquals("Login", loginButton.getText());
        assertEquals("Login if you have an existing Account.", loginInstruction.getText());
        assertEquals("Don't already have an account? Click Here.", newAccountLink.getText());

    }

}
