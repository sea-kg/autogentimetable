CREATE TABLE times
(
  id int NOT NULL IDENTITY (1, 1),
  name varchar(255) NOT NULL,
  CONSTRAINT PK_times PRIMARY KEY (id)
);
----------------------------------------------------------------------------------------
CREATE TABLE rooms 
(
  id int NOT NULL IDENTITY (1, 1),
  name varchar(255) NOT NULL,
  CONSTRAINT PK_rooms PRIMARY KEY (id)
);
----------------------------------------------------------------------------------------
CREATE TABLE subjects 
(
  id int NOT NULL IDENTITY (1, 1),
  name varchar(255) NOT NULL,
  CONSTRAINT PK_subjects PRIMARY KEY (id)
);
----------------------------------------------------------------------------------------
CREATE TABLE teachers 
(
  id int NOT NULL IDENTITY (1, 1),
  name varchar(255) NOT NULL,
  CONSTRAINT PK_teachers PRIMARY KEY (id)
);
----------------------------------------------------------------------------------------
CREATE TABLE groups
(
  id int NOT NULL IDENTITY (1, 1),
  name varchar(255) NOT NULL,
  CONSTRAINT PK_groups PRIMARY KEY (id)
);
----------------------------------------------------------------------------------------
CREATE TABLE days
(
  id int NOT NULL IDENTITY (1, 1),
  name varchar(255) NOT NULL,
  CONSTRAINT PK_days PRIMARY KEY (id)
);
----------------------------------------------------------------------------------------
CREATE TABLE groups_subjects
(
  id int NOT NULL IDENTITY (1, 1),
  id_groups int NOT NULL,
  id_subjects int NOT NULL,
  weight int NOT NULL,
  CONSTRAINT PK_groups_subjects PRIMARY KEY (id),
  CONSTRAINT FK1_groups_subjects FOREIGN KEY (id_groups) REFERENCES groups(id) ON DELETE CASCADE,
  CONSTRAINT FK2_groups_subjects FOREIGN KEY (id_subjects) REFERENCES subjects(id) ON DELETE CASCADE
);
----------------------------------------------------------------------------------------
CREATE UNIQUE INDEX ind_groups_subjects
ON groups_subjects
(
	id_groups,
	id_subjects
);
----------------------------------------------------------------------------------------
CREATE TABLE teachers_subjects
(
  id int NOT NULL IDENTITY (1, 1),
  id_teachers int NOT NULL,
  id_subjects int NOT NULL,
  weight int NOT NULL,
  CONSTRAINT PK_teachers_subjects PRIMARY KEY (id),
  CONSTRAINT FK1_teachers_subjects FOREIGN KEY (id_teachers) REFERENCES teachers(id) ON DELETE CASCADE,
  CONSTRAINT FK2_teachers_subjects FOREIGN KEY (id_subjects) REFERENCES subjects(id) ON DELETE CASCADE
);
----------------------------------------------------------------------------------------
CREATE UNIQUE INDEX ind_teachers_subjects
ON teachers_subjects
(
	id_teachers,
	id_subjects
);
----------------------------------------------------------------------------------------
CREATE TABLE rooms_subjects
(
  id int NOT NULL IDENTITY (1, 1),
  id_rooms int NOT NULL,
  id_subjects int NOT NULL,
  CONSTRAINT PK_rooms_subjects PRIMARY KEY (id),
  CONSTRAINT FK1_rooms_subjects FOREIGN KEY (id_rooms) REFERENCES rooms(id) ON DELETE CASCADE,
  CONSTRAINT FK2_rooms_subjects FOREIGN KEY (id_subjects) REFERENCES subjects(id) ON DELETE CASCADE
);
----------------------------------------------------------------------------------------
CREATE UNIQUE INDEX ind_rooms_subjects
ON rooms_subjects
(
	id_rooms,
	id_subjects
);
----------------------------------------------------------------------------------------
CREATE TABLE days_times
(
  id int NOT NULL, --IDENTITY (1, 1),
  id_days int NOT NULL,
  id_times int NOT NULL,
  weight int NOT NULL,
  CONSTRAINT PK_days_times PRIMARY KEY (id),
  CONSTRAINT FK1_days_times FOREIGN KEY (id_days) REFERENCES days(id) ON DELETE CASCADE,
  CONSTRAINT FK2_days_times FOREIGN KEY (id_times) REFERENCES times(id) ON DELETE CASCADE
);
----------------------------------------------------------------------------------------
CREATE UNIQUE INDEX ind_days_times
ON days_times
(
	id_days,
	id_times
);
----------------------------------------------------------------------------------------
CREATE TABLE timetable
(
  id int NOT NULL IDENTITY (1, 1),
  id_groups int NOT NULL,
  id_subjects int NOT NULL,
  id_teachers int NOT NULL,
  id_rooms int NOT NULL,
  id_days_times int NOT NULL,
  CONSTRAINT PK_timetable PRIMARY KEY (id),
  CONSTRAINT FK1_timetable FOREIGN KEY (id_groups) REFERENCES groups(id) ON DELETE CASCADE,
  CONSTRAINT FK2_timetable FOREIGN KEY (id_subjects) REFERENCES subjects(id) ON DELETE CASCADE,
  CONSTRAINT FK3_timetable FOREIGN KEY (id_teachers) REFERENCES teachers(id) ON DELETE CASCADE,
  CONSTRAINT FK4_timetable FOREIGN KEY (id_rooms) REFERENCES rooms(id) ON DELETE CASCADE,
  CONSTRAINT FK5_timetable FOREIGN KEY (id_days_times) REFERENCES days_times(id) ON DELETE CASCADE
);
-----------------------------------------------------------------------------------------
CREATE UNIQUE INDEX ind_groups_days_times ON timetable (id_groups,id_days_times);
CREATE UNIQUE INDEX ind_rooms_days_times ON timetable (id_rooms,id_days_times);
CREATE UNIQUE INDEX ind_teachers_days_times ON timetable (id_teachers,id_days_times);
CREATE UNIQUE INDEX ind_subjects_days_times ON timetable (id_subjects,id_days_times);