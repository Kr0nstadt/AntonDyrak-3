using SAOD_lab_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital;
using System.Collections;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class DigitSortViewModel
    {
        public DigitSortViewModel(IntArrayMade array)
        {
            _array = array;
        }
        public override string ToString()
        {
            string incSorted = ArrayString(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Inc), (Digital_Sort.QueueMake(Inc).Peek().Length))));
            int mIncSorted = Digital_Sort.M;
            Digital_Sort.M = 0;

            string decSorted = ArrayString(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Dec), (Digital_Sort.QueueMake(Dec).Peek().Length))));
            int mDecSorted = Digital_Sort.M;
            Digital_Sort.M = 0;

            string randSorted = ArrayString(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Ran), (Digital_Sort.QueueMake(Ran).Peek().Length))));
            int mRandSorted = Digital_Sort.M;
            Digital_Sort.M = 0;

            return $"Исходный возрастающий : {ArrayString(Inc)}\n" +
                $"Исходный в побитовом представлении : {QueueString(Digital_Sort.QueueMake(Inc))}\n" +
                $"Количество серий : {Digital_Sort.Series(Inc)}\n" +
                $"Контрольная сумма : {Digital_Sort.Sum(Inc)}\n" +
                $"После сортировки : {incSorted}\n" +
                $"После сортировки в обратном порядке  : {ArrayString(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSortReverse(Digital_Sort.QueueMake(Inc), (Digital_Sort.QueueMake(Inc).Peek().Length))))}\n" +
                $"После сортировки в побитовом представлении : {QueueString(Digital_Sort.QueueMake(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Inc), (Digital_Sort.QueueMake(Inc).Peek().Length)))))}\n" +
                $"Количество серий : {Digital_Sort.Series(Digital_Sort.IntArrayMake(Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Inc), (Digital_Sort.QueueMake(Inc).Peek().Length))))}\n" +
                $"Контрольная сумма : {Digital_Sort.Sum(Digital_Sort.IntArrayMake(Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Inc), (Digital_Sort.QueueMake(Inc).Peek().Length))))}\n\n" +
                $"Фактические сравнения :{mIncSorted}\n" +
                $"Теоритические сравнения : {TheorM}\n\n" +

                $"Исходный убывающий : {ArrayString(Dec)}\n" +
                $"Исходный в побитовом представлении : {QueueString(Digital_Sort.QueueMake(Dec))} \n" +
                $"Количество серий : {Digital_Sort.Series(Dec)}\n" +
                $"Контрольная сумма : {Digital_Sort.Sum(Dec)}\n" +
                $"После сортировки : {decSorted}\n" +
                $"После сортировки в обратном порядке  : {ArrayString(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSortReverse(Digital_Sort.QueueMake(Dec), (Digital_Sort.QueueMake(Dec).Peek().Length))))}\n" +
                $"После сортировки в побитовом представлении : {QueueString(Digital_Sort.QueueMake(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Dec), (Digital_Sort.QueueMake(Dec).Peek().Length)))))}\n" +
                $"Количество серий : {Digital_Sort.Series(Digital_Sort.IntArrayMake(Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Dec), (Digital_Sort.QueueMake(Dec).Peek().Length))))}\n" +
                $"Контрольная сумма : {Digital_Sort.Sum(Digital_Sort.IntArrayMake(Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Dec), (Digital_Sort.QueueMake(Dec).Peek().Length))))}\n\n" +
                $"Фактические сравнения :{mDecSorted}\n" +
                $"Теоритические сравнения : {TheorM}\n\n" +
                
                $"Исходный рандомный : {ArrayString(Ran)}\n" +
                $"Исходный в побитовом представлении : {QueueString(Digital_Sort.QueueMake(Ran))}" +
                $"Количество серий : {Digital_Sort.Series(Ran)}\n" +
                $"Контрольная сумма : {Digital_Sort.Sum(Ran)}\n" +
                $"После сортировки : {randSorted}\n" +
                $"После сортировки в обратном порядке  : {ArrayString(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSortReverse(Digital_Sort.QueueMake(Ran), (Digital_Sort.QueueMake(Ran).Peek().Length))))}\n" +
                $"После сортировки в побитовом представлении : {QueueString(Digital_Sort.QueueMake(Digital_Sort.IntArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Ran), (Digital_Sort.QueueMake(Ran).Peek().Length)))))} \n" +
                $"Количество серий : {Digital_Sort.Series(Digital_Sort.IntArrayMake(Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Ran), (Digital_Sort.QueueMake(Ran).Peek().Length))))}\n" +
                $"Контрольная сумма : {Digital_Sort.Sum(Digital_Sort.IntArrayMake(Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Ran), (Digital_Sort.QueueMake(Ran).Peek().Length))))}\n\n" +
                $"Фактические сравнения :{mRandSorted}\n" +
                $"Теоритические сравнения : {TheorM}\n\n";
        }

        private IntArrayMade _array;
        private int[] Inc => _array.IncIntArray;
        private int[] Dec => _array.DecIntArray;
        private int[] Ran => _array.RandIntArray;

        private int TheorM => 4 * (256 + _array.array.Length);
        private string ArrayString(int[] array)
        {
            string res = "";
            for(int i = 0; i < array.Length; i++)
            {
                res += array[i].ToString() + " ";
            }
            return res;
        }
        private string QueueString(Queue<byte[]> array)
        {
            string res = "";
            foreach(byte[] b in array)
            {
                res += Convert.ToString(BitConverter.ToInt32(b), 2).PadLeft(32, '0');
                res += " ";
            }
            return res;
        }
    }
}
