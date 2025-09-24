using System;
using System.Text.Json;
using System.ComponentModel;
using ModelContextProtocol.Server;

using MCPWebControllerApi.Services;

namespace MCPWebControllerApi.McpTool;

// [McpServerToolType]
// public static class BeverageToolsRest
// {
//     private static readonly BeverageService _bevService = new BeverageService();

//     [McpServerTool, Description("Get a list of beverages and return as JSON")]
//     public static string GetBeveragesJson()
//     {
//         var task = _bevService.GetBeveragesJson();
//         return task.GetAwaiter().GetResult();
//     }

//     [McpServerTool, Description("Get a beverage by the name and return as JSON")]
//     public static string GetBeverageJson([Description("The name of the beverage to get details of")] string name)
//     {
//         var task = _bevService.GetBeverageByName(name);
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }

//     [McpServerTool, Description("Get a beverage by the ID and return as JSON")]
//     public static string GetBeverageByIdJson([Description("The ID of the beverage to get details of")] int id)
//     {
//         var task = _bevService.GetBeverageById(id);
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }

//     [McpServerTool, Description("Get beverages by their country of origin and return as JSON")]
//     public static string GetBeveragesByOriginJson([Description("The origin to get details of beverages")] string origin)
//     {
//         var task = _bevService.GetBeveragesByOrigin(origin);
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }

//     [McpServerTool, Description("Get beverages by their main ingredient and return as JSON")]
//     public static string GetBeveragesByMainIngredientJson([Description("The main ingredient to get details of beverages")] string mainIngredient)
//     {
//         var task = _bevService.GetBeveragesByMainIngredient(mainIngredient);
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }

//     [McpServerTool, Description("Get beverages by their type and return as JSON")]
//     public static string GetBeveragesByTypeJson([Description("The type to get details of")] string type)
//     {
//         var task = _bevService.GetBeveragesByType(type);
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }

//     [McpServerTool, Description("Get the beverages that contain sugar")]
//     public static string GetBeveragesWithSugarJson()
//     {
//         var task = _bevService.GetBeveragesWithSugar();
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }

//     [McpServerTool, Description("Get the beverages with the most calories")]
//     public static string GetBeveragesWithTheMostCaloriesJson()
//     {
//         var task = _bevService.GetBeverageWithMostCalories();
//         return JsonSerializer.Serialize(task.GetAwaiter().GetResult());
//     }
// }
