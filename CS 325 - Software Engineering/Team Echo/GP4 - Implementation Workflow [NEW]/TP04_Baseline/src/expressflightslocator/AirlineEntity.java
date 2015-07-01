/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

/**
 *
 * @author Brian
 */
 public class AirlineEntity{
        private String airlineAbbreviation;
        private double costPerMile;
        private String nameOfAirline;
        AirlineEntity(){
            
        }
        AirlineEntity(String airlineAbbreviation,double costPerMile, String nameOfAirline ){
            this.airlineAbbreviation=airlineAbbreviation;
            this.costPerMile=costPerMile;
            this.nameOfAirline=nameOfAirline;
        }

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
       
    }
