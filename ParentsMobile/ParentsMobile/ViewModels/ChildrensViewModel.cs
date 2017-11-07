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
        ApiServices apiServices = new ApiServices();

        public string AccessToken { get; set; }

        public List<Childrens> _childrens { get; set; }

        public List<Childrens> Childrens
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
                    _childrens = await apiServices.GetIdeasAsync(AccessToken);
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
