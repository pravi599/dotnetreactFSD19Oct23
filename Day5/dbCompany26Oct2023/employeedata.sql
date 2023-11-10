create database employeeData
use employeeData


create table EMP
(Empno int constraint pk_empno primary key,
Empname varchar(20),
Empsalary numeric,
Deptname varchar(20),
Bossno int null constraint fk_bossno foreign key references emp(empno))

create table DEPARTMENT
(Deptname varchar(20) constraint pk_deptname primary key,
Deptfloor int,
Deptphone varchar(20),
Mgrid int not null constraint fk_mgrid foreign key references emp(empno))


Alter table EMP add constraint fk_dept foreign key (deptname)
references department(deptname)



-- Create the ITEM table
CREATE TABLE ITEM (
    itemname VARCHAR(50) PRIMARY KEY,
    itemtype VARCHAR(50),
    itemcolor VARCHAR(50)
);



-- Create the SALES table
CREATE TABLE SALES (
    salesno INT PRIMARY KEY,
    saleqty INT,
    itemname VARCHAR(50) NOT NULL,
    deptname VARCHAR(20) NOT NULL,
    FOREIGN KEY (itemname) REFERENCES ITEM (itemname),
    FOREIGN KEY (deptname) REFERENCES DEPARTMENT (deptname)
);

-- Insert data into the DEPARTMENT table


-- Insert data into the ITEM table
INSERT INTO ITEM (itemname, itemtype, itemcolor)
VALUES
    ('Boots-snake proof', 'TypeA', 'ColorA'),
    ('Pith Helmet', 'TypeB', 'ColorB'),
    ('Sextant', 'TypeC', 'ColorC'),
    ('Hat-polar Explorer', 'TypeD', 'ColorD'),
    ('Pocket Knife-Nile', 'TypeE', 'ColorE'),
    ('Compass', 'TypeF', 'ColorF'),
    ('Geo positioning system', 'TypeG', 'ColorG'),
    ('Map Measure', 'TypeH', 'ColorH');





