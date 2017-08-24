using Newtonsoft.Json;

namespace Cliente.Models.Entities
{
    public class Categoria
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "caminho_imagem")]
        public string UrlImagem { get; set; }

        [JsonProperty(PropertyName = "quantidade_empresa")]
        public int QuantidadeEmpresas { get; set; }

        [JsonProperty(PropertyName = "categoriapai_id")]
        public int? CategoriaPaiId { get; set; }
    }
}
