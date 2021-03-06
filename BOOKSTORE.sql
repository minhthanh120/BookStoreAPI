-- Create a new database called 'DatabaseName'
-- Connect to the 'master' database to run this snippet
USE master
GO

drop database UserAuthentication
-- Create the new database if it does not exist already
CREATE DATABASE BOOKSTORE
GO

USE BOOKSTORE
GO

--drop database BOOKSTORE
-- Create the table in the specified schema
CREATE TABLE Author
(
    AuthorId    INT PRIMARY KEY IDENTITY(1,1),
    AuthorName  [NVARCHAR](50)  NOT NULL,
    AuthorDescr NTEXT
);
GO

CREATE TABLE Category
(
    CategoryId      INT PRIMARY KEY IDENTITY(1,1),
    CategoryName    [NVARCHAR](50)  NOT NULL
);
GO

CREATE TABLE Book
(
    BookId      INT             PRIMARY KEY IDENTITY(1,1)   NOT NULL ,
    BookName    [NVARCHAR](50)  NOT NULL,
    Price       INT,
    Supplier    NVARCHAR(50),
    Publisher   NVARCHAR(50),
    Weight      FLOAT,
    Height      FLOAT,
    Length      FLOAT,
    Width       FLOAT,
    PublishYear INT,
    BookDescr   NTEXT
);
GO

CREATE TABLE CategoryBook
(
    CategoryId  INT                             NOT NULL,
    BookId      INT                             NOT NULL,
    CONSTRAINT  PK_tblCategoryBook              PRIMARY KEY(CategoryId, BookId),
    CONSTRAINT  FK_tblCategoryBook_BookId       FOREIGN KEY(BookId)     REFERENCES  Book(BookId),
    CONSTRAINT  FK_tblCategoryBook_CategoryID   FOREIGN KEY(CategoryId) REFERENCES  Category(CategoryId)
);
GO
CREATE TABLE AuthorBook
(
    AuthorId    INT                             NOT NULL,
    BookId      INT                             NOT NULL,
    CONSTRAINT  PK_tblAuthorBook                PRIMARY KEY(AuthorId, BookId),
    CONSTRAINT  FK_tblAuthorBook_BookId         FOREIGN KEY(BookId)     REFERENCES  Book(BookId),
    CONSTRAINT  FK_tblAuthorBook_AuthorId       FOREIGN KEY(AuthorId)   REFERENCES  Author(AuthorId)
);
GO

CREATE TABLE Picture
(
    PictureId   INT                 PRIMARY KEY IDENTITY(1,1)   NOT NULL,
    PicturePath VARCHAR(255),
    BookId      INT                 NOT NULL,
    CONSTRAINT  FK_tblBook_BookId   FOREIGN KEY(BookId) REFERENCES Book(BookId)
);
GO

CREATE TABLE Evaluation
(
    EvalId      INT                     PRIMARY KEY IDENTITY(1,1)   NOT NULL,
    Content     NTEXT                   NOT NULL,
    Score       SMALLINT                NOT NULL,
    UserId      VARCHAR(255)            NOT NULL,
    BookId      INT                     NOT NULL,
    CONSTRAINT  FK_tblEval_BookID       FOREIGN KEY(BookId)         REFERENCES Book(BookId),
    CONSTRAINT  CHK_tblEval_ScoreRange  CHECK(Score < 6 AND Score > 0)
);
GO


-- Insert rows into table 'Author'
INSERT INTO Author
( -- columns to insert data into
[AuthorName], [AuthorDescr]
)
VALUES
( -- first row: values for the columns in the list above
N'Nguy???n Nh???t ??nh', N'Best of the Best'
),
( -- second row: values for the columns in the list above
N'L??? T???n', N'China author'
)
-- add more rows here
GO
INSERT INTO Author
( -- columns to insert data into
[AuthorName], [AuthorDescr]
) VALUES
(N'Tenz', N'Ng?????i ch??i ??i???n t???')
-- Select rows from a Table or View 'Author' in schema 'SchemaName'
SELECT * FROM Author
 	/* add search conditions here */
GO

INSERT INTO Author
( 
 [AuthorName], [AuthorDescr]
)
VALUES
(
N'Og Mandino',N'Og Mandino (1923-1996) l?? c???u ch??? t???ch t???p ch?? Success Unlimited v?? l?? ng?????i ?????u ti??n ???????c trao huy ch????ng Napoleon Hill'
),
(
 N'Zig Ziglar',N'Hilary Hinton "Zig" Ziglar (ng??y 6 th??ng 11 n??m 1926 ??? 28 th??ng 11 n??m 2012) l?? m???t t??c gi???, chuy??n vi??n b??n h??ng v?? di???n gi??? truy???n c???m h???ng ng?????i M???.'
),
(
    N'Tatsuya Endo',N'T??c gi??? manga S??? 11'
),
(
    N'Takashi SHIINA',N'T??c gi??? manga S??? 10'
),
(
    N'Yamazaki Kore',N'T??c gi??? manga S??? 9'
),
(
    N'Hitoshi Iwaaki',N'T??c gi??? manga S??? 8'
),
(
    N'Osamu Tezuka',N'T??c gi??? manga S??? 7'
),
(
    N'Yasuhisa Hara',N'T??c gi??? manga S??? 6'
),
(
    N'Chiho Saito',N'T??c gi??? manga S??? 5'
),
(
    N'Gamon Sakurai',N'T??c gi??? manga 4'
),
(
    N'Jos?? Mauro de Vasconcelos',N'T??c gi??? s??ch selfhelp'
),
(
    N'Paulo Coelho',N'T??c gi??? Nh?? gi??? Kim'
),
(
    N'Hae Min',N'T??c gi??? H??n Qu???c'
),
(
    N'Mario Puzo',N'T??c gi??? manga S??? 3'
),
(
    N'Koyoharu Gotouge',N'T??c gi??? manga S??? 2'
),
(
    N'Shuka Matsuda',N'T??c gi??? manga S??? 1'
)
-- add more rows here
GO
INSERT INTO Book (BookName, Price,  Supplier,   Publisher,      Weight, Height,Length, Width, PublishYear, BookDescr)
VALUES
(N'B???y b?????c t???i m??a h??',    10000,  N'Tiki',    N'NXB Tr???',     0.3,    15,     18.5,   1.8,    2019,       N'Best of 2021'),
(N'Cascaderseus',           10000,  N'Tiki',    N'NXB Qu???c Gia',0.45,   17,     19.7,   2.5,    2022,       N'Cu???n s??ch hay nh???t 2022'),
(N'M???t M?? Da Vinci',        10000,  N'Tiki',    N'NXB Tr?? Vi???t',0.6,    16.8,   18.5,   1.8,    2022,       N'B??n ch???y nh???t 2022')
INSERT INTO Book (BookName, Price,  Supplier,   Publisher,      Weight, Height,Length, Width, PublishYear, BookDescr)
VALUES
(N'H?????ng d???n s??? d???ng win 10',    10000,  N'Tiki',    N'NXB Tr???',     0.3,    15,     18.5,   1.8,    2019,       N'Best of 2021'),
(N'Angular c?? b???n',           10000,  N'Tiki',    N'NXB Qu???c Gia',0.45,   17,     19.7,   2.5,    2022,       N'Cu???n s??ch hay nh???t 2022'),
(N'Python c?? b???n',        10000,  N'Tiki',    N'NXB Tr?? Vi???t',0.6,    16.8,   18.5,   1.8,    2022,       N'B??n ch???y nh???t 2022')

insert into AuthorBook( BookId, AuthorId) values (1, 13)
insert into AuthorBook( BookId, AuthorId) values (1, 14)
insert into AuthorBook( BookId, AuthorId) values (2,14 )
insert into AuthorBook( BookId, AuthorId) values (3,14 )
insert into AuthorBook( BookId, AuthorId) values (7, 15)
insert into AuthorBook( BookId, AuthorId) values (8, 16)

INSERT INTO Category(CategoryName) values(N'V??n h???c')
INSERT INTO Category(CategoryName) values(N'Ti???u Thuy???t')
INSERT INTO Category(CategoryName) values(N'Khoa h???c')
INSERT INTO Category(CategoryName) values(N'Truy???n tranh')
INSERT INTO Category(CategoryName) values(N'B??o ch??')
INSERT INTO Category(CategoryName) values(N'S??ch gi??o khoa')

INSERT INTO CategoryBook(CategoryId, BookId) values(1,1)
INSERT INTO CategoryBook(CategoryId, BookId) values(2,2)
INSERT INTO CategoryBook(CategoryId, BookId) values(3,3)
INSERT INTO CategoryBook(CategoryId, BookId) values(4,4)
INSERT INTO CategoryBook(CategoryId, BookId) values(5,5)
INSERT INTO CategoryBook(CategoryId, BookId) values(6,6)
select * from AuthorBook
select * from book

SELECT * FROM AuthorBook
delete Author WHERE Author.AuthorId = 2
SELECT * FROM Book join AuthorBook on book.BookId=AuthorBook.BookId where authorbook.AuthorId =1

-- Delete rows from table 'Book'
DELETE FROM Book
WHERE BookId=6	/* add search conditions here */
GO


CREATE TABLE [UserPassword](
    Account		nvarchar(50),
	Hash_MD5	varchar(1024),
    Salt      varchar(1024),
    Foreign key(Account) references [User](Account)
)

drop table UserPassword
go;
select case when EXISTS(
select * from [User] join [UserPassword] on [User].Account=[UserPassword].Account where [UserPassword].Account= 'awalbyy9' and [UserPassword].Salt='abcd1234')
then cast(1 as bit)
else cast(0 as bit) END
go;

select u.Account, u.Avatar, u.Email, u.Firstname, u.Lastname from [User] as u join UserPassword as up on u.Account=up.Account join [UserPassword] as ut on ut.Account=u.Account where u.Account = @param1 and up.Salt=@param2

select salt from UserPassword where account = 'awalby9'

declare @Salt varchar(1024)
declare @pass varchar(1024)
select * from [User]
select * from [UserPassword]
delete UserPassword where Account = 'localboi'
delete [User] where Account = 'localboi'
select HASHBYTES('SHA1', 'abcd12340e+3G2hee2O3jdFvtajzt6rE') from userpassword
