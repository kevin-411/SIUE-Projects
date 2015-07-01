package com.learnoba.login.forgotpassword;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

import com.database.DatabaseFacade;
import com.learnoba.AbstractController;
import com.learnoba.models.User;

public class ForgotPasswordController extends AbstractController<AnchorPane> {

    @FXML
    private PasswordField confirmNewPasswordField;

    @FXML
    private PasswordField newPasswordField;

    @FXML
    private TextField securityAnswerField;

    @FXML
    private Label securityQuestionLabelText;

    @FXML
    private Button submitButton;

    private DatabaseFacade facade;

    private String username;

    @Override
    public void initialize(URL arg0, ResourceBundle arg1) {
        try {
            facade = DatabaseFacade.getInstance();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void setUserSecurityQuestion(String question, String username) {
        securityQuestionLabelText.setText(question);
        this.username = username;
    }

    @FXML
    private void submitPressed() {
        String newPass;
        String confPass;
        String answer;

        if (newPasswordField.getCharacters() == null
            || confirmNewPasswordField.getCharacters() == null
            || securityAnswerField.getCharacters() == null) {
            return;
        }
        newPass = newPasswordField.getCharacters().toString();
        confPass = confirmNewPasswordField.getCharacters().toString();
        answer = securityAnswerField.getCharacters().toString();
        
        if (!newPass.equals(confPass)) {
            Dialogs.showErrorDialog(
                    new Stage(),
                    "The passwords you entered do not match!! Please try to reenter the passwords.",
                    "Failure!",
                    "Login");
            return;
        }
        
        try {
            if (facade.getSelect().getUserAnswer(username, answer)) {
                User user = new User();
                user.setUserName(username);
                user.setPassword(newPass);
                user.setQuestion(securityQuestionLabelText.getText());
                user.setAnswer(answer);
                user.setUserID(facade.getSelect().getUserID(username));
                facade.getUpdate().updateUser(user);
                Dialogs.showInformationDialog(
                        new Stage(),
                        "Your password has been updated!!",
                        "Successful Update!!",
                        "Login");
                getPrimaryView().close();
            } else {
                Dialogs.showErrorDialog(
                        new Stage(),
                        "The answer you provided is incorrect.",
                        "Failure!",
                        "Login");
            }


        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

}
