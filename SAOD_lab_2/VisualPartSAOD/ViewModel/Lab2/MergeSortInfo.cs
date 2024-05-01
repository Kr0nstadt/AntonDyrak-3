using System;
using LiveChartsCore.Kernel;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SAOD_lab_2;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using DynamicDataStructure;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;

namespace VisualPartSAOD.ViewModel.Lab2;

public class MergeSortInfo
{
    public MergeSortInfo()
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

        //List
        MyList<int> randomList = new MyList<int>();
        FillList.FillingRand(randomList, (e, i) =>
        {
            if (e is MyList<int> list)
            {
                list.Add(i);
            }
        }, 64, 10, 20);

        MyList<int> sortRandomList = new MyList<int>(randomList);
        MyList<int>.MergeSort(ref sortRandomList);
        _randomIntListViewModel = new MergeIntListViewModel(randomList, sortRandomList,
            n => n, n => n);


        MyList<int> decreaseList = new MyList<int>();
        FillList.FillingIncDec(64, 0, decreaseList, (e, i) =>
        {
            if (e is MyList<int> list)
            {
                list.Add(i);
            }
        });

        MyList<int> sortDecreaseList = new MyList<int>(decreaseList);
        MyList<int>.MergeSort(ref sortDecreaseList);
        _decreasingIntListViewModel = new MergeIntListViewModel(decreaseList, sortDecreaseList,
            n => n, n => n);

        MyList<int> increaseList = new MyList<int>();
        FillList.FillingIncDec(0, 64, increaseList, (e, i) =>
        {
            if (e is MyList<int> list)
            {
                list.Add(i);
            }
        });

        MyList<int> sortIncreaseList = new MyList<int>(increaseList);
        MyList<int>.MergeSort(ref sortIncreaseList);
        _increasingListViewModel = new MergeIntListViewModel(increaseList, sortIncreaseList,
            n => n, n => n);


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
        


        SeriesMergeSort = new ISeries[]
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

    public string RandomQuickArrayInfo => _randomQuickIntArrayViewModel.ToString();
    public string IncreasingQuickArrayInfo => _increasingQuickIntArrayViewModel.ToString();
    public string DecreasingQuickArrayInfo => _decreasingQuickIntArrayViewModel.ToString();

    public string RandomIntListInfo => _randomIntListViewModel.ToString();
    public string IncreasingIntListInfo => _increasingListViewModel.ToString();
    public string DecreasingIntListInfo => _decreasingIntListViewModel.ToString();

    public SortedArrayTableRow[] TableHeapSort =>
        _tableHeapSort.SkipWhile((item) => item.TheorMC == 0).ToArray();
    public SortedArrayTableRow[] TableQuickSortSecond =>
        _tableQuickSortSecond.SkipWhile((item) => item.TheorMC == 0).ToArray();
    public SortedArrayTableRow[] TableQuickSortFirst =>
        _tableQuickSortFirst.SkipWhile((item) => item.TheorMC == 0).ToArray();

    public SortedListTableRow[] TableMergeSort =>
    _tableMergeSort.SkipWhile((item => item.TheorMC == 0)).ToArray();

    public ISeries[] SeriesMergeSort { get; set; }

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

    private IntArrayViewModel _randomQuickIntArrayViewModel;
    private IntArrayViewModel _increasingQuickIntArrayViewModel;
    private IntArrayViewModel _decreasingQuickIntArrayViewModel;

    private MergeIntListViewModel _randomIntListViewModel;
    private MergeIntListViewModel _increasingListViewModel;
    private MergeIntListViewModel _decreasingIntListViewModel;


    private SortedArrayTableRow[] _tableHeapSort;
    private SortedArrayTableRow[] _tableQuickSortFirst;
    private SortedArrayTableRow[] _tableQuickSortSecond;
    private SortedListTableRow[] _tableMergeSort;
}
