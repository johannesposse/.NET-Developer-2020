
USE master
GO

CREATE DATABASE ImdbMini
GO

USE ImdbMini
GO

CREATE TABLE Directors
(
	DirectorID int IDENTITY(1,1),
	FirstName nvarchar(20) NOT NULL CHECK(LEN(FirstName) >= 2),
	LastName nvarchar(20) NOT NULL CHECK(LEN(LastName) >= 2),
	Age int NOT NULL CHECK(Age > 5),
	Country nvarchar(30) NOT NULL CHECK(LEN(Country) >= 3)

	CONSTRAINT PK_DIRECTOR PRIMARY KEY (DirectorID)

)

CREATE TABLE Genres
(
	GenreID int IDENTITY(1,1),
	Type nvarchar(20) NOT NULL CHECK(LEN(Type) >= 2),
	Description nvarchar(30) NOT NULL CHECK(LEN(Description) >= 5),
	FirstYear DateTime NOT NULL

	CONSTRAINT PK_GENRE PRIMARY KEY (GenreID)
)

CREATE TABLE Movies
(
	MovieID int IDENTITY(1,1),
	Name nvarchar(30) NOT NULL CHECK(LEN(Name) >= 2),
	GenreID int NOT NULL,
	DirectorID int NOT NULL,
	Year DateTime NOT NULL

	CONSTRAINT PK_MOVIES PRIMARY KEY (MovieID),
	CONSTRAINT FK_Director FOREIGN KEY (DirectorID) REFERENCES Directors(DirectorID),
	CONSTRAINT FK_GENRE FOREIGN KEY (GenreID) REFERENCES Genres(GenreID)
)

--ALTER TABLE Movies
--ADD CONSTRAINT FK_Director FOREIGN KEY (DirectorID) REFERENCES Directors(DirectorID)

--ALTER TABLE Movies
--ADD	CONSTRAINT FK_GENRE FOREIGN KEY (GenreID) REFERENCES Genres(GenreID)


INSERT INTO Genres(Type,Description, FirstYear)
Values('Action','Movies that goes boom, pew pew', '1965-09-10')

INSERT INTO Genres(Type,Description, FirstYear)
Values('Horror','Nightmare fuel', '1965-09-10')

INSERT INTO Genres(Type,Description, FirstYear)
Values('Comedy','Movies that goes like hahaha', '1931-12-24')

INSERT INTO Genres(Type,Description, FirstYear)
Values('Sci-Fi','Lasers and stuff', '1971-03-15')

INSERT INTO Genres(Type,Description, FirstYear)
Values('Romance','<3<3<3', '2005-02-14')


INSERT INTO Directors (FirstName, LastName, Age, Country)
VALUES('Christopher','Nolan',51,'England')

INSERT INTO Directors (FirstName, LastName, Age, Country)
VALUES('Alfred','Hitchcock',81,'USA')

INSERT INTO Directors (FirstName, LastName, Age, Country)
VALUES('Steven','Spielberg',74,'USA')

INSERT INTO Directors (FirstName, LastName, Age, Country)
VALUES('Quentin','Tarantino',57,'USA')

INSERT INTO Directors (FirstName, LastName, Age, Country)
VALUES('Ingmar','Bergman',89,'Sweden')


INSERT INTO MOVIES(Name,GenreID,DirectorID,Year)
VALUES('Toy Story',2,5,'2020-08-01')

INSERT INTO MOVIES(Name,GenreID,DirectorID,Year)
VALUES('Star Wars',4,3,'1977-04-25')

INSERT INTO MOVIES(Name,GenreID,DirectorID,Year)
VALUES('Avengers',5,4,'2000-01-01')

INSERT INTO MOVIES(Name,GenreID,DirectorID,Year)
VALUES('Lord Of The Rings',1,2,'1955-10-11')

INSERT INTO MOVIES(Name,GenreID,DirectorID,Year)
VALUES('Super Bad',3,2,'1993-08-01')