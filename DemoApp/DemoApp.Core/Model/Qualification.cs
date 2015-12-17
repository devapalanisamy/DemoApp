using System;

namespace DemoApp.Core
{
	public class Qualification
	{
		public Qualification ()
		{
		}

		public string id { get; set; }
		public string name { get; set; }
		public string country { get; set; }
		public string link { get; set; }
		public Subject[] subjects { get; set; }
	}
}

