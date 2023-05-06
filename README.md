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

Bu tasarım doğrultusunda ihtiyacım olan sorulara cevap veren bazı sorgular :

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
