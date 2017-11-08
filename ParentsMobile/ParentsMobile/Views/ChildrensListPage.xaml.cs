﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildrensListPage : ContentPage
    {
        public ChildrensListPage()
        {
            InitializeComponent();
        }

        private async void GoToAddChildrenPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewChildrenPage());
        }
    }
}