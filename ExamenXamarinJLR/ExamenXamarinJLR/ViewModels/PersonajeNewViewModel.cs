using ExamenXamarinJLR.Base;
using ExamenXamarinJLR.Models;
using ExamenXamarinJLR.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExamenXamarinJLR.ViewModels
{
    public class PersonajeNewViewModel: ViewModelBase
    {
        private ServiceSeries service;
        public PersonajeNewViewModel(ServiceSeries service)
        {
            this.service = service;
            this.Personaje = new Personaje();
        }
        public Command InsertarPersonaje
        {
            get
            {
                return new Command(async()=>
                {
                    await this.service.InsertarPersonaje(this.Personaje.Nombre, this.Personaje.Imagen, this.Personaje.IdSerie);
                    await Application.Current.MainPage.DisplayAlert("Alert", "Has insertado", "Ok");
                });
            }
        }
        private Personaje _Personaje;
        public Personaje Personaje
        {
            get { return this._Personaje; }
            set
            {
                this._Personaje = value;
                OnPropertyChanged("Personaje");
            }
        }
    }
}
