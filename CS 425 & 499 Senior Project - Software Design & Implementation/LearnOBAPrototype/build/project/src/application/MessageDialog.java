package application;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.VBoxBuilder;
import javafx.scene.text.Text;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class MessageDialog {
    // private static MessageDialog dia = null;
    //
    // protected MessageDialog() {
    //
    // }
    //
    // public static MessageDialog getInstance() {
    // if (dia == null) {
    // dia = new MessageDialog();
    // }
    // return dia;
    // }

    public static Stage getDialog(String text, String buttonText) {
        Stage dialogStage = new Stage();
        dialogStage.initModality(Modality.WINDOW_MODAL);
        dialogStage.setScene(new Scene(VBoxBuilder.create().
                children(new Text(text), new Button(buttonText)).
                alignment(Pos.CENTER).padding(new Insets(5)).build()));
        return dialogStage;
    }
}
