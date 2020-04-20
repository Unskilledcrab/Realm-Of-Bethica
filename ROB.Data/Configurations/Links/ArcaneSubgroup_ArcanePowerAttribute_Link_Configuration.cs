using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Data.Configurations.Links
{
    public class ArcaneSubgroup_ArcanePowerAttribute_Link_Configuration : IEntityTypeConfiguration<ArcaneSubgroup_ArcanePowerAttribute_Link>
    {
        public void Configure(EntityTypeBuilder<ArcaneSubgroup_ArcanePowerAttribute_Link> builder)
        {
            builder
                .HasKey(link => new { link.ArcaneSubgroupId, link.ArcanePowerAttributeId });

            builder
                .HasOne(link => link.ArcaneSubgroup)
                .WithMany(classOne => classOne.ElementsUsedIn)
                .HasForeignKey(link => link.ArcaneSubgroupId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(link => link.ArcanePowerAttribute)
                .WithMany(classTwo => classTwo.RequiredArcaneSubgroups)
                .HasForeignKey(link => link.ArcanePowerAttributeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
