using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OVB.Project.Eschody.Monolithic.Domain.AccountContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping.Interfaces;
using OVB.Project.Eschody.Monolithic.Domain.AccountContext.ENUMs;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping;

public sealed class AccountMapping : IMapping<Account>
{
    public void CreateMapping(EntityTypeBuilder<Account> entity)
    {
        // Primary Key's
        entity.HasKey(p => p.Identifier)
            .HasName("PK_ACCOUNT_IDENTIFIER");

        // Foreign Key's
        entity.HasMany(p => p.Assignments).WithOne(p => p.CreatedBy)
            .HasConstraintName("FK_ACCOUNT_ASSIGNMENT");

        // Index
        entity.HasIndex(p => p.Identifier)
            .IsUnique()
            .HasDatabaseName("UK_ACCOUNT_IDENTIFIER");
        entity.HasIndex(p => p.Username)
            .IsUnique()
            .HasDatabaseName("UK_ACCOUNT_USERNAME");
        entity.HasIndex(p => p.Email)
            .IsUnique()
            .HasDatabaseName("UK_ACCOUNT_EMAIL");

        // Properties
        entity.Property(p => p.Username)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Username")
            .HasMaxLength(256);

        entity.Property(p => p.Email)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Email")
            .HasMaxLength(256);

        entity.Property(p => p.Password)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Password")
            .HasMaxLength(256);

        entity.Property(p => p.TypeAccount)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasConversion<string>(p => p.ToString(), p => (TypeAccount)Enum.Parse(typeof(TypeAccount), p))
            .HasColumnName("TypeAccount")
            .HasMaxLength(256);
    }
}
