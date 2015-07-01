package application;

import javafx.application.Application;
import javafx.stage.Stage;

public class Main extends Application {
	@Override
	public void start(Stage primaryStage) {
        LoginController controller = new LoginController();
        controller.setPrimaryView(new LoginGUI("LoginGUI.fxml", "Login Screen"));
        controller.getPrimaryView().show();
        
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
