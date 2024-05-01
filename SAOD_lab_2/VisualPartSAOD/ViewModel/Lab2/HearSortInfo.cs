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

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HearSortInfo
    {
        public HearSortInfo()
        {
            RandomIntArray randomIntArray = new RandomIntArray(20);
            IncreasingIntArray increasingIntArray = new IncreasingIntArray(20);
            DecreasingIntArray decreasingIntArray = new DecreasingIntArray(20);

            _randomIntArrayViewModel = new ShellIntArrayViewModel(randomIntArray,
                new ShellSortIntArray(randomIntArray),
                (n) => 3 * (n * n - n) / 4,
                (n) => (n * n - n) / 2);

            _increasingIntArrayViewModel =
                new ShellIntArrayViewModel(increasingIntArray,
                    new ShellSortIntArray(increasingIntArray),
                    (n) => 0,
                    (n) => (n * n - n) / 2);

            _decreasingIntArrayViewModel = new ShellIntArrayViewModel(decreasingIntArray,
                new ShellSortIntArray(decreasingIntArray),
                (n) => 3 * (n * n - n) / 2,
                (n) => (n * n - n) / 2);

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


            _tableHeapSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(200, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(300, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(400, (array) => new HeapCreator(array)),
                new SortedArrayTableRow(500, (array) => new HeapCreator(array)),
            };

            _tableShellSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new ShellSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new ShellSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new ShellSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new ShellSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new ShellSortIntArray(array)),
            };
            

            SeriesLab5 = new ISeries[]
            {
                
                new LineSeries<SortedArrayTableRow>
                {
                    Values = _tableShellSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "ShellSort",
                }
            };
            SeriesHearSort = new ISeries[]
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
                    Values = _tableShellSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "ShellSort",
                }
            };


            CreateVisuals();
        }

        public string RandomArrayInfo => _randomIntArrayViewModel.ToString();
        public string IncreasingArrayInfo => _increasingIntArrayViewModel.ToString();
        public string DecreasingArrayInfo => _decreasingIntArrayViewModel.ToString();

        public string RandomHeapArrayInfo => _randomHeapIntArrayViewModel.ToString();
        public string IncreasingHeapArrayInfo => _increasingHeapIntArrayViewModel.ToString();
        public string DecreasingHeapArrayInfo => _decreasingHeapIntArrayViewModel.ToString();

        

        public SortedArrayTableRow[] TableHeapSort =>
            _tableHeapSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableShellSort =>
            _tableShellSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
       

        public ISeries[] SeriesLab5 { get; set; }
        public ISeries[] SeriesHearSort { get; set; }

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

        private ShellIntArrayViewModel _randomIntArrayViewModel;
        private ShellIntArrayViewModel _increasingIntArrayViewModel;
        private ShellIntArrayViewModel _decreasingIntArrayViewModel;

       
        private IntArrayViewModel _randomHeapIntArrayViewModel;
        private IntArrayViewModel _increasingHeapIntArrayViewModel;
        private IntArrayViewModel _decreasingHeapIntArrayViewModel;

       

        
        private SortedArrayTableRow[] _tableShellSort;
        private SortedArrayTableRow[] _tableHeapSort;
    
}
}
