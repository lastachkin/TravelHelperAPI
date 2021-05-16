using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelHelperAPI.Models
{
    public partial class TravelHelperContext : DbContext
    {
        public TravelHelperContext()
        {
        }

        public TravelHelperContext(DbContextOptions<TravelHelperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TravelHelper;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.RoomId)
                    .IsRequired()
                    .HasColumnName("room_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HotelId)
                    .IsRequired()
                    .HasColumnName("hotel_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.HotelId)
                    .IsRequired()
                    .HasColumnName("hotel_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
