using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Precio
    {
        public Guid PrecioId {get;set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioCita {get;set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioDescuento {get;set;}
        public Guid CitaId {get;set;}
        public Cita Cita {get;set;}
    }
}