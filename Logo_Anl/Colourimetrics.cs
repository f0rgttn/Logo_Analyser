using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Logo_Anl
{
    class Colourimetrics
    {
        private static Dictionary<string, double> ColourDictionary = new Dictionary<string, double>();
        public static void ColourDic()
        {
            ColourDictionary.Add("red", 0);
            ColourDictionary.Add("vermillion", 15);
            ColourDictionary.Add("orange", 30);
            ColourDictionary.Add("golden yellow", 45);
            ColourDictionary.Add("yellow", 60);
            ColourDictionary.Add("lime", 75);
            ColourDictionary.Add("olive", 90);
            ColourDictionary.Add("grass green", 105);
            ColourDictionary.Add("green", 120);
            ColourDictionary.Add("cobalt green", 135);
            ColourDictionary.Add("teal", 150);
            ColourDictionary.Add("turquoise", 165);
            ColourDictionary.Add("cyan", 180);
            ColourDictionary.Add("cerulean blue", 195);
            ColourDictionary.Add("azure", 210);
            ColourDictionary.Add("blue", 225);
            ColourDictionary.Add("ultramarine", 240);
            ColourDictionary.Add("hyacinth", 255);
            ColourDictionary.Add("violet", 270);
            ColourDictionary.Add("purple", 285);
            ColourDictionary.Add("magenta", 300);
            ColourDictionary.Add("crimson", 315);
            ColourDictionary.Add("scarlet", 330);
            ColourDictionary.Add("carmine", 345);
        }

        private static List<Color> ColoursIn = new List<Color>();
        private static List<Color> ColoursOnce = new List<Color>();
        private static List<string> NamedColours = new List<string>();
        private static List<string> Dict_list = new List<string>();
        private static List<string> Output = new List<string>();

        public static List<string> Colour(Image Logo, bool AllPixels)
        {
            ColourDic();

            var Dict_List = ColourDictionary.Values.ToList();
            Dict_List.Sort();

            //Converts image to bitmap and then takes the argb pixel colours of each pixel
            Bitmap logo = new Bitmap(Logo);
            //nested for loop that returns the colour of each 
            for (int i = 0; i < logo.Width; i++)
            {
                for (int j = 0; j < logo.Height; j++)
                {
                    var pixel = logo.GetPixel(i, j);
                    ColourStore(pixel);
                    // Console.WriteLine(ColoursIn[i * j].ToString());
                }
            }

            if (AllPixels == true)
            {
                //display all colour values with names in ColourIn (this means there will be repeating values)
                foreach (Color colour in ColoursIn)
                {
                    //convert RGB to HSL
                    HSL tempHSL = Colour_Scheme_Convert.RGB_to_HSL(colour);
                    string Name = ColourNaming(colour, Dict_List);
                    string output = tempHSL.Info() + Name +"... \n";
                    Output.Add(output);
                }
            }
            else
            {
                // display all colours from ColourOnce
                foreach (Color colour in ColoursOnce)
                {
                    // convert to HSL
                    HSL tempHSL = Colour_Scheme_Convert.RGB_to_HSL(colour);
                    //Console.Write(tempHSL.Info() + "... ");
                    string Name = ColourNaming(colour, Dict_List);
                    //Console.Write(Name + "\n");
                    //Console.WriteLine();
                    string output = tempHSL.Info() + Name + "... \n";
                    Output.Add(output);
                }
            }
            //Dictionary is cleared here because the dictionary is created upon the start of
            //Colourimetric class, if not clear the program would error as the program would 
            //be adding duplicates into the dictionary
            ColourDictionary.Clear();
            return Output; //Named the returning List output just to clarify that is what is returned from the colourimetic
        }


        public static void ColourStore(Color pixel)
        {
            ColoursIn.Add(pixel);

            if (!ColoursOnce.Contains(pixel))
                ColoursOnce.Add(pixel);
        }

        static string ColourNaming(Color colour, List<double> Dict_List)
        {
            string ColourNamed = null;
            HSL L = Colour_Scheme_Convert.RGB_to_HSL(colour);
            double l = L.L_transfer();
            if (l == 1 || l == 0)
            {
                if (l == 1)
                {
                    ColourNamed = "Black";

                }
                ColourNamed = "White";
            }
            else
            {
                HSL H = Colour_Scheme_Convert.RGB_to_HSL(colour);
                double h = H.H_transfer();

                double closest = Dict_List.Aggregate((x, y) => Math.Abs(x - h) < Math.Abs(y - h) ? x : y);
                ColourNamed = ColourDictionary.First(x => x.Value == closest).Key;
            }

            return ColourNamed;
        }
    }

    public class Colour_Scheme_Convert
    {
        public static HSL RGB_to_HSL(Color c)
        {
            HSL hsl = new HSL();

            //store hue as 0-1.0 instead of 0-360 that RGB uses
            hsl.H = c.GetHue() / 360.0;
            //hsl.H = c.GetHue();
            hsl.L = c.GetBrightness();
            hsl.S = c.GetSaturation();

            return hsl;
        }
    }

    public class HSL
    {
        public HSL() //constructor
        {
            _h = 0;
            _s = 0;
            _l = 0;
        }

        double _h;
        double _s;
        double _l;

        public string Info()
        {
            string theInfo = "";
            theInfo += $"h={_h * 360}, s={_s}, l={_l}... ";
            return theInfo;
        }

        public double L_transfer()
        {
            return (_l);
        }

        public double H_transfer()
        {
            return (_h * 360);
        }


        public double H
        {
            get { return _h; }
            set
            {
                _h = value;
                _h = _h > 1 ? 1 : _h < 0 ? 0 : _h;
            }
        }

        public double S
        {
            get { return _s; }
            set
            {
                _s = value;
                _s = _s > 1 ? 1 : _s < 0 ? 0 : _s;
            }
        }

        public double L
        {
            get { return _l; }
            set
            {
                _l = value;
                _l = _l > 1 ? 1 : _l < 0 ? 0 : _l;
            }
        }
    }


}
