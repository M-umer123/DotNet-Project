using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_1.Models;

public partial class MarketReadySiteContext : DbContext
{
    public MarketReadySiteContext()
    {
    }

    public MarketReadySiteContext(DbContextOptions<MarketReadySiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutTbl> AboutTbls { get; set; }

    public virtual DbSet<AdminTable> AdminTables { get; set; }

    public virtual DbSet<BookingTbl> BookingTbls { get; set; }

    public virtual DbSet<HomeTbl> HomeTbls { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutTbl>(entity =>
        {
            entity.HasKey(e => e.AboutId);

            entity.ToTable("about_tbl");

            entity.Property(e => e.AboutId).HasColumnName("about_id");
            entity.Property(e => e.AboutBtnText)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("about_btn_text");
            entity.Property(e => e.AboutDesc)
                .HasColumnType("text")
                .HasColumnName("about_desc");
            entity.Property(e => e.AboutTitle)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("about_title");
        });

        modelBuilder.Entity<AdminTable>(entity =>
        {
            entity.HasKey(e => e.AdminId);

            entity.ToTable("admin_table");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("admin_email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("admin_name");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("admin_password");
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("admin_phone");
        });

        modelBuilder.Entity<BookingTbl>(entity =>
        {
            entity.HasKey(e => e.BookId);

            entity.ToTable("booking_tbl");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BookerBookingDate)
                .HasColumnType("datetime")
                .HasColumnName("booker_booking_date");
            entity.Property(e => e.BookerEmail)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("booker_email");
            entity.Property(e => e.BookerName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("booker_name");
            entity.Property(e => e.BookerPhone)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("booker_phone");
            entity.Property(e => e.BookerTotalPersons).HasColumnName("booker_total_persons");
        });

        modelBuilder.Entity<HomeTbl>(entity =>
        {
            entity.HasKey(e => e.HomeId);

            entity.ToTable("home_tbl");

            entity.Property(e => e.HomeId).HasColumnName("home_id");
            entity.Property(e => e.HomeBgImg)
                .HasColumnType("text")
                .HasColumnName("home_bg_img");
            entity.Property(e => e.HomeDesc)
                .HasColumnType("text")
                .HasColumnName("home_desc");
            entity.Property(e => e.HomeTitle)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("home_title");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("menu");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Item1Price).HasColumnName("item_1_price");
            entity.Property(e => e.Item2Price).HasColumnName("item_2_price");
            entity.Property(e => e.Item3Price).HasColumnName("item_3_price");
            entity.Property(e => e.Item4Price).HasColumnName("item_4_price");
            entity.Property(e => e.Item5Price).HasColumnName("item_5_price");
            entity.Property(e => e.Item6Price).HasColumnName("item_6_price");
            entity.Property(e => e.Item7Price).HasColumnName("item_7_price");
            entity.Property(e => e.Item8Price).HasColumnName("item_8_price");
            entity.Property(e => e.Item9Price).HasColumnName("item_9_price");
            entity.Property(e => e.ItemDesc1)
                .HasColumnType("text")
                .HasColumnName("item_desc_1");
            entity.Property(e => e.ItemDesc2)
                .HasColumnType("text")
                .HasColumnName("item_desc_2");
            entity.Property(e => e.ItemDesc3)
                .HasColumnType("text")
                .HasColumnName("item_desc_3");
            entity.Property(e => e.ItemDesc4)
                .HasColumnType("text")
                .HasColumnName("item_desc_4");
            entity.Property(e => e.ItemDesc5)
                .HasColumnType("text")
                .HasColumnName("item_desc_5");
            entity.Property(e => e.ItemDesc6)
                .HasColumnType("text")
                .HasColumnName("item_desc_6");
            entity.Property(e => e.ItemDesc7)
                .HasColumnType("text")
                .HasColumnName("item_desc_7");
            entity.Property(e => e.ItemDesc8)
                .HasColumnType("text")
                .HasColumnName("item_desc_8");
            entity.Property(e => e.ItemDesc9)
                .HasColumnType("text")
                .HasColumnName("item_desc_9");
            entity.Property(e => e.ItemImg1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("item_img_1");
            entity.Property(e => e.ItemImg2)
                .HasColumnType("text")
                .HasColumnName("item_img_2");
            entity.Property(e => e.ItemImg3)
                .HasColumnType("text")
                .HasColumnName("item_img_3");
            entity.Property(e => e.ItemImg4)
                .HasColumnType("text")
                .HasColumnName("item_img_4");
            entity.Property(e => e.ItemImg5)
                .HasColumnType("text")
                .HasColumnName("item_img_5");
            entity.Property(e => e.ItemImg6)
                .HasColumnType("text")
                .HasColumnName("item_img_6");
            entity.Property(e => e.ItemImg7)
                .HasColumnType("text")
                .HasColumnName("item_img_7");
            entity.Property(e => e.ItemImg8)
                .HasColumnType("text")
                .HasColumnName("item_img_8");
            entity.Property(e => e.ItemImg9)
                .HasColumnType("text")
                .HasColumnName("item_img_9");
            entity.Property(e => e.ItemTitle1)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_1");
            entity.Property(e => e.ItemTitle2)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_2");
            entity.Property(e => e.ItemTitle3)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_3");
            entity.Property(e => e.ItemTitle4)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_4");
            entity.Property(e => e.ItemTitle5)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_5");
            entity.Property(e => e.ItemTitle6)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_6");
            entity.Property(e => e.ItemTitle7)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_7");
            entity.Property(e => e.ItemTitle8)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_8");
            entity.Property(e => e.ItemTitle9)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("item_title_9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
