using LasserreDetresTravelAgency.Business.Service;
using LasserreDetresTravelAgency.Data;
using LasserreDetresTravelAgency.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();

// Link Services and their interfaces
builder.Services.AddTransient<IDestinationService, DestinationService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IRateService, RateService>();
builder.Services.AddTransient<IVisitService, VisitService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IFavoryService, FavoryService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IEventService, EventService>();

// Link Repositories and their interfaces
builder.Services.AddTransient<IDestinationRepository, DestinationRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IRateRepository, RateRepository>();
builder.Services.AddTransient<IVisitRepository, VisitRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IFavoryRepository, FavoryRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IEventRepository, EventRepository>();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
