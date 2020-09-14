using quickify_persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace quickify_service.Auth
{
	public class AuthService
	{
		
		public bool getAccess(AuthUser authUser)
		{
			if (authUser.email != string.Empty && authUser.password != string.Empty)
			{
				bool access = false;
				using (var client = new HttpClient())
				{
					string userRole = authUser.password + ";" + authUser.email;
					client.BaseAddress = new Uri("https://localhost:44328/api/");
					var responseTask = client.GetAsync("Auth/getAccess/" + userRole);
					responseTask.Wait();

					var result = responseTask.Result;
					if (result.IsSuccessStatusCode)
					{
						var readJob = result.Content.ReadAsStringAsync();
						readJob.Wait();
						access = bool.Parse(readJob.Result);
					}
				}
				return access;
			}
			else if (authUser.email == string.Empty)
			{
				return false;

			}
			else if (authUser.password == string.Empty)
			{
				return false;
			}
			return false;
		}

		public bool getUserExists(Users authUser)
		{
			if (authUser.email != string.Empty && authUser.name != string.Empty)
			{
				bool access = false;
				using (var client = new HttpClient())
				{
					string userRole = authUser.name + ";" + authUser.email;
					client.BaseAddress = new Uri("https://localhost:44328/api/");
					var responseTask = client.GetAsync("Auth/getUserExists/" + userRole);
					responseTask.Wait();

					var result = responseTask.Result;
					if (result.IsSuccessStatusCode)
					{
						var readJob = result.Content.ReadAsStringAsync();
						readJob.Wait();
						access = bool.Parse(readJob.Result);
					}
				}
				return access;
			}
			else if (authUser.email == string.Empty)
			{
				return false;

			}
			else if (authUser.name == string.Empty)
			{
				return false;

			}

			return false;
		}
		public string getNameUser(AuthUser authUser)
		{
			string nameUser = string.Empty;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44328/api/");
				var responseTask = client.GetAsync("Auth/getNameUser/" + authUser.email);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readJob = result.Content.ReadAsStringAsync();
					readJob.Wait();
					nameUser = readJob.Result;
				}
			}
			return nameUser;
		}

		public void signUp(Users user)
		{
			
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44328/api/");
				var responseTask = client.PostAsJsonAsync("Auth/signUp", user);
				responseTask.Wait();
			}
		}

	}

}
