using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scheduler.Contracts;

namespace Scheduler.ApiClient
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {

            var workItem = new WorkItem();
            workItem.Status = WorkItemStatus.Prepared;
            workItem.ExecutionType = WorkItemExecutionType.OneTime;
            workItem.StartTime = DateTime.Now;

            var json = JsonConvert.SerializeObject(workItem);
            await using (StreamWriter sw = new StreamWriter("WorkItem.json", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(json);
            }
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(@"https://localhost:5001/api/work", data);

            string result = response.Content.ReadAsStringAsync().Result;


            //var response = await client.GetAsync(@"https://localhost:5001/api/work/1");
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<WorkItem>(responseBody);

        }
    }
}
