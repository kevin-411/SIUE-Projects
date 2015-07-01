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

import com.learnoba.AbstractController;
import com.learnoba.models.Login;

public class LoginController extends AbstractController<AnchorPane> {
    @FXML
    private Button loginButton;
    @FXML
    private Button cancelButton;
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
    private ImageView logo;

    private Login loginModel;

    public LoginController() throws SQLException {
        super();
        loginModel = new Login();
    }

    /**
     * This method is called by the FXMLLoader when initialization is complete. It allows us to
     * access the injected variables upon completion.
     */
    @Override
    public void initialize(URL fxmlFileLocation, ResourceBundle resources) {
        // initialize your logic here: all @FXML variables will have been injected
        loginInstruction.setAlignment(Pos.CENTER);
        logo.setImage(new Image("file:resources/Logo%20(inverted).png"));
        installEventHandler(username);
        installEventHandler(password);
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

        keyNode.setOnKeyPressed(keyEventHandler);
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
        LoginStatus status = loginModel.verifyUser(username, password);

        ((LoginView) getPrimaryView()).displayMessage(status, loginModel.getUsername());

        if (status == LoginStatus.SUCCESSFUL_LOGIN) {
            loginModel.displayTabController();
            getPrimaryView().close();
        } else if (status == LoginStatus.SUCCESSFUL_REGISTER) {
            newAccountLoginScreenToggleFired(null);
        }
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
                loginInstruction, newAccountLink);
    }
}
