using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtcSample.Models
{
    public class Soliloquy
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(140)]
        public string Message { get; set; }
        
        public DateTime Created { get; set; }

        [NotMapped]
        public String CreatedUtc { 
            get
            {
                return $"{Created.ToString("s")}Z";
            }
        }
    }
}