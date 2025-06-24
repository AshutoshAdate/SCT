using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SCT.API.Extensions;
using SCT.Application.Helper.SMTP;
using SCT.Application.Mappings;
using SCT.Infrastructure.Data;
using System.Security.Claims;
using System.Text;

namespace SCT.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add cors plicy
            builder.Services.AddCors(o =>
            {
                o.AddPolicy("allowedFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000").WithHeaders().AllowAnyMethod().AllowAnyHeader();
                });
            });
            //add cors plicy


            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            //builder.Services.AddTransient<EmailSettings>();

            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            //builder.Services.AddTransient<MailHelper>();
            //Console.WriteLine(builder.ToString());
            builder.Services.AddControllers();

            builder.Services.AddApplicationServices(); // register services

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SCT", Version = "v1" });

                // Add JWT bearer support
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field. Example: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });



            //authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            //Console.WriteLine($"key:{jwtSettings}");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            //authentication
            var app = builder.Build();

            //check all and migrate the DB changes if any for relational DB only.
            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //    // Check if database exists
            //    if (dbContext.Database.CanConnect())
            //    {
            //        // Check if there are any pending migrations
            //        var pendingMigrations = dbContext.Database.GetPendingMigrations();
            //        if (pendingMigrations.Any())
            //        {
            //            dbContext.Database.Migrate();
            //        }
            //        else
            //        {
            //            Console.WriteLine("Database and schema already up to date.");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Database cannot be reached or does not exist.");
            //    }
            //}

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}
            app.UseCors("allowedFrontend");

            app.UseAuthentication();
            app.UseAuthorization();


            if (!app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // Middleware to restrict access to users with "admin" role
                app.Use(async (context, next) =>
                {
                    if (context.Request.Path.StartsWithSegments("/swagger"))
                    {
                        var user = context.User;

                        if (!user.Identity.IsAuthenticated ||
                            !user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "admin"))
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("Forbidden: You do not have access to Swagger UI.");
                            return;
                        }
                    }

                    await next();
                });
            }
            else
            {
                // Allow Swagger in development for any user
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
