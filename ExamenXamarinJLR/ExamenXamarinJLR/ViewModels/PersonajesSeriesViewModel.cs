using ExamenXamarinJLR.Base;
using ExamenXamarinJLR.Models;
using ExamenXamarinJLR.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExamenXamarinJLR.ViewModels
{
    public class PersonajesSeriesViewModel: ViewModelBase
    {
        private ServiceSeries service;
        public PersonajesSeriesViewModel(ServiceSeries service)
        {
            this.service = service;
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
