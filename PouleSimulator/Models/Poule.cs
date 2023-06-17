using System.ComponentModel;

namespace PouleSimulator
{
    public class Poule: IPoule, INotifyPropertyChanged
    {
        private ITeam teamA;
        private ITeam teamB;
        private ITeam teamC;
        private ITeam teamD;

        public ITeam TeamA 
        {   get => teamA;
            set
            {
                if (teamA != value)
                {
                    teamA = value;
                    OnPropertyChanged(nameof(TeamA));
                }
            }
        }
        public ITeam TeamB
        {
            get => teamB;
            set
            {
                if (teamB != value)
                {
                    teamB = value;
                    OnPropertyChanged(nameof(TeamB));
                }
            }
        }
        public ITeam TeamC
        {
            get => teamC;
            set
            {
                if (teamC != value)
                {
                    teamC = value;
                    OnPropertyChanged(nameof(TeamC));
                }
            }
        }
        public ITeam TeamD
        {
            get => teamD;
            set
            {
                if (teamD != value)
                {
                    teamD = value;
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
