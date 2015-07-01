package com.learnoba.login;


import java.util.List;

import javafx.geometry.Pos;
import javafx.scene.control.*;
import javafx.scene.control.Dialogs.DialogOptions;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

import com.learnoba.AbstractView;

public class LoginView extends AbstractView<AnchorPane> {
    private PasswordField password2;

    public LoginView(String resource, String title) {
        super(resource, title);
        password2 = null;
    }

    /**
     * Displays Feedback to the user based on the status of the login
     * 
     * @param status
     * @param usernameString
     */
    public void displayMessage(LoginStatus status, String usernameString) {
        usernameString = (usernameString == null ? "." : usernameString);
        switch (status) {
            case SUCCESSFUL_LOGIN:
                break;
            case INVALID_PASSWORD:
                Dialogs.showInformationDialog(new Stage(),
                        "The user name or password combination provided is incorrect!!", "Failure!",
                        "Login");
                break;

            case SUCCESSFUL_REGISTER:
                Dialogs.showInformationDialog(new Stage(), "You are now registered "
                    + usernameString
                    + "!! Please login with your credentials.", "Success!", "Login");
                break;
            case INVALID_INPUT:
                Dialogs.showErrorDialog(new Stage(), "Please enter something in the fields!!",
                        "Failure!", "Login", DialogOptions.OK);
                break;

            case USERNAME_IN_USE:
                Dialogs.showInformationDialog(new Stage(),
                        "The user name is currently in use!! Please try a new username", "Failure!",
                        "Login");
                break;
            case PASSWORDS_MISMATCH:
                Dialogs.showInformationDialog(
                        new Stage(),
                        "The passwords you entered do not match!! Please try to reenter the passwords.",
                        "Failure!",
                        "Login");
                break;
            case USERNAME_DOESNT_EXIST:
                Dialogs.showInformationDialog(
                        new Stage(),
                        "The Username currently entered doesn't exist in the database.",
                        "Missing Username",
                        "Login");

            default:
                break;
        }
    }

    /**
     * Toggle screen is used to go back and forth between the Login Screen to
     * 
     * @param loginButton
     * @param loginInstruction
     * @param newAccountLink
     */
    public void toggleScreen(boolean isLogin, Button loginButton, Label loginInstruction,
                             Hyperlink newAccountLink, GridPane pane) {
        if (isLogin) {
            loginButton.setText("Login");
            loginInstruction.setText("Login if you have an existing Account.");
            newAccountLink.setText("Don't already have an account? Click Here.");
            this.setTitle("Login Screen");
            this.setHeight(this.getHeight() - 150);
            pane.setLayoutY(pane.getLayoutY() - 150);
        } else {
            loginButton.setText("Create");
            loginInstruction.setText("Create New Account.");
            newAccountLink.setText("Already have an account? Click Here.");
            this.setTitle("Register Screen");
            this.setHeight(this.getHeight() + 150);
            pane.setLayoutY(pane.getLayoutY() + 150);
        }
    }

    public void addFieldsForRegister(List<TextField> fields) {
        password2 = (PasswordField) fields.get(0);
    }
}