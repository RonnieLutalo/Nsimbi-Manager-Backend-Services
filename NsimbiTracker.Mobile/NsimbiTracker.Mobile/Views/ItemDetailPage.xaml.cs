using NsimbiTracker.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NsimbiTracker.Mobile.Views
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