using FeedbackSystem.Core.Interfaces.IRepository;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.BussinessLogic.Logic;
using FeedbackSystem.BusinessLogic.Logic.Repositories;
using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.BusinessLogic.Mapper;
using FeedbackSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using FeedbackSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ar")
    };
    opt.DefaultRequestCulture = new RequestCulture("en");
    opt.SupportedUICultures = supportedCultures;

});

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<UserModel>(/*options => options.SignIn.RequireConfirmedAccount = true*/).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddSignInManager<SignInManager<UserModel>>(); ;

// Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IClassificationRepository, ClassificationRepository>();
builder.Services.AddScoped<IFloorNumberRepository, FloorNumberRepository>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceTypeRepository, PlaceTypeRepository>();
builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
builder.Services.AddScoped<IResponseTypeRepository, ResponseTypeRepository>();
builder.Services.AddScoped<ISenderTypeRepository, SenderTypeRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWingRepository, WingRepository>();
builder.Services.AddScoped<ITicketImageRepository, TicketImageRepository>();
builder.Services.AddScoped<IUserModelRepository, UserModelRepository>();

// Services
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IWingsService, WingService>();
builder.Services.AddScoped<IClassificationService, ClassificationService>();
builder.Services.AddScoped<IFloorNumberService, FloorNumberService>();
builder.Services.AddScoped<IPlaceTypeService, PlaceTypeService>();
builder.Services.AddScoped<IRequestTypeService, RequestTypeService>();
builder.Services.AddScoped<IResponseTypeService, ResponseTypeService>();
builder.Services.AddScoped<ISenderTypeService, SenderTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IUserModelService, UserModelService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
