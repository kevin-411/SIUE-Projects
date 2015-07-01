/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

import java.awt.Dimension;
import java.awt.Toolkit;
import java.text.NumberFormat;
import javax.swing.JOptionPane;
import javax.xml.bind.ValidationException;

/**
 * @author Brian
 * @author Brendan
 * @author Lindsey
 */
public class ManagerControl extends AgentControl {
    private CRATD cratd;
    
    ManagerControl(){
        cratd = CRATD.getInstance();
        agentBorder.setListenersForManagerControl(this);
    }
    public void createAgentButtonActionPerformed(java.awt.event.ActionEvent evt) {
        boolean openLocationInAgentArray=false;

        if(verifyFieldsFor("Agent")){
            
            AgentEntity newAgent = new AgentEntity(String.valueOf(eflDatabase.getAgents().size()),
                    agentBorder.getAgentPasswordField().getText(),
                    agentBorder.getAgentIsManagerCheckBox().isSelected(),
                    agentBorder.getAgentFirstNameField().getText() + " " + agentBorder.getAgentLastNameField().getText(),                               agentBorder.getAgentAddressField().getText(), 
                    agentBorder.getAgentEmailAddressField().getText(), 
                    agentBorder.getAgentPhoneNumberField().getText());
                    
                for(AgentEntity agent: eflDatabase.getAgents()){
                    if(agent.getName().equals("")){
                        newAgent.setAgentID(agent.getAgentID());
                        eflDatabase.getAgents().set(Integer.parseInt(agent.getAgentID()), newAgent);
                        agentBorder.getAgentIDField1().setText(String.valueOf(agent.getAgentID()));
                        openLocationInAgentArray=true;
                        break;
                    }
                }
                if(!openLocationInAgentArray){
                    agentBorder.getAgentIDField1().setText(String.valueOf(eflDatabase.getAgents().size()));
                    newAgent.setAgentID(String.valueOf(eflDatabase.getAgents().size()));
                    eflDatabase.getAgents().add(newAgent);
                }
             JOptionPane.showMessageDialog(null, "Successful Creation of Agent Account!!", "Agent Account Creation!", JOptionPane.INFORMATION_MESSAGE);
        
        changeEnabledFor("Agent");
        }
        
    }

    public void modifyAgentButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(verifyFieldsFor("Agent")){
            AgentEntity newAgent = new AgentEntity(String.valueOf(eflDatabase.getAgents().size()),
                    agentBorder.getAgentPasswordField().getText(),
                    agentBorder.getAgentIsManagerCheckBox().isSelected(),
                    agentBorder.getAgentFirstNameField().getText() + " " + agentBorder.getAgentLastNameField().getText(),                                agentBorder.getAgentAddressField().getText(), 
                    agentBorder.getAgentEmailAddressField().getText(), 
                    agentBorder.getAgentPhoneNumberField().getText());
            
            eflDatabase.getAgents().set(Integer.parseInt(agentBorder.getAgentIDField1().getText()), newAgent);
             JOptionPane.showMessageDialog(null, "Successful Updated the Agent Account!!", "Agent Account Updated!", JOptionPane.INFORMATION_MESSAGE);
        }
    }

    public void deleteAgentButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(agentBorder.getAgentIDField1().getText().equals("")){
            JOptionPane.showMessageDialog(null, "Please insert the agent id of the agent you wish to terminate into the Agent ID Field!!", "Missing Agent ID!", JOptionPane.ERROR_MESSAGE);
        }
        eflDatabase.getAgents().set(Integer.parseInt(agentBorder.getAgentIDField1().getText()), new AgentEntity());
        clearAgentButtonActionPerformed(evt);
        JOptionPane.showMessageDialog(null, "Successful Deleted the Agent Account!!", "Agent Account Deleted!", JOptionPane.INFORMATION_MESSAGE);
        
    }

    public void clearAgentButtonActionPerformed(java.awt.event.ActionEvent evt) {
        UpdateAgentFields(new AgentEntity(null,null,false,null,null,null,null));
        changeEnabledFor("Agent");
    }
    public void agentSearchButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(agentBorder.getAgentIDField1().getText().equals("")){
            JOptionPane.showMessageDialog(null, "Please insert the agent id of the agent you wish to terminate into the Agent ID Field!!", "Missing Agent ID!", JOptionPane.ERROR_MESSAGE);
            return;
        }else if (eflDatabase.getAgents().get(Integer.parseInt(agentBorder.getAgentIDField1().getText())).getAgentID()==null){
        JOptionPane.showMessageDialog(null, "Agent Doesn't Exist!!", "Agent Doesn't Exist!", JOptionPane.ERROR_MESSAGE);
        return;
        }
        UpdateAgentFields(eflDatabase.getAgents().get(Integer.parseInt(agentBorder.getAgentIDField1().getText())));
        if(agentBorder.getCreateAgentButton().isEnabled()){
            changeEnabledFor("Agent");
        }
    }
    private void UpdateAgentFields(AgentEntity newAgent){
        if(newAgent.getName()==null){
            agentBorder.getAgentFirstNameField().setText("");
            agentBorder.getAgentLastNameField().setText("");
        }else{
            String[] name = newAgent.getName().split(" ");
            agentBorder.getAgentFirstNameField().setText(name[0]);
            agentBorder.getAgentLastNameField().setText(name[1]);
           
            }
           agentBorder.getAgentPasswordField().setText(newAgent.getPassword());
           agentBorder.getAgentIDField().setText(newAgent.getAgentID());
           agentBorder.getAgentIsManagerCheckBox().setSelected(newAgent.isaManager());
           agentBorder.getAgentAddressField().setText(newAgent.getAddress());
           agentBorder.getAgentEmailAddressField().setText(newAgent.getEmailAddress());
           agentBorder.getAgentPhoneNumberField().setText(newAgent.getPhoneNumber());
        }
    private void changeEnabledFor(String Choice){
        switch(Choice){
            case "Agent":
                if(agentBorder.getCreateAgentButton().isEnabled()){
                    agentBorder.getCreateAgentButton().setEnabled(false);
                    agentBorder.getModifyAgentButton().setEnabled(true);
                    agentBorder.getDeleteAgentButton().setEnabled(true);
                    agentBorder.getClearAgentButton().setEnabled(true);
                }
                else{
                    agentBorder.getCreateAgentButton().setEnabled(true);
                    agentBorder.getModifyAgentButton().setEnabled(false);
                    agentBorder.getDeleteAgentButton().setEnabled(false);
                    agentBorder.getClearAgentButton().setEnabled(false);
                } break;
        }
        
    }
    private boolean verifyFieldsFor(String choice){
        switch(choice){
            case "Agent":
                if (agentBorder.getAgentIDField().getText().equals("") ||
                    agentBorder.getAgentFirstNameField().getText().equals("") ||
                    agentBorder.getAgentLastNameField().getText().equals("") ||
                    agentBorder.getAgentPasswordField().getText().equals("") ||
                    agentBorder.getAgentAddressField().getText().equals("") ||
                    agentBorder.getAgentEmailAddressField().getText().equals("") ||
                    agentBorder.getAgentPhoneNumberField().getText().equals("")){
                    return false;
                }
                break;
        }
        return true;
           
    } 
    
    public void getUpdatesFromCRATDButtonActionPerformed(java.awt.event.ActionEvent evt) {
        cratd.getCRATDUpdates();
        JOptionPane.showMessageDialog(null, "You have successfully updated the local repository from the CRATD!!", "Successful CRATD Update!", JOptionPane.INFORMATION_MESSAGE);
        for(AirportEntity airport:eflDatabase.getAirports()){
        agentBorder.getDepartureCityComboBox().addItem(airport.getNameOfAirport());
        }
        agentBorder.getDepartureCityComboBox().setSelectedItem(null);
        
    }
    public void submitServiceFeeButtonActionPerformed(java.awt.event.ActionEvent evt) {
        if(!agentBorder.getServiceFeeField().getText().equals("")){
            try {
                eflDatabase.setFee(Double.parseDouble(agentBorder.getServiceFeeField().getText()));
            } catch (NumberFormatException e) {
                  JOptionPane.showMessageDialog(null, e.getMessage(), "Fee Error!", JOptionPane.INFORMATION_MESSAGE); 
                  return;
            }
        }
        agentBorder.getServiceFeeField().setText("");
        JOptionPane.showMessageDialog(null, "You have successfully updated the service fee!!", "Successful service fee Update!", JOptionPane.INFORMATION_MESSAGE);
    }
    public void produceDailyReportActionPerformed(java.awt.event.ActionEvent evt) {
        ProduceDailyReport();
    }
    private void ProduceDailyReport(){
        agentBorder.getReportFrame().setTitle("Daily Report");
        String dailyReport = "";
        dailyReport = ProduceContactReport();
        dailyReport += "\n";
        dailyReport += ProduceFinancialReport();
        int width=450, height=650;
        
       Toolkit toolkit =  Toolkit.getDefaultToolkit();
       Dimension dim = toolkit.getScreenSize();
       agentBorder.getReportFrame().setBounds((dim.width - width)/2, (dim.height - height)/2, width, height);
       agentBorder.getPrintTextArea().setText(dailyReport);
       agentBorder.getReportFrame().setVisible(true);
    }
    
    private String ProduceContactReport(){
        String contactReport = "";
        contactReport += "----------------- Daily Contact Report-------------------------\n";
        contactReport += "Number of customers serviced: ";
        contactReport += eflDatabase.getReport().getCustomersServiced().size() + "\n";
        contactReport += "Number of customers gained: ";
        contactReport += eflDatabase.getReport().getNumberOfNewCustomers() + "\n";
        contactReport += "Number of reservations made: ";
        contactReport += eflDatabase.getReport().getNumberOfReservations() + "\n";
        contactReport += "Number of cancellations gained: ";
        contactReport += eflDatabase.getReport().getNumberOfCancelations() + "\n";
        contactReport += "Number of price watches started: ";
        contactReport += eflDatabase.getReport().getNumberOfWatchesStarted() + "\n";
        contactReport += "Number of price watches cancelled: ";
        contactReport += eflDatabase.getReport().getNumberOfCancelations() + "\n";
        return contactReport;
    }
    
    private String ProduceFinancialReport(){
        NumberFormat numForm = NumberFormat.getCurrencyInstance();
        String financialReport = "";
        financialReport += "----------------- Daily Financial Report-------------------------\n";
        financialReport += "Number of service fees assessed: ";
        financialReport += eflDatabase.getReport().getNumberOfServiceFees() + "\n";
        financialReport += "Cost Per Fee: ";
        financialReport += numForm.format(eflDatabase.getFee()) + "\n";
        financialReport += "Total income for the day: ";
        financialReport += numForm.format(eflDatabase.getReport().getTotalIncome()) + "\n";
       
        return financialReport;
    }

    /**
     * @return the cratd
     */
    public CRATD getCratd() {
        return cratd;
    }

    /**
     * @param cratd the cratd to set
     */
    public void setCratd(CRATD cratd) {
        this.cratd = cratd;
    }
}
