use Demo404
--insert employee
insert into Employees(Id,passCode) values(NEWID(),'123456');
--insert service
insert into Servicecs(Name,Image) values(N'Vệ sinh','/Assets/images/images/login/bucket.png');
insert into Servicecs(Name, Image) values(N'Bảo vệ','/Assets/images/images/login/policeman.png');
insert into Servicecs(Name, Image) values(N'Chăm sóc học viên','/Assets/images/images/login/social-care.png');
-- insert question
insert into Questions(question, Servicecs_Id) values(N'Sạch sẽ',1);
insert into Questions(question, Servicecs_Id) values(N'Bảo vệ',2);
