create or alter procedure StoreUpdateSalary
(
@Name varchar(20),
@BasicPay decimal,
@department varchar(50),
@address varchar(50),
@PhoneNumber varchar(10),
@Deduction decimal(10,2),
@TaxablePay decimal(10,2),
@Tax decimal(10,2),
@NetPay decimal(10,2)
)
as 
begin
update emp_payroll set Salary=@BasicPay, department=@department,address=@address,phonenumber=@PhoneNumber,deductions=@Deduction,taxable_pay=@TaxablePay,income_tax=@Tax,net_pay=@NetPay
where Name = @Name
end
go

create or alter procedure StoreGetDataByDateRange
(
@StartDate date,
@EndDate date
)
as
begin
select * from emp_payroll 
where StartDate between cast(@StartDate as Date) and cast(@EndDate as Date)
end 
go


