using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hall_Reservation.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : 
            base(options)
        {
        }

        public virtual DbSet<AboutU> AboutUs { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Checked> Checkeds { get; set; } = null!;
        public virtual DbSet<Checklist> Checklists { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<DepView> DepViews { get; set; } = null!;
        public virtual DbSet<Hall> Halls { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Roless> Rolesses { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Visa> Visas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
                optionsBuilder.UseOracle("USER ID= **********;PASSWORD=***********;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR15_USER88")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<AboutU>(entity =>
            {
                
                entity.HasKey(e => e.Id)
                    .HasName("ABOUT_US_PK");

                entity.ToTable("ABOUT_US");
                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(17)
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.Home)
                    .WithMany()
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00273183");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.AddressId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKING");

                entity.Property(e => e.BookingId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.HallId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273161");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273162");
                
                entity.Property(e => e.Creation_Date)
                  .HasColumnType("DATE")
                  .HasColumnName("CREATION_DATE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("SYS_C00273143");

                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CatId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CAT_ID");

                entity.Property(e => e.CatImagePath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CAT_IMAGE_PATH");

                entity.Property(e => e.CatName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAT_NAME");
            });

            modelBuilder.Entity<Checked>(entity =>
            {
                entity.HasKey(e => e.CheckId)
                    .HasName("SYS_C00273167");

                entity.ToTable("CHECKED");

                entity.Property(e => e.CheckId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHECK_ID");

                entity.Property(e => e.BookingId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.CheckedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHECKED_DATE");

                entity.Property(e => e.HallId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_ID");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Checkeds)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273170");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Checkeds)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273169");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Checkeds)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273171");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Checkeds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273168");
            });

            modelBuilder.Entity<Checklist>(entity =>
            {
                entity.HasKey(e => e.CheckedId)
                    .HasName("SYS_C00273164");

                entity.ToTable("CHECKLIST");

                entity.Property(e => e.CheckedId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHECKED_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.ToTable("CONTACT_US");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(17)
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.ContactUs)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00273186");
            });

            modelBuilder.Entity<DepView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DEP_VIEW");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Salary)
                    .HasPrecision(10)
                    .HasColumnName("SALARY");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("HALL");

                entity.Property(e => e.HallId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HALL_ID");

                entity.Property(e => e.AddressId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.BookingPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BOOKING_PRICE");

                entity.Property(e => e.BuildingNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUILDING_NUMBER");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.HallCapacity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_CAPACITY");

                entity.Property(e => e.HallDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("HALL_DESCRIPTION");

                entity.Property(e => e.HallName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HALL_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00273152");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273151");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("HOME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_3");

                entity.Property(e => e.Title1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TITLE_1");

                entity.Property(e => e.Title2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TITLE_2");

                entity.Property(e => e.Title3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TITLE_3");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.HasIndex(e => e.UserName, "SYS_C00273139")
                    .IsUnique();

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RolesId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLES_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.RolesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273141");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273140");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PayId)
                    .HasName("SYS_C00273174");

                entity.ToTable("PAYMENT");

                entity.Property(e => e.PayId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAY_ID");

                entity.Property(e => e.BookingId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.HallName)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_NAME");

                entity.Property(e => e.PayAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAY_AMOUNT");

                entity.Property(e => e.PayDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAY_DATE");

                entity.Property(e => e.PayDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PAY_DESC");

                entity.Property(e => e.PayUserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAY_USER_ID");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.VisaId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VISA_ID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273180");

                entity.HasOne(d => d.HallNameNavigation)
                    .WithMany(p => p.PaymentHallNameNavigations)
                    .HasForeignKey(d => d.HallName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273177");

                entity.HasOne(d => d.PayAmountNavigation)
                    .WithMany(p => p.PaymentPayAmountNavigations)
                    .HasForeignKey(d => d.PayAmount)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273176");

                entity.HasOne(d => d.PayUser)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PayUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273178");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273175");

                entity.HasOne(d => d.Visa)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.VisaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273179");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewsId)
                    .HasName("SYS_C00273154");

                entity.ToTable("REVIEWS");

                entity.Property(e => e.ReviewsId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEWS_ID");

                entity.Property(e => e.HallId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_ID");

                entity.Property(e => e.Opinion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("OPINION");

                entity.Property(e => e.Rating)
                    .HasPrecision(10)
                    .HasColumnName("RATING");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273156");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273155");
            });

            modelBuilder.Entity<Roless>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C00273134");

                entity.ToTable("ROLESS");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Opinion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OPINION");

                entity.Property(e => e.Rating)
                    .HasPrecision(10)
                    .HasColumnName("RATING");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00273190");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273191");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273189");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.UserName, "SYS_C00273126")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .HasPrecision(14)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.UserImage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_IMAGE");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<Visa>(entity =>
            {
                entity.ToTable("VISA");

                entity.Property(e => e.VisaId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VISA_ID");

                entity.Property(e => e.CvcCvv)
                    .HasPrecision(3)
                    .HasColumnName("CVC_CVV");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.VisaAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VISA_AMOUNT");

                entity.Property(e => e.VisaName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VISA_NAME");

                entity.Property(e => e.VisaNumber)
                    .HasPrecision(16)
                    .HasColumnName("VISA_NUMBER");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Visas)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00273131");
            });

            modelBuilder.HasSequence("SEQUENCE_DEP_ID");

            modelBuilder.HasSequence("SEQUENCEDEPARTMENT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
