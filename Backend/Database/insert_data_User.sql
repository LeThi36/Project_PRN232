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
    '2B41A33D-A688-43ED-AC93-07913C185E5D',  -- Thay thế bằng ID thực tế của vai trò Admin
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
    '77A57779-9FC1-4BC4-94E5-9257DEB63E87',  -- Thay thế bằng ID thực tế của vai trò Librarian
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
    '79FC15D5-846E-48DE-B6E1-4E3A7BF0CA6E',  -- Thay thế bằng ID thực tế của vai trò Student
    NULL,
    GETDATE(),
    GETDATE(),
    NULL,
    'DE170486'
);