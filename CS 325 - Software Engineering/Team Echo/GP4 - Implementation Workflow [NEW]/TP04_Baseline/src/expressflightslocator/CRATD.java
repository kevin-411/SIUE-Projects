/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFileChooser;
import javax.swing.JPanel;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class CRATD {
    private static CRATD instance = null;
    private static EFLDatabase eflDatabase;
    private static ArrayList<FlightEntity> flights;
    private static  String currentFile;
    
    private void CRATD(){
            //left blank by design
    }
    public static CRATD getInstance(){
        if(instance == null){
            initialize();
          instance = new CRATD();
        }
        return instance;
    }
    private static void initialize(){
        eflDatabase = EFLDatabase.getInstance();

        //flights = new ArrayList<>();
        //flights.add(new FlightEntity());
        currentFile="";
    }
    public void getCRATDUpdates(){
        getCRATDUpdates("");
    }
    public void getCRATDUpdates(String path){
        //Can only be performed by a manager
        //Will essentially update the system with the most current info.
        //How will this work?
        JFileChooser chooser = new JFileChooser();
            //TODO FileNameExtensionFilter filter = new FileNameExtensionFilter(".cbk Files", "cbk");
            //chooser.setFileFilter(filter);
        int returnVal=0;
        currentFile=path;
        if(path.equals("")){
            returnVal = chooser.showOpenDialog(new JPanel());
            currentFile=chooser.getSelectedFile().getPath();
        }
            if(returnVal == JFileChooser.APPROVE_OPTION || path.equals("")) {
                try {
                        LoadTransactions(new BufferedReader(new FileReader(new File(currentFile))));
                    } catch (IOException ex) {
                        Logger.getLogger(CRATD.class.getName()).log(Level.SEVERE, null, ex);
                    }
            }
    }
    
    /**LoadTransactions
     * 
     * @param load file handle 
     * @throws IOException 
     */
    private void LoadTransactions(BufferedReader load) throws IOException{
        
        String temp = load.readLine();
        int section=0;
        
        while(!temp.equals("")) {
            switch (temp.substring(0, 1)) {
                case "#":
                    break;
                case "!":
                    section++;
                    break;
                default:
                    switch(section){
                        case 0:
                           EFLDatabase.getAirlines().add(new AirlineEntity(temp.substring(0, 2),Double.parseDouble(temp.substring(3, 8).replaceAll("\\s","")), temp.substring(9)));
                            break;
                        case 1:
                            if(eflDatabase.getAirports()==null){
                                eflDatabase.setAirports(new ArrayList<AirportEntity>());
                            }
                            eflDatabase.getAirports().add(new AirportEntity(temp.substring(0,3),Integer.parseInt(temp.substring(4, 7)), Integer.parseInt(temp.substring(10, 13).replaceAll("\\s","")), Integer.parseInt(temp.substring(14, 17).replaceAll("\\s","")), Double.parseDouble(temp.substring(18,23)),temp.substring(24)));
                            
                            break;
                        case 2:
                            EFLDatabase.getRoutes().add(new RouteEntity(temp.substring(0,3), temp.substring(4,7)));
                            break;
                        case 3:
                            ArrayList<FlightEntity> flight = computeFlights(temp);
                            eflDatabase.getFlights().add(flight);
                            break;
                        default:
                            
                    }
                    break;
            }
            temp = load.readLine();
        }//outer while 
        mergeLegsIntoMultiLegFlights();
    }
      private void mergeLegsIntoMultiLegFlights(){
       
        for(ArrayList<FlightEntity> currentMultiLeg: eflDatabase.getFlights()){
            if(currentMultiLeg.get(0).getStopsDuringFlight()> 0 ){
                for(ArrayList<FlightEntity> leg: eflDatabase.getFlights()){
                    if(currentMultiLeg.get(0).getAirlineAbbreviation().equals(leg.get(0).getAirlineAbbreviation()) && currentMultiLeg.get(0).getFlightNumber()==leg.get(0).getFlightNumber() && !currentMultiLeg.equals(leg)){
                    currentMultiLeg.add(leg.get(0));
                    }
                }
            }
        }
    }
    private ArrayList<FlightEntity> computeFlights(String flight){
        boolean departPM=false;
        flights = new ArrayList<>();
        flights.add(new FlightEntity());
        String airlineAbbreviation =  flight.substring(0, 2);
        int flightNumber = Integer.parseInt(flight.substring(2, 6).replaceAll("\\s",""));
        String nameOfAirline = eflDatabase.getAirline(airlineAbbreviation).getNameOfAirline();
        double costPerMile = eflDatabase.getAirline(airlineAbbreviation).getCostPerMile();
        String originAirport = flight.substring(8, 11);
        GregorianCalendar departureTime = new GregorianCalendar();
        departureTime.set(Calendar.HOUR_OF_DAY, Integer.parseInt(flight.substring(12, 14).replaceAll("\\s","")));
        departureTime.set(Calendar.MINUTE, Integer.parseInt(flight.substring(14, 16)));
        switch(flight.substring(16, 17)){
            case "A":
                      int hour = (Integer.parseInt(flight.substring(12, 14).replaceAll("\\s",""))==12)?0:
                        Integer.parseInt(flight.substring(12, 14).replaceAll("\\s",""));
            departureTime.set(Calendar.HOUR_OF_DAY, hour);
                break;
            case "P":
                departPM=true;
            departureTime.set(Calendar.HOUR_OF_DAY, Integer.parseInt(flight.substring(12, 14).replaceAll("\\s",""))+12);
        }
        String destinationAirport = flight.substring(19, 22);
        
        GregorianCalendar arrivalTime = new GregorianCalendar();
        
        arrivalTime.set(Calendar.MINUTE, Integer.parseInt(flight.substring(25, 27)));
        switch(flight.substring(27, 28)){
            case "A":
                int hour = (Integer.parseInt(flight.substring(23, 25).replaceAll("\\s",""))==12)?0:
                        Integer.parseInt(flight.substring(23, 25).replaceAll("\\s",""));
                
                arrivalTime.set(Calendar.HOUR_OF_DAY, hour);
                if(departPM){
                    arrivalTime.set(Calendar.DAY_OF_MONTH, arrivalTime.get(Calendar.DAY_OF_MONTH) + 1);
                }

                break;
            case "P":
            arrivalTime.set(Calendar.HOUR_OF_DAY, Integer.parseInt(flight.substring(23, 25).replaceAll("\\s","")) + 12);

        }
        int stopsDuringFlight = Integer.parseInt(flight.substring(30, 31));
        if(stopsDuringFlight > 5){
            stopsDuringFlight=5;
        }
        
        
        flights.get(0).setAirlineAbbreviation(airlineAbbreviation);
        flights.get(0).setArrivalTime(arrivalTime);
        flights.get(0).setCostPerMile(costPerMile);
        flights.get(0).setDepartureTime(departureTime);
        flights.get(0).setDestinationAirport(destinationAirport);
        flights.get(0).setFlightNumber(flightNumber);
        flights.get(0).setNameOfAirline(nameOfAirline);
        flights.get(0).setOriginAirport(originAirport);
        flights.get(0).setStopsDuringFlight(stopsDuringFlight);
        flights.get(0).setTotalCost(0.0);
        flights.get(0).setTravelTime(0.0);
        
        return flights;
    }

}
