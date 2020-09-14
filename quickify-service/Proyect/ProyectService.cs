using Newtonsoft.Json;
using quickify_persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace quickify_service.Proyect
{
	public class ProyectService
	{
		public IEnumerable<Proyects> getProjectsByEmailFromTheUser(string emailUser)
		{
            IEnumerable<Proyects> proyects = null;

            if (emailUser != string.Empty)
			{
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44328/api/");
                    var responseTask = client.GetAsync("Proyect/getProjectsByEmailFromTheUser/" + emailUser);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readJob = result.Content.ReadAsAsync<IList<Proyects>>();
                        readJob.Wait();
                        proyects = readJob.Result;
                    }
                    else
                    {
                        proyects = Enumerable.Empty<Proyects>();
                    }
                }
                return proyects;
			}
			else
			{
                proyects = Enumerable.Empty<Proyects>();
                return proyects;
			}

		}

        public string getNameUSer(string emailUser)
        {
            string nameUser = string.Empty;

            if (emailUser != string.Empty)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44328/api/");
                    var responseTask = client.GetAsync("Proyect/getNameUSer/" + emailUser);
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
            else
            {
                return nameUser;
            }
        }

        public void addProyect(string nameProyect, Users[] users)
        {
            TeamDetail teamDetail = new TeamDetail(nameProyect, users);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44328/api/");
                var responseTask = client.PostAsJsonAsync("Proyect/addProyect", teamDetail);
                responseTask.Wait();
            }
        }

        public IEnumerable<Users> getUsers(string emailUser)
        {
            IEnumerable<Users> users = null;

            if (emailUser != string.Empty)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44328/api/");
                    var responseTask = client.GetAsync("Proyect/getUsers/" + emailUser);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readJob = result.Content.ReadAsAsync<IList<Users>>();
                        readJob.Wait();
                        users = readJob.Result;
                    }
                    else
                    {
                        users = Enumerable.Empty<Users>();
                    }
                }
                return users;
            }
            else
            {
                users = Enumerable.Empty<Users>();
                return users;
            }
        }

         public string getNameProyectById(int id)
        {
            string nameUser = string.Empty;

            if (id != 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44328/api/");
                    var responseTask = client.GetAsync("Proyect/getNameProyectById/" + id);
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
            else
            {
                return nameUser;
            }
        }

        public string getRoleUserByProyect(int id, string emailUser)
        {
            string nameUser = string.Empty;

            if (emailUser != string.Empty)
            {
                using (var client = new HttpClient())
                {
                    string userRole = id.ToString() + ";" + emailUser;
                    client.BaseAddress = new Uri("https://localhost:44328/api/");
                    var responseTask = client.GetAsync("Proyect/getRoleUserByProyect/" + userRole);
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
            else
            {
                return nameUser;
            }
        }
    }
}
