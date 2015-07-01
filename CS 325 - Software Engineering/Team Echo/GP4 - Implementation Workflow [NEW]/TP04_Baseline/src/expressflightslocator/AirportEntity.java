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
public class AirportEntity {
    private String airportAbbreviation;
    private int timeZoneOffset;
    private int xCoordinate;
    private int yCoordinate;
    private double airportFee;
    private String nameOfAirport;
    
    AirportEntity(String airportAbbreviation, int timeZoneOffset, int xCoordinate, int yCoordinate, double airportFee, String nameOfAirport){
        this.airportAbbreviation=airportAbbreviation;
        this.timeZoneOffset=timeZoneOffset;
        this.nameOfAirport=nameOfAirport;
        this.xCoordinate=xCoordinate;
        this.yCoordinate=yCoordinate;
        this.airportFee=airportFee;
        this.nameOfAirport=nameOfAirport;
    }

    /**
     * @return the airportAbbreviation
     */
    public String getAirportAbbreviation() {
        return airportAbbreviation;
    }

    /**
     * @param airportAbbreviation the airportAbbreviation to set
     */
    public void setAirportAbbreviation(String airlineAbbreviation) {
        this.airportAbbreviation = airlineAbbreviation;
    }

    /**
     * @return the timeZoneOffset
     */
    public int getTimeZoneOffset() {
        return timeZoneOffset;
    }

    /**
     * @param timeZoneOffset the timeZoneOffset to set
     */
    public void setTimeZoneOffset(int timeZoneOffset) {
        this.timeZoneOffset = timeZoneOffset;
    }

    /**
     * @return the xCoordinate
     */
    public int getxCoordinate() {
        return xCoordinate;
    }

    /**
     * @param xCoordinate the xCoordinate to set
     */
    public void setxCoordinate(int xCoordinate) {
        this.xCoordinate = xCoordinate;
    }

    /**
     * @return the yCoordinate
     */
    public int getyCoordinate() {
        return yCoordinate;
    }

    /**
     * @param yCoordinate the yCoordinate to set
     */
    public void setyCoordinate(int yCoordinate) {
        this.yCoordinate = yCoordinate;
    }

    /**
     * @return the airportFee
     */
    public double getAirportFee() {
        return airportFee;
    }

    /**
     * @param airportFee the airportFee to set
     */
    public void setAirportFee(double airportFee) {
        this.airportFee = airportFee;
    }

    /**
     * @return the nameOfAirport
     */
    public String getNameOfAirport() {
        return nameOfAirport;
    }

    /**
     * @param nameOfAirport the nameOfAirport to set
     */
    public void setNameOfAirport(String nameOfAirport) {
        this.nameOfAirport = nameOfAirport;
    }
    
}
