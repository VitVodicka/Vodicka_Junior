using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodicka_Junior
{
    internal class Building
    {
        

        public int Id { get; set; }//declaring object Building(object from databse BuildingState
        public string Date { get; set; }
        public int IdType { get; set; }

        public int Stamp { get; set; }
        public int NeccessityInvestment { get; set; }
        public int InvestmentAmount { get; set; }
        public string Note { get; set; }

        public Building(int id, string date, int idType, int stamp, int neccessityInvestment, int investmentAmount, string note)
        {
            Id = id;
            Date = date;
            IdType = idType;
            Stamp = stamp;
            NeccessityInvestment = neccessityInvestment;
            InvestmentAmount = investmentAmount;
            Note = note;
        }
        


    }
}
