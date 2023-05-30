using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PriceChangeDTO
    {
        [Required(ErrorMessage = "At least one Item is required.")]
        [MinLength(1, ErrorMessage = "At least one Item is required.")]
        public string[] ItemCodes { get; set; } = null!;

        public List<ItemDTO> Items { get; set; }

        [Required]
        public string IncreaseDecrease { get; set; } = null!;

        [Required(ErrorMessage = "Price Type is required.")]
        public string PriceType { get; set; } = null!;

        [Required(ErrorMessage = "Price Update is required.")]
        public string PriceUpdate { get; set; } = null!;

        [Required(ErrorMessage = "Price Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "PriceAmount must be greater than 0.")]
        public decimal PriceAmount { get; set; }

        public PriceChangeDTO() { }
    }

}
