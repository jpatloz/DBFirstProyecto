using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class Futbolista
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
    }
}
