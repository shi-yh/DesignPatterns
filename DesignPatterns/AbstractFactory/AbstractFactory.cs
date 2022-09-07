using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Patrix
    {
        public void LoadScene(string gameSceneName)
        {
            PatrixSceneFactory psf = GetGameScene(gameSceneName);

            Texture texture = psf.CreateTexture();

            Model model = psf.CreateModel();

            model.FillTexture(texture);

        }

        private PatrixSceneFactory GetGameScene(string gameSceneName)
        {
            return (PatrixSceneFactory)Assembly.Load("DesignPatterns").CreateInstance("DesignPatterns." + gameSceneName);
        }
    }

    #region Abstract Factory

    abstract class PatrixSceneFactory
    {
        public abstract Model CreateModel();

        public abstract Texture CreateTexture();

    }


    abstract class Model
    {
        public abstract void FillTexture(Texture texture);
    }

    abstract class Texture
    {

    }

    #endregion

    #region HalfPaper Factory
    class HalfPaper : PatrixSceneFactory
    {
        public override Model CreateModel()
        {
            return new HalfPaperModel();
        }

        public override Texture CreateTexture()
        {
            return new HalfPaperTexture();
        }
    }

    class HalfPaperModel : Model
    {
        public HalfPaperModel()
        {
            Console.WriteLine("HalfPaper Model Created");
        }

        public override void FillTexture(Texture texture)
        {
            Console.WriteLine("Half Paper Model is filled Texture");
        }
    }

    class HalfPaperTexture : Texture
    {
        public HalfPaperTexture()
        {
            Console.WriteLine("Half Paper Texture Created");
        }
    }

    #endregion

    #region Matrix Facotry

    class Matrix : PatrixSceneFactory
    {
        public override Model CreateModel()
        {
            return new MatrixModel();
        }

        public override Texture CreateTexture()
        {
            return new MatrixTexture();
        }

    }

    class MatrixModel : Model
    {
        public override void FillTexture(Texture texture)
        {
            Console.WriteLine("Matrix Model is filled Texture");
        }

        public MatrixModel()
        {
            Console.WriteLine("Matrix Model Created");
        }
    }

    class MatrixTexture : Texture
    {
        public MatrixTexture()
        {
            Console.WriteLine("Matrix Texture Created");
        }
    }


    #endregion

}
