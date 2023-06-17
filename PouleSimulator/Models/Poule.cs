using System.ComponentModel;

namespace PouleSimulator
{
    public class Poule: IPoule, INotifyPropertyChanged
    {
        private ITeam _teamA;
        private ITeam _teamB;
        private ITeam _teamC;
        private ITeam _teamD;

        public ITeam TeamA 
        {   get => _teamA;
            set
            {
                if (_teamA != value)
                {
                    _teamA = value;
                    OnPropertyChanged(nameof(TeamA));
                }
            }
        }
        public ITeam TeamB
        {
            get => _teamB;
            set
            {
                if (_teamB != value)
                {
                    _teamB = value;
                    OnPropertyChanged(nameof(TeamB));
                }
            }
        }
        public ITeam TeamC
        {
            get => _teamC;
            set
            {
                if (_teamC != value)
                {
                    _teamC = value;
                    OnPropertyChanged(nameof(TeamC));
                }
            }
        }
        public ITeam TeamD
        {
            get => _teamD;
            set
            {
                if (_teamD != value)
                {
                    _teamD = value;
                    OnPropertyChanged(nameof(TeamD));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
