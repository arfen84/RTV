using RTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RTV.Models
{
    public class Product
    {
        public string Nazwa { get; set; }

        public string Kategoria { get; set; }   //czy potrzebna?

        public double Cena { get; set; }

        public string Marka { get; set; }

        public string Opis { get; set; }

        public string Stan { get; set; }

        public bool Sprzedany { get; set; }

        //dla dysków

        //string typ            //ssd, hdd itp

    }

    public class Monitor : Product
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int MonitorId { get; set; }
        [Display(Name = "Rozdzielczość: ")]
        public string Rozdzielczosc { get; set; }
        [Display(Name = "Przekątna: ")]
        public int Przekatna { get; set; }
        [Display(Name = "Czas reakcji: ")]
        public int czas_reakcji { get; set; }
        [Display(Name = "Jasność: ")]
        public int Jasnosc { get; set; }
        public string Matryca { get; set; }    //plazmowy/LCD, LED
        
    }

    public class Laptop : Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LaptopId { get; set; }
        [Display(Name = "Pojemność dysku [GB]: ")]
        public int Pojemnosc { get; set; }
        [Display(Name = "Rozdzielczość: ")]
        public string Rozdzielczosc { get; set; }
        [Display(Name = "Przekątna Ekranu: ")]
        public int Przekatna { get; set; }
        [Display(Name = "Seria procesora: ")]
        public string SeriaProcesora { get; set; }
        [Display(Name = "Ilość rdzeni: ")]
        public int IloscRdzeni { get; set; }
        [Display(Name = "Pamięć RAM [GB]: ")]
        public int RAM { get; set; }
        [Display(Name = "Pamięć grafika [GB]: ")]
        public int PamiecGrafika { get; set; }
        public string System { get; set; }
        [Display(Name = "Złącza: ")]
        public string Zlacza { get; set; }     //np USB
    }

    public class Drukarka:Product
    {

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int DrukarkaId { get; set; }
        [Display(Name = "Typ drukarki: ")]
        public string Typ { get; set; } //atramentowa/laserowa/ploter
    }

    public class Grafika:Product
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int GrafikaId { get; set; }
        public string Chipset { get; set; }
        [Display(Name = "Producent Chipsetu: ")]
        public string ProducentChipsetu { get; set; }
        public int RAM { get; set; }
        [Display(Name = "Rodzaj RAMu: ")]
        public string RodzajRAM { get; set; }
        [Display(Name = "Szyna danych [bit]: ")]
        public int Szyna { get; set; }
        [Display(Name = "Typ złącza: ")]
        public string Zlacze { get; set; }
        [Display(Name = "Łączenie kart: ")]
        public string Laczenie { get; set; }
        [Display(Name = "Obsługiwane standardy: ")]
        public string Standard { get; set; }
        [Display(Name = "Wyjście video: ")]
        public string Wyjscie { get; set; }
    }

    public class Procesor : Product
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ProcesorId { get; set; }
        public string Linia { get; set; }
        public string Gniazdo { get; set; }
        public int Rdzenie { get; set; }
        [Display(Name = "Odblokowany mnożnik: ")]
        public bool Mnoznik { get; set; }
        [Display(Name = "Załączone chłodzenie: ")]
        public bool Chlodzenie { get; set; }
    }

    public class Plyta : Product
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int PlytaId { get; set; }
        public string Standard { get; set; }
        public string Gniazdo { get; set; }
        public string Chipset { get; set; }
        [Display(Name = "Panel tylni: ")]
        public string PanelTylni { get; set; }
        [Display(Name = "Typ gniazda pamięci: ")]
        public string GniazdoRAM { get; set; }
        [Display(Name = "Częstotliwość pamięci [MHz]: ")]
        public string CzestotliwoscRAM { get; set; }
    }

    public class RAM : Product
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int RAMId { get; set; }
        public string Typ { get; set; }
        [Display(Name = "Pojemność [GB]: ")]
        public int Pojemnosc { get; set; }
        [Display(Name = "Częstotliwość [MHz]: ")]
        public int Czestotliwosc { get; set; }
        [Display(Name = "Liczba modułów: ")]
        public int Moduly { get; set; }
        [Display(Name = "Opóźnienie [CL]: ")]
        public int Opoznienie { get; set; }
        [Display(Name = "Napięcie [V]: ")]
        public float Napiecie { get; set; }
        [Display(Name = "Chłodzenie: ")]
        public bool Chlodzenie { get; set; }
    }

    public class Zasilacz : Product
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ZasilaczId { get; set; }
        public string Standard { get; set; }
        [Display(Name = "Specyfika sprawności: ")]
        public string Sprawnosc { get; set; }
        [Display(Name = "Modularne okablowanie: ")]
        public string Modularne { get; set; }
        [Display(Name = "Typ chłodzenia: ")]
        public string Chlodzenie { get; set; }
        [Display(Name = "Średnica wentylatora: ")]
        public string Wentylator { get; set; }
        [Display(Name = "Układ PFC: ")]
        public string PFC { get; set; }
    }

    public class ProductViewModel
    {
        public List<Monitor> Monitory { get; set; }
        public List<Laptop> Laptopy { get; set; }
        public List<Drukarka> Drukarki { get; set; }
        public List<Grafika> Graficzne { get; set; }
        public List<Procesor> Procesory { get; set; }
        public List<Plyta> Plyty { get; set; }
        public List<RAM> Pamieci { get; set; }
        public List<Zasilacz> Zasilacze { get; set; }
    }

}

