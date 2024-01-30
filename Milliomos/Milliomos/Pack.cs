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
        //public List<string> Valaszok { get; set; }
        //public string Megoldas { get { return Valaszok.Where(x => x.Contains("*")).First().Replace("*", ""); } }
        public char Answer { get; set;}
        public string Difficulty { get; set; }
        

        public Pack(string row)
        {
            string[] data = row.Split(';');
            Question = data[0];
            //for (int i = 1; i <= 4; i++)
            //{
            //    Valaszok.Add(data[i]);
            //}
            A = data[1];
            B = data[2];
            C = data[3];
            D = data[4];
            Answer = data[5][0];
            Difficulty = data[6];

        }

        public Pack()
        {

        }
    }
}
