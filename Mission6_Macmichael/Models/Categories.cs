using System.ComponentModel.DataAnnotations;

namespace Mission6_Macmichael.Models
{
    public class Categories //This is named plural because if it was named Category then the Category on line 9 would have to be renamed
    {
        [Key]
        public int CategoryId { get; set; }
        public required string Category { get; set; }
    }
}
