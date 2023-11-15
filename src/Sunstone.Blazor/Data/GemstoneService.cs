using Sunstone.Application;
using Sunstone.Domain;

namespace Sunstone.Blazor.Data
{
    public class GemstoneService
    {
        private readonly HttpClient _httpClient;
        private const string POST_URI = "gemstone";
        private const string GET_URI = "gemstones";

        public GemstoneService(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<IEnumerable<Gemstone>> GetGemstoneAsync()
            => await _httpClient.GetFromJsonAsync<IEnumerable<Gemstone>>(GET_URI);

        public async Task<bool> PostGemstoneAsync(Model model)
        {
            var response = await _httpClient.PostAsJsonAsync(POST_URI, new CreateInputModel { Name = model.Name, Colors = GetColorName(model.Color) });

            if (response.IsSuccessStatusCode is false)
                throw new Exception();

            return true;

        }

        #region Private Methods
        public Colors GetColorName(string color)
        {
            return color switch
            {
                "Red" => Colors.Red,
                "Black" => Colors.Black,
                "Bicolor" => Colors.BiColor,
                "Blue" => Colors.Blue,
                "Brown" => Colors.Brown,
                "Colourless" => Colors.Colourless,
                "Green" => Colors.Green,
                "Yellow" => Colors.Yellow,
                "Gray" => Colors.Gray,
                "Purple" => Colors.Purple,
                "White" => Colors.White,
                "Multicolor" => Colors.Multicolor,
                "Pink" => Colors.Pink,
                "Orange" => Colors.Orange,
                _ => Colors.All,
            };
        }

        #endregion

    }
}
