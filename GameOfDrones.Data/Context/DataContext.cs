using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GameOfDrones.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext()
            : base()
        {
        }

        public DataContext(DbContextOptions dbOptions)
            : base(dbOptions)
        {
        }
        
        DbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameMap());
            modelBuilder.ApplyConfiguration(new MoveMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new PlayerMoveMap());
            modelBuilder.ApplyConfiguration(new RoundMap());
        }



    }
}
