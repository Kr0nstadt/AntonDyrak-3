using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Attitude
    {
        public int[,] Attitube;
        public List<char> Chars;
        public Attitude(string relationStr, Variety v)
        {
            if (IsAttitudeFromSet(relationStr, v._varieti) == false)
            {
                throw new ArgumentException("Invalid relation");
            }
            SortedSet<char> elements = new SortedSet<char>(v._varieti);
            string[] relations = relationStr.Split(',');

            /*foreach (string relation in relations)
            {
                elements.Add(relation[0]);
                elements.Add(relation[1]);
            }*/

            List<char> sortedElements = new List<char>(elements);
            sortedElements.Sort();
            Chars = sortedElements;

            int n = elements.Count;
            int[,] relationMatrix = new int[n, n];

            foreach (string relation in relations)
            {
                int i = sortedElements.IndexOf(relation[0]);
                int j = sortedElements.IndexOf(relation[1]);
                relationMatrix[i, j] = 1;
            }
            Attitube = relationMatrix;
        }
        public override string ToString()
        {
            string txt = "";
            for(int i = 0; i < Attitube.GetLength(0); i++)
            {
                for(int j = 0; j < Attitube.GetLength(1); j++)
                {
                    txt += Attitube[i, j] + " ";
                }
                txt += "\n";
            }
            return txt;
        }

        private bool IsAttitudeFromSet(string attitude, char[] set)
        {
            string attitudeWithoutComma = attitude.Replace(",", "");

            foreach (char c in attitudeWithoutComma)
            {
                if (Array.IndexOf(set, c) == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
