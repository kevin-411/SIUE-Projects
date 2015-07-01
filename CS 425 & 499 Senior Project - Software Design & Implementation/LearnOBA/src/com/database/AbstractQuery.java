package com.database;

import java.io.File;
import java.net.URISyntaxException;
import java.net.URL;
import java.security.SecureRandom;
import java.sql.*;

import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;

import org.apache.commons.codec.binary.Base64;

public abstract class AbstractQuery {
    private static Connection conn;
    private static Statement stmt;
    /**
     * Use sqlQuery to hold the query being built and will hold the last called query
     */
    private String sqlQuery;
    private final int timeout = 30;
    
    // The next 3 variables are for the encryption functions
    // The higher the number of iterations the more 
    // expensive computing the hash is for us
    // and also for a brute force attack.
    private static final int iterations = 10*1024;
    private static final int saltLen = 16;
    private static final int desiredKeyLen = 256;

    public AbstractQuery() {
        URL url = getClass().getProtectionDomain().getCodeSource().getLocation();
        File myfile = null;
        try {
            myfile = new File(url.toURI());
        } catch (URISyntaxException e1) {
            e1.printStackTrace();
        }
        File dir = myfile.getParentFile();
        //uncomment me for testing
        String dBURL = dir.getAbsolutePath().concat("/resources/LearnOBA.db");
        //uncomment me for implementation
        // String dBURL = dir.getAbsolutePath().concat("/LearnOBA.db");
        final String learnOBADbUrl = "jdbc:sqlite:" + dBURL;
        connectDatabase(learnOBADbUrl);
        try {
            stmt = conn.createStatement();
            stmt.setQueryTimeout(timeout);
            setSqlQuery("PRAGMA foreign_keys = ON;");
            stmt.execute(sqlQuery);

        } catch (SQLException e) {
            e.printStackTrace();
        }
        sqlQuery = "";
    }

    /**
     * For now let's keep this private.
     * 
     * @param url
     */
    private void connectDatabase(String url) {
        try {
            conn = DriverManager.getConnection(url);
            } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    public Connection getConnection() {
        return conn;
    }

    public Statement getStatement() {
        return stmt;
    }

    /**
     * @return the sqlQuery
     */
    protected String getSqlQuery() {
        return sqlQuery;
    }

    /**
     * @param sqlQuery the sqlQuery to set
     */
    protected void setSqlQuery(String sqlQuery) {
        this.sqlQuery = sqlQuery;
    }
    
    protected void appendSqlQuery(String sqlQuery){
    	this.sqlQuery += sqlQuery;
    }
    
    // TODO: Remove this function once removed from use in DeleteQuery.java 
    protected int executeUpdates() throws SQLException{
        int i = stmt.executeUpdate(sqlQuery);
        sqlQuery = "";
        return i;

    }
    
    // TODO: Remove this function once removed from use in SelectQuery.java 
    protected ResultSet executeSelectQuery() throws SQLException{
        ResultSet res = stmt.executeQuery(sqlQuery);
        sqlQuery = "";
        return res;
       
    }
    
    //Functions to encrypt, and decrypt string fields
    // Adapted from Martin Konicek's post on StackOverflow
    // Found at: http://stackoverflow.com/questions/2860943/suggestions-for-library-to-hash-passwords-in-java
    
    /**
     * 
     * @param password
     * @return
     * @throws Exception
     * 
     * Computes a salted PBKDF2 hash of given plain text password
     * suitable for storing in a database. 
     * Empty passwords are not supported.
     */
	public static String getSaltedHash(String password) throws Exception {
	    byte[] salt = SecureRandom.getInstance("SHA1PRNG").generateSeed(saltLen);
	    // store the salt with the password
	    return Base64.encodeBase64String(salt) + "$" + hash(password, salt);
	}
	
	/**
	 * 
	 * @param password
	 * @param stored
	 * @return
	 * @throws Exception
	 * 
	 * Checks whether given plain text password corresponds 
	 * to a stored salted hash of the password.
	 */
	public static boolean check(String password, String stored) throws Exception{
	    String[] saltAndPass = stored.split("\\$");
	    if (saltAndPass.length != 2)
	        return false;
	    String hashOfInput = hash(password, Base64.decodeBase64(saltAndPass[0]));
	    return hashOfInput.equals(saltAndPass[1]);
	}
	
	// using PBKDF2 from Sun, an alternative is https://github.com/wg/scrypt
	// cf. http://www.unlimitednovelty.com/2012/03/dont-use-bcrypt.html
	private static String hash(String password, byte[] salt) throws Exception {
	    if (password == null || password.length() == 0)
	        throw new IllegalArgumentException("Empty passwords are not supported.");
	    SecretKeyFactory f = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
	    SecretKey key = f.generateSecret(new PBEKeySpec(
	        password.toCharArray(), salt, iterations, desiredKeyLen)
	    );
	    return Base64.encodeBase64String(key.getEncoded());
	}
	
	

}
