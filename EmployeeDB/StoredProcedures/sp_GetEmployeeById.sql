create procedure sp_GetEmployeeById
@Id int
as
begin
	select * from Employees where Id = @Id
end	


