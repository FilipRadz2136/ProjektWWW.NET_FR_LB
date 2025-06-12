using System;
using System.ComponentModel.DataAnnotations;

public class Komentarz
{
    public int Id { get; set; }

    [Required]
    public string Tresc { get; set; }

    public DateTime DataDodania { get; set; } = DateTime.Now;

    public string Uzytkownik { get; set; } 
    public string? NazwaPliku { get; set; }
}