// Menu
using System.Collections.Generic;
using System.Numerics;

//menu();

// Variables
Random ran = new Random();
int counter = 0;
var positionList = new List<string>() { "GK", "DF", "MF", "FW" };
var numOfPositionList = new List<int>() { 1, 4, 3, 3 };

var menuChoice = 0;
var playerDictionary = new Dictionary<string, (string Position, int Rating)>()
            {
                {"Luka Modric",  (Position: "MF", Rating: 88)},
                {"Marcelo Brozovic", (Position: "MF", Rating: 86)},
                {"Mateo Kovacic",  (Position: "MF", Rating: 84)},
                {"Ivan Perisic",  (Position: "MF", Rating: 84)},
                {"Andrej Kramaric",  (Position: "FW", Rating: 82)},
                {"Ivan Rakitic",  (Position: "MF", Rating: 82)},
                {"Josko Gvardiol",  (Position: "DF", Rating: 81)},
                {"Mario Pasalic",  (Position: "MF", Rating: 81)},
                {"Lovro Majer",  (Position: "MF", Rating: 80)},
                {"Dominik Livaković",  (Position: "GK", Rating: 80)},
                {"Ante Rebic",  (Position: "FW", Rating: 80)},
                {"Josip Brekalo", (Position: "MF", Rating: 79)},
                {"Borna Sosa", (Position: "DF", Rating: 78)},
                {"Nikola Vlasic", (Position: "MF", Rating: 78)},
                {"Duje Caleta Car", (Position: "DF", Rating: 78)},
                {"Dejan Lovren", (Position: "DF", Rating: 78)},
                {"Mislav Orsic", (Position: "MF", Rating: 77)},
                {"Marko Livaja", (Position: "FW", Rating: 77)},
                {"Domagoj Vida", (Position: "DF", Rating: 76)},
                {"Ante Budimir", (Position: "FW", Rating: 76)}
            };

var goalKeepers = new Dictionary<string, (string Position, int Rating)>()
{

};
var defenseDict = new Dictionary<string, (string Position, int Rating)>()
{

};
var midFieldDict = new Dictionary<string, (string Position, int Rating)>()
{

};

var forwardDict = new Dictionary<string, (string Position, int Rating)>()
{

};
var playingInGame = new Dictionary<string, (string Position, int Rating)>()
{

};
// The process
do
{
    menu();
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 0:
            menuChoice = 1;
            break;
        case 1:
            foreach (var rate in playerDictionary)
            {
                var rating = rate.Value.Rating;
                Console.WriteLine($"{rate.Key} Rating prije treninga: {rate.Value.Rating} Rating poslije treninga: {DoTraining(rate.Value.Rating)}");
                Console.WriteLine("------------------");
                rating = DoTraining(rate.Value.Rating); // Sprema novi rating
            }
            GoBack();
            break;
        case 2:
            // Nisam shvatila ovaj dio, probala sam ga rjesit na svakakve nacine (ostavila sa tu dictionarye i funkcije koje sam koristila) ali ne uspjeva, ostavljam prazno
            GoBack();
            break;
        case 3:
            Console.WriteLine("1 - Ispis onako kako su spremljeni");
            Console.WriteLine("2 - Ispis po rating uzlazno");
            Console.WriteLine("3 - Ispis po rating silazno");
            Console.WriteLine("4 - Ispis igraca po imenu i prezimenu"); // Ispis pozicije i ratinga isto
            Console.WriteLine("5 - Ispis igraca po ratingu"); // U nos ratinga, ispisuje igrac(a)
            Console.WriteLine("6 - Ispis igraca po poziciji");
            Console.WriteLine("7 - Ispis trenutnih prvih 11 igraca");
            Console.WriteLine("8 - Ispis strijelaca i koliko golova imaju");
            Console.WriteLine("9 - Ispis rezultat svih ekipa");
            Console.WriteLine("5 - Ispis tablice grupe"); // Mjesto na tablici, ime ekipe, broj bodova i gol razlika
            int statChoice = int.Parse(Console.ReadLine());
            switch (statChoice)
            {
                case 1: // Generalna lista
                    foreach (var player in playerDictionary)
                        Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                    GoBack();
                    break;

                case 2: // Sortiraj uzlazno <
                    var playersAscend = playerDictionary
                        .OrderBy(playersAscend => playersAscend.Value.Rating)
                        .ToDictionary(playersAscend => playersAscend.Key, playersAscend => playersAscend.Value);
                    foreach (var player in playersAscend)
                    {
                        Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                    }
                    GoBack();
                    break;

                case 3: // Sortiraj silazno >
                    var playersDescend = playerDictionary
                        .OrderByDescending(playersAscend => playersAscend.Value.Rating)
                        .ToDictionary(playersAscend => playersAscend.Key, playersAscend => playersAscend.Value);
                    foreach (var player in playersDescend)
                    {
                        Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                    }
                    GoBack();
                    break;

                case 4: // Trazi po imenu
                    Console.WriteLine("Upiši ime i prezime igraca (bez kvacica)");
                    string findPlayerByName = Console.ReadLine();
                    foreach (var player in playerDictionary)
                    {
                        if (findPlayerByName == player.Key)
                        {
                            Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                            counter++;
                        }
                    }
                    if (counter == 0)
                        Console.WriteLine("Na listi ne postoji igrac kojeg si unio");
                    GoBack();
                    break;

                case 5:
                    Console.WriteLine("Upiši rating");
                    int findPlayersByRating = int.Parse(Console.ReadLine());
                    foreach (var player in playerDictionary)
                    {
                        if (findPlayersByRating == player.Value.Rating)
                        {
                            Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                            counter++;
                        }
                    }
                    GoBack();
                    break;

                case 6:
                    Console.WriteLine("Upiši poziciju");
                    string findPlayersByPosition = Console.ReadLine();
                    foreach (var player in playerDictionary)
                    {
                        if (findPlayersByPosition == player.Value.Position)
                        {
                            Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                            counter++;
                        }
                    }
                    if (counter == 0)
                        Console.WriteLine("Na listi ne postoji igrac s ratingom kojeg si unio");
                    GoBack();
                    break;
                case 7: // trebam 2 imat za to
                    GoBack();
                    break;
                case 8: // trebam 2 imat za to
                    GoBack();
                    break;
                case 9: // trebam 2 imat za to
                    GoBack();
                    break;
                case 10: // trebam 2 imat za to
                    GoBack();
                    break;
                case 11: // trebam 2 imat za to
                    GoBack();
                    break;
            }
            break;
        case 4:
            Console.WriteLine("1 - Unos novog igraca");
            Console.WriteLine("2 - Brisanje igraca");
            Console.WriteLine("3 - Uredivanje igraca");
            var controlChoice = int.Parse(Console.ReadLine());
            switch (controlChoice)
            {
                case 1:
                    Console.WriteLine("Upisi ime i prezime igraca");
                    string nameKey = Console.ReadLine();
                    Console.WriteLine("Upisi poziciju igraca");
                    string positionValue = Console.ReadLine();
                    Console.WriteLine("Upisi rating igraca");
                    int ratingValue = int.Parse(Console.ReadLine());
                    playerDictionary.Add(nameKey, (positionValue, ratingValue));
                    Console.WriteLine("Uspjesan unos igraca");
                    GoBack();
                    break;
                case 2:
                    Console.WriteLine("1 - Brisanje igraca unosom imena i prezimena");
                    var delChoice = int.Parse(Console.ReadLine());
                    switch (delChoice)
                    {
                        case 1:
                            Console.WriteLine("Upiši ime i prezime igraca (bez kvacica)");
                            string findPlayerByName = Console.ReadLine();
                            foreach (var player in playerDictionary)
                            {
                                if (playerDictionary.ContainsKey(findPlayerByName))
                                {
                                    playerDictionary.Remove(findPlayerByName);
                                    Console.WriteLine("Igrac izbrisan");
                                }
                            }
                            if (counter == 0)
                                Console.WriteLine("Na listi ne postoji igrac kojeg si unio");
                            break;
                        default:
                            Console.WriteLine("Nepoznata radnja");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("1 - Uredi ime i prezime igraca");
                    Console.WriteLine("2 - Uredi poziciju igraca (GK, DF, MF ili FW");
                    Console.WriteLine("3 - Uredi rating igraca (1 - 100)");
                    var editChoice = int.Parse(Console.ReadLine());
                    switch (editChoice)
                    {
                        case 1:
                            Console.WriteLine("Upiši ime i prezime igraca (bez kvacica)");
                            string findPlayerByName = Console.ReadLine();
                            foreach (var player in playerDictionary)
                            {
                                if (playerDictionary.ContainsKey(findPlayerByName))
                                {
                                    var nameAndSurname = player.Key;
                                    Console.WriteLine("Upiši novo ime i prezime");
                                    nameAndSurname = Console.ReadLine();
                                    counter++;
                                    Console.WriteLine($"{nameAndSurname} Position: {player.Value.Position} Rating: {player.Value.Rating}");
                                    Console.WriteLine("Uspjesno uredeno ime");
                                }
                            }
                            if (counter == 0)
                                Console.WriteLine("Na listi ne postoji igrac kojeg si unio");
                            break;

                        case 2:
                            Console.WriteLine("Upiši ime i prezime igraca (bez kvacica)");
                            string searchName = Console.ReadLine();
                            foreach (var player in playerDictionary)
                            {
                                if (playerDictionary.ContainsKey(searchName))
                                {
                                    var position = player.Value.Position;
                                    Console.WriteLine("Upiši novi position");
                                    position = Console.ReadLine();
                                    counter++;
                                    Console.WriteLine($"{player.Key} Position: {position} Rating: {player.Value.Rating}");
                                    Console.WriteLine("Uspjesno uredena pozicija");
                                }
                            }
                            if (counter == 0)
                                Console.WriteLine("Na listi ne postoji igrac kojeg si unio");
                            break;
                        case 3:
                            Console.WriteLine("Upiši ime i prezime igraca (bez kvacica)");
                            string findName = Console.ReadLine();
                            foreach (var player in playerDictionary)
                            {
                                if (playerDictionary.ContainsKey(findName))
                                {
                                    var rating = player.Value.Rating;
                                    Console.WriteLine("Upiši novi rating");
                                    rating = int.Parse(Console.ReadLine());
                                    counter++;
                                    Console.WriteLine($"{player.Key} Position: {player.Value.Position} Rating: {rating}");
                                    Console.WriteLine("Uspjesno ureden rating");
                                }
                            }
                            if (counter == 0)
                                Console.WriteLine("Na listi ne postoji igrac kojeg si unio");
                            break;
                        default:
                            Console.WriteLine("Nepoznata radnja");
                            break;
                    }
                    break;
            }
            GoBack();
            break;

        default:
            Console.WriteLine("Nepoznata operacija");
            GoBack();
            break;
    }
} while (menuChoice == 0);

static int DoTraining(int ratingFunc)
{
    Random ran = new Random();
    var editRating = 100 + ran.Next(1, 5);
    double percentage = (double)editRating / 100;
    int finalRating = (int)(percentage * ratingFunc);
    if (finalRating > 100)
        finalRating = 100;
    return finalRating;

}

void menu()
{
    Console.WriteLine("1 - Odradi trening");
    Console.WriteLine("2 - Odigraj utakmicu");
    Console.WriteLine("3 - Statistika");
    Console.WriteLine("4 - Kontrola igraca");
    Console.WriteLine("0 - Izlaz iz aplikacije");
    var menuChoice = 0;
}

void GoBack()
{
    menuChoice = 1;
    Console.WriteLine("Vratiti se na pocetni izbornik y/n");
    string yesOrNo = Console.ReadLine();
    if (yesOrNo == "y")
        menuChoice = 0;
    else if (yesOrNo == "n")
        menuChoice = 1;
    else
        Console.WriteLine("Nepoznata radnja");
}

void SortGKPositions(int positionFunc)
{
    foreach (var player in playerDictionary)
    {
        int newCounter = 0;
        if (positionList[newCounter] == player.Value.Position)
        {
            goalKeepers.Add(player.Key, (player.Value.Position, player.Value.Rating));
        }
    }
}

void SortDFPositions(int positionFunc)
{
    foreach (var player in playerDictionary)
    {
        int newCounter = 1;
        if (positionList[newCounter] == player.Value.Position)
        {
            defenseDict.Add(player.Key, (player.Value.Position, player.Value.Rating));
        }
    }
}

void SortMFPositions(int positionFunc)
{
    foreach (var player in playerDictionary)
    {
        int newCounter = 2;
        if (positionList[newCounter] == player.Value.Position)
        {
            midFieldDict.Add(player.Key, (player.Value.Position, player.Value.Rating));
        }
    }
}

void SortFWPositions()
{
    int newCounter = 3;
    foreach (var player in playerDictionary)
    {
        if (positionList[newCounter] == player.Value.Position)
        {
            forwardDict.Add(player.Key, (player.Value.Position, player.Value.Rating));
        }
        for (var j = 0; j < numOfPositionList[newCounter]; j++)
        {
            playingInGame.Add(player.Key, (player.Value.Position, player.Value.Rating));
        }
    }
}

//void playing(int playingFunc)
//{
//    for (var i = 0; i < 4; i++)
//    {
//        for (var j = 0; j < numOfPositionList[i]; j++)

//    }
//}