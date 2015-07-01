package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.RadioButton;
import javafx.scene.layout.AnchorPane;

public class CreateClassController extends AbstractController {
	@FXML
    private RadioButton createClassRadio;
    @FXML
    private RadioButton selectClassRadio;
    @FXML
    private Button browseButton;
    @FXML
    private ComboBox courseCombo;
    @FXML
    private ComboBox semesterCombo;
    @FXML
    private ComboBox yearCombo;
    @FXML
    private Button createButton;
    @FXML
    private Button homeButton;
    @FXML
    private AnchorPane createClassPane;

    public CreateClassController() {
        super();
    }
    @FXML
    private void browseFired(ActionEvent event) {

    }

    @FXML
    private void createFired(ActionEvent event) {

    }
    @FXML
    private void homeFired(ActionEvent event) {
   
          
    }

    @FXML
    private void selectFired(ActionEvent event) {
   
    }

    @Override
    public void initialize(URL arg0, ResourceBundle arg1) {
        // TODO Auto-generated method stub

    }

}
