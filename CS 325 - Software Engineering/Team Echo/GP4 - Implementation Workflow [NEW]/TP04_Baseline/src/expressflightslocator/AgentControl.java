/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

import java.awt.Dimension;
import java.awt.List;
import java.awt.Toolkit;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.HashMap;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class AgentControl {
   
   static protected AgentBorder agentBorder;
   static protected EFLDatabase eflDatabase;
   protected ArrayList<ArrayList<FlightEntity>> currentFlightsList;
   final static protected long ALLOWED_TIME_BETWEEN_FLIGHTS = (long) (45 * 60000.0);
   final static protected double HOURS_TO_MILLISECONDS = (60 * 60000.0);
   final static protected int MAX_NUM_FLIGHT_LEGS = 3;
   static protected boolean isManager;
    
    AgentControl(){
        agentBorder = new AgentBorder();
        eflDatabase = EFLDatabase.getInstance();
        currentFlightsList = new ArrayList<>();
        
        agentBorder.run();
        /**
         * Keep this method call at the end of the Constructor sets all of the Listeners for the controller and the 
         * controller needs to be fully initialized when this happens.
         */
        agentBorder.setListenersForControl(this);
    }
      
    //Accessors and Mutators//
    
    /**
     * @return the agentBorder
     */
    public AgentBorder getAgentBorder() {
        return agentBorder;
    }

    /**
     * @param agentBorder the agentBorder to set
     */
    public void setAgentBorder(AgentBorder agentBorder) {
        this.agentBorder = agentBorder;
    }

    /**
     * @return the eflDatabase
     */
    public EFLDatabase getEflDatabase() {
        return eflDatabase;
    }

    /**
     * @param eflDatabase the eflDatabase to set
     */
    public void setEFLDatabase(EFLDatabase eflDatabase) {
        this.eflDatabase = eflDatabase;
    }
    
    ////////////////////////////////////LISTENER METHODS TO CATCH BORDER ACTIONS
    public void loginButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(!LogIn(agentBorder.getAgentIDField().getText().replaceAll("\\s",""), agentBorder.getPasswordField().getText().replaceAll("\\s",""))){
            JOptionPane.showMessageDialog(null, "Incorrect password. Please try again.", "Incorrect Password!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        agentBorder.LogIn();
    }
    public void createCustomerButtonActionPerformed(java.awt.event.ActionEvent evt) {
        boolean openLocationInCustomerArray=false;

        if(verifyFieldsFor("Customer")){
            Calendar cal = agentBorder.getCardExpirationDateChooser().getCalendar();
            GregorianCalendar expriationDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
            CreditCardEntity customerCard = new CreditCardEntity(
                agentBorder.getCardHolderNameField().getText(), 
                agentBorder.getCardTypeComboBox().getModel().getSelectedItem().toString(), 
                agentBorder.getCardNumberField().getText(),expriationDate, 
                agentBorder.getCsvNumberField().getText(),
                agentBorder.getBillingAddressField().getText());
   
                CustomerEntity newCustomer = CreateCustomerAccount(null,
                agentBorder.getFirstNameField().getText() + " " + agentBorder.getLastNameField().getText(), 
                agentBorder.getAddressField().getText(), 
                agentBorder.getEmailAddressField().getText(), 
                agentBorder.getPhoneNumberField().getText(),customerCard);
                    
                for(CustomerEntity customer: eflDatabase.getCustomers()){
                    if(customer.getName().equals("")){
                        newCustomer.setCustomerID(customer.getCustomerID());
                        eflDatabase.getCustomers().set(Integer.parseInt(customer.getCustomerID()), newCustomer);
                        agentBorder.getCustomerIDField().setText(String.valueOf(customer.getCustomerID()));
                        agentBorder.getCustomerIDField1().setText(String.valueOf(customer.getCustomerID()));
                        agentBorder.getCustomerIDField3().setText(String.valueOf(customer.getCustomerID()));
                        if(!eflDatabase.getReport().getCustomersServiced().contains(Integer.parseInt(customer.getCustomerID()))){
                            eflDatabase.getReport().getCustomersServiced().add(Integer.parseInt(customer.getCustomerID()));
                        }
                        openLocationInCustomerArray=true;
                        break;
                    }
                }
                
                if(!openLocationInCustomerArray){
                    agentBorder.getCustomerIDField().setText(String.valueOf(eflDatabase.getCustomers().size()));
                    agentBorder.getCustomerIDField1().setText(String.valueOf(eflDatabase.getCustomers().size()));
                    agentBorder.getCustomerIDField3().setText(String.valueOf(eflDatabase.getCustomers().size()));
                    newCustomer.setCustomerID(String.valueOf(eflDatabase.getCustomers().size()));
                    if(!eflDatabase.getReport().getCustomersServiced().contains(eflDatabase.getCustomers().size())){
                            eflDatabase.getReport().getCustomersServiced().add(eflDatabase.getCustomers().size());
                        }
                    eflDatabase.getCustomers().add(newCustomer);
                }
        
            JOptionPane.showMessageDialog(null, "Successful Creation of Customer Account!!", "Customer Account Creation!", JOptionPane.INFORMATION_MESSAGE);
            eflDatabase.getReport().setNumberOfNewCustomers(eflDatabase.getReport().getNumberOfNewCustomers() + 1);
            clearItineraryButtonActionPerformed(evt);
            if(!agentBorder.getCreateItineraryButton().isEnabled()){
                changeEnabledFor("Itinerary");
            }
            changeEnabledFor("Customer");
        }//end verify if
    }

    public void modifyCustomerButtonActionPerformed(java.awt.event.ActionEvent evt) {
        
      if(verifyFieldsFor("Customer")){
        Calendar cal = agentBorder.getCardExpirationDateChooser().getCalendar();
        GregorianCalendar expriationDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
        CreditCardEntity customerCard = new CreditCardEntity(
                agentBorder.getCardHolderNameField().getText(), 
                agentBorder.getCardTypeComboBox().getModel().getSelectedItem().toString(), 
                agentBorder.getCardNumberField().getText(),expriationDate, 
                agentBorder.getCsvNumberField().getText(),
                agentBorder.getBillingAddressField().getText());
   
                CustomerEntity newCustomer = UpdateCustomer(
                agentBorder.getCustomerIDField().getText(),
                agentBorder.getFirstNameField().getText() + " " + agentBorder.getLastNameField().getText(), 
                agentBorder.getAddressField().getText(), 
                agentBorder.getEmailAddressField().getText(), 
                agentBorder.getPhoneNumberField().getText(),customerCard);
                
                JOptionPane.showMessageDialog(null, "Successful Customer Account Update!!", "Customer Account Updated!", JOptionPane.INFORMATION_MESSAGE);
      }
    }
    public void deleteCustomerButtonActionPerformed(java.awt.event.ActionEvent evt) {
        //Logical Delete so the customers will not lose their customer ID the old customerIDs will be recycled
       eflDatabase.getCustomers().get(Integer.parseInt(agentBorder.getCustomerIDField().getText())).setName("");
       eflDatabase.getCustomers().get(Integer.parseInt(agentBorder.getCustomerIDField().getText())).setPhoneNumber("");
       clearCustomerButtonActionPerformed(evt);
       JOptionPane.showMessageDialog(null, "Successful Deleted Customer Account!!", "Customer Account Deleted!", JOptionPane.INFORMATION_MESSAGE);
      clearItineraryButtonActionPerformed(evt);
      if(!agentBorder.getCreateItineraryButton().isEnabled()){
                changeEnabledFor("Itinerary");
            }
    }
    public void clearCustomerButtonActionPerformed(java.awt.event.ActionEvent evt) {
        CustomerEntity nullCustomer = 
                CreateCustomerAccount(null,null,null,null,null,new 
                CreditCardEntity(null, null,null,null, null, null));
        UpdateCustomerFields(nullCustomer);
        agentBorder.getCustomerIDField().setText("");
        agentBorder.getCustomerIDField1().setText("");
        agentBorder.getCustomerIDField3().setText("");
        changeEnabledFor("Customer");
        if(!agentBorder.getCreateItineraryButton().isEnabled()){
            clearItineraryButtonActionPerformed(evt);
            changeEnabledFor("Itinerary");
        }
    }
    public void customerSearchButtonActionPerformed(java.awt.event.ActionEvent evt) {
        int customerID = CustomerLookUp(agentBorder.getCustomerSearchField().getText());
        if(customerID==-1){
            JOptionPane.showMessageDialog(null, "Invalid Customer Account!! Customer Name or Telephone number doesn't exist!!", "Failed Account Retrieval!!", JOptionPane.ERROR_MESSAGE);
        }else{
            if(!eflDatabase.getReport().getCustomersServiced().contains(customerID)){
                eflDatabase.getReport().getCustomersServiced().add(customerID);
            }
            agentBorder.getCustomerIDField().setText(String.valueOf(customerID));
            agentBorder.getCustomerIDField1().setText(String.valueOf(customerID));
            agentBorder.getCustomerIDField3().setText(String.valueOf(customerID));
            UpdateCustomerFields(eflDatabase.getCustomers().get(customerID));
        
            if(agentBorder.getCreateCustomerButton().isEnabled()){
                changeEnabledFor("Customer");
            }
            agentBorder.getCustomerSearchField().setText(null);
            clearItineraryButtonActionPerformed(evt);
            if(!agentBorder.getCreateItineraryButton().isEnabled()){
                changeEnabledFor("Itinerary");
            }
            agentBorder.getManageFlightsButton().setEnabled(false);
        }
    }
    public void itemStateChangedForDepartureCity(java.awt.event.ItemEvent evt) {
        agentBorder.getArrivalCityComboBox().removeAllItems();
        for (RouteEntity route : eflDatabase.getRoutes()) {
            if(eflDatabase.getAirport(route.source).getNameOfAirport()==agentBorder.getDepartureCityComboBox().getSelectedItem()){
                agentBorder.getArrivalCityComboBox().addItem(eflDatabase.getAirport(route.destination).getNameOfAirport());
            }
        }
    }
    public void createItineraryButtonActionPerformed(java.awt.event.ActionEvent evt) {
        boolean openLocationInItineraryArray=false;
        int itineraryIndex=0;
        if(verifyFieldsFor("Itinerary")){
            Calendar cal = agentBorder.getDepartureDateChooser().getCalendar();
            GregorianCalendar departureDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
                     cal = agentBorder.getArrivalDateChooser().getCalendar();
            GregorianCalendar returnDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
            String preference = (agentBorder.getCheapestFareRadioButton().isSelected()? preference = "Cheapest Fare": 
                                 agentBorder.getShortestNumberOfFlightsRadioButton().isSelected()? preference = "Shortest Number Of Flights":
                                 agentBorder.getShortestTimeRadioButton().isSelected()? preference = "Shortest Time": null);
            
            ItineraryEntity newItinerary = CreateNewItinerary(agentBorder.getCustomerIDField1().getText(), 
                     agentBorder.getDepartureCityComboBox().getSelectedItem().toString(), 
                     agentBorder.getArrivalCityComboBox().getSelectedItem().toString(), departureDate
                     ,returnDate,preference);
            
            cal = agentBorder.getCardExpirationDateChooser1().getCalendar();
            GregorianCalendar expriationDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
            CreditCardEntity itineraryCard = new CreditCardEntity(
                agentBorder.getCardHolderNameField1().getText(), 
                agentBorder.getCardTypeComboBox1().getModel().getSelectedItem().toString(), 
                agentBorder.getCardNumberField1().getText(),expriationDate, 
                agentBorder.getCsvNumberField1().getText(),
                agentBorder.getBillingAddressField1().getText());
            
            newItinerary.setCreditCard(itineraryCard);
            
            for(ItineraryEntity itinerary: eflDatabase.getCustomers().get( Integer.parseInt(agentBorder.getCustomerIDField1().getText()))
                    .getItineraries()){
                    if(itinerary.getItineraryID()==-1){
                        newItinerary.setItineraryID(itineraryIndex);
                        eflDatabase.getCustomers().get( Integer.parseInt(
                                agentBorder.getCustomerIDField1().getText())).getItineraries().set(itineraryIndex, newItinerary);
                        openLocationInItineraryArray=true;
                        break;
                    }
                    itineraryIndex++;
                }
            if(!openLocationInItineraryArray){
                eflDatabase.getCustomers().get( Integer.parseInt(agentBorder.getCustomerIDField1().getText()))
                .getItineraries().add(newItinerary);
            }

            UpdateItineraryFields(newItinerary);
            changeEnabledFor("Itinerary");
            JOptionPane.showMessageDialog(null, "Successful Creation of Itinerary!!", "Itinerary Creation!", JOptionPane.INFORMATION_MESSAGE);
        }
    }
    public void modifyItineraryButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(verifyFieldsFor("Itinerary")){
            
            Calendar cal = agentBorder.getDepartureDateChooser().getCalendar();
            GregorianCalendar departureDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
            
                     cal = agentBorder.getArrivalDateChooser().getCalendar();
            GregorianCalendar returnDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
            
            String preference = (agentBorder.getCheapestFareRadioButton().isSelected()? preference = "Cheapest Fare": 
                                 agentBorder.getShortestNumberOfFlightsRadioButton().isSelected()? preference = "Shortest Number Of Flights":              agentBorder.getShortestTimeRadioButton().isSelected()? preference = "Shortest Time": null);

            ItineraryEntity itinerary = new ItineraryEntity(); 
            
            itinerary.setDepartureCity(agentBorder.getDepartureCityComboBox().getSelectedItem().toString()); 
            itinerary.setArrivalCity(agentBorder.getArrivalCityComboBox().getSelectedItem().toString());
            itinerary.setDepartureDate(departureDate);
            itinerary.setReturnDate(returnDate);
            itinerary.setPreference(preference);
            for(String string :agentBorder.getNamesOfTravelersList().getItems()){
            itinerary.getTravelerNames().add(string);
            }
            itinerary.setNumberOfTravelers(Integer.parseInt(agentBorder.getNumberOfTravelersField().getText()));
            
            cal = agentBorder.getCardExpirationDateChooser1().getCalendar();
            GregorianCalendar expriationDate = new GregorianCalendar(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH), cal.get(Calendar.DAY_OF_MONTH));
            CreditCardEntity itineraryCard = new CreditCardEntity(
                agentBorder.getCardHolderNameField1().getText(), 
                agentBorder.getCardTypeComboBox1().getModel().getSelectedItem().toString(), 
                agentBorder.getCardNumberField1().getText(),expriationDate, 
                agentBorder.getCsvNumberField1().getText(),
                agentBorder.getBillingAddressField1().getText());
            
            itinerary.setCreditCard(itineraryCard);
            
            eflDatabase.getCustomers().get(Integer.parseInt(agentBorder.getCustomerIDField1().getText())).getItineraries().set(Integer.parseInt(agentBorder.getItineraryIDField().getText()), itinerary);
 
            UpdateItineraryFields(itinerary);
             JOptionPane.showMessageDialog(null, "Successful Itinerary Update!!", "Itinerary Updated!", JOptionPane.INFORMATION_MESSAGE);
        }
    }
    public void deleteItineraryButtonActionPerformed(java.awt.event.ActionEvent evt) {
        int itineraryIndex = Integer.parseInt(agentBorder.getItineraryIDField().getText());
        //LAZY DELETE TO KEEP THE SAME ITINERARY NUMBER
       eflDatabase.getCustomers().get(Integer.parseInt(
               agentBorder.getCustomerIDField1().getText())).getItineraries().get(itineraryIndex).setItineraryID(-1);
       clearItineraryButtonActionPerformed(evt);
       JOptionPane.showMessageDialog(null, "Successful Deleted Itinerary!!", "Itinerary Deleted!", JOptionPane.INFORMATION_MESSAGE);
    }
    public void clearItineraryButtonActionPerformed(java.awt.event.ActionEvent evt) {
       ItineraryEntity nullItinerary = 
                CreateNewItinerary(null,null,null,null,null,null);
       nullItinerary.setCreditCard(new CreditCardEntity(null, null,null,null, null, null));
        UpdateItineraryFields(nullItinerary);
        agentBorder.getNamesOfTravelersField().setText("");
        agentBorder.getNumberOfTravelersField().setText("0");
        agentBorder.getNumberOfTravelersField1().setText("0");
        agentBorder.getNamesOfTravelersList().removeAll();
        agentBorder.getItineraryIDField().setText("");
        agentBorder.getItineraryIDField2().setText("");
        changeEnabledFor("Itinerary");
        agentBorder.getManageFlightsButton().setEnabled(false);
    }
    public void itinerarySearchButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(agentBorder.getCustomerIDField1().getText().equals("")){
            JOptionPane.showMessageDialog(null, "Please Look Up A Customer In The Customer Menu!!", "Failed Itineary Retrieval!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        int itineraryIndex=-1;
        try{
        itineraryIndex = Integer.parseInt(agentBorder.getItinerarySearchField().getText());
        }catch(Exception ex){
            if(itineraryIndex==-1){
                JOptionPane.showMessageDialog(null, "Bad info placed in itinerary search field please insert only the number of the itinerary ID!!", "Failed Itineary Retrieval!", JOptionPane.ERROR_MESSAGE);
            }
            return;
        }
        ArrayList<ItineraryEntity> itineraryArray = eflDatabase.getCustomers().get(Integer.parseInt(agentBorder.getCustomerIDField1().getText())).getItineraries();
        ItineraryEntity itinerary;
        if(itineraryIndex <= itineraryArray.size() - 1 && itineraryArray.get(itineraryIndex).getItineraryID()!=-1 ){
            itinerary = eflDatabase.getCustomers().get(
                    Integer.parseInt(agentBorder.getCustomerIDField1().getText())).getItineraries().get(itineraryIndex);
            UpdateItineraryFields(itinerary);
            if(agentBorder.getCreateItineraryButton().isEnabled()){
                changeEnabledFor("Itinerary");
            }
            agentBorder.getItinerarySearchField().setText("");
        }else{
            JOptionPane.showMessageDialog(null, "Invalid Itinerary ID!! Itinerary doesn't exist!!", "Failed Itinerary Retrieval!!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        agentBorder.getManageFlightsButton().setEnabled(eflDatabase.getCustomers().get(Integer.parseInt(agentBorder.getCustomerIDField1().getText())).getItineraries().get(itineraryIndex).getFlights().size()>0 );
        
    }
    
    /**
     * searchFlightsButtonActionPerformed
     * 1 Verifies an itinerary is set
     * 2 Traverses through each flight and immediately stores direct flights and multi-leg  flights of the same airline
     * other flights with the same origin are stored in a "candidate" list (tempList) and the remainder are put into a "graph-like"  hash function
     * 3 Iterates a total number of times defined by the constant MAX_NUM_FLIGHT_LEGS - 1 since the direct flights are already taken care of for us.
     * if a candidate flight's following flights contain the desired destination they are then stored in the currentFlightsList
     * 4 Runs the necessary Sorting based on the current preference of the user and populates the flights table with the information
     * @param evt 
     */
    public void searchFlightsButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(agentBorder.getItineraryIDField().getText().equals("")){
            JOptionPane.showMessageDialog(null, "Please have an Itinerary chosen to execute a flight search!!", "Failed Search Flight!!", JOptionPane.ERROR_MESSAGE);
            return;
        }else if(agentBorder.getDepartureCityComboBox().getSelectedItem()==null || agentBorder.getArrivalCityComboBox().getSelectedItem()==null){
            JOptionPane.showMessageDialog(null, "Please select a Destination and Origin!!", "Failed Search Flight!!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        currentFlightsList = new ArrayList<>();
        String currentAirport = eflDatabase.getAirport(agentBorder.getDepartureCityComboBox().getSelectedItem().toString()).getAirportAbbreviation();
        String destinationAirport = eflDatabase.getAirport(agentBorder.getArrivalCityComboBox().getSelectedItem().toString()).getAirportAbbreviation();
        ArrayList<ArrayList<FlightEntity>> tempList = new ArrayList<>();
        HashMap hash = new HashMap(eflDatabase.getAirports().size());
        //first loop commits the direct flights to the currentFlightList
            for (ArrayList<FlightEntity> flight : eflDatabase.getFlights()) {
                if(flight.get(0).getOriginAirport().equals(currentAirport)){
                   if(flight.get(0).getDestinationAirport().equals(destinationAirport)){
                       computeFlightTime(flight);
                       flight.get(0).setTotalCost(ComputeCost(flight));
                       currentFlightsList.add(flight);
                       continue;
                   }else{
                   tempList.add(flight);
                   }
                   
                }else if (flight.get(0).getStopsDuringFlight() == 0){
                    ArrayList<ArrayList<FlightEntity>> temp;
                    
                    if(hash.containsKey(flight.get(0).getOriginAirport())){
                        temp = ((ArrayList<ArrayList<FlightEntity>>)hash.get(flight.get(0).getOriginAirport()));
                    }else{
                        temp = new ArrayList<>();
                    }
                        temp.add(flight);
                        hash.put(flight.get(0).getOriginAirport(), temp);
                }
            }
                    
               for(int i=1; i<MAX_NUM_FLIGHT_LEGS;i++){
                    int size = tempList.size();
                    ArrayList<FlightEntity> temp;
                    for(ArrayList<FlightEntity> legs: tempList){
                        currentAirport = legs.get(0).getDestinationAirport();
                        ArrayList<ArrayList<FlightEntity>> legLists = (ArrayList<ArrayList<FlightEntity>>)hash.get(currentAirport);
                        for(ArrayList<FlightEntity> leg : legLists){
                            temp = (ArrayList<FlightEntity>) tempList.get(tempList.indexOf(legs)).clone();
                                    temp.addAll(leg);
                                    
                           if(legs.get(tempList.indexOf(legs)).getArrivalTime().get(Calendar.HOUR_OF_DAY)>=12 && leg.get(0).getDepartureTime().get(Calendar.HOUR_OF_DAY)<12 ){
                                legs.get(tempList.indexOf(legs)).getArrivalTime().set(Calendar.DAY_OF_MONTH, legs.get(tempList.indexOf(legs)).getArrivalTime().get(Calendar.DAY_OF_MONTH) + 1);
                           }
                           if(leg.get(0).getDepartureTime().getTimeInMillis() - legs.get(0).getArrivalTime().getTimeInMillis() >= ALLOWED_TIME_BETWEEN_FLIGHTS && !legs.get(0).getAirlineAbbreviation().equals(temp.get(temp.size()-1).getAirlineAbbreviation())){
                              
                                if(temp.get(temp.size()-1).getDestinationAirport().equals(destinationAirport)){
                                    ArrayList<FlightEntity> newLegFlights=new ArrayList<>();
                                    FlightEntity flightSummary = new FlightEntity();
                                    flightSummary.setAirlineAbbreviation("MULTI");
                                    flightSummary.setNameOfAirline("MULTI");
                                    flightSummary.setOriginAirport(temp.get(0).getOriginAirport());
                                    flightSummary.setDestinationAirport(destinationAirport);
                                    flightSummary.setDepartureTime(temp.get(0).getDepartureTime());
                                    flightSummary.setArrivalTime(temp.get(temp.size()-1).getArrivalTime());
                                    flightSummary.setCostPerMile(-1.0);
                                    flightSummary.setStopsDuringFlight(temp.size()-1);
                                    newLegFlights.add(flightSummary);
                                    newLegFlights.addAll(temp);
                                    newLegFlights.get(0).setTotalCost(ComputeCost(newLegFlights));
                                    computeFlightTime(newLegFlights);
                                    currentFlightsList.add(newLegFlights);
                                }else{ 
                                    tempList.add(temp);
                                } 
                           }
                        }
                        tempList.remove(tempList.indexOf(legs));
                        size--;
                        if(size==0){
                            break;
                        }
                    }
                } 
               
       if(evt!=null){      
       int width=1100, height=650;
       Toolkit toolkit =  Toolkit.getDefaultToolkit();
       Dimension dim = toolkit.getScreenSize();
       DefaultTableModel model = (DefaultTableModel) agentBorder.getFlightListTable().getModel();
       agentBorder.getMakeReservationButton().setEnabled(false);
       
       setTableData(model, SearchFlights());
       agentBorder.getNumberOfTravelersField1().setText(agentBorder.getNumberOfTravelersField().getText());
       agentBorder.getFlightListFrame().setBounds((dim.width - width)/2, (dim.height - height)/2, width, height);
       agentBorder.getFlightListFrame().setVisible(true);
       }
         
    }
    public void flightListTableMouseClicked(java.awt.event.MouseEvent evt) {
        NumberFormat numForm = NumberFormat.getCurrencyInstance();
        JTable table = agentBorder.getFlightListTable();
        if(evt.getClickCount()==1 && table.contains(evt.getPoint())){
            agentBorder.getMakeReservationButton().setEnabled(true);
            int rowIndex = table.rowAtPoint(evt.getPoint());
            DefaultTableModel model = (DefaultTableModel) agentBorder.getLegListTable().getModel();
            ArrayList<ArrayList<FlightEntity>> temp = new ArrayList();
            agentBorder.getTotalCostTextField().setText(numForm.format((Integer.parseInt(agentBorder.getNumberOfTravelersField().getText())+1)*currentFlightsList.get(rowIndex).get(0).getTotalCost()));
            temp.add(currentFlightsList.get(rowIndex));
            setTableData(model, temp);
        }
    }
    public void createPriceWatchButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(agentBorder.getDesiredCostTextField().getText().equals("")){
            JOptionPane.showMessageDialog(null, "Please have price desired eterned to create a price watch!!", "Failed Price Watch Creation!!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        int customerID = (int) Integer.parseInt(agentBorder.getCustomerIDField3().getText());
        int itineraryID = (int) Integer.parseInt(agentBorder.getItineraryIDField2().getText());
        
        for(PriceWatchEntity priceWatch: eflDatabase.getPriceWatches()){
            if(priceWatch.getCustomerID()==customerID && priceWatch.getItineraryID()==itineraryID){
                 int choice;
                choice=JOptionPane.showConfirmDialog(agentBorder, "There can only be one price watch per Itinerary!! Would you like to Overwrite the current flight with the new flight?","Flight Reservation Error!!" ,JOptionPane.YES_NO_CANCEL_OPTION);
                switch(choice){
               case JOptionPane.YES_OPTION:
                   eflDatabase.getPriceWatches().remove(priceWatch);
                   break;
               case JOptionPane.NO_OPTION:
               case JOptionPane.CANCEL_OPTION:
                   return;
                }
            }
            if(eflDatabase.getPriceWatches().isEmpty()){
                break;
            }
        }
        try{
        eflDatabase.getReport().setNumberOfWatchesStarted(eflDatabase.getReport().getNumberOfWatchesStarted() + 1);
        eflDatabase.getPriceWatches().add(
        CreatePriceWatch(Double.parseDouble(agentBorder.getDesiredCostTextField().getText()),agentBorder.getSendTextNotification().isSelected(), customerID, itineraryID));
        agentBorder.getDesiredCostTextField().setText("");
        } catch (NumberFormatException e) {
                  JOptionPane.showMessageDialog(null, e.getMessage(), "Input Error!", JOptionPane.INFORMATION_MESSAGE); 
        }
    }
    public void provideMetWatchesButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(eflDatabase.getPriceWatches().isEmpty()){
             JOptionPane.showMessageDialog(null, "There are no price watches to be retrieved!!", "Failed Price Watch Retrieval!!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        DefaultTableModel model = (DefaultTableModel) agentBorder.getMetWatchesAndFlightsTable().getModel();
        CustomerEntity customer = null;
        for (int i = model.getRowCount() - 1; i >= 0; i--) {
            model.removeRow(i);
        }
        ArrayList<PriceWatchEntity> metPriceWatches = ProvideMetWatches();
        for(PriceWatchEntity priceWatch: metPriceWatches){
            customer = eflDatabase.getCustomers().get(priceWatch.getCustomerID());
            String[] name = customer.getName().split(" ");
            for(ArrayList<FlightEntity> flight: priceWatch.getMetFlights()){
            model.addRow(new Object[]{name[0], name[1], String.valueOf(priceWatch.getCustomerID()),String.valueOf(priceWatch.getItineraryID()),customer.getPhoneNumber(), customer.getEmailAddress(), round(flight.get(0).getTotalCost(),2),round(flight.get(0).getTravelTime(),2), flight.get(0).getStopsDuringFlight(),flight.get(0).getAirlineAbbreviation(),flight.get(0).getFlightNumber()});
            }
        }
        
       int width=1000, height=450;
       Toolkit toolkit =  Toolkit.getDefaultToolkit();
       Dimension dim = toolkit.getScreenSize();

       agentBorder.getMetWatchesAndFlightsFrame().setBounds((dim.width - width)/2, (dim.height - height)/2, width, height);
       agentBorder.getMetWatchesAndFlightsFrame().setVisible(true);
       agentBorder.getMetWatchesAndFlightsFrame().setTitle("Met Price Watches");
       agentBorder.getMetWatchesAndFlightsLabel().setText("Met Price Watches");
       agentBorder.getCancelReservationButton().setVisible(false);
       agentBorder.getCancelPriceWatchButton().setVisible(true);
    }
    public void cancelPriceWatchButtonActionPerformed(java.awt.event.ActionEvent evt) { 
        JTable table = agentBorder.getMetWatchesAndFlightsTable();
        DefaultTableModel model = (DefaultTableModel) agentBorder.getMetWatchesAndFlightsTable().getModel();
        
        int customerID = Integer.parseInt((String)model.getValueAt(table.getSelectedRow(),2));
        int itineraryID = Integer.parseInt((String)model.getValueAt(table.getSelectedRow(),3));
        
        for(PriceWatchEntity priceWatch: eflDatabase.getPriceWatches()){
            if(customerID==priceWatch.getCustomerID() && itineraryID==priceWatch.getItineraryID()){
                CancelWatch(priceWatch);
                eflDatabase.getReport().setNumberOfWatchesCancelled(eflDatabase.getReport().getNumberOfWatchesCancelled() + 1);
            }
            if(eflDatabase.getPriceWatches().isEmpty()){
                 JOptionPane.showMessageDialog(null, "There are no price watches to be retrieved!!", "No Price Watches Left!!", JOptionPane.ERROR_MESSAGE);
               agentBorder.getMetWatchesAndFlightsFrame().setVisible(false);
                break;
            }
        }
    } 
    public void metWatchesAndFlightsMouseClicked(java.awt.event.MouseEvent evt) {
        JTable table = agentBorder.getMetWatchesAndFlightsTable();
        if(table.contains(evt.getPoint())){
           if(agentBorder.getMetWatchesAndFlightsFrame().getTitle().equals("Customer Flight")){
            agentBorder.getCancelReservationButton().setEnabled(true);
            }
            agentBorder.getCancelPriceWatchButton().setEnabled(true);
        }
    }
    public void makeReservationButtonActionPerformed(java.awt.event.ActionEvent evt) {
        int customerID = Integer.parseInt(agentBorder.getCustomerIDField3().getText());
        int itineraryID = Integer.parseInt(agentBorder.getItineraryIDField2().getText());
        if(!eflDatabase.getCustomers().get(customerID).getItineraries().get(itineraryID).getFlights().isEmpty()){
            JOptionPane.showMessageDialog(null, "You cannot add more than one flight to a single itinerary. If you want to add a new flight, you will have to make a new itinerary.", "Single Flight To Itineary Error!", JOptionPane.ERROR_MESSAGE);
            return;
        }
        JTable table = agentBorder.getFlightListTable();
        int index = table.getSelectedRow();
        ReserveFlight(currentFlightsList.get(index),customerID,itineraryID);
        agentBorder.getManageFlightsButton().setEnabled(true);
        eflDatabase.getReport().setNumberOfReservations(eflDatabase.getReport().getNumberOfReservations() + 1);
    }
    public void cancelReservationButtonActionPerformed(java.awt.event.ActionEvent evt) {
        CancelReservation(Integer.parseInt(agentBorder.getCustomerIDField3().getText()),Integer.parseInt(agentBorder.getItineraryIDField2().getText()));
        clearItineraryButtonActionPerformed(evt);
        agentBorder.getManageFlightsButton().setEnabled(false);
        agentBorder.getCancelReservationButton().setEnabled(false);
        DefaultTableModel model = (DefaultTableModel) agentBorder.getMetWatchesAndFlightsTable().getModel();
       for (int i = model.getRowCount() - 1; i >= 0; i--) {
            model.removeRow(i);
       }
       if(model.getRowCount()==0){
           agentBorder.getMetWatchesAndFlightsFrame().setVisible(false);
       }
    }
    public void modifyReservationButtonActionPerformed(java.awt.event.ActionEvent evt) {
        JTable table = agentBorder.getFlightListTable();
        DefaultTableModel model = (DefaultTableModel) agentBorder.getLegListTable().getModel();
        int index = table.getSelectedRow();
        ModifyReservation(currentFlightsList.get(index),Integer.parseInt(agentBorder.getCustomerIDField3().getText()),Integer.parseInt(agentBorder.getItineraryIDField2().getText()));
    }
    public void manageFlightsButtonActionPerformed(java.awt.event.ActionEvent evt) {
        
       if(agentBorder.getCustomerIDField1().getText().equals("") || agentBorder.getItineraryIDField().getText().equals("")){
           JOptionPane.showMessageDialog(null, "Customer or Itinerary Fields are Empty, please return to Customer Menu and retreive a customer and create an itinerary before trying to manage a flight.", "Fields left Empty!", JOptionPane.ERROR_MESSAGE);
       }
       DefaultTableModel model = (DefaultTableModel) agentBorder.getMetWatchesAndFlightsTable().getModel();
       int customerID = Integer.parseInt(agentBorder.getCustomerIDField1().getText());
       int itineraryID = Integer.parseInt(agentBorder.getItineraryIDField().getText());
       CustomerEntity customer = eflDatabase.getCustomers().get(customerID);
       
       for (int i = model.getRowCount() - 1; i >= 0; i--) {
            model.removeRow(i);
       }
       String[] name = customer.getName().split(" ");
       for(FlightEntity flight : eflDatabase.getCustomers().get(customerID).getItineraries().get(itineraryID).getFlights()){
           model.addRow(new Object[]{name[0], name[1], String.valueOf(customerID),String.valueOf(itineraryID),customer.getPhoneNumber(), customer.getEmailAddress(), round(flight.getTotalCost(),2),round(flight.getTravelTime(),2), flight.getStopsDuringFlight(),flight.getAirlineAbbreviation(),flight.getFlightNumber()});
       }
        
       
       int width=1000, height=450;
       Toolkit toolkit =  Toolkit.getDefaultToolkit();
       Dimension dim = toolkit.getScreenSize();

       agentBorder.getMetWatchesAndFlightsFrame().setBounds((dim.width - width)/2, (dim.height - height)/2, width, height);
       agentBorder.getMetWatchesAndFlightsFrame().setVisible(true);
       agentBorder.getMetWatchesAndFlightsFrame().setTitle("Customer Flight");
       agentBorder.getMetWatchesAndFlightsLabel().setText("Customer Flight Info");
       agentBorder.getCancelPriceWatchButton().setVisible(false);
       agentBorder.getCancelReservationButton().setVisible(true);
    }


    ////////////////////////////////////HELPER METHODS TO KEEP REUSABLE CLEAN CODE
        private void UpdateCustomerFields(CustomerEntity newCustomer){
        if(newCustomer.getName()==null){
            agentBorder.getFirstNameField().setText("");
            agentBorder.getLastNameField().setText("");
        }else{
            String[] name = newCustomer.getName().split(" ");

            agentBorder.getFirstNameField().setText(name[0]);
            agentBorder.getLastNameField().setText(name[1]);
            }
            agentBorder.getAddressField().setText(newCustomer.getAddress());
            agentBorder.getEmailAddressField().setText(newCustomer.getEmailAddress());
            agentBorder.getPhoneNumberField().setText(newCustomer.getPhoneNumber());
            agentBorder.getCardHolderNameField().setText(newCustomer.getCreditCard().getHolderName());
            agentBorder.getCardNumberField().setText(newCustomer.getCreditCard().getCardNumber());
            agentBorder.getCardTypeComboBox().setSelectedItem(newCustomer.getCreditCard().getCardType());
        if(newCustomer.getCreditCard().getExpirationDate()==null){
            agentBorder.getCardExpirationDateChooser().setDate(null);
        }else{
            agentBorder.getCardExpirationDateChooser().setDate(newCustomer.getCreditCard().getExpirationDate().getTime());
        }
            agentBorder.getCsvNumberField().setText(newCustomer.getCreditCard().getCsvNumber());
            agentBorder.getBillingAddressField().setText(newCustomer.getCreditCard().getBillingAddress());
        }
        private void UpdateItineraryFields(ItineraryEntity newItinerary){
            agentBorder.getItineraryIDField().setText(String.valueOf(newItinerary.getItineraryID()));
            agentBorder.getItineraryIDField2().setText(String.valueOf(newItinerary.getItineraryID()));
            agentBorder.getDepartureCityComboBox().setSelectedItem(newItinerary.getDepartureCity());
            agentBorder.getArrivalCityComboBox().setSelectedItem(newItinerary.getArrivalCity());
            if(newItinerary.getDepartureDate() == null){
                agentBorder.getDepartureDateChooser().setDate(null);
            }else{
            agentBorder.getDepartureDateChooser().setDate(newItinerary.getDepartureDate().getTime());
            }
            if(newItinerary.getReturnDate() == null){
                agentBorder.getArrivalDateChooser().setDate(null);
            }else{
            agentBorder.getArrivalDateChooser().setDate(newItinerary.getReturnDate().getTime());
            }
            agentBorder.getNamesOfTravelersList().removeAll();
            for(String string: newItinerary.getTravelerNames().getItems()){
            agentBorder.getNamesOfTravelersList().add(string);
                    }
            agentBorder.getNumberOfTravelersField().setText(String.valueOf(newItinerary.getNumberOfTravelers()));
            agentBorder.getCardHolderNameField1().setText(newItinerary.getCreditCard().getHolderName());
            agentBorder.getCardNumberField1().setText(newItinerary.getCreditCard().getCardNumber());
            agentBorder.getCardTypeComboBox1().setSelectedItem(newItinerary.getCreditCard().getCardType());
        if(newItinerary.getCreditCard().getExpirationDate()==null){
            agentBorder.getCardExpirationDateChooser1().setDate(null);
        }else{
            agentBorder.getCardExpirationDateChooser1().setDate(newItinerary.getCreditCard().getExpirationDate().getTime());
        }
            agentBorder.getCsvNumberField1().setText(newItinerary.getCreditCard().getCsvNumber());
            agentBorder.getBillingAddressField1().setText(newItinerary.getCreditCard().getBillingAddress());
        }
    private void changeEnabledFor(String customerOrItinerary){
        switch(customerOrItinerary){
            case "Customer":
                if(agentBorder.getCreateCustomerButton().isEnabled()){
                    agentBorder.getCreateCustomerButton().setEnabled(false);
                    agentBorder.getModifyCustomerButton().setEnabled(true);
                    agentBorder.getDeleteCustomerButton().setEnabled(true);
                    agentBorder.getClearCustomerButton().setEnabled(true);
                }
                else{
                    agentBorder.getCreateCustomerButton().setEnabled(true);
                    agentBorder.getModifyCustomerButton().setEnabled(false);
                    agentBorder.getDeleteCustomerButton().setEnabled(false);
                    agentBorder.getClearCustomerButton().setEnabled(false);
                } break;
            case "Itinerary":
                if(agentBorder.getCreateItineraryButton().isEnabled()){
                    agentBorder.getCreateItineraryButton().setEnabled(false);
                    agentBorder.getModifyItineraryButton().setEnabled(true);
                    agentBorder.getDeleteItineraryButton().setEnabled(true);
                    agentBorder.getClearItineraryButton().setEnabled(true);
                    agentBorder.getSearchFlightsButton().setEnabled(true);
                }
                else{
                    agentBorder.getCreateItineraryButton().setEnabled(true);
                    agentBorder.getModifyItineraryButton().setEnabled(false);
                    agentBorder.getDeleteItineraryButton().setEnabled(false);
                    agentBorder.getClearItineraryButton().setEnabled(false);
                    agentBorder.getSearchFlightsButton().setEnabled(false);
                } break;
        }
        
    }
    private boolean verifyFieldsFor(String customerOrItinerary){
        switch(customerOrItinerary){
            case "Customer":
                if (agentBorder.getBillingAddressField().getText().equals("")){
                    agentBorder.getBillingAddressField().setText(agentBorder.getAddressField().getText());
                }
                if(agentBorder.getFirstNameField().getText().equals("") || 
                   agentBorder.getLastNameField().getText().equals("") ||
                   agentBorder.getAddressField().getText().equals("") ||
                   agentBorder.getEmailAddressField().getText().equals("") ||
                   agentBorder.getPhoneNumberField().getText().equals("") ||
                   agentBorder.getCardHolderNameField().getText().equals("") ||
                   agentBorder.getCardTypeComboBox().getSelectedItem().equals("") ||
                   agentBorder.getCardNumberField().getText().equals("") ||
                   agentBorder.getCsvNumberField().getText().equals("") ||
                   agentBorder.getBillingAddressField().getText().equals("") ||
                   agentBorder.getCardExpirationDateChooser().getCalendar() == null){
                    JOptionPane.showMessageDialog(null, "Field(s) left Empty, please try again.", "Field(s) left Empty!", JOptionPane.ERROR_MESSAGE);
                    return false;
                }break;
            case "Itinerary":
                if(agentBorder.getCustomerIDField1().getText().equals("")){
                    JOptionPane.showMessageDialog(null, "Customer Field is Empty, please return to Customer Menu and retreive a customer before creating or searching for an itinerary.", "Customer Field left Empty!", JOptionPane.ERROR_MESSAGE);
                    return false;
                }
                if(agentBorder.getBillingAddressField1().getText().equals("") ||
                    agentBorder.getCardTypeComboBox().getSelectedItem().equals("") ||
                    agentBorder.getCardNumberField1().getText().equals("") ||
                    agentBorder.getCsvNumberField1().getText().equals("") ||
                    agentBorder.getCardHolderNameField1().getText().equals("") ||
                    agentBorder.getCardExpirationDateChooser1().getCalendar() == null){
                    
                    agentBorder.getBillingAddressField1().setText(agentBorder.getBillingAddressField().getText());
                    agentBorder.getCardTypeComboBox1().setSelectedItem(agentBorder.getCardTypeComboBox().getSelectedItem());
                    agentBorder.getCardNumberField1().setText(agentBorder.getCardNumberField().getText());
                    agentBorder.getCsvNumberField1().setText(agentBorder.getCsvNumberField().getText());
                    agentBorder.getCardHolderNameField1().setText(agentBorder.getCardHolderNameField().getText());
                    agentBorder.getCardExpirationDateChooser1().setCalendar(agentBorder.getCardExpirationDateChooser().getCalendar());
                }
                if(agentBorder.getDepartureCityComboBox().getItemCount()==0 ||
                    agentBorder.getArrivalCityComboBox().getItemCount()==0){
                    JOptionPane.showMessageDialog(null,"No Airports populated please get an update from the CRATD!", "Airport Information Needed!", JOptionPane.ERROR_MESSAGE);
                    return false;
                }else if(agentBorder.getDepartureCityComboBox().getSelectedItem() ==
                    agentBorder.getArrivalCityComboBox().getSelectedItem()){
                    JOptionPane.showMessageDialog(null,"You cannot have the same Departure and Arrival Cities!", "Incorrect Airport Information!", JOptionPane.ERROR_MESSAGE);
                    return false;
                }

                if(agentBorder.getDepartureCityComboBox().getSelectedItem().equals("") ||
                    agentBorder.getArrivalCityComboBox().getSelectedItem().equals("") ||
                    agentBorder.getDepartureDateChooser().getCalendar() == null ||
                    agentBorder.getArrivalDateChooser().getCalendar() == null){
                    JOptionPane.showMessageDialog(null, "Field(s) left Empty, please try again.", "Field(s) left Empty!", JOptionPane.ERROR_MESSAGE);
                    return false;
                }
                break;
        }
        return true;
    } 
    private void setTableData(DefaultTableModel model, ArrayList<ArrayList<FlightEntity>> flights){
        DefaultTableModel legModel = (DefaultTableModel) agentBorder.getLegListTable().getModel();
       for (int i = model.getRowCount() - 1; i >= 0; i--) {
            model.removeRow(i);
            if(i <= legModel.getRowCount()-1 && !legModel.equals(model)){
                legModel.removeRow(i);
            }
        }
       if(legModel.equals(model)){
           boolean blockFirstFlight=flights.get(0).get(0).getStopsDuringFlight()>0;
          for(FlightEntity leg:flights.get(0)){
              if(!blockFirstFlight){
           addAndFormatFlight(leg,model);
              }else{
                  blockFirstFlight=false;
              }
          }
          return;
       }
       for(ArrayList<FlightEntity> sortedFlight :flights){
           addAndFormatFlight(sortedFlight.get(0),model);         
       }
    }
    private void addAndFormatFlight(FlightEntity flight, DefaultTableModel model){
        NumberFormat numForm = NumberFormat.getCurrencyInstance();
        
        String date = String.valueOf(flight.getDepartureTime().get(Calendar.MONTH)+1);
            date += "/" + String.valueOf(flight.getDepartureTime().get(Calendar.DAY_OF_MONTH));
            date += "/" + String.valueOf(flight.getDepartureTime().get(Calendar.YEAR));
            String departure = String.valueOf(flight.getDepartureTime().get(Calendar.HOUR_OF_DAY));
            int minute = flight.getDepartureTime().get(Calendar.MINUTE);
            departure += ":" + String.valueOf((minute<=9 && minute!=0?"0":"") + minute  + (minute==0?"0":""));
            String arrival = String.valueOf(flight.getArrivalTime().get(Calendar.HOUR_OF_DAY));
            minute=flight.getArrivalTime().get(Calendar.MINUTE);
            arrival += ":" + String.valueOf((minute<=9 && minute!=0?"0":"") + minute  + (minute==0?"0":""));
            int hour =(int) (flight.getTravelTime() * 60.0)/60;
            int min = (int) (flight.getTravelTime() * 60.0)%60;
            String time = String.valueOf(hour) + ":" + (min>9?"":"0") + String.valueOf(min);
            model.addRow(new Object[]{date,flight.getAirlineAbbreviation() , flight.getFlightNumber(), flight.getOriginAirport(), departure,flight.getDestinationAirport() ,arrival,numForm.format(flight.getTotalCost()), time, flight.getStopsDuringFlight()});
    }
    public static double round(double value, int places) {
    if (places < 0) {
            throw new IllegalArgumentException();
        }

    long factor = (long) Math.pow(10, places);
    value = value * factor;
    long tmp = Math.round(value);
    return (double) tmp / factor;
}
    ////////////////////////////////////ORIGINAL METHODS
    protected boolean LogIn(String agentID, String password){
        
        //If the ID is an existing index into the array, check the entity's password against the entered (supplied) password
        if(agentID.equals("admin") && password.equals("admin")){
            return true;
        }
        if(eflDatabase.getAgents().get(Integer.parseInt(agentID)).getPassword().equals(password)){
            isManager=eflDatabase.getAgents().get(Integer.parseInt(agentID)).isaManager();
            agentBorder.setUserIsManager(eflDatabase.getAgents().get(Integer.parseInt(agentID)).isaManager());
        return true;
        }
        return false;
    }
   
    public CustomerEntity CreateCustomerAccount(String CustomerID,String name, String address, String emailAddress, String phoneNumber, CreditCardEntity creditCard){
        CustomerEntity newCustomer = new CustomerEntity();
        newCustomer.setCustomerID(CustomerID);
        newCustomer.setName(name);
        newCustomer.setAddress(address);
        newCustomer.setEmailAddress(emailAddress);
        newCustomer.setPhoneNumber(phoneNumber);
        newCustomer.setCreditCard(creditCard);
        newCustomer.setItineraries(new ArrayList<ItineraryEntity>());
        return newCustomer;
    } 
    /**
     * Returns the index into an ArrayList of existing customers. This index will also correspond to the customer's customerID. If the customer doesn't exist, -1 will be returned, signaling that the customer specified is an invalid customer.
     * @param customerID
     * @return 
     */
    protected int CustomerLookUp(String customerID){

        int customerIndex = -1;
        if(Character.isDigit(customerID.charAt(0))){
            //This means the string is a customer's phone number.
            for (CustomerEntity customer: eflDatabase.getCustomers()){
                if(customer.getPhoneNumber().equals(customerID)){
                    customerIndex = Integer.parseInt(customer.getCustomerID());
                }
            }
        }
        else if(customerID!=null){
            //This means the string is a customer's name.
            for (CustomerEntity customer: eflDatabase.getCustomers()){
                if(customer.getName().split(" ")[0].toLowerCase().equals(customerID.toLowerCase())){
                customerIndex = Integer.parseInt(customer.getCustomerID());
                }
            }
           
        }    
        return customerIndex;
    } 

    public CustomerEntity UpdateCustomer(String customerID, String name, String address, String emailAddress, String phoneNumber, CreditCardEntity creditCard){
         CustomerEntity customer; 
            customer = eflDatabase.getCustomers().get(Integer.parseInt(customerID));
            customer.setName(name);
            customer.setAddress(address);
            customer.setEmailAddress(emailAddress);
            customer.setPhoneNumber(phoneNumber);
            customer.setCreditCard(creditCard);
            
            eflDatabase.getCustomers().set(Integer.parseInt(customerID), customer);

         return customer;
    }
    
    protected ItineraryEntity CreateNewItinerary(String customerID, String departureCity, String arrivalCity, GregorianCalendar depatureDate, GregorianCalendar returnDate, String preference){
        ItineraryEntity newItinerary = new ItineraryEntity();
        
        if(customerID==null){
            newItinerary.setItineraryID(-1);
        }else{
            CustomerEntity customer = eflDatabase.getCustomers().get(Integer.parseInt(customerID));
            newItinerary.setItineraryID(customer.getItineraries().size());
        }
            newItinerary.setDepartureCity(departureCity);
            newItinerary.setArrivalCity(arrivalCity);
            newItinerary.setDepartureDate(depatureDate);
            newItinerary.setReturnDate(returnDate);
            newItinerary.setPreference(preference);
            newItinerary.setTravelerNames(agentBorder.getNamesOfTravelersList());
            newItinerary.setNumberOfTravelers(Integer.parseInt(agentBorder.getNumberOfTravelersField().getText()));

        return newItinerary;
    }
    
    protected ArrayList<ArrayList<FlightEntity>> SearchFlights(){
        String preference = (agentBorder.getCheapestFareRadioButton().isSelected()? preference = "Cheapest Fare": 
                             agentBorder.getShortestNumberOfFlightsRadioButton().isSelected()? preference = "Shortest Number Of Flights":agentBorder.getShortestTimeRadioButton().isSelected()? preference = "Shortest Time": null);
        
        int n=currentFlightsList.size();
        switch(preference){
            case "Cheapest Fare":
                for(int pass=1; pass < n ;pass++){
                    for (int i=0; i < n-pass; i++) {
                        if (currentFlightsList.get(pass-1).get(0).getTotalCost() > 
                                currentFlightsList.get(pass).get(0).getTotalCost()) {
                            ArrayList<FlightEntity> temp = currentFlightsList.get(pass-1);  
                            currentFlightsList.set(pass-1, currentFlightsList.get(pass)); 
                            currentFlightsList.set(pass, temp);
                        }
                     }
                 }
                break;

            case "Shortest Time":
                for(ArrayList<FlightEntity> sortMe:currentFlightsList){
                    for(int pass=1; pass < n ;pass++){
                    for (int i=0; i < n-pass; i++) {
                        if (currentFlightsList.get(pass-1).get(0).getTravelTime() > 
                                currentFlightsList.get(pass).get(0).getTravelTime()) {
                            ArrayList<FlightEntity> temp = currentFlightsList.get(pass-1);  
                            currentFlightsList.set(pass-1, currentFlightsList.get(pass)); 
                            currentFlightsList.set(pass, temp);
                        }
                     }
                 }
                }
                break;

            case "Shortest Number Of Flights":
                for(ArrayList<FlightEntity> sortMe:currentFlightsList){
                 for(int pass=1; pass < n ;pass++){
                    for (int i=0; i < n-pass; i++) {
                        if (currentFlightsList.get(pass-1).get(0).getStopsDuringFlight() > 
                                currentFlightsList.get(pass).get(0).getStopsDuringFlight()) {
                            ArrayList<FlightEntity> temp = currentFlightsList.get(pass-1);  
                            currentFlightsList.set(pass-1, currentFlightsList.get(pass)); 
                            currentFlightsList.set(pass, temp);
                        }
                     }
                 }
                }
                break;
        }
        return currentFlightsList;
    }
       
     protected double ComputeCost(ArrayList<FlightEntity> flight){
         if(flight==null){
             return 0.0;
         }
         double cost = 0.0, distance = 0.0, legCost=0.0;
         boolean discount=false;
         int numberOfStops = flight.get(0).getStopsDuringFlight();
         int numberOfTravelers = 1 + Integer.parseInt(agentBorder.getNumberOfTravelersField().getText());
         AirlineEntity airline = new AirlineEntity();
         AirportEntity origin = null,destination= null;
         
         if(numberOfStops>0){
             discount = !flight.get(0).getAirlineAbbreviation().equals("MULTI");
             numberOfStops++;
         }
         for(int i=0;i<=numberOfStops;i++){
             airline = eflDatabase.getAirline(flight.get(i).getAirlineAbbreviation());
             origin = eflDatabase.getAirport(flight.get(i).getOriginAirport());
             destination = eflDatabase.getAirport(flight.get(i).getDestinationAirport());
             distance =CalculateDistance(origin.getxCoordinate(),origin.getyCoordinate(),destination.getxCoordinate(),destination.getyCoordinate());
             if(i==0 && numberOfStops > 0){
                 continue;
             }
             double airlineCost = airline.getCostPerMile()*distance;
             
             double discountAmount =((i - 1) * .1);
             if(discount){
                 legCost= airlineCost - airlineCost * discountAmount  + origin.getAirportFee();
                 flight.get(i).setTotalCost(legCost);
             }else if(i==2){
                 legCost=airlineCost - (airlineCost * .1) + origin.getAirportFee();
                 flight.get(i).setTotalCost(legCost);
             }else{
                 legCost=airlineCost + origin.getAirportFee();
                 flight.get(i).setTotalCost(legCost);
             }
             cost+=legCost;
         }
         cost+=destination.getAirportFee();
         cost*=numberOfTravelers;
         cost+=(eflDatabase.getFee() - eflDatabase.getCustomers().get(Integer.parseInt(agentBorder.getCustomerIDField1().getText())).getAccountCredit());
         flight.get(0).setTotalCost(cost);
         
         return cost; 
     }
     
        protected void computeFlightTime(ArrayList<FlightEntity> flight){
            if(flight==null || flight.get(0).getOriginAirport()==null || flight.get(0).getDestinationAirport()==null){
                return;
            }
       double flightTime = 0.0;
       double originOffset;
       double arrivalOffset;
       GregorianCalendar arrivalTime;
       GregorianCalendar departureTime;
       double timeDifference;
       
       for(int i=0;i<=flight.size()-1;i++){
           if(i==0 && flight.get(0).getStopsDuringFlight()>0){
               arrivalTime = flight.get(flight.size()-1).getArrivalTime();
               departureTime = flight.get(1).getDepartureTime();
               if(departureTime.get(Calendar.AM_PM)==Calendar.PM && arrivalTime.get(Calendar.AM_PM)==Calendar.AM){
                   arrivalTime.set(Calendar.DAY_OF_MONTH, arrivalTime.get(Calendar.DAY_OF_MONTH)+1);
               }
           }else{
             arrivalTime = flight.get(i).getArrivalTime();
             departureTime = flight.get(i).getDepartureTime();
           }
         originOffset = eflDatabase.getAirport(flight.get(i).getOriginAirport()).getTimeZoneOffset();
         arrivalOffset = eflDatabase.getAirport(flight.get(i).getDestinationAirport()).getTimeZoneOffset();

         timeDifference = (arrivalOffset + 12) - (originOffset + 12);
         flightTime = ((arrivalTime.getTimeInMillis() - (timeDifference * HOURS_TO_MILLISECONDS)) - departureTime.getTimeInMillis()) / HOURS_TO_MILLISECONDS;
            if (flightTime < 0) {
                JOptionPane.showMessageDialog(agentBorder, "Flights Cannot Be Less than 0. Double check the flight times and location offsets to verify there's enough time to fly to and from your destination!!","Leg Time Error!!" ,JOptionPane.ERROR_MESSAGE);
                return;
            }
            flight.get(i).setTravelTime(flightTime);
       }
    }
  public double CalculateDistance(int x1, int y1, int x2, int y2) {
        return Math.sqrt(Math.pow((x1 - x2), 2.0) + Math.pow((y1 - y2), 2.0));
    }
    
    protected void ReserveFlight(ArrayList<FlightEntity> flight, int customerID, int itineraryID){
           CustomerEntity customer = eflDatabase.getCustomers().get(customerID);
            if (customer.getItineraries().get(itineraryID).getFlights().isEmpty()){
                customer.getItineraries().get(itineraryID).setFlights(flight);
                customer.setNumberFlightsReserved();
                eflDatabase.getReport().setNumberOfServiceFees(eflDatabase.getReport().getNumberOfServiceFees() + 1);
                eflDatabase.getReport().setTotalIncome(eflDatabase.getReport().getTotalIncome() + flight.get(0).getTotalCost());
                ProduceFlightReceipt(flight, customer.getItineraries().get(itineraryID),customer);
            }else{
                int choice;
                choice=JOptionPane.showConfirmDialog(agentBorder, "There can only be one flight per Itinerary!! Would you like to Overwrite the current flight with the new flight?","Flight Reservation Error!!" ,JOptionPane.YES_NO_CANCEL_OPTION);
                switch(choice){
               case JOptionPane.YES_OPTION:
                    eflDatabase.getReport().setTotalIncome(eflDatabase.getReport().getTotalIncome() - customer.getItineraries().get(itineraryID).getFlights().get(0).getTotalCost() + flight.get(0).getTotalCost());
                   customer.getItineraries().get(itineraryID).setFlights(flight);
                   ProduceFlightReceipt(flight, customer.getItineraries().get(itineraryID),customer);
                   break;
               case JOptionPane.NO_OPTION:
               case JOptionPane.CANCEL_OPTION:
                }
            }
  
    }
    
    protected void ModifyReservation(ArrayList<FlightEntity> flight, int itineraryID, int customerID){
        //Update a specific itinerary in the list of itineraries a customer has.
        CustomerEntity customer;
        ItineraryEntity itinerary;
 
        customer = eflDatabase.getCustomers().get(customerID);
        itinerary = customer.getItineraries().get(itineraryID);
        if(itinerary.getFlights().equals(flight)){
            JOptionPane.showMessageDialog(agentBorder, "Information requested for reservation is the same as the currently stored information. Please review your order and resubmit.","Modify reservation message" ,JOptionPane.INFORMATION_MESSAGE);
            return;
        }
        if (!itinerary.getFlights().isEmpty()){
            int choice;
                choice=JOptionPane.showConfirmDialog(agentBorder, "There can only be one flight per Itinerary!! Would you like to Overwrite the current flight with the new flight?","Flight Reservation Error!!" ,JOptionPane.YES_NO_CANCEL_OPTION);
                switch(choice){
               case JOptionPane.YES_OPTION:
                   customer.getItineraries().get(itineraryID).setFlights(flight);
                   break;
               case JOptionPane.NO_OPTION:
               case JOptionPane.CANCEL_OPTION:
                return;
                }
        }


    }
    
    protected boolean CancelReservation(int customerID, int itineraryID){
        CustomerEntity customer;
        int choice;
            customer = eflDatabase.getCustomers().get(customerID);
            if(itineraryID < customer.getItineraries().size()){
                choice=JOptionPane.showConfirmDialog(agentBorder, "Cancelling your flight will result in deletion of the customer itinerary. Would you like to continue?","Flight and Itinerary Deletion!!" ,JOptionPane.YES_NO_CANCEL_OPTION);
                switch(choice){
               case JOptionPane.YES_OPTION:
                   customer.getItineraries().remove(itineraryID);
                JOptionPane.showMessageDialog(agentBorder, "The flight and itinerary were successfully delted!!","Flight Cancelled!" ,JOptionPane.INFORMATION_MESSAGE);
                   break;
               case JOptionPane.NO_OPTION:
               case JOptionPane.CANCEL_OPTION:
                return false;
                }
            }else{
                return false;
            }
        return true;
    }  
    
    protected PriceWatchEntity CreatePriceWatch(double priceDesired, boolean notify, int customerID, int itineraryID){
        PriceWatchEntity priceWatch = new PriceWatchEntity();
        priceWatch.setPriceWatchExpiration();
        priceWatch.setPriceWatchPrice(priceDesired);
        priceWatch.setSendNotifyText(notify);
        priceWatch.setCustomerID(customerID);
        priceWatch.setItineraryID(itineraryID);
        JOptionPane.showMessageDialog(null, "Price Watch Successfully Created!!.", "Price Watch Created!", JOptionPane.INFORMATION_MESSAGE);
        return priceWatch;
    }
  
    protected ArrayList<PriceWatchEntity> ProvideMetWatches(){
          long thirtyDaysInMillis = (long) HOURS_TO_MILLISECONDS * 24 * 30;

        for(PriceWatchEntity priceWatch : eflDatabase.getPriceWatches()){
            if(new GregorianCalendar().getTimeInMillis() - priceWatch.getPriceWatchExpiration().getTimeInMillis()>=thirtyDaysInMillis){
                CancelWatch(priceWatch);
            }else{
                agentBorder.getCustomerSearchField().setText(eflDatabase.getCustomers().get(priceWatch.getCustomerID()).getName().split(" ")[0]);
                customerSearchButtonActionPerformed(null);
                agentBorder.getItinerarySearchField().setText(String.valueOf(priceWatch.getItineraryID()));
                itinerarySearchButtonActionPerformed(null);
                searchFlightsButtonActionPerformed(null);
                priceWatch.getMetFlights().clear();
                for(ArrayList<FlightEntity> flight : currentFlightsList){
                    if(flight.get(0).getTotalCost()<=priceWatch.getPriceWatchPrice()){// && !priceWatch.getMetFlights().contains(flight)){
                        priceWatch.setIsMet(true);
                        priceWatch.getMetFlights().add(flight);
                    }
                }
            } 
        }
        return eflDatabase.getPriceWatches();
    }
     protected void CancelWatch(PriceWatchEntity priceWatch){
         if(eflDatabase.getPriceWatches().remove(priceWatch)){
             DefaultTableModel model = (DefaultTableModel) agentBorder.getMetWatchesAndFlightsTable().getModel();
                for (int i = model.getRowCount() - 1; i >= 0; i--) {
                    if(priceWatch.getCustomerID()==Integer.parseInt((String)model.getValueAt(i,2)) && priceWatch.getItineraryID()==Integer.parseInt((String)model.getValueAt(i, 3))){
                        model.removeRow(i);
                    }
                }
                eflDatabase.getReport().setNumberOfCancelations(eflDatabase.getReport().getNumberOfCancelations() + 1);
                JOptionPane.showMessageDialog(null, "Price Watch was successfully cancelled!!", "Cancelled Price Watch!", JOptionPane.ERROR_MESSAGE);
                agentBorder.getCancelPriceWatchButton().setEnabled(false);
             return;
         }
         JOptionPane.showMessageDialog(null, "Price Watch No Longer Exists!!", "Invalid Price Watch!", JOptionPane.ERROR_MESSAGE);
    }
    protected void ProduceFlightReceipt(ArrayList<FlightEntity> flight, ItineraryEntity itinerary, CustomerEntity customer){
        agentBorder.getReportFrame().setTitle("Customer Receipt");
        NumberFormat numForm = NumberFormat.getCurrencyInstance();
        String flightReceipt = "-----------FLIGHT RECEIPT------------------\n";
        flightReceipt += "Customer Name: ";
        flightReceipt += customer.getName() + "\n";
        flightReceipt += "Address: ";
        flightReceipt += customer.getAddress() + "\n";
        flightReceipt += "Phone Number: ";
        flightReceipt += customer.getPhoneNumber() + "\n";
        flightReceipt += "Email Address: ";
        flightReceipt += customer.getEmailAddress() + "\n";
        flightReceipt += "Departure City: ";
        flightReceipt += itinerary.getDepartureCity() + "\n";
        flightReceipt += "Arrival City: ";
        flightReceipt += itinerary.getArrivalCity() + "\n";
        for(FlightEntity leg: flight){
        flightReceipt += "Departure Date: ";
        flightReceipt += leg.getDepartureTime().getTime().toString() + "\n";
        flightReceipt += "Arrival Date: ";
        flightReceipt += leg.getArrivalTime().getTime().toString() + "\n";
        flightReceipt += "Origin Airport: ";
        flightReceipt += leg.getOriginAirport() + "\n";
        flightReceipt += "Destination Airport: ";
        flightReceipt += leg.getDestinationAirport() + "\n";
        flightReceipt += "Total Flight Time: ";
        String hour = String.valueOf((int) (leg.getTravelTime() * 60.0)/60);
        String min = String.valueOf((int) (leg.getTravelTime() * 60.0)%60);
        flightReceipt += hour + "hr(s) and " + min + " min(s)\n";
        }
        for(String name: agentBorder.getNamesOfTravelersList().getItems()){
            flightReceipt += name + " ";
        }
        flightReceipt += "\nCredit Card Holder's Name: ";
        flightReceipt += itinerary.getCreditCard().getHolderName() + "\n";
        flightReceipt += "Credit Card Type: ";
        flightReceipt += itinerary.getCreditCard().getCardType() + "\n";
        flightReceipt += "Credit Card Last 4: ";
        flightReceipt += itinerary.getCreditCard().getCardNumber().subSequence(itinerary.getCreditCard().getCardNumber().length()-4, itinerary.getCreditCard().getCardNumber().length()) + "\n";
        flightReceipt += "Credit Card Expiration Date: ";
        flightReceipt += itinerary.getCreditCard().getExpirationDate().getTime().toString() + "\n";
        flightReceipt +="------------------------------------------------\n";
        flightReceipt += "Total Cost: ";
        flightReceipt += numForm.format(flight.get(0).getTotalCost()) + "\n";
        
       int width=450, height=650;
       Toolkit toolkit =  Toolkit.getDefaultToolkit();
       Dimension dim = toolkit.getScreenSize();
       agentBorder.getReportFrame().setBounds((dim.width - width)/2, (dim.height - height)/2, width, height);
        agentBorder.getPrintTextArea().setText(flightReceipt);
        agentBorder.getReportFrame().setVisible(true);
    }
    

    protected void AddCredit(double creditAmount, int customerID){
        if(creditAmount < 5 || creditAmount >0){
            try{
                eflDatabase.getCustomers().get(customerID).setAccountCredit(eflDatabase.getCustomers().get(customerID).getAccountCredit() + creditAmount);
            } catch (NumberFormatException e) {
                  JOptionPane.showMessageDialog(null, e.getMessage(), "Fee Error!", JOptionPane.INFORMATION_MESSAGE); 
            }
        }else{
            JOptionPane.showMessageDialog(agentBorder, "Incorrect Amount please insert a number between a range of 0 - 5", "Invalid Entry!", JOptionPane.ERROR_MESSAGE);
        }
    }
}

