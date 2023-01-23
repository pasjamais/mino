﻿using System;
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
            public static readonly int Number_of_Query_Printers                         = 7;
            public static readonly int Number_of_Query_Where_Are_Printers_Now           = 10;
            public static readonly int Number_of_Query_Cartridges_Assortiment           = 14;
            public static readonly int Number_of_Query_Cartridges_for_Printer_Model     = 19;
            public static readonly int Number_of_Query_Cartridges_Rotation              = 20;
            public static readonly int Number_of_Query_Cartridges_by_User               = 24;
            public static readonly int Cartridges_Places                                = 25;
            public static readonly int Cartridge_Models_list                            = 26;
            public static readonly int Alliances                                        = 27;
            public static readonly int Number_of_Query_Change_Alliance                  = 28;
            public static readonly int Number_of_Query_Del_Alliance                     = 29;
            public static readonly int Number_of_Query_Users_and_PCs                    = 30;
            public static readonly int Number_of_Query_List_of_Printer_Models           = 31;  

        public static readonly string Del_Confirmation = "В самом деле удалить\n";

            public static readonly Dictionary<string, int> mouvement_cartridge_type = new Dictionary<string, int>
                    {
                        {"Поступил", 1 },
                        {"Выбыл",   -1 }
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
