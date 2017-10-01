using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfDrones.Data
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Relationships

            builder.
                HasMany(p => p.Players)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId)
                .IsRequired();

            builder.
                HasMany(s => s.Rounds)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId)
                .IsRequired();

        }
    }
}
