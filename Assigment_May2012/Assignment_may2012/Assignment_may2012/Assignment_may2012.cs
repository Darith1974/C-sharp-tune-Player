using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            ///char SpecialCase="'";
            int f = 293, duration = 250;
            Console.Beep(f, duration);
            ///Console.Beep(440, 500);
            string MusicInput = "A,Aa'a";
            ///char[] MusicInputArray = Console.Read().ToCharArray();
            char[] MusicInputArray = MusicInput.ToCharArray();
            int x = MusicInputArray.Length;
            float[] frequency = {220F, 439.99F, 1759.97F, 879.99F};
            int[] output = new int[x];
            for(int i=0,j=0;i<(x-1);i++)
            {
                if((MusicInputArray[i]=='A') && (MusicInputArray[i+1] == ','))
                {
                    output[j]=220;
                    j++;
                }
                else if ((MusicInputArray[i] == 'A')&& (!(MusicInputArray[i+1] == ',')))
                {
                    output[j]=440;
                    j++;
                }
                else if ((MusicInputArray[i] == 'a') && (MusicInputArray[i + 1] == '\''))
                {
                    output[j] = 1760;
                    j++;
                }
                else if ((MusicInputArray[i] == 'a')&& (!(MusicInputArray[i + 1] == '\'')))
                {
                    output[j] = 880;
                    j++;
                }
                                  
            }
            for (int i = 0; i < (x-1); i++)
            {
                Console.Beep(output[i], duration);
            }

        }
    }
}



