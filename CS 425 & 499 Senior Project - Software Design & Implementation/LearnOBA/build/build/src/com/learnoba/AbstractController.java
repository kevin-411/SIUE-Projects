package com.learnoba;

import javafx.fxml.Initializable;
import javafx.scene.layout.Pane;

/**
 * Abstract Controller
 * 
 * @param <T> This specifies the class of the root pane within the view.
 */

public abstract class AbstractController<T extends Pane> implements Initializable {

    private AbstractView<T> view = null;

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

}
