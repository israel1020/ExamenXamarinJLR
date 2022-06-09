using ExamenXamarinJLR.Code;
using ExamenXamarinJLR.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenXamarinJLR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainSeriesView : MasterDetailPage
    {
        public MainSeriesView()
        {
            InitializeComponent();
            ObservableCollection<MasterPageItem> menu = new ObservableCollection<MasterPageItem>
            {
                 new MasterPageItem
                {
                    Titulo = "Series",
                    Icono = "1.png",
                    Tipo = typeof(SeriesView)
                },
                new MasterPageItem
                {
                    Titulo = "Personajes",
                    Icono = "2.png",
                    Tipo = typeof(PersonajesView)
                },
                new MasterPageItem
                {
                    Titulo = "New Personaje",
                    Icono = "3.png",
                    Tipo = typeof(PersonajeNewView)
                }
            };
            this.lsvMenu.ItemsSource = menu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(SeriesView)));
            this.lsvMenu.ItemSelected += LsvMenu_ItemSelected;
        }

        private void LsvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem item = e.SelectedItem as MasterPageItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.Tipo));
            IsPresented = false;
        }
    }
}