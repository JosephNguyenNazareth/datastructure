using System;
namespace DegreeConverse {
    class Degree {
        private double Before;
        private double After;
        private string para;
        public void setBefore () {
            Console.Write ("Enter degree: ");
            Before = Convert.ToDouble (Console.ReadLine ());
        }
        public void setParameter () {
            Console.Write ("Enter parameter: Farenheit to Celcius or Celcius to Farenheit (FC or CF) ");
            para = Console.ReadLine ();
        }
        public void ConvertDegree () {
            if (para == "FC" || para == "fc" || para == "fC" || para == "Fc") {
                After = Math.Round (((Before - 32) / 1.8), 2);
            } else if (para == "CF" || para == "cf" || para == "Cf" || para == "cF") {
                After = Math.Round ((Before * 1.8 + 32), 2);
            }
        }
        public void Display () {
            setBefore ();
            setParameter ();
            ConvertDegree ();
            Console.Write ("Converted value: {0}", After);
        }
    }
    class Test {
        static void Main (string[] args) {
            Console.Write ("Select programme: ");
            int Choice = Convert.ToInt16 (Console.ReadLine ());
            if (Choice == 1) {
                Degree n = new Degree ();
                n.Display ();
            } else if (Choice == 2) {
                Vector2D Point = new Vector2D ();
                if (Point.setLocation () == 3) Point.Display ();
            } else if (Choice == 3) {
                Date ClientDate = new Date ();
                ClientDate.setCurrentDate ();
                ClientDate.setAfterDate ();
                ClientDate.Display ();
            }
            Console.ReadKey ();
        }
    }
    class Vector2D {
        private double xAxis, yAxis, length, angle;
        private string readInputLocation;
        public int setLocation () {
            Console.Write ("Vector A: ");
            readInputLocation = Console.ReadLine ();
            int index = 0;
            int horizon = 0;
            string SaveString = "";
            while (readInputLocation[index] != '\0') {
                if (readInputLocation[index] == '[') {
                    horizon = 1;
                } else if (readInputLocation[index] == ',') {
                    xAxis = Convert.ToDouble (SaveString);
                    SaveString = "";
                    if (horizon == 1) horizon = 2;
                } else if (readInputLocation[index] == ']') {
                    yAxis = Convert.ToDouble (SaveString);
                    if (horizon == 2) horizon = 3;
                    break;
                } else {
                    if (horizon == 1) {
                        SaveString += readInputLocation[index];
                    } else if (horizon == 2) {
                        SaveString += readInputLocation[index];
                    }
                }
                index++;
            }
            if (horizon != 3) Console.Write ("Syntax error.");
            return horizon;
        }
        public double calLength () {
            length = Math.Round (Math.Sqrt (xAxis * xAxis + yAxis * yAxis), 2);
            return length;
        }
        public void calAngle () { }
        public void Display () {
            Console.WriteLine ("Your input location: {0}", readInputLocation);
            Console.WriteLine ("Vector length: {0}", calLength ());
        }
    }
    class Date {
        private uint day, month, year;
        private string date;
        private string[] dateIndex = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private uint[] UnleapYear = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private uint[] LeapYear = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public void setCurrentDate () {
            Console.Write ("Current date: ");
            date = Console.ReadLine ();
        }
        public int setDuration () {
            Console.Write ("How many days after: ");
            return Convert.ToInt32 (Console.ReadLine ());
        }
        public void setAfterDate () {
            int MoreDay = setDuration ();
            int NewDay;
            for (int index = 0; index < 7; index++) {
                if (date == dateIndex[index]) {
                    NewDay = (index + MoreDay) % 7;
                    date = dateIndex[NewDay];
                    break;
                }
            }
        }
        public void Display () {
            Console.Write ("Day after: {0}", date);
        }
    }
}