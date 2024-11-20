using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_3
{
    public class CricketTeam
    {
        public void PointsCalculation(int no_of_matches)
        {
            
            Console.WriteLine("Enter the scores:");
            int[] scores = new int[no_of_matches];
            for(int i=0; i < no_of_matches; i++)
            {
                scores[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            for(int i = 0; i < no_of_matches; i++)
            {
                sum = sum + scores[i];
            }
            int average = sum / no_of_matches;
            Console.WriteLine("The Count of matches is:" + no_of_matches);
            Console.WriteLine("The Average of the scores is:" + average);
            Console.WriteLine("The sum of the scores is:" + sum);


            Console.Read();
            
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the no.of.matches:");
            int no_of_matches = Convert.ToInt32(Console.ReadLine());
            CricketTeam c1 = new CricketTeam();
            c1.PointsCalculation(no_of_matches);
        }
    }
}
