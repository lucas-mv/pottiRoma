﻿using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class EditPersonalDataPage : ContentPage
    {
        public EditPersonalDataPageViewModel ViewModel
        {
            get
            {
                return (EditPersonalDataPageViewModel)this.BindingContext;
            }
        }
        public EditPersonalDataPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
