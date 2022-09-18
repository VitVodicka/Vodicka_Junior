﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodicka_Junior.Structures
{
    internal class Background : INotifyPropertyChanged
    {
        public ObservableCollection<Building> BuildingCollection { get; set; }
        public List<User> UserLogin { get; set; }
        public Background()
        {
            BuildingCollection = new ObservableCollection<Building>();
            UserLogin = new List<User>();   
        }
        public void Change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void AddToCollection(Building b)
        {
            BuildingCollection.Add(b);
            Change("BuildingCollection");
        }
        public void RemoveFromCollection(int index)
        {
            if (index >-1 ) { 
            BuildingCollection.RemoveAt(index);
            Change("BuildingCollection");
            }

        }
        public void AddingToList(User u)
        {
            UserLogin.Add(u);
        }
        public bool ListLoading(string username, string password)
        {
            bool resault = false;
            foreach (User us in UserLogin)
            {
                if((us.Username == username)&& (us.Password == password)){
                    resault = true;
                   
                }
            }
            return resault;
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
