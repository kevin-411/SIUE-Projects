package introductory.project;

/**
 *
 * @author Bryan Allen
 */
public class OutputDialog extends javax.swing.JFrame
{
    private static String signature = "// VOID //";
    private static String routingNum = "1234567890";
    private static String accNum = "325001033631";
    private static String teamName= "Let's Hope This Works";
    private static String project = "Intro Project 1";
    public OutputDialog(){
        initComponents();
    }
    public void setLabels(String name,String memo,String amount, int checkNumber, String dollarAmount){
	Processor proc = new Processor();
        checkNum1Label.setText(Integer.toString(checkNumber));
        checkNum2Label.setText(checkNum1Label.getText());
	dateLabel.setText(proc.GetDate());
        payeeLabel.setText(name);
        numericalAmountLabel.setText(amount);
        textAmountLabel.setText(dollarAmount);
        memoLabel.setText(memo);
        signatureLabel.setText(signature);
        routingNumLabel.setText(routingNum);
        accountNumLabel.setText(accNum);
        teamNameLabel.setText(teamName);
        projectLabel.setText(project);
	setTitle("Check #"+checkNum1Label.getText());
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        teamNameLabel = new javax.swing.JLabel();
        projectLabel = new javax.swing.JLabel();
        dateLabel = new javax.swing.JLabel();
        payeeLabel = new javax.swing.JLabel();
        numericalAmountLabel = new javax.swing.JLabel();
        textAmountLabel = new javax.swing.JLabel();
        memoLabel = new javax.swing.JLabel();
        signatureLabel = new javax.swing.JLabel();
        routingNumLabel = new javax.swing.JLabel();
        accountNumLabel = new javax.swing.JLabel();
        checkNum1Label = new javax.swing.JLabel();
        checkNum2Label = new javax.swing.JLabel();
        siueLabel = new javax.swing.JLabel();
        BackgroundImg = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Check");
        setForeground(java.awt.Color.white);
        setIconImages(null);
        setLocationByPlatform(true);
        setMinimumSize(new java.awt.Dimension(653, 318));
        setResizable(false);
        getContentPane().setLayout(null);

        teamNameLabel.setFont(new java.awt.Font("Verdana", 1, 12)); // NOI18N
        teamNameLabel.setText("Let's Hope This Works");
        getContentPane().add(teamNameLabel);
        teamNameLabel.setBounds(30, 30, 180, 20);

        projectLabel.setFont(new java.awt.Font("Verdana", 1, 12)); // NOI18N
        projectLabel.setText("Intro Project 1");
        getContentPane().add(projectLabel);
        projectLabel.setBounds(30, 50, 200, 16);

        dateLabel.setFont(new java.awt.Font("Times New Roman", 0, 18)); // NOI18N
        dateLabel.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        dateLabel.setVerticalAlignment(javax.swing.SwingConstants.BOTTOM);
        getContentPane().add(dateLabel);
        dateLabel.setBounds(370, 60, 150, 20);

        payeeLabel.setFont(new java.awt.Font("Verdana", 2, 18)); // NOI18N
        payeeLabel.setVerticalAlignment(javax.swing.SwingConstants.BOTTOM);
        getContentPane().add(payeeLabel);
        payeeLabel.setBounds(90, 94, 390, 30);

        numericalAmountLabel.setFont(new java.awt.Font("Times New Roman", 0, 18)); // NOI18N
        getContentPane().add(numericalAmountLabel);
        numericalAmountLabel.setBounds(520, 110, 100, 20);

        textAmountLabel.setFont(new java.awt.Font("Verdana", 2, 18)); // NOI18N
        textAmountLabel.setVerticalAlignment(javax.swing.SwingConstants.BOTTOM);
        getContentPane().add(textAmountLabel);
        textAmountLabel.setBounds(30, 130, 540, 30);

        memoLabel.setFont(new java.awt.Font("Verdana", 2, 24)); // NOI18N
        memoLabel.setVerticalAlignment(javax.swing.SwingConstants.BOTTOM);
        getContentPane().add(memoLabel);
        memoLabel.setBounds(60, 210, 240, 30);

        signatureLabel.setFont(new java.awt.Font("Verdana", 2, 24)); // NOI18N
        signatureLabel.setVerticalAlignment(javax.swing.SwingConstants.BOTTOM);
        getContentPane().add(signatureLabel);
        signatureLabel.setBounds(350, 210, 270, 30);

        routingNumLabel.setFont(new java.awt.Font("Times New Roman", 0, 22)); // NOI18N
        getContentPane().add(routingNumLabel);
        routingNumLabel.setBounds(50, 250, 110, 20);

        accountNumLabel.setFont(new java.awt.Font("Times New Roman", 0, 22)); // NOI18N
        getContentPane().add(accountNumLabel);
        accountNumLabel.setBounds(180, 250, 160, 20);

        checkNum1Label.setFont(new java.awt.Font("Times New Roman", 0, 22)); // NOI18N
        getContentPane().add(checkNum1Label);
        checkNum1Label.setBounds(530, 20, 90, 20);

        checkNum2Label.setFont(new java.awt.Font("Times New Roman", 0, 22)); // NOI18N
        getContentPane().add(checkNum2Label);
        checkNum2Label.setBounds(380, 250, 80, 20);

        siueLabel.setFont(new java.awt.Font("Verdana", 0, 11)); // NOI18N
        siueLabel.setText("Southern Illinois University Edwardsville");
        getContentPane().add(siueLabel);
        siueLabel.setBounds(30, 160, 370, 20);

        BackgroundImg.setIcon(new javax.swing.ImageIcon(getClass().getResource("/introductory/project/check.jpg"))); // NOI18N
        getContentPane().add(BackgroundImg);
        BackgroundImg.setBounds(0, 0, 650, 290);
        BackgroundImg.getAccessibleContext().setAccessibleName("jLabel1");

        pack();
    }// </editor-fold>//GEN-END:initComponents

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel BackgroundImg;
    private javax.swing.JLabel accountNumLabel;
    private javax.swing.JLabel checkNum1Label;
    private javax.swing.JLabel checkNum2Label;
    private javax.swing.JLabel dateLabel;
    private javax.swing.JLabel memoLabel;
    private javax.swing.JLabel numericalAmountLabel;
    private javax.swing.JLabel payeeLabel;
    private javax.swing.JLabel projectLabel;
    private javax.swing.JLabel routingNumLabel;
    private javax.swing.JLabel signatureLabel;
    private javax.swing.JLabel siueLabel;
    private javax.swing.JLabel teamNameLabel;
    private javax.swing.JLabel textAmountLabel;
    // End of variables declaration//GEN-END:variables
}
