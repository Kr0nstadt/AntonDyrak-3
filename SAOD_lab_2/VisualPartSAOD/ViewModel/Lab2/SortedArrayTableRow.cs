using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{
    public class SortedArrayTableRow
    {
        public SortedArrayTableRow()
        {
            TheorMC = 0;
            RandomCM = 0;
            IncreaseCM = 0;
            DecreaseCM = 0;
        }
        public SortedArrayTableRow(int size, Func<BaseIntArray, BaseSortedIntArray> creator)
        {
            _n = size;

            RandomIntArray randomIntArray = new RandomIntArray((uint)size);
            IncreasingIntArray increasingIntArray = new IncreasingIntArray((uint)size);
            DecreasingIntArray decreasingIntArray = new DecreasingIntArray((uint)size);

            _randomSortedArray = creator(randomIntArray);
            _increaseSortedArray = creator(increasingIntArray);
            _decreaseSortedArray = creator(decreasingIntArray);

            TheorMC = _randomSortedArray.TM + _randomSortedArray.TC;
            RandomCM = _randomSortedArray.C + _randomSortedArray.M + _randomSortedArray.CMHeap;
            IncreaseCM = _increaseSortedArray.C + _increaseSortedArray.M + _increaseSortedArray.CMHeap;
            DecreaseCM = _decreaseSortedArray.C + _decreaseSortedArray.M + _decreaseSortedArray.CMHeap;
            StepShell = _randomSortedArray.Step;
            GepShell = _randomSortedArray.Gep;
            RandomPCM = _randomSortedArray.CMHeap;//_randomSortedArray.PC + _randomSortedArray.PM + 1 ;
            IncreasePCM = _increaseSortedArray.CMHeap;//_increaseSortedArray.PC + _increaseSortedArray.PM + 1;
            DecreasePCM = _decreaseSortedArray.CMHeap;//_decreaseSortedArray.PC + _decreaseSortedArray.PM + 1;
            TheorPCM = _randomSortedArray.TCMHeap;
            TheorCMHeap = _randomSortedArray.CMHeapSort;
            RandomST = (int)(_randomSortedArray.Step * 0.33);
            IncreaseST = (int)(_increaseSortedArray.Step*0.33);
            DecreaseST =(int)( _decreaseSortedArray.Step*0.33);
            RandomST2 = (int)(_randomSortedArray.Step * 0.7);
            IncreaseST2 = (int)(_increaseSortedArray.Step * 0.7);
            DecreaseST2 = (int)(_decreaseSortedArray.Step * 0.7);
        }

        public int N => _n;

        public int TheorMC { get; init; }
        //public int TheorCMHeap {  get; init; }
        public int RandomCM { get; init; }
        public int IncreaseCM { get; init; }
        public int DecreaseCM { get; init; }
        public int StepShell { get; init; }
        public string GepShell { get; init; }
        public int RandomPCM { get; init; }
        public int IncreasePCM { get; init; }
        public int DecreasePCM { get; init; }
        public int TheorPCM { get; init; }
        public int RandomST {get; init;}
        public int IncreaseST { get; init;}
        public int DecreaseST { get; init;}
        public int TheorCMHeap {  get; init; }
        public int IncreaseST2 { get; init; }
        public int DecreaseST2 { get; init; }
        public int RandomST2 { get; init; }
        private int _n;
        private readonly BaseSortedIntArray? _randomSortedArray;
        private readonly BaseSortedIntArray? _increaseSortedArray;
        private readonly BaseSortedIntArray? _decreaseSortedArray;
    }
}
