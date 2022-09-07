using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class DrinkHandler:FoodHandler
    {
        public override FoodType Type => FoodType.FoodType_drink;

        public override void HandleRequest(ResponsibilityContext context)
        {
            context.AuditRemark += "-饮料相关-";
            if (context.Type==Type)
            {
                context.AuditResult = true;
                Console.WriteLine("{0}  处理请求  {1}", this.GetType().Name, context);
            }
            else if (successor != null)
            {
                successor.HandleRequest(context);
            }

        }
    }
}
