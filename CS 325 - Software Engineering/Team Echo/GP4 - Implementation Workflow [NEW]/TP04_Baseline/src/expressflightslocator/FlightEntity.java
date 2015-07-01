/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;
import java.util.GregorianCalendar;
/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class FlightEntity {
    
    private String airlineAbbreviation;
    private int flightNumber;
    private String nameOfAirline;
    private double costPerMile;
    private GregorianCalendar departureTime;
    private String originAirport;
    private GregorianCalendar arrivalTime;
    private String destinationAirport;
    private int stopsDuringFlight;
    private double totalCost;
    private double travelTime;

    /**
     * @return the airlineAbbreviation
     */
    public String getAirlineAbbreviation() {
        return airlineAbbreviation;
    }

    /**
     * @param airlineAbbreviation the airlineAbbreviation to set
     */
    public void setAirlineAbbreviation(String airlineAbbreviation) {
        this.airlineAbbreviation = airlineAbbreviation;
    }

    /**
     * @return the flightNumber
     */
    public int getFlightNumber() {
        return flightNumber;
    }

    /**
     * @param flightNumber the flightNumber to set
     */
    public void setFlightNumber(int flightNumber) {
        this.flightNumber = flightNumber;
    }

    /**
     * @return the nameOfAirline
     */
    public String getNameOfAirline() {
        return nameOfAirline;
    }

    /**
     * @param nameOfAirline the nameOfAirline to set
     */
    public void setNameOfAirline(String nameOfAirline) {
        this.nameOfAirline = nameOfAirline;
    }

    /**
     * @return the costPerMile
     */
    public double getCostPerMile() {
        return costPerMile;
    }

    /**
     * @param costPerMile the costPerMile to set
     */
    public void setCostPerMile(double costPerMile) {
        this.costPerMile = costPerMile;
    }

    /**
     * @return the departureTime
     */
    public GregorianCalendar getDepartureTime() {
        return departureTime;
    }

    /**
     * @param departureTime the departureTime to set
     */
    public void setDepartureTime(GregorianCalendar departureTime) {
        this.departureTime = departureTime;
    }

    /**
     * @return the originAirport
     */
    public String getOriginAirport() {
        return originAirport;
    }

    /**
     * @param originAirport the originAirport to set
     */
    public void setOriginAirport(String originAirport) {
        this.originAirport = originAirport;
    }

    /**
     * @return the arrivalTime
     */
    public GregorianCalendar getArrivalTime() {
        return arrivalTime;
    }

    /**
     * @param arrivalTime the arrivalTime to set
     */
    public void setArrivalTime(GregorianCalendar arrivalTime) {
        this.arrivalTime = arrivalTime;
    }

    /**
     * @return the destinationAirport
     */
    public String getDestinationAirport() {
        return destinationAirport;
    }

    /**
     * @param destinationAirport the destinationAirport to set
     */
    public void setDestinationAirport(String destinationAirport) {
        this.destinationAirport = destinationAirport;
    }

    /**
     * @return the stopsDuringFlight
     */
    public int getStopsDuringFlight() {
        return stopsDuringFlight;
    }

    /**
     * @param stopsDuringFlight the stopsDuringFlight to set
     */
    public void setStopsDuringFlight(int stopsDuringFlight) {
        this.stopsDuringFlight = stopsDuringFlight;
    }

    /**
     * @return the totalCost
     */
    public double getTotalCost() {
        return totalCost;
    }

    /**
     * @param totalCost the totalCost to set
     */
    public void setTotalCost(double totalCost) {
        this.totalCost = totalCost;
    }

    /**
     * @return the travelTime
     */
    public double getTravelTime() {
        return travelTime;
    }

    /**
     * @param travelTime the travelTime to set
     */
    public void setTravelTime(double travelTime) {
        this.travelTime = travelTime;
    }
  
    
}
