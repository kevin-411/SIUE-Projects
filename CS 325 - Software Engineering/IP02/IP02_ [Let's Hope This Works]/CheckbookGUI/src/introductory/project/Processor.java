/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package introductory.project;
import java.text.*;
import java.util.Date;

/**
 *
 * @author Darren Hoots
 */
public class Processor {
    private String stringDigit;
    private int length;
    public String amountText;
    
    public Processor(){
        length = 0;
        amountText = "";
        stringDigit = "";
    }
       
    public String getAmountString(){
        return amountText;
    }
    //converts the double number into a string of words 
    public void convert(double amount, String temp, int count){
       stringDigit = temp;
       length = stringDigit.length()-2;
       String[] digitNames = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
       String[] specialTens = {"", "ten", "twenty", "thirty", "", "fifty"};
       String[] teens = {"", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
       
       if(count<=length)
       {  
           if(count==0)
           {
                amountText = amountText + stringDigit.charAt(length-count) + stringDigit.charAt((length - count)+1)+"/100";
           } 
           else if((count==2)&&(stringDigit.charAt((length-count)-1)!='1'))
           {
                amountText = " " + digitNames[(int)((amount%10))] + " " + amountText;
           }  
           else if(count==3)
           {
               if((stringDigit.charAt(length-count)=='1')&&(stringDigit.charAt((length-count)+1)=='0'))
               { 
                 amountText = specialTens[1] + " " + amountText;
               }
               else if((stringDigit.charAt(length-count)=='2')||(stringDigit.charAt(length-count)=='3')||(stringDigit.charAt(length-count)=='5'))
               {
                     amountText = specialTens[(int)((amount%100)/10)] + amountText;      
               }
               else if((stringDigit.charAt(length-count)=='1')&&(stringDigit.charAt(length-count+1)!='0'))
               {
                   amountText = teens[(int)((amount%10))] + " " + amountText;
               }
               else
               {
                 amountText = digitNames[(int)((amount%100)/10)] + "ty " + amountText;
               }
           }
           else if(count==4)
           {
             amountText = digitNames[(int)((amount%1000)/100)] + " hundred " + amountText;
           }
           else if((count == 5)&&(length==5))
           {
               amountText = digitNames[(int)((amount%10000)/1000)] + " thousand " + amountText;
           }
           else if(count == 6)
           { 
               if((((stringDigit.charAt(length-count)=='1')&&(stringDigit.charAt((length-count)+1)=='0'))||(stringDigit.charAt(length-count)=='2')||(stringDigit.charAt(length-count)=='3')||stringDigit.charAt(length-count)=='5'))
               {
                 amountText = specialTens[(int)(amount/10000)] + " " + digitNames[(int)((amount%10000)/1000)] + " thousand " + amountText;
               }
               else if((stringDigit.charAt(length-count)=='1')&&(stringDigit.charAt(length-count)!='0'))
               {
                 amountText = teens[(int)((amount%10000)/1000)] + " thousand " + amountText;
               }
              
               else
               {
                 amountText = digitNames[(int)(amount/10000)] + "ty " + digitNames[(int)((amount%10000)/1000)] + " thousand " + amountText;
               }
           }
           convert(amount, stringDigit, count+1); 
       }
               
    }
    
    public String GetDate(){
	DateFormat dateFormat = new SimpleDateFormat("M-dd-yyyy");
	Date date = new Date();
	return(dateFormat.format(date));
    }
}