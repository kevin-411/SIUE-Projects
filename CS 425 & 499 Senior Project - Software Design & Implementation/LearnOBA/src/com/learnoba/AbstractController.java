package com.learnoba;

import com.learnoba.loading.LoadingController;
import com.learnoba.loading.LoadingView;
import com.learnoba.login.forgotpassword.ForgotPasswordController;
import com.learnoba.login.forgotpassword.ForgotPasswordView;

import javafx.event.EventHandler;
import javafx.fxml.Initializable;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Dialogs;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.Pane;
import javafx.scene.layout.VBoxBuilder;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;
import javafx.stage.Modality;
import javafx.stage.Stage;
import javafx.stage.StageStyle;
import javafx.stage.WindowEvent;

/**
 * Abstract Controller
 * 
 * @param <T> This specifies the class of the root pane within the view.
 */

public abstract class AbstractController<T extends Pane> implements Initializable {

    private AbstractView<T> view = null;
    private LoadingView loadView = null;

    public AbstractController() {
    	
    }

    public void setPrimaryView(AbstractView<T> view) {
        if (this.view == null) {
            this.view = view;
        }
    }

    public AbstractView<T> getPrimaryView() {
        return view;
    }
    
    public void setLoading(){
    	if(loadView == null){
	    	loadView = new LoadingView("loading.fxml", "Loading");
	        LoadingController controller = (LoadingController) loadView.getController();
	        loadView.initModality(Modality.APPLICATION_MODAL);
	        loadView.initStyle(StageStyle.UNDECORATED);
	        loadView.initOwner(getPrimaryView());
	        loadView.setResizable(false);
	        getPrimaryView().getBasePane().setDisable(true);
	        loadView.show();
	        loadView.setX((getPrimaryView().getBasePane().getScene().getWindow().getX() + (getPrimaryView().getBasePane().getScene().getWidth() / 2)) - (loadView.getWidth() / 2));
	        loadView.setY((getPrimaryView().getBasePane().getScene().getWindow().getY() + (getPrimaryView().getBasePane().getScene().getHeight() / 2)) - (loadView.getHeight() / 2));
    	}
    }
    
    public void stopLoading(){
    	if(loadView.isShowing())
    		loadView.close();
    	loadView = null;
    	getPrimaryView().getBasePane().setDisable(false);
    }

}
