using System.ComponentModel.DataAnnotations;

namespace WMS.Service.Dtos.Floor
{
    public class FloorForManipulationDto
    {
        [Required(ErrorMessage = "Floor name is a required field")]
        [MaxLength(64, ErrorMessage = "Maximum length for the Name is 64 characters")]
        public string Name { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Capacity is required and it can't be lower than 1")]
        public int Capacity { get; set; }
    }
}
