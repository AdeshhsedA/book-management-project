using Book__Management_Final.BusinessLogic.Mappings;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.BusinessLogic.Services.Services;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Implementation;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

{
	

	builder.Services.AddControllersWithViews();
	builder.Services.AddDbContext<BookManagementDbContext>(
		options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
		);
	builder.Services.AddAutoMapper(typeof(MapperConfig));

	builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["JWT:Issuer"],
			ValidAudience = builder.Configuration["JWT:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
		};
	});

	//User Respositroy  
	builder.Services.AddScoped<IUserRepository, UserRepository>();
	

	builder.Services.AddScoped<IBookRepository, BookRepository>();
	builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
	builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
	builder.Services.AddScoped<IRentedBookRepository, RentedBookRepository>();


	builder.Services.AddScoped<IUserServices, UserServices>();
	builder.Services.AddScoped<IBookServices, BookServices>();
	builder.Services.AddScoped<IAuthorServices, AuthorServices>();
	builder.Services.AddScoped<ISubjectServices, SubjectServices>();
	builder.Services.AddScoped<IRentedBookServices,RentedBookServices>();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
}

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		builder =>
		{
			builder.WithOrigins("http://localhost:4200") // Replace with your client's origin
				   .AllowAnyMethod()
				   .AllowAnyHeader()
				   .AllowCredentials();
		});
});

var app = builder.Build();

{
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}
	app.UseCors("AllowSpecificOrigin");
	app.UseHttpsRedirection();
	app.UseStaticFiles();
	
	app.UseAuthentication();
	app.UseAuthorization();
	app.MapControllers();
	app.Run();
}