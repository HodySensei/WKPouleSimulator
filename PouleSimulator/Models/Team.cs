using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public class Team : ITeam, INotifyPropertyChanged
    {
        private int _id;
        private int _offensePoints;
        private int _defensePoints;
        private int _teamplayPoints;
        private string _name;
        private int _played;
        private int _win;
        private int _draw;
        private int _loss;
        private int _for;
        private int _against;
        private int _points;

        public int ID 
        {
            get => this._id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }
        public int OffensePoints 
        { 
            get => this._offensePoints;
            set
            {
                if (_offensePoints != value)
                {
                    _offensePoints = value;
                    OnPropertyChanged(nameof(OffensePoints));
                }
            }
        }
        public int DefensePoints 
        { 
            get => this._defensePoints;
            set
            {
                if (_defensePoints != value)
                {
                    _defensePoints = value;
                    OnPropertyChanged(nameof(DefensePoints));
                }
            }
        }
        public int TeamPlayPoints 
        { 
            get => this._teamplayPoints;
            set
            {
                if (_teamplayPoints != value)
                {
                    _teamplayPoints = value;
                    OnPropertyChanged(nameof(TeamPlayPoints));
                }
            }
        }
        public string Name 
        { 
            get => this._name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public int Played 
        { 
            get => this._played;
            set
            {
                if (_played != value)
                {
                    _played = value;
                    OnPropertyChanged(nameof(Played));
                }
            }
        }
        public int Win 
        { 
            get => this._win;
            set
            {
                if (_win != value)
                {
                    _win = value;
                    OnPropertyChanged(nameof(Win));
                }
            }
        }
        public int Draw 
        { 
            get => this._draw;
            set
            {
                if (_draw != value)
                {
                    _draw = value;
                    OnPropertyChanged(nameof(Draw));
                }
            }
        }
        public int Loss 
        { 
            get => this._loss;
            set
            {
                if (_loss != value)
                {
                    _loss = value;
                    OnPropertyChanged(nameof(Loss));
                }
            }
        }
        public int For 
        { 
            get => this._for;
            set
            {
                if (_for != value)
                {
                    _for = value;
                    OnPropertyChanged(nameof(For));
                    OnPropertyChanged(nameof(Difference));
                }
            }
        }
        public int Against 
        { 
            get => this._against;
            set
            {
                if (_against != value)
                {
                    _against = value;
                    OnPropertyChanged(nameof(Against));
                    OnPropertyChanged(nameof(Difference));
                }
            }
        }
        public int Difference 
        { 
            get => this._against +- this.For;
        }
        public int Points 
        { 
            get => this._points;
            set
            {
                if (_points != value)
                {
                    _points = value;
                    OnPropertyChanged(nameof(Points));
                }
            }
        }

        public void UpdateStats(int goalsMade, int goalsTaken)
        {
            this.Played++;

            bool winner = goalsMade + -goalsTaken > 0;
            bool draw = goalsMade + -goalsTaken == 0;

            if (winner)
            {
                this.Win++;
                this.Points += 3;
            }
            else if (draw)
            {
                this.Draw++;
                this.Points++;
            }
            else 
                this.Loss++;

            this.For += goalsTaken;
            this.Against += goalsMade;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
