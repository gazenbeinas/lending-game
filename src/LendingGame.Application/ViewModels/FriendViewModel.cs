using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LendingGame.Application.ViewModels
{
    public class FriendViewModel
    {
        [DisplayName("Código")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail é obrigatório")]
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [JsonProperty("hasPendingLoan")]
        public bool HasPendingLoan { get; set; }
    }
}