package application;

import javafx.fxml.Initializable;
import javafx.scene.layout.Pane;

/**
 * Abstract Controller
 * 
 * @param <T> This specifies the class of the root pane within the view.
 */

public abstract class AbstractController<T extends Pane> implements Initializable {

    private AbstractGUI<T> view = null;

    public AbstractController() {
    }

    public void setPrimaryView(AbstractGUI<T> view) {
        if (this.view == null) {
            this.view = view;
        }
    }

    public AbstractGUI<T> getPrimaryView() {
        return view;
    }

}
