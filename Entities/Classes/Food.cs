using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Food
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public FoodType Category { get; set; }
        public Measure Unit { get; set; }
        public decimal UnitaryCost { get; set; }
        public bool IsOrganic { get; set; }
    }
}
