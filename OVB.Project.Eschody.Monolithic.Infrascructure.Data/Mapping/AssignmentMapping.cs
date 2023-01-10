using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.ENUMs;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping.Interfaces;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping;

public sealed class AssignmentMapping : IMapping<Assignment>
{
    public void CreateMapping(EntityTypeBuilder<Assignment> entity)
    {
        // Primary Key
        entity.HasKey(p => p.Identifier).HasName("PK_ASSIGNMENT_IDENTIFIER");

        // Foreign Key
        entity.HasOne(p => p.CreatedBy).WithMany(p => p.Assignments).HasConstraintName("FK_ASSIGNMENTS_ACCOUNT");

        // Index
        entity.HasIndex(p => p.Identifier)
            .IsUnique()
            .HasDatabaseName("UK_ASSIGNMENT_IDENTIFIER");

        // Properties
        entity.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnType("VARCHAR");

        entity.Property(p => p.CreatedOn)
            .IsRequired()
            .HasColumnType("DATETIME");

        entity.Property(p => p.TypeStatusAssignment)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Status")
            .HasConversion<string>(p => p.ToString(), p => (TypeStatusAssignment)Enum.Parse(typeof(TypeStatusAssignment), p))
            .HasMaxLength(256);

        entity.Property(p => p.Deadline)
            .IsRequired()
            .HasColumnType("DATE")
            .HasConversion<string>(p => p.Date.ToShortDateString(), p => Convert.ToDateTime(p));
    }
}
