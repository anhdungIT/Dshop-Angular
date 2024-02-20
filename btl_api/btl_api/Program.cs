using BLL;
using DAL.Helper;
using DAL;
using Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ITools, Tools>();
// Product Category
builder.Services.AddTransient<IProductCateBLL, ProductCateBLL>();
builder.Services.AddTransient<IProductCateDAL, ProductCateDAL>();
// Product
builder.Services.AddTransient<IProductBLL, ProductBLL>();
builder.Services.AddTransient<IProductDAL, ProductDAL>();
//  Post
builder.Services.AddTransient<IPostBLL,PostBLL>();
builder.Services.AddTransient<IPostDAL, PostDAL>();
//  Post Category
builder.Services.AddTransient<IPostCateBLL, PostCateBLL>();
builder.Services.AddTransient<IPostCateDAL, PostCateDAL>();
// user
builder.Services.AddTransient<IUserBLL, UserBLL>();
builder.Services.AddTransient<IUserDAL, UserDAL>();
// order
builder.Services.AddTransient<IOrderBLL, OrderBLL>();
builder.Services.AddTransient<IOrdersDAL, OrdersDAL>();
// Add services to the container.
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("MyCors", build => { build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("MyCors");
app.UseAuthorization();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
