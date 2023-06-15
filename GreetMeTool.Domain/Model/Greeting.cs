using System;
using System.ComponentModel.DataAnnotations;

namespace GreetMeTool.Domain.Model
{
	public class Greeting
	{
        /// <summary>
        /// The message class is used to hold(memory) various types of data
        /// </summary>

            public Int64 Id { get; set; }
            [StringLength(3)]
            [Required]
            public string CountryCode { get; set; }
            public string Title { get; set; }
            [Required]
            public string MessageText { get; set; }
            [Required]
            [DataType(DataType.DateTime)]
            public DateTimeOffset StartDate { get; set; }
            [DataType(DataType.DateTime)]
            public DateTimeOffset EndDate { get; set; }
            [Required]
            public string MessageType { get; set; }

    }
 }





