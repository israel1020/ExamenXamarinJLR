using ExamenXamarinJLR.Base;
using ExamenXamarinJLR.Models;
using ExamenXamarinJLR.Services;
using ExamenXamarinJLR.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenXamarinJLR.ViewModels
{
    public class SeriesListViewModel:ViewModelBase 
    {
        private ServiceSeries service;
        public SeriesListViewModel(ServiceSeries service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                await this.LoadSeries();
            });
            MessagingCenter.Subscribe<SeriesListViewModel>(this, "RELOAD", async (sender) =>
             {
                 await this.LoadSeries();
             });
        }
        private async Task LoadSeries()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            this.Series = new ObservableCollection<Serie>(series);
        }
        public Command InsertarSeries
        {
            get
            {
                return new Command(async()=>
                {
                    MessagingCenter.Send<SeriesListViewModel>(App.ServiceLocator.SeriesListViewModel, "RELOAD");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Has Insertado Correctamente", "OK");
                });
            }
        }
        public Command MotrarPersonajes
        {
            get
            {
                return new Command(async(idserie)=>
                {
                    List<Personaje> personajes = await this.service.FindPersonajesSeriesAsyn((int)idserie);
                    PersonajesSeriesView view = new PersonajesSeriesView();
                    PersonajesSeriesViewModel viewmodel = App.ServiceLocator.PersonajesSeriesViewModel;
                    viewmodel.Personajes = new ObservableCollection<Personaje>(personajes);
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
        private ObservableCollection<Serie> _Series;
        public ObservableCollection<Serie> Series
        {
            get { return this._Series; }
            set
            {
                this._Series = value;
                OnPropertyChanged("Series");
            }
        }
    }
}
