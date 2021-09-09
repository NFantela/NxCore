using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NxCore.API.Entities
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string RecipeName { get; set; }

        // owner id is received from the claims identity
        [Required]
        [MaxLength(50)]
        public string OwnerId { get; set; }
    }
}
