package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

public class CreateClassController extends AbstractController<AnchorPane> {
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
    @FXML
    private Label successLabel;
    @FXML
    private TextField rosterTextBox;
    
    public CreateClassController() {
        super();
    }
    @FXML
    private void browseFired(ActionEvent event) {
    	Stage stage = new Stage();
    	FileChooser fileChooser = new FileChooser();
    	fileChooser.setTitle("C:/Users/Owner/Documents/CS 425/roster.txt");
    	fileChooser.showOpenDialog(stage);
    	rosterTextBox.setText(fileChooser.getTitle());
    	
    }

    @FXML
    private void createFired(ActionEvent event) {

    	successLabel.setVisible(true);
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
