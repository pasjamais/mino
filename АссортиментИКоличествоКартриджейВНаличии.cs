using System;
using System.Collections.Generic;

namespace mino
{
    public partial class АссортиментИКоличествоКартриджейВНаличии
    {
        public string? Картридж { get; set; }
        public byte[]? Заправленных { get; set; }
        public byte[]? Незаправленных { get; set; }
        public byte[]? Новых { get; set; }
    }
}
