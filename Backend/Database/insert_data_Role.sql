-- Insert Role: Admin (giá trị 0)
INSERT INTO [Project_PRN232].[dbo].[roles] ([id], [role_name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NULL);

-- Insert Role: Librarian (giá trị 1)
INSERT INTO [Project_PRN232].[dbo].[roles] ([id], [role_name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES (NEWID(), 1, GETDATE(), GETDATE(), NULL);

-- Insert Role: Student (giá trị 2)
INSERT INTO [Project_PRN232].[dbo].[roles] ([id], [role_name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES (NEWID(), 2, GETDATE(), GETDATE(), NULL);