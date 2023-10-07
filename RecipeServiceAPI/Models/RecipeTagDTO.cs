namespace RecipeService.Models;
using System.ComponentModel.DataAnnotations;
public record RecipeTagDTO
{

    public RecipeTagDTO()
    {

    }
    public RecipeTagDTO(int recipeId, int tagId)
    {

        this.RecipeId = recipeId;
        this.TagId = tagId;

    }
    public RecipeTagDTO(int id, int recipeId, int tagId)
    {

        this.Id = id;
        this.RecipeId = recipeId;
        this.TagId = tagId;

    }


    public int Id { get; set; }

    [Required]
    public int RecipeId { get; set; }
    [Required]
    public int TagId { get; set; }
}