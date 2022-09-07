using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal enum MoodStateEnum
    {
        MoodStateEnum_happy,
        MoodStateEnum_angry,
        MoodStateEnum_sad,
        MoodStateEnum_joy,
    }

    internal abstract class MoodState
    {
        protected MoodContext context = null;

        protected abstract MoodStateEnum MoodStateEnum { get; }

        public MoodState(MoodContext context)
        {
            this.context = context;
        }

        public abstract void Handle(MoodStateEnum value);
    }
}
