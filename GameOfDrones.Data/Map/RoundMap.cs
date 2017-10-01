using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Data
{
    public class RoundMap : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder
                .HasMany(p => p.Moves);

            builder
                .HasOne(p => p.Winner)
                .WithMany()
                .HasForeignKey(p => p.WinnerPlayerId);
        }
    }
}
