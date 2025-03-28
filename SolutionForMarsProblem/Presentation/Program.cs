using Application.Extensions;
using Application.Services.Abstract;
using Application.Services.Concrete;
using Application.Wrappers;
using Domain.Concrete;
using Microsoft.Extensions.DependencyInjection;

//bağımlılıkların enjekte edilmesi
var serviceProvider = new ServiceCollection()
            .AddSingleton<IRobotService, RobotService>()
            .BuildServiceProvider();

IRobotService robotService = serviceProvider.GetRequiredService<IRobotService>();

//input : size
string size = InputValidation.GetValidInput(
    "Yüzey boyutunu giriniz :  \nörneğin: 5 5",
    InputValidation.IsValidCoordinate,
    "Girilen yüzey boyutu geçersiz. {SAYI}{BOŞLUK}{SAYI} şeklinde olmalı."
);

//input : birinci robotun konumu
string location1 = InputValidation.GetValidInput(
    "Birinci robotun mevcut konumunu giriniz :  \nörneğin: 1 2 N",
    InputValidation.IsValidLocation,
    "Girilen mevcut konum bilgisi geçersiz. {SAYI}{BOŞLUK}{SAYI}{BOŞLUK}{BÜYÜK HARF} şeklinde olmalı."
);

//input : birinci robotun yönlendirmesi
string direction1 = InputValidation.GetValidInput(
    "Birinci robotun yönlendirmesini giriniz :  \nörneğin: LMLMLMLMM",
    InputValidation.IsValidCommand,
    "Girilen yönlendirme geçersiz. Yalnızca R, L ve M harfleri kullanılabilir."
);

//duruma göre mapping(AutoMapping) işlemleri yapılabilir. bu senaryoda böyle bir işlem yapmadım
Location robotLocation1 = new Location(location1);
Response<Location> result1 = robotService.Move(size, robotLocation1, direction1);

if (result1.Status)
{
    Console.WriteLine(result1.Value.x + " " + result1.Value.y + " " + result1.Value.currentWay + "\n\n");
}
else
{
    Console.WriteLine("Birinci robot şu sebepten dolayı hareket edemedi => " + result1.Message);
    Console.ReadLine();
}

//input : ikinici robotun konumu
string location2 = InputValidation.GetValidInput(
    "İkinci robotun mevcut konumunu giriniz :  \nörneğin: 3 3 E",
    InputValidation.IsValidLocation,
    "Girilen mevcut konum bilgisi geçersiz. {SAYI}{BOŞLUK}{SAYI}{BOŞLUK}{BÜYÜK HARF} şeklinde olmalı."
);

//input : İkinci robotun yönlendirmesi
string direction2 = InputValidation.GetValidInput(
    "İkinci robotun yönlendirmesini giriniz :  \nörneğin: MMRMMRMRRM",
    InputValidation.IsValidCommand,
    "Girilen yönlendirme geçersiz. Yalnızca R, L ve M harfleri kullanılabilir."
);


Location robotLocation2 = new Location(location2);

Response<Location> result2 = robotService.Move(size, robotLocation2, direction2);

if (result2.Status)
{
    Console.WriteLine(result2.Value.x + " " + result2.Value.y + " " + result2.Value.currentWay);
    Console.ReadLine();
}
else
{
    Console.WriteLine("İkinci robot şu sebepten dolayı hareket edemedi => " + result2.Message);
    Console.ReadLine();
}
