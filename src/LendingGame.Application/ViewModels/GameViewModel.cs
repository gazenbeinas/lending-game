using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LendingGame.Application.ViewModels
{
    public class GameViewModel
    {
        [DisplayName("Código")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome do jogo é obrigatório")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DisplayName("Está emprestado")]
        [JsonProperty("isBorrowed")]
        public bool IsBorrowed { get; set; }
    }
}