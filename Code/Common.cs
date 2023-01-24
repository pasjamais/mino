using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace mino
{
  //  namespace mino.Code
        public static class Common
        {
            public static readonly String AlmostRussianStringFormat = "dd MMMM yyyy HH:mm:ss";
            
            // константы с номерами нужных запросов, хранящихся в БД
            public static readonly int Number_of_Query_Journal                          = 1;
        public static readonly int Number_of_Query_Users_Activity = 2;
        public static readonly int Number_of_Query_Popular_Services = 5;
        public static readonly int Number_of_Query_Scanners = 6;
        public static readonly int Number_of_Query_Printers                         = 7;
            public static readonly int Number_of_Query_Aventures_of_Printer             = 8;
            public static readonly int Number_of_Query_Where_is_Printer                 = 9;
            public static readonly int Number_of_Query_Where_Are_Printers_Now           = 10;
            public static readonly int Number_of_Query_Where_Are_Printers_of_Model      = 11;
            public static readonly int Number_of_Query_Full_Cartridges_for_PrinterModel = 12;
            public static readonly int Number_of_Query_Compatible_Cartridges_for_PrinterModel = 13;
            public static readonly int Number_of_Query_Cartridges_Assortiment           = 14;
            public static readonly int Number_of_Query_PCs                              = 34;
            public static readonly int Number_of_Query_Cartridges_for_Printer_Model     = 19;
            public static readonly int Number_of_Query_Cartridges_Rotation              = 20;
            public static readonly int Number_of_Query_Cartridges_by_User               = 24;
            public static readonly int Cartridges_Places                                = 25;
            public static readonly int Cartridge_Models_list                            = 26;
            public static readonly int Number_of_Query_Alliances                        = 27;
            public static readonly int Number_of_Query_Change_Alliance                  = 28;
            public static readonly int Number_of_Query_Del_Alliance                     = 29;
            public static readonly int Number_of_Query_Users_and_PCs                    = 30;
            public static readonly int Number_of_Query_List_of_Printer_Models           = 31;
            public static readonly int Number_of_Query_List_Printers_Mouvement          = 32;
            public static readonly int Number_of_Query_List_Printers_by_Cartridge_Model = 33; // WHERE tech_Models_of_Cartridge.Id = @Id;

        public static readonly List<long> List_Queries_for_Printers = new List<long>() {
                Number_of_Query_Printers,
                Number_of_Query_Where_Are_Printers_Now,
                Number_of_Query_List_Printers_Mouvement,
                //
                Number_of_Query_Aventures_of_Printer,
                Number_of_Query_Where_is_Printer,
                Number_of_Query_Where_Are_Printers_of_Model,
                Number_of_Query_Full_Cartridges_for_PrinterModel,
                Number_of_Query_Compatible_Cartridges_for_PrinterModel,
                Number_of_Query_Cartridges_for_Printer_Model,
                Number_of_Query_List_Printers_by_Cartridge_Model
            };
            public static readonly List<long> List_Queries_for_PrinterModels_With_Parametre = new List<long>() {
                Number_of_Query_Where_Are_Printers_of_Model,            // WHERE tech_Models_of_Printer.id = @ModelId 
                Number_of_Query_Full_Cartridges_for_PrinterModel,       // WHERE tech_Models_of_Printer.id = @PrinterId
                Number_of_Query_Compatible_Cartridges_for_PrinterModel, // WHERE tech_Models_of_Printer.id = @PrinterId
                Number_of_Query_Cartridges_for_Printer_Model            // WHERE tech_Models_of_Printer.Id = @PrinterId;
                };
        public static readonly List<long> List_Queries_for_Printers_With_Parametre = new List<long>() {
                Number_of_Query_Aventures_of_Printer,                   // WHERE PCs_Printers.printer = @PrinterId
                Number_of_Query_Where_is_Printer                       // FROM PCs_Printers WHERE printer = @PrinterId     
    };

        public static readonly List<long> List_Different_Reports = new List<long>() {
                Number_of_Query_Users_Activity,
                Number_of_Query_Popular_Services,
                Number_of_Query_Where_Are_Printers_Now,
                Number_of_Query_Scanners,
                Number_of_Query_Cartridges_Assortiment
              };



        public static readonly string Del_Confirmation = "В самом деле удалить\n";

            public static readonly Dictionary<string, int> mouvement_cartridge_type = new Dictionary<string, int>
                    {
                        {"Поступил", 1 },
                        {"Выбыл",   -1 }
                    };
        public static readonly Dictionary<int, string> Printer_Models_Type = new Dictionary<int, string>
                    {
                        {0, "Принтер"},
                        {1, "МФУ"  }
                    };
        public static readonly Dictionary<int, string> TB_Place_Text = new Dictionary <int, string>
                    {
                        { 1, "в..." },
                        {-1, "из..." }
                    };
        public static readonly Dictionary<int, string> Status_Texts = new Dictionary<int, string>
                    {
                        {0, "\nВсё нормально" },
                        {1, "\nФайл БД не обнаружен" },
                        {2, "\nБэкап БД..."},
                        {3, "\nЗагрузка пользователей..."},
                        {4, "\nЗагрузка журнала..."},
                        {5, "\nЗагрузка картриджей..."},
                        {6, "\nЗагрузка ПК..."},
                        {7, "\nЗагрузка кабинетов..."},
                        {8, "\nЗагрузка принтеров..."},
                        {9, "\nЗагрузка отчётов..."},
                        {10, "\nЗагрузка железа..."},
                        {11, "\nЗагрузка софта..."},
                        {12, "\nО программе ..."},
                        {19, "\nСущность уже есть!"},
                        {20, "\nФИО не может быть пустым!"},
                        {21, "\nСущность создана: "},
                        {22, "\nПК присвоен"},
                        {23, "\nПК откреплены"},
                        {24, "\nСущность удалена"},
                        {25, "\nСервисные обращения удалены"},
                        {26, "\nСущность изменена: "},
                        {27, "\nИмя сущности не может быть пустой"},
                        {28, "\nТеперь без кабинета: "},
                        {29, "\nКабинет удалён: "},
                        {30, "\nСписок — "},
                        {100, "\n"}
                    };
    }
}
