using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Data.Database;

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
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<TimeTrackerContext>();

        return services.BuildServiceProvider();
    }
}