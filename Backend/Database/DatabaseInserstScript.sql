-----------------------------------------------------------------------------------
-- IF THERE IS NO DATA IN YOUR Project_PRN232 DATABASE, PLEASE DELETE THIS SECTION.
-----------------------------------------------------------------------------------
USE Project_PRN232;
-- Disable foreign key constraints temporarily (for SQL Server)
EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
-- Delete data from all tables
DELETE FROM Borrow_Records;
DELETE FROM Book_Reservations;
DELETE FROM Book_Reviews;
DELETE FROM Book_Favorites;
DELETE FROM Book_Copies;
DELETE FROM Books;
DELETE FROM Users;
DELETE FROM Events;
DELETE FROM Authors;
DELETE FROM Categories;
DELETE FROM Publishers;
DELETE FROM Roles;
-- Re-enable foreign key constraints
EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
-----------------------------------------------------------------------------------
-- IF THERE IS NO DATA IN YOUR Project_PRN232 DATABASE, PLEASE DELETE THIS SECTION.
-----------------------------------------------------------------------------------

USE Project_PRN232;

DECLARE @fixedDateTime DATETIME = '2024-09-15 10:23:53.000';
DECLARE @currentDate DATE = CAST(GETDATE() AS DATE);

-- --- ROLES (20 records - 3 fixed roles + 17 dummy) ---
-- GUIDs for fixed Roles
DECLARE @adminrole_id UNIQUEIDENTIFIER = NEWID();
DECLARE @librarianrole_id UNIQUEIDENTIFIER = NEWID();
DECLARE @studentrole_id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Roles (Id, role_name, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@adminrole_id, 0, @fixedDateTime, @fixedDateTime, NULL),
(@librarianrole_id, 1, @fixedDateTime, @fixedDateTime, NULL),
(@studentrole_id, 2, @fixedDateTime, @fixedDateTime, NULL);

-- --- USERS (20 records) ---
-- GUIDs for Users (already 10, add 10 more)
DECLARE @user1Id UNIQUEIDENTIFIER = NEWID(); -- Admin
DECLARE @user2Id UNIQUEIDENTIFIER = NEWID(); -- Librarian
DECLARE @user3Id UNIQUEIDENTIFIER = NEWID(); -- Student
DECLARE @user4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @user20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Users (Id, Username, password_hash, Email, Phone_Number, Date_Of_Birth, Gender, Address, role_id, Image_Url, CreatedAt, UpdatedAt, DeletedAt, StudentCode) VALUES
(@user1Id, 'adminuser', '123123', 'admin@example.com', '0912345678', '1980-01-01', 0, '123 Admin St, City A', @adminrole_id, NULL, '2022-01-15 09:23:53.123', '2024-03-10 14:45:00.567', NULL, 'admin'),

(@user2Id, 'librarianuser', '123123', 'lib@example.com', '0912345679', '1985-02-15', 1, '456 Library Rd, City B', @librarianrole_id, NULL,  '2021-05-20 11:00:00.000', '2023-11-25 08:30:15.987', NULL, 'librarian'),

(@user3Id, 'student1', '123123', 'stu1@example.com', '0912345680', '2000-03-20', 0, '789 Student Apt, City C', @studentrole_id, NULL, '2020-08-01 15:10:20.400', '2022-02-05 16:05:30.120', NULL, 'ST001'),

(@user4Id, 'student2', '123123', 'stu2@example.com', '0912345681', '2001-04-25', 1, '101 Student Dorm, City C', @studentrole_id, NULL, '2023-02-10 07:00:00.000', '2024-09-12 20:10:05.000', NULL, 'ST002'),

(@user5Id, 'student3', '123123', 'stu3@example.com', '0912345682', '1999-05-30', 0, '202 University Blvd, City C', @studentrole_id, NULL, '2022-07-07 10:30:45.000', '2025-01-01 00:00:00.000', NULL, 'ST003'),

(@user6Id, 'john.doe', '123123', 'john.doe@example.com', '0912345683', '1998-06-01', 0, '303 Oak St, Town D', @studentrole_id, NULL, '2021-03-03 18:20:10.000', '2023-06-15 09:00:00.000', NULL, 'ST004'),

(@user7Id, 'jane.smith', '123123', 'jane.smith@example.com', '0912345684', '2002-07-07', 1, '404 Pine St, Town D', @studentrole_id, NULL, '2024-04-10 13:00:00.000', '2025-05-20 11:30:00.000', NULL, 'ST005'),

(@user8Id, 'peter.jones', '123123', 'peter.jones@example.com', '0912345685', '1997-08-10', 0, '505 Maple Ave, Town E', @studentrole_id, NULL, '2020-11-20 08:00:00.000', '2021-12-01 10:10:10.000', NULL, 'ST006'),

(@user9Id, 'alice.brown', '12213', 'alice.brown@example.com', '0912345686', '2003-09-12', 1, '606 Birch Ln, Town E', @studentrole_id, NULL, '2023-01-01 12:00:00.000', '2024-07-22 17:00:00.000', NULL, 'ST007'),

(@user10Id, 'bob.white', '123123', 'bob.white@example.com', '0912345687', '1996-10-15', 0, '707 Cedar Dr, Town F', @studentrole_id, NULL, '2022-09-15 09:45:00.000', '2025-06-01 06:00:00.000', NULL, 'ST008'),

(@user11Id, 'charlie.green', '123123', 'charlie.green@example.com', '0912345688', '2004-11-20', 0, '808 Elm Rd, Town F', @studentrole_id, NULL, '2024-02-28 14:00:00.000', '2025-03-05 09:00:00.000', NULL, 'ST009'),

(@user12Id, 'diana.king', '123123', 'diana.king@example.com', '0912345689', '1995-12-25', 1, '909 Willow Cres, Town G', @studentrole_id, NULL, '2020-03-10 11:00:00.000', '2021-04-20 15:00:00.000', NULL, 'ST010'),

(@user13Id, 'eva.lopez', '123123', 'eva.lopez@example.com', '0912345690', '2000-01-05', 1, '111 Poplar Blvd, Town G', @studentrole_id, NULL, '2023-05-01 10:00:00.000', '2024-10-10 19:00:00.000', NULL, 'ST011'),

(@user14Id, 'frank.moore', '123123', 'frank.moore@example.com', '0912345691', '1997-02-14', 0, '222 Aspen Pkwy, Town H', @studentrole_id, NULL, '2021-01-20 09:00:00.000', '2022-08-08 11:00:00.000', NULL, 'ST012'),

(@user15Id, 'grace.hall', '123123', 'grace.hall@example.com', '0912345692', '2001-03-03', 1, '333 Spruce St, Town H', @studentrole_id, NULL, '2024-01-05 16:00:00.000', '2025-04-15 14:00:00.000', NULL, 'ST013'),

(@user16Id, 'harry.clark', '123123', 'harry.clark@example.com', '0912345693', '1994-04-08', 0, '444 Palm Ave, Town I', @studentrole_id, NULL, '2020-07-01 10:00:00.000', '2021-09-30 17:00:00.000', NULL, 'ST014'),

(@user17Id, 'ivy.davis', '123123', 'ivy.davis@example.com', '0912345694', '2002-05-19', 1, '555 Cherry Ln, Town I', @studentrole_id, NULL, '2023-08-12 11:00:00.000', '2024-11-01 10:00:00.000', NULL, 'ST015'),

(@user18Id, 'jack.evans', '123123', 'jack.evans@example.com', '0912345695', '1999-06-21', 0, '666 Vine Dr, Town J', @studentrole_id, NULL, '2021-06-20 14:00:00.000', '2023-01-25 12:00:00.000', NULL, 'ST016'),

(@user19Id, 'kathy.harris', '123123', 'kathy.harris@example.com', '0912345696', '2003-07-30', 1, '777 Peach Blvd, Town J', @studentrole_id, NULL, '2024-06-01 09:00:00.000', '2025-06-20 15:00:00.000', NULL, 'ST017'),

(@user20Id, 'leo.jackson', '123123', 'leo.jackson@example.com', '0912345697', '1996-08-05', 0, '888 Plum Pkwy, Town K', @studentrole_id, NULL, '2022-04-01 08:00:00.000', '2025-06-25 10:00:00.000', NULL, 'ST018');

-- --- AUTHORS (20 records) ---
-- GUIDs for Authors (already 10, add 10 more)
DECLARE @author1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @author20Id UNIQUEIDENTIFIER = NEWID();

-- Assume all @authorXId variables are already declared and populated with valid GUIDs.
-- If not, you need to include the Author GUID declarations from the previous script BEFORE this INSERT statement.

INSERT INTO Authors (Id, author_name, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@author1Id, 'Stephen King', '2020-03-10 10:30:00.000', '2024-05-20 14:15:30.000', NULL),
(@author2Id, 'J.K. Rowling', '2021-01-20 09:00:00.000', '2023-11-01 11:45:00.000', NULL),
(@author3Id, 'George R.R. Martin', '2020-07-05 11:20:00.000', '2022-09-10 16:30:00.000', NULL),
(@author4Id, 'Agatha Christie', '2022-04-12 08:00:00.000', '2025-01-01 10:00:00.000', NULL),
(@author5Id, 'Haruki Murakami', '2021-08-15 13:00:00.000', '2024-02-28 09:00:00.000', NULL),
(@author6Id, 'Nguyễn Nhật Ánh', '2020-02-20 09:30:00.000', '2023-07-07 14:00:00.000', NULL),
(@author7Id, 'Tô Hoài', '2021-06-01 10:00:00.000', '2024-04-01 16:00:00.000', NULL),
(@author8Id, 'Dương Thụy', '2022-10-10 11:00:00.000', '2025-03-15 08:00:00.000', NULL),
(@author9Id, 'Trang Hạ', '2021-04-05 14:00:00.000', '2023-09-20 12:00:00.000', NULL),
(@author10Id, 'Nguyễn Phong Sắc', '2020-09-01 07:00:00.000', '2022-11-11 15:00:00.000', NULL),
(@author11Id, 'Nguyễn Du', '2023-01-01 12:00:00.000', '2024-06-05 10:00:00.000', NULL),
(@author12Id, 'Vũ Trọng Phụng', '2022-05-15 10:00:00.000', '2025-02-10 13:00:00.000', NULL),
(@author13Id, 'Ernest Hemingway', '2021-02-01 08:00:00.000', '2023-04-20 16:00:00.000', NULL),
(@author14Id, 'Jane Austen', '2020-10-25 11:00:00.000', '2022-12-30 09:00:00.000', NULL),
(@author15Id, 'F. Scott Fitzgerald', '2023-03-01 15:00:00.000', '2024-12-01 14:00:00.000', NULL),
(@author16Id, 'Leo Tolstoy', '2021-07-10 12:00:00.000', '2024-01-20 11:00:00.000', NULL),
(@author17Id, 'Mark Twain', '2022-08-01 09:00:00.000', '2025-04-25 10:00:00.000', NULL),
(@author18Id, 'Gabriel Garcia Marquez', '2020-04-04 16:00:00.000', '2023-05-05 13:00:00.000', NULL),
(@author19Id, 'Hồ Biểu Chánh', '2023-06-15 10:00:00.000', '2025-06-20 16:00:00.000', NULL),
(@author20Id, 'Nam Cao', '2022-02-02 08:00:00.000', '2025-06-26 18:00:00.000', NULL);

-- --- CATEGORIES (20 records) ---
-- GUIDs for Categories (already 10, add 10 more)
DECLARE @category1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @category20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Categories (Id, category_name, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@category1Id, 'Fiction', '2020-03-20 10:00:00.000', '2024-05-15 14:30:00.000', NULL),
(@category2Id, 'Science', '2021-01-10 11:00:00.000', '2023-10-25 09:45:00.000', NULL),
(@category3Id, 'History', '2020-06-25 15:00:00.000', '2022-08-01 16:10:00.000', NULL),
(@category4Id, 'Fantasy', '2022-05-01 07:30:00.000', '2025-01-10 11:00:00.000', NULL),
(@category5Id, 'Biography', '2021-09-05 13:00:00.000', '2024-03-05 10:20:00.000', NULL),
(@category6Id, 'Mystery', '2020-02-15 09:00:00.000', '2023-08-18 15:00:00.000', NULL),
(@category7Id, 'Romance', '2021-07-01 10:00:00.000', '2024-05-20 17:00:00.000', NULL),
(@category8Id, 'Technology', '2022-11-05 14:00:00.000', '2025-04-01 09:00:00.000', NULL),
(@category9Id, 'Art', '2021-04-20 10:30:00.000', '2023-10-01 11:00:00.000', NULL),
(@category10Id, 'Travel', '2020-09-10 08:00:00.000', '2022-12-12 14:00:00.000', NULL),
(@category11Id, 'Self-Help', '2023-01-10 12:00:00.000', '2024-07-01 10:30:00.000', NULL),
(@category12Id, 'Cooking', '2022-06-01 11:00:00.000', '2025-03-20 13:00:00.000', NULL),
(@category13Id, 'Health', '2021-03-05 09:00:00.000', '2023-05-10 16:00:00.000', NULL),
(@category14Id, 'Business', '2020-11-18 14:00:00.000', '2022-01-25 10:00:00.000', NULL),
(@category15Id, 'Children''s', '2023-04-01 10:00:00.000', '2024-12-25 11:00:00.000', NULL),
(@category16Id, 'Poetry', '2021-05-25 09:00:00.000', '2024-02-14 15:00:00.000', NULL),
(@category17Id, 'Philosophy', '2022-07-15 13:00:00.000', '2025-05-01 12:00:00.000', NULL),
(@category18Id, 'Psychology', '2020-04-30 11:00:00.000', '2023-06-01 14:00:00.000', NULL),
(@category19Id, 'Education', '2023-09-01 08:00:00.000', '2025-06-20 10:00:00.000', NULL),
(@category20Id, 'Comics', '2022-02-22 10:00:00.000', '2025-06-26 15:00:00.000', NULL); 


-- --- PUBLISHERS (20 records) ---
-- GUIDs for Publishers (already 10, add 10 more)
DECLARE @publisher1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @publisher20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Publishers (Id, publisher_name, Address, Phone_Number, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@publisher1Id, 'Penguin Random House', 'New York, USA', '123-456-7890', '2020-05-01 10:00:00.000', '2024-06-01 14:30:00.000', NULL),
(@publisher2Id, 'HarperCollins', 'New York, USA', '123-456-7891', '2021-02-10 11:00:00.000', '2023-12-15 09:45:00.000', NULL),
(@publisher3Id, 'Simon & Schuster', 'New York, USA', '123-456-7892', '2020-08-20 15:00:00.000', '2022-10-01 16:10:00.000', NULL),
(@publisher4Id, 'Hachette Livre', 'Paris, France', '123-456-7893', '2022-03-05 07:30:00.000', '2025-02-20 11:00:00.000', NULL),
(@publisher5Id, 'Macmillan Publishers', 'London, UK', '123-456-7894', '2021-10-15 13:00:00.000', '2024-04-10 10:20:00.000', NULL),
(@publisher6Id, 'Kim Đồng Publishing House', 'Hanoi, Vietnam', '024-3864-7123', '2020-01-10 09:30:00.000', '2023-08-05 14:00:00.000', NULL),
(@publisher7Id, 'Nhã Nam', 'Hanoi, Vietnam', '024-3767-8910', '2021-07-25 10:00:00.000', '2024-06-01 17:00:00.000', NULL),
(@publisher8Id, 'Alpha Books', 'Hanoi, Vietnam', '024-3722-7901', '2022-12-01 14:00:00.000', '2025-05-10 09:00:00.000', NULL),
(@publisher9Id, 'Fahasa', 'Ho Chi Minh City, Vietnam', '028-3820-0080', '2021-05-05 10:30:00.000', '2023-11-20 11:00:00.000', NULL),
(@publisher10Id, 'First News', 'Ho Chi Minh City, Vietnam', '028-3822-7901', '2020-09-20 08:00:00.000', '2022-01-05 14:00:00.000', NULL),
(@publisher11Id, 'Bloomsbury Publishing', 'London, UK', '123-456-7895', '2023-02-01 12:00:00.000', '2024-08-10 10:30:00.000', NULL),
(@publisher12Id, 'Scholastic Corporation', 'New York, USA', '123-456-7896', '2022-06-10 11:00:00.000', '2025-01-25 13:00:00.000', NULL),
(@publisher13Id, 'Pearson Education', 'London, UK', '123-456-7897', '2021-04-15 09:00:00.000', '2023-07-01 16:00:00.000', NULL),
(@publisher14Id, 'Wiley', 'Hoboken, USA', '123-456-7898', '2020-11-01 14:00:00.000', '2022-03-18 10:00:00.000', NULL),
(@publisher15Id, 'Cambridge University Press', 'Cambridge, UK', '123-456-7899', '2023-05-20 10:00:00.000', '2024-11-11 14:00:00.000', NULL),
(@publisher16Id, 'Oxford University Press', 'Oxford, UK', '123-456-7900', '2021-08-01 09:00:00.000', '2024-03-01 15:00:00.000', NULL),
(@publisher17Id, 'Vintage Books', 'New York, USA', '123-456-7901', '2022-09-05 13:00:00.000', '2025-06-05 12:00:00.000', NULL),
(@publisher18Id, 'Dover Publications', 'Mineola, USA', '123-456-7902', '2020-03-15 11:00:00.000', '2023-04-01 14:00:00.000', NULL),
(@publisher19Id, 'NXB Trẻ', 'Ho Chi Minh City, Vietnam', '028-3829-1999', '2023-07-01 08:00:00.000', '2025-06-20 10:00:00.000', NULL), 
(@publisher20Id, 'NXB Lao Động', 'Hanoi, Vietnam', '024-3825-7890', '2022-01-01 10:00:00.000', '2025-06-26 15:00:00.000', NULL); 

-- --- BOOKS (20 records) ---
-- GUIDs for Books
DECLARE @book1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @book20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Books (Id, Title, author_id, category_id, publisher_id, publication_year, Description, Status, Image_Url, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@book1Id, 'The Shining', @author1Id, @category1Id, @publisher1Id, 1977, 'Horror novel by Stephen King.', 'Available', 'https://example.com/shining.jpg',
    '2020-01-05 10:00:00.000', '2024-03-10 15:30:00.000', NULL),
(@book2Id, 'Harry Potter and the Sorcerer''s Stone', @author2Id, @category4Id, @publisher2Id, 1997, 'First book in the Harry Potter series.', 'Available', 'https://example.com/hp1.jpg',
    '2021-02-15 11:30:00.000', '2023-10-20 09:00:00.000', NULL),
(@book3Id, 'A Game of Thrones', @author3Id, @category4Id, @publisher3Id, 1996, 'First book of A Song of Ice and Fire.', 'Available', 'https://example.com/got.jpg',
    '2020-06-20 14:00:00.000', '2022-09-01 16:00:00.000', NULL),
(@book4Id, 'And Then There Were None', @author4Id, @category6Id, @publisher4Id, 1939, 'Classic mystery novel.', 'Available', 'https://example.com/agatha.jpg',
    '2022-04-01 09:00:00.000', '2025-01-15 10:00:00.000', NULL),
(@book5Id, 'Norwegian Wood', @author5Id, @category1Id, @publisher5Id, 1987, 'Coming-of-age novel by Haruki Murakami.', 'Available', 'https://example.com/norwegian.jpg',
    '2021-09-01 12:00:00.000', '2024-02-20 08:30:00.000', NULL),
(@book6Id, 'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', @author6Id, @category1Id, @publisher6Id, 2010, 'Tiểu thuyết của Nguyễn Nhật Ánh.', 'Available', 'https://example.com/hoavang.jpg',
    '2020-03-01 10:00:00.000', '2023-07-10 14:00:00.000', NULL),
(@book7Id, 'Dế Mèn Phiêu Lưu Ký', @author7Id, @category15Id, @publisher7Id, 1941, 'Truyện thiếu nhi kinh điển.', 'Available', 'https://example.com/demen.jpg',
    '2021-07-05 09:00:00.000', '2024-05-01 16:00:00.000', NULL),
(@book8Id, 'Đi Qua Hoa Cúc', @author8Id, @category7Id, @publisher8Id, 2008, 'Tập truyện ngắn lãng mạn.', 'Available', 'https://example.com/hoacuc.jpg',
    '2022-10-20 11:00:00.000', '2025-04-10 09:00:00.000', NULL),
(@book9Id, 'Cho Một Tình Yêu', @author9Id, @category7Id, @publisher9Id, 2007, 'Tản văn về tình yêu.', 'Available', 'https://example.com/tinhyv.jpg',
    '2021-04-10 14:00:00.000', '2023-11-05 12:00:00.000', NULL),
(@book10Id, 'Tắt Đèn', @author10Id, @category3Id, @publisher10Id, 1937, 'Tiểu thuyết hiện thực phê phán.', 'Available', 'https://example.com/tatden.jpg',
    '2020-09-25 07:00:00.000', '2022-12-01 15:00:00.000', NULL),
(@book11Id, 'Truyện Kiều', @author11Id, @category16Id, @publisher6Id, 1820, 'Kiệt tác thơ nôm của Nguyễn Du.', 'Available', 'https://example.com/truyenkie.jpg',
    '2023-01-10 12:00:00.000', '2024-07-01 10:00:00.000', NULL),
(@book12Id, 'Số Đỏ', @author12Id, @category1Id, @publisher7Id, 1938, 'Tiểu thuyết trào phúng của Vũ Trọng Phụng.', 'Available', 'https://example.com/sodo.jpg',
    '2022-05-20 10:00:00.000', '2025-03-01 13:00:00.000', NULL),
(@book13Id, 'The Old Man and the Sea', @author13Id, @category1Id, @publisher17Id, 1952, 'A novella by Ernest Hemingway.', 'Available', 'https://example.com/oldmansea.jpg',
    '2021-03-01 08:00:00.000', '2023-05-10 16:00:00.000', NULL),
(@book14Id, 'Pride and Prejudice', @author14Id, @category7Id, @publisher17Id, 1813, 'A romance novel by Jane Austen.', 'Available', 'https://example.com/prideprejudice.jpg',
    '2020-11-01 11:00:00.000', '2023-01-01 09:00:00.000', NULL),
(@book15Id, 'The Great Gatsby', @author15Id, @category1Id, @publisher17Id, 1925, 'A novel by F. Scott Fitzgerald.', 'Available', 'https://example.com/gatsby.jpg',
    '2023-04-15 15:00:00.000', '2024-12-10 14:00:00.000', NULL),
(@book16Id, 'War and Peace', @author16Id, @category1Id, @publisher17Id, 1869, 'An epic novel by Leo Tolstoy.', 'Available', 'https://example.com/warpeace.jpg',
    '2021-07-20 12:00:00.000', '2024-02-01 11:00:00.000', NULL),
(@book17Id, 'The Adventures of Tom Sawyer', @author17Id, @category15Id, @publisher18Id, 1876, 'A classic American novel by Mark Twain.', 'Available', 'https://example.com/tomsawyer.jpg',
    '2022-08-10 09:00:00.000', '2025-05-15 10:00:00.000', NULL),
(@book18Id, 'One Hundred Years of Solitude', @author18Id, @category1Id, @publisher17Id, 1967, 'A masterpiece by Gabriel Garcia Marquez.', 'Available', 'https://example.com/solitude.jpg',
    '2020-05-05 16:00:00.000', '2023-06-10 13:00:00.000', NULL),
(@book19Id, 'Thầy Thuốc', @author19Id, @category1Id, @publisher19Id, 1920, 'Tiểu thuyết của Hồ Biểu Chánh.', 'Available', 'https://example.com/thaythuoc.jpg',
    '2023-07-05 10:00:00.000', '2025-06-20 16:00:00.000', NULL), 
(@book20Id, 'Chí Phèo', @author20Id, @category1Id, @publisher20Id, 1941, 'Truyện ngắn nổi tiếng của Nam Cao.', 'Available', 'https://example.com/chipheo.jpg',
    '2022-02-05 08:00:00.000', '2025-06-26 18:00:00.000', NULL); 

-- --- BOOK COPIES (40 records - 2 copies per book) ---
-- Declare GUIDs for 40 book copies
DECLARE @bookCopyCounter INT = 1;
DECLARE @bookCopies TABLE (
    Id UNIQUEIDENTIFIER,
    book_id UNIQUEIDENTIFIER,
    CopyCode NVARCHAR(50),
    Status NVARCHAR(50),
    CreatedAt DATETIME,
    UpdatedAt DATETIME,
    DeletedAt DATETIME
);

INSERT INTO @bookCopies (Id, book_id, CopyCode, Status, CreatedAt, UpdatedAt, DeletedAt)
SELECT NEWID(), Id, 'CP-' + RIGHT(CAST(NEWID() AS NVARCHAR(36)), 4) + '-01', 'Available', @fixedDateTime, @fixedDateTime, NULL FROM Books;

INSERT INTO @bookCopies (Id, book_id, CopyCode, Status, CreatedAt, UpdatedAt, DeletedAt)
SELECT NEWID(), Id, 'CP-' + RIGHT(CAST(NEWID() AS NVARCHAR(36)), 4) + '-02', 'Available', @fixedDateTime, @fixedDateTime, NULL FROM Books;

-- Insert into the actual Book_Copies table
INSERT INTO Book_Copies SELECT * FROM @bookCopies;


-- --- EVENTS (20 records) ---
-- GUIDs for Events (already 10, add 10 more)
DECLARE @event1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @event20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Events (Id, event_name, event_date, Description, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@event1Id, 'Library Grand Opening', '2023-01-15', 'Grand opening ceremony of the new library.',
    '2022-12-01 10:00:00.000', '2023-01-10 14:30:00.000', NULL), 
(@event2Id, 'Book Fair 2023', '2023-03-10', 'Annual book fair with discounted books.',
    '2023-02-01 11:00:00.000', '2023-03-05 09:45:00.000', NULL), 
(@event3Id, 'Author Meet & Greet: Stephen King', '2023-05-20', 'Meet and greet session with author Stephen King.',
    '2023-04-10 15:00:00.000', '2023-05-18 16:10:00.000', NULL), 
(@event4Id, 'Summer Reading Challenge', '2023-06-01', 'Reading challenge for students during summer.',
    '2023-05-15 07:30:00.000', '2023-05-28 11:00:00.000', NULL), 
(@event5Id, 'Children''s Story Time', '2023-07-05', 'Weekly story time for young children.',
    '2023-06-20 13:00:00.000', '2023-07-03 10:20:00.000', NULL), 
(@event6Id, 'Digital Literacy Workshop', '2023-08-12', 'Workshop on improving digital literacy skills.',
    '2023-07-25 09:00:00.000', '2023-08-08 15:00:00.000', NULL), 
(@event7Id, 'Poetry Slam Night', '2023-09-15', 'Open mic night for poetry enthusiasts.',
    '2023-08-30 10:00:00.000', '2023-09-12 17:00:00.000', NULL), 
(@event8Id, 'Local History Talk', '2023-10-26', 'Discussion on the history of the local area.',
    '2023-10-01 14:00:00.000', '2023-10-20 09:00:00.000', NULL), 
(@event9Id, 'Halloween Story Night', '2023-10-31', 'Spooky stories for Halloween.',
    '2023-10-15 10:30:00.000', '2023-10-29 11:00:00.000', NULL), 
(@event10Id, 'Winter Book Drive', '2023-12-01', 'Collecting books for donation during winter.',
    '2023-11-10 08:00:00.000', '2023-11-28 14:00:00.000', NULL), 
(@event11Id, 'New Member Orientation', '2024-01-20', 'Session for new library members.',
    '2024-01-01 12:00:00.000', '2024-01-18 10:30:00.000', NULL), 
(@event12Id, 'Tech Talk: AI in Libraries', '2024-02-28', 'Discussion on artificial intelligence applications in library science.',
    '2024-02-10 11:00:00.000', '2024-02-25 13:00:00.000', NULL), 
(@event13Id, 'Youth Reading Club', '2024-03-15', 'Monthly meeting for young readers.',
    '2024-03-01 09:00:00.000', '2024-03-12 16:00:00.000', NULL), 
(@event14Id, 'Creative Writing Workshop', '2024-04-10', 'Workshop to enhance creative writing skills.',
    '2024-03-20 14:00:00.000', '2024-04-05 10:00:00.000', NULL), 
(@event15Id, 'Film Screening: Classic Novels', '2024-05-05', 'Screening of movie adaptations of classic novels.',
    '2024-04-20 10:00:00.000', '2024-05-01 14:00:00.000', NULL), 
(@event16Id, 'Local Author Showcase', '2024-06-22', 'Event featuring works by local authors.',
    '2024-06-01 09:00:00.000', '2024-06-18 15:00:00.000', NULL), 
(@event17Id, 'Art Exhibition: Literary Themes', '2024-07-18', 'Artworks inspired by literature.',
    '2024-07-01 13:00:00.000', '2025-06-20 12:00:00.000', NULL), 
(@event18Id, 'Coding for Beginners', '2024-08-01', 'Introductory coding workshop for all ages.',
    '2024-07-10 11:00:00.000', '2025-06-22 14:00:00.000', NULL), 
(@event19Id, 'Gardening Book Club', '2024-09-09', 'Discussion group for gardening enthusiasts.',
    '2024-08-20 08:00:00.000', '2025-06-25 10:00:00.000', NULL), 
(@event20Id, 'Holiday Craft Fair', '2024-11-25', 'Craft fair featuring local artisans.',
    '2024-11-01 10:00:00.000', '2025-06-26 15:00:00.000', NULL); 

-- --- BOOK FAVORITES (20 records) ---
-- GUIDs for BookFavorites (already 10, add 10 more)
DECLARE @bookFavorite1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookFavorite20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Book_Favorites (Id, user_id, book_id, added_at, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@bookFavorite1Id, @user3Id, @book1Id, '2023-01-01 10:00:00.000', '2023-01-31 10:00:00.000', '2024-05-10 15:30:00.000', NULL),
(@bookFavorite2Id, @user4Id, @book2Id, '2022-03-15 11:00:00.000', '2022-04-10 11:00:00.000', '2024-01-20 09:00:00.000', NULL),
(@bookFavorite3Id, @user5Id, @book3Id, '2023-07-01 14:00:00.000', '2023-07-21 14:00:00.000', '2025-02-01 16:00:00.000', NULL),
(@bookFavorite4Id, @user6Id, @book4Id, '2021-05-20 09:00:00.000', '2021-06-08 09:00:00.000', '2023-09-01 10:00:00.000', NULL),
(@bookFavorite5Id, @user7Id, @book5Id, '2024-02-10 12:00:00.000', '2024-02-25 12:00:00.000', '2025-04-05 08:30:00.000', NULL),
(@bookFavorite6Id, @user8Id, @book6Id, '2022-09-01 10:00:00.000', '2022-09-13 10:00:00.000', '2024-06-15 14:00:00.000', NULL),
(@bookFavorite7Id, @user9Id, @book7Id, '2023-04-05 15:00:00.000', '2023-04-15 15:00:00.000', '2025-01-20 16:00:00.000', NULL),
(@bookFavorite8Id, @user10Id, @book8Id, '2021-11-10 11:00:00.000', '2021-11-18 11:00:00.000', '2023-10-01 09:00:00.000', NULL),
(@bookFavorite9Id, @user3Id, @book9Id, '2024-05-01 08:00:00.000', '2024-05-08 08:00:00.000', '2025-05-20 12:00:00.000', NULL),
(@bookFavorite10Id, @user4Id, @book10Id, '2022-06-20 16:00:00.000', '2022-06-25 16:00:00.000', '2024-03-01 15:00:00.000', NULL),
(@bookFavorite11Id, @user11Id, @book11Id, '2023-02-01 09:00:00.000', '2023-03-10 09:00:00.000', '2025-06-10 10:00:00.000', NULL),
(@bookFavorite12Id, @user12Id, @book12Id, '2021-08-05 13:00:00.000', '2021-09-09 13:00:00.000', '2024-07-01 13:00:00.000', NULL),
(@bookFavorite13Id, @user13Id, @book13Id, '2024-01-10 10:00:00.000', '2024-02-10 10:00:00.000', '2025-06-15 11:00:00.000', NULL),
(@bookFavorite14Id, @user14Id, @book14Id, '2022-05-01 14:00:00.000', '2022-06-01 14:00:00.000', '2024-08-01 14:00:00.000', NULL),
(@bookFavorite15Id, @user15Id, @book15Id, '2023-11-15 07:00:00.000', '2023-12-10 07:00:00.000', '2025-06-20 09:00:00.000', NULL),
(@bookFavorite16Id, @user16Id, @book16Id, '2021-01-01 11:00:00.000', '2021-01-23 11:00:00.000', '2024-09-01 10:00:00.000', NULL),
(@bookFavorite17Id, @user17Id, @book17Id, '2024-03-01 10:00:00.000', '2024-03-21 10:00:00.000', '2025-06-25 15:00:00.000', NULL),
(@bookFavorite18Id, @user18Id, @book18Id, '2022-07-07 15:00:00.000', '2022-07-25 15:00:00.000', '2024-10-10 11:00:00.000', NULL),
(@bookFavorite19Id, @user19Id, @book19Id, '2023-09-10 09:00:00.000', '2023-09-25 09:00:00.000', '2025-06-26 13:00:00.000', NULL),
(@bookFavorite20Id, @user20Id, @book20Id, '2021-12-01 14:00:00.000', '2022-01-01 14:00:00.000', '2025-06-27 08:00:00.000', NULL); 

-- --- BOOK REVIEWS (20 records) ---
-- GUIDs for BookReviews (already 10, add 10 more)
DECLARE @bookReview1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview2Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview3Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview4Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview5Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview6Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview7Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview8Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview9Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview10Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview11Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview12Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview13Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview14Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview15Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview16Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview17Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview18Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview19Id UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReview20Id UNIQUEIDENTIFIER = NEWID();

INSERT INTO Book_Reviews (Id, user_id, book_id, Rating, Review_Text, Review_Date, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@bookReview1Id, @user3Id, @book1Id, 5, 'Amazing horror story, a classic!', '2023-01-05', '2023-01-07 10:00:00.000', '2024-05-10 15:30:00.000', NULL),
(@bookReview2Id, @user4Id, @book2Id, 5, 'A magical start to a fantastic series!', '2022-03-20', '2022-03-22 11:00:00.000', '2024-01-20 09:00:00.000', NULL),
(@bookReview3Id, @user5Id, @book3Id, 4, 'Complex characters and intriguing plot.', '2023-07-05', '2023-07-07 14:00:00.000', '2025-02-01 16:00:00.000', NULL),
(@bookReview4Id, @user6Id, @book4Id, 5, 'A masterpiece of mystery, highly recommend.', '2021-06-01', '2021-06-03 09:00:00.000', '2023-09-01 10:00:00.000', NULL),
(@bookReview5Id, @user7Id, @book5Id, 4, 'Murakami never disappoints, a unique read.', '2024-02-15', '2024-02-17 12:00:00.000', '2025-04-05 08:30:00.000', NULL),
(@bookReview6Id, @user8Id, @book6Id, 5, 'Cuốn sách rất ý nghĩa và đầy cảm xúc.', '2022-09-05', '2022-09-07 10:00:00.000', '2024-06-15 14:00:00.000', NULL),
(@bookReview7Id, @user9Id, @book7Id, 5, 'Kỷ niệm tuổi thơ với Dế Mèn.', '2023-04-10', '2023-04-12 15:00:00.000', '2025-01-20 16:00:00.000', NULL),
(@bookReview8Id, @user10Id, @book8Id, 4, 'Truyện ngắn lãng mạn nhẹ nhàng.', '2021-11-15', '2021-11-17 11:00:00.000', '2023-10-01 09:00:00.000', NULL),
(@bookReview9Id, @user3Id, @book9Id, 4, 'Đọc để thấy tình yêu thật đẹp.', '2024-05-05', '2024-05-07 08:00:00.000', '2025-05-20 12:00:00.000', NULL),
(@bookReview10Id, @user4Id, @book10Id, 5, 'Phản ánh xã hội sâu sắc.', '2022-06-25', '2022-06-27 16:00:00.000', '2024-03-01 15:00:00.000', NULL),
(@bookReview11Id, @user11Id, @book11Id, 5, 'Kiệt tác văn học Việt Nam.', '2023-02-05', '2023-02-07 09:00:00.000', '2025-06-10 10:00:00.000', NULL),
(@bookReview12Id, @user12Id, @book12Id, 4, 'Hài hước và sâu sắc về xã hội.', '2021-08-10', '2021-08-12 13:00:00.000', '2024-07-01 13:00:00.000', NULL),
(@bookReview13Id, @user13Id, @book13Id, 5, 'Câu chuyện về sự kiên cường và hy vọng.', '2024-01-15', '2024-01-17 10:00:00.000', '2025-06-15 11:00:00.000', NULL),
(@bookReview14Id, @user14Id, @book14Id, 4, 'Tình yêu và định kiến xã hội.', '2022-05-05', '2022-05-07 14:00:00.000', '2024-08-01 14:00:00.000', NULL),
(@bookReview15Id, @user15Id, @book15Id, 5, 'Một cái nhìn u sầu về giấc mơ Mỹ.', '2023-11-20', '2023-11-22 07:00:00.000', '2025-06-20 09:00:00.000', NULL),
(@bookReview16Id, @user16Id, @book16Id, 5, 'Bản hùng ca về chiến tranh và hòa bình.', '2021-01-05', '2021-01-07 11:00:00.000', '2024-09-01 10:00:00.000', NULL),
(@bookReview17Id, @user17Id, @book17Id, 4, 'Phiêu lưu thú vị cho mọi lứa tuổi.', '2024-03-05', '2024-03-07 10:00:00.000', '2025-06-25 15:00:00.000', NULL),
(@bookReview18Id, @user18Id, @book18Id, 5, 'Thế giới huyền ảo và kỳ diệu.', '2022-07-10', '2022-07-12 15:00:00.000', '2024-10-10 11:00:00.000', NULL),
(@bookReview19Id, @user19Id, @book19Id, 4, 'Truyện cổ điển đầy giá trị.', '2023-09-15', '2023-09-17 09:00:00.000', '2025-06-26 13:00:00.000', NULL),
(@bookReview20Id, @user20Id, @book20Id, 5, 'Nỗi đau của người nông dân Việt Nam.', '2021-12-05', '2021-12-07 14:00:00.000', '2025-06-27 08:00:00.000', NULL);

-- --- BOOK RESERVATIONS (20 records) ---
-- GUIDs for BookReservations (using available book copies)
-- We need to select 20 distinct book copies.
-- For simplicity, let's just pick the first 20 IDs from the Book_Copies table that were just inserted.
-- In a real scenario, you might query for available copies more robustly.

-- Get the first 20 book copy IDs for reservations
DECLARE @reservationcopy_ids TABLE (copy_id UNIQUEIDENTIFIER);
INSERT INTO @reservationcopy_ids (copy_id)
SELECT TOP 20 Id FROM Book_Copies ORDER BY NEWID(); -- Randomly pick 20 copies

-- Declare GUIDs for 20 BookReservations
DECLARE @bookReservationId_1 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_2 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_3 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_4 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_5 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_6 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_7 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_8 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_9 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_10 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_11 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_12 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_13 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_14 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_15 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_16 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_17 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_18 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_19 UNIQUEIDENTIFIER = NEWID();
DECLARE @bookReservationId_20 UNIQUEIDENTIFIER = NEWID();

-- Get specific copy IDs for easier linking
DECLARE @copy_idForRes1 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes1;
DECLARE @copy_idForRes2 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes2;
DECLARE @copy_idForRes3 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes3;
DECLARE @copy_idForRes4 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes4;
DECLARE @copy_idForRes5 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes5;
DECLARE @copy_idForRes6 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes6;
DECLARE @copy_idForRes7 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes7;
DECLARE @copy_idForRes8 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes8;
DECLARE @copy_idForRes9 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes9;
DECLARE @copy_idForRes10 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes10;
DECLARE @copy_idForRes11 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes11;
DECLARE @copy_idForRes12 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes12;
DECLARE @copy_idForRes13 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes13;
DECLARE @copy_idForRes14 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes14;
DECLARE @copy_idForRes15 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes15;
DECLARE @copy_idForRes16 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes16;
DECLARE @copy_idForRes17 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes17;
DECLARE @copy_idForRes18 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes18;
DECLARE @copy_idForRes19 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());
DELETE FROM @reservationcopy_ids WHERE copy_id = @copy_idForRes19;
DECLARE @copy_idForRes20 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @reservationcopy_ids ORDER BY NEWID());


INSERT INTO Book_Reservations (Id, user_id, copy_id, Reservation_Date, Status, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@bookReservationId_1, @user3Id, @copy_idForRes1, '2025-07-01', 'Pending', '2025-06-01 10:15:20.000', '2025-06-25 15:30:10.000', NULL),
(@bookReservationId_2, @user4Id, @copy_idForRes2, '2025-07-02', 'Pending', '2025-06-05 11:30:45.000', '2025-06-26 09:45:30.000', NULL),
(@bookReservationId_3, @user5Id, @copy_idForRes3, '2025-07-03', 'Pending', '2025-06-08 14:05:10.000', '2025-06-27 16:10:55.000', NULL),
(@bookReservationId_4, @user6Id, @copy_idForRes4, '2025-07-04', 'Fulfilled', '2025-06-10 09:20:30.000', '2025-06-15 10:00:05.000', NULL),
(@bookReservationId_5, @user7Id, @copy_idForRes5, '2025-07-05', 'Pending', '2025-06-12 12:40:00.000', '2025-06-20 08:30:40.000', NULL),
(@bookReservationId_6, @user8Id, @copy_idForRes6, '2025-07-06', 'Fulfilled', '2025-06-14 10:50:25.000', '2025-06-18 14:00:15.000', NULL),
(@bookReservationId_7, @user9Id, @copy_idForRes7, '2025-07-07', 'Pending', '2025-06-16 15:10:00.000', '2025-06-24 16:00:20.000', NULL),
(@bookReservationId_8, @user10Id, @copy_idForRes8, '2025-07-08', 'Fulfilled', '2025-06-18 11:55:00.000', '2025-06-22 09:00:10.000', NULL),
(@bookReservationId_9, @user11Id, @copy_idForRes9, '2025-07-09', 'Pending', '2025-06-20 08:30:00.000', '2025-06-26 12:00:00.000', NULL),
(@bookReservationId_10, @user12Id, @copy_idForRes10, '2025-07-10', 'Fulfilled', '2025-06-22 16:10:00.000', '2025-06-25 15:00:00.000', NULL),
(@bookReservationId_11, @user13Id, @copy_idForRes11, '2025-07-11', 'Pending', '2025-06-23 09:25:00.000', '2025-06-27 10:00:00.000', NULL),
(@bookReservationId_12, @user14Id, @copy_idForRes12, '2025-07-12', 'Fulfilled', '2025-06-24 13:40:00.000', '2025-06-26 13:00:00.000', NULL),
(@bookReservationId_13, @user15Id, @copy_idForRes13, '2025-07-13', 'Pending', '2025-06-25 10:10:00.000', '2025-06-27 11:00:00.000', NULL),
(@bookReservationId_14, @user16Id, @copy_idForRes14, '2025-07-14', 'Fulfilled', '2025-06-26 14:20:00.000', '2025-06-27 14:00:00.000', NULL),
(@bookReservationId_15, @user17Id, @copy_idForRes15, '2025-07-15', 'Pending', '2025-06-26 16:30:00.000', '2025-06-27 16:00:00.000', NULL),
(@bookReservationId_16, @user18Id, @copy_idForRes16, '2025-07-16', 'Fulfilled', '2025-06-20 09:40:00.000', '2025-06-23 15:00:00.000', NULL),
(@bookReservationId_17, @user19Id, @copy_idForRes17, '2025-07-17', 'Pending', '2025-06-21 10:50:00.000', '2025-06-27 10:00:00.000', NULL),
(@bookReservationId_18, @user20Id, @copy_idForRes18, '2025-07-18', 'Fulfilled', '2025-06-22 15:10:00.000', '2025-06-25 11:00:00.000', NULL),
(@bookReservationId_19, @user3Id, @copy_idForRes19, '2025-07-19', 'Pending', '2025-06-23 09:20:00.000', '2025-06-27 13:00:00.000', NULL),
(@bookReservationId_20, @user4Id, @copy_idForRes20, '2025-07-20', 'Fulfilled', '2025-06-24 14:30:00.000', '2025-06-26 08:00:00.000', NULL);

-- --- BORROW RECORDS (20 records) ---
-- Similar to reservations, we need distinct copy IDs for borrow records.
-- Let's pick another 20 distinct copy IDs.
DECLARE @borrowcopy_ids TABLE (copy_id UNIQUEIDENTIFIER);
INSERT INTO @borrowcopy_ids (copy_id)
SELECT TOP 20 Id FROM Book_Copies WHERE Id NOT IN (SELECT copy_id FROM Book_Reservations) ORDER BY NEWID(); -- Pick copies not used in reservations

-- Declare GUIDs for 20 BorrowRecords
DECLARE @borrowRecordId_1 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_2 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_3 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_4 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_5 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_6 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_7 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_8 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_9 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_10 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_11 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_12 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_13 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_14 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_15 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_16 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_17 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_18 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_19 UNIQUEIDENTIFIER = NEWID();
DECLARE @borrowRecordId_20 UNIQUEIDENTIFIER = NEWID();

-- Get specific copy IDs for easier linking
DECLARE @copy_idForBorrow1 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow1;
DECLARE @copy_idForBorrow2 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow2;
DECLARE @copy_idForBorrow3 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow3;
DECLARE @copy_idForBorrow4 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow4;
DECLARE @copy_idForBorrow5 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow5;
DECLARE @copy_idForBorrow6 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow6;
DECLARE @copy_idForBorrow7 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow7;
DECLARE @copy_idForBorrow8 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow8;
DECLARE @copy_idForBorrow9 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow9;
DECLARE @copy_idForBorrow10 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow10;
DECLARE @copy_idForBorrow11 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow11;
DECLARE @copy_idForBorrow12 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow12;
DECLARE @copy_idForBorrow13 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow13;
DECLARE @copy_idForBorrow14 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow14;
DECLARE @copy_idForBorrow15 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow15;
DECLARE @copy_idForBorrow16 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow16;
DECLARE @copy_idForBorrow17 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow17;
DECLARE @copy_idForBorrow18 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow18;
DECLARE @copy_idForBorrow19 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());
DELETE FROM @borrowcopy_ids WHERE copy_id = @copy_idForBorrow19;
DECLARE @copy_idForBorrow20 UNIQUEIDENTIFIER = (SELECT TOP 1 copy_id FROM @borrowcopy_ids ORDER BY NEWID());

-- Assume all @borrowRecordId_X, @userXId, @copy_idForBorrowX variables are already declared and populated with valid GUIDs.
-- If not, you need to include their declarations from the previous scripts BEFORE this INSERT statement.

INSERT INTO Borrow_Records (Id, user_id, copy_id, Borrow_Date, Due_Date, Return_Date, Fine, Status, ExtensionDateCount, CreatedAt, UpdatedAt, DeletedAt) VALUES
(@borrowRecordId_1, @user6Id, @copy_idForBorrow1, '2025-05-28', '2025-06-07', '2025-06-02', 5.00, 'Returned', 0, '2025-05-28 10:00:00.000', '2025-06-02 11:30:00.000', NULL),
(@borrowRecordId_2, @user8Id, @copy_idForBorrow2, '2025-06-01', '2025-06-11', '2025-06-05', 0.00, 'Returned', 0, '2025-06-01 11:00:00.000', '2025-06-05 12:45:00.000', NULL),
(@borrowRecordId_3, @user10Id, @copy_idForBorrow3, '2025-06-05', '2025-06-15', '2025-06-10', 0.00, 'Returned', 0, '2025-06-05 12:00:00.000', '2025-06-10 14:10:00.000', NULL),
(@borrowRecordId_4, @user3Id, @copy_idForBorrow4, '2025-06-10', '2025-07-05', NULL, 0.00, 'Borrowed', 0, '2025-06-10 09:00:00.000', '2025-06-10 09:00:00.000', NULL),
(@borrowRecordId_5, @user4Id, @copy_idForBorrow5, '2025-06-13', '2025-07-08', NULL, 0.00, 'Borrowed', 0, '2025-06-13 10:30:00.000', '2025-06-13 10:30:00.000', NULL),
(@borrowRecordId_6, @user5Id, @copy_idForBorrow6, '2025-06-15', '2025-07-10', NULL, 0.00, 'Borrowed', 0, '2025-06-15 11:15:00.000', '2025-06-15 11:15:00.000', NULL),
(@borrowRecordId_7, @user7Id, @copy_idForBorrow7, '2025-06-17', '2025-07-12', NULL, 0.00, 'Borrowed', 0, '2025-06-17 14:00:00.000', '2025-06-17 14:00:00.000', NULL),
(@borrowRecordId_8, @user9Id, @copy_idForBorrow8, '2025-06-18', '2025-07-13', NULL, 0.00, 'Borrowed', 0, '2025-06-18 09:00:00.000', '2025-06-18 09:00:00.000', NULL),
(@borrowRecordId_9, @user11Id, @copy_idForBorrow9, '2025-06-19', '2025-07-14', NULL, 0.00, 'Borrowed', 0, '2025-06-19 10:00:00.000', '2025-06-19 10:00:00.000', NULL),
(@borrowRecordId_10, @user12Id, @copy_idForBorrow10, '2025-06-20', '2025-07-15', NULL, 0.00, 'Borrowed', 0, '2025-06-20 11:00:00.000', '2025-06-20 11:00:00.000', NULL),
(@borrowRecordId_11, @user13Id, @copy_idForBorrow11, '2025-06-21', '2025-07-16', NULL, 0.00, 'Borrowed', 0, '2025-06-21 12:00:00.000', '2025-06-21 12:00:00.000', NULL),
(@borrowRecordId_12, @user14Id, @copy_idForBorrow12, '2025-06-22', '2025-07-17', NULL, 0.00, 'Borrowed', 0, '2025-06-22 13:00:00.000', '2025-06-22 13:00:00.000', NULL),
(@borrowRecordId_13, @user15Id, @copy_idForBorrow13, '2025-06-23', '2025-07-18', NULL, 0.00, 'Borrowed', 0, '2025-06-23 14:00:00.000', '2025-06-23 14:00:00.000', NULL),
(@borrowRecordId_14, @user16Id, @copy_idForBorrow14, '2025-06-24', '2025-07-19', NULL, 0.00, 'Borrowed', 0, '2025-06-24 15:00:00.000', '2025-06-24 15:00:00.000', NULL),
(@borrowRecordId_15, @user17Id, @copy_idForBorrow15, '2025-06-25', '2025-07-20', NULL, 0.00, 'Borrowed', 0, '2025-06-25 16:00:00.000', '2025-06-25 16:00:00.000', NULL),
(@borrowRecordId_16, @user18Id, @copy_idForBorrow16, '2025-05-10', '2025-05-20', '2025-05-25', 2.50, 'Returned', 1, '2025-05-10 10:00:00.000', '2025-05-25 11:00:00.000', NULL), 
(@borrowRecordId_17, @user19Id, @copy_idForBorrow17, '2025-05-15', '2025-05-25', '2025-05-28', 1.00, 'Returned', 0, '2025-05-15 11:00:00.000', '2025-05-28 12:00:00.000', NULL), 
(@borrowRecordId_18, @user20Id, @copy_idForBorrow18, '2025-05-20', '2025-05-30', '2025-06-02', 3.00, 'Returned', 2, '2025-05-20 12:00:00.000', '2025-06-02 13:00:00.000', NULL), 
(@borrowRecordId_19, @user3Id, @copy_idForBorrow19, '2025-06-01', '2025-06-11', '2025-06-08', 0.00, 'Returned', 0, '2025-06-01 14:00:00.000', '2025-06-08 15:00:00.000', NULL),
(@borrowRecordId_20, @user4Id, @copy_idForBorrow20, '2025-05-25', '2025-06-04', '2025-05-30', 0.00, 'Returned', 0, '2025-05-25 15:00:00.000', '2025-05-30 16:00:00.000', NULL);
