/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

//import java.util.ArrayList;

import java.util.ArrayList;


/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class CustomerEntity extends PersonEntity{
    
    private String customerID;
    private CreditCardEntity creditCard;
    private double accountCredit;
    private ArrayList<ItineraryEntity> itineraries;
    private int numberFlightsReserved;
    
    CustomerEntity(){
        itineraries = new ArrayList<>();
    }
    
    CustomerEntity(String CustomerID,String name, String address, String emailAddress, String phoneNumber, CreditCardEntity creditCard){
        
    }
    //This ArrayList of integers refers to the flight numbers that a customer has reserved.
    //private ArrayList<Integer> reservedFlights;

    /**
     * @return the customerID
     */
    public String getCustomerID() {
        return customerID;
    }

    /**
     * @param customerID the customerID to set
     */
    public void setCustomerID(String customerID) {
        this.customerID = customerID;
    }

    /**
     * @return the creditCard
     */
    public CreditCardEntity getCreditCard() {
        return creditCard;
    }

    /**
     * @param creditCard the creditCard to set
     */
    public void setCreditCard(CreditCardEntity creditCard) {
        this.creditCard = creditCard;
    }  

    /**
     * @return the accountCredit
     */
    public double getAccountCredit() {
        return accountCredit;
    }

    /**
     * @param accountCredit the accountCredit to set
     */
    public void setAccountCredit(double accountCredit) {
        this.accountCredit += accountCredit;
        if(accountCredit > 50){
            accountCredit=50;
        }
    }

    /**
     * @return the itineraries
     */
    public ArrayList<ItineraryEntity> getItineraries() {
        return itineraries;
    }

    /**
     * @param itineraries the itineraries to set
     */
    public void setItineraries(ArrayList<ItineraryEntity> itineraries) {
        this.itineraries = itineraries;
    }

    /**
     * @return the numberFlightsReserved
     */
    public int getNumberFlightsReserved() {
        return numberFlightsReserved;
    }

    /**
     * @param numberFlightsReserved the numberFlightsReserved to set
     */
    public void setNumberFlightsReserved() {
        this.numberFlightsReserved +=1;
        switch(numberFlightsReserved){
            case 2:
            case 10:setAccountCredit(5); break;
        }
    }
    
}
