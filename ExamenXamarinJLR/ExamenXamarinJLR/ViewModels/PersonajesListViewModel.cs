using ExamenXamarinJLR.Base;
using ExamenXamarinJLR.Models;
using ExamenXamarinJLR.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExamenXamarinJLR.ViewModels
{
    public class PersonajesListViewModel: ViewModelBase
    {
        private ServiceSeries service;
        public PersonajesListViewModel(ServiceSeries service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                await LoadPersonajes();
            });
        }
        private async Task LoadPersonajes()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            this.Personajes = new ObservableCollection<Personaje>(personajes);
        }
        private ObservableCollection<Personaje> _Personajes;
        public ObservableCollection<Personaje> Personajes
        {
            get { return this._Personajes; }
            set
            {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }
    }
}
