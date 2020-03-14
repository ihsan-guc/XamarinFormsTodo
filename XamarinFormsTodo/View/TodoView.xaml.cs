
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsTodo.ViewModel;

namespace XamarinFormsTodo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            BindingContext = new TodoViewModel();
        }
    }
}