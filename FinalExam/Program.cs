using FinalExam.Business.Services.Abstract;
using FinalExam.Business.Services.Concretes;
using FinalExam.Core.Models;
using FinalExam.Core.RepositoryAbstract;
using FinalExam.Data.DAL;
using FinalExam.Data.RepositoryConcretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.User.RequireUniqueEmail = false;
    }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
    builder.Services.AddScoped<IWorkerService, WorkerService>();

    builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}"
        );

    app.Run();
}
