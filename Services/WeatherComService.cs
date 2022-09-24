using Abstractions;

namespace Services
{
    public class WeatherComService:IWeatherService
    {
        public decimal GetWeather(string place)
        {
            switch(place.ToLower())
            {
                case "ankara":
                    return 27m;
                case "izmir":
                    return 31m;
                case "bursa":
                    return 28m;
                case "istanbul":
                    return 32m;
                default:
                   return new Random().Next(10,20);
                    
            }
        }

        public decimal Temperature(string placeName)
        {
            return GetWeather(placeName); 
        }
    }
}