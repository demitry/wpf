using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestMvvm
{
    public class Route : INotifyPropertyChanged
    {
        private string title;
        private double lenght;
        private string start;
        private string finish;

        public Route()
        {
        }

        public Route(string title)
        {
            Title = title;
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public double Lenght
        {
            //get { return lenght; }, can use new style:
            get => lenght;
            set
            {
                lenght = value;
                OnPropertyChanged("Lenght");
            }
        }

        public string Start { get => start; set => start = value; }

        public string Finish { get => finish; set => finish = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
