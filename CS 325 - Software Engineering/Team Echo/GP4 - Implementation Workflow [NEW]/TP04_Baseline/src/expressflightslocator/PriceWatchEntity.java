/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;
import java.util.ArrayList;
import java.util.GregorianCalendar;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class PriceWatchEntity {
    private double priceWatchPrice;
    private int customerID;
    private int itineraryID;
    private boolean isMet;
    private boolean sendNotifyText;
    private GregorianCalendar priceWatchExpiration;
    private ArrayList<ArrayList<FlightEntity>> metFlights = new ArrayList<>();
    private final static long THIRTY_DAYS_IN_MILLIS =  (60 * 60000 * 24 * 30);
    /**
     * @return the priceWatchPrice
     */
    public double getPriceWatchPrice() {
        return priceWatchPrice;
    }

    /**
     * @param priceWatchPrice the priceWatchPrice to set
     */
    public void setPriceWatchPrice(double priceWatchPrice) {
        this.priceWatchPrice = priceWatchPrice;
    }

    /**
     * @return the sendNotifyText
     */
    public boolean isSendNotifyText() {
        return sendNotifyText;
    }

    /**
     * @param sendNotifyText the sendNotifyText to set
     */
    public void setSendNotifyText(boolean sendNotifyText) {
        this.sendNotifyText = sendNotifyText;
    }

    /**
     * @return the priceWatchExpiration
     */
    public GregorianCalendar getPriceWatchExpiration() {
        return priceWatchExpiration;
    }

    /**
     * @param priceWatchExpiration the priceWatchExpiration to set
     */
    public void setPriceWatchExpiration() {
        this.priceWatchExpiration = new GregorianCalendar();
        this.priceWatchExpiration.setTimeInMillis((long)(new GregorianCalendar()).getTimeInMillis() +  THIRTY_DAYS_IN_MILLIS);
    }

    /**
     * @return the customerID
     */
    public int getCustomerID() {
        return customerID;
    }

    /**
     * @param customerID the customerID to set
     */
    public void setCustomerID(int customerID) {
        this.customerID = customerID;
    }

    /**
     * @return the itineraryID
     */
    public int getItineraryID() {
        return itineraryID;
    }

    /**
     * @param itineraryID the itineraryID to set
     */
    public void setItineraryID(int itineraryID) {
        this.itineraryID = itineraryID;
    }

    /**
     * @return the isMet
     */
    public boolean isIsMet() {
        return isMet;
    }

    /**
     * @param isMet the isMet to set
     */
    public void setIsMet(boolean isMet) {
        this.isMet = isMet;
    }

    /**
     * @return the metFlights
     */
    public ArrayList<ArrayList<FlightEntity>> getMetFlights() {
        return metFlights;
    }

    /**
     * @param metFlights the metFlights to set
     */
    public void setMetFlights(ArrayList<ArrayList<FlightEntity>> metFlights) {
        this.metFlights = metFlights;
    }

  
    
}
