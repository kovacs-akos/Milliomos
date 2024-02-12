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

        public int Actual{ get; private set; }




        public Megoldas()
        {
            ReadFile();
            
        }

        public void ReadFile()
        {
            StreamReader sr = new StreamReader("questions.txt", Encoding.UTF8);
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

            Actual++;

        }

        public bool CheckAnswer(char answer)
        {
            if (answer == currentPack.Answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteQuestion()
        {
            packs.Remove(currentPack);
        }

        


    }
}
