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
public abstract class PersonEntity {
    
    protected String name;
    protected String address;
    protected String emailAddress;
    protected String phoneNumber;
    
    public String getName(){
        return name;
    }
    
    public void setName(String name){
        this.name=name;
    }
    
    public String getAddress(){
        return address;
    }
    
    public void setAddress(String address){
        this.address=address;
    }
    public String getEmailAddress(){
        return emailAddress;
    }
    
    public void setEmailAddress(String emailAddress){
        this.emailAddress=emailAddress;
    }
    
    public String getPhoneNumber(){
        return phoneNumber;
    }
    
    public void setPhoneNumber(String phoneNumber){
        this.phoneNumber=phoneNumber;
    }
    
    
}
