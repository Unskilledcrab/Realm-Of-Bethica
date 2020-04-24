using Google.Apis.Services;
using System;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System.Threading.Tasks;

namespace ROB.BootstrapStudio
{
    class GoogleDriveService
    {
        //[STAThread]
        //static void Main()
        //{
        //    Console.WriteLine("Discovery API Sample");
        //    Console.WriteLine("====================");
        //    try
        //    {
        //        new Program().Run().Wait();
        //    }
        //    catch (AggregateException ex)
        //    {
        //        foreach (var e in ex.InnerExceptions)
        //        {
        //            Console.WriteLine("ERROR: " + e.Message);
        //        }
        //    }
        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //}

        //private async Task Run()
        //{
        //    // Create the service.
        //    var service = new DriveService(new BaseClientService.Initializer
        //    {
        //        ApplicationName = "Discovery Sample",
        //        ApiKey = "[YOUR_API_KEY_HERE]",
        //    });

        //    // Run the request.
        //    Console.WriteLine("Executing a list request...");
        //    var result = await service.;

        //    // Display the results.
        //    if (result.Items != null)
        //    {
        //        foreach (DirectoryList.ItemsData api in result.Items)
        //        {
        //            Console.WriteLine(api.Id + " - " + api.Title);
        //        }
        //    }
        //}
    }
}
