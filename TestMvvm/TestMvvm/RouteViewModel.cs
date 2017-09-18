using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestMvvm
{
    public class RouteViewModel : INotifyPropertyChanged
    {
        private Route route;

        public RouteViewModel(Route r)
        {
            route = r;
        }

        public string Title
        {
            get { return route.Title; }
            set
            {
                route.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            /*if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));*/

            // simplified delegate invocation:
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
