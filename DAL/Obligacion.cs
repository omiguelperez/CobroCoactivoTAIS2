﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Obligacion
    {
        public int ObligacionId { get; set; }
        public float Cuantia { get; set; }
        public float Dueda { get; set; }
        public DateTime FechaPreinscripcion { get; set; }
        public string Estado { get; set; }
        public virtual List<Cobro> Cobros { get; set; }
        public virtual Expediente Expediente { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
    }
}
