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
            int[] frequency = { 139, 147, 165, 185, 196, 220, 247, 277, 294, 330, 370, 392, 440, 494, 554, 587, 659, 740, 784, 880, 988, 1109, 1175, 1318, 1480, 1568, 1760, 1976, 32000 };
            char[] notes = { '#', '#', '#', '#', '#', '#', '#', 'C', 'D', 'E', 'F', 'G', 'A', 'B', 'c', 'd', 'e', 'f', 'g', 'a', 'b', '#', '#', '#', '#', '#', '#', '#', 'z' };
            // Here i have created two arrays, one for each of the notes plus the corresponding frequency. The '#' sysmbols are merely here to fill array and accomodate 
            // easy reference. For example 'C' corresponds to 7 in notes its frequenct will be index 7 in frequency. "C," is seven places below in notes and hence seven places
            // the corrsesponding index for 'C' in frequency.
            char[] symbol = { '\'', ',' };
            string music1 = "DEFGABcd", music2 = "D2E2F3GABcd", music3 = "defgabc'd'", music6 = "BEgb", music7 = "d2c'd'|a~D3", music4 = "dcB|A2FAD2FA|dAdefdBd|A~F3DFAF|GBEFGdcB|A~F3D2FA|dAdefdBd|AdcBAFGE|FD~D3|";
            string music5 = "dD~D2 FDFA|dfaf gfec|dD~D2 FDFA|GFEF GABc|dD~D2 FDFA|dfaf gfeg|fdec dBAF|GFEF GABc|d2fd Adfd|d2fd BABc|d2fd Adfd|BGEF GABc|d2fd Adfd|d2fd cdeg|fdec dAFA|GFEF GABc|d2fd Adfd|d2fd BABc|dcde fdAF|GEFD ~E3z|~a3b afdf|gfef gbag|fdec dBAF|GFEF GABc|";
            string music8 = "ab z", music9 = "dc,dc,";
            string music = music5;
            music = music + "$";
            // At various stages in this program i analyze the next digit simultaneously as well looking for the current one.
            // However this can cause issues in that if i am trying to ascertain the last character to but if it is looking for a character not there, i.e end of index
            // then the program will stop. My solution is to add a reduntant character "$" at the end of each string which at various satges of the below program
            // if found in 'i' or 'i+1' position, the program will exit the main loop.
            int x = music.Length;
            int z = 10 * x;
            // I initially set the lenght of the for loop to be ten times the lenght of the string, probably not the most efficient way for breaking the loop
            // but it works. Additionally i set break conditions inside the loop when the "$" character is found.
            int[] output = new int[1000];
            int[] duration = new int[1000];
            // Here i have created an array containing the frequencies to be outputted in order. Also there is an array which contains the duartion of each note.
            char[] musicArray = music.ToCharArray();
            // Here i create a character array of the string. My for loop will analyze each character in the array sequentially and act accordinally.
            int y = musicArray.Length; int index = 0;
            //index is used here to reference element of the output and duration arrays. when a character match is made the corresponding entry in output and duration
            // is updated.
            for (int i = 0, j = 0; i < z; j++)
            // I initialise the for loop with i= 0, j=0. "i" here represents the each character in the or is the index used to access each element of musicArray.
            //"j" represents each member of the notes array, its index. On each interation of the loop the character in the music arry is evaluated against the current
            // note, notes[j].
            {
                if (j == 29)
                {
                    j = 0;
                }
                // My notes array has 29 members. When the loop has gone through all elements of this array it will simply reset and start searching again. 
                else if ((musicArray[i] == '|') || (musicArray[i] == ' '))
                {
                    index++; i++;
                    //If a bar or space is found in the Array i simply leave the corresponding entry in the output and duration as blank.
                }
                else if (musicArray[i] == '~')
                {
                    int Num_ref = Convert.ToInt32(Char.GetNumericValue(musicArray[i + 2]));
                    // Num_ref converts the digit obtained from the string to a int value, i could i have also simply evaluated musicArray[i+2] directly as either
                    // '2'or '3'.
                    // if a ~ is found in the string, this represents a roll. So e.g ~D2 becomes E50,D250,C50,D200; four different notes with different duration.
                    if (Num_ref == 3)
                    {
                        for (int l = 0; l <= 28; l++)
                        {
                            //This for loop matches the element in musicArray with the notes and creates the entries the n the output & duration array accordinally.
                            //Note 'i' is incremented three times to account for three characters have been determined. 
                            if (musicArray[i + 1] == notes[l])
                            {
                                output[index] = frequency[l];
                                duration[index] = 250;
                                output[index + 1] = frequency[l + 1];
                                duration[index + 1] = 50;
                                output[index + 2] = frequency[l];
                                duration[index + 2] = 200;
                                output[index + 3] = frequency[l - 1];
                                duration[index + 3] = 50;
                                output[index + 4] = frequency[l];
                                duration[index + 4] = 200;
                                index = index + 5;
                                i = i + 3;
                                break;
                            }
                        }


                    }
                    else if (Num_ref == 2)
                    {
                        for (int l = 0; l <= 28; l++)
                        {
                            //This for loop matches the element in musicArray with the notes and creates the entries the n the output & duration array accordinally.
                            if (musicArray[i + 1] == notes[l])
                            {
                                //output[index] = frequency[l];
                                //duration[index] = 250;
                                output[index] = frequency[l + 1];
                                duration[index] = 50;
                                output[index + 1] = frequency[l];
                                duration[index + 1] = 200;
                                output[index + 2] = frequency[l - 1];
                                duration[index + 2] = 50;
                                output[index + 3] = frequency[l];
                                duration[index + 3] = 200;
                                index = index + 4;
                                i = i + 3;
                                break;
                            }
                        }


                    }

                }

                else if ((musicArray[i] == notes[j]) && (musicArray[i + 1] == '$'))
                {
                    //If the current reference to musicArray matches a corresponding reference in notes and the next element in musicArray is '$', i.e end of
                    // string; then finish off output and duration and then break out of the loop.
                    output[index] = frequency[j];
                    duration[index] = 250;
                    index++; i++; break;

                }
                else if ((musicArray[i] == notes[j]) && (char.IsDigit(music[i + 1])))
                {

                    //This statement handles the fact that the next character is a letter followed by a digit. This merely indicates that the note is played for that number
                    // times the standard duration. convert the digit to int and multiply duration by that value. Increment the index and i by two as two characters
                    // are been accesed simultaneously.
                    int Num_ref = Convert.ToInt32(Char.GetNumericValue(musicArray[i + 1]));
                    output[index] = frequency[j];
                    duration[index] = 250 * Num_ref;
                    index++; i++; i++;
                }
                else if ((musicArray[i] == notes[j]) && (!(musicArray[i + 1] == '\'')) && (!(musicArray[i + 1] == ',')))
                {
                    //Else if the next characters are e.g letter, then not number or coma or apostrophe then match output according to that letter.
                    output[index] = frequency[j];
                    duration[index] = 250;
                    index++; i++;
                }
                else if ((musicArray[i] == notes[j]) && (musicArray[i + 1] == '\''))
                {
                    // This else if statement handles the fact that the next sequence is a letter followed by apostrophe. There is not a direct match between output
                    // and frequency but a jump of seven places forward in the arry, hence frequency[j+7].
                    output[index] = frequency[j + 7];
                    duration[index] = 250;
                    index++; i++; i++;
                    // A break if last character is met.
                    if (musicArray[i] == '$')
                    {
                        break;
                    }


                }
                else if ((musicArray[i] == notes[j]) && (musicArray[i + 1] == ','))
                {
                    // This else if statement handles the fact that the next sequence is a letter followed by apostrophe. There is not a direct match between output
                    // and frequency but a jump of seven places forward in the arry, hence frequency[j-7].
                    output[index] = frequency[j - 7];
                    duration[index] = 250;
                    index++; i++; i++;
                    // A break if last character is met.
                    if (musicArray[i] == '$')
                    {
                        break;
                    }


                }
                // A break if last character is met.
                else if (musicArray[i] == '$')
                {

                    break;
                }


            }
            // This for loop goes through each element of the output array and sends it to console.beep with its corresponding duration.
            for (int a = 0; a < 1000; a++)
            {
                if (output[a] != 0)
                {
                    Console.Beep(output[a], duration[a]);
                }
            }

        }

    }
}
