use bookrentalshop

-- 구분 테이블
CREATE TABLE divtbl (
  Division CHAR(4) NOT NULL PRIMARY KEY,
  Names NVARCHAR(45)
)

-- 책 테이블
CREATE TABLE bookstbl (
  Idx INT NOT NULL IDENTITY PRIMARY KEY,
  Author VARCHAR(45),
  Division CHAR(4) NOT NULL
	FOREIGN KEY REFERENCES divtbl(Division),
  Names VARCHAR(100),
  ReleaseDate DATE,
  ISBN VARCHAR(200),
  Price DECIMAL(10,0))

-- 회원테이블
CREATE TABLE membertbl (
  Idx INT NOT NULL IDENTITY PRIMARY KEY,
  Names VARCHAR(45) NOT NULL,
  Levels CHAR(1),
  Addr VARCHAR(100),
  Mobile VARCHAR(13),
  Email VARCHAR(50))

-- 대여테이블
CREATE TABLE rentaltbl (
  Idx INT NOT NULL IDENTITY PRIMARY KEY,
  memberIdx INT
   FOREIGN KEY REFERENCES membertbl(Idx),
  bookIdx INT
	FOREIGN KEY REFERENCES bookstbl(Idx),
  rentalDate DATE,
  returnDate DATE)