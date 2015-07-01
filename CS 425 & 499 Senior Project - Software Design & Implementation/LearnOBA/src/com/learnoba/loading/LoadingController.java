package com.learnoba.loading;

import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

import com.learnoba.AbstractController;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.layout.AnchorPane;


public class LoadingController extends AbstractController<AnchorPane>{
	
    public LoadingController() throws SQLException {
        super();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        
    }
   
}
