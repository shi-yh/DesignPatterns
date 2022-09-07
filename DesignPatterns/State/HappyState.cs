using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State
{
    internal class HappyState:MoodState
    {
        public HappyState(MoodContext context) : base(context)
        {
        }

        protected override MoodStateEnum MoodStateEnum => MoodStateEnum.MoodStateEnum_happy;

        public override void Handle(MoodStateEnum value)
        {
            if (value == MoodStateEnum)
            {
                //context.SetState()
            }
        }

    }
}
