-- Hash mật khẩu mẫu (ĐÂY LÀ VÍ DỤ. BẠN CẦN TẠO CÁC CHUỖI HASH THỰC TẾ TRONG MÃ C#):
-- Để tạo một hash cho "Password@123" trong C#:
-- string hashedPassword = BCrypt.Net.BCrypt.HashPassword("Password@123");

-- User 1: Admin
INSERT INTO [Project_PRN232].[dbo].[users] (
    [id], [username], [password_hash], [email], [phone_number],
    [date_of_birth], [gender], [address], [role_id], [image_url],
    [CreatedAt], [UpdatedAt], [DeletedAt], [StudentCode]
)
VALUES (
    NEWID(),                                 -- id
    'Admin',                                 -- username
    '$2a$12$VRgob0VNZ3IB/tgyTdnP6e9VDfDuHdXNHkoijAsvpvKvuqXWTrdUS',-- password_hash (đã hash từ "123")
    'admin@gmail.com',                       -- email
    '0901234567',                            -- phone_number
    '1990-01-15',                            -- date_of_birth (YYYY-MM-DD)
    0,                                       -- gender (0: Male, 1: Female)
    N'123 Đường Điện Biên Phủ, Quận 1, TP.HCM',      -- address (N' để hỗ trợ Unicode)
    '54ACC053-02F6-4786-B1B3-4925514EC359',  -- Thay thế bằng ID thực tế của vai trò Admin
    NULL,                                    -- image_url
    GETDATE(),                               -- CreatedAt
    GETDATE(),                               -- UpdatedAt
    NULL,                                    -- DeletedAt
    'DE170484'                               -- StudentCode
);

-- User 2: Librarian
INSERT INTO [Project_PRN232].[dbo].[users] (
    [id], [username], [password_hash], [email], [phone_number],
    [date_of_birth], [gender], [address], [role_id], [image_url],
    [CreatedAt], [UpdatedAt], [DeletedAt], [StudentCode]
)
VALUES (
    NEWID(),
    'Librarian',
    '$2a$12$VRgob0VNZ3IB/tgyTdnP6e9VDfDuHdXNHkoijAsvpvKvuqXWTrdUS', -- password_hash (đã hash từ "123")
    'librarian@gmail.com',
    '0912345678',
    '1985-05-20',
    1,                                       -- gender (1: Female)
    N'456 Đường Hai Bà Trưng, Quận Hoàn Kiếm, Hà Nội',
    '974FBA45-D8FF-470B-AE10-1C80873632F9',  -- Thay thế bằng ID thực tế của vai trò Librarian
    NULL,
    GETDATE(),
    GETDATE(),
    NULL,
    'DE170485'
);

-- User 3: Student
INSERT INTO [Project_PRN232].[dbo].[users] (
    [id], [username], [password_hash], [email], [phone_number],
    [date_of_birth], [gender], [address], [role_id], [image_url],
    [CreatedAt], [UpdatedAt], [DeletedAt], [StudentCode]
)
VALUES (
    NEWID(),
    'Student',
    '$2a$12$VRgob0VNZ3IB/tgyTdnP6e9VDfDuHdXNHkoijAsvpvKvuqXWTrdUS', -- password_hash (đã hash từ "123")
    'student@gmail.com',
    '0987654321',
    '2000-10-10',
    0,                                       -- gender (0: Male)
    N'789 Đường Nguyễn Văn Linh, Quận 3, Đà Nẵng',
    '2AED5442-8AF3-4025-99B7-D3FD10DB69DD',  -- Thay thế bằng ID thực tế của vai trò Student
    NULL,
    GETDATE(),
    GETDATE(),
    NULL,
    'DE170486'
);