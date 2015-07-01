/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package expressflightslocator;
import java.awt.List;
import java.util.ArrayList;
import java.util.GregorianCalendar;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */

public class ItineraryEntity {
    private int itineraryID;
    private String departureCity;
    private String arrivalCity;
    private GregorianCalendar departureDate;
    private GregorianCalendar returnDate;
    private int numberOfTravelers;
    private List travelerNames = new List();
    private String preference;
    private CreditCardEntity creditCard;
    private ArrayList<FlightEntity> flights;
    
    ItineraryEntity(){
        flights = new ArrayList<>();
    }
    ItineraryEntity(int itineraryID, String departureCity, String arrivalCity, GregorianCalendar departureDate,  GregorianCalendar returnDate, int numberOfTravelers, List travelerNames, String preference, CreditCardEntity creditCard, ArrayList<FlightEntity> flights){ 
    this.itineraryID = itineraryID;
    this.departureCity = departureCity;
    this.arrivalCity = arrivalCity;
    this.departureDate = departureDate;
    this.returnDate = returnDate;
    this.numberOfTravelers = numberOfTravelers;
    this.travelerNames = new List();
    this.preference = preference;
    this.creditCard = creditCard;
    this.flights = flights;
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
     * @return the departureCity
     */
    public String getDepartureCity() {
        return departureCity;
    }

    /**
     * @param departureCity the departureCity to set
     */
    public void setDepartureCity(String departureCity) {
        this.departureCity = departureCity;
    }

    /**
     * @return the arrivalCity
     */
    public String getArrivalCity() {
        return arrivalCity;
    }

    /**
     * @param arrivalCity the arrivalCity to set
     */
    public void setArrivalCity(String arrivalCity) {
        this.arrivalCity = arrivalCity;
    }

    /**
     * @return the departureDate
     */
    public GregorianCalendar getDepartureDate() {
        return departureDate;
    }

    /**
     * @param departureDate the departureDate to set
     */
    public void setDepartureDate(GregorianCalendar departureDate) {
        this.departureDate = departureDate;
    }

    /**
     * @return the returnDate
     */
    public GregorianCalendar getReturnDate() {
        return returnDate;
    }

    /**
     * @param returnDate the returnDate to set
     */
    public void setReturnDate(GregorianCalendar returnDate) {
        this.returnDate = returnDate;
    }

    /**
     * @return the numberOfTravelers
     */
    public int getNumberOfTravelers() {
        return numberOfTravelers;
    }

    /**
     * @param numberOfTravelers the numberOfTravelers to set
     */
    public void setNumberOfTravelers(int numberOfTravelers) {
        this.numberOfTravelers = numberOfTravelers;
    }

    /**
     * @return the travelerNames
     */
    public List getTravelerNames() {
        return travelerNames;
    }

    /**
     * @param travelerNames the travelerNames to set
     */
    public void setTravelerNames(List travelerNames) {
        this.travelerNames = travelerNames;
    }

    /**
     * @return the preference
     */
    public String getPreference() {
        return preference;
    }

    /**
     * @param preference the preference to set
     */
    public void setPreference(String preference) {
        this.preference = preference;
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
     * @return the flights
     */
    public ArrayList<FlightEntity> getFlights() {
        return flights;
    }

    /**
     * @param flights the flights to set
     */
    public void setFlights(ArrayList<FlightEntity> flights) {
        this.flights = flights;
    }


    
}
