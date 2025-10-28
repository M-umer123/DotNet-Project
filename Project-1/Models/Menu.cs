using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_1.Models;

public partial class Menu
{

    public int MenuId { get; set; }

    [Required(ErrorMessage = "Dish name is required!")]
    public string? ItemImg1 { get; set; }

    public string? ItemImg2 { get; set; }

    public string? ItemImg3 { get; set; }

    public string? ItemImg4 { get; set; }

    public string? ItemImg5 { get; set; }

    public string? ItemImg6 { get; set; }

    public string? ItemImg7 { get; set; }

    public string? ItemImg8 { get; set; }

    public string? ItemImg9 { get; set; }

    public string? ItemTitle1 { get; set; }

    public string? ItemTitle2 { get; set; }

    public string? ItemTitle3 { get; set; }

    public string? ItemTitle4 { get; set; }

    public string? ItemTitle5 { get; set; }

    public string? ItemTitle6 { get; set; }

    public string? ItemTitle7 { get; set; }

    public string? ItemTitle8 { get; set; }

    public string? ItemTitle9 { get; set; }

    public string? ItemDesc1 { get; set; }

    public string? ItemDesc2 { get; set; }

    public string? ItemDesc3 { get; set; }

    public string? ItemDesc4 { get; set; }

    public string? ItemDesc5 { get; set; }

    public string? ItemDesc6 { get; set; }

    public string? ItemDesc7 { get; set; }

    public string? ItemDesc8 { get; set; }

    public string? ItemDesc9 { get; set; }

    public int? Item1Price { get; set; }

    public int? Item2Price { get; set; }

    public int? Item3Price { get; set; }

    public int? Item4Price { get; set; }

    public int? Item5Price { get; set; }

    public int? Item6Price { get; set; }

    public int? Item7Price { get; set; }

    public int? Item8Price { get; set; }

    public int? Item9Price { get; set; }
}
