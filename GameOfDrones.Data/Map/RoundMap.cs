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
            builder.HasOne(x => x.Game)
                .WithMany()
                .HasForeignKey(x => x.GameId);

            builder.HasOne(s => s.Winner)
                .WithMany()
                .HasForeignKey(f => f.WinnerPlayerId);

            builder.HasMany(s => s.Moves);
        }
    }
}
