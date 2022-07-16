USE ProjectRegistration
GO 
CREATE TABLE Teacher
(
Name NVARCHAR,
Username NVARCHAR,
Password NVARCHAR,
Email NVARCHAR(50),
ID INT PRIMARY KEY
)
CREATE TABLE Student
(
Name NVARCHAR,
Username NVARCHAR,
Password NVARCHAR,
Email NVARCHAR(50),
ID INT PRIMARY KEY
)
CREATE TABLE Project
(
ID INT PRIMARY KEY,
TeacherID INT,
Type INT,
Name NVARCHAR,
FOREIGN KEY (teacherID) REFERENCES dbo.Teacher(ID)
)
