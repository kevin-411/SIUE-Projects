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
public class ExpressFlightsLocator {
    
private static ManagerControl managerControl;
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList<AgentEntity> defaultAgents;
        defaultAgents = new ArrayList<>(); 
        defaultAgents.add(fabricateDefaultManager());
        defaultAgents.add(fabricateDefaultAgent());
        managerControl = new ManagerControl();
        managerControl.getEflDatabase().setAgents(defaultAgents);
        managerControl.getEflDatabase().setCustomers(fabricateDummyCustomers());
    }
    private static AgentEntity fabricateDefaultManager(){
        AgentEntity agent = new AgentEntity();
        agent.setAddress("123 Simpleton Ln.\n Wannahockaloogi, IL 94586" );
        agent.setName("Lindsey Shelton");
        agent.setPhoneNumber("1234567890");
        agent.setAgentID("0");
        agent.setPassword("root");
        agent.setaManager(true);
    return agent;
    }
    private static AgentEntity fabricateDefaultAgent(){
        AgentEntity agent = new AgentEntity();
        agent.setAddress("5309 Tommy Ln.\n Ilovethatsongville, IL 86753" );
        agent.setName("Jenny Tutone");
        agent.setPhoneNumber("6188675309");
        agent.setAgentID("1");
        agent.setPassword("root");
        agent.setaManager(false);
    return agent;
    }
    private static ArrayList<CustomerEntity> fabricateDummyCustomers(){
        ArrayList<CustomerEntity> dummyCustomers = new ArrayList<>();
        CustomerEntity cust1 = managerControl.CreateCustomerAccount("0","Brian Olsen","6458 Slumpy Rd.\nWaterloo, IL 62298","bolsen@siue.edu","123456789", new CreditCardEntity("BRIAN D OLSEN JR", "MasterCard", "0123456789", new GregorianCalendar(),"578","6458 Slumpy Rd.\nWaterloo, IL 62298"));
        cust1.setItineraries(new ArrayList<ItineraryEntity>());
        cust1.getItineraries().add(new ItineraryEntity(0, "Albuquerque, New Mexico","Atlanta, Georgia",new GregorianCalendar(),new GregorianCalendar(), 0, new List(),"Cheapest Fare", new CreditCardEntity("BRIAN D OLSEN JR", "MasterCard", "0123456789", new GregorianCalendar(),"578","6458 Slumpy Rd.\nWaterloo, IL 62298"), new ArrayList<FlightEntity>()));
        
        CustomerEntity cust2 = managerControl.CreateCustomerAccount("1","Brendan Lehman","3764 Green Hill Dr.\nO'Fallon, IL 69764","blehman@siue.edu","9876543210", new CreditCardEntity("BRENDAN LEHMAN", "Visa", "346724946525", new GregorianCalendar(),"945","3764 Green Hill Dr.\nO'Fallon, IL 69764"));
        cust2.setItineraries(new ArrayList<ItineraryEntity>());
        cust2.getItineraries().add(new ItineraryEntity(0, "Albuquerque, New Mexico","Atlanta, Georgia",new GregorianCalendar(),new GregorianCalendar(), 0, new List(),"Cheapest Fare", new CreditCardEntity("BRIAN D OLSEN JR", "MasterCard", "0123456789", new GregorianCalendar(),"578","6458 Slumpy Rd.\nWaterloo, IL 62298"), new ArrayList<FlightEntity>()));
        dummyCustomers.add(cust1);
        dummyCustomers.add(cust2);
        return dummyCustomers;
    }
}
