use pubs
select * from authors
select * from titles
select * from sales

--projection
select au_fname, phone from authors
select au_fname 'Author Name' ,phone 'Contact Number' from authors
select au_fname as 'Author Name' ,phone as 'Contact Number' from authors
select au_fname Author_Name ,phone Contact_Number from authors
--selection
select * from authors where contract = 0

select * from titles where royalty>10
select * from titles where royalty>10 or price > 15
select * from titles where royalty>10 and price > 15

select title'Book Name',price 'Cost',royalty 'Royalty Paid',
advance 'Advance received'
from titles 
where royalty>10 and price > 15

select title from titles where price >=10 and price<=25
select title from titles where price between 10 and 25

select * from titles where title like 'The%'
--
select title 'Book Name' from titles where title like '%data%'

select title 'Book Name' from titles where pubdate < '1991-06-18 00:00:00.000'

select title 'Book Name', price 'Price' from titles where pub_id = 0877

select title 'Book Name',price 'Price',notes 'Notes' from titles where type = 'business' and (price between 15 and 100)

select * from titles where price in (10,20,30)

--Aggregate data
select * from titles

select AVG(price) 'Average Price' from titles

select MIN(price) 'Minimum Price' from titles

select MAX(price) 'Maximum Price' from titles

select COUNT(notes) from titles group by type having type='business'

select AVG(price) 'Averge price'from titles where  type='business'

select AVG(price) 'Averge price', Sum(price) 'Sum of price' from titles

select type,COUNT(notes)'Count' from titles group by type

--sub total and grouping
select type'Type Name',AVG(price)'Price' from titles group by type

select state ,count(au_id) from authors group by state

select title_id,COUNT(ord_num) 'number of times sold' 
from sales group by title_id

select title_id,COUNT(ord_num) 'number of times sold' 
from sales 
group by title_id 
having count(ord_num) > 1

select type 'Type name',AVG(price) 'Average price'
from titles 
where price>10
group by type
having AVG(price)>18

--sorting

select * from authors order by state,city,au_fname

select type 'Type name',AVG(price) 'Average price'
from titles 
where price>10
group by type
having AVG(price)>18
order by type desc

--sub queries

select * from titles 
select * from sales

select title_id from titles where title='Straight Talk About Computers'
select * from sales where title_id='BU7832'

select * from sales where title_id=
(select title_id from titles where title='Straight Talk About Computers')

--identifying null
select * from titles where advance is null

select * from authors 

select * from titles where title_id in(
select title_id from titleauthor where au_id =
(select au_id from authors where au_lname= 'White'))

--print title name 
select * from sales
select * from titles

select title 'Book Name' from titles where title_id in
(select title_id from sales )

select title 'Book Name' from titles where title_id not in
(select title_id from sales )

--fetch the average price of titles that hvae been published by publishers 
--who are from USA. Print only if the average is greater than the average of
-- all the titles
--sort them by asencending order of the average

select * from titles
select * from publishers



select title 'Title', Avg(price) 'Average Price'
from titles
where pub_id in (select pub_id from publishers where country='USA')
group by title
having avg(price)>(select avg(price) from titles)


select avg(price) as Avg_price_of_Titles ,pub_id from titles where pub_id in(select pub_id from publishers where country = 'USA')
group by pub_id 
having avg(price)>(select avg(price) from titles)
order by avg(price);










select * from titles