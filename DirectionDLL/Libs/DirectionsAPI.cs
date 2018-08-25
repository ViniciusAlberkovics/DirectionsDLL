using DirectionDLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DirectionDLL.Libs
{
    public class DirectionsAPI
    {
		#region Properties
		private readonly string baseUrl = "https://maps.googleapis.com/maps/api/directions/json?origin=";

		private HttpClient _httpClient;

		private readonly string _key = "KEY_Google_Directions_API";
        #endregion

        /*Summary - Route Url Parameters
         * args[0] = Origin
         * args[1] = Destiny
         * args[2+] = Waypoints
         */

        public async Task<List<Position>> GenereteRoute(params object[] args)
        {
            try
            {                            
                var result = await GetRoute(args);
                var resultAll = new List<Position>();

                foreach (var route in result.Routes)
                {
                    var line = route.Polyline;
                    resultAll = line.Positions.Select(l => new Position(l.Latitude, l.Longitude)).ToList();
                }
                return resultAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<DirectionAnswer> GetRoute(params object[] args)
        {
            try
            {
                _httpClient = new HttpClient();
                StringBuilder url = new StringBuilder();
                StringBuilder waypoints = new StringBuilder();
                int cont = 2, finalization = args.Length - 1;
                
                while (args.Length != cont)
                {
                    if (cont != finalization)
                        waypoints.Append(args[cont] + "|");
                    else
                        waypoints.Append(args[cont]);

                    cont++;
                }

                if(args.Length == 2)
                    url.Append(baseUrl + args[0] + "&destination=" + args[1] + "&sensor=false&mode=driving");
                else
                    url.Append(baseUrl + args[0] + "&destination=" + args[1] + "&waypoints=" + waypoints + "&sensor=false&mode=driving");
                //url.Append("&key=" + _key);

                var request = new HttpRequestMessage(HttpMethod.Post, url.ToString());

                DirectionAnswer directionAnswer = new DirectionAnswer();
                request.Content = new StringContent(JsonConvert.SerializeObject(directionAnswer), Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                
                if (response != null)
                {
                    var result = JsonConvert.DeserializeObject<DirectionAnswer>(response.Content.ReadAsStringAsync().Result);
                    
                    return result;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}