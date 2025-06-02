using BlazorWASMWebApplication.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml;


public partial class ContactsDataBaseContext : DbContext
{
    public ContactsDataBaseContext(DbContextOptions<ContactsDataBaseContext> options)
: base(options)
    {
    }

    public virtual DbSet<Contact> Contact { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<SubCategory> SubCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(contact =>
        {
            contact.Property(e => e.CategoryId).IsRequired().HasColumnName("CategoryId");

            contact.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            contact.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            contact.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            contact.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubCategory>()
        .HasKey(subCategory => new { subCategory.CategoryId, subCategory.Name });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
