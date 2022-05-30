using MobileApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApplication.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}