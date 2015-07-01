package com.database;

import java.sql.SQLException;

import com.database.queries.DeleteQuery;
import com.database.queries.InsertQuery;
import com.database.queries.SelectQuery;
import com.database.queries.UpdateQuery;

/**
 * DatabaseFacade is a Singleton to avoid multiple queries to the database and holds all the needed
 * database interaction functionality in a single class.
 */
public class DatabaseFacade {
    private static DeleteQuery delete;
    private static InsertQuery insert;
    private static SelectQuery select;
    private static UpdateQuery update;
    private static DatabaseFacade instance = null;

    private DatabaseFacade() throws SQLException {
        delete = new DeleteQuery();
        insert = new InsertQuery();
        select = new SelectQuery();
        update = new UpdateQuery();
    }

    public static DatabaseFacade getInstance() throws SQLException {
        if (instance == null) {
            instance = new DatabaseFacade();
        }
        return instance;

    }

    /**
     * @return the delete
     */
    public static DeleteQuery getDelete() {
        return delete;
    }

    /**
     * @param delete the delete to set
     */
    public static void setDelete(DeleteQuery delete) {
        DatabaseFacade.delete = delete;
    }

    /**
     * @return the insert
     */
    public static InsertQuery getInsert() {
        return insert;
    }

    /**
     * @param insert the insert to set
     */
    public static void setInsert(InsertQuery insert) {
        DatabaseFacade.insert = insert;
    }

    /**
     * @return the select
     */
    public static SelectQuery getSelect() {
        return select;
    }

    /**
     * @param select the select to set
     */
    public static void setSelect(SelectQuery select) {
        DatabaseFacade.select = select;
    }

    /**
     * @return the update
     */
    public static UpdateQuery getUpdate() {
        return update;
    }

    /**
     * @param update the update to set
     */
    public static void setUpdate(UpdateQuery update) {
        DatabaseFacade.update = update;
    }


}
