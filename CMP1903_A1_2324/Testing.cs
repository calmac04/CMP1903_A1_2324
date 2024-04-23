using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        private SevensOut sevens;
        private ThreeOrMore threes;
        public void TestRun()
        {
            Console.WriteLine("testing start");
            List<int> sevensdata = sevens.testrun();
            Debug.Assert(sevensdata[0] == 7);
            foreach (int i in sevensdata)
            {
                Debug.Assert(i >=2 && i<=12);
            }

            List<int> threesdata = threes.Testrun();
            Debug.Assert(threesdata[0] >= 20);
            int testscore = 0;
            testscore = threesdata[0];
            threesdata.RemoveAt(0);
            int score = 0;
            foreach (int i in threesdata)
            {
                Debug.Assert(i >= 1 && i <= 5);
                if (i == 3)
                {
                    score += 3;
                }
                else if (i == 4)
                {
                    score += 6;
                }
                else if (i == 5)
                {
                    score += 12;
                }
            }
            Debug.Assert(score == testscore);
            Console.WriteLine("testing end");
        }
    }
}
