﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace TestMvvm
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Route selectedRoute;

        public ObservableCollection<Route> Routes { get; set; }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        string strTemporaryName = "Route " + (Routes.Count + 1).ToString();
                        Route route = new Route(strTemporaryName);
                        Routes.Insert(0, route);
                        SelectedRoute = route;
                    }));
            }
        }

        public Route SelectedRoute
        {
            get { return selectedRoute; }
            set
            {
                selectedRoute = value;
                OnPropertyChanged("SelectedRoute");
            }
        }

        public ApplicationViewModel()
        {
            Routes = new ObservableCollection<Route>
            {
                new Route { Title="Route 1" },
                new Route { Title="Route 2" },
                new Route { Title="Route 3" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
