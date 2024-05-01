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
    public class SummaryInfoSuper
    {
        public SummaryInfoSuper()
        {
            RandomIntArray randomIntArray = new RandomIntArray(100);
            IncreasingIntArray increasingIntArray = new IncreasingIntArray(100);
            DecreasingIntArray decreasingIntArray = new DecreasingIntArray(100);

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

            _randomIntArrayViewModel = new ShellIntArrayViewModel(randomIntArray,
               new SuperShellSortIntArray(randomIntArray),
               (n) => 3 * (n * n - n) / 4,
               (n) => (n * n - n) / 2);

            _increasingIntArrayViewModel =
                new ShellIntArrayViewModel(increasingIntArray,
                    new SuperShellSortIntArray(increasingIntArray),
                    (n) => 0,
                    (n) => (n * n - n) / 2);

            _decreasingIntArrayViewModel = new ShellIntArrayViewModel(decreasingIntArray,
                new SuperShellSortIntArray(decreasingIntArray),
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

            _randomInsertIntArrayViewModel = new IntArrayViewModel(randomIntArray,
                new InsertSortIntArray(randomIntArray),
                (n) => ((n * n - n) / 2) + 2 * n - 2,
                (n) => (n * n - n) / 2);

            _increasingInsertIntArrayViewModel =
                new IntArrayViewModel(increasingIntArray,
                    new InsertSortIntArray(increasingIntArray),
                    (n) => 2 * (n - 1),
                    (n) => n - 1);

            _decreasingInsertIntArrayViewModel = new IntArrayViewModel(decreasingIntArray,
                new InsertSortIntArray(decreasingIntArray),
                (n) => ((n * n - n) / 2) + 2 * n - 2,
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
            _tableSelectSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new SelectSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new SelectSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new SelectSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new SelectSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new SelectSortIntArray(array)),
            };

            _tableShakerSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new ShakerSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new ShakerSortIntArray(array)),
            };

            _tableInsertSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new InsertSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new InsertSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new InsertSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new InsertSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new InsertSortIntArray(array)),
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
            _tableSuperShellSort = new SortedArrayTableRow[]
            {
                new SortedArrayTableRow(),
                new SortedArrayTableRow(100, (array) => new SuperShellSortIntArray(array)),
                new SortedArrayTableRow(200, (array) => new SuperShellSortIntArray(array)),
                new SortedArrayTableRow(300, (array) => new SuperShellSortIntArray(array)),
                new SortedArrayTableRow(400, (array) => new SuperShellSortIntArray(array)),
                new SortedArrayTableRow(500, (array) => new SuperShellSortIntArray(array)),
            };

            SeriesSuperShell = new ISeries[]
            {
                new LineSeries<SortedArrayTableRow>
                {
                    Values = _tableSuperShellSort,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "SuperShellSort",
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

        public string RandomShakerArrayInfo => _randomShakerIntArrayViewModel.ToString();
        public string IncreasingShakerArrayInfo => _increasingShakerIntArrayViewModel.ToString();
        public string DecreasingShakerArrayInfo => _decreasingShakerIntArrayViewModel.ToString();

        public string RandomSuperShakerArrayInfo => _randomShakerIntArrayViewModel.ToString();
        public string IncreasingSuperShakerArrayInfo => _increasingShakerIntArrayViewModel.ToString();
        public string DecreasingSuperShakerArrayInfo => _decreasingShakerIntArrayViewModel.ToString();

        public string RandomInsertArrayInfo => _randomInsertIntArrayViewModel.ToString();
        public string IncreasingInsertArrayInfo => _increasingInsertIntArrayViewModel.ToString();
        public string DecreasingInsertArrayInfo => _decreasingInsertIntArrayViewModel.ToString();

        public SortedArrayTableRow[] TableBubbleSort =>
            _tableBubbleSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableShakerSort =>
            _tableShakerSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableInsertSort =>
            _tableInsertSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableSelectSort =>
            _tableSelectSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableShellSort =>
            _tableShellSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
        public SortedArrayTableRow[] TableSuperShellSort =>
            _tableSuperShellSort.SkipWhile((item) => item.TheorMC == 0).ToArray();

        public ISeries[] SeriesLab5 { get; set; }
        public ISeries[] SeriesSuperShell { get; set; }

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
                Name = "Трудоёмкость 10^k",
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

        private IntArrayViewModel _randomShakerIntArrayViewModel;
        private IntArrayViewModel _increasingShakerIntArrayViewModel;
        private IntArrayViewModel _decreasingShakerIntArrayViewModel;

        private IntArrayViewModel _randomInsertIntArrayViewModel;
        private IntArrayViewModel _increasingInsertIntArrayViewModel;
        private IntArrayViewModel _decreasingInsertIntArrayViewModel;

        private SortedArrayTableRow[] _tableBubbleSort;
        private SortedArrayTableRow[] _tableShakerSort;
        private SortedArrayTableRow[] _tableInsertSort;
        private SortedArrayTableRow[] _tableSelectSort;
        private SortedArrayTableRow[] _tableShellSort;
        private SortedArrayTableRow[] _tableSuperShellSort;
    }
}
