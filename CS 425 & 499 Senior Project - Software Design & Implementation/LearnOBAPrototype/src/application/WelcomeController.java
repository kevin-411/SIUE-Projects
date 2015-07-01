package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.RadioButton;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;


public class WelcomeController extends AbstractController<AnchorPane> {
    @FXML
    private RadioButton createClassRadio;
    @FXML
    private RadioButton selectClassRadio;
    @FXML
    private Button exitButton;
    @FXML
    private AnchorPane welcomePane;

    public WelcomeController() {
        super();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {


    }

    @FXML
    private void createFired(ActionEvent event) {
        CreateClassController controller = new CreateClassController();
        controller.setPrimaryView(new CreateClassGUI("CreateClass.fxml", "Create Class Screen"));
        controller.getPrimaryView().show();

    }

    @FXML
    private void selectFired(ActionEvent event) {
        SelectClassController controller = new SelectClassController();
        controller.setPrimaryView(new SelectClassGUI("SelectClass.fxml", "Select Class Screen"));
        controller.getPrimaryView().show();
    }

    public Pane getParentPane() {
        return welcomePane;
    }



}
