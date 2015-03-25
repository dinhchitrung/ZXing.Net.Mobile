using System;
using Android.App;


namespace ZXing.Mobile
{
    public static class ZXingScanner
    {
        public static IMobileBarcodeScanner Instance { get; set; }

#if MONODROID

        public static void Init(Func<Activity> getActivity) 
        {
			if (Instance != null)
				throw new Exception("You have already initialized barcodes");

			//Instance = new BarCodesImpl(getActivity);
        }


        public static void Init(Activity activity) 
        {
            if (Instance != null)
				throw new Exception("You have already initialized barcodes");

            var app = Application.Context.ApplicationContext as Application;
            if (app == null)
                throw new Exception("Application Context is not an application");

            ActivityMonitor.CurrentTopActivity = activity;
            app.RegisterActivityLifecycleCallbacks(new ActivityMonitor());
            //Instance = new MobileBarcodeScanner(() => ActivityMonitor.CurrentTopActivity);
        }
#elif WINDOWS_PHONE || __UNIFIED__

        public static void Init() {
            //Instance = new ZxingScanner();
            Instance = new MobileBarcodeScanner();
        }
#else

        [Obsolete("You are calling the PCL Init() method.  You should be calling the platform Init().  Make sure you have included the nuget package in your platform projects.")]
        public static void Init() {
            throw new Exception("You are calling the PCL Init() method.  You should be calling the platform Init().  Make sure you have included the nuget package in your platform projects.");
        }
#endif
    }
}
