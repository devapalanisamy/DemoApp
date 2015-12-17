using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoApp.Core
{
	public interface IRestService
	{
		Task<List<Qualification>> RefreshDataAsync ();
	}
}

