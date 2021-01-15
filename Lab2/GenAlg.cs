using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class GenAlg
    {
        readonly int razmer = 1000;         //размер популяции
        readonly int max_iter = 100;        //максимум итераций
        readonly double mp = 0.4;           //мутация
        readonly double ln = 0.3;           //порог отсечения
        readonly double p = 0.7;            //вероятность скрещивания
        readonly double dlt = 0.0001;     
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public int wag { get; private set; }
        public Func<double, double> Func;
        public List<Potomok> Popylyaciya = new List<Potomok>();

        private double func(double x) 
        {
            return Func(x);
        }

        public void Init() 
        {
            GenPop();
            Ocenka();
        }

        public Potomok Process()  
        {
            int i = 0;
            for (; i < max_iter; i++) 
            {
                Skrewivanie();
                Mytaciya();
                Ocenka();
                Selekciya();
                if (Math.Abs(Popylyaciya.First().Y - Popylyaciya.Last().Y) <= dlt)
                    break;
            }
            wag = i;
            return Popylyaciya.First();
        }

        public void GenPop() 
        {
            for(int i = 0; i < razmer; i++) 
            {
                var potom = new Potomok()
                {
                    X = (rnd.NextDouble() - 0.5) * 100000
                };
                Popylyaciya.Add(potom);
            }
        }

        public void Ocenka()  //оценка популяции
        {
            foreach(var potom in Popylyaciya) 
            {
                potom.Y = func(potom.X);
            }
            Popylyaciya.Sort();
        }

        public void Selekciya()   //селекция
        {
            for(int i = (int)(Popylyaciya.Count * ln); i < Popylyaciya.Count; i++) 
                Popylyaciya.RemoveAt(i);
        }

        public void Skrewivanie() //скрещивание
        {
            var old_razmer = Popylyaciya.Count;
            while (Popylyaciya.Count < razmer) 
            {
                int i = (int)(rnd.NextDouble() * old_razmer);
                int j = (int)(rnd.NextDouble() * old_razmer);

                if(p > rnd.NextDouble()) 
                {
                    var deti = SkrewPot(Popylyaciya[i], Popylyaciya[j]);
                    Popylyaciya.Add(deti.Item1);
                    Popylyaciya.Add(deti.Item2);
                }
            }
        }

        public (Potomok, Potomok) SkrewPot(Potomok x, Potomok y) 
        {
            var lambda = rnd.NextDouble();
            var zx = new Potomok() { X = lambda * x.X + (1 - lambda) * y.X };
            var zy = new Potomok() { X = lambda * y.X + (1 - lambda) * x.X };
            return (zx, zy);
        }

        public void Mytaciya()  //мутация
        {
            foreach(var potom in Popylyaciya) 
            {
                if(mp > rnd.NextDouble())
                {
                    potom.X += (rnd.NextDouble() - 0.5) * 100;
                }
            }
        }
    }
}
