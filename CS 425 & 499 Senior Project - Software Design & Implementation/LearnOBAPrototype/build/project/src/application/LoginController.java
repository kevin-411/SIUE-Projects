package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class LoginController extends AbstractController {
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

        if (loginButton.getText().equals("Login") && !username.getText().equals(null)
            && !password.getText().equals(null)) {
            Dialogs.showConfirmDialog(new Stage(), "You logged in successfully!!");

            System.out.println(((Button) event.getSource()).getText() + "\n");
            WelcomeController welcomeController = new WelcomeController();
            welcomeController.setPrimaryView(new WelcomeGUI("WelcomeGUI.fxml", "Welcome Screen"));
            welcomeController.getPrimaryView().show();

        } else if (!loginButton.getText().equals("Register")) {
            MessageDialog.getDialog("Please enter something in the fields!!", "Ok").show();
        } else if (username.getText() != "" && password.getText() != null) {
            MessageDialog.getDialog("You registered successfully!!", "Ok").show();
        } else {
            MessageDialog.getDialog("Please enter something in the fields!!", "Ok").show();
        }
    }

    @FXML
    private void cancelFired(ActionEvent event) {
        Node source = (Node) event.getSource();
        Stage stage = (Stage) source.getScene().getWindow();
        stage.close();
    }

    @FXML
    private void newAccountLoginScreenToggleFired(ActionEvent event) {
        if (loginButton.getText().equals("Login")) {
            loginButton.setText("Register");
            loginInstruction.setText("Register New Account.");
            newAccountLink.setText("Already have an account? Click Here.");

        } else {
            loginButton.setText("Login");
            loginInstruction.setText("Login if you have an existing Account.");
            newAccountLink.setText("Don't already have an account? Click Here.");
        }

    }




}
