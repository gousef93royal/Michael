using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Statistics
    {
        //todo: add total for each lending items, type of food and drink.
        
        public int CheckedInTotal { get; set; }
        public int CheckedOutTotal { get; set; }
        public int TotalMales { get; set;  }
        public int TotalFemale { get; set; }


        public int TotalLentItems { get; set;  }
        public int TotalAvailableItems { get; set; }



        public int TotalFoodSold { get; set; }
        public int TotalDrinksSold { get; set; }


        public int TotalAvailableCampingSpots { get; set; }
        public int TotalTakenCampingSpots { get; set; }


        public Statistics(int checkInTotal, int checkedOutTotal, int totalMale, int totalFemale, int totalDrinksSold, int totalFoodSold, int totalAvailableSpots,
            int totalTakenCampingSpots)
        {
            this.CheckedInTotal = checkInTotal;
            this.CheckedOutTotal = CheckedOutTotal;
            this.TotalMales = totalMale;
            this.TotalFemale = totalFemale;
            this.TotalDrinksSold = totalDrinksSold;
            this.TotalFoodSold = totalFoodSold;
            this.TotalAvailableCampingSpots = totalAvailableSpots;
            this.TotalTakenCampingSpots = TotalTakenCampingSpots;

        }
    }
}
