using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Cinema_UserControl.Model
{
    public class Cadira: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private long id;
        private Point coord;
        private Categoria cat;
        private long idGrup;
        private EnumEstat estat;

        public Cadira(long id, Point coord, Categoria cat, long idGrup, EnumEstat estat)
        {
            Id = id;
            Coord = coord;
            Cat = cat;
            IdGrup = idGrup;
            Estat = estat;
        }

        public long Id { get => id; set => id = value; }
        public Point Coord { get => coord; set => coord = value; }
        public Categoria Cat { get => cat; set => cat = value; }
        public long IdGrup { get => idGrup; set => idGrup = value; }
        internal EnumEstat Estat
        {
            get => estat;
            set
            {
                estat = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs("Estat"));
            }
        }

    }
}
