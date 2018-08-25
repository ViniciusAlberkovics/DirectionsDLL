using System;
using System.Collections.Generic;
using System.Text;

namespace DirectionDLL.Models
{
    public struct Position
    {
		public Position(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		public double Latitude { get;	}
		public double Longitude { get;	}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}


		/* Summary:
		     Returns a Boolean value that indicates whether or not left represents exactly
		     the same latitude and longitude as right.
		
		 Parameters:
		   left:
		     A Xamarin.Forms.Maps.Position to compare.
		
		   right:
		     A Xamarin.Forms.Maps.Position to compare.
		
		 Returns:
		     true if left represents exactly the same latitude and longitude as right. Otherwise,
		     false.
		
		 Remarks:
		     To be added.*/
		public static bool operator ==(Position left, Position right)
		{
			bool x = left == right ? true : false;
			return x;
		}

		/* Summary:
		     Returns a Boolean value that indicates whether or not left and right represent
		     different latitudes or longitudes.
		
		 Parameters:
		   left:
		     A Xamarin.Forms.Maps.Position to compare.
		
		   right:
		     A Xamarin.Forms.Maps.Position to compare.
		
		 Returns:
		     true if left and right represent different latitudes or longitudes. Otherwise,
		     false.
		
		 Remarks:
		     To be added.*/
		public static bool operator !=(Position left, Position right)
		{
			bool x = left != right ? true : false;
			return x;
		}
	}
}
