using System;
using System.Collections.Generic;
using DataLayer.Enum;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class ProjectPrn232Context : DbContext
{
    public ProjectPrn232Context(DbContextOptions<ProjectPrn232Context> options) : base(options) { }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    public virtual DbSet<BookFavorite> BookFavorites { get; set; }

    public virtual DbSet<BookReservation> BookReservations { get; set; }

    public virtual DbSet<BookReview> BookReviews { get; set; }

    public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__authors__3213E83F45E5F6A6");

            entity.ToTable("authors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__books__3213E83F961658F9");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(450)
                .HasColumnName("author_id");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(450)
                .HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
            entity.Property(e => e.PublisherId)
                .HasMaxLength(450)
                .HasColumnName("publisher_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_books_authors");

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_books_categories");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_books_publishers");
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book_cop__3213E83F25D02A04");

            entity.ToTable("book_copies");

            entity.HasIndex(e => e.CopyCode, "UQ__book_cop__5196394F6914230C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId)
                .HasMaxLength(450)
                .HasColumnName("book_id");
            entity.Property(e => e.CopyCode)
                .HasMaxLength(20)
                .HasColumnName("copy_code");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Book).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_copies_books");

        });

        modelBuilder.Entity<BookFavorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book_fav__3213E83F055FA27C");

            entity.ToTable("book_favorites");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("added_at");
            entity.Property(e => e.BookId)
                .HasMaxLength(450)
                .HasColumnName("book_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookFavorites)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_favorites_books");

            entity.HasOne(d => d.User).WithMany(p => p.BookFavorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_favorites_users");
        });

        modelBuilder.Entity<BookReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book_res__3213E83FE1B198C7");

            entity.ToTable("book_reservations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CopyId)
                .HasMaxLength(450)
                .HasColumnName("copy_id");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Copy).WithMany(p => p.BookReservations)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_reservations_book_copies");

            entity.HasOne(d => d.User).WithMany(p => p.BookReservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_reservations_users");
        });

        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book_rev__3213E83F10A2D67B");

            entity.ToTable("book_reviews");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId)
                .HasMaxLength(450)
                .HasColumnName("book_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("review_date");
            entity.Property(e => e.ReviewText).HasColumnName("review_text");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_reviews_books");

            entity.HasOne(d => d.User).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_reviews_users");
        });

        modelBuilder.Entity<BorrowRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__borrow_r__3213E83F6ECCAA08");

            entity.ToTable("borrow_records");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorrowDate).HasColumnName("borrow_date");
            entity.Property(e => e.CopyId)
                .HasMaxLength(450)
                .HasColumnName("copy_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Fine)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fine");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Copy).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_borrow_records_book_copies");

            entity.HasOne(d => d.User).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_borrow_records_users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FBB1165BA");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__events__3213E83F433374A8");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .HasColumnName("event_name");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__publishe__3213E83F7237A8CE");

            entity.ToTable("publishers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(100)
                .HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F9E4EC569");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F4305DF6D");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId)
                .HasMaxLength(450)
                .HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_users_roles");
        });

        //// --- SEED DATA ---
        //// Lưu ý: ID phải là các chuỗi GUID hợp lệ

        //var fixedDateTime = new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Utc);

        //var adminRoleId = "1"; // Hardcode một GUID
        //var librarianRoleId = "2"; // Hardcode một GUID
        //var studentRoleId = "3"; // Hardcode một GUID

        //modelBuilder.Entity<Role>().HasData(
        //    new Role { Id = adminRoleId, RoleName = RoleEnum.Admin, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Role { Id = librarianRoleId, RoleName = RoleEnum.Librarian, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Role { Id = studentRoleId, RoleName = RoleEnum.Student, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //var user1Id = "1"; // Admin
        //var user2Id = "2"; // Librarian
        //var user3Id = "3"; // Student
        //var user4Id = "4";
        //var user5Id = "5";
        //var user6Id = "6";
        //var user7Id = "7";
        //var user8Id = "8";
        //var user9Id = "9";
        //var user10Id = "10";


        //modelBuilder.Entity<User>().HasData(
        //    new User { Id = user1Id, Username = "adminuser", PasswordHash = "hashed_password_admin", Email = "admin@example.com", RoleId = adminRoleId, StudentCode = "admin", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user2Id, Username = "librarianuser", PasswordHash = "hashed_password_lib", Email = "lib@example.com", RoleId = librarianRoleId, StudentCode = "librarian", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user3Id, Username = "student1", PasswordHash = "hashed_password_stu1", Email = "stu1@example.com", RoleId = studentRoleId, StudentCode = "ST001", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user4Id, Username = "student2", PasswordHash = "hashed_password_stu2", Email = "stu2@example.com", RoleId = studentRoleId, StudentCode = "ST002", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user5Id, Username = "student3", PasswordHash = "hashed_password_stu3", Email = "stu3@example.com", RoleId = studentRoleId, StudentCode = "ST003", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user6Id, Username = "john.doe", PasswordHash = "hashed_password_jd", Email = "john.doe@example.com", RoleId = studentRoleId, StudentCode = "ST004", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user7Id, Username = "jane.smith", PasswordHash = "hashed_password_js", Email = "jane.smith@example.com", RoleId = studentRoleId, StudentCode = "ST005", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user8Id, Username = "peter.jones", PasswordHash = "hashed_password_pj", Email = "peter.jones@example.com", RoleId = studentRoleId, StudentCode = "ST006", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user9Id, Username = "alice.brown", PasswordHash = "hashed_password_ab", Email = "alice.brown@example.com", RoleId = studentRoleId, StudentCode = "ST007", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new User { Id = user10Id, Username = "bob.white", PasswordHash = "hashed_password_bw", Email = "bob.white@example.com", RoleId = studentRoleId, StudentCode = "ST008", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //var author1Id = "1";
        //var author2Id = "2";
        //var author3Id = "3";
        //var author4Id = "4";
        //var author5Id = "5";
        //var author6Id = "6";
        //var author7Id = "7";
        //var author8Id = "8";
        //var author9Id = "9";
        //var author10Id = "10";

        //modelBuilder.Entity<Author>().HasData(
        //    new Author { Id = author1Id, AuthorName = "Stephen King", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author2Id, AuthorName = "J.K. Rowling", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author3Id, AuthorName = "George R.R. Martin", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author4Id, AuthorName = "Agatha Christie", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author5Id, AuthorName = "Haruki Murakami", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author6Id, AuthorName = "Nguyễn Nhật Ánh", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author7Id, AuthorName = "Tô Hoài", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author8Id, AuthorName = "Dương Thụy", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author9Id, AuthorName = "Trang Hạ", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Author { Id = author10Id, AuthorName = "Nguyễn Phong Sắc", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //var category1Id = "1"; // Fiction
        //var category2Id = "2"; // Science
        //var category3Id = "3"; // History
        //var category4Id = "4"; // Fantasy
        //var category5Id = "5"; // Biography
        //var category6Id = "6"; // Mystery
        //var category7Id = "7"; // Romance
        //var category8Id = "9"; // Technology
        //var category9Id = "10"; // Art
        //var category10Id = "11"; // Travel

        //modelBuilder.Entity<Category>().HasData(
        //    new Category { Id = category1Id, CategoryName = "Fiction", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category2Id, CategoryName = "Science", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category3Id, CategoryName = "History", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category4Id, CategoryName = "Fantasy", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category5Id, CategoryName = "Biography", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category6Id, CategoryName = "Mystery", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category7Id, CategoryName = "Romance", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category8Id, CategoryName = "Technology", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category9Id, CategoryName = "Art", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Category { Id = category10Id, CategoryName = "Travel", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //var publisher1Id = "1";
        //var publisher2Id = "2";
        //var publisher3Id = "3";
        //var publisher4Id = "4";
        //var publisher5Id = "5";
        //var publisher6Id = "6";
        //var publisher7Id = "7";
        //var publisher8Id = "9";
        //var publisher9Id = "10";
        //var publisher10Id = "11";

        //modelBuilder.Entity<Publisher>().HasData(
        //    new Publisher { Id = publisher1Id, PublisherName = "Penguin Random House", Address = "New York, USA", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher2Id, PublisherName = "HarperCollins", Address = "New York, USA", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher3Id, PublisherName = "Simon & Schuster", Address = "New York, USA", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher4Id, PublisherName = "Hachette Livre", Address = "Paris, France", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher5Id, PublisherName = "Macmillan Publishers", Address = "London, UK", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher6Id, PublisherName = "Kim Đồng Publishing House", Address = "Hanoi, Vietnam", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher7Id, PublisherName = "Nhã Nam", Address = "Hanoi, Vietnam", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher8Id, PublisherName = "Alpha Books", Address = "Hanoi, Vietnam", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher9Id, PublisherName = "Fahasa", Address = "Ho Chi Minh City, Vietnam", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Publisher { Id = publisher10Id, PublisherName = "First News", Address = "Ho Chi Minh City, Vietnam", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //// --- Books ---
        //var book1Id = "book_01_shining";
        //var book2Id = "book_02_hp";
        //var book3Id = "book_03_got";
        //var book4Id = "book_04_none";
        //var book5Id = "book_05_norwegian";
        //var book6Id = "book_06_hoavang";
        //var book7Id = "book_07_demen";
        //var book8Id = "book_08_hoacuc";
        //var book9Id = "book_09_tinhyv";
        //var book10Id = "book_10_tatden";

        //modelBuilder.Entity<Book>().HasData(
        //    new Book { Id = book1Id, Title = "The Shining", AuthorId = author1Id, CategoryId = category1Id, PublisherId = publisher1Id, PublicationYear = 1977, Description = "Horror novel by Stephen King.", Status = "Available", ImageUrl = "https://example.com/shining.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book2Id, Title = "Harry Potter and the Sorcerer's Stone", AuthorId = author2Id, CategoryId = category4Id, PublisherId = publisher2Id, PublicationYear = 1997, Description = "First book in the Harry Potter series.", Status = "Available", ImageUrl = "https://example.com/hp1.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book3Id, Title = "A Game of Thrones", AuthorId = author3Id, CategoryId = category4Id, PublisherId = publisher3Id, PublicationYear = 1996, Description = "First book of A Song of Ice and Fire.", Status = "Available", ImageUrl = "https://example.com/got.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book4Id, Title = "And Then There Were None", AuthorId = author4Id, CategoryId = category6Id, PublisherId = publisher4Id, PublicationYear = 1939, Description = "Classic mystery novel.", Status = "Available", ImageUrl = "https://example.com/agatha.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book5Id, Title = "Norwegian Wood", AuthorId = author5Id, CategoryId = category1Id, PublisherId = publisher5Id, PublicationYear = 1987, Description = "Coming-of-age novel by Haruki Murakami.", Status = "Available", ImageUrl = "https://example.com/norwegian.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book6Id, Title = "Tôi Thấy Hoa Vàng Trên Cỏ Xanh", AuthorId = author6Id, CategoryId = category1Id, PublisherId = publisher6Id, PublicationYear = 2010, Description = "Tiểu thuyết của Nguyễn Nhật Ánh.", Status = "Available", ImageUrl = "https://example.com/hoavang.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book7Id, Title = "Dế Mèn Phiêu Lưu Ký", AuthorId = author7Id, CategoryId = category1Id, PublisherId = publisher7Id, PublicationYear = 1941, Description = "Truyện thiếu nhi kinh điển.", Status = "Available", ImageUrl = "https://example.com/demen.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book8Id, Title = "Đi Qua Hoa Cúc", AuthorId = author8Id, CategoryId = category7Id, PublisherId = publisher8Id, PublicationYear = 2008, Description = "Tập truyện ngắn lãng mạn.", Status = "Available", ImageUrl = "https://example.com/hoacuc.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book9Id, Title = "Cho Một Tình Yêu", AuthorId = author9Id, CategoryId = category7Id, PublisherId = publisher9Id, PublicationYear = 2007, Description = "Tản văn về tình yêu.", Status = "Available", ImageUrl = "https://example.com/tinhyv.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Book { Id = book10Id, Title = "Tắt Đèn", AuthorId = author10Id, CategoryId = category3Id, PublisherId = publisher10Id, PublicationYear = 1937, Description = "Tiểu thuyết hiện thực phê phán.", Status = "Available", ImageUrl = "https://example.com/tatden.jpg", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //// --- BookCopy ---
        //List<BookCopy> bookCopies = new List<BookCopy>();
        //var bookIdsForCopies = new List<string> { book1Id, book2Id, book3Id, book4Id, book5Id, book6Id, book7Id, book8Id, book9Id, book10Id };

        //int bookCopyCounter = 1;
        //foreach (var bId in bookIdsForCopies)
        //{
        //    for (int i = 1; i <= 2; i++) // 2 copies per book
        //    {
        //        bookCopies.Add(new BookCopy
        //        {
        //            Id = $"book_copy_{bookCopyCounter++}", // Đảm bảo mỗi ID là duy nhất
        //            BookId = bId,
        //            CopyCode = $"CP-{bId.Split('_')[1]}-{bookCopyCounter - 1:D2}", // Mã copy rõ ràng hơn
        //            Status = "Available",
        //            CreatedAt = fixedDateTime,
        //            UpdatedAt = fixedDateTime
        //        });
        //    }
        //}
        //modelBuilder.Entity<BookCopy>().HasData(bookCopies);

        //// Events (10 events)
        //modelBuilder.Entity<Event>().HasData(
        //    new Event { Id = "1", EventName = "Library Grand Opening", EventDate = new DateOnly(2023, 1, 15), Description = "Grand opening ceremony of the new library.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "2", EventName = "Book Fair 2023", EventDate = new DateOnly(2023, 3, 10), Description = "Annual book fair with discounted books.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "3", EventName = "Author Meet & Greet: Stephen King", EventDate = new DateOnly(2023, 5, 20), Description = "Meet and greet session with author Stephen King.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "4", EventName = "Summer Reading Challenge", EventDate = new DateOnly(2023, 6, 1), Description = "Reading challenge for students during summer.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "5", EventName = "Children's Story Time", EventDate = new DateOnly(2023, 7, 5), Description = "Weekly story time for young children.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "6", EventName = "Digital Literacy Workshop", EventDate = new DateOnly(2023, 8, 12), Description = "Workshop on improving digital literacy skills.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "7", EventName = "Poetry Slam Night", EventDate = new DateOnly(2023, 9, 15), Description = "Open mic night for poetry enthusiasts.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "8", EventName = "Local History Talk", EventDate = new DateOnly(2023, 10, 26), Description = "Discussion on the history of the local area.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "9", EventName = "Halloween Story Night", EventDate = new DateOnly(2023, 10, 31), Description = "Spooky stories for Halloween.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new Event { Id = "10", EventName = "Winter Book Drive", EventDate = new DateOnly(2023, 12, 1), Description = "Collecting books for donation during winter.", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //// BookFavorites (10 favorites)
        //modelBuilder.Entity<BookFavorite>().HasData(
        //    new BookFavorite { Id = "1", UserId = user3Id, BookId = book1Id, AddedAt = fixedDateTime.AddDays(-30), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "2", UserId = user4Id, BookId = book2Id, AddedAt = fixedDateTime.AddDays(-25), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "3", UserId = user5Id, BookId = book3Id, AddedAt = fixedDateTime.AddDays(-20), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "4", UserId = user6Id, BookId = book4Id, AddedAt = fixedDateTime.AddDays(-18), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "5", UserId = user7Id, BookId = book5Id, AddedAt = fixedDateTime.AddDays(-15), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "6", UserId = user8Id, BookId = book6Id, AddedAt = fixedDateTime.AddDays(-12), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "7", UserId = user9Id, BookId = book7Id, AddedAt = fixedDateTime.AddDays(-10), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "8", UserId = user10Id, BookId = book8Id, AddedAt = fixedDateTime.AddDays(-8), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "9", UserId = user3Id, BookId = book9Id, AddedAt = fixedDateTime.AddDays(-7), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookFavorite { Id = "10", UserId = user4Id, BookId = book10Id, AddedAt = fixedDateTime.AddDays(-5), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //// BookReviews (10 reviews)
        //modelBuilder.Entity<BookReview>().HasData(
        //    new BookReview { Id = "1", UserId = user3Id, BookId = book1Id, Rating = 5, ReviewText = "Amazing horror story, a classic!", ReviewDate = fixedDateTime.AddDays(-28), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "2", UserId = user4Id, BookId = book2Id, Rating = 5, ReviewText = "A magical start to a fantastic series!", ReviewDate = fixedDateTime.AddDays(-22), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "3", UserId = user5Id, BookId = book3Id, Rating = 4, ReviewText = "Complex characters and intriguing plot.", ReviewDate = fixedDateTime.AddDays(-19), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "4", UserId = user6Id, BookId = book4Id, Rating = 5, ReviewText = "A masterpiece of mystery, highly recommend.", ReviewDate = fixedDateTime.AddDays(-16), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "5", UserId = user7Id, BookId = book5Id, Rating = 4, ReviewText = "Murakami never disappoints, a unique read.", ReviewDate = fixedDateTime.AddDays(-13), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "6", UserId = user8Id, BookId = book6Id, Rating = 5, ReviewText = "Cuốn sách rất ý nghĩa và đầy cảm xúc.", ReviewDate = fixedDateTime.AddDays(-11), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "7", UserId = user9Id, BookId = book7Id, Rating = 5, ReviewText = "Kỷ niệm tuổi thơ với Dế Mèn.", ReviewDate = fixedDateTime.AddDays(-9), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "8", UserId = user10Id, BookId = book8Id, Rating = 4, ReviewText = "Truyện ngắn lãng mạn nhẹ nhàng.", ReviewDate = fixedDateTime.AddDays(-6), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "9", UserId = user3Id, BookId = book9Id, Rating = 4, ReviewText = "Đọc để thấy tình yêu thật đẹp.", ReviewDate = fixedDateTime.AddDays(-4), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReview { Id = "10", UserId = user4Id, BookId = book10Id, Rating = 5, ReviewText = "Phản ánh xã hội sâu sắc.", ReviewDate = fixedDateTime.AddDays(-2), CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //// BookReservation (10 reservations) - using available book copies
        //var copyIds = bookCopies.Select(bc => bc.Id).Take(10).ToList(); // Get 10 copy IDs
        //modelBuilder.Entity<BookReservation>().HasData(
        //    new BookReservation { Id = "1", UserId = user3Id, CopyId = copyIds[0], ReservationDate = new DateOnly(2025, 6, 1), Status = "Pending", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "2", UserId = user4Id, CopyId = copyIds[1], ReservationDate = new DateOnly(2025, 6, 2), Status = "Pending", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "3", UserId = user5Id, CopyId = copyIds[2], ReservationDate = new DateOnly(2025, 6, 3), Status = "Pending", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "4", UserId = user6Id, CopyId = copyIds[3], ReservationDate = new DateOnly(2025, 6, 4), Status = "Fulfilled", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "5", UserId = user7Id, CopyId = copyIds[4], ReservationDate = new DateOnly(2025, 6, 5), Status = "Pending", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "6", UserId = user8Id, CopyId = copyIds[5], ReservationDate = new DateOnly(2025, 6, 6), Status = "Fulfilled", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "7", UserId = user9Id, CopyId = copyIds[6], ReservationDate = new DateOnly(2025, 6, 7), Status = "Pending", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "8", UserId = user10Id, CopyId = copyIds[7], ReservationDate = new DateOnly(2025, 6, 8), Status = "Fulfilled", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "9", UserId = user3Id, CopyId = copyIds[8], ReservationDate = new DateOnly(2025, 6, 9), Status = "Pending", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BookReservation { Id = "10", UserId = user4Id, CopyId = copyIds[9], ReservationDate = new DateOnly(2025, 6, 10), Status = "Fulfilled", CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);

        //// BorrowRecords (10 records)
        //modelBuilder.Entity<BorrowRecord>().HasData(
        //    new BorrowRecord { Id = "1", UserId = user6Id, CopyId = copyIds[3], BorrowDate = fixedDateTime.AddDays(-10), DueDate = fixedDateTime.AddDays(-3), ReturnDate = fixedDateTime.AddDays(-5), Fine = 5.00m, Status = "Returned", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "2", UserId = user8Id, CopyId = copyIds[5], BorrowDate = fixedDateTime.AddDays(-15), DueDate = fixedDateTime.AddDays(-8), ReturnDate = fixedDateTime.AddDays(-10), Fine = 0.00m, Status = "Returned", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "3", UserId = user10Id, CopyId = copyIds[7], BorrowDate = fixedDateTime.AddDays(-20), DueDate = fixedDateTime.AddDays(-13), ReturnDate = fixedDateTime.AddDays(-15), Fine = 0.00m, Status = "Returned", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "4", UserId = user3Id, CopyId = copyIds[0], BorrowDate = fixedDateTime.AddDays(-5), DueDate = fixedDateTime.AddDays(2), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "5", UserId = user4Id, CopyId = copyIds[1], BorrowDate = fixedDateTime.AddDays(-7), DueDate = fixedDateTime.AddDays(0), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "6", UserId = user5Id, CopyId = copyIds[2], BorrowDate = fixedDateTime.AddDays(-2), DueDate = fixedDateTime.AddDays(5), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "7", UserId = user7Id, CopyId = copyIds[4], BorrowDate = fixedDateTime.AddDays(-1), DueDate = fixedDateTime.AddDays(6), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "8", UserId = user9Id, CopyId = copyIds[6], BorrowDate = fixedDateTime.AddDays(-3), DueDate = fixedDateTime.AddDays(4), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "9", UserId = user3Id, CopyId = copyIds[8], BorrowDate = fixedDateTime.AddDays(-4), DueDate = fixedDateTime.AddDays(3), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime },
        //    new BorrowRecord { Id = "10", UserId = user4Id, CopyId = copyIds[9], BorrowDate = fixedDateTime.AddDays(-6), DueDate = fixedDateTime.AddDays(1), ReturnDate = null, Fine = 0.00m, Status = "Borrowed", ExtensionDateCount = 0, CreatedAt = fixedDateTime, UpdatedAt = fixedDateTime }
        //);
        
        modelBuilder.Entity<RevokedToken>(entity =>
        {
            entity.ToTable("RevokedTokens"); // Đặt tên bảng trong DB
            entity.HasIndex(e => e.Token).IsUnique(); // Đảm bảo token là duy nhất
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
