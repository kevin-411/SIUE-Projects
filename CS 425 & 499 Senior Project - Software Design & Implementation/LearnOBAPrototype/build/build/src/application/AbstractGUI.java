package application;

import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public abstract class AbstractGUI extends Stage {
    private final String styleFile = "application.css";
    private static String OS = System.getProperty("os.name").toLowerCase();

    public AbstractGUI(String resource, String title) {
        try {
            AnchorPane page = FXMLLoader.<AnchorPane> load(Main.class.getResource(resource));
            Scene scene = new Scene(page);
            scene.getStylesheets().add(Main.class.getResource(styleFile).toExternalForm());
            this.setScene(scene);
            this.setTitle(title);
            if (OS.indexOf("mac") >= 0) {
                this.getIcons().setAll(new Image("file:resources/LOBAIcon.icns"));
            } else {
                this.getIcons().setAll(new Image("file:resources/LOBAIcon.png"));
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
