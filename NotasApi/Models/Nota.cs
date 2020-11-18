using System;
using System.Collections.Generic;

#nullable disable

namespace NotasApi.Models
{
    public partial class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Detalle { get; set; }
    }
}
