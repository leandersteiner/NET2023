﻿using System;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Core.Services;
using TimeTracker.Data.Database;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation;

public partial class App : Application
{
    public new static App Current => (App) Application.Current;
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

        services.AddSingleton<IDialogCoordinator, DialogCoordinator>();

        services.AddSingleton<AppContextStore>();
        services.AddTransient<TimeTrackerContext>();

        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IOrganisationRepository, OrganisationRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IRecordRepository, RecordRepository>();
        services.AddTransient<IWorkItemRepository, WorkItemRepository>();

        services.AddTransient<UserService>();

        services.AddTransient<ShellViewModel>();
        services.AddTransient<LoginControlViewModelBase>();
        services.AddTransient<SignupControlViewModelBase>();
        services.AddTransient<UserListViewModel>();
        services.AddTransient<UserSelectionViewModel>();
        services.AddTransient<OrganisationListViewModel>();
        services.AddTransient<OrganisationSelectionViewModel>();
        services.AddTransient<ProjectListViewModel>();
        services.AddTransient<ProjectSelectionViewModel>();
        services.AddTransient<WorkItemListViewModel>();
        services.AddTransient<WorkItemSelectionViewModel>();
        services.AddTransient<RecordListViewModel>();
        services.AddTransient<RecordedTimesViewViewModel>();
        services.AddTransient<UserViewViewModel>();
        services.AddTransient<TimeRecorderViewModel>();

        return services.BuildServiceProvider();
    }
}