using Autofac;
using ExamenXamarinJLR.ViewModels;
using ExamenXamarinJLR.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ExamenXamarinJLR.Services
{
    public class ServiceIoC
    {
        private IContainer container;
        public ServiceIoC()
        {
            this.RegisterDependecies();
        }
        private void RegisterDependecies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceSeries>();
            builder.RegisterType<SeriesListViewModel>();
            builder.RegisterType<PersonajesListViewModel>();
            builder.RegisterType<MainSeriesView>();
            builder.RegisterType<PersonajesSeriesViewModel>();
            builder.RegisterType<PersonajeNewViewModel>();
            string resourseName = "ExamenXamarinJLR.appsettings.json";
            Stream stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(resourseName);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Register<IConfiguration>(z => configuration);
            this.container = builder.Build();
        }
        public SeriesView SeriesView
        {
            get
            {
                return this.container.Resolve<SeriesView>();
            }
        }
        public PersonajeNewViewModel PersonajeNewViewModel
        {
            get
            {
                return this.container.Resolve<PersonajeNewViewModel>();
            }
        }
        public PersonajesSeriesViewModel PersonajesSeriesViewModel
        {
            get
            {
                return this.container.Resolve<PersonajesSeriesViewModel>();
            }
        }
        public PersonajesListViewModel PersonajesListViewModel
        {
            get
            {
                return this.container.Resolve<PersonajesListViewModel>();
            }
        }
        public SeriesListViewModel SeriesListViewModel
        {
            get
            {
                return this.container.Resolve<SeriesListViewModel>();
            }
        }
        public ServiceSeries ServiceSeries
        {
            get
            {
                return this.container.Resolve<ServiceSeries>();
            }
        }
    }
}
