
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsTodo.Model;
using XamarinFormsTodo.ViewModel;

namespace XamarinFormsTodo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoView : ContentPage
    {
        public TodoView(ITodoRepository todoRepository)
        {
            InitializeComponent();
            BindingContext = new TodoViewModel(todoRepository);
        }
    }
}