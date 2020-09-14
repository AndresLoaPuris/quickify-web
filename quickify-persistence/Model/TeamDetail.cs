using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickify_persistence.Model
{
	public class TeamDetail
	{
		public TeamDetail(string nameProyect, Users[] users)
		{
			this.nameProyect = nameProyect;
			this.users = users;
		}
		public string nameProyect { get; set; }
		public Users[] users { get; set; }
	}
}
