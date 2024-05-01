using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{
    public class IndexArray
    {
        private Phonebook[] phonebookArray;
        private Phonebook2[] phonebookArray2;
        public IndexArray(Phonebook[] phonebookarray)
        {
            this.phonebookArray = phonebookarray;
        }
        public IndexArray(Phonebook2[] phonebookarray)
        {
            this.phonebookArray2 = phonebookarray;
        }
        public int[] BildIndexArray()
        {
            int n = phonebookArray.Length;
            int[] indexArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexArray[i] = i;
            }
            bool swapped;
            int start = 0;
            int end = n - 1;
            do
            {
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (phonebookArray[indexArray[i]].CompareTo(phonebookArray[indexArray[i + 1]]) > 0)
                    {
                        int tmt = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = tmt;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                swapped = false;
                end--;
                for (int i = end - 1; i >= start; i--)
                {
                    if (phonebookArray[indexArray[i]].CompareTo(phonebookArray[indexArray[i + 1]]) > 0)
                    {
                        int temp = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = temp;
                        swapped = true;
                    }
                }
                start++;
            } while (swapped);
            return indexArray;
        }
        public int[] BildIndexArray2()
        {
            int n = phonebookArray2.Length;
            int[] indexArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexArray[i] = i;
            }
            bool swapped;
            int start = 0;
            int end = n - 1;
            do
            {
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (phonebookArray2[indexArray[i]].CompareTo(phonebookArray2[indexArray[i + 1]]) > 0)
                    {
                        int tmt = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = tmt;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                swapped = false;
                end--;
                for (int i = end - 1; i >= start; i--)
                {
                    if (phonebookArray2[indexArray[i]].CompareTo(phonebookArray2[indexArray[i + 1]]) > 0)
                    {
                        int temp = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = temp;
                        swapped = true;
                    }
                }
                start++;
            } while (swapped);
            return indexArray;
        }
        public int[] BildIndexArray2(Phonebook2[] array)
        {
            int n = array.Length;
            int[] indexArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexArray[i] = i;
            }
            bool swapped;
            int start = 0;
            int end = n - 1;
            do
            {
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (array[indexArray[i]].CompareTo(array[indexArray[i + 1]]) > 0)
                    {
                        int tmt = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = tmt;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                swapped = false;
                end--;
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[indexArray[i]].CompareTo(array[indexArray[i + 1]]) > 0)
                    {
                        int temp = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = temp;
                        swapped = true;
                    }
                }
                start++;
            } while (swapped);
            return indexArray;
        }
        public int[] BildIndexArray(Phonebook[] array)
        {
            int n = array.Length;
            int[] indexArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexArray[i] = i;
            }
            bool swapped;
            int start = 0;
            int end = n - 1;
            do
            {
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if (array[indexArray[i]].CompareTo(array[indexArray[i + 1]]) > 0)
                    {
                        int tmt = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = tmt;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                swapped = false;
                end--;
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[indexArray[i]].CompareTo(array[indexArray[i + 1]]) > 0)
                    {
                        int temp = indexArray[i];
                        indexArray[i] = indexArray[i + 1];
                        indexArray[i + 1] = temp;
                        swapped = true;
                    }
                }
                start++;
            } while (swapped);
            return indexArray;
        }
        public int BinarySearch(string lastName)
        {
            
            int low = 0;
            int high = phonebookArray.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int compareResult = string.Compare(phonebookArray[mid].surname, lastName);
                if (compareResult == 0)
                {
                    return mid;
                }
                else if (compareResult < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return 0;
        }
        public int[] SearchAll(string r, Phonebook2[] array )
        {
            List<int> result = new List<int>();
            int[] index = BildIndexArray2(array);
            for ( int i = 0;i < array.Length;i++)
            {
                if (array[index[i]].area == r)
                {
                    result.Add(i);
                }
                else continue;
            }
            return result.ToArray();
        }

        public int[] SearchAll(string r, Phonebook[] array)
        {
            List<int> result = new List<int>();
            int[] index = BildIndexArray(array);
            
            for (int i = 0; i < array.Length; i++)
            {
                string flag = array[index[i]].surname + " " + array[index[i]].name + " " + array[index[i]].petronymic;
                if (flag == r)
                {
                    result.Add(i);
                }
                else continue;
            }
            return result.ToArray();
        }
    } 
}
