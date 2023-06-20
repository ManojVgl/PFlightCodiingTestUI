using System;
using System.ComponentModel.DataAnnotations;

namespace GreetMeTool.Domain.Model
{
	public class Filter
	{
        [StringLength(3)]
        [Required]
        public string CountryCode { get; set; }
        [DataType(DataType.DateTime)]
        public DateTimeOffset DepartureDate { get; set; }
    }
}

