using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using BMCFileMangement.Services.Interface;
using BMCFileMangement.Services.Implementation;
using BMCFileMangement.forms;

namespace BMCFileMangement
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfigurationRoot _config;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(_config)
               .Enrich.FromLogContext()
               .WriteTo.Console(new RenderedCompactJsonFormatter()).CreateLogger();
            try
            {
                Log.Information("Starting hosted worker");
                var host = CreateHostBuilder(args).Build();//.Run();

                ServiceProvider = host.Services;

                // Show splash screen
                //var splashScreen = new frmSplashScreen(); // Replace with your splash screen form
                //splashScreen.Show();

                //CreateSplashForm();

                // Simulate login (replace with actual login logic)
                //var loginForm = new frmLoginForm();
                //var loginForm = new frmLogin();
                //var loginResult = loginForm.ShowDialog();
                Application.Run(ServiceProvider.GetRequiredService<frmLogin>());
                // Close splash screen after login
                //splashScreen.Close();

                // Check login result
                //if (loginResult == DialogResult.OK)
                //{
                //    Application.Run(ServiceProvider.GetRequiredService<MainWindows>()); // Replace with your main form
                //    //Application.Run(new MainWindows());
                //}

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IConfigurationRoot>(_config);
                services.AddTransient<IMessageService, MessageService>();
                services.AddTransient<IQueueManagerService, QueueManagerService>();
                services.AddTransient<frmLogin>();
                //services.AddHostedService<WorkerNotification>();
            });
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        private static void CreateSplashForm()
        {

            var fSplash = new frmSplashScreen();
            //fSplash.BackgroundImage = System.Drawing.Image.FromFile(@"Images\Money-Heist.jpg");

            //fSplash.BackgroundImageLayout = ImageLayout.Center;
            //fSplash.FormBorderStyle = FormBorderStyle.None;
            //fSplash.StartPosition = FormStartPosition.CenterScreen;
            //fSplash.TopMost = true;

            //fSplash.TransparencyKey = System.Drawing.Color.White;// it sets transparency for the background of image

            // Set the splash form size and we are shure the image fit to the form
            //fSplash.Width = (int)fSplash.BackgroundImage.PhysicalDimension.Width;
            //fSplash.Height = (int)fSplash.BackgroundImage.PhysicalDimension.Height;

            fSplash.Show();
            System.Threading.Thread.Sleep(2000);
            fSplash.Close();

        }

    }
}