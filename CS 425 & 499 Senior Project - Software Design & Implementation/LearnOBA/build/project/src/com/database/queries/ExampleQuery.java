// package com.database.queries;
//
// import java.sql.ResultSet;
// import java.sql.ResultSetMetaData;
// import java.sql.SQLException;
// import java.util.ArrayList;
// import java.util.Arrays;
// import java.util.List;
//
// import com.database.AbstractQuery;
// import com.database.DatabaseFacade;
// import com.database.QueryTestHelper;
// import com.learnoba.models.*;
//
// public class ExampleQuery extends AbstractQuery {
// private DatabaseFacade facade;
// private QueryTestHelper helper;
// private static List<String> tableNames = new ArrayList<String>(Arrays.asList("class_table",
// "student_class_association_table",
// "student_table", "assignment_table", "task_table", "skill_table", "outcome_table",
// "users_table"));
//
// public ExampleQuery() throws SQLException {
// super();
// facade = DatabaseFacade.getInstance();
// helper = QueryTestHelper.getInstance();
// }
//
// private static ResultSet resultSet;
//
// public static void main(String[] args) throws ClassNotFoundException, SQLException {
// Class.forName("org.sqlite.JDBC");
// ExampleQuery ex = new ExampleQuery();
// ex.dostuff();
// }
//
// // Here's where you guys can perform different queries
// // deleteEverything - clears the database and reinserts the default values that must be in the
// // database in the beginning.
// // insertStuffIntoTheDatabase - puts values from QueryTestHelper into all the tables so there's
// // junk data in there.
// // print Stuff - gives you a pretty snap shot of what's in all the database tables.
// //
// // WARNING - if Matt makes changes to the database him or myself needs to update this class!!
// // 1) If there is a new table added
// // 1.a) Add the name of the table to the tableNames array list
// // 1.b) Update the insert statement
// // 2) If you change an attribute i.e. getting rid of skills_count in task table like we planned
// // 2.a) Update it in the InsertQuery or this will fail.
// public void dostuff() throws SQLException {
// deleteEverything();
// insertStuffIntoTheDatabase();
// printStuff();
// }
//
// private void printStuff() {
// String selectQuery;
// try {
// for (String tableName : tableNames) {
// System.out.println("********" + tableName + "********");
// selectQuery = "SELECT * FROM ".concat(tableName);
// resultSet = getStatement().executeQuery(selectQuery);
// while (resultSet.next()) {
// ResultSetMetaData rsmd = resultSet.getMetaData();
// System.out.println("Row Number: " + String.valueOf(resultSet.getRow()));
// for (int i = 1; i <= rsmd.getColumnCount(); i++) {
// System.out.print(rsmd.getColumnName(i) + ": ");
// System.out.println(String.valueOf(resultSet.getObject(i)));
// }
// System.out.println("\n");
// }
// System.out.println("\n");
// }
// } catch (SQLException e) {
// e.printStackTrace();
// }
// }
//
// private void insertStuffIntoTheDatabase() {
// try {
// for (User user : helper.createUsers()) {
// facade.getInsert().insertUser(user);
// }
//
// for (BasicClass clas : helper.createClasses()) {
// facade.getInsert().insertClass(clas);
// }
// for (Student student : helper.createStudents()) {
// // for (BasicClass clas : helper.createClasses()) {
// facade.getInsert().insertStudentClass(student, 1);
// // }
// }
//
// for (Assignment assignment : helper.createAssignments()) {
// facade.getInsert().insertAssignment(assignment);
// }
//
// for (Skill skill : helper.createSkills()) {
//
// facade.getInsert().insertSkill(skill);
// for (Skill child : skill.getSkills()) {
// facade.getInsert().insertSkill(child);
// }
// }
// for (Task task : helper.createTasks()) {
// facade.getInsert().insertTask(task);
// }
// List<Outcome> outcomes = helper.createOutcomes();
// for (Outcome outcome : outcomes) {
// facade.getInsert().insertOutcomes(outcome);
// }
//
// } catch (SQLException e) {
// e.printStackTrace();
// }
// }
//
// private void selectStuffFromTheDatabase() {
// String selectQuery =
// "SELECT class_id, semester, calander_year, class_name, max_score FROM class_table";
// try {
// resultSet = getStatement().executeQuery(selectQuery);
// } catch (SQLException e) {
// e.printStackTrace();
// }
// }
//
// private void deleteEverything() {
// for (String tableName : tableNames) {
// String deleteQuery = "DELETE FROM ".concat(tableName);
// try {
// getStatement().executeUpdate(deleteQuery);
// } catch (SQLException e) {
// e.printStackTrace();
// }
// }
// String defaultInsert =
// "INSERT INTO users_table (user_id, user_name, user_password) VALUES (0, '','');"
// +
// "INSERT INTO class_table (class_id, user_id, semester, calander_year, class_name, max_score)"
// +
// "VALUES (0, 0, '', 0, '', 0);"
// +
// "INSERT INTO skill_table (skill_id, skill_name, prefilled_outcome_value, class_id, parent_id)"
// +
// "VALUES (-1, '', 0, 0, -1);";
// try {
// getStatement().executeUpdate(defaultInsert);
// } catch (SQLException e) {
// e.printStackTrace();
// }
// }
// }
