using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using THWEB.Data;
using THWEB.Services;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IReponsitoryA, ReA>();
            builder.Services.AddScoped<IReponsitoryB, ReB>();
            builder.Services.AddScoped<IReponsitoryP, ReP>();
            builder.Services.AddDbContext<AppDbcontext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("DefConnect")));
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
