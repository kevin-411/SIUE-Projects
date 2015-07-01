package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;

public class ManageClassController extends AbstractController<AnchorPane> {
@FXML
private Label optionLabel;
@FXML
private RadioButton addRadio;
@FXML
private RadioButton selectRadio;
@FXML
private AnchorPane optionAnchor;
@FXML
private AnchorPane manageClassPane;
    public ManageClassController() {
        super();
    }
    
    @Override
    public void initialize(URL location, ResourceBundle resources) {
        
    }
  
    @FXML
    private void addClassFired(ActionEvent event) {
    	CreateClassGUI createClassGUI = new CreateClassGUI("CreateClass.fxml", "Add Class");
    	optionAnchor.getChildren().add(new Label("")); 
    	optionAnchor.getChildren().addAll(createClassGUI.getBasePane());
    	
    	
    }
    @FXML
    private void selectClassFired(ActionEvent event) {
    	SelectClassGUI selectClassGUI = new SelectClassGUI("SelectClass.fxml", "Select Class");
    	optionAnchor.getChildren().add(new Label("")); 
    	optionAnchor.getChildren().add((AnchorPane) selectClassGUI.getBasePane());
    }
  
 
}
