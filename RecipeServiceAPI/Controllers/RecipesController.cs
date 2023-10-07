using Microsoft.AspNetCore.Mvc;
using RecipeService.Models;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Cors;

namespace GetRecipeService.Controllers;



[ApiController]
[Route("[controller]")]

public class RecipesController : ControllerBase
{

    private readonly DbConnection dbConnection = new DbConnection();
    private readonly ILogger<RecipesController> _logger;

    public RecipesController(ILogger<RecipesController> logger, IConfiguration configuration)
    {
        _logger = logger;
    }

    [EnableCors]
    [HttpGet]
    public List<RecipeDTO> GetRecipes()
    {
        Console.WriteLine("Get Recipes");
        var SQL = "SELECT * FROM public.recipes";
        List<RecipeDTO> returnList = new();

        using (var connection = new NpgsqlConnection(dbConnection.connectionString))
        {
            returnList = connection.Query<RecipeDTO>(SQL).ToList();

        }
        return returnList;

    }

    [EnableCors]
    [HttpGet("{name}")]
    public RecipeDTO GetRecipeByName(string name)
    {
        Console.WriteLine("Get Recipe by name");
        var SQL = $"SELECT * FROM public.recipes WHERE LOWER(name)=LOWER('{name}')";
        RecipeDTO returnRecipeDTO = new(-1, "NULL-VALUE-ERROR", -1, -1, new List<int>(), new List<int>());

        using (var connection = new NpgsqlConnection(dbConnection.connectionString))
        {
            returnRecipeDTO = connection.Query<RecipeDTO>(SQL).First();

        }
        return returnRecipeDTO;

    }
    
    [EnableCors]
    [HttpPost()]
    public RecipeDTO PostRecipe(string name, int servingSize, int imageId)
    {


        Console.WriteLine("Post Recipe");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("ServingSize: " + servingSize);
        Console.WriteLine("ImageId: " + imageId);

        var sql = $"INSERT INTO public.recipes" +
            $"(name, servingSize, imageId)" +
            $"VALUES ('{name}', '{servingSize}', '{imageId}')";


        Console.WriteLine("sql: " + sql);

        using (var connection = new NpgsqlConnection(dbConnection.connectionString))
        {
            try
            {
                connection.Execute(sql);
                //NEED TO CALL GetRecipeTags and GetInstructionSteps TO COMPLETE RECIPE
                //NEED TO CALL GetRecipeTags and GetInstructionSteps TO COMPLETE RECIPE
                //NEED TO CALL GetRecipeTags and GetInstructionSteps TO COMPLETE RECIPE
                //NEED TO CALL GetRecipeTags and GetInstructionSteps TO COMPLETE RECIPE
                //NEED TO CALL GetRecipeTags and GetInstructionSteps TO COMPLETE RECIPE
                return new RecipeDTO(GetRecipeByName(name).Id, name, servingSize, imageId, new List<int>(), new List<int>());
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the Recipe to the list: " + e.Message);
                throw new InvalidDataException();

            }
        }
    }
}


