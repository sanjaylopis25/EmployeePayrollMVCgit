create database employee_payroll_MVC
 use employee_payroll_MVC

 Create TABLE Emp_Form1 (
    Emp_id int identity(1,1) primary key not null,
	Name varchar(50),
    Profile_Image varchar(50),  
    Gender varchar(50),
    Department varchar(50),
	Salary varchar(50),
	Start_Date varchar(50),
	Notes varchar(250),
	RegisteredDate datetime default sysdatetime()
);

select * from Emp_Form1

create PROCEDURE sp_Emp_Form1
@Name varchar(50),
@Profile_Image varchar(50),
@Gender varchar(50),
@Department varchar(50),
@Salary varchar (50),
@Start_Date	 varchar(50),
@Notes varchar(50)
AS
BEGIN
insert into Emp_Form1 (Name,Profile_Image,Gender,Department,Salary,Start_Date,Notes) values
(
@Name,@Profile_Image,@Gender,@Department,@Salary,@Start_Date,@Notes
)
END
GO