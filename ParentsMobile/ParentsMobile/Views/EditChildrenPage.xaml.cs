using ParentsMobile.Models;
using ParentsMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditChildrenPage : ContentPage
    {
        public EditChildrenPage(Childrens children)
        {
            var editChildrenViewModel = new EditChildrenViewModel();
            editChildrenViewModel.Childrens = children;

            BindingContext = editChildrenViewModel;

            InitializeComponent();

            //var editChildrenViewModel = BindingContext as EditChildrenViewModel;

            //editChildrenViewModel.Children = children;
        }
    }
}