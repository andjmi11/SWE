﻿using System.ComponentModel.DataAnnotations;

namespace Elfind.Data.Model
{
    public class RasporedCasova
    {
        [Key]
        public int ID { get; set; }
        public List<Cas> SpisakCasova = new List<Cas>();
        //public List<Student> Studenti { get; set; }
        //public List<NastavnoOsoblje> NastavnoOsoblje { get; set; }
        public Smer ZaSmer { get; set; }
        public Administrator Administrator { get; set; }
    }
}
