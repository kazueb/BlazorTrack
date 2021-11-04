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
    public class MemberService : IModelService<Member>
    {
        private readonly HttpClient _httpClient;

        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Member>> GetModels()
        {
            _httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync("/api/member");
            // TODO have to check response codes in client api calls
            return JsonConvert.DeserializeObject<List<Member>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Member> SaveModel(string email, Member member)
        {
            _httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.PutAsJsonAsync<Member>($"/api/member/{email}", member);
                
            return JsonConvert.DeserializeObject<Member>(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteModel(string email)
        {
            await _httpClient.DeleteAsync($"/api/member/{email}");
        }
    }
}
