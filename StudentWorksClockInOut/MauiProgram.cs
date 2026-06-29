using Microsoft.Extensions.Logging;
using StudentWorksClockInOut.Repositories;

namespace StudentWorksClockInOut;

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

        builder.Services.AddSingleton<EmployeeDatabase>();
        builder.Services.AddSingleton<TimeEntryRepository>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
