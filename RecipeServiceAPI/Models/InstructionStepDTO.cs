namespace RecipeService.Models;
using System.ComponentModel.DataAnnotations;
public record InstructionStepDTO
{

    public InstructionStepDTO()
    {

    }
    public InstructionStepDTO(int stepNumber, List<int> ingredients)
    {

        this.StepNumber = stepNumber;
        this.Ingredients = ingredients;

    }
    public InstructionStepDTO(int id, int stepNumber, List<int> ingredients)
    {

        this.Id = id;
        this.StepNumber = stepNumber;
        this.Ingredients = ingredients;

    }


    public int Id { get; set; }

    [Required]
    public int StepNumber { get; set; }
    [Required]
    //NEED TO CHANGE THIS TO ACTUAL INGREDIENTS
    public List<int>? Ingredients { get; set; }
}