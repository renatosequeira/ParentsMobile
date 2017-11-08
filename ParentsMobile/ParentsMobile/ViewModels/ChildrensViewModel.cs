using ParentsMobile.Helpers;
using ParentsMobile.Models;
using ParentsMobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParentsMobile.ViewModels
{
    public class ChildrensViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();

        //public string AccessToken { get; set; }

        private List<Childrens> _childrens;

        public List<Childrens> ChildrenList
        {
            get { return _childrens; }
            set
            {
                _childrens = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetChildrensCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = Settings.AccessToken;
                    ChildrenList = await _apiServices.GetChildrenAsync(accessToken);
                });
            }
        }

        #region OnPropertyChanged
        //Atualiza os dados, cada vez que o estado da app é modificado
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
