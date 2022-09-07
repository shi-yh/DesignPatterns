using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal abstract class FoodHandler
    {
        protected FoodHandler successor;

        public abstract FoodType Type { get; }

        public void SetSuccessor(FoodHandler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(ResponsibilityContext context);

    }
}
