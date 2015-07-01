package application;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.control.TreeItem;
import javafx.scene.control.TreeView;
import javafx.scene.layout.AnchorPane;

public class EnterScoresController extends AbstractController<AnchorPane> {

	@FXML
    private AnchorPane enterScoresPane;
	@FXML
    private ListView studentListView;
    @FXML
    private TreeView skillsTreeView;
    @FXML
    private Label scoresLabel;
    @FXML
    private Label studentLabel;
    @FXML
    private Label firstLabel;
    @FXML
    private Label lastLabel;
    @FXML
    private Label middleinitialLabel;
    @FXML
    private Label actualFirstLabel;
    @FXML
    private Label actualLastLabel;
    @FXML
    private Label actualMiddleInitialLabel;
    @FXML
    private Label idLabel;
    @FXML
    private Label actualIDLabel;
    @FXML
    private Label currentLabel;
    @FXML
    private Label actualCurrentLabel;
    @FXML
    private Button saveButton;
    
    public EnterScoresController() {
        super();
    }
    
    public void showLabels(){
    	firstLabel.setVisible(true);
    	lastLabel.setVisible(true);
    	middleinitialLabel.setVisible(true);
    	actualFirstLabel.setVisible(true);
    	actualLastLabel.setVisible(true);
    	actualMiddleInitialLabel.setVisible(true);
    	idLabel.setVisible(true);
    	actualIDLabel.setVisible(true);
    	currentLabel.setVisible(true);
    	actualCurrentLabel.setVisible(true);
    }
  
    @Override
    public void initialize(URL location, ResourceBundle resources) {
    	
    	//Here is a bunch of crappy looking code for the tree view to enter scores
    	TextField text = new TextField();
    	TextField text1 = new TextField();
    	TextField text2= new TextField();
    	TextField text3 = new TextField();
    	TextField text4 = new TextField();
    	TextField text5 = new TextField();
    	TextField text6 = new TextField();
    	TextField text7 = new TextField();
    	TextField text8= new TextField();
    	TextField text9 = new TextField();
    	TextField text10 = new TextField();
    	TextField text11 = new TextField();
    	TextField text12 = new TextField();
    	TextField text13 = new TextField();
    	TextField text14= new TextField();
       	TreeItem<String> root = new TreeItem<String>("Question 1");
        TreeItem<String> top = new TreeItem<String>("Questions");
        TreeItem<String> root1 = new TreeItem<String>("Question 2");
        TreeItem<String> root2 = new TreeItem<String>("Question 3");
        TreeItem<String> root3 = new TreeItem<String>("Question 4");
        TreeItem<String> root4 = new TreeItem<String>("Question 5");
        TreeItem<String> root5 = new TreeItem<String>("Question 6");
        
        text.setMaxWidth(20);
        text1.setMaxWidth(20);
        text2.setMaxWidth(20);
        text3.setMaxWidth(20);
        text4.setMaxWidth(20);
        text5.setMaxWidth(20);
        text6.setMaxWidth(20);
        text7.setMaxWidth(20);
        text8.setMaxWidth(20);
        text9.setMaxWidth(20);
        text10.setMaxWidth(20);
        text11.setMaxWidth(20);
        text12.setMaxWidth(20);
        text13.setMaxWidth(20);
        text14.setMaxWidth(20);
        
        
        text.setText("5");
        text1.setText("5");
        text2.setText("5");
        text3.setText("5");
        text4.setText("5");
        text5.setText("5");
        text6.setText("5");
        text7.setText("5");
        text8.setText("5");
        text9.setText("5");
        text10.setText("5");
        text11.setText("5");
        text12.setText("5");
        text13.setText("5");
        text14.setText("5");
      
      
    	   //Add TreeItems to the root
        root.getChildren().addAll(
            new TreeItem<String>("Diagram", text),
            new TreeItem<String>("Equation", text1),
            new TreeItem<String>("Algebra", text2));
        
        root1.getChildren().addAll(
                new TreeItem<String>("Decomposition", text3),
                new TreeItem<String>("Definition Used Correctly", text4),
                new TreeItem<String>("Correctly Defined Variables", text5)); 
        root2.getChildren().addAll(
                new TreeItem<String>("Energy Bar Chart", text6),
                new TreeItem<String>("Forces Identified", text7),
                new TreeItem<String>("System Defined", text8));
        root3.getChildren().addAll(
                new TreeItem<String>("Diagram", text9),
                new TreeItem<String>("Equation", text10),
                new TreeItem<String>("Work", text11));
        root4.getChildren().addAll(
                new TreeItem<String>("Internal Momentum Defined", text12),
                new TreeItem<String>("Free Body Diagram", text13),
                new TreeItem<String>("Torques Summed Along X-Axis", text14));
    
        top.getChildren().addAll(root, root1, root2, root3, root4);
        skillsTreeView.setRoot(top);
        
        //This populates the list view
    	ObservableList<String> items =FXCollections.observableArrayList (
        	    "Zach Benchley", "Logan Maughan", "Brian Olsen", "Matt Lievens", "Jeremy Mintun", "Haley Evans",
        	    "Bryce Starkey", "Cole Burton");
    	studentListView.setItems(items);
    	
    	//This is responsible for showing labels when a name is selected from the list
    	studentListView.getSelectionModel().selectedItemProperty().addListener(
    	new ChangeListener<String>() {
            public void changed(ObservableValue<? extends String> ov, 
                String old_val, String new_val) {
            	showLabels();
        }});
      	   
    }
    
 
}
