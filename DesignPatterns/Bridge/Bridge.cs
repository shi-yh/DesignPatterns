using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    abstract class PatrixScene
    {
        protected GameMode mode;

        public GameMode Mode
        {
            get => mode;
            set => mode = value;
        }


        public abstract void LoadScene();

    }

    abstract class GameMode
    {
        public abstract void InitScene();
    }

    class HalfPaperScene : PatrixScene
    {
        public override void LoadScene()
        {
            Console.WriteLine("Load HalfPaper Completed");
            mode.InitScene();
        }
    }

    class MatrixScene : PatrixScene
    {
        public override void LoadScene()
        {
            Console.WriteLine("Load Matrix Completed");
            mode.InitScene();
        }
    }

    class GoldMode : GameMode
    {
        public override void InitScene()
        {
            Console.WriteLine("Init Gold Mode Completed");
        }
    }
    class PropertyMode : GameMode
    {
        public override void InitScene()
        {
            Console.WriteLine("Init Property Mode Completed");
        }
    }
}
