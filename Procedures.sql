declare @res int;
exec Calc 10,'+',20,@res output;
print @res;



drop proc Calc;
create proc Calc
	@num1 int,
	@operator char(1),
	@num2 int,
	@result int output
as
begin
	if @operator = '+'
		set @result = @num1 + @num2;
	else if @operator = '-'
		set @result = @num1 - @num2;
end





declare @min int;
declare @max int;
set @min = 10;
set @max = 20;
exec SelectProductsBetweenPrices @min, @max




create proc SelectProductsBetweenPrices
	@min int,
	@max int
as
	select * 
	from Product
	where UnitPrice between @min and @max



execute SelectAllProducts



--create proc SelectAllProducts
--as
--	select * from Product




declare @x int = 5;
declare @y int = 12;
print (@y - @x);



declare @maxPrice float;
set @maxPrice = (select MAX(UnitPrice) from Product);

if @maxPrice between 100 and 300 --@maxPrice > 100 AND @maxPrice < 300
begin
	select * 
	from Product
	where UnitPrice = @maxPrice
end





select MAX(UnitPrice) from Product