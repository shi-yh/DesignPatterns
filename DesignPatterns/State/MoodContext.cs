using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class MoodContext
    {
        MoodState state = null;

        public void Change(MoodStateEnum value)
        {
            state.Handle(value);
        }

        public void SetState(MoodState value)
        {
            state = value;
        }


    }
}
