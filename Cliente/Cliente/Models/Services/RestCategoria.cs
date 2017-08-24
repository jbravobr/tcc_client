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
    public class RestCategoria
    {
        private string _linkComp = "";
        public async Task<List<Categoria>> GetCategories(int categoriaPai)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Settings.ApiSettings);
                    if (categoriaPai > 0)
                    {
                        _linkComp = "categoria/" + categoriaPai.ToString();
                    }
                    else
                    {
                        _linkComp = "categoria";
                    }
                    var result = await client.GetAsync(_linkComp);
                    if (!result.IsSuccessStatusCode) return null;

                    var resultContent = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Categoria>>(resultContent);
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
