using System;
using System.Linq;

namespace LinusTorvalds
{
    public class Work
    {   

        public static void Main(String[] args)
        {
            getTimeAndOutputAnswer();
        }

        static void getTimeAndOutputAnswer() {
            Console.WriteLine(
                getAnswerString(
                    countDegreesBetweenHands(
                        parseTime(
                            atAnyPriceGetValidTimeInputFromConsole()
                        )
                    )
                )
            );
        }

        static String atAnyPriceGetValidTimeInputFromConsole() {
            String timeString;

            do {
                Console.WriteLine("Write time in 'hh:mm' format");
                timeString = Console.ReadLine();
            } while (!isValidTime(timeString));

            return timeString;
        }

        static String getAnswerString(double degrees) {
            return String.Format("Answer is {0:0.0} degrees", degrees);
        }

        static bool isValidTime(String timeString) {
            String[] timeStrings = timeString.Split(':');
            
            if (timeStrings.Length != 2 || timeStrings[0] == "" || timeStrings[1] == "") {
                Console.WriteLine("Input Err. Use valid fromat 'hh:mm'");
            }
            
            if (Int32.TryParse(timeStrings[0], out int h)) {
                if (h < 0 || h >= 24){
                    Console.WriteLine("Hours aren't valid");
                    return false;
                }
            }

            if (Int32.TryParse(timeStrings[1], out int m)) {
                if (m < 0 || m >= 60) {
                    Console.WriteLine("Minutes aren't valid");
                    return false;
                } else {
                    return true;
                }
            }

            Console.WriteLine("Input not parseble. Use format hh:mm");
            return false;
        }

        static int[] parseTime(String timeString) {
            String[] timeStrings = timeString.Split(':');
            Int32.TryParse(timeStrings[0], out int h);
            Int32.TryParse(timeStrings[1], out int m);
            return new int[2] {h, m};
        }

        static double countDegreesBetweenHands(int [] time) {
            return Math.Abs(((time[0] % 12 + (time[1]+0.0) / 60) * 30 - time[1]*6) % 180);
        }
    }
}
