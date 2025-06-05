using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWASMWebApplication.Shared.Model
{
    public class Token
    {
        public Token() { }
        public Token(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
            this.Created = DateTime.Now;
        }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string EncodeToBase64()
        {
            return Utils.ENCODE_TOKEN_TO_BASE_64(JsonSerializer.Serialize(this));
        }
        public static Token DECODE_FROM_BASE_64(String encodedData, int deltaTimeInSeconds)
        {
            Token token = JsonSerializer.Deserialize<Token>
            (Utils.DECODE_FROM_BASE_64(encodedData), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (token.Created.AddSeconds(-deltaTimeInSeconds) > DateTime.Now)
            {
                throw new TokenEarlyException();
            }
            if (token.Created.AddSeconds(deltaTimeInSeconds) < DateTime.Now)
            {
                throw new TokenDelayedException();
            }
            return token;
        }
    }
}
