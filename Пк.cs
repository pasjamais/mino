using System;
using System.Collections.Generic;

namespace mino
{
    public partial class Пк
    {
        public string? ИмяПк { get; set; }
        public string? Ip { get; set; }
        public string? Пользователь { get; set; }
        public string? МодельЦп { get; set; }
        public long? ЧастотаЦп { get; set; }
        public byte[]? РейтингЦп { get; set; }
        public long? ОзуГб { get; set; }
        public string? ТипОзу { get; set; }
        public long? СлотовОзуВсего { get; set; }
        public long? СлотовОзуИспольз { get; set; }
        public string? Ибп { get; set; }
        public byte[]? Ноутбук { get; set; }
        public string? Ос { get; set; }
        public string? ОфисныйПакет { get; set; }
        public string? Антивирус { get; set; }
        public string? СпециальныйСофт { get; set; }
        public string? Инвентарный { get; set; }
        public byte[]? ПоследнееОбновлениеСведений { get; set; }
        public byte[]? ПоследнееСервиснОбслуживания { get; set; }
        public string? Примечание { get; set; }
    }
}
