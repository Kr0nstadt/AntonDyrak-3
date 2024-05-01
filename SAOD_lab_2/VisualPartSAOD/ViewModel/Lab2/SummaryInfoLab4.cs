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
    internal class SummaryInfoLab4
    {
        public SummaryInfoLab4()
        {
            RandomIntArray randomIntArray = new RandomIntArray(10);
            IncreasingIntArray increasingIntArray = new IncreasingIntArray(10);
            DecreasingIntArray decreasingIntArray = new DecreasingIntArray(10);

            _randomIntArrayViewModel = new IntArrayViewModel(randomIntArray,
                new BubbleSortIntArray(randomIntArray),
                (n) => 3 * (n * n - n) / 4,
                (n) => (n * n - n) / 2);

            _increasingIntArrayViewModel =
                new IntArrayViewModel(increasingIntArray,
                    new BubbleSortIntArray(increasingIntArray),
                    (n) => 0,
                    (n) => (n * n - n) / 2);

            _decreasingIntArrayViewModel = new IntArrayViewModel(decreasingIntArray,
                new BubbleSortIntArray(decreasingIntArray),
                (n) => 3 * (n * n - n) / 2,
                (n) => (n * n - n) / 2);

            _randomShakerIntArrayViewModel = new IntArrayViewModel(randomIntArray,
                new ShakerSortIntArray(randomIntArray),
                (n) => 3 * (n * n - n) / 4,
                (n) => (n * n - n) / 2);
            _increasingShakerIntArrayViewModel =
                new IntArrayViewModel(increasingIntArray,
                    new ShakerSortIntArray(increasingIntArray),
                    (n) => 0,
                    (n) => n - 1);
            _decreasingShakerIntArrayViewModel = new IntArrayViewModel(decreasingIntArray,
                new ShakerSortIntArray(decreasingIntArray),
                (n) => 3 * (n * n - n) / 2,
                (n) => (n * n - n) / 2);

            _tableBubbleSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new BubbleSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new BubbleSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new BubbleSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new BubbleSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new BubbleSortIntArray(array)),
            };

            _tableShakerSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new ShakerSortIntArray(array))
            };
            
            SeriesLab4 =
            [
                new LineSeries<SortedArrayTableRow>
                {
                    Values = _tableBubbleSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "BubbleSort"
                },

                new LineSeries<SortedArrayTableRow>
                {
                    Values = _tableShakerSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "ShakerSort",
                }
            ];

            CreateVisuals();
        }

        public string RandomArrayInfo => _randomIntArrayViewModel.ToString();
        public string IncreasingArrayInfo => _increasingIntArrayViewModel.ToString();
        public string DecreasingArrayInfo => _decreasingIntArrayViewModel.ToString();

        public string RandomShakerArrayInfo => _randomShakerIntArrayViewModel.ToString();
        public string IncreasingShakerArrayInfo => _increasingShakerIntArrayViewModel.ToString();
        public string DecreasingShakerArrayInfo => _decreasingShakerIntArrayViewModel.ToString();

        public SortedArrayTableRow[] TableBubbleSort => 
            _tableBubbleSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableShakerSort => 
            _tableShakerSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableSelectSort =>
            _tableSelectSort.SkipWhile((item) => item.TheorMC == 0).ToArray();


        public ISeries[] SeriesLab4 { get; set; }

        public Axis[] XAxes => new[]
        {
            new Axis
            {
                Name = "Количество элементов",
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
                Name = "Трудоёмкость",
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

        private IntArrayViewModel _randomIntArrayViewModel;
        private IntArrayViewModel _increasingIntArrayViewModel;
        private IntArrayViewModel _decreasingIntArrayViewModel;

        private IntArrayViewModel _randomShakerIntArrayViewModel;
        private IntArrayViewModel _increasingShakerIntArrayViewModel;
        private IntArrayViewModel _decreasingShakerIntArrayViewModel;

        private SortedArrayTableRow[] _tableBubbleSort;
        private SortedArrayTableRow[] _tableShakerSort;
        private SortedArrayTableRow[] _tableSelectSort;
    }
}
