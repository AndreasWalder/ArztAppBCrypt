
using ArztApp.BAL;
using ArztApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var context = new ArztContext();
builder.Services.AddSingleton(context);

builder.Services.AddScoped<MedicationServices>();
builder.Services.AddScoped<PatientServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<VisitMedicationServices>();
builder.Services.AddScoped<VisitServices>();


var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
