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
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Class.forName("org.sqlite.JDBC");
        loginView = new LoginView("Login.fxml", "Login Screen");
        loginView.show();
    }

}