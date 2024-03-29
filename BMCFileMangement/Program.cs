using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using BMCFileMangement.Services.Interface;
using BMCFileMangement.Services.Implementation;
using BMCFileMangement.forms;
using System.Windows.Forms.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using BMCFileMangement.forms.UserControls;
using BMCFileMangement.Services.DisServices;

namespace BMCFileMangement
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfigurationRoot _config;

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("buttonClickedAsdf"))
            {
                // Simulate the activation event manually
                ToastNotificationManagerCompat_OnActivated(null);
            }
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhKYVtpR2Nbe05xdl9CY1ZQTGYuP1ZhSXxXdkdjXn9edHdUT2VUU0Y=");
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

                ToastNotificationManagerCompat.OnActivated += ToastNotificationManagerCompat_OnActivated; ;


                // Show splash screen
                var splashScreen = new frmSplashScreen(); // Replace with your splash screen form
                splashScreen.Show();
                System.Threading.Thread.Sleep(1000);

                // Simulate login (replace with actual login logic)
                var _IConfigurationRoot = ServiceProvider.GetRequiredService<IConfigurationRoot>();
                var _ILoggerFactory = ServiceProvider.GetRequiredService<ILoggerFactory>();
                var _IMessageService = ServiceProvider.GetRequiredService<IMessageService>();
                var _IApplicationLogService = ServiceProvider.GetRequiredService<IApplicationLogService>();
                var _UserProfileService = ServiceProvider.GetRequiredService<IUserProfileService>();
                var _FTPTransferService = ServiceProvider.GetRequiredService<IFTPTransferService>();

                var loginForm = new frmLogin(
                    _IConfigurationRoot,
                    _ILoggerFactory,
                    _IMessageService,
                    _IApplicationLogService,
                    _UserProfileService);
                var loginResult = loginForm.ShowDialog();

                //// Close splash screen after login
                splashScreen.Close();

                //// Check login result
                if (loginResult == DialogResult.OK)
                {
                    Application.Run(ServiceProvider.GetRequiredService<BMCFileMangement.forms.frmMainWindow>()); // Replace with your main form
                }

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

        private static void ToastNotificationManagerCompat_OnActivated(ToastNotificationActivatedEventArgsCompat e)
        {
            clsUpdatedDBHandler objCls = new clsUpdatedDBHandler();
            objCls.UpdateFileOpenAndShowPopAndDownload(e);
            objCls.Dispose();
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
                services.AddTransient<IApplicationLogService, ApplicationLogService>();
                services.AddTransient<IUserProfileService, UserProfileService>();
                services.AddTransient<IFTPTransferService, FTPTransferService>();
                services.AddTransient<BMCFileMangement.forms.frmMainWindow>();
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