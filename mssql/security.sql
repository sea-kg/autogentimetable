CREATE LOGIN admin 
	WITH PASSWORD = '777'
CREATE LOGIN observer
	WITH PASSWORD = '777'
CREATE LOGIN teacher
	WITH PASSWORD = '777'
CREATE LOGIN people
	WITH PASSWORD = '777'
GO

USE ForTimetable
CREATE USER admin FOR login admin
CREATE USER observer FOR login observer
CREATE USER teacher FOR login teacher
CREATE USER people FOR login people
GO

USE ForTimetable
CREATE ROLE db_people
GRANT SELECT ON timetable to people

CREATE ROLE db_teacher
GRANT SELECT ON timetable to teacher
GRANT SELECT ON rooms to teacher
GRANT SELECT ON groups_subjects to teacher


CREATE ROLE db_observer
GRANT ALL ON groups to observer
GRANT ALL ON rooms to observer
GRANT ALL ON subjects to observer
GO

USE ForTimeTable
EXEC sp_addrolemember 'db_people', 'people'
EXEC sp_addrolemember 'db_teacher', 'teacher'
EXEC sp_addrolemember 'db_observer', 'observer'
EXEC sp_addsrvrolemember 'admin', 'sysadmin'
GO