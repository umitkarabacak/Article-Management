USE master

CREATE DATABASE ArticleDB
GO

USE ArticleDB

CREATE TABLE Articles
(
	Id INT IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(50),
	Content NVARCHAR(MAX)
)

CREATE TABLE Authors
(
	Id INT IDENTITY(1,1) NOT NULL,
	Fullname NVARCHAR(100)
)

CREATE TABLE Comments
(
	Id INT IDENTITY(1,1) NOT NULL,
	ArticleId INT NOT NULL,
	AuthorId INT,
	Content NVARCHAR(MAX)
)

INSERT INTO Authors (Fullname) 
	VALUES ('Ümit Karabacak') , ('Farklı Kullanıcı')

INSERT INTO Articles (Title, Content) 
	VALUES ('İlk Eğitim', NULL), ('Ikinci Eğitim', NULL)

INSERT INTO Comments (ArticleId, AuthorId, Content)
	VALUES (1, 1, 'YORUM 1'), (1, 2, 'YORUM 2'), (2, 1, 'YORUM 3'), (2, 2, 'YORUM 4')