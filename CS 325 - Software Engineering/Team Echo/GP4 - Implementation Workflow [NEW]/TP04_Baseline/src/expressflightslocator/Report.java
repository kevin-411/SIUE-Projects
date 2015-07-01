/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package expressflightslocator;

import java.util.ArrayList;
import java.util.GregorianCalendar;

/**
 *
 * @author Brian
 */
public class Report {
    private int numberOfServiceFees;
    private GregorianCalendar currentDay;
    private double totalIncome;
    private ArrayList<Integer> customersServiced = new ArrayList<>();
    private int numberOfNewCustomers;
    private int numberOfReservations;
    private int numberOfCancelations;
    private int numberOfWatchesStarted;
    private int numberOfWatchesCancelled;

    /**
     * @return the numberOfServiceFees
     */
    public int getNumberOfServiceFees() {
        return numberOfServiceFees;
    }

    /**
     * @param numberOfServiceFees the numberOfServiceFees to set
     */
    public void setNumberOfServiceFees(int numberOfServiceFees) {
        this.numberOfServiceFees = numberOfServiceFees;
    }

    /**
     * @return the totalIncome
     */
    public double getTotalIncome() {
        return totalIncome;
    }

    /**
     * @param totalIncome the totalIncome to set
     */
    public void setTotalIncome(double totalIncome) {
        this.totalIncome = totalIncome;
    }

    /**
     * @return the numberOfNewCustomers
     */
    public int getNumberOfNewCustomers() {
        return numberOfNewCustomers;
    }

    /**
     * @param numberOfNewCustomers the numberOfNewCustomers to set
     */
    public void setNumberOfNewCustomers(int numberOfNewCustomers) {
        this.numberOfNewCustomers = numberOfNewCustomers;
    }

    /**
     * @return the numberOfReservations
     */
    public int getNumberOfReservations() {
        return numberOfReservations;
    }

    /**
     * @param numberOfReservations the numberOfReservations to set
     */
    public void setNumberOfReservations(int numberOfReservations) {
        this.numberOfReservations = numberOfReservations;
    }

    /**
     * @return the numberOfCancelations
     */
    public int getNumberOfCancelations() {
        return numberOfCancelations;
    }

    /**
     * @param numberOfCancelations the numberOfCancelations to set
     */
    public void setNumberOfCancelations(int numberOfCancelations) {
        this.numberOfCancelations = numberOfCancelations;
    }

    /**
     * @return the numberOfWatchesStarted
     */
    public int getNumberOfWatchesStarted() {
        return numberOfWatchesStarted;
    }

    /**
     * @param numberOfWatchesStarted the numberOfWatchesStarted to set
     */
    public void setNumberOfWatchesStarted(int numberOfWatchesStarted) {
        this.numberOfWatchesStarted = numberOfWatchesStarted;
    }

    /**
     * @return the numberOfWatchesCancelled
     */
    public int getNumberOfWatchesCancelled() {
        return numberOfWatchesCancelled;
    }

    /**
     * @param numberOfWatchesCancelled the numberOfWatchesCancelled to set
     */
    public void setNumberOfWatchesCancelled(int numberOfWatchesCancelled) {
        this.numberOfWatchesCancelled = numberOfWatchesCancelled;
    }

    /**
     * @return the customersServiced
     */
    public ArrayList<Integer> getCustomersServiced() {
        return customersServiced;
    }

    /**
     * @param customersServiced the customersServiced to set
     */
    public void setCustomersServiced(ArrayList<Integer> customersServiced) {
        this.customersServiced = customersServiced;
    }

    /**
     * @return the currentDay
     */
    public GregorianCalendar getCurrentDay() {
        return currentDay;
    }

    /**
     * @param currentDay the currentDay to set
     */
    public void setCurrentDay(GregorianCalendar currentDay) {
        this.currentDay = currentDay;
    }
    
}
