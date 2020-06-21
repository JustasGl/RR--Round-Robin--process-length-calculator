using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            int q;
            int prsk;
            Console.WriteLine("Iveskite Procesu skaiciu");
            prsk = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite Kvanto dydi");
            q=int.Parse(Console.ReadLine());
            int AllLenght = 0;
            int[] procesai = new int[prsk];
            int[] TimeTaken = new int[prsk];
            Queue<int> place = new Queue<int>();

            for (int i=0;i<prsk; i++)
            {
                Console.WriteLine("Iveskite proceso p{0} ilgi",i+1);
                procesai[i] = int.Parse(Console.ReadLine());
                AllLenght += procesai[i];
                place.Enqueue(i);
                TimeTaken[i] = 0;
            }
            int j;
            bool done=false;
            while (!done)
            {
                j= place.Peek();
                place.Dequeue();
                procesai[j] -= q;
                if (procesai[j] > 0) { 
                    place.Enqueue(j);
                }
                for (int i = 0; i < prsk; i++)
                {
                    if (i != j&&procesai[i] > 0)
                    {
                        if (procesai[j] < 0)
                            TimeTaken[i] += (q - Math.Abs(procesai[j]));
                        else if (procesai[j] >= 0)
                            TimeTaken[i] += q;

                    }
                }
                done = true;
                for (int i = 0; i < prsk; i++)
                    if (procesai[i] > 0)
                        done = false;

            }
            for (int i=0; i<prsk; i++)
            {
                Console.WriteLine("Procesas p{0} uztruko {1} ", i + 1, TimeTaken[i]);
            }
        }
    }
}
