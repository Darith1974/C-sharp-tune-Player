using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab12_Assn
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] frequency = { 139, 147, 165, 185, 196, 220, 247, 277, 294, 330, 370, 392, 440, 494, 554, 587, 659, 740, 784, 880, 988, 1109, 1175, 1318, 1480, 1568, 1760, 1976, 0, 0 };
            string[] notes = { "C,", "D,", "E,", "F,", "G,", "A,", "B,", "C", "D", "E", "F", "G", "A", "B", "c", "d", "e", "f", "g", "a", "b", "c'", "d'", "e'", "f'", "g'", "a'", "b'", "|", "~" };
            string music1 = "DEFGABcd", music2 = "D2E2F3GABcd", music3 = "defgabc'd'", music6 = "BEgb", music7 = "f'2d'2", music4 = "dcB|A2FAD2FA|dAdefdBd|A~F3DFAF|GBEFGdcB|A~F3D2FA|dAdefdBd|AdcBAFGE|FD~D3|";
            string music5 = "dD~D2 FDFA|dfaf gfec|dD~D2 FDFA|GFEF GABc|dD~D2 FDFA|dfaf gfeg|fdec dBAF|GFEF GABc|d2fd Adfd|d2fd BABc|d2fd Adfd|BGEF GABc|d2fd Adfd|d2fd cdeg|fdec dAFA|GFEF GABc|d2fd Adfd|d2fd BABc|dcde fdAF|GEFD ~E3z|~a3b afdf|gfef gbag|fdec dBAF|GFEF GABc|";
            string music8 = "beb";
            string music = music5;

            int x = music.Length;
            //string test = music.Insert(6, "F");
            int[] output = new int[1000];
            for (int outputIndex = 0, j = 0, i = 0, r = 2; i < (x + 1); j++)
            {
                if (j == 30)
                {
                    j = 0;
                }
                if (i == (x - 1))
                {
                    if ((music.IndexOf(notes[j]) != -1))
                    {
                        output[music.IndexOf(notes[j])] = frequency[j];
                        i++;
                        //Console.Beep(frequency[j], 250);
                        outputIndex++;
                        break;
                        if (i == (x + 1))
                        {
                            break;
                        }
                    }

                }
                if ((music.IndexOf(notes[j]) != -1) && ((music[music.IndexOf(notes[j]) + 1] != '\'') || (music[music.IndexOf(notes[j]) + 1] != ',')))
                {
                    output[music.IndexOf(notes[j])] = frequency[j];
                    i++;
                    outputIndex++;
                    //Console.Beep(frequency[j], 250);
                    //if (outputIndex > 0)
                    //{
                    //outputIndex--;
                    //}
                    if (i == (x + 1))
                    {
                        break;
                    }
                    if (char.IsDigit(music[(music.IndexOf(notes[j])) + 1]))
                    {
                        double Num_ref = Char.GetNumericValue(music, (music.IndexOf(notes[j]) + 1));
                        for (int count = 1; count < Num_ref; count++, i++)
                        {
                            output[music.IndexOf(notes[j]) + count + outputIndex] = frequency[j];
                            //music = music.Insert();
                            //Console.Beep(frequency[j], 250);
                            outputIndex++;
                        }
                        if (Num_ref > 2)
                        {
                            int b = Convert.ToInt32(Num_ref) - 2;
                            x = x + b;
                        }
                        if (i == (x + 1))
                        {
                            break;
                        }
                        //outputIndex--;
                        //outputIndex--;

                    }
                }
                if ((music.IndexOf(notes[j]) != -1) && ((music[music.IndexOf(notes[j]) + 1] == '\'') || (music[music.IndexOf(notes[j]) + 1] == ',')))
                {
                    output[music.IndexOf(notes[j])] = frequency[j];
                    i++;
                    //Console.Beep(frequency[j], 250);
                    //if (outputIndex > 0)
                    //{
                    //    outputIndex--;
                    //}
                    if (i == (x + 1))
                    {
                        break;
                    }
                    if (char.IsDigit(music[(music.IndexOf(notes[j])) + 2]))
                    {
                        double Num_ref = Char.GetNumericValue(music, (music.IndexOf(notes[j]) + 1));
                        for (int count = 1; count < Num_ref; count++, i++)
                        {
                            output[music.IndexOf(notes[j]) + count] = frequency[j];
                            //Console.Beep(frequency[j], 250);
                            outputIndex++;
                        }
                        if (Num_ref > 2)
                        {
                            int b = Convert.ToInt32(Num_ref) - 2;
                            x = x + b;
                        }
                        if (i == (x + 1))
                        {
                            break;
                        }
                        //outputIndex--;
                        //outputIndex--;
                    }
                }


            }




            for (int a = 0; a < 1000; a++)
            {
                if (output[a] != 0)
                {
                    Console.Beep(output[a], 250);
                }
            }


        }
    }
}




