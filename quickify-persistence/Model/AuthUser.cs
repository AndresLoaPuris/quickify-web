using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickify_persistence.Model
{
	public class AuthUser
	{
		public int Id { get; set; }

		//[Required(ErrorMessage = "Error : Ingresar Email")]
		public string email { get; set; }

		//[Required(ErrorMessage = "Error : Ingresar Password")]
		public string password { get; set; }
	}
}
