using Microsoft.Extensions.Logging;
using MuseumFinder.Services;
using MuseumFinder.ViewModels;
using MuseumFinder.Views;
namespace MuseumFinder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Services
        builder.Services.AddSingleton<IMuseumService, MuseumService>();

        //Views Registration
        builder.Services.AddSingleton<MuseumListPage>();
        builder.Services.AddTransient<AddUpdateMuseumDetail>();

        //View Models
        builder.Services.AddSingleton<MuseumLisPageViewModel>();
        builder.Services.AddTransient<AddUpdateMuseumDetailViewModel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
