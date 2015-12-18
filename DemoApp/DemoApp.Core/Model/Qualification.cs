using System;
using System.Collections.Generic;

namespace DemoApp.Core
{
	public class Qualification
	{
		public Qualification ()
		{
		}

		public string id { get; set; }
		public string name { get; set; }
		//public string country { get; set; }
		public string link { get; set; }
		public List<Subject> subjects { get; set; }
	}
}

