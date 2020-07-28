using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class restaurantvspjContext : DbContext
    {
        public restaurantvspjContext()
        {
        }

        public restaurantvspjContext(DbContextOptions<restaurantvspjContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pozice> Pozice { get; set; }
        public virtual DbSet<Sekce> Sekce { get; set; }
        public virtual DbSet<Tabless> Tabless { get; set; }
        public virtual DbSet<Vat> Vat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:vspj.database.windows.net,1433;Initial Catalog=restaurant.vspj;Persist Security Info=False;User ID=murban27;Password=Swimer01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.SectionId).HasColumnName("Section_ID");

                entity.Property(e => e.VatId).HasColumnName("VAT_ID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Item_Section");

                entity.HasOne(d => d.Vat)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.VatId)
                    .HasConstraintName("FK_Item_TAX");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasColumnName("login")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPoziceNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.IdPozice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("ORDER_DETAIL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("Item_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ORDER_DETAIL_ITEM_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ORDER_DETAIL_ID");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_Id");
            });

            modelBuilder.Entity<Pozice>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sekce>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Sekce");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vat>(entity =>
            {
                entity.ToTable("VAT");

                entity.Property(e => e.VatId).HasColumnName("VAT_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
