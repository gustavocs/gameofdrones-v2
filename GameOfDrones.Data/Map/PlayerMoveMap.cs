using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Data
{
    public class PlayerMoveMap : IEntityTypeConfiguration<PlayerMove>
    {
        public void Configure(EntityTypeBuilder<PlayerMove> builder)
        {
            // Relationships

            builder
                .HasOne(x => x.Move)
                .WithMany()
                .HasForeignKey(x => x.MoveId)
                .IsRequired();

            builder
                .HasOne(x => x.Player)
               .WithMany()
               .HasForeignKey(x => x.PlayerId)
               .IsRequired();
        }
    }
}
