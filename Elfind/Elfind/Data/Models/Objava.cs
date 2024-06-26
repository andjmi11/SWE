﻿using Elfind.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elfind.Data.Model
{
    public enum TipObjave
    {
        Obavestenje,
        Anketa
    }

    public class Objava
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TipObjave TipObjave { get; set; }
        public string Tekst { get; set; }

        public List<Opcija> Opcije { get; set; } = new List<Opcija>();

        public NastavnoOsoblje OdNastavnogOsoblja { get; set; }
       
        public Forum Forum { get; set; }
    }
}
