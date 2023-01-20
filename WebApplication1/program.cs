namespace WebApplication1
{
    public class program
    {
       
            static void Main(string[] args)
            {
                createHostBuilder(args).Build().Run();
            }
            public static IHostBuilder createHostBuilder(string[] args) =>

          Host.CreateDefaultBuilder(args)
             .ConfigureWebHostDefaults(webHost =>
             {
                 webHost.UseStartup<startup>();
             });







       
        
    }
   
}
