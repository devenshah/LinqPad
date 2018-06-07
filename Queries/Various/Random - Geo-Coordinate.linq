<Query Kind="Program" />

void Main()
{
    
}

// Define other methods and classes here
public class Coordinate
{
    public double Latitude { set; get; }
    public double Longitude { set; get; }
}

private Coordinate[] Calculate(Coordinate location1, Coordinate location2, Coordinate location3,
        Coordinate location4)
{
    Coordinate[] allCoords = { location1, location2, location3, location4 };
    double minLat = allCoords.Min(x => x.Latitude);
    double minLon = allCoords.Min(x => x.Longitude);
    double maxLat = allCoords.Max(x => x.Latitude);
    double maxLon = allCoords.Max(x => x.Longitude);

    Random r = new Random();

    Coordinate[] result = new Coordinate[5];
    for (int i = 0; i < result.Length; i++)
    {
        Coordinate point = new Coordinate();
        do
        {
            point.Latitude = r.NextDouble() * (maxLat - minLat) + minLat;
            point.Longitude = r.NextDouble() * (maxLon - minLon) + minLon;
        } while (!IsPointInPolygon(point, allCoords));
        result[i] = point;
    }
    return result;
}

//took it from http://codereview.stackexchange.com/a/108903
//you can use your own one
private bool IsPointInPolygon(Coordinate point, Coordinate[] polygon)
{
    int polygonLength = polygon.Length, i = 0;
    bool inside = false;
    // x, y for tested point.
    double pointX = point.Longitude, pointY = point.Latitude;
    // start / end point for the current polygon segment.
    double startX, startY, endX, endY;
    Coordinate endPoint = polygon[polygonLength - 1];
    endX = endPoint.Longitude;
    endY = endPoint.Latitude;
    while (i < polygonLength)
    {
        startX = endX;
        startY = endY;
        endPoint = polygon[i++];
        endX = endPoint.Longitude;
        endY = endPoint.Latitude;
        
        inside ^= ((endY > pointY) ^ (startY > pointY)) /* ? pointY inside [startY;endY] segment ? */
                  && /* if so, test if it is under the segment */
                  (pointX - endX < (pointY - endY) * (startX - endX) / (startY - endY));
    }
    return inside;
}