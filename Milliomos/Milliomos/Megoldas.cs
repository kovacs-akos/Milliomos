using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos
{
    class Megoldas : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPorpertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Pack> packs = new ObservableCollection<Pack>();
        
        
        private Pack _currentPack;
        public Pack currentPack
        {
            get { return _currentPack; }
            set { _currentPack = value; OnPorpertyChanged("currentPack"); }
        }

        public string currentAnswer { get; set; }



        public Megoldas()
        {
            ReadFile();
            GetQuestion();
        }

        public void ReadFile()
        {
            StreamReader sr = new StreamReader("questions.txt");
            while (!sr.EndOfStream)
            {
                string row = sr.ReadLine();
                packs.Add(new Pack(row));
            }
            sr.Close();
        }

        public void GetQuestion()
        {
            //if currentPack is not null, remove it from packs
            if (currentPack != null)
            {
                packs.Remove(currentPack);
            }
            //select random question from pack
            Random rnd = new Random();
            int rndPack = rnd.Next(0, packs.Count);
            currentPack = packs[rndPack];
            if (currentPack.A.Contains('*')) 
            {
                currentPack.A.Replace("*", "");
                currentAnswer = currentPack.A;
            }
            if (currentPack.B.Contains('*'))
            {
                currentPack.B.Replace("*", "");
                currentAnswer = currentPack.B;
            }
            if (currentPack.C.Contains('*'))

            {
                currentPack.C.Replace("*", "");
                currentAnswer = currentPack.C;

            }
            if (currentPack.D.Contains('*'))
            {
                currentPack.D.Replace("*", "");
                currentAnswer = currentPack.D;
            }

        }


    }
}
