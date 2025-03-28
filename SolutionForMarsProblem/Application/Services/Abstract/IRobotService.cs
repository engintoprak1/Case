using Application.Wrappers;
using Domain.Concrete;

namespace Application.Services.Abstract;

public interface IRobotService
{
    Response<Location> Move(string size, Location location, string direction);
}
