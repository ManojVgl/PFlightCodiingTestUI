using System;
namespace PrivateFlightGreetMeTool.Models
{
	/// <summary>
	/// The message class is used to hold(memory) various types of data
	/// </summary>
	public class Message
	{
		public Message()
		{
		}
		public string CountryCode { get; set; }
		public string Title { get; set; }
		public string MessageText { get; set; }
		public DateTimeOffset StartDate { get; set; }
		public DateTimeOffset EndDate { get; set; }

	}
}

