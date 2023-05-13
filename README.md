# Library

The problems to solve about the library database are listed belove : 

Design the database of Kadıköy Anatolian High School.
  The courses in the school have name, code, importance level.
  There are teachers, teachers' name, surname, branch, phone number, has a title.
  There are students, there are students' name, surname, class, identity number, age
  The class has the name of the class, its capacity and its president (a normal student-type
  variable?) are there are there are.
  Each class has lessons.
  One lesson can be taught by more than one teacher.
  Students can be in one class.
  There are teachers in the classroom.
  Homework is given at school. Assignments have a name, code and due date. 
  An assignment can be given to many classes. One teacher prepares the assignment and assigns it to many classes.


The project includes library database schema, which contains relationship with the picture belove : 

![Bildschirmfoto 2023-02-02 um 15 06 07](https://user-images.githubusercontent.com/120198895/216320235-17827208-4860-4e36-a536-8624ce033416.png)

An example of n-n relation is shown belove : 

![Bildschirmfoto 2023-02-02 um 15 08 01](https://user-images.githubusercontent.com/120198895/216320583-ef302a9a-a14e-4fff-80a5-f130c92d1f43.png)

The codes of the library database : 

create table Worker(
Id int primary key GENERATED ALWAYS AS IDENTITY,
WorkerName character varying (100),
Surname character varying (100),
PhoneNumber character varying(10),
Salary float
);

create table Book(
Id int primary key GENERATED ALWAYS AS IDENTITY,
BookTitle character varying(100),
Author character varying(100),
PageNumber int,
PublishDate date
);

create table Episode(
Id int primary key GENERATED ALWAYS AS IDENTITY,
EpisodeName character varying(100),
BookId int,
FOREIGN KEY (BookId) REFERENCES Book(Id)
);

create table Section(
Id int primary key GENERATED ALWAYS AS IDENTITY,
SectionName character varying(100),
FloorId int,
WorkerId int,
FOREIGN KEY (FloorId) REFERENCES LibraryFloor(Id),
FOREIGN KEY (WorkerId) REFERENCES Worker(Id)
);

create table LibraryFloor(
Id int primary key GENERATED ALWAYS AS IDENTITY,
Area float,
FloorType character varying(50),
Capacity int,
Nickname character varying(100)
);

create table BookSection(
Id int primary key GENERATED ALWAYS AS IDENTITY,
BookSectionName character varying(100),
BookId int,
SectionId int,
FOREIGN KEY(BookId) REFERENCES Book(Id),
FOREIGN KEY(SectionId) REFERENCES Section(Id)
);
insert into Book(BookTitle,Author,PageNumber,PublishDate)values ('Tutunamayanlar','Oğuz Atay',483,'2006-09-12')
insert into Book(BookTitle,Author,PageNumber,PublishDate)values ('İnsan Ne İle Yaşar','Tolstoy',273,'1885-06-22')
insert into Book(BookTitle,Author,PageNumber,PublishDate)values ('Savaş ve Barış','Dostoyevski',500,'1923-07-10')
insert into Book(BookTitle,Author,PageNumber,PublishDate)values ('En Mavi Göz','Oğuz Atay',483,'2006-09-12')
insert into Book(BookTitle,Author,PageNumber,PublishDate)values ('Cadı Kazanı','Arthur Miller',198,'1940-11-23')

insert into Worker(WorkerName,Surname,PhoneNumber,Salary) values ('Mert','Ünal','5335246062',9000)
insert into Worker(WorkerName,Surname,PhoneNumber,Salary) values ('Efe','Taycı','5346751025',8500)
insert into Worker(WorkerName,Surname,PhoneNumber,Salary) values ('Efe','Keskin','5335246062',10000)
insert into Worker(WorkerName,Surname,PhoneNumber,Salary) values ('Serhat','Ünal','5334659007',5000)
insert into Worker(WorkerName,Surname,PhoneNumber,Salary) values ('Ege','Perçinel','5324063514',7500)

insert into LibraryFloor(Area,FloorType,Capacity,Nickname) values (870.25,'wood',650,'Science')
insert into LibraryFloor(Area,FloorType,Capacity,Nickname) values (900,'marble',500,'Language')
insert into LibraryFloor(Area,FloorType,Capacity,Nickname) values (1600.5,'marble',450,'Social Studies')
insert into LibraryFloor(Area,FloorType,Capacity,Nickname) values (1200,'wood',250,'Mathematics')
insert into LibraryFloor(Area,FloorType,Capacity,Nickname) values (2200,'marble',300,'Economy')

insert into Episode(EpisodeName,BookId) values ('Oğuz Atay Maceraları',1)
insert into Episode(EpisodeName,BookId) values ('Efendi İle Uşak',2)
insert into Episode(EpisodeName,BookId) values ('Oğuz Atay Maceraları',3)
insert into Episode(EpisodeName,BookId) values ('Sonbahar',4)
insert into Episode(EpisodeName,BookId) values ('Piyer Bozukof ve Nikolay Rustof',5)

insert into Section(SectionName,FloorId,WorkerId) values ('1',1,2)
insert into Section(SectionName,FloorId,WorkerId) values ('10',3,5)
insert into Section(SectionName,FloorId,WorkerId) values ('5',4,4)
insert into Section(SectionName,FloorId,WorkerId) values ('3',5,1)
insert into Section(SectionName,FloorId,WorkerId) values ('20',2,3)

insert into BookSection(BookSectionName,BookId) values ('Başlangıç',3)
insert into BookSection(BookSectionName,BookId) values ('Sonbahar',4)
insert into BookSection(BookSectionName,BookId) values ('Aşk Maceraları',1)
insert into BookSection(BookSectionName,BookId) values ('Ayrılık',5)
insert into BookSection(BookSectionName,BookId) values ('Mahkeme Başlıyor',2)

In line with this design, some datas that answer the questions I need:

-- Book sections of workers whose name is 'efe'
select BookSectionName from Worker,Section,BookSection
where Worker.Id=Section.WorkerId
and Section.Id = BookSection.SectionId
and Worker.WorkerName = 'Efe'

--Episodes of workers named efe
select EpisodeName 
from Worker,Section,BookSection,Book,Episode
where Worker.Id=Section.WorkerId
and Section.Id = BookSection.SectionId
and BookSection.BookId=Book.Id
and Book.Id=Episode.BookId
and WorkerName = 'Efe' 

--LibraryFloor of workers named efe 
select FloorType from Worker,Section,LibraryFloor
where Worker.Id=Section.WorkerId
and Section.FloorId = LibraryFloor.Id
and Nickname = 'Economy'

--The worker name and sary of the episode with episode name 'x'
select WorkerName,Salary from Episode,Book,BookSection,Section,Worker
where Worker.Id=Section.WorkerId
and Section.Id = BookSection.SectionId
and BookSection.BookId=Book.Id
and Book.Id=Episode.BookId
and EpisodeName = 'Sonbahar'
select * from Episode

--Book names of library floor with library floor nick name 'x'
select BookTitle from LibraryFloor,Section,BookSection,Book
where LibraryFloor.Id=Section.FloorId
and Section.Id=BookSection.SectionId
and Book.Id=BookSection.BookId
and Nickname = 'Science'
