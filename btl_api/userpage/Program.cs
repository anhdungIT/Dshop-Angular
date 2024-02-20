using BLL;
using DAL.Helper;
using DAL;
using Common;
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
builder.Services.AddTransient<IPostBLL, PostBLL>();
builder.Services.AddTransient<IPostDAL, PostDAL>();
//  Post Category
builder.Services.AddTransient<IPostCateBLL, PostCateBLL>();
builder.Services.AddTransient<IPostCateDAL, PostCateDAL>();
// order
builder.Services.AddTransient<IOrderBLL, OrderBLL>();
builder.Services.AddTransient<IOrdersDAL, OrdersDAL>();
// Add services to the container.

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

app.MapControllers();

app.Run();
