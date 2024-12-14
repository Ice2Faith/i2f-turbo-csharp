USE GraduateDB;
GO
CREATE TABLE Administrator
(
ano NCHAR(10) PRIMARY KEY,
atype NCHAR(10),
acollege NCHAR(20),
adepartment NCHAR(20),
aname NCHAR(10),
apwd NCHAR(10),
alastLogin NVARCHAR(50)
)
GO
CREATE TABLE Course
(
cno NCHAR(10) PRIMARY KEY,
cname NVARCHAR(50),
cscore int,
cstudyTime int
)
GO
CREATE TABLE Teacher
(
tno NCHAR(10) PRIMARY KEY,
tpwd NCHAR(20),
tcollege NCHAR(20),
tdepartment NCHAR(20),
tsubject NCHAR(20),
tgrade NCHAR(10),
tname NCHAR(10),
tsex NCHAR(10),
tbirthday NCHAR(20),
tphoto NVARCHAR(50),
temail NVARCHAR(50),
tmaxStuCount int,
tintroduction TEXT,
tlastLogin NVARCHAR(50)
)
GO
CREATE TABLE Student
(
sno NCHAR(10) PRIMARY KEY,
spwd NCHAR(20),
scollege NCHAR(20),
sdepartment NCHAR(20),
ssubject NCHAR(20),
sclass NCHAR(10),
sname NCHAR(10),
ssex NCHAR(10),
sbirthday NCHAR(20),
srace NCHAR(10),
sinYear int,
sgraduateYear int,
sguideTeacher NCHAR(10) FOREIGN KEY REFERENCES Teacher(tno),
sphoto NVARCHAR(50),
semail NVARCHAR(50),
sintroduction TEXT,
slastLogin NVARCHAR(50)
)
GO
CREATE TABLE Score
(
sno NCHAR(10) FOREIGN KEY REFERENCES Student(sno),
cno NCHAR(10) FOREIGN KEY REFERENCES Course(cno),
grade NCHAR(10),
PRIMARY KEY(sno,cno)
)
GO
CREATE TABLE Wish
(
sno NCHAR(10) PRIMARY KEY FOREIGN KEY REFERENCES Student(sno),
w1 NCHAR(10) FOREIGN KEY REFERENCES Teacher(tno),
w2 NCHAR(10) FOREIGN KEY REFERENCES Teacher(tno),
w3 NCHAR(10) FOREIGN KEY REFERENCES Teacher(tno),
wstate NCHAR(10)
)
GO
CREATE TABLE SystemDate
(
date0 NCHAR(20),
date1 NCHAR(20),
date2 NCHAR(20),
date3 NCHAR(20),
date4 NCHAR(20)
)