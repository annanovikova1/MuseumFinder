using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MuseumFinder.Model
{
        public class MuseumModels
        {
            [PrimaryKey, AutoIncrement]
            public int MuseumID { get; set; }

            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Year { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string Info { get; set; }
            public string Path { get; set; }
            public string Rating { get; set; }
        }
    }



