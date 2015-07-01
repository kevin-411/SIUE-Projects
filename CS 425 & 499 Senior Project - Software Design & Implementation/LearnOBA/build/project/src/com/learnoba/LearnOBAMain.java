package com.learnoba;

import java.io.IOException;
import java.sql.SQLException;

import javafx.application.Application;
import javafx.stage.Stage;

import com.learnoba.login.LoginView;

public class LearnOBAMain extends Application {
    private LoginView loginView;

    public static void main(String[] args) throws ClassNotFoundException, SQLException, IOException {
        Class.forName("org.sqlite.JDBC");
        determineDefaultDirectory();
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Class.forName("org.sqlite.JDBC");
        loginView = new LoginView("Login.fxml", "Login Screen");
        loginView.show();
    }

    private static void determineDefaultDirectory() {
        // here, we assign the name of the OS, according to Java, to a variable...
        String OS = (System.getProperty("os.name")).toUpperCase();
        // to determine what the workingDirectory is.
        // if it is some version of Windows
        if (OS.contains("WIN")) {
            UserSettings.getInstance().setWorkingDirectory(System.getenv("AppData"));
        }
        // Otherwise, we assume Linux or Mac
        else if (OS.contains("MAC")) {
            // in either case, we would start in the user's home directory
            UserSettings.getInstance().setWorkingDirectory(
                    System.getProperty("user.home") + "/Library/Application Support");

        }
        else {
            UserSettings.getInstance().setWorkingDirectory(System.getProperty("user.home"));
        }
    }
}
