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
    	settings.getInstance();
    	facade.getInstance();
        name = rootSkill;
        skillID = -1;
        parentID = 0;
        classID = settings.getCurrentClassID();
        prefilledOutcomeValue = 5;
        skills = null;
        skillNames = FXCollections.observableList(new ArrayList<String>());
        skillNames.add(rootSkill);
    }
    
    private Skill(String skill_name, int skill_id, int parent_id, int class_id, int outcome) throws SQLException{
        name = skill_name;
        skillID = skill_id;
        parentID = parent_id;
        classID = class_id;
        prefilledOutcomeValue = outcome;
        skills = null;
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
    	//System.out.println(skillId + ": " + name);
        if(skills == null)
            skills = new ArrayList<Skill>();
        if(skillNames == null)
            skillNames = FXCollections.observableList(new ArrayList<String>());
        skills.add(newSkill);
        skillNames.add(name);
        FXCollections.sort(skillNames);
        return newSkill;
    }
    //adds the given skill to the list
    private Skill addSkill(Skill newSkill){
    	//System.out.println(newSkill.getSkillID() + ": " + newSkill.getName());
		if(skills == null)
		    skills = new ArrayList<Skill>();
		if(skillNames == null)
		    skillNames = FXCollections.observableList(new ArrayList<String>());
		skills.add(newSkill);
		skillNames.add(newSkill.getName());
		FXCollections.sort(skillNames);
		return newSkill;
    }
    //inserts a skill given the skill name and its parent
    public boolean insert(String newSkill, String parent, String rootSkill) throws SQLException{
        boolean added = false;
        Skill skillObj = null, parentObj = null;
        int ID;
        //System.out.println(parent);
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
        	skillObj = new Skill(newSkill, 0, parentObj.getSkillID(), 0, this.getPrefilledOutcomeValue());
        	ID = facade.getInsert().insertSkill(skillObj);
        	skillObj.setSkillID(ID);
        	parentObj.addSkill(skillObj);
        }
        return added;
    }
    //deletes a skill if given its name
    public boolean delete(String skillName, String parentName) throws SQLException{
        Skill skill, parent;
        List<Skill> children;
        //if skill is not null, display a confirm dialog 
        if(skillName != null){
            DialogResponse response = Dialogs.showConfirmDialog(new Stage(), "Are you sure you want to delete this skill?", "Deleting " + skillName, "Delete a Skill", DialogOptions.YES_NO);
            //if the user says yes, then delete the skill and move all children up
            if(response == DialogResponse.YES){
                parent = find(parentName);
                skill = find(skillName);
                children = skill.skills;
                //if there are children, move them up to the deleted items parent
                if(children != null){
                    for(Skill item: children){
                        parent.skills.add(item);
                        item.parentID = parent.getSkillID();
                        facade.getUpdate().updateSkill(item);
                    }
                }
                parent.skills.remove(skill);
                facade.getDelete().deleteSkill(skill);
                skillNames.remove(skill.getName());
                return true;
            }
        }
        return false;
    }
    //updates the given skill with the new name and parent
    public boolean update(String skillName, String parentName, String newSkillName, String newParentName) throws SQLException{
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
    public void getAllSkills(int class_id) throws SQLException{
        ResultSet set;
        Skill temp, parent;
        LinkedList<Skill> queue = new LinkedList<Skill>();
        set = facade.getSelect().getSkillsByClass(class_id);
            while(set.next()){
            	if(set.getInt("skill_id") == -1)
            		continue;
                //if the skill's parent ID is equal to the current skill ID, add it to current skill's children
                //otherwise, find the skill with the skill's parent ID and add it to that skill. 
                //if the parent skill does not exist yet, add it to the queue.  
                if(set.getInt("parent_id") == this.getSkillID()){
                	this.addSkill(set.getString("skill_name"), set.getInt("skill_id"), set.getInt("parent_id"), set.getInt("class_id"), set.getInt("prefilled_outcome_value"));
                }else if((parent = find(set.getInt("parent_id"))) != null){
                	parent.addSkill(set.getString("skill_name"), set.getInt("skill_id"), set.getInt("parent_id"), set.getInt("class_id"), set.getInt("prefilled_outcome_value"));
                }else{
                	queue.add(parent);
                }
            }
            while(!queue.isEmpty()){
            	temp = queue.pop();
            	if((parent = find(temp.getParentID())) != null){
                	parent.addSkill(temp);
            	}else{
                	queue.add(parent);
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
            if(item.name == skillName){
                return item;
            }else{
                //if child skill list is not empty, recurse down
                if(item.skills != null){
                    skill = item.find(skillName);
                    //if skill has been found, return skill
                    if(skill != null && skill.name == skillName)
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
        if(skillNames == null)
            return false;
        return skillNames.contains(skill_name);
    }
    //returns the number of leading tab characters in the given string  
    //used for file upload of skills
    private int tabCount(String name){
        int count = 0;
        while(name.charAt(count) == '\t')
            count++;
        return count;
    }
    //recursively adds all uploaded skills into the list of skills
    private List<Skill> addUploadedSkills(List<Skill> current, List<String> list, int position, int tabCount, int offset, int pid) throws SQLException{
        int tabs, cid = -1;
        Skill newSkill = null;
        String item;
        //loop through each skill that was in the text file
        for(int i = position; i < list.size(); i++){
            item = list.get(i);
            //if an empty line was read in from the text file, skip it
            if(item.isEmpty())
                continue;
            //Get tab count and then remove all tabs from current item.
            tabs = tabCount(list.get(i));
            item = item.replaceAll("\t", "");
            //Set the tab offset if at first item.
            if(i == 0)
                offset = tabs;
            //if the skill already exists, skip it
            if(exists(item))
                continue;
            //if the tabs are less than offset, skip skill
            if(tabs < offset)
                continue;
            //if the tab count of the current item is equal to the current level tab count, create new skill and add it
            //to the database and list of skills.  if the tab count of the current item is greater than the current level tab count,
            //recurse down a level.  if the tab count of the current item is less than the current level tab count, return i.
            if(tabs == tabCount){
            	//TODO: Update new skill so that it uses the correct class id and outcome values
            	newSkill = new Skill(item, -1, pid, 1, 5);
            	find(pid).addSkill(newSkill);
 	            cid = facade.getInsert().insertSkill(newSkill);
 	            newSkill.setSkillID(cid);
            }else if(tabs > tabCount){
                current.get(current.size() - 1).setSkills(addUploadedSkills(current.get(current.size() - 1).getSkills(), list, i, tabCount+1, offset, cid));
                i = skillNames.size() - 2;
            }else if(tabs < tabCount){
                return current;
            }
        }
        return current;
    }
    //allows the user to select a file of skills to upload.  after adding to the skill list, adds to database
    public void uploadSkills() throws SQLException{
        File file = null;
        Scanner scan;
        List<String> tempList = new ArrayList<String>();
        //Set up file chooser (title, initial directory, and extension filter)
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Open Skills File");
        //TODO: Change initial directory for MAC/LINUX?
        fileChooser.setInitialDirectory(new File(System.getProperty("user.home") + "/Desktop"));
        fileChooser.getExtensionFilters().addAll(new FileChooser.ExtensionFilter("text", "*.txt"));
        file = fileChooser.showOpenDialog(new Stage());
        try{
            //open file, read in all skills, and store in tempList
            scan = new Scanner(file);
            while (scan.hasNextLine()){
                tempList.add(scan.nextLine());
            }
            skills = this.addUploadedSkills(this.skills, tempList, 0, 0, 0, -1);
            //TODO:Add all new skills to database
        }catch(FileNotFoundException e){
            e.printStackTrace();
        }
    }  
}
