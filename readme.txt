--------------------------------------------------------------------
Create Proc [dbo].[GetEmployeeById]
@Id int
As
	Begin
		Select * from employee where ID=@Id
	End
----------------------------------------------------------------------
Create Proc [dbo].[GetAllEmployees]
As
	Begin
		Select * from employee
	End
-----------------------------------------------------------------------
Create Proc [dbo].[GetEmployeeByDOB]
@DOB int
As
	Begin
		Select * from employee where DateOfBirth=@DOB
	End
------------------------------------------------------------------------    

Create Proc [dbo].[DeleteEmployee]
@Id int
As
	Begin
		Delete from employee where ID=@Id
	End
--------------------------------------------------------------------------
Create Proc [dbo].[UpdateEmployee]
@Id int,
@Fname varchar(50),
@Lname varchar(50),
@DOB DateTime

As
	Begin
		Update employee set FirstName=@Fname,LastName=@Lname,DateOfBirth=@DOB where ID=@Id
	End
---------------------------------------------------------------------------    