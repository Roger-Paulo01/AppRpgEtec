using Android.App;
using Android.Runtime;
using AppRpgEtec.Models;
using Javax.Security.Auth.Login;

namespace AppRpgEtec
{
    [Application(UsesCleartextTraffic =true)]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
