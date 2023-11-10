use pubs

--VIew
create view vwPublisher
as
select pub_id 'Publisher Id', pub_name 'Publisher Name'  from Publishers

select * from vwPublisher

create view vwInvoice
as
select t.title 'Book Name',sum(s.qty)*sum(t.price) 'Sale Amount'from sales s join titles t
		on s.title_id = t.title_id
		group by t.title

select * from vwInvoice

--Index

create index idxSample
on tbl1(f1)

sp_help tbl1

--Triggers-Gets executed when the associated action happens
--Insert,Update,Delete

create trigger trg_InsertTbl1
on tbl1
for insert
as
begin
	print 'Hello'
end
insert into tbl1 values(101,'UUU')

use dbCompany26Oct2023

select * from EmployeeSkills

create trigger trg_InsertTbl1
on tbl1
for insert
as
begin
   print 'Hello'
end

insert into tbl1 values(101,'UUU')

use dbCompany26Oct2023

select * from EmployeesSkills
create trigger trgInsertEmployeeSkill
on EmployeesSkills
instead of insert
as
begin
   declare 
	 @skillName varchar(20),
	 @empId int,
	 @level int
	 set @SkillName = (select skill_name from inserted)
	 set @empId =  (select employee_id from inserted)
	 set @level =  (select skill_level from inserted)
	 if((select count(skill) from Skills where skill= @skillName) =0)
	 begin
			print 'Skill not present in skill table'
	end
	else
	begin
	    insert into EmployeesSkills values(@empId,@skillName,@level)	
	end
end

insert into EmployeesSkills values(101,'SQ',8)


-----
use pubs

alter PROCEDURE TotalSalesForPublish(@publisherName VARCHAR(100))
AS
BEGIN
declare @sales float 
set @sales= ( SELECT SUM(s.qty)*sum(t.price) AS TotalSales
    FROM sales s
     JOIN titles  t ON t.title_id=s.title_id
     JOIN publishers p ON p.pub_id= t.pub_id
    WHERE p.pub_name= @publisherName)
END;
exec TotalSalesForPublish @publisherName='New Moon Books'


use pubs

select * from sales
select * from titles
select * from publishers
select * from stores
select * from employee
select * from authors
select * from titleauthor


SELECT s.stor_name 'Store Name', t.title 'Book Name', sl.qty 'Quantity', Sum(sl.qty) * Sum(t.price) 'Sale Amount',
p.pub_name 'Publisher Name', concat(a.au_fname,' ',a.au_lname) 'Author Name'
FROM Stores s join Sales sl ON s.stor_id = sl.stor_id
full outer join titles t ON t.title_id = sl.title_id
full outer join titleauthor ta  ON ta.title_id = t.title_id
full outer join authors a ON a.au_id = ta.au_id
left outer join Publishers p ON p.pub_id = t.pub_id
group by s.stor_name,
t.title,sl.qty,
p.pub_name,
a.au_fname,a.au_lname



alter PROCEDURE get_total_sales_by_author (@author_name VARCHAR(60))
AS
BEGIN
    DECLARE @total_sales DECIMAL(10,2);
	SET @total_sales = (SELECT sum(s.qty )* sum(t.price)  FROM sales s
    INNER JOIN titles t ON s.title_id = t.title_id
    INNER JOIN titleauthor ta ON t.title_id = ta.title_id
    INNER JOIN authors a ON ta.au_id = a.au_id
    WHERE a.au_fname + ' ' + a.au_lname = @author_name)
    IF @total_sales IS NULL OR @total_sales = 0
    BEGIN
        PRINT 'Sale yet to gear up';
    END
    ELSE
    BEGIN
        PRINT 'The total sales amount for ' + @author_name + ' is ' + CAST(@total_sales AS VARCHAR);
    END;
END;

EXEC get_total_sales_by_author @author_name = 'Anne Ringer';


select a.au_fname + ' ' + a.au_lname from authors a

SELECT *
FROM Stores s INNER JOIN Sales sl ON s.stor_id = sl.stor_id
INNER JOIN titles t ON t.title_id = sl.title_id

WHERE sl.qty > (
    SELECT MAX(qty) 
    FROM Sales 
    WHERE t.title_id = sl.title_id AND s.stor_id = sl.stor_id)

select * from sales
select * from stores
select * from titles



select concat(a.au_fname,' ',a.au_lname) 'Author Name' ,avg(t.price) 'Average Price'
from authors a  left outer join titleauthor ta
on ta.au_id = a.au_id
left outer join titles t on t.title_id = ta.title_id
group by  concat(a.au_fname,' ',a.au_lname)


sp_help titles



CREATE PROCEDURE get_count_of_books_by_price (@price DECIMAL(10,2))
AS
BEGIN
    DECLARE @count INT;
    SET @count = (SELECT COUNT(*)  FROM titles WHERE price < @price);
    PRINT 'The count of books that are priced less than ' + CAST(@price AS VARCHAR) + ' is ' + CAST(@count AS VARCHAR);
END;

EXEC get_count_of_books_by_price @price = 20;


CREATE TRIGGER check_price_before_update
ON titles 
instead of insert
AS
BEGIN
    DECLARE
	@title_id varchar(6),
	@title varchar(60),
	@type char(12),
	@pub_id char(4),
	@price money,
	@advance money,
	@royalty int,
	@ytd_sales int,
	@notes varchar(200),
	@pubdate datetime,
	@new_price DECIMAL(10,2);
    SET @new_price = (SELECT  price FROM inserted);

    IF @new_price < 7
    BEGIN
        PRINT 'The price cannot be updated to below 7';
    END;
	ELSE
	BEGIN
		insert into titles values(@title_id,@title,@type,@pub_id,@price,@advance,@royalty ,@ytd_sales ,@notes,@pubdate)
	END;
END;


insert into titles values('AU1099','Learn From Failures',
		'psychology','0599',6.00,15000.00,25,333,
		'Here you can face fear of Failures','2023-10-30 00:00:00:000')



select title 'Book Name' from titles where title like '%e%' and title like '%a%'

select * from authors
select * from 


SELECT s.stor_id AS 'Store ID',
    s.title_id AS 'Title ID',
    t.title AS 'Title',
    s.qty AS 'Sale Quantity',
    s.ord_date AS 'Sale Date'
FROM sales s
left JOIN (
    SELECT
        s.stor_id,
        s.title_id,
        MAX(s.qty) AS max_qty
    FROM sales s
    GROUP BY s.stor_id, s.title_id) max_sale_qty ON s.stor_id = max_sale_qty.stor_id
    AND s.title_id = max_sale_qty.title_id
    AND s.qty > max_sale_qty.max_qty
JOIN titles t ON s.title_id = t.title_id;




