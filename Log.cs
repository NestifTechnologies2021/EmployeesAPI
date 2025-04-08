//using System.Configuration;
//using System.Reflection;

//namespace SampleRestfulAPI
//{
//    public static class FileInfo
//    {


//        public static void WriteInLogFile(string s, string path)
//        {
//            //var path =  Configuration.Get("LogSettings:LogPath");

//            //if (!Directory.Exists(path))
//            //{
//            //    Directory.CreateDirectory(path);
//            //}
//            try
//            {

//                using (StreamWriter w = File.AppendText(path + "\\" + "log.txt"))
//                {
//                    w.WriteLine(DateTime.Now + " ----- " + s);
//                }
//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public class Startup
//        {
//            public IConfiguration Configuration { get; }

//            public Startup(IConfiguration configuration)
//            {
//                Configuration = configuration;
//            }

//            public void ConfigureServices(IServiceCollection services)
//            {



//            }

//            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//            {
//                // Configure your application pipeline here
//            }

//        }

//        // Define a class to hold your app settings
//        public class LogSettings
//        {
//            // Define properties that match your appsettings.json structure
//            public string LogPath { get; set; }
//        }




//    }





//}