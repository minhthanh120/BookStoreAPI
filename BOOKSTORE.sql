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
N'Nguyễn Nhật Ánh', N'Best of the Best'
),
( -- second row: values for the columns in the list above
N'Lỗ Tấn', N'China author'
)
-- add more rows here
GO
INSERT INTO Author
( -- columns to insert data into
[AuthorName], [AuthorDescr]
) VALUES
(N'Tenz', N'Người chơi điện tử')
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
N'Og Mandino',N'Og Mandino (1923-1996) là cựu chủ tịch tạp chí Success Unlimited và là người đầu tiên được trao huy chương Napoleon Hill'
),
(
 N'Zig Ziglar',N'Hilary Hinton "Zig" Ziglar (ngày 6 tháng 11 năm 1926 – 28 tháng 11 năm 2012) là một tác giả, chuyên viên bán hàng và diễn giả truyền cảm hứng người Mỹ.'
),
(
    N'Tatsuya Endo',N'Tác giả manga Số 11'
),
(
    N'Takashi SHIINA',N'Tác giả manga Số 10'
),
(
    N'Yamazaki Kore',N'Tác giả manga Số 9'
),
(
    N'Hitoshi Iwaaki',N'Tác giả manga Số 8'
),
(
    N'Osamu Tezuka',N'Tác giả manga Số 7'
),
(
    N'Yasuhisa Hara',N'Tác giả manga Số 6'
),
(
    N'Chiho Saito',N'Tác giả manga Số 5'
),
(
    N'Gamon Sakurai',N'Tác giả manga 4'
),
(
    N'José Mauro de Vasconcelos',N'Tác giả sách selfhelp'
),
(
    N'Paulo Coelho',N'Tác giả Nhà giả Kim'
),
(
    N'Hae Min',N'Tác giả Hàn Quốc'
),
(
    N'Mario Puzo',N'Tác giả manga Số 3'
),
(
    N'Koyoharu Gotouge',N'Tác giả manga Số 2'
),
(
    N'Shuka Matsuda',N'Tác giả manga Số 1'
)
-- add more rows here
GO
INSERT INTO Book (BookName, Price,  Supplier,   Publisher,      Weight, Height,Length, Width, PublishYear, BookDescr)
VALUES
(N'Bảy bước tới mùa hè',    10000,  N'Tiki',    N'NXB Trẻ',     0.3,    15,     18.5,   1.8,    2019,       N'Best of 2021'),
(N'Cascaderseus',           10000,  N'Tiki',    N'NXB Quốc Gia',0.45,   17,     19.7,   2.5,    2022,       N'Cuốn sách hay nhất 2022'),
(N'Mật Mã Da Vinci',        10000,  N'Tiki',    N'NXB Trí Việt',0.6,    16.8,   18.5,   1.8,    2022,       N'Bán chạy nhất 2022')
INSERT INTO Book (BookName, Price,  Supplier,   Publisher,      Weight, Height,Length, Width, PublishYear, BookDescr)
VALUES
(N'Hướng dẫn sử dụng win 10',    10000,  N'Tiki',    N'NXB Trẻ',     0.3,    15,     18.5,   1.8,    2019,       N'Best of 2021'),
(N'Angular cơ bản',           10000,  N'Tiki',    N'NXB Quốc Gia',0.45,   17,     19.7,   2.5,    2022,       N'Cuốn sách hay nhất 2022'),
(N'Python cơ bản',        10000,  N'Tiki',    N'NXB Trí Việt',0.6,    16.8,   18.5,   1.8,    2022,       N'Bán chạy nhất 2022')

insert into AuthorBook( BookId, AuthorId) values (1, 13)
insert into AuthorBook( BookId, AuthorId) values (1, 14)
insert into AuthorBook( BookId, AuthorId) values (2,14 )
insert into AuthorBook( BookId, AuthorId) values (3,14 )
insert into AuthorBook( BookId, AuthorId) values (7, 15)
insert into AuthorBook( BookId, AuthorId) values (8, 16)

INSERT INTO Category(CategoryName) values(N'Văn học')
INSERT INTO Category(CategoryName) values(N'Tiểu Thuyết')
INSERT INTO Category(CategoryName) values(N'Khoa học')
INSERT INTO Category(CategoryName) values(N'Truyện tranh')
INSERT INTO Category(CategoryName) values(N'Báo chí')
INSERT INTO Category(CategoryName) values(N'Sách giáo khoa')

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
