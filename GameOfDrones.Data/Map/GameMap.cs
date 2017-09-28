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
            builder.HasMany(s => s.Players)
                .WithOne(p => p.Game);

            builder.HasMany(s => s.Rounds)
                .WithOne(p => p.Game);
        }
    }
}
