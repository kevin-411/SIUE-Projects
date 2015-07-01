CREATE TABLE taskTable
(
	taskId				INT PRIMARY KEY		NOT NULL,
	assignmentCode		CHAR(50)			NOT NULL,
	skillsCount			INT					NOT NULL,
	classId				INT					NOT NULL
);

CREATE TABLE scoreTable
(
	scoreId		INT PRIMARY KEY		NOT NULL,
	taskId		INT					NOT NULL,
	studentId	INT					NOT NULL,
	skillId		INT					NOT NULL,
	scoreValue	INT					NULL
);

CREATE TABLE classTable(
	classId			INT PRIMARY KEY		NOT NULL,
	semester		CHAR(6) 			NOT NULL,
	calanderYear	CHAR(4)				NOT NULL,
	class_name		CHAR(50)			NOT NULL,
	maxScore		INT					NOT NULL	
);

CREATE TABLE studentTable
(
	studentId		INT PRIMARY KEY		NOT NULL,
	firstName		CHAR(50)			NOT NULL,
	lastName		CHAR(50)			NOT NULL,
	middleName		CHAR(50)			NULL,
	classId			INT					NOT NULL
);

CREATE TABLE usersTable
(
	userID			INT PRIMARY KEY		NOT NULL,
	userName		CHAR(50)			NOT NULL,
	userPassword	CHAR(50)			NOT NULL
);

CREATE TABLE skillTable
(
	skillId			INT PRIMARY KEY		NOT NULL,
	skillName		CHAR(50)			NOT NULL,
	classId			INT					NOT NULL
);