using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfDrones.Data
{
    public class MoveMap : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            // Relationships

            builder.
                HasOne(s => s.Kills)
                .WithMany()
                .HasForeignKey(f => f.KillsMoveId);
        }
    }
}
