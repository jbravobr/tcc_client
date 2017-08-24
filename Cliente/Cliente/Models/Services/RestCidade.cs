using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Cliente.Helpers;
using Cliente.Models.Entities;
using Newtonsoft.Json;

namespace Cliente.Models.Services
{
    public class RestCidade
    {
        private readonly string _link = Settings.ApiSettings;
        public async Task<List<Cidade>> GetCities()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_link);

                    var result = await client.GetAsync("cidade");
                    if (!result.IsSuccessStatusCode) return null;

                    var resultContent = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Cidade>>(resultContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        
    }
}
