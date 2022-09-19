using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodicka_Junior.Structures
{
    internal class Collection : INotifyPropertyChanged
    {
        public ObservableCollection<Building> BuildingCollection { get; set; }//Buildingcollection observablecollection (BuildingElements table)
        public List<User> UserLogin { get; set; }//list with users
        public ObservableCollection<SvereneBudovy> SvereneBudovyCollection { get; set; }// observablecollection from severeneBudovy view (BuildingElements table)
        public ObservableCollection<Element> ElementsCollection { get; set; }//elements of building observablecollection of
        public Collection()
        {
            BuildingCollection = new ObservableCollection<Building>();//declaring lists/observablecollections
            UserLogin = new List<User>();
            SvereneBudovyCollection = new ObservableCollection<SvereneBudovy>();
            ElementsCollection = new ObservableCollection<Element>(); 

        }
        public void Change(string property)//providing changes to observablecollections
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void AddToCollection(Building b)//adds to Buildingcollection(BuildingElements table)
        {
            BuildingCollection.Add(b);
            Change("BuildingCollection");//updates changes
        }
        public void AddingElementsToList(Element e)
        {
            ElementsCollection.Add(e);
            Change("ElementsCollection");
        }


        public void RemoveFromCollection(int index)//removes from BuildingCollection
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
        public void AddingToSvereneBudovy(SvereneBudovy s)
        {
            SvereneBudovyCollection.Add(s);
            Change("SvereneBudovyCollection");
        }

        public bool ListLoading(string username, string password)//checks if entered login is in list
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
