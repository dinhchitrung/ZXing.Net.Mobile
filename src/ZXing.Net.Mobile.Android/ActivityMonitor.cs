using System;
using Android.App;
using Android.OS;


namespace ZXing.Mobile {

    // TODO: ensure 4.0+
    internal class ActivityMonitor : Java.Lang.Object, Application.IActivityLifecycleCallbacks {
        public static Activity CurrentTopActivity { get; internal set; }


        public void OnActivityCreated(Activity activity, Bundle savedInstanceState) {
            CurrentTopActivity = activity;
        }


        public void OnActivityResumed(Activity activity) {
            CurrentTopActivity = activity;
        }


        public void OnActivityPaused(Activity activity) {}
        public void OnActivityDestroyed(Activity activity) {}
        public void OnActivitySaveInstanceState(Activity activity, Bundle outState) {}
        public void OnActivityStarted(Activity activity) {}
        public void OnActivityStopped(Activity activity) {}
    }
}