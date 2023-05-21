using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumFinder.Model
{
    
    public  class MuseumModel
    {
        [PrimaryKey, AutoIncrement]
        public int MuseumID { get; set; }
        [MaybeNull]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Year { get; set; }
        public string Latitude { get; set; }
        public  string Longitude { get; set; }
        public string Info { get; set; }
        public string Path { get; set; }
        public string Rating { get; set; }
    }
}
