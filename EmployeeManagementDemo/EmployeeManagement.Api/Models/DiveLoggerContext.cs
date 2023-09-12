using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public partial class DiveLoggerContext : DbContext
    {
        private readonly string _connectionString;
        public DiveLoggerContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<AuthUser> AuthUser { get; set; }
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<Dive> Dive { get; set; }
        public virtual DbSet<DiveLog> DiveLog { get; set; }
        public virtual DbSet<Diver> Diver { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Padi> Padi { get; set; }
        public virtual DbSet<ReefLife> ReefLife { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>(entity =>
            {
                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewVal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OldVal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dive>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AvgDepthFt).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.AvgDepthM)
                    .HasColumnType("numeric(10, 5)")
                    .HasComputedColumnSql("([AvgDepthFt]*(0.3048))");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndPg).HasColumnName("EndPG");

                entity.Property(e => e.MaxDepthFt).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.MaxDepthM)
                    .HasColumnType("numeric(10, 5)")
                    .HasComputedColumnSql("([MaxDepthFt]*(0.3048))");

                entity.Property(e => e.StartPg).HasColumnName("StartPG");

                entity.Property(e => e.TemperatureF).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.TimeIn).HasColumnType("time(0)");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("time(0)")
                    .HasComputedColumnSql("(dateadd(minute,[Minutes],[TimeIn]))");

                entity.Property(e => e.Visibility).HasMaxLength(50);

                entity.HasOne(d => d.Diver)
                    .WithMany(p => p.Dives)
                    .HasForeignKey(d => d.DiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dive_Diver");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Dive)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dive_Location");
            });

            modelBuilder.Entity<DiveLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AvgDepthFt).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DivedWith)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EndPg).HasColumnName("EndPG");

                entity.Property(e => e.Equipment).HasMaxLength(50);

                entity.Property(e => e.Locality).HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observations).HasMaxLength(250);

                entity.Property(e => e.PsiperMin).HasColumnName("PSIPerMin");

                entity.Property(e => e.SafetyStop)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartPg).HasColumnName("StartPG");

                entity.Property(e => e.SurfaceTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Visibility)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Weather)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Diver>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Padilevel).HasColumnName("PADILevel");

                entity.Property(e => e.Padinumber)
                    .HasColumnName("PADINumber")
                    .HasMaxLength(20);

                entity.HasOne(d => d.PadilevelNavigation)
                    .WithMany(p => p.Diver)
                    .HasForeignKey(d => d.Padilevel)
                    .HasConstraintName("FK_Diver_PADI");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lat).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Lng).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Locality).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Padi>(entity =>
            {
                entity.ToTable("PADI");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ReefLife>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
