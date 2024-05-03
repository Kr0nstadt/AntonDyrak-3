using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SAOD_lab_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using Digital;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class DigitalSortInfo
    {
        public DigitalSortInfo()
        {
            RandomIntArray randomIntArray = new RandomIntArray(20);
            IncreasingIntArray increasingIntArray = new IncreasingIntArray(20);
            DecreasingIntArray decreasingIntArray = new DecreasingIntArray(20);

            IntArrayMade IntArray = new IntArrayMade(20);
            ShortArrayMade ShortArray = new ShortArrayMade(20);

            string[] StringArray = { "Пупкин", "Смотрова", "Янченко", "Алегина", "Фахурдинов" };

            _DigitSortViewModel = new DigitSortViewModel(IntArray);
            _DigitSortViewModelSurname = new DigitSortViewModelSurname(StringArray);
            _DigitSortViewModelShort = new DigitSortViewModelShort(ShortArray);

            _randomHeapIntArrayViewModel = new IntArrayViewModel(randomIntArray,
                new HeapCreator(randomIntArray),
                (n) => 3 * (n * n - n) / 2,
                (n) => (n * n - n) / 2);
            _increasingHeapIntArrayViewModel =
                new IntArrayViewModel(increasingIntArray,
                    new HeapCreator(increasingIntArray),
                    (n) => 0,
                    (n) => (n * n - n) / 2);
            _decreasingHeapIntArrayViewModel = new IntArrayViewModel(decreasingIntArray,
                new HeapCreator(decreasingIntArray),
                (n) => 3 * (n * n - n) / 2,
                (n) => (n * n - n) / 2);

            _randomQuickIntArrayViewModel = new IntArrayViewModel(randomIntArray,
               new QuickSortFirst(randomIntArray),
               (n) => 3 * (n * n - n) / 2,
               (n) => (n * n - n) / 2);
            _increasingQuickIntArrayViewModel =
                new IntArrayViewModel(increasingIntArray,
                    new QuickSortFirst(increasingIntArray),
                    (n) => 0,
                    (n) => (n * n - n) / 2);
            _decreasingQuickIntArrayViewModel = new IntArrayViewModel(decreasingIntArray,
                new QuickSortFirst(decreasingIntArray),
                (n) => 3 * (n * n - n) / 2,
                (n) => (n * n - n) / 2);

            _tableDigitalSort = new DigitalSortTableRow[]
            {
                new DigitalSortTableRow(),
                new DigitalSortTableRow(100),
                new DigitalSortTableRow(200),
                new DigitalSortTableRow(300),
                new DigitalSortTableRow(400),
                new DigitalSortTableRow(500),
            };
            _tableDigitalSort2 = new DigitalSortTableRow[]
            {
                new DigitalSortTableRow(),
                new DigitalSortTableRow(100),
                new DigitalSortTableRow(200),
                new DigitalSortTableRow(300),
                new DigitalSortTableRow(400),
                new DigitalSortTableRow(500),
            };


            _tableHeapSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(200, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(300, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(400, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(500, (array) => new HeapCreator(array)),
            };
            _tableQuickSortFirst = new SortedArrayTableRow[]
           {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new  QuickSortFirst(array)),
                new SortedArrayTableRow(200, (array) => new  QuickSortFirst(array)),
                new SortedArrayTableRow(300, (array) => new  QuickSortFirst(array)),
                new SortedArrayTableRow(400, (array) => new  QuickSortFirst(array)),
                new SortedArrayTableRow(500, (array) => new  QuickSortFirst(array)),
           };
            _tableQuickSortSecond = new SortedArrayTableRow[]
           {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new  QuickSortSecond(array)),
                new SortedArrayTableRow(200, (array) => new  QuickSortSecond(array)),
                new SortedArrayTableRow(300, (array) => new  QuickSortSecond(array)),
                new SortedArrayTableRow(400, (array) => new  QuickSortSecond(array)),
                new SortedArrayTableRow(500, (array) => new  QuickSortSecond(array)),
           };
            _tableMergeSort = new SortedListTableRow[]
           {
            new SortedListTableRow(),
            new SortedListTableRow(100),
            new SortedListTableRow(200),
            new SortedListTableRow(300),
            new SortedListTableRow(400),
            new SortedListTableRow(500),
           };


            SeriesDigitSort = new ISeries[]
            {

                new LineSeries<SortedArrayTableRow>
                {
                    Values = _tableHeapSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "HeapSort",
                },
                new LineSeries<SortedArrayTableRow>
                {
                    Values = _tableQuickSortFirst,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "QuickSort",
                },
                 new LineSeries<SortedListTableRow>
                {
                    Values = _tableMergeSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "MergeSort",
                },
                new LineSeries<DigitalSortTableRow>
                {
                    Values = _tableDigitalSort,
                    Mapping = (row, index) => new(row.N, row.RandomCMInt > 0 ? Math.Log10(row.RandomCMInt) : 0),
                    Fill = null,
                    Name = "DigitalSort",
                }

            };


            CreateVisuals();
        }


        public string RandomHeapArrayInfo => _randomHeapIntArrayViewModel.ToString();
        public string IncreasingHeapArrayInfo => _increasingHeapIntArrayViewModel.ToString();
        public string DecreasingHeapArrayInfo => _decreasingHeapIntArrayViewModel.ToString();

        public string DigitSortIntInfo => _DigitSortViewModel.ToString();
        public string DigitSortShortInfo => _DigitSortViewModelShort.ToString();
        public string DigitSortIntInfoSurname => _DigitSortViewModelSurname.ToString();

        public string RandomQuickArrayInfo => _randomQuickIntArrayViewModel.ToString();
        public string IncreasingQuickArrayInfo => _increasingQuickIntArrayViewModel.ToString();
        public string DecreasingQuickArrayInfo => _decreasingQuickIntArrayViewModel.ToString();

        public SortedArrayTableRow[] TableHeapSort =>
            _tableHeapSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableQuickSortSecond =>
            _tableQuickSortSecond.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableQuickSortFirst =>
            _tableQuickSortFirst.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public DigitalSortTableRow[] TableDigitalSort =>
            _tableDigitalSort.SkipWhile((item) => item.TheorMCInt == 0).ToArray();
        public DigitalSortTableRow[] TableDigitalSort2 =>
            _tableDigitalSort.SkipWhile((item) => item.TheorMCInt == 0).ToArray();
        public SortedListTableRow[] TableMergeSort =>
    _tableMergeSort.SkipWhile((item => item.TheorMC == 0)).ToArray();

        public ISeries[] SeriesDigitSort { get; set; }

        public Axis[] XAxes => new[]
        {
            new Axis
            {
                Name = "Количество элементов N",
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
                MaxLimit = 550,
                ForceStepToMin = true,
                MinStep = 50
            }
        };
        public Axis[] YAxes => new[]
        {
            new Axis
            {
                Name = "Трудоёмкость 10^n",
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
                MaxLimit = 5.9
            }
        };

        public IEnumerable<ChartElement<SkiaSharpDrawingContext>> VisualElements { get; set; }

        private void CreateVisuals()
        {
            var visuals = new List<ChartElement<SkiaSharpDrawingContext>>
            {
                new GeometryVisual<RectangleGeometry>
                {
                    X = 0.1,
                    Y = 10,
                    LocationUnit = MeasureUnit.ChartValues,
                    Width = 0.02,
                    Height = 10,
                    SizeUnit = MeasureUnit.ChartValues,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10 },
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10, StrokeThickness = 3f },
                },
                new GeometryVisual<RectangleGeometry>
                {
                    X = 0.1,
                    Y = 6.15,
                    LocationUnit = MeasureUnit.ChartValues,
                    Width = 0.02,
                    Height = 0.5,
                    SizeUnit = MeasureUnit.ChartValues,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10 },
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10, StrokeThickness = 3f },
                    Rotation = -30
                },
                new GeometryVisual<RectangleGeometry>
                {
                    X = 0.1,
                    Y = 6.15,
                    LocationUnit = MeasureUnit.ChartValues,
                    Width = 0.02,
                    Height = 0.5,
                    SizeUnit = MeasureUnit.ChartValues,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10 },
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10, StrokeThickness = 3f },
                    Rotation = 30
                },
                new GeometryVisual<RectangleGeometry>
                {
                    X = 0,
                    Y = 0.01,
                    LocationUnit = MeasureUnit.ChartValues,
                    Width = 1000,
                    Height = 0.01,
                    SizeUnit = MeasureUnit.ChartValues,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10 },
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10, StrokeThickness = 1.5f },
                },
                new GeometryVisual<RectangleGeometry>
                {
                    X = 535,
                    Y = 0.01,
                    LocationUnit = MeasureUnit.ChartValues,
                    Width = 30,
                    Height = 0.01,
                    SizeUnit = MeasureUnit.ChartValues,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10 },
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10, StrokeThickness = 1.5f },
                    Rotation = 30
                },
                new GeometryVisual<RectangleGeometry>
                {
                    X = 535,
                    Y = 0.01,
                    LocationUnit = MeasureUnit.ChartValues,
                    Width = 30,
                    Height = 0.01,
                    SizeUnit = MeasureUnit.ChartValues,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10 },
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { ZIndex = 10, StrokeThickness = 1.5f },
                    Rotation = -30
                }
            };



            VisualElements = visuals;
        }



        private IntArrayViewModel _randomHeapIntArrayViewModel;
        private IntArrayViewModel _increasingHeapIntArrayViewModel;
        private IntArrayViewModel _decreasingHeapIntArrayViewModel;

        private DigitSortViewModel _DigitSortViewModel;
        private DigitSortViewModelShort _DigitSortViewModelShort;
        private DigitSortViewModelSurname _DigitSortViewModelSurname;

        private IntArrayViewModel _randomQuickIntArrayViewModel;
        private IntArrayViewModel _increasingQuickIntArrayViewModel;
        private IntArrayViewModel _decreasingQuickIntArrayViewModel;

        private SortedArrayTableRow[] _tableHeapSort;
        private SortedArrayTableRow[] _tableQuickSortFirst;
        private SortedArrayTableRow[] _tableQuickSortSecond;
        private SortedListTableRow[] _tableMergeSort;
        private DigitalSortTableRow[] _tableDigitalSort;
        private DigitalSortTableRow[] _tableDigitalSort2;
    }
}
