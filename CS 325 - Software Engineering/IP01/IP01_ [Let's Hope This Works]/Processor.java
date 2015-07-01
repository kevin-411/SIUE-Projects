/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package processor;

/**
 *
 * @author dhoots
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
       length = stringDigit.length();
       double exp;
       String[] digitNames = {"", "one", "two,", "three", "four", "five", "six", "seven", "eight", "nine"};
       String[] specialTens = {"", "ten", "twenty", "thirty", "", "fifty"};
       String[] teens = {"", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
       
       if(count<length)
       {   
           convert(amount, stringDigit, count+1);
           if(count==0)
           {
               if((stringDigit.charAt(count)=='1')&&(stringDigit.charAt(count+1)!='0'))
               {
                 amountText = teens[(int)(amount/10000)] + amountText;
               }
               else if(((stringDigit.charAt(count)=='1')||(stringDigit.charAt(count)=='2')||(stringDigit.charAt(count)=='3')||stringDigit.charAt(count)=='5')&&(stringDigit.charAt(count-1)=='0'))
               {
                 amountText = specialTens[(int)(amount/10000)] + amountText;
               }
               else
               {
                 amountText = digitNames[(int)(amount/10000)] + "ty " + amountText;
               }
           } 
           else if(count==1)
           {
               exp = Math.pow(10, count+3);
               amountText = digitNames[(int)((amount%exp)/1000)] + " thousand " + amountText;
           }
           //handles all of the tens special cases and teens  
           else if(count==2)
           {
               exp = Math.pow(10, count+1);
               amountText = digitNames[(int)((amount%exp)/100)] + " hundred " + amountText;
           }
           else if(count==3)
           {
               exp = Math.pow(10, count-1);
               if(((stringDigit.charAt(count)=='1')||(stringDigit.charAt(count)=='2')||(stringDigit.charAt(count)=='3')||(stringDigit.charAt(count)=='5'))&&(stringDigit.charAt(count-1)=='0'))
               { 
                 amountText = specialTens[(int)((amount%exp)/10)] + amountText;
               }
               else if ((stringDigit.charAt(count)=='1')&&(stringDigit.charAt(count+1)!='0'))
               {
                   amountText = teens[(int)((amount%exp)/10)] + amountText;
               }
               else
               {
                 amountText = digitNames[(int)((amount%exp)/10)] + "ty " + amountText;
               }
           }
           else if(count==4)
           {
             amountText = digitNames[(int)((amount%10))] + " " + amountText;
           }
           //adds the word 'hundred' to the end of the hundreds place
           else if(stringDigit.charAt(count)=='.')
           {
             amountText = amountText + stringDigit.charAt(count+1) + stringDigit.charAt(count+2)+"/100";
           }    
            
       }
               
    }
    
    //This was working and I had some family things to take care of so it is entirely my fault that this wasnt completed 
    //hopefully this wont penalize my teamates too much missed the full implementation by just a few hours just wanted to let
    //you know as a courtesy to my teamates
    
    /**
     * @param args the command line arguments
     */
   /* public static void main(String[] args) {
        Processor p1 = new Processor();
        double test = 35345.55;
       
        
        p1.convert(test, "35345.55", 0);
        
        System.out.println(p1.getAmountString());
        // TODO code application logic here
    }
}*/
