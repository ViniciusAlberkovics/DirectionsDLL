using Newtonsoft.Json;
using System.Collections.Generic;

namespace DirectionDLL.Models
{
    public class Polyline
    {
        public string Points { get; set; }
     
        [JsonIgnore]
        public IEnumerable<Position> Positions
        {
            get
            {
                return GooglePoints.Decode(this.Points);
            }
        }
    }
}
