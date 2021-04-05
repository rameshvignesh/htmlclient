using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;


namespace DemoWebApi.Models
{
    public class DeptClient
    {
        string url = "http://localhost:50429/api/";
        public IEnumerable<Dept> ShowAllDept()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Dept/GetDept").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Dept>>().Result;
            return null;

        }
        public Dept Find(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Dept/GetDept/"+id).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Dept>().Result;
            return null;

        }
        public bool Add(Dept dept)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("Dept/PostDept", dept).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Edit(Dept dept)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync("Dept/PostDept"+dept.Id, dept).Result;
            return response.IsSuccessStatusCode;
        }
        public bool Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("Dept/PostDept"+id ).Result;
            return response.IsSuccessStatusCode;
        }
    }
}