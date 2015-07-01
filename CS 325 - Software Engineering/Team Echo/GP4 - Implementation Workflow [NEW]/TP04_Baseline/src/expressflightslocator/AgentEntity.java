/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class AgentEntity extends PersonEntity{
    
    private String agentID;
    private String password;
    private boolean aManager;
    
    AgentEntity(){
        
    }
    
    AgentEntity(String agentID, String password, boolean aManager, String name, String address, String agentEmailAddress, String agentPhoneNumber){
        this.agentID=agentID;
        this.address=address;
        this.aManager=aManager;
        this.emailAddress=agentEmailAddress;
        this.name=name;
        this.password=password;
        this.phoneNumber=agentPhoneNumber;
    }

    /**
     * @return the agentID
     */
    public String getAgentID() {
        return agentID;
    }

    /**
     * @param agentID the agentID to set
     */
    public void setAgentID(String agentID) {
        this.agentID = agentID;
    }

    /**
     * @return the password
     */
    public String getPassword() {
        return password;
    }

    /**
     * @param password the password to set
     */
    public void setPassword(String password) {
        this.password = password;
    }

    /**
     * @return the aManager
     */
    public boolean isaManager() {
        return aManager;
    }

    /**
     * @param aManager the aManager to set
     */
    public void setaManager(boolean aManager) {
        this.aManager = aManager;
    }

}
