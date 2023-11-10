use pubs

select * from publishers

select * from titles
--select publisher name and the title name
select pub_name 'Publisher Name', title 'Book Name' from publishers join titles
on publishers.pub_id = titles.pub_id

select pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id

select p.pub_id 'Publisher Id', pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id
order by [Publisher Name]

--outer JOin
select pub_name 'Publisher Name', title 'Book Name' 
from publishers left outer join titles
on publishers.pub_id = titles.pub_id

select t.title Book_Name, s.qty Quantity_Sold
from sales s right outer join titles t
on s.title_id = t.title_id

select pub_name 'Publisher Name' ,count(t.pub_id) 'Number of books published'
from publishers p join titles t
on p.pub_id = t.pub_id
group by pub_name
order by [Publisher Name]

select pub_name 'Publisher Name', fname+' '+lname 'Employee Name' 
from publishers p join employee e
on p.pub_id = e.pub_id

select * from publishers
select * from employee
--print the publisher name and employee name
select * from authors
select * from titles
select * from titleauthor

select title 'Book Name', CONCAT(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id 
join authors a on ta.au_id = a.au_id




select pub_name 'Publisher Name',title 'Book Name',qty 'Sold Quantity'
from publishers p join titles t on 
p.pub_id = t.pub_id
join sales s on t.title_id = s.title_id

--cross join

select * from sales cross join employee

