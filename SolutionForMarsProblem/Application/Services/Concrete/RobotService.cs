using Application.Extensions;
using Application.Services.Abstract;
using Application.Wrappers;
using Domain.Concrete;

namespace Application.Services.Concrete;

public class RobotService : IRobotService
{
    public Response<Location> Move(string size, Location location,string direction) //size => yüzeyin boyutu, location => robotun anlık konumu direction => LMLMLMLMM //MMRMMRMRRM
    {
        //parametreden gelecek olan yönlendirmedeki her elemana göre aksiyon alacağım
        //foreach ile her bir elemanı alıp switch case ile işlem yapacağım
        char[] directive = direction.ToCharArray();

        foreach (var item in directive)
        {
            switch (item)
            {
                case 'L':
                    Response leftResult = TurnLeft(location);

                    if (!leftResult.Status)
                    {
                        return new Response<Location>(location, false)
                        {
                            Message = leftResult.Message
                        };
                    }
                    break;

                case 'R':

                    Response rightResult = TurnRight(location);

                    if (!rightResult.Status)
                    {
                        return new Response<Location>(location,false)
                        {
                            Message = rightResult.Message
                        };
                    }
                    break;

                case 'M':

                    Response moveResult = MoveOneSquare(size, location);

                    if (!moveResult.Status)
                    {
                        return new Response<Location>(location,false)
                        {
                            Message = moveResult.Message
                        };
                    }

                    break;
                default:
                    break;
            }
        }

        return new Response<Location>(location,true);
    }

    private Response TurnLeft(Location location)
    {
        if (location == null)
        {
            //loglama işlemleri
            return new Response(false, "Location bilgisi boş olamaz.");
        }

        switch (location.currentWay)
        {
            case "N":  //north'a bakıyorsa sola döndüğünde west'e bakar
                location.currentWay = "W";
                break;
            case "W": // west'e bakıyorsa sola döndüğünde south'a bakar
                location.currentWay = "S";
                break;
            case "S": // south'a bakıyorsa sola döndüğünde east'e bakar
                location.currentWay = "E";
                break;
            case "E": // east'e bakıyorsa sola döndüğünde north'a bakar
                location.currentWay = "N";
                break;
            default:
                throw new Exception(message: "Yön belirtilmedi ya da belirtilen yön yanlış");
        }

        return new Response(true);
    }

    private Response TurnRight(Location location)
    {
        if (location == null)
        {
            //loglama işlemleri
            return new Response(false, "Location bilgisi boş olamaz.");
        }
        
        switch (location.currentWay)
        {
            case "N":  //north'a bakıyorsa sağa döndüğünde east'e bakar
                location.currentWay = "E";
                break;
            case "E": // east'e bakıyorsa sağa döndüğünde south'a bakar
                location.currentWay = "S";
                break;
            case "S": // south'a bakıyorsa sağa döndüğünde west'e bakar
                location.currentWay = "W";
                break;
            case "W": // west'a bakıyorsa sağa döndüğünde north'a bakar
                location.currentWay = "N";
                break;
            default:
                throw new Exception(message: "Yön belirtilmedi ya da belirtilen yön yanlış");
        }

        return new Response(true);
    }

    private Response MoveOneSquare(string size,Location location)
    {
        if (!InputValidation.IsValidCoordinate(size))
        {
            //loglama işlemleri
            return new Response(false, "Girilen yüzey boyutu geçersiz.{SAYI}{BOŞLUK}{SAYI} şeklinde olmalı.");
        }
            

        int x = int.Parse(size.Split(' ')[0]);

        int y = int.Parse(size.Split(' ')[1]);

        switch (location.currentWay)
        {
            case "N":  //north'a bakarken bir adım ileri giderse y koordinatı 1 artar
                location.y = location.y < y ? location.y + 1 : location.y;
                break;
            case "W": // west'e bakarken bir adım ileri giderse x koordinatı 1 azalır
                location.x = location.x > 0 ? location.x - 1 : 0;
                break;
            case "S": // south'a bakarken bir adım ileri giderse y koordinatı 1 azalır
                location.y = location.y > 0 ? location.y - 1 : 0;
                break;
            case "E": // east'e bakarken bir adım ileri giderse x koordinatı 1 artar
                location.x = location.x < x ? location.x + 1 : location.x;
                break;
            default:
                throw new Exception(message: "Yön belirtilmedi ya da belirtilen yön yanlış");
        }

        return new Response(true);
    }
}