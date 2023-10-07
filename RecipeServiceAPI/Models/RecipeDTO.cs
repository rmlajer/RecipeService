namespace RecipeService.Models;
using System.ComponentModel.DataAnnotations;
public record RecipeDTO
{

    public RecipeDTO()
    {

    }
    public RecipeDTO(string name, int servingSize, int imageId, List<int> tags, List<int> instructionStepIds)
    {
        //Constructor without ID
        this.Name = name;
        this.ServingSize = servingSize;
        this.ImageId = imageId;
        this.RecipeTagIds = tags;
        this.InstructionStepIds = instructionStepIds;

    }
    public RecipeDTO(int id, string name, int servingSize, int imageId, List<int> tags, List<int> instructionStepIds)
    {

        this.Id = id;
        this.Name = name;
        this.ServingSize = servingSize;
        this.ImageId = imageId;
        this.RecipeTagIds = tags;
        this.InstructionStepIds = instructionStepIds;

    }


    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int ServingSize { get; set; }
    [Required]
    public int ImageId { get; set; }
    [Required]
    public List<int>? RecipeTagIds { get; set; }
    [Required]
    public List<int>? InstructionStepIds { get; set; }
}