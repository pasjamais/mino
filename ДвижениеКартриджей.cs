using System;
using System.Collections.Generic;

namespace mino
{
    public partial class ДвижениеКартриджей
    {
        public byte[]? Дата { get; set; }
        public string? МодельКартриджа { get; set; }
        public byte[]? Количество { get; set; }
        public byte[]? Движение { get; set; }
        public string? Место { get; set; }
        public string? Примечание { get; set; }
    }
}
