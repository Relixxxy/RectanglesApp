using Microsoft.Extensions.DependencyInjection;
using Rects;
using Rects.Services;
using Rects.Services.Interfaces;

void ConfigureServices(ServiceCollection serviceCollection)
{
    serviceCollection
        .AddTransient<IPrinterService, PrinterService>()
        .AddTransient<ICreatorService, CreatorService>()
        .AddTransient<IFinderService, FinderService>()
        .AddTransient<App>();
}

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
app!.Start();