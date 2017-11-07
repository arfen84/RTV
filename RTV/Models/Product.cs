using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RTV.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Display(Name = "Nazwa: ")]
        public string ProductName { get; set; }

        [Display(Name = "Kategoria: ")]
        public string Category { get; set; }   //czy potrzebna?

        [Display(Name = "Cena: ")]
        public double Price { get; set; }

        [Display(Name = "Marka: ")]
        public string Mark { get; set; }

        [Display(Name = "Opis: ")]
        public string Description { get; set; }

        //dla monitora
        public string rozdzielczosc { get; set; }
        public int przekatna { get; set; }
        [Display(Name = "Czas reakcji: ")]
        public int czas_reakcji { get; set; }
        public int jasnosc { get; set; }
        [Display(Name = "Technologia podświetlenia: ")]
        public string technologiaPodswietlenia { get; set; }    //plazmowy/LCD, LED

        //dla drukarki
        public string typ { get; set; } //atramentowa/laserowa/ploter

        //dla laptopów
        public string stan { get; set; }
        public string seriaProcesora { get; set; }
        public int iloscRdzeni { get; set; }
        public int RAM { get; set; }
        public int pamiecGrafika { get; set; }
        public string system { get; set; }
        public string zlacza { get; set; }     //np USB
        public string komunikacja { get; set; }

        //dla dysków
        public int pojemnosc { get; set; }
            //string typ            //ssd, hdd itp

        //dla innych
    }
}