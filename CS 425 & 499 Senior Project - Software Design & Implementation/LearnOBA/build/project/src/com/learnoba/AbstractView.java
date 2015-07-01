package com.learnoba;

import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

/**
 * Abstract GUI class
 * 
 * @param <T> This specifies the class of the root pane within the view.
 */
public abstract class AbstractView<T extends Pane> extends Stage {
    private final String styleFile = "application.css";
    private static String OS = System.getProperty("os.name").toLowerCase();
    private AbstractController<T> controller;
    private T page;

    public AbstractView(String resource, String title) {
        FXMLLoader loader = new FXMLLoader(LearnOBAMain.class.getResource(resource));
        try {
            page = (T) loader.load();
            controller = loader.getController();
            controller.setPrimaryView(this);
            Scene scene = new Scene(page);
            scene.getStylesheets().add(LearnOBAMain.class.getResource(styleFile).toExternalForm());
            this.setScene(scene);
            this.setTitle(title);
            if (OS.indexOf("mac") >= 0) {
                this.getIcons().setAll(new Image("file:resources/LOBAIcon.icns"));
            } else {
                this.getIcons().setAll(new Image("file:resources/LOBAIcon.png"),
                        new Image("file:resources/LOBAIcon.ico"));
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public AbstractController<T> getController() {
        return controller;
    }

    public T getBasePane(){
        return page;
    }

    // TODO make abstract
    public void Update() {

    }

}
