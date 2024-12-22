using System.ComponentModel.DataAnnotations;

namespace ProductsMvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "שם המוצר הוא שדה חובה.")]
        [MinLength(2, ErrorMessage = "שם המוצר חייב להיות לפחות 2 תווים.")]
        public string Name { get; set; } 

        [MaxLength(500, ErrorMessage = "תיאור המוצר לא יכול להיות יותר מ-500 תווים.")]
        public string? Description { get; set; } 

        [Required(ErrorMessage = "מחיר המוצר הוא שדה חובה.")]
        [Range(0, double.MaxValue, ErrorMessage = "המחיר חייב להיות חיובי.")]
        public double Price { get; set; } 

        [Required(ErrorMessage = "כמות המוצר היא שדה חובה.")]
        [Range(0, int.MaxValue, ErrorMessage = "הכמות חייבת להיות לפחות 1.")]
        public int Quantity { get; set; } 

        public string? UserId {  get; set; }
    }
}
