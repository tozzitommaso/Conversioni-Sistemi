using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversioniSistemi
{
    class Program
    {
        /*nt[4] elementi(ottetti) => decimale puntato (es 10.10.10.10) return bool[32]

        metodi:

        bool[] Convert_DP_to_Bin(int[] dp) { return bool[]; }

        int Convert_DP_to_Int(int[] dp) { return int; }

        int Convert_Bin_to_Int(bool[] bn) { return int; }

        int[] Convert_Bin_to_DP(bool[] b) { return int[]; }*/
        static void Main(string[] args)
        {
            int[] dp = new int[4];
            for(int i = 0; i<dp.Length;i++)
            {
                Console.WriteLine($"Inseirsci la cifra numero {i + 1}");
                dp[i] = Convert.ToInt32(Console.ReadLine());
            }

            bool[] bn = Convert_DP_to_Bin(dp);

            for (int i = 0; i < bn.Length; i++)
            {
                Console.Write(Convert.ToInt32(bn[i]));
            }

            Console.WriteLine(" ");
            Console.WriteLine(Convert_DP_to_Int(dp)); 
            Console.WriteLine(" ");
            Console.WriteLine(Convert_Bin_to_Int(bn));
            Console.WriteLine(" ");
            Console.WriteLine(Convert_Bin_to_DP(bn));
            Console.ReadLine();

        }
        static bool[] Convert_DP_to_Bin(int[] dp)
        {
            bool[] bn = new bool[32];       //array binario
            int z = bn.Length - 1;      //inizializzo la variabile z all'ultimo indice dell'array

            for(int i = 0; i<dp.Length;i++)
            {
                int numero = dp[i];      //do alla nuova variabile numero il valore corrente
                for (int j = 0; j < 8; j++)
                {
                    bn[z] = numero % 2 == 1;  //inserisce il bit giusto nell'ordine inverso
                    numero = numero / 2;
                    z--;
                }
            }
            return bn;
        }
        static int Convert_DP_to_Int(int[] dp)
        {
            int numDecimale = 0;
            int z = 3;

            for (int i = 0; i < dp.Length; i++)
            {
                numDecimale += dp[i] * (int)Math.Pow(256, z--);
            }
            return numDecimale;

        }
        static int Convert_Bin_to_Int(bool[] bn)
        {
            int numIntero = 0;
            int z = bn.Length - 1;

            for (int i = 0; i < bn.Length; i++) 
            {
                if (bn[i])
                    numIntero += (int)Math.Pow(2, z);

                z--;
            }
            return numIntero;
        }
        static int Convert_Bin_to_DP(bool[] bn)
        {
            int dec = 0;

            for (int i = 0; i < bn.Length; i++)
            {
                if (bn[i])
                    dec = (int)Math.Pow(10, 31 - i);
            }
            return dec;
                    
        }
    }
}
