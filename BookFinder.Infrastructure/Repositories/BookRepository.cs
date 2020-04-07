using BookFinder.Domain.Repositories;

namespace BookFinder.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private const string EndPoint = "/Hotel/Ammenities?";

        public BookRepository()
        {
        }

        //public async Task<List<Ammenities>> Ammenities(string sessionToken, string language, CancellationToken cancellationToken)
        //{
        //    var client = new RestClient(_configuration.Netactica.BaseUrl);

        //    var restRequest = new RestRequest(HotelAmmenitiesEndPoint, Method.GET, DataFormat.Json);

        //    restRequest.AddQueryParameter("SessionToken", sessionToken);
        //    restRequest.AddQueryParameter("Language", language);

        //    var result = await client.ExecuteAsync(restRequest, cancellationToken);

        //    if (result.IsSuccessful)
        //    {
        //        return JsonConvert.DeserializeObject<List<Ammenities>>(result.Content);
        //    }

        //    if (result.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        _logger.LogWarning($"{result.StatusCode} - {result.Content} - {result.ErrorMessage}");
        //        throw new Exception(JsonConvert.DeserializeObject<GenericError>(result.Content).Message);
        //    }

        //    _logger.LogError(
        //        $@"Error: {result.StatusCode} - {result.Content} - {result.ErrorMessage}.
        //           Request: {_configuration.Netactica.BaseUrl}/{HotelAmmenitiesEndPoint}");

        //    throw new Exception($"Netactica Error - HotelAmmenities: {result.Content}");
        //}
    }
}
