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
public class CreditCardEntity {
    private String holderName;
    private String cardType;
    private String cardNumber;
    private GregorianCalendar expirationDate;
    private String csvNumber;
    private String billingAddress;
    
    CreditCardEntity(){
        
    }
    
    CreditCardEntity(String holderName, String cardType,String cardNumber, GregorianCalendar expirationDate, String csvNumber, String billingAddress){
        this.billingAddress = billingAddress;
        this.cardNumber = cardNumber;
        this.cardType = cardType;
        this.csvNumber = csvNumber;
        this.expirationDate = expirationDate;
        this.holderName = holderName;
        
    }

    /**
     * @return the holderName
     */
    public String getHolderName() {
        return holderName;
    }

    /**
     * @param holderName the holderName to set
     */
    public void setHolderName(String holderName) {
        this.holderName = holderName;
    }

    /**
     * @return the cardType
     */
    public String getCardType() {
        return cardType;
    }

    /**
     * @param cardType the cardType to set
     */
    public void setCardType(String cardType) {
        this.cardType = cardType;
    }

    /**
     * @return the cardNumber
     */
    public String getCardNumber() {
        return cardNumber;
    }

    /**
     * @param cardNumber the cardNumber to set
     */
    public void setCardNumber(String cardNumber) {
        this.cardNumber = cardNumber;
    }

    /**
     * @return the expirationDate
     */
    public GregorianCalendar getExpirationDate() {
        return expirationDate;
    }

    /**
     * @param expirationDate the expirationDate to set
     */
    public void setExpirationDate(GregorianCalendar expirationDate) {
        this.expirationDate = expirationDate;
    }

    /**
     * @return the csvNumber
     */
    public String getCsvNumber() {
        return csvNumber;
    }

    /**
     * @param csvNumber the csvNumber to set
     */
    public void setCsvNumber(String csvNumber) {
        this.csvNumber = csvNumber;
    }

    /**
     * @return the billingAddress
     */
    public String getBillingAddress() {
        return billingAddress;
    }

    /**
     * @param billingAddress the billingAddress to set
     */
    public void setBillingAddress(String billingAddress) {
        this.billingAddress = billingAddress;
    }
    
}
