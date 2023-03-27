using ATOJewellery.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddControllersWithViews();
//W2 want to add here before we build the builder | So we are adding a new service and this line is how we let the app know to complie 
// with the Model(s) for the Database, Code first approach: code was written, Data  File / ApplicationDbContext file was created |
// and the Model was added to it. | Now all models add to this page will be compiled according here this file (class)  "ApplicationDbContext"
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"))); // We will need a mange nuget package for this line if the package is not installed  | The package name is "Microssoft.EntityFrameworkCore.sqlServer"
//Inside UseSqlServer will need to add our connections string that we created in "appsetting.json"

builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); // Remember this project is MVC and not Razor, But we do have Razor files within the project, So in order to operate hotreload we most add this line for Razor to be Recognized by the Runtime

//builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); // If we were using Razor pages we would use this for runtime hot reload | my deprecated as we are using .Net7 instead we can do whats on the next line
//builder.Services.AddRazorPages()



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())// Used to determine if were are in a sort of development mode | if not exception handing 
{
    app.UseExceptionHandler("/Home/Error");  
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //Static files are defined in wwwroot folder

app.UseRouting();// Routing middlware 
     // If we add authentical middleware to project we would add here because it woulds need to come before the Autherixation
app.UseAuthorization();  

app.MapControllerRoute(//Mapping depending on the request will redirect to the corrsonding controllers 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
