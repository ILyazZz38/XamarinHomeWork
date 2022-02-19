using HW.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WEB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly PictureViewModel viewmodel = new PictureViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }
    }
}
