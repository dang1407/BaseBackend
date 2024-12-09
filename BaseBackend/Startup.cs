using BaseBackend.Application.IService;
using BaseBackend.Application;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BaseBackend.Middleware;

namespace BaseBackend
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // Đăng ký các dịch vụ vào DI container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            //services.AddControllers();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Don't have naming policy, return raw Property
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.Converters.Add(new LocalTimeZoneConverter());
                }
                );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Khai báo các Dependency Injection

            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ITitleService, TitleService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPermisionRepository, PermisionRepository>();
            services.AddScoped<IPermisionService, PermisionService>();
            services.AddScoped<IAdmFeatureFunctionRepository, AdmFeatureFunctionRepository>();
            services.AddScoped<IAdmFeatureFunctionService, AdmFeatureFunctionService>();
            services.AddScoped<ICustomerT24Repository, CustomerT24Repository>();
            services.AddScoped<ICustomerT24Service, CustomerT24Service>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger  Solution", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });
            // Grant permission to FE fetch API
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            })
                );



            services.AddControllers().ConfigureApiBehaviorOptions(
                options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var errors = context.ModelState.Where(pair => pair.Value.Errors != null && pair.Value.Errors.Any()).Select(pair => new
                        {
                            ErrorKey = pair.Key,
                            ErrorMessage = string.Join(", ", pair.Value.Errors.Select(error => error.ErrorMessage))
                        }).ToArray();
                        return new BadRequestObjectResult(new ResponseException()
                        {
                            ErrorCode = 400,
                            UserMessage = "Lỗi từ người dùng",
                            DevMessage = "Lỗi dữ liệu đầu vào từ người dùng",
                            TraceId = "",
                            MoreInfo = "",
                            Errors = errors,
                        }.ToString() ?? "");
                    };
                }
                );
            // Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    //ValidateLifetime = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                };
            });

            // Cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/Forbidden/";
                });

            services.AddAuthorization();

            // Cache In-Memory
            services.AddMemoryCache();
        }

        // Thiết lập các middleware cho ứng dụng
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IPermisionService permisionService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();
            // Sử dụng routing
            app.UseRouting();

            // Sử dụng CORS với chính sách đã đăng ký
            app.UseCors("corsapp");

            // Sử dụng authentication (nếu có)
            app.UseAuthentication();
            app.UseAuthorization();

            // Thiết lập endpoint cho API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            Init(permisionService);
        }

        public void Init(IPermisionService permisionService)
        {
            GlobalCache.InitCache(permisionService);
        }
    }
}
