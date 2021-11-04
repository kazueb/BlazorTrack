using IR.FirstBlazorWasm.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Services.Impl
{
    public class ProjectService : IModelService<Project>
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Project>> GetModels()
        {
            _httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync("/api/project");
            // TODO have to check response codes in client api calls
            return JsonConvert.DeserializeObject<List<Project>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Project> SaveModel(string name, Project model)
        {
            _httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.PutAsJsonAsync<Project>($"/api/project/{name}", model);

            return JsonConvert.DeserializeObject<Project>(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteModel(string name)
        {
            await _httpClient.DeleteAsync($"/api/project/{name}");
        }
    }
}
