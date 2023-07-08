using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Data.Database;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation;

public partial class App : Application
{
    public IServiceProvider Services { get; }

    public App()
    {
        using var db = new TimeTrackerContext();
        db.Database.Migrate();

        Services = ConfigureServices();

        InitializeComponent();

        db.Users.Add(new User
        {
            Email = "ls@ls.de"
        });
        db.SaveChanges();
        Trace.WriteLine("text4");
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<TimeTrackerContext>();

        return services.BuildServiceProvider();
    }
}