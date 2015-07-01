package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;

public class SelectClassController extends AbstractController {
	@FXML
    private ComboBox semesterComboBox;
    @FXML
    private ComboBox yearComboBox;
    @FXML
    private ComboBox courseComboBox;
    @FXML
    private ListView rosterList;
    @FXML
    private ListView courseWorkList;
	@FXML
    private RadioButton addStudentRadio;
    @FXML
    private RadioButton createAssignmentRadio;
    @FXML
    private Button deleteStudentButton;
    @FXML
    private Button editAssignButton;
    @FXML
    private Button deleteAssignButton;
    @FXML
    private Label firstLabel;
	@FXML
    private Label lastLabel;
    @FXML
    private Label idLabel;
    @FXML
    private Button saveStudentButton;
    @FXML
    private TextField firstTextBox;
    @FXML
    private TextField lastTextBox;
    @FXML
    private TextField idTextBox;
    @FXML
    private Label assignmentNameLabel;
	@FXML
    private Label typeLabel;
    @FXML
    private Label percentageLabel;
    @FXML
    private Button saveAssignButton;
    @FXML
    private TextField percentageTextBox;
    @FXML
    private TextField assignmentNameTextBox;
    @FXML
    private ComboBox typeComboBox;
    @FXML
    private AnchorPane selectClassPane;



    public SelectClassController() {
        super();
    }
    @FXML
    private void addStudentFired(ActionEvent event) {
    		handleStudentEnable();  	
    }

    @FXML
    private void createAssignmentFired(ActionEvent event) {
    		handleAssignEnable();
    }
    @FXML
    private void deleteStudentFired(ActionEvent event) {
   
          
    }

    @FXML
    private void editAssignmentFired(ActionEvent event) {
       	EditAssignmentController controller= new EditAssignmentController();
    	controller.setPrimaryView(new EditAssignmentGUI("EditAssignment.fxml", "Edit Assignment Screen"));
    	controller.getPrimaryView().show();
    }
    @FXML
    private void deleteAssignmentFired(ActionEvent event) {
   
          
    }
    @FXML
    private void saveStudentFired(ActionEvent event) {
   
    }
    @FXML
    private void saveAssignmentFired(ActionEvent event) {
   
    }
    public void handleStudentEnable(){
    	firstLabel.setVisible(true);
    	lastLabel.setVisible(true);
    	idLabel.setVisible(true);
    	saveStudentButton.setVisible(true);
    	firstTextBox.setVisible(true);
    	lastTextBox.setVisible(true);
    	idTextBox.setVisible(true);
    }
    public void handleStudentDisable(){
    	firstLabel.setVisible(false);
    	lastLabel.setVisible(false);
    	idLabel.setVisible(false);
    	saveStudentButton.setVisible(false);
    	firstTextBox.setVisible(false);
    	lastTextBox.setVisible(false);
    	idTextBox.setVisible(false);
    }
    public void handleAssignEnable(){
    	typeComboBox.setVisible(true);
    	assignmentNameTextBox.setVisible(true);
    	percentageTextBox.setVisible(true);
    	saveAssignButton.setVisible(true);
    	percentageLabel.setVisible(true);
    	typeLabel.setVisible(true);
    	assignmentNameLabel.setVisible(true);
    }
    public void handleAssignDisable(){
    	typeComboBox.setVisible(false);
    	assignmentNameTextBox.setVisible(false);
    	percentageTextBox.setVisible(false);
    	saveAssignButton.setVisible(false);
    	percentageLabel.setVisible(false);
    	typeLabel.setVisible(false);
    	assignmentNameLabel.setVisible(false);
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        // TODO Auto-generated method stub

    }

}
