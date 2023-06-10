using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SkyNotes.BlazorServer.Data;
using SkyNotes.Common.DataContext.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddSkyNotesContext(connectionString:builder.Configuration.GetConnectionString("SQLAZURECONNSTR_SkynotesDbConnection")!);

builder.Services.AddTransient<ISkyNotesService, SkyNotesService>();
builder.Services.AddTransient<IOpenAiService, OpenAiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();