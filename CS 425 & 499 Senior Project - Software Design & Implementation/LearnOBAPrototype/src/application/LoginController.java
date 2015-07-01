package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.geometry.Pos;
import javafx.scene.control.*;
import javafx.scene.control.Dialogs.DialogOptions;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

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

    public LoginController() {
        super();

    }

    @Override
    // This method is called by the FXMLLoader when initialization is complete
    public void initialize(URL fxmlFileLocation, ResourceBundle resources) {
        // initialize your logic here: all @FXML variables will have been injected
        loginInstruction.setAlignment(Pos.CENTER);
        logo.setImage(new Image("file:resources/Logo%20(inverted).png"));
    }

    @FXML
    private void loginFired(ActionEvent event) {

        if (loginButton.getText().equals("Login") && !(username.getCharacters().length() == 0)
            && !(password.getCharacters().length() == 0)) {
           // Dialogs.showInformationDialog(new Stage(), "You logged in successfully!!", "Success!",
             //       "Login");

            MainTabGUI mainTabGUI = new MainTabGUI("MainTabGUI.fxml", "Main Screen");
            MainTabController mainTabController = (MainTabController) mainTabGUI.getController();
            mainTabController.getPrimaryView().show();

            getPrimaryView().close();

        } else if (!loginButton.getText().equals("Register")) {
            Dialogs.showErrorDialog(new Stage(), "Please enter something in the fields!!", "Fail!",
                    "Login", DialogOptions.OK);
        } else if (!(username.getCharacters().length() == 0)
            && !(password.getCharacters().length() == 0)) {
            Dialogs.showInformationDialog(new Stage(), "You are now registered!!",
                    "Success!", "Login");
        } else {
            Dialogs.showErrorDialog(new Stage(), "Please enter something in the fields!!",
                    "Fail!", "Login", DialogOptions.OK);
        }
    }

    @FXML
    private void cancelFired(ActionEvent event) {
        getPrimaryView().close();
    }

    @FXML
    private void newAccountLoginScreenToggleFired(ActionEvent event) {
        if (loginButton.getText().equals("Login")) {
            loginButton.setText("Create");
            loginInstruction.setText("Create New Account.");
            newAccountLink.setText("Already have an account? Click Here.");


        } else {
            loginButton.setText("Login");
            loginInstruction.setText("Login if you have an existing Account.");
            newAccountLink.setText("Don't already have an account? Click Here.");
        }

    }




}
