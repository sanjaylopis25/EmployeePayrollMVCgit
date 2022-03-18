create PROCEDURE sp_AddEmpForm1

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

create PROCEDURE sp_DeleteEmpForm1
@Emp_id int
AS
BEGIN
delete from Emp_Form1 where @Emp_id=Emp_id
END

Create procedure sp_GetAllEmpForm1     
as      
Begin      
    select *      
    from Emp_Form1      
End   


create PROCEDURE sp_Update_EmpForm1
(
@Emp_id int,
@Name varchar(50),
@Profile_Image varchar(50),
@Gender varchar(50),
@Department varchar(50),
@Salary varchar (50),
@Start_Date	 varchar(50),
@Notes varchar(50)
)
AS
BEGIN
update Emp_Form1 set

Name=@Name,
Profile_Image=@Profile_Image,
Gender=@Gender,
Department=@Department,
Salary=@Salary,
Start_Date=@Start_Date,
Notes=@Notes
where @Emp_id=Emp_id
END
