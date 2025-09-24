using System;
using System.ComponentModel.DataAnnotations;

namespace MCPWebControllerApi.Models;

public class Beverage
{
    [Required]
    public int BeverageId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? MainIngredient { get; set; }
    public string? Origin { get; set; }
    public int CaloriesPerServing { get; set; }
}
