﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using GameOfDrones.Data;
using GameOfDrones.Services;
using GameOfDrones.Models;

namespace GameOfDrones.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["DbConnectionString"];

            services.AddCors();
            services.AddMvc();

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(
                    options => options.UseNpgsql(connection, b => b.MigrationsAssembly("GameOfDrones.WebAPI")));
            
            services.AddScoped<IDbContext, DataContext>();

            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IRoundService, RoundService>();
            services.AddTransient<IMoveService, MoveService>();
            services.AddTransient<IConfigService, ConfigService>();

            services.AddScoped<IRepositoryBase<Game>, RepositoryBase<Game>>();
            services.AddScoped<IRepositoryBase<Player>, RepositoryBase<Player>>();
            services.AddScoped<IRepositoryBase<Round>, RepositoryBase<Round>>();
            services.AddScoped<IRepositoryBase<Move>, RepositoryBase<Move>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
