namespace BaseBackend
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var builder = WebApplication.CreateBuilder(args);

        //    // Add services to the container.

        //    //builder.Services.AddControllers();
        //    builder.Services.AddControllers()
        //        .AddJsonOptions(options =>
        //        {
        //            // Don't have naming policy, return raw Property
        //            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        //            options.JsonSerializerOptions.Converters.Add(new LocalTimeZoneConverter());
        //        }
        //        );

        //    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //    builder.Services.AddEndpointsApiExplorer();
        //    builder.Services.AddSwaggerGen();

        //    // Khai báo các Dependency Injection

        //    // Unit Of Work
        //    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        //    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //    builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        //    builder.Services.AddScoped<ITitleRepository, TitleRepository>();
        //    builder.Services.AddScoped<ITitleService, TitleService>();
        //    builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        //    builder.Services.AddScoped<IAccountService, AccountService>();
        //    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        //    // AutoMapper
        //    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //    // Gán connectionString
        //    AccessDatabase.connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //    builder.Services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger  Solution", Version = "v1" });

        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
        //              Enter 'Bearer' [space] and then your token in the text input below.
        //              \r\n\r\nExample: 'Bearer 12345abcdef'",
        //            Name = "Authorization",
        //            In = ParameterLocation.Header,
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });

        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        //          {
        //            {
        //              new OpenApiSecurityScheme
        //              {
        //                Reference = new OpenApiReference
        //                  {
        //                    Type = ReferenceType.SecurityScheme,
        //                    Id = "Bearer"
        //                  },
        //                  Scheme = "oauth2",
        //                  Name = "Bearer",
        //                  In = ParameterLocation.Header,
        //                },
        //                new List<string>()
        //              }
        //            });
        //    });
        //    // Grant permission to FE fetch API
        //    builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
        //    {
        //        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //    })
        //        );



        //    builder.Services.AddControllers().ConfigureApiBehaviorOptions(
        //        options =>
        //        {
        //            options.InvalidModelStateResponseFactory = context =>
        //            {
        //                var errors = context.ModelState.Where(pair => pair.Value.Errors != null && pair.Value.Errors.Any()).Select(pair => new
        //                {
        //                    ErrorKey = pair.Key,
        //                    ErrorMessage = string.Join(", ", pair.Value.Errors.Select(error => error.ErrorMessage))
        //                }).ToArray();
        //                return new BadRequestObjectResult(new ResponseException()
        //                {
        //                    ErrorCode = 400,
        //                    UserMessage = "Lỗi từ người dùng",
        //                    DevMessage = "Lỗi dữ liệu đầu vào từ người dùng",
        //                    TraceId = "",
        //                    MoreInfo = "",
        //                    Errors = errors,
        //                }.ToString() ?? "");
        //            };
        //        }
        //        );
        //    // Authentication
        //    builder.Services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(options =>
        //    {
        //        options.RequireHttpsMetadata = false;
        //        options.SaveToken = true;
        //        options.TokenValidationParameters = new TokenValidationParameters()
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            //ValidateLifetime = true,
        //            ValidAudience = builder.Configuration["Jwt:Audience"],
        //            ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        //        };
        //    });

        //    // Cookies
        //    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //        .AddCookie(options =>
        //        {
        //            options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        //            options.SlidingExpiration = true;
        //            options.AccessDeniedPath = "/Forbidden/";
        //        });

        //    builder.Services.AddAuthorization();

        //    // Cache In-Memory
        //    builder.Services.AddMemoryCache();

        //    var app = builder.Build();

        //    // Configure the HTTP request pipeline.
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //        app.UseCors("corsapp");
        //    }
        //    app.UseHttpsRedirection();

        //    app.UseAuthentication();

        //    app.UseAuthorization();

        //    app.MapControllers();

        //    app.UseMiddleware<ExceptionMiddleware>();
        //    app.UseMiddleware<UserCacheMiddleware>();

        //    app.Run();
        //}

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
