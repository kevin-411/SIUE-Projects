--SQL used to create all of the tables in the LearnOBA database

CREATE TABLE users_table
(
	user_id			INTEGER PRIMARY KEY		NOT NULL,
	user_name		CHAR(50)				NOT NULL,
	user_password	CHAR(500)				NOT NULL,
	question_text	CHAR(500)				NOT NULL,
	answer_text		CHAR(500)				NOT NULL
);

CREATE TABLE class_table
(
	class_id				INTEGER PRIMARY KEY		NOT NULL,
	user_id					INTEGER					NOT NULL,
	semester				CHAR(7) 				NOT NULL,
	calander_year			INTEGER					NOT NULL,
	class_name				CHAR(50)				NOT NULL,
	max_score				INTEGER					NOT NULL,
	last_used_timestamp		DATETIME				NOT NULL,
	FOREIGN KEY(user_id) REFERENCES users_table(user_id) ON DELETE CASCADE	
);

CREATE TABLE student_class_association_table
(
	student_class_id	INTEGER PRIMARY KEY		NOT NULL,
	class_id			INTEGER					NOT NULL,
	student_id			INTEGER					NOT NULL,
	FOREIGN KEY(class_id) REFERENCES class_table(class_id) ON DELETE CASCADE,
	FOREIGN KEY(student_id) REFERENCES student_table(student_id) ON DELETE CASCADE
);

CREATE TABLE student_table
(
	student_id			INTEGER PRIMARY KEY		NOT NULL,
	first_name			CHAR(50)				NOT NULL,
	last_name			CHAR(50)				NOT NULL,
	middle_name			CHAR(50)				NULL,
	email_address		CHAR(100)				NULL,
	student_id_code		CHAR(10)				NULL
);

CREATE TABLE assignment_table
(
	assignment_id		INTEGER PRIMARY KEY		NOT NULL,
	class_id			INTEGER					NOT NULL,
	assignment_name		CHAR(50)				NOT NULL,
	FOREIGN KEY(class_id) REFERENCES class_table(class_id) ON DELETE CASCADE
);

CREATE TABLE task_table
(
	task_id				INTEGER PRIMARY KEY		NOT NULL,
	assignment_id		INTEGER					NOT NULL,
	question_number		INTEGER					NOT NULL,
	question_text		CHAR(500)				NULL,
	question_answer		TEXT					NULL,
	question_type		CHAR(20)				NULL,
	FOREIGN KEY(assignment_id) REFERENCES assignment_table(assignment_id) ON DELETE CASCADE
);

CREATE TABLE skill_table
(
	skill_id				INTEGER PRIMARY KEY		NOT NULL,
	skill_name				CHAR(50)				NOT NULL,
	prefilled_outcome_value	FLOAT					NOT NULL,
	max_skill_value			INTEGER					NULL,
	parent_id				INTEGER					NOT NULL,
	class_id				INTEGER					NOT NULL,
	FOREIGN KEY(parent_id) REFERENCES skill_table(skill_id),
	FOREIGN KEY(class_id) REFERENCES class_table(class_id) ON DELETE CASCADE
);

CREATE TABLE outcome_table
(
	task_id			INTEGER					NOT NULL,
	student_id		INTEGER					NOT NULL,
	skill_id		INTEGER					NOT NULL,
	outcome_value	FLOAT					NULL,
	FOREIGN KEY(task_id) REFERENCES task_table(task_id) ON DELETE CASCADE,
	FOREIGN KEY(student_id) REFERENCES student_table(student_id) ON DELETE CASCADE,
	FOREIGN KEY(skill_id) REFERENCES skill_table(skill_id) ON DELETE CASCADE,
	PRIMARY KEY(task_id, student_id, skill_id)
);

-- INSERT 0 Rows into tables that need them. 
-- All tables that are needed to insert the root skill must also have a 0 row 
--(ie. class_table because a Skill has a Foreign Key to class, and user_table 
-- because Class has a foreign Key to user)

INSERT INTO users_table (user_id, user_name, user_password, question_text, answer_text)
VALUES (0, '','', '', '');

INSERT INTO class_table (class_id, user_id, semester, calander_year, class_name, max_score, last_used_timestamp)
VALUES (0, 0, '', 0, '', 0, CURRENT_TIMESTAMP);

INSERT INTO skill_table (skill_id, skill_name, prefilled_outcome_value, class_id, parent_id)
VALUES (-1, '', 0, 0, -1);