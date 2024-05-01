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
using static System.Net.Mime.MediaTypeNames;

namespace VisualPartSAOD.ViewModel.Lab2
{
    public class PhonebookInfo
    {
        public PhonebookInfo()
        {
            Phonebook A = new Phonebook("Демчева", "Валентина", "Александровна", 89617262130,"Кирова 45", "Кировский");
            Phonebook B = new Phonebook("Зозулина", "Диана", "Игоревна", 79031036005,"Советская 67","Центральный");
            Phonebook C = new Phonebook("Кривенышев", "Артëм", "Валерьевич", 89141261106,"Свердловская 9","Ленинский");
            Phonebook D = new Phonebook("Кривенышев", "Евгений", "Сергеевич", 89293458685,"Пропарская 90","Ленинский");
            Phonebook E = new Phonebook("Ляшев", "Артем", "Алексеевич", 89089581815,"Двуреченская 34","Пятый");
            Phonebook F = new Phonebook("Огнивенко", "Дмитрий", "Сергеевич", 89537742244,"Перезд 67","Область");
            Phonebook G = new Phonebook("Родионов", "Вячеслав", "Евгеньевич", 89236267605,"Усеченская 66","Центральный");
            Phonebook H = new Phonebook("Хмыльников", "Евгений", "Павлович", 89953385539,"Красина 50","Дзержинский");
            Phonebook I = new Phonebook("Карпова", "Яна", "Алексеевна", 89538958159,"Фрунзе 8","Дзержинский");
            Phonebook J = new Phonebook("Антропов", "Георгий", "Вячеславович", 79031036045,"Промышленная 30","Шестой");
            Phonebook K = new Phonebook("Щекотихин", "Арсений", "Максимович", 89139146947,"Юность 5","Октяборьский");
            Phonebook L = new Phonebook("Попов", "Владимир", "Владимирович", 89134640684,"25 лет октября 25","Дзержинский");
            Phonebook[] array = { A, B, C, D, E, F, G, H, I, J, K, L }; 
            _phonebookViewModel = new PhonebookViewModel(array);
            Phonebook2 A2 = new Phonebook2("Демчева", "Валентина", "Александровна", 89617262130, "Кирова 45", "Кировский");
            Phonebook2 B2 = new Phonebook2("Зозулина", "Диана", "Игоревна", 79031036005, "Советская 67", "Центральный");
            Phonebook2 C2 = new Phonebook2("Кривенышев", "Артëм", "Валерьевич", 89141261106, "Свердловская 9", "Ленинский");
            Phonebook2 D2 = new Phonebook2("Кривенышев", "Евгений", "Сергеевич", 89293458685, "Пропарская 90", "Ленинский");
            Phonebook2 E2 = new Phonebook2("Ляшев", "Артем", "Алексеевич", 89089581815, "Двуреченская 34", "Пятый");
            Phonebook2 F2 = new Phonebook2("Огнивенко", "Дмитрий", "Сергеевич", 89537742244, "Перезд 67", "Область");
            Phonebook2 G2 = new Phonebook2("Родионов", "Вячеслав", "Евгеньевич", 89236267605, "Усеченская 66", "Центральный");
            Phonebook2 H2 = new Phonebook2("Хмыльников", "Евгений", "Павлович", 89953385539, "Красина 50", "Дзержинский");
            Phonebook2 I2 = new Phonebook2("Карпова", "Яна", "Алексеевна", 89538958159, "Фрунзе 8", "Дзержинский");
            Phonebook2 J2 = new Phonebook2("Антропов", "Георгий", "Вячеславович", 79031036045, "Промышленная 30", "Шестой");
            Phonebook2 K2 = new Phonebook2("Щекотихин", "Арсений", "Максимович", 89139146947, "Юность 5", "Октяборьский");
            Phonebook2 L2 = new Phonebook2("Попов", "Владимир", "Владимирович", 89134640684, "25 лет октября 25", "Дзержинский");
            Phonebook2[] array2 = { A2, B2, C2, D2, E2, F2, G2, H2, I2, J2, K2, L2 };
            _phonebook2ViewModel = new PhonebookViewModel2(array2);
            _phonebook3ViewModel = new PhonebookViewModel3(array2);
            _phonebook4ViewModel = new PhonebookViewModel4(array);

            


        }
        public string PhonebookText => _phonebookViewModel.ToString();
        public string Phonebook2Text => _phonebook2ViewModel.ToString();
        public string Phonebook3Text => _phonebook3ViewModel.ToString();
        public string Phonebook4Text => _phonebook4ViewModel.ToString();

        private PhonebookViewModel _phonebookViewModel;
        private PhonebookViewModel3 _phonebook3ViewModel;
        private PhonebookViewModel2 _phonebook2ViewModel;
        private PhonebookViewModel4 _phonebook4ViewModel;
    }
}
