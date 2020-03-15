
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using DatabaseTodo;
using System.IO;

namespace XamarinFormsTodo.Droid
{
    [Activity(Label = "XamarinFormsTodo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            var dbPath = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "Todo.db");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            TodoRepository todoRepository = new TodoRepository(dbPath);
            LoadApplication(new App(todoRepository));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}