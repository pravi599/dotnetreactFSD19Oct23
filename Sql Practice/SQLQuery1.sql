use pubs



select title 'Book Name' from titles

select title 'Book Name' from titles where pub_id='1389'

select title 'Book Name' from titles where price between 10 and 15

select title 'Book Name' from titles where price is null

select title 'Book Name' from titles where title like 'The%'

select title 'Book Name' from titles where title not like '%v%'

select title 'Book Name' from titles
order by royalty

select title 'Book Name' from  titles
order by pub_id desc,
type asc,
price desc

select type 'Type of Book', avg(price) 'Average' from titles
group by type

select distinct type 'Type of Book' from titles

select top(2) title 'Book name' from titles
order by price desc


select title 'Book Name' from titles 
where (type='business' and  price>20 and advance>7000)

select pub_id,count(title) 'Number of Books' from titles
where price between 15 and 25
group by pub_id
having count(title)>2
order by count(title)

select * from authors where state = 'CA'

select state,count(au_id) 'Count of Aothors' from authors
group by state

----------------------

select stor_id,count(stor_id) 'Orders' from sales
group by stor_id

select title_id,count(title_id) 'Orders' from sales
group by title_id

select p.pub_name 'Publisher Name',t.title 'Book Name'
from publishers p inner join titles t
on p.pub_id = t.pub_id

select au_fname+' '+au_lname 'Author Full Name' from authors

select title , price+price*12.36/100 'Tax' from titles

select a.au_fname+' '+a.au_lname 'Author Name',t.title 'Title Name'
from authors a
inner join titleauthor ta on a.au_id = ta.au_id
inner join titles t on t.title_id= ta.title_id

select a.au_fname+' '+a.au_lname 'Author Name',t.title 'Title Name',p.pub_name 'Publisher Name'
from authors a
inner join titleauthor ta on a.au_id = ta.au_id
inner join titles t on t.title_id= ta.title_id
inner join publishers p on p.pub_id = t.pub_id

select p.pub_name,avg(t.price) 'Average Price'
from publishers p full outer join titles t
on p.pub_id = t.pub_id
group by p.pub_name

select * from titles


select t.title 'Title Name' 
from titles t 
inner join titleauthor ta on t.title_id = ta.title_id
inner join authors a on a.au_id= ta.au_id
where a.au_fname='Marjorie'

select p.pub_name 'Publisher Name', sum(s.qty) 'Number Of Books'
from sales s
inner join titles t on t.title_id = s.title_id
right outer join publishers p on p.pub_id = t.pub_id
where p.pub_name = 'New Moon Books' 
group by p.pub_name

select p.pub_name 'Publisher Name',sum(s.qty)'Number Of Orders'
from sales s
inner join titles t on t.title_id = s.title_id
right outer join publishers p on p.pub_id = t.pub_id
group by p.pub_name

select s.ord_num 'Order Number',t.title 'Book Name',
s.qty 'Quantity',t.price 'Price',s.qty*t.price 'Total Price'
from sales s
full outer join titles t on t.title_id = s.title_id
group by s.ord_num,
t.title,s.qty,t.price

select t.title 'Book Name', s.qty*t.price 'Order Quantity'
from sales s
right outer join titles t on t.title_id = s.title_id

select t.title 'Book Name', s.qty*t.price 'Total Price'
from sales s
right outer join titles t on t.title_id = s.title_id










select * from sales















select * from publishers
select * from sales
select * from titles
select * from authors
select * from titleauthor
sp_help titles
