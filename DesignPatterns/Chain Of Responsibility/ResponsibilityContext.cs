using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    public enum FoodType
    {
        FoodType_meat,
        FoodType_vegetable,
        FoodType_drink
    }

    internal class ResponsibilityContext
    {
        public FoodType Type = FoodType.FoodType_meat;

        public string Description = "我想吃肉";

        public bool AuditResult = false;

        public string AuditRemark = "";


    }
}
