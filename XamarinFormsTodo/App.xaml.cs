using Xamarin.Forms;
using XamarinFormsTodo.View;
using XamarinFormsTodo.ViewModel;

namespace XamarinFormsTodo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TodoView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
