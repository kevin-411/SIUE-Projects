package com.learnoba.login;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.GridPane;

import com.database.DatabaseFacade;
import com.learnoba.AbstractController;
import com.learnoba.UserSettings;
import com.learnoba.login.forgotpassword.ForgotPasswordController;
import com.learnoba.login.forgotpassword.ForgotPasswordView;
import com.learnoba.models.Login;
import com.learnoba.models.User;

public class LoginController extends AbstractController<AnchorPane> {
    @FXML
    private Button loginButton;
    @FXML
    private GridPane buttonsGridPane;
    @FXML
    private Button cancelButton;
    @FXML
    private PasswordField confirmPasswordField;
    @FXML
    private Label confirmPasswordLabel;
    @FXML
    private Hyperlink forgotPasswordLink;
    @FXML
    private AnchorPane login;
    @FXML
    private Hyperlink newAccountLink;
    @FXML
    private Label loginInstruction;
    @FXML
    private TextField username;
    @FXML
    private PasswordField password;
    @FXML
    private TextField securityAnswerField;
    @FXML
    private Label securityAnswerLabel;
    @FXML
    private TextField securityQuestionField;
    @FXML
    private Label securityQuestionLabel;
    @FXML
    private ImageView logo;

    private Login loginModel;

    private DatabaseFacade facade;
    
    private UserSettings userSettings;

    public LoginController() throws SQLException {
        super();
        userSettings = UserSettings.getInstance();
        loginModel = new Login();
        facade = DatabaseFacade.getInstance();
    }

    /**
     * This method is called by the FXMLLoader when initialization is complete. It allows us to
     * access the injected variables upon completion.
     */
    @Override
    public void initialize(URL fxmlFileLocation, ResourceBundle resources) {
        // initialize your logic here: all @FXML variables will have been injected
        loginInstruction.setAlignment(Pos.CENTER);
        logo.setImage(new Image("file:" + userSettings.translatePath("Logo%20(inverted).png")));
        installEventHandler(username);
        installEventHandler(password);
        installEventHandler(confirmPasswordField);
        installEventHandler(securityAnswerField);
        installEventHandler(securityQuestionField);
    }

    /**
     * This Method takes in a Node from the JavaFX forms and assigns an event handler that listens
     * for the enter key to be pressed or released.
     * 
     * @param keyNode
     */
    private void installEventHandler(final Node keyNode) {
        final EventHandler<KeyEvent> keyEventHandler =
                new EventHandler<KeyEvent>() {
                    public void handle(final KeyEvent keyEvent) {
                        if (keyEvent.getCode() == KeyCode.ENTER) {
                            try {
                                login();
                            } catch (SQLException e) {
                                e.printStackTrace();
                            }
                            keyEvent.consume();
                        }
                    }
                };

        keyNode.setOnKeyReleased(keyEventHandler);
    }

    /**
     * Method that handles when the cancel button is clicked.
     * 
     * @param event
     * @throws SQLException
     */
    @FXML
    private void loginFired(ActionEvent event) throws SQLException {
        login();
    }

    /**
     * Method that is called to perform a login attempt.
     * 
     * @throws SQLException
     */
    private void login() throws SQLException {
        String pass = password.getCharacters().toString();
        LoginStatus status = null;
        String confirmPass =
                !loginModel.isLogin() ? confirmPasswordField.getCharacters().toString() : "";
        User user = populateUser();
        if (!loginModel.isLogin() && !pass.equals(confirmPass)) {
            status = LoginStatus.PASSWORDS_MISMATCH;
        } else {
            status = loginModel.verifyUser(user);
        }

        ((LoginView) getPrimaryView()).displayMessage(status, user.getUserName());

        if (status == LoginStatus.SUCCESSFUL_LOGIN) {
            loginModel.displayTabController();
            getPrimaryView().close();
        } else if (status == LoginStatus.SUCCESSFUL_REGISTER) {
            newAccountLoginScreenToggleFired(null);
        }
    }

    private User populateUser() {
        User user = new User();
        user.setUserName(username.getCharacters() != null ? username.getCharacters().toString() : "");
        user.setPassword(password.getCharacters() != null ? password.getCharacters().toString() : "");
        user.setQuestion(securityQuestionField.getCharacters() != null ? securityQuestionField
                .getCharacters().toString() : "");
        user.setAnswer(securityAnswerField.getCharacters() != null ? securityAnswerField
                .getCharacters().toString() : "");
        return user;
    }

    /**
     * Method that handles when the cancel button is clicked.
     * 
     * @param event
     */
    @FXML
    private void cancelFired(ActionEvent event) {
        getPrimaryView().close();
    }

    /**
     * Method that handles when the
     * 
     * @param event
     */
    @FXML
    private void newAccountLoginScreenToggleFired(ActionEvent event) {
        loginModel.toggleScreen();
        ((LoginView) getPrimaryView()).toggleScreen(loginModel.isLogin(), loginButton,
                loginInstruction, newAccountLink, buttonsGridPane);
        toggleFields(confirmPasswordLabel, confirmPasswordField, !loginModel.isLogin());
        toggleFields(securityQuestionLabel, securityQuestionField, !loginModel.isLogin());
        toggleFields(securityAnswerLabel, securityAnswerField, !loginModel.isLogin());
    }
    
    private void toggleFields(Label label, TextField field, boolean toggle){
    	label.setVisible(toggle);
    	field.setVisible(toggle);
    	field.setFocusTraversable(toggle);
    }
    
    @FXML
    private void ForgotPassword() {
        if (username.getCharacters() == null) {
            return;
        }
        String userName = username.getCharacters().toString();

        if (userName.length() == 0) {
            return;
        }

        try {
            if (!facade.getSelect().validateUser(userName)) {
                ForgotPasswordView forgotPassView =
                        new ForgotPasswordView("ForgotPassword.fxml", "ForgotPassword");
                ForgotPasswordController controller =
                        ((ForgotPasswordController) forgotPassView.getController());
                controller.setUserSecurityQuestion(facade.getSelect().getUserQuestion(userName),
                        userName);

                forgotPassView.show();
            }
            else {
                ((LoginView) getPrimaryView()).displayMessage(LoginStatus.USERNAME_DOESNT_EXIST, "");
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
