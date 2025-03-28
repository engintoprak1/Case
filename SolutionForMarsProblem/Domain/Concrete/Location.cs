using Domain.Abstract;

namespace Domain.Concrete;

public sealed class Location : IDto
{
    public int x; // x koordinatı örn : 1
    public int y; // y koordinatı örn : 3
    public string currentWay; // robotun baktığı cephe örn : N

    public Location(string location)
    {
        x = int.Parse(location.Split(' ')[0]);
        y = int.Parse(location.Split(' ')[1]);
        currentWay = location.Split(' ')[2];
    }
}
