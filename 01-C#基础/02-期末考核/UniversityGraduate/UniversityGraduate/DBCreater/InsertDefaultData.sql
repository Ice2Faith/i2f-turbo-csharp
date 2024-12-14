USE GraduateDB;
GO
INSERT INTO Administrator(ano,aname,apwd,adepartment) VALUES('1001','sa','123','计科系');
INSERT INTO Administrator(ano,aname,apwd,adepartment) VALUES('1002','sb','234','计科系');
INSERT INTO Administrator(ano,aname,apwd,adepartment) VALUES('1003','sc','345','计科系');
GO
INSERT INTO Teacher(tno,tname,tpwd,tdepartment,tmaxStuCount) VALUES('9001','Belies','555','计科系',24);
INSERT INTO Teacher(tno,tname,tpwd,tdepartment,tmaxStuCount) VALUES('9002','Arise','666','计科系',30);
INSERT INTO Teacher(tno,tname,tpwd,tdepartment,tmaxStuCount) VALUES('9003','Kadard','777','计科系',25);
INSERT INTO Teacher(tno,tname,tpwd,tdepartment,tmaxStuCount) VALUES('9004','Jemily','888','计科系',28);
INSERT INTO Teacher(tno,tname,tpwd,tdepartment,tmaxStuCount) VALUES('9005','Morzake','999','计科系',47);
INSERT INTO Teacher(tno,tname,tpwd,tdepartment,tmaxStuCount) VALUES('9006','Deluse','000','计科系',36);
GO
INSERT INTO Student(sno,sname,spwd,sdepartment,sinYear) VALUES('3001','Lilly','333','计科系',2017);
INSERT INTO Student(sno,sname,spwd) VALUES('3002','july','444');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3003','Miler','555','计科系');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3004','Aierier','666','计科系');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3005','Bululu','777','计科系');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3006','Ciling','888','计科系');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3007','Derviga','999','计科系');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3008','Eiz','000','计科系');
INSERT INTO Student(sno,sname,spwd,sdepartment) VALUES('3009','Floridar','111','计科系');
GO
INSERT INTO Course(cno,cname,cscore,cstudyTime) VALUES('c01','C#应用开发','2',3);
INSERT INTO Course(cno,cname,cscore,cstudyTime) VALUES('c02','Computer OS','2',3);
INSERT INTO Course(cno,cname,cscore,cstudyTime) VALUES('c03','Software First','1',3);
GO
INSERT INTO Score(sno,cno,grade) VALUES('3001','c01','1.5');
GO
INSERT INTO Wish(sno,w1,wstate) VALUES('3001','9001','ready');
GO
INSERT INTO SystemDate(date0,date1,date2,date3,date4) VALUES('2020年3月1日 11:05:00','2020年3月10日 11:05:00','2020年3月20日 11:05:00','2020年4月1日 11:05:00','2020年4月10日 11:05:00');
GO
UPDATE Student SET sphoto='../Images/defstu.jpg';
UPDATE Teacher SET tphoto='../Images/deftch.jpg';