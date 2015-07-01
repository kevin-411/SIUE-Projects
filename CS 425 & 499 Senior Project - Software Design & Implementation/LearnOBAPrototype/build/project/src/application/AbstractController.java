package application;

import javafx.fxml.Initializable;



public abstract class AbstractController implements Initializable {

    private AbstractGUI view;

    public AbstractController() {

    }

    public void setPrimaryView(AbstractGUI view) {
        this.view = view;
    }

    public AbstractGUI getPrimaryView() {
        return view;
    }

}
