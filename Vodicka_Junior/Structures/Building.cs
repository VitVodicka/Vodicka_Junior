using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodicka_Junior
{
    internal class Building
    {
        public int BuildingId { get; set; }

        

        public DateTime FirstApproval { get; set; }
        public Building(DateTime firstApproval, int buildingId)
        {
            BuildingId = buildingId;
            FirstApproval = firstApproval;
        }

    }
}
