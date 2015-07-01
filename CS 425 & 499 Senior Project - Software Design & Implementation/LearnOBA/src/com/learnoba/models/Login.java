package com.learnoba.models;

import java.sql.SQLException;

import com.database.DatabaseFacade;
import com.learnoba.AbstractModel;
import com.learnoba.UserSettings;
import com.learnoba.login.LoginStatus;
import com.learnoba.tab.TabController;
import com.learnoba.tab.TabView;

/**
 * Login Class This is the model that holds on to the values entered in the Login Screen by the
 * User. It is responsible for the validation of the user name and password. It extends
 * functionality from the AbstractModel Class. user name holds user name info password holds
 * password info isLogin is true for Login mode or false if it is in register mode facade is the
 * DatabaseFacade that allows us to generate queries on the database
 */
public class Login extends AbstractModel {
	private String username;
	private String password;
	private boolean isLogin;
    private DatabaseFacade facade;
    private UserSettings userSettings;
	
    /**
     * Login Constructor Responsible for defaulting isLogin to true and getting and instance of the
     * database facade.
     * 
     * @throws SQLException
     */
    public Login() throws SQLException {
	    isLogin = true;
        facade = DatabaseFacade.getInstance();
        userSettings = UserSettings.getInstance();
	}

    /**
     * Getters and Setters
     */
	public String getUsername(){
		return username;
	}
	public void setUsername(String user){
		this.username=user;
	}
	public String getPassword(){
		return password;
	}
	public void setPassword(String pass){
		this.password=pass;
	}

	public boolean isLogin(){
	    return isLogin;
	}

    /**
     * Verify Text is used not to simply verify that the user entered something into the fields but
     * this is open to further requirements if the specifications ever become updated.
     * 
     * @param username
     * @param password
     * @param showDialog
     * @return
     */
    private boolean verifyText(String username, String password) {
        if (!(username.length() == 0) && !(password.length() == 0)) {
            return true;
        }
        return false;
    }


    /**
     * Verify User This method first determines if the login screen is in registration mode or login
     * mode. It then calls verifyText to make sure the information entered are valid entries.
     * Finally either validateUser(Register) checks if the user name is taken and if it hasn't
     * facade.getInsert().insertUser is called and the user is registered is called. Otherwise
     * validatePassword(Login) is called to verify the user name and password combination. If they
     * exist then the user will be allowed to log in and that user's information will be kept in the
     * login model during the time the user is logged in.
     * 
     * @param username
     * @param password
     * @param showDialog
     * @return
     * @throws SQLException
     */
    public LoginStatus verifyUser(User user) throws SQLException
    {
        
        if (!verifyText(user.getUserName(), user.getPassword())) {
            return LoginStatus.INVALID_INPUT;
        }

        if (isLogin) {
            if (facade.getSelect().validatePassword(user.getUserName(), user.getPassword())) {
                setUsername(user.getUserName());
                userSettings.setCurrentUserID(facade.getSelect().getUserID(user.getUserName()));
            	return LoginStatus.SUCCESSFUL_LOGIN;
            }

            return LoginStatus.INVALID_PASSWORD;

        } else { // isRegister

            if (facade.getSelect().validateUser(user.getUserName())) {
                userSettings.setCurrentUserID(facade.getInsert().insertUser(user));
                return LoginStatus.SUCCESSFUL_REGISTER;
            }

            return LoginStatus.USERNAME_IN_USE;
        }
    }


    /**
     * Display Tab Controller Responsible for generating the TabController view once verification is
     * successful TabController contains all the views of the main controller.
     */
    public void displayTabController() {
        TabView tab = new TabView("Tab.fxml", "Main Screen");
        TabController tabController = (TabController) tab.getController();
        tabController.updateUserName(getUsername());
        tabController.getPrimaryView().show();
    }

    /**
     * Toggle screen is used to go back and forth between the Login Screen to the RegisterScreen
     */
    public void toggleScreen() {
        isLogin = isLogin ? false : true;
    }
}
