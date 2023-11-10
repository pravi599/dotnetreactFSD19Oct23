create table tbl1
(f1 int,
f2 varchar(20))

insert into tbl1 values(1,'abc'),(2,'efg'),(3,'klj'),(4,'jjj')
--data injection
select * from tbl1 where f1=1;delete  from tbl1;




create procedure proc_first
as
begin
select * from authors
end

execute proc_First

create proc proc_InsertSample(@f1 int,@f2 varchar(20))
as
begin
insert into tbl1 values(@f1,@f2)
end

exec proc_InsertSample 5,'GYH'
exec proc_InsertSample 5,'GYH';delete from tbl1;

alter proc proc_Select(@f2 varchar(20))
as
begin
   select * from tbl1 where f2=@f2
end

exec proc_Select '1;delete from tbl1'


create proc proc_GetTotalSaleAmount(@authorName varchar(20),@salemount float out)
as
begin
   declare
    @saleamt float
	set @saleamt = (select sum(s.qty) * sum(t.price) from sales s join titles t 
						on s.title_id=t.title_id
						where t.title_id in
						(select title_id from titleauthor where au_id= 
						(select au_id from authors where au_fname = @authorName)))
	set @salemount = @saleamt
end


select * from authors

declare @amt float
begin
exec proc_GetTotalSaleAmount 'Cheryl',@amt out
print @amt
end


create function fn_CalculateTax(@price float)
returns float
as
begin
    declare @totalPrice float
	set @totalPrice = @price +(@price*12.36/100)
	return round(@totalPrice,2)
end

select title,price,dbo.fn_CalculateTax(price) 'Nett. Price'
from titles

--create a function that will take the author's first name and last name and 
--give back the full name separated by space

create function fn_AuthorFullName(@fname varchar(20),@lname varchar(20))
returns varchar(40) 
as
begin
    declare @full_name VARCHAR(40)
    set @full_name = CONCAT(@fname, ' ', @lname)
    return @full_name
end

select dbo.fn_AuthorFullName(au_fname,au_lname) AS 'Full Name' from authors;





--create a procedure that will take the publisher name and give back the total sale 



create proc proc_GetTotalPublisherSaleAmount(@publisherName varchar(20),@salemount float out)
as
begin
   declare
    @saleamt float
	set @saleamt = (select sum(s.qty) * sum(t.price) from sales s join titles t 
						on s.title_id=t.title_id
						where t.pub_id in
						(select pub_id from publishers  where pub_name = @publisherName))
	set @salemount = @saleamt
end


declare @amt float
begin
exec proc_GetTotalPublisherSaleAmount 'Algodata Infosystems',@amt out
print @amt
end
