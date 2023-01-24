using System;
using System.Collections.Generic;

namespace mino
{
    public partial class Журнал
    {
        public byte[]? Дата { get; set; }
        public string? Манипуляция { get; set; }
        public byte[]? Содержание { get; set; }
        public string? Сотрудник { get; set; }
    }
}
