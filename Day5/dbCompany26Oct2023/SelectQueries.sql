use pubs
select * from authors
--where class restricts the number of rows
select * from authors where state = 'CA'
--Column selection
select au_lname,au_fname from authors
