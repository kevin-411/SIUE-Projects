package com.learnoba.models;

import java.io.File;
import java.io.FileNotFoundException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.Dialogs;
import javafx.scene.control.TreeItem;
import javafx.scene.control.TreeView;
import javafx.scene.control.Dialogs.DialogOptions;
import javafx.scene.control.Dialogs.DialogResponse;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import com.database.DatabaseFacade;
import com.learnoba.AbstractModel;
import com.learnoba.UserSettings;

public class Skill extends AbstractModel{
    private String name;
    private int skillID;
    private int parentID;
    private int classID;
    private int prefilledOutcomeValue;
    
    private DatabaseFacade facade;
    private UserSettings settings;

    private List<Skill> skills;
    private ObservableList<String> skillNames;
    
    public Skill(String rootSkill) throws SQLException {
    	settings = settings.getInstance();
    	facade = facade.getInstance();
        name = rootSkill;
        skillID = -1;
        parentID = 0;
        classID = settings.getCurrentClassID();
        prefilledOutcomeValue = settings.getCurrentMaxOutcome();
        skills = new ArrayList<Skill>();
        skillNames = FXCollections.observableList(new ArrayList<String>());
        skillNames.add(rootSkill);
    }
    
    private Skill(String skill_name, int skill_id, int parent_id, int class_id, int outcome) throws SQLException{
        name = skill_name;
        skillID = skill_id;
        parentID = parent_id;
        classID = class_id;
        prefilledOutcomeValue = outcome;
        skills = new ArrayList<Skill>();
        skillNames = FXCollections.observableList(new ArrayList<String>());
        facade = null;
        settings = null;
    }
    
    
    /**
     * @return the skillID
     */
    public int getSkillID() {
        return skillID;
    }

    /**
     * @param skillID the skillID to set
     */
    public void setSkillID(int skillID) {
        this.skillID = skillID;
    }

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the parentID
     */
    public int getParentID() {
        return parentID;
    }

    /**
     * @param parentID the parentID to set
     */
    public void setParentID(int parentID) {
        this.parentID = parentID;
    }

    /**
     * @return the skills
     */
    public List<Skill> getSkills() {
        return skills;
    }

    /**
     * @param skills the skills to set
     */
    public void setSkills(List<Skill> skills) {
        this.skills = skills;
    }

    /**
     * @return the prefilledOutcomeValue
     */
    public int getPrefilledOutcomeValue() {
        return prefilledOutcomeValue;
    }

    /**
     * @param prefilledOutcomeValue the prefilledOutcomeValue to set
     */
    public void setPrefilledOutcomeValue(int prefilledOutcomeValue) {
        this.prefilledOutcomeValue = prefilledOutcomeValue;
    }
    
    /**
     * @return the skillNames
     */
    public ObservableList<String> getSkillNames() {
        return skillNames;
    }
    
    /**
     * @return the skillNames of all skills
     */
    public ObservableList<String> getAllSkillNames() {
    	List<Skill> skills = this.getSkills();
    	ObservableList<String> names = FXCollections.observableList(new ArrayList<String>());
    	if(skills == null)
    		return null;
    	names.addAll(getSkillNames());
        for(int i = 0; i < skills.size(); i++){
        	if(skills.get(i).getSkills() != null)
        		names.addAll(skills.get(i).getAllSkillNames());
        }
        return names;
    }
    
    /**
     * @param skillNames the skillNames to set
     */

    public void setSkillNames(ObservableList<String> skillNames) {
        this.skillNames = skillNames;
    }
    

    /**
     * @return the classID
     */
    public int getClassID() {
        return classID;
    }

    /**
     * @param classID the classID to set
     */
    public void setClassID(int classID) {
        this.classID = classID;
    }
    
    //creates a new skill with the given attributes and adds it to the list
    private Skill addSkill(String name, int skillId, int parentId, int classId, int outcome) throws SQLException{
        Skill newSkill = new Skill(name, skillId, parentId, classId, outcome);
        skills.add(newSkill);
        skillNames.add(name);
        FXCollections.sort(skillNames);
        return newSkill;
    }
    //creates a new skill with the given attributes and adds it to the list as well as the database
    private int createSkill(String name, int parentId, int classId, int outcome) throws SQLException{
        int id;
        Skill newSkill = addSkill(name, -1, parentId, classId, outcome);
        id = facade.getInsert().insertSkill(newSkill);
		newSkill.setSkillID(id);
		return id;
    }
    //inserts a skill given the skill name and its parent
    public boolean insert(String newSkill, String parent, String outcome, String rootSkill) throws SQLException{
        boolean added = false;
        Skill parentObj = null;
        //if the new skill is not blank
        if(!(newSkill.isEmpty())){
            //make sure skill does not already exist.
            //if it doesn't exist and the parent skill chosen was the root, then add it to list
            //if it doesn't exist and the parent skill chosen was not the root, then find the parent and add to the parent's list
            if(exists(newSkill)){
                Dialogs.showErrorDialog(new Stage(), "There is already a skill with that name! Please choose a unique skill name.", "Create a Skill");
            }else{
                added = true;
            }
        }else{
            Dialogs.showErrorDialog(new Stage(), "Your new skill must have a name!", "Create a Skill");
        }
        if(added){
        	parentObj = find(parent);
        	if(parentObj == null)
        		parentObj = this;
        	parentObj.createSkill(newSkill, parentObj.getSkillID(), settings.getCurrentClassID(), Integer.parseInt(outcome));
        }
        return added;
    }
    //deletes a skill if given its name
    public boolean delete(String skillName, String parentName) throws SQLException{
        Skill skill, parent;
        parent = find(parentName);
        skill = find(skillName);
        if(!(skill.getSkills().isEmpty())){
        	deleteChildren(skill);
        }
        parent.skills.remove(skill);
        parent.skillNames.remove(skill.getName());
        facade.getDelete().deleteSkill(skill);
        return true;
    }
    //Recursively deletes all child skills of a given skill
    private void deleteChildren(Skill root) throws SQLException{
    	List<Skill> children = root.getSkills();
    	for(Skill item : children){
    		if(!(item.getSkills().isEmpty())){
    			deleteChildren(item);
    		}
    		facade.getDelete().deleteSkill(item);
    	}
    }
    //updates the given skill with the new name and parent
    public boolean update(String skillName, String parentName, String newSkillName, String newParentName, String outcome) throws SQLException{
        boolean changed = false;
        Skill item, parentSkill;
        //if the new skill name is not empty
        if(!newSkillName.isEmpty()){
            //if the new and old skill names are different, and the new skill name already exists, show dialog
            if(!newSkillName.equals(skillName) && (skillNames.contains(newSkillName) == true)){
                Dialogs.showErrorDialog(new Stage(), "There is already a skill with that name! Please choose a unique skill name.", "Edit a Skill");
            //if the parents are the same, simply update the skill name
            }else if(parentName == newParentName){
                item = find(skillName);
                item.setName(newSkillName);
                item.setPrefilledOutcomeValue(Integer.parseInt(outcome));
                skillNames.remove(skillName);
                skillNames.add(newSkillName);
                facade.getUpdate().updateSkill(item);
                changed = true;
            }else{
                parentSkill = find(newParentName);
                item = find(skillName);
                //make sure that the skill being updated is not a child of the new parent.  if it is not, update it 
                if(!item.exists(newParentName)){
                    find(parentName).skills.remove(item);
                    parentSkill.skills.add(item);
                    item.setName(newSkillName);
                    item.setPrefilledOutcomeValue(Integer.parseInt(outcome));
                    item.setParentID(parentSkill.getSkillID());
                    skillNames.remove(skillName);
                    skillNames.add(newSkillName);
                    facade.getUpdate().updateSkill(item);
                    changed = true;
                }else{
                    Dialogs.showErrorDialog(new Stage(), "You must choose a parent skill that is not a child of the current skill", "Edit a Skill");
                }
            }
        }else{
            Dialogs.showErrorDialog(new Stage(), "You must enter something into the textbox!", "Edit a Skill");
        }
        return changed;
    }
    //accesses the database and pulls all skills out associated with the current class
    public void getAllSkills() throws SQLException{
        ResultSet set;
        Skill temp, parent;
        int class_id = settings.getCurrentClassID();
        LinkedList<Skill> queue = new LinkedList<Skill>();
        set = facade.getSelect().getSkillsByClass(settings.getCurrentClassID());
        
        while(set.next()){
        	if(set.getInt("skill_id") == -1)
        		continue;
            //if the skill's parent ID is equal to the current skill ID, add it to current skill's children
            //otherwise, find the skill with the skill's parent ID and add it to that skill. 
            //if the parent skill does not exist yet, add the skill to the queue.  
            if(set.getInt("parent_id") == this.getSkillID()){
            	this.addSkill(set.getString("skill_name"), set.getInt("skill_id"), set.getInt("parent_id"), set.getInt("class_id"), set.getInt("prefilled_outcome_value"));
            }else if((parent = find(set.getInt("parent_id"))) != null){
            	parent.addSkill(set.getString("skill_name"), set.getInt("skill_id"), set.getInt("parent_id"), set.getInt("class_id"), set.getInt("prefilled_outcome_value"));
            }else{
            	queue.add(new Skill(set.getString("skill_name"), set.getInt("skill_id"), set.getInt("parent_id"), set.getInt("class_id"), set.getInt("prefilled_outcome_value")));
            }
        }
        //Go through the queue and add all of the skills
        while(!queue.isEmpty()){
        	temp = queue.pop();
        	if((parent = find(temp.getParentID())) != null){
            	parent.addSkill(temp.getName(), temp.getSkillID(), temp.getParentID(), temp.getClassID(), temp.getPrefilledOutcomeValue());
        	}else{
            	queue.add(temp);
            }
        }
    }
    //accesses the database and pulls all skills out associated with the given task id
    public void getAllSkillsForTask(int task_id) throws SQLException{
    	List<Skill> skills = new ArrayList<Skill>();
    	List<Integer> skillIDs = new ArrayList<Integer>();
    	LinkedList<Skill> queue = new LinkedList<Skill>();
    	Skill parent, temp;
    	ResultSet set = facade.getSelect().getTaskSpecificSkills(task_id);
        while(set.next()){
        	skills.add(new Skill(set.getString("skill_name"), set.getInt("skill_id"), set.getInt("parent_id"), set.getInt("class_id"), set.getInt("prefilled_outcome_value")));
        	skillIDs.add(set.getInt("skill_id"));
    	}
        for(Skill skill : skills){
        	//if the skills parent is not in the list of skills ids, add to root.  
        	if(!(skillIDs.contains(skill.getParentID())))
        		this.addSkill(skill.getName(), skill.getSkillID(), skill.getParentID(), skill.getClassID(), skill.getPrefilledOutcomeValue());
        	//if the parent can be found, add skill to parents children
        	else if((parent = find(skill.getParentID())) != null)
        		parent.addSkill(skill.getName(), skill.getSkillID(), skill.getParentID(), skill.getClassID(), skill.getPrefilledOutcomeValue());
        	else
        		queue.add(skill);
        }
        //Go through the queue and add all of the skills
        while(!queue.isEmpty()){
        	temp = queue.pop();
        	if((parent = find(temp.getParentID())) != null){
            	parent.addSkill(temp.getName(), temp.getSkillID(), temp.getParentID(), temp.getClassID(), temp.getPrefilledOutcomeValue());
        	}else{
            	queue.add(temp);
            }
        }
    }
    //recursively finds the skill with the given name and returns it
    //returns null if it doesn't exist
    public Skill find(String skillName){
        Skill skill = null;
        if(skills == null)
        	return null;
        if(this.name == skillName)
            return this;
        //loop through list of skills
        for(Skill item: skills){
            //if skill is found, return it
            if(item.getName().equals(skillName)){
                return item;
            }else{
                //if child skill list is not empty, recurse down
                if(item.skills != null){
                    skill = item.find(skillName);
                    //if skill has been found, return skill
                    if(skill != null && skill.getName().equals(skillName))
                        return skill;
                }
            }
        }
        return skill;
    }
    //recursively finds the skill with the given id and returns it
    //returns null if it doesn't exist
    public Skill find(int ID){
        Skill skill = null;
        if(skills == null)
        	return null;
        if(this.getSkillID() == ID)
            return this;
        //loop through list of skills
        for(Skill item: skills){
            //if skill is found, return it
            if(item.getSkillID() == ID){
                return item;
            }else{
                //if child skill list is not empty, recurse down
                if(item.getSkills() != null){
                    skill = item.find(ID);
                    //if skill has been found, return skill
                    if(skill != null && skill.getSkillID() == ID)
                        return skill;
                }
            }
        }
        return skill;
    }
    //returns true if the skill already exists, false otherwise
    public boolean exists(String skill_name){
        ObservableList<String> names = getAllSkillNames();
        if(names == null)
            return false;
        return names.contains(skill_name);
    }
    //returns the number of leading tab characters in the given string  
    //used for file upload of skills
    private int tabCount(String name){
        int count = 0;
        while(name.charAt(count) == '\t')
            count++;
        return count;
    }
    //iteratively adds all uploaded skills into the list of skills and database
    private void addUploadedSkills(List<String> list) throws SQLException{
        int cid = -1, pid = -1, tabs = 0, level = 0;
        List<Skill> parentList = new ArrayList<Skill>();
        String item;
        //loop through each skill that was in the text file
        for(int i = 0; i < list.size(); i++){
            item = list.get(i);
            //if an empty line was read in from the text file, skip it
            if(item.isEmpty())
                continue;
            //Get tab count and then remove all tabs from current item.
            tabs = tabCount(list.get(i));
            item = item.replaceAll("\t", "");
            //If the skill is a child of the previous skill, set pid and add previous skill to parentList
            if(tabs > level){
                pid = cid;
                parentList.add(find(pid));
                level++;
            //If the skill has less tabs than the previous skill, remove skills from parentList and set pid accordingly
            }else if(tabs < level){
                while(level > tabs){
                    parentList.remove(level - 1);
                    level--;
                }
                if(parentList.isEmpty())
                    pid = -1;
                else
                    pid = parentList.get(parentList.size() - 1).getSkillID();
            }
            if(parentList.isEmpty())
                cid = createSkill(item, pid, settings.getCurrentClassID(), settings.getCurrentMaxOutcome());
            else
                cid = parentList.get(parentList.size() - 1).createSkill(item, pid, settings.getCurrentClassID(), settings.getCurrentMaxOutcome());
        }
    }
    //Checks input file for formatting errors
    private boolean checkFile(List<String> list){
        int startTabs = tabCount(list.get(0)), prevTabs = startTabs, tabs = 0;
        List<String> allSkills = this.getAllSkillNames();
        List<String> newSkills = new ArrayList<String>();
        for(String item : list){
        	if(item.isEmpty())
        		continue;
            tabs = tabCount(item);
            item = item.replaceAll("\t", "");
            //Make sure that the skills being added don't already exist
            if(!(allSkills.isEmpty()) && allSkills.contains(item)){
                Dialogs.showErrorDialog(new Stage(), "One or more skills in the file being added already exists!", "Skill Already Exists!", "Upload File Error");
                return false;
            }
            //Make sure that there are no duplicate skills in the file
            if(!(newSkills.isEmpty()) && newSkills.contains(item)){
                Dialogs.showErrorDialog(new Stage(), "There is a duplicate skill within your text file!", "Duplicate Skill!", "Upload File Error");
                return false;
            }
            //Make sure that the current tab count is less than 1 more of the previous tab count and greater than the starting tab count
            if(tabs > prevTabs + 1 || tabs < startTabs){
                Dialogs.showErrorDialog(new Stage(), "There is a formatting error in your file of skills!  Please make sure that all child skills are directly below their parent and contain exactly one more preceding tab than their parent.", "Formatting Error!", "Upload File Error");
                return false;
            }
            newSkills.add(item);
            prevTabs = tabs;
        }
        return true;
    }
    
    //allows the user to select a file of skills to upload.  after adding to the skill list, adds to database
    public void uploadSkills() throws SQLException{
        File file = null;
        Scanner scan;
        List<String> tempList = new ArrayList<String>();
        //Set up file chooser (title, initial directory, and extension filter)
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Open Skills File");
        fileChooser.setInitialDirectory(new File(settings.getWorkingDirectory()));
        fileChooser.getExtensionFilters().addAll(new FileChooser.ExtensionFilter("text", "*.txt"));
        file = fileChooser.showOpenDialog(new Stage());
        if(file != null){
	        try{
	            //open file, read in all skills, and store in tempList
	            scan = new Scanner(file);
	            while (scan.hasNextLine()){
	                tempList.add(scan.nextLine());
	            }
	            if(checkFile(tempList))
	                this.addUploadedSkills(tempList);
	        }catch(FileNotFoundException e){
	            //e.printStackTrace();
	        }
        }
    }  
    //Private function that sets up the items in a treeview. Called from reloadTree
    private void resetTree(TreeItem<String> tree, List<Skill> list){
        TreeItem<String> item;
        if(list == null)
            return;
        //loop through list of items and add them to the tree
        for(int i = 0; i < list.size(); i++){
            item = new TreeItem<String>(list.get(i).getName());
            tree.getChildren().add(item);
            //if item has children, recurse down
            if(list.get(i).getSkills() != null){
                resetTree(item, list.get(i).getSkills());
            }
        }
    }
    //Function that reloads the tree after its been updated.  Calls recursive function resetTree to set up items.
    public ObservableList<String> reloadTree(TreeView<String> view){
        ObservableList<String> list;
        //clear the tree
        view.getRoot().getChildren().clear();
        resetTree(view.getRoot(), this.getSkills());
        list = this.getAllSkillNames();
        return list;
    }
}
