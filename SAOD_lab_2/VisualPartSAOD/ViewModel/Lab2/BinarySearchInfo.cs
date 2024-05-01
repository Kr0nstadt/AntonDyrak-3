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
    public class SummaryInfoBinarySearch
    {
        public SummaryInfoBinarySearch()
        {
            RandomIntArray randomIntArray = new RandomIntArray(100);


            _firstViewModelRand = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchFirstIntArray(new SelectSortIntArray(randomIntArray), 67));
            _firstViewModelFirst = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchFirstIntArray(new SelectSortIntArray(randomIntArray), new SelectSortIntArray(randomIntArray).first));
            _firstViewModelEnd = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchFirstIntArray(new SelectSortIntArray(randomIntArray), new SelectSortIntArray(randomIntArray).end));
            _firstViewModelNope = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchFirstIntArray(new SelectSortIntArray(randomIntArray), 9999));


            _secondViewModelRand = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchSecondIntArray(new SelectSortIntArray(randomIntArray), 67));
            _secondViewModelFirst = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchSecondIntArray(new SelectSortIntArray(randomIntArray), new SelectSortIntArray(randomIntArray).first));
            _secondViewModelEnd = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchSecondIntArray(new SelectSortIntArray(randomIntArray), new SelectSortIntArray(randomIntArray).end));
            _secondViewModelNope = new BinarySearchViewModel(new SelectSortIntArray(randomIntArray),
                new BinarySearchSecondIntArray(new SelectSortIntArray(randomIntArray), 9999));


            _tableBinarySearchFirst = new SearchArrayTableRow[]
            {
                new SearchArrayTableRow(),
                new SearchArrayTableRow(100, (array) => new BinarySearchFirstIntArray(array,10)),
                new SearchArrayTableRow(200, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(300, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(400, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(500, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(600, (array) => new BinarySearchFirstIntArray(array,10)),
                new SearchArrayTableRow(700, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(800, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(900, (array) => new BinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(1000, (array) => new BinarySearchFirstIntArray (array, 10)),
            };
            _tableBinarySearchSecond = new SearchArrayTableRow[]
            {
                new SearchArrayTableRow(),
                new SearchArrayTableRow(100, (array) => new BinarySearchSecondIntArray(array,10)),
                new SearchArrayTableRow(200, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(300, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(400, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(500, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(600, (array) => new BinarySearchSecondIntArray(array,10)),
                new SearchArrayTableRow(700, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(800, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(900, (array) => new BinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(1000, (array) => new BinarySearchSecondIntArray (array, 10)),
            };
            _tableBinarySearchFirstAll = new SearchArrayTableRow[]
            {
                new SearchArrayTableRow(),
                new SearchArrayTableRow(100, (array) => new ArrayBinarySearchFirstIntArray(array,10)),
                new SearchArrayTableRow(200, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(300, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(400, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(500, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(600, (array) => new ArrayBinarySearchFirstIntArray(array,10)),
                new SearchArrayTableRow(700, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(800, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(900, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
                new SearchArrayTableRow(1000, (array) => new ArrayBinarySearchFirstIntArray (array, 10)),
            };
            _tableBinarySearchSecondAll = new SearchArrayTableRow[]
            {
                new SearchArrayTableRow(),
                new SearchArrayTableRow(100, (array) => new ArrayBinarySearchSecondIntArray(array,10)),
                new SearchArrayTableRow(200, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(300, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(400, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(500, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(600, (array) => new ArrayBinarySearchSecondIntArray(array,10)),
                new SearchArrayTableRow(700, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(800, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(900, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
                new SearchArrayTableRow(1000, (array) => new ArrayBinarySearchSecondIntArray (array, 10)),
            };
            SeriesBinarySearch = new ISeries[]
             {
                new LineSeries<SearchArrayTableRow>
                {
                    Values = _tableBinarySearchSecondAll,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "Вторая версия",
                },
                new LineSeries<SearchArrayTableRow>
                {
                    Values = _tableBinarySearchFirstAll,
                    Mapping = (row, index) => new(row.N, row.RandomCM > 0 ? Math.Log10(row.RandomCM) : 0),
                    Fill = null,
                    Name = "Первая версия",
                }
             };


            CreateVisuals();
        }
        public ISeries[] SeriesBinarySearch { get; set; }
        public string BinarySearchFirstInfoRand => _firstViewModelRand.ToString();
        public string BinarySearchFirstInfoFirst => _firstViewModelFirst.ToString();
        public string BinarySearchFirstInfoEnd => _firstViewModelEnd.ToString();
        public string BinarySearchFirstInfoNope => _firstViewModelNope.ToString();
        public string BinarySearchSecondInfoRand => _secondViewModelRand.ToString();
        public string BinarySearchSecondInfoFirst => _secondViewModelFirst.ToString();
        public string BinarySearchSecondInfoEnd => _secondViewModelEnd.ToString();
        public string BinarySearchSecondInfoNope => _secondViewModelNope.ToString();

        public SearchArrayTableRow[] TableBinarySearchFirst =>
            _tableBinarySearchFirst.SkipWhile((item) => item.RandomCM == 0).ToArray();
        public SearchArrayTableRow[] TableBinarySearchSecond =>
            _tableBinarySearchSecond.SkipWhile((item) => item.RandomCM == 0).ToArray();
        public SearchArrayTableRow[] TableBinarySearchFirstAll =>
             _tableBinarySearchFirstAll.SkipWhile((item) => item.RandomCM == 0).ToArray();
        public SearchArrayTableRow[] TableBinarySearchSecondAll =>
            _tableBinarySearchSecondAll.SkipWhile((item) => item.RandomCM == 0).ToArray();



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
        private BinarySearchViewModel _firstViewModelRand;
        private BinarySearchViewModel _firstViewModelFirst;
        private BinarySearchViewModel _firstViewModelEnd;
        private BinarySearchViewModel _firstViewModelNope;
        private BinarySearchViewModel _secondViewModelRand;
        private BinarySearchViewModel _secondViewModelFirst;
        private BinarySearchViewModel _secondViewModelEnd;
        private BinarySearchViewModel _secondViewModelNope;

      
        private SearchArrayTableRow[] _tableBinarySearchSecond;
        private SearchArrayTableRow[] _tableBinarySearchFirst;
        private SearchArrayTableRow[] _tableBinarySearchSecondAll;
        private SearchArrayTableRow[] _tableBinarySearchFirstAll;
    }
}
