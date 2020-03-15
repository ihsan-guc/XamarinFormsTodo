using Xamarin.Forms;
using XamarinFormsTodo.Model;
using XamarinFormsTodo.View;
using XamarinFormsTodo.ViewModel;

namespace XamarinFormsTodo
{
    public partial class App : Application
    {
        public App(ITodoRepository todoRepository)
        {
            InitializeComponent();
            MainPage = new TodoView(todoRepository);
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
