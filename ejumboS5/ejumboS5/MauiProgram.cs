using ejumboS5.Modelos;
using MauiSQLITE;
using Microsoft.Extensions.Logging;

namespace ejumboS5;

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

		string sbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
		builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, sbPath));

		return builder.Build();
	}
}

