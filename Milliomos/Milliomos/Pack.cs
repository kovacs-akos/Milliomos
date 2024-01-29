using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos
{
    class Pack
    {
        public string Question { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Difficulty { get; set; }
        public string Id { get; set;}
        

        public Pack(string row)
        {
            string[] data = row.Split(';');
            Question = data[0];
            A = data[1];
            B = data[2];
            C = data[3];
            D = data[4];
            Difficulty = data[5];
        }

        public Pack()
        {

        }
    }
}
