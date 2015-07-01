/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

import java.util.ArrayList;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class EFLDatabase {
    private static double fee;
    private static ArrayList<AirportEntity> airports;
    private static ArrayList<ArrayList<FlightEntity>> flights;
    private static ArrayList<AgentEntity> managerEntities;    //A manager is a specialized version of an agent and has more abilities.
    private static ArrayList<AgentEntity> agentEntities;
    private static ArrayList<CustomerEntity> customerEntities;
    private static ArrayList<AirlineEntity> airlines;
    private static ArrayList<RouteEntity> routes;
    private static ArrayList<PriceWatchEntity> priceWatches;
    private static Report report;
    
    
    
    private static EFLDatabase instance = null;
    
    private static void EFLDatabase(){
    }
    public static EFLDatabase getInstance(){
        if(instance == null){
            initialize();
            instance = new EFLDatabase();
        }
        return instance;
    }
    private static void initialize(){
        fee=50.0;
        airports = new ArrayList<>();
        flights = new ArrayList<>();
        managerEntities = new ArrayList<>();    //A manager is a specialized version of an agent and has more abilities.
        agentEntities = new ArrayList<>();
        customerEntities = new ArrayList<>();
        airlines = new ArrayList<>();
        routes = new ArrayList<>();
        priceWatches = new ArrayList<>();
        setReport(new Report());


    }

    /**
     * @return the priceWatches
     */
    public static ArrayList<PriceWatchEntity> getPriceWatches() {
        return priceWatches;
    }

    /**
     * @return the report
     */
    public static Report getReport() {
        return report;
    }

    /**
     * @param aReport the report to set
     */
    public static void setReport(Report aReport) {
        report = aReport;
    }
    public AirlineEntity getAirline(String abbreviation){
            for (AirlineEntity airline: getAirlines()){
                if (airline.getAirlineAbbreviation().equals(abbreviation)){
                    return airline;
                }
            }
            return null;
            
        }
    /**
     * @return the airlines
     */
    public static ArrayList<AirlineEntity> getAirlines() {
        return airlines;
    }

    /**
     * @param aAirlines the airlines to set
     */
    public static void setAirlines(ArrayList<AirlineEntity> aAirlines) {
        airlines = aAirlines;
    }

    /**
     * @return the routes
     */
    public static ArrayList<RouteEntity> getRoutes() {
        return routes;
    }

    /**
     * @param aRoutes the routes to set
     */
    public static void setRoutes(ArrayList<RouteEntity> aRoutes) {
        routes = aRoutes;
    }
public AirportEntity getAirport(String key){
    if(key.length()==3){
            for (AirportEntity airport: getAirports()){
                if (airport.getAirportAbbreviation().equals(key)){
                    return airport;
                }
            }
    }
    for (AirportEntity airport: getAirports()){
                if (airport.getNameOfAirport().equals(key)){
                    return airport;
                }
            }
    
            return null;
            
        }
    /**
     * @return the airports
     */
    public ArrayList<AirportEntity> getAirports() {
        return airports;
    }

    /**
     * @param airports the airports to set
     */
    public void setAirports(ArrayList<AirportEntity> airports) {
        this.airports = airports;
    }

    /**
     * @return the flights
     */
    public ArrayList<ArrayList<FlightEntity>> getFlights() {
        return flights;
    }

    /**
     * @param flights the flights to set
     */
    public void setFlights(ArrayList<ArrayList<FlightEntity>> flights) {
        this.flights = flights;
    }

    /**
     * @return the managers
     */
    public ArrayList<AgentEntity> getManagers() {
        return managerEntities;
    }

    /**
     * @param managers the managers to set
     */
    public void setManagers(ArrayList<AgentEntity> managers) {
        this.managerEntities = managers;
    }

    /**
     * @return the agents
     */
    public ArrayList<AgentEntity> getAgents() {
        return agentEntities;
    }

    /**
     * @param agents the agents to set
     */
    public void setAgents(ArrayList<AgentEntity> agents) {
        this.agentEntities = agents;
    }

    /**
     * @return the customers
     */
    public ArrayList<CustomerEntity> getCustomers() {
        return customerEntities;
    }

    /**
     * @param customers the customers to set
     */
    public void setCustomers(ArrayList<CustomerEntity> customers) {
        this.customerEntities = customers;
    }

    /**
     * @return the fee
     */
    public double getFee() {
        return fee;
    }

    /**
     * @param fee the fee to set
     */
    public void setFee(double fee) {
        this.fee = fee;
    }
   
    

}
