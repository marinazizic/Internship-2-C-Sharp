var articles = new Dictionary<string, (int Quantity, double Price, DateTime ExpiryDate)>()
{
    {"Jabuke", (15, 1.5, new DateTime(2023,12,15))},
    {"Banane", (7, 1, new DateTime(2023,11,30))},
    {"Cokolino", (22, 3.5, new DateTime(2024,09,04))},
    {"Sljive", (2, 0.5, new DateTime(2023,11,20))},
    {"Plazma", (9, 2.7, new DateTime(2024,03,14))},
    {"Puding", (12, 1.2, new DateTime(2023,11,15))}
};

var workers = new Dictionary<string, DateTime>()
{
    {"Ivana",  new DateTime(1993,03,24)},
    {"Željka",  new DateTime(1968,11,08)},
    {"Perica",  new DateTime(1975,05,01)}
};

var boughtArticles = new Dictionary<string, int>()
{

};

var receipt = new Dictionary<int, (Dictionary<string, int>, DateTime timeBought, double fullPrice)>()
{
};

bool menuChoice = true;
bool goBack,
    exitAnswer,
    sureToChange,
    isDeleted,
    isChanged,
    isBirthdayThisMonth,
    isFound,
    isDone,
    checkReceipt,
    isReceiptFound;
int year,
    month,
    day,
    newYear,
    newMonth,
    newDay;
string userChoice,
    articleChoice,
    deleteChoice,
    editChoice,
    chooseChoice,
    saleChoice,
    printChoice,
    workersChoice,
    deleteWorkersChoice,
    chooseWorkerChoice,
    printWorkersChoice,
    receiptChoice,
    statisticsChoice;

int ID = 0;
double fullPrice = 0;
DateTime dateWhenBought;
do
{
    ShowMenu();
    userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "0":
            Console.WriteLine("Jeste li sigurni? y/n");
            exitAnswer = YesOrNo();
            if (exitAnswer)
                menuChoice = false;

            break;

        case "1":
            ShowArticleMenu();
            articleChoice = Console.ReadLine();
            switch (articleChoice)
            {
                case "1":
                    Console.WriteLine("Upišite ime proizvoda");
                    string name = Console.ReadLine();

                    Console.WriteLine("Upišite količinu proizvoda");
                    int quantity = CheckIfInt();

                    Console.WriteLine("Upišite cijenu proizvoda");
                    double price = CheckIfDouble();

                    Console.WriteLine("Upišite godinu isteka roka");
                    while (true)
                    {
                        year = CheckIfInt();
                        bool checkYear = CheckIfYear(year);
                        if (checkYear)
                            break;
                        else
                            continue;
                    }
                    Console.WriteLine("Upišite mjesec isteka roka");
                    while (true)
                    {
                        month = CheckIfInt();
                        bool checkMonth = CheckIfMonth(month);
                        if (checkMonth)
                            break;
                        else
                            continue;
                    }

                    Console.WriteLine("Upišite dan isteka roka");
                    while (true)
                    {
                        day = CheckIfInt();
                        bool checkDay = CheckIfDay(day);
                        if (checkDay)
                            break;
                        else
                            continue;
                    }
                    var expiryDate = new DateTime(year, month, day);
                    articles.Add(name, (quantity, price, expiryDate));

                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                    goBack = YesOrNo();
                    if (!goBack)
                        menuChoice = false;
                    Console.Clear();
                    break;

                case "2":
                    Console.WriteLine("a. Po imenu");
                    Console.WriteLine("b. Sve one kojima je istekao datum trajanja");
                    deleteChoice = Console.ReadLine();
                    switch (deleteChoice)
                    {
                        case "a":
                        case "a.":
                            isDeleted = false;
                            Console.WriteLine("Upišite ime artikla kojeg želite izbrisati.");
                            string articleToDelete = Console.ReadLine();
                            foreach (var item in articles)
                            {
                                if (articleToDelete == item.Key)
                                {
                                    Console.WriteLine("Jeste li sigurni da želite izbrisati navedeni artikl? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        articles.Remove(item.Key);
                                        isDeleted = true;
                                        break;
                                    }
                                }
                            }
                            if (!isDeleted)
                                Console.WriteLine("Nije pronađen artikl.");
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;

                        case "b":
                        case "b.":
                            isDeleted = false;
                            Console.WriteLine("Jeste li sigurni da želite izbrisati sve artikle kojima je prošao rok? y/n");
                            sureToChange = YesOrNo();
                            if (sureToChange)
                            {
                                foreach (var item in articles)
                                {
                                    if (item.Value.ExpiryDate < DateTime.Today)
                                    {
                                        articles.Remove(item.Key);
                                        isDeleted = true;
                                    }
                                }
                            }

                            if (!isDeleted)
                                Console.WriteLine("Nije pronađen nijedan artikl s prošlim rokom.");
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Krivo unešena akcija!");
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("a. Zasebno uređivanje proizvoda");
                    Console.WriteLine("b. Popust/poskupljenje na sve proizvode");
                    editChoice = Console.ReadLine();
                    switch (editChoice)
                    {
                        case "a":
                        case "a.":
                            isChanged = false;
                            isFound = false;
                            Console.WriteLine("Upišite ime artikla kojeg želite urediti.");
                            string articleToEdit = Console.ReadLine();
                            foreach (var item in articles)
                            {
                                if (articleToEdit == item.Key)
                                {
                                    isFound = true;
                                    string nameArticle = item.Key;
                                    int quantityArticle = item.Value.Quantity;
                                    double priceArticle = item.Value.Price;
                                    DateTime dateArticle = item.Value.ExpiryDate;
                                    Console.WriteLine("1. Urediti ime");
                                    Console.WriteLine("2. Urediti količinu");
                                    Console.WriteLine("3. Urediti cijenu");
                                    Console.WriteLine("4. Urediti rok trajanja");
                                    chooseChoice = Console.ReadLine();
                                    isChanged = false;
                                    switch (chooseChoice)
                                    {
                                        case "1":
                                            Console.WriteLine("Jeste li sigurni da želite urediti navedeni artikl? y/n");
                                            sureToChange = YesOrNo();
                                            if (sureToChange)
                                            {
                                                Console.WriteLine("Upišite novo ime");
                                                string newName = Console.ReadLine();
                                                articles.Remove(nameArticle);
                                                articles.Add(newName, (quantityArticle, priceArticle, dateArticle));
                                            }
                                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                            goBack = YesOrNo();
                                            if (!goBack)
                                                menuChoice = false;
                                            Console.Clear();
                                            break;
                                        case "2":
                                            Console.WriteLine("Jeste li sigurni da želite urediti navedeni artikl? y/n");
                                            sureToChange = YesOrNo();
                                            if (sureToChange)
                                            {
                                                Console.WriteLine("Upišite novu količinu");
                                                int newQuantity = CheckIfInt();
                                                articles.Remove(nameArticle);
                                                articles.Add(nameArticle, (newQuantity, priceArticle, dateArticle));
                                            }
                                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                            goBack = YesOrNo();
                                            if (!goBack)
                                                menuChoice = false;
                                            Console.Clear();
                                            break;
                                        case "3":
                                            Console.WriteLine("Jeste li sigurni da želite urediti navedeni artikl? y/n");
                                            sureToChange = YesOrNo();
                                            if (sureToChange)
                                            {
                                                Console.WriteLine("Upišite novu cijenu");
                                                double newPrice = CheckIfDouble();
                                                articles.Remove(nameArticle);
                                                articles.Add(nameArticle, (quantityArticle, newPrice, dateArticle));
                                            }
                                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                            goBack = YesOrNo();
                                            if (!goBack)
                                                menuChoice = false;
                                            Console.Clear();
                                            break;
                                        case "4":
                                            Console.WriteLine("Jeste li sigurni da želite urediti navedeni artikl? y/n");
                                            sureToChange = YesOrNo();
                                            if (sureToChange)
                                            {
                                                Console.WriteLine("Upišite novu godinu");
                                                while (true)
                                                {
                                                    newYear = CheckIfInt();
                                                    bool checkNewYear = CheckIfYear(newYear);
                                                    if (checkNewYear)
                                                        break;
                                                    else
                                                        continue;
                                                }
                                                Console.WriteLine("Upišite novi mjesec");
                                                while (true)
                                                {
                                                    newMonth = CheckIfInt();
                                                    bool checkNewMonth = CheckIfMonth(newMonth);
                                                    if (checkNewMonth)
                                                        break;
                                                    else
                                                        continue;
                                                }
                                                Console.WriteLine("Upišite novi dan");

                                                while (true)
                                                {
                                                    newDay = CheckIfInt();
                                                    bool checkNewDay = CheckIfDay(newDay);
                                                    if (checkNewDay)
                                                        break;
                                                    else
                                                        continue;
                                                }
                                                DateTime newDate = new DateTime(newYear, newMonth, newDay);
                                                articles.Remove(nameArticle);
                                                articles.Add(nameArticle, (quantityArticle, priceArticle, newDate));
                                            }
                                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                            goBack = YesOrNo();
                                            if (!goBack)
                                                menuChoice = false;
                                            Console.Clear();
                                            break;
                                        default:
                                            Console.WriteLine("Krivo unešena akcija!");
                                            break;
                                    }
                                }
                                break;
                            }
                            if (!isFound)
                            {
                                Console.WriteLine("Nije pronađen ni uređen proizvod.");
                                Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                goBack = YesOrNo();
                                if (!goBack)
                                    menuChoice = false;
                                Console.Clear();
                            }
                            break;
                        case "b":
                        case "b.":
                            Console.WriteLine("a. Popust");
                            Console.WriteLine("b. Poskupljenje");
                            saleChoice = Console.ReadLine();
                            switch (saleChoice)
                            {
                                case "a":
                                case "a.":
                                    Console.WriteLine("Upišite koliki želite postotak bez znaka %");
                                    int percentage = CheckIfInt();
                                    Console.WriteLine("Jeste li sigurni da želite dati popust? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        foreach (var item in articles.OrderBy(x => x.Key))
                                        {

                                            string nameArticle = item.Key;
                                            int quantityArticle = item.Value.Quantity;
                                            double priceArticle = item.Value.Price;
                                            DateTime dateArticle = item.Value.ExpiryDate;
                                            double priceToRemove = (priceArticle / 100) * percentage;
                                            double newPrice = priceArticle - priceToRemove;
                                            articles.Remove(nameArticle);
                                            articles.Add(nameArticle, (quantityArticle, newPrice, dateArticle));
                                        }
                                    }
                                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                    goBack = YesOrNo();
                                    if (!goBack)
                                        menuChoice = false;
                                    Console.Clear();
                                    break;

                                case "b":
                                case "b.":
                                    Console.WriteLine("Upišite koliki želite postotak bez znaka %");
                                    int percentageSale = CheckIfInt();
                                    Console.WriteLine("Jeste li sigurni da želite dati poskupljenje? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        foreach (var item in articles.OrderBy(x => x.Key))
                                        {

                                            string nameArticle = item.Key;
                                            int quantityArticle = item.Value.Quantity;
                                            double priceArticle = item.Value.Price;
                                            DateTime dateArticle = item.Value.ExpiryDate;
                                            double priceToRemove = (priceArticle / 100) * percentageSale;
                                            double newPrice = priceArticle + priceToRemove;
                                            articles.Remove(nameArticle);
                                            articles.Add(nameArticle, (quantityArticle, newPrice, dateArticle));
                                        }
                                    }
                                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                    goBack = YesOrNo();
                                    if (!goBack)
                                        menuChoice = false;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Krivo unešena akcija!");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Krivo unešena akcija!");
                            break;
                    }
                    break;

                case "4":
                    ShowPrintMenu();
                    printChoice = Console.ReadLine();
                    switch (printChoice)
                    {
                        case "a":
                        case "a.":
                            foreach (var item in articles)
                            {
                                double daysUntil = CountDownDays(item.Value.ExpiryDate);
                                Console.WriteLine("{0} ({1}) - {2} - Broj dana do isteka: {3}", item.Key, item.Value.Quantity, item.Value.Price, daysUntil);
                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;

                        case "b":
                        case "b.":
                            var orderedByNameAsc = articles.OrderBy(k => k.Key).ToDictionary(k => k.Key, k => k.Value);
                            foreach (var item in orderedByNameAsc)
                            {
                                Console.WriteLine("{0} ({1}) - {2} - Datum Isteka: {3}", item.Key, item.Value.Quantity, item.Value.Price, item.Value.ExpiryDate);

                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        case "c":
                        case "c.":
                            var orderedByDateDesc = articles.OrderByDescending(x => x.Value.ExpiryDate).ToDictionary(x => x.Key, x => x.Value);
                            foreach (var item in orderedByDateDesc)
                            {
                                Console.WriteLine("{0} ({1}) - {2} - Datum Isteka: {3}", item.Key, item.Value.Quantity, item.Value.Price, item.Value.ExpiryDate);

                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;

                        case "d":
                        case "d.":
                            var orderedByDateAsc = articles.OrderBy(x => x.Value.ExpiryDate).ToDictionary(x => x.Key, x => x.Value);
                            foreach (var item in orderedByDateAsc)
                            {
                                Console.WriteLine("{0} ({1}) - {2} - Datum Isteka: {3}", item.Key, item.Value.Quantity, item.Value.Price, item.Value.ExpiryDate);

                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        case "e":
                        case "e.":
                            var orderedByQuantity = articles.OrderBy(x => x.Value.Quantity).ToDictionary(x => x.Key, x => x.Value);
                            foreach (var item in orderedByQuantity)
                            {
                                Console.WriteLine("{0} ({1}) - {2} - Datum Isteka: {3}", item.Key, item.Value.Quantity, item.Value.Price, item.Value.ExpiryDate);

                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        case "f":
                        case "f.":
                            Console.WriteLine(findMostSoldArticle(articles));
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;

                        case "g":
                        case "g.":
                            Console.WriteLine(findLeastSoldArticle(articles));
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Krivo unešena akcija!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Krivo unešena akcija!");
                    break;
            };
            break;

        case "2":
            ShowWorkersMenu();
            workersChoice = Console.ReadLine();
            switch (workersChoice)
            {
                case "1":
                    Console.WriteLine("Upišite ime radnika");
                    string name = Console.ReadLine();

                    Console.WriteLine("Upišite godinu rođenja radnika");
                    while (true)
                    {
                        year = CheckIfInt();
                        bool checkYear = CheckIfYear(year);
                        if (checkYear)
                            break;
                        else
                            continue;
                    }
                    Console.WriteLine("Upišite mjesec rođenja radnika");
                    while (true)
                    {
                        month = CheckIfInt();
                        bool checkMonth = CheckIfMonth(month);
                        if (checkMonth)
                            break;
                        else
                            continue;
                    }

                    Console.WriteLine("Upišite dan rođenja radnika");
                    while (true)
                    {
                        day = CheckIfInt();
                        bool checkDay = CheckIfDay(day);
                        if (checkDay)
                            break;
                        else
                            continue;
                    }
                    var birthDate = new DateTime(year, month, day);
                    workers.Add(name, birthDate);

                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                    goBack = YesOrNo();
                    if (!goBack)
                        menuChoice = false;
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("a. Po imenu");
                    Console.WriteLine("b. Sve one koji imaju više od 65 godina");
                    deleteWorkersChoice = Console.ReadLine();
                    switch (deleteWorkersChoice)
                    {
                        case "a":
                        case "a.":
                            isDeleted = false;
                            Console.WriteLine("Upišite ime radnika kojeg želite izbrisati");
                            string workerToDelete = Console.ReadLine();
                            foreach (var item in workers)
                            {
                                if (workerToDelete == item.Key)
                                {
                                    Console.WriteLine("Jeste li sigurni da želite izbrisati navedenog radnika? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        articles.Remove(item.Key);
                                        isDeleted = true;
                                        break;
                                    }
                                }
                            }
                            if (!isDeleted)
                                Console.WriteLine("Nije pronađen radnik.");
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        case "b":
                        case "b.":
                            isDeleted = false;
                            foreach (var item in workers)
                            {
                                double yearsFrom = CountDownYears(item.Value);
                                if (yearsFrom <= -65)
                                {
                                    Console.WriteLine("Jeste li sigurni da želite izbrisati radnike starije od 65 godina? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        workers.Remove(item.Key);
                                        isDeleted = true;
                                    }
                                }
                            }
                            if (!isDeleted)
                                Console.WriteLine("Nije pronađen radnik.");
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Krivo unešena akcija!");
                            break;
                    }
                    break;
                case "3":
                    isChanged = false;
                    Console.WriteLine("Upišite ime radnika kojeg želite urediti.");
                    string workerToEdit = Console.ReadLine();
                    foreach (var item in workers.OrderBy(x => x.Key))
                    {
                        if (workerToEdit == item.Key)
                        {
                            string workerName = item.Key;
                            DateTime workerBirth = item.Value;
                            Console.WriteLine("1. Urediti ime");
                            Console.WriteLine("2. Urediti datum rođenja");
                            chooseWorkerChoice = Console.ReadLine();
                            switch (chooseWorkerChoice)
                            {
                                case "1":
                                    isChanged = false;
                                    Console.WriteLine("Jeste li sigurni da želite urediti ime radnika? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        Console.WriteLine("Upišite novo ime");
                                        string newWorkerName = Console.ReadLine();
                                        workers.Remove(workerName);
                                        workers.Add(newWorkerName, workerBirth);
                                        isChanged = true;
                                    }
                                    if (!isChanged)
                                        Console.WriteLine("Nije pronađen i uređen radnik.");
                                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                    goBack = YesOrNo();
                                    if (!goBack)
                                        menuChoice = false;
                                    Console.Clear();
                                    break;
                                case "2":
                                    isChanged = false;
                                    Console.WriteLine("Jeste li sigurni da želite urediti datum rođenja radnika? y/n");
                                    sureToChange = YesOrNo();
                                    if (sureToChange)
                                    {
                                        Console.WriteLine("Upišite novu godinu");
                                        while (true)
                                        {
                                            newYear = CheckIfInt();
                                            bool checkNewYear = CheckIfYear(newYear);
                                            if (checkNewYear)
                                                break;
                                            else
                                                continue;
                                        }
                                        Console.WriteLine("Upišite novi mjesec");
                                        while (true)
                                        {
                                            newMonth = CheckIfInt();
                                            bool checkNewMonth = CheckIfMonth(newMonth);
                                            if (checkNewMonth)
                                                break;
                                            else
                                                continue;
                                        }
                                        Console.WriteLine("Upišite novi dan");

                                        while (true)
                                        {
                                            newDay = CheckIfInt();
                                            bool checkNewDay = CheckIfDay(newDay);
                                            if (checkNewDay)
                                                break;
                                            else
                                                continue;
                                        }
                                        DateTime newBirthDate = new DateTime(newYear, newMonth, newDay);
                                        workers.Remove(workerName);
                                        workers.Add(workerName, newBirthDate);
                                        isChanged = true;
                                    }
                                    if (!isChanged)
                                        Console.WriteLine("Nije pronađen i uređen radnik.");
                                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                                    goBack = YesOrNo();
                                    if (!goBack)
                                        menuChoice = false;
                                    Console.Clear();
                                    break;
                            }
                        }
                    }
                    if (!isChanged)
                        Console.WriteLine("Nije pronađen i uređen radnik.");
                    break;
                case "4":
                    Console.WriteLine("a. Ispis svih radnika");
                    Console.WriteLine("b. Ispis svih radnika kojima je rođendan u tekućem mjesecu");
                    printWorkersChoice = Console.ReadLine();
                    switch (printWorkersChoice)
                    {
                        case "a":
                        case "a.":
                            foreach (var item in workers)
                            {
                                double yearsFrom = CountDownYears(item.Value);
                                Console.WriteLine("{0} - {1}", item.Key, Math.Abs(Math.Round(yearsFrom)));
                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        case "b":
                        case "b.":
                            foreach (var item in workers)
                            {
                                double yearsFrom = CountDownYears(item.Value);
                                isBirthdayThisMonth = CheckIfBirthdayThisMonth(item.Value);
                                if (isBirthdayThisMonth)
                                    Console.WriteLine("{0} - {1}", item.Key, Math.Abs(Math.Round(yearsFrom)));
                            }
                            Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                            goBack = YesOrNo();
                            if (!goBack)
                                menuChoice = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Krivo unešena akcija!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Krivo unešena akcija!");
                    break;
            }
            break;
        case "3":
            Console.WriteLine("1 - Unos novog računa");
            Console.WriteLine("2 - Ispis");
            receiptChoice = Console.ReadLine();
            switch (receiptChoice)
            {
                case "1":
                    isDone = true;
                    foreach (var item in articles.OrderBy(x => x.Key))
                    {
                        double daysUntil = CountDownDays(item.Value.ExpiryDate);
                        if (item.Value.Quantity > 0)
                            Console.WriteLine("{0} ({1}) - {2} - Broj dana do isteka: {3}", item.Key, item.Value.Quantity, item.Value.Price, daysUntil);
                    }
                    boughtArticles.Clear();
                    fullPrice = 0;
                    do
                    {
                        isFound = false;
                        Console.WriteLine("Upišite ime artikla");
                        string articleToBuy = Console.ReadLine();
                        foreach (var item in articles.OrderBy(x => x.Key))
                        {
                            string nameArticle = item.Key;
                            double priceArticle = item.Value.Price;
                            DateTime dateArticle = item.Value.ExpiryDate;
                            if (articleToBuy == item.Key)
                            {
                                isFound = true;
                                do
                                {
                                    Console.WriteLine("Upišite količinu");
                                    int amountToBuy = CheckIfInt();
                                    if (item.Value.Quantity >= amountToBuy)
                                    {
                                        int quantityArticle = item.Value.Quantity - amountToBuy;
                                        boughtArticles.Add(articleToBuy, amountToBuy);
                                        fullPrice += amountToBuy * item.Value.Price;
                                        if (quantityArticle == 0)
                                            articles.Remove(item.Key);
                                        else
                                        {
                                            articles.Remove(item.Key);
                                            articles.Add(nameArticle, (quantityArticle, priceArticle, dateArticle));
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nema dovoljno artikla! Upišite broj manji ili jednak {0}", item.Value.Quantity);
                                        continue;
                                    }
                                } while (true);
                            }
                        }
                        if (!isFound)
                            Console.WriteLine("Nije pronađen nijedan artikl.");
                        Console.WriteLine("Dodati još artikla? y/n");
                        isDone = YesOrNo();
                    } while (isDone);
                    dateWhenBought = DateTime.Now;
                    receipt.Add(ID, (boughtArticles, dateWhenBought, fullPrice));
                    foreach (var item in receipt)
                    {
                        if (item.Key == ID)
                        {
                            Console.WriteLine("{0} - {1} - {2:0.00}", item.Key, item.Value.timeBought, item.Value.fullPrice);
                        }
                    };
                    ID++;

                    Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                    goBack = YesOrNo();
                    if (!goBack)
                        menuChoice = false;
                    Console.Clear();
                    break;
                case "2":
                    int IDReceipt;
                    foreach (var item in receipt)
                    {
                        Console.WriteLine("{0} - {1} - {2:0.00}", item.Key, item.Value.timeBought, item.Value.fullPrice);
                    };
                    Console.WriteLine("Detalji specifičnog računa y/n");
                    checkReceipt = YesOrNo();
                    if (!checkReceipt)
                    {
                        Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                        goBack = YesOrNo();
                        if (!goBack)
                            menuChoice = false;
                        Console.Clear();
                    }

                    else
                    {
                        Console.WriteLine("Upišite ID računa");
                        IDReceipt = CheckIfInt();
                        isReceiptFound = false;
                        foreach (var item in receipt)
                        {
                            if (item.Key == IDReceipt)
                            {
                                isReceiptFound = true;
                                Console.WriteLine("{0} - {1}", item.Key, item.Value.timeBought);
                                foreach (var item1 in boughtArticles)
                                {
                                    Console.WriteLine("{0} - {1}", item1.Key, item1.Value);
                                }
                                Console.WriteLine("Sveukupna cijena: {0}", item.Value.fullPrice);
                            }
                        }
                        if (!isReceiptFound)
                            Console.WriteLine("Nije pronađen nijedan račun.");
                        Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                        goBack = YesOrNo();
                        if (!goBack)
                            menuChoice = false;
                        Console.Clear();
                    }
                    break;
                default:
                    Console.WriteLine("Krivo unešena akcija!");
                    break;
            }
            break;
        case "4":
            Console.WriteLine("Upišite šifru");
            int passwordTry = CheckIfInt();
            int password = 1234;
            int countedArticles = 0;
            double valueOfNotBought = 0;
            double valueOfBought = 0;
            if (passwordTry == password)
            {
                ShowStatisticsMenu();
                statisticsChoice = Console.ReadLine();
                switch (statisticsChoice)
                {
                    case "1":
                        foreach (var item in articles)
                        {
                            countedArticles += item.Value.Quantity;
                        }
                        Console.WriteLine("Ukupan broj artikala u trgovini je {0}", countedArticles);
                        Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                        goBack = YesOrNo();
                        if (!goBack)
                            menuChoice = false;
                        Console.Clear();
                        break;
                    case "2":
                        foreach (var item in articles)
                        {
                            valueOfNotBought += item.Value.Quantity * item.Value.Price;
                        }
                        Console.WriteLine("Ukupna vrijednost artikala koji nisu prodani u trgovini je {0}", valueOfNotBought);
                        Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                        goBack = YesOrNo();
                        if (!goBack)
                            menuChoice = false;
                        Console.Clear();
                        break;
                    case "3":
                        foreach (var item in receipt)
                        {
                            valueOfBought += item.Value.fullPrice;
                        }
                        Console.WriteLine("Ukupna vrijednost artikala koji su prodani u trgovini je {0}", valueOfBought);
                        Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                        goBack = YesOrNo();
                        if (!goBack)
                            menuChoice = false;
                        Console.Clear();
                        break;
                    case "4":
                        int dayStatistics;
                        int monthStatistics;
                        int yearStatistics;
                        Console.WriteLine("Upišite dan datuma");
                        while (true)
                        {
                            dayStatistics = CheckIfInt();
                            bool checkStatsDay = CheckIfDay(dayStatistics);
                            if (checkStatsDay)
                                break;
                            else
                                continue;
                        }

                        Console.WriteLine("Upišite mjesec datuma");
                        while (true)
                        {
                            monthStatistics = CheckIfInt();
                            bool checkStatsMonth = CheckIfMonth(monthStatistics);
                            if (checkStatsMonth)
                                break;
                            else
                                continue;
                        }
                        Console.WriteLine("Upišite godinu datuma");
                        while (true)
                        {
                            yearStatistics = CheckIfInt();
                            bool checkStatsYear = CheckIfYear(yearStatistics);
                            if (checkStatsYear)
                                break;
                            else
                                continue;
                        }
                        DateTime statsDate = new DateTime(yearStatistics, monthStatistics, dayStatistics);
                        Console.WriteLine("Upišite plaću radnika");
                        double monthlyPay = CheckIfDouble();
                        Console.WriteLine("Upišite iznos najma");
                        double monthlyLease = CheckIfDouble();
                        Console.WriteLine("Upišite iznos ostalih troškova");
                        double monthlyCharges = CheckIfDouble();
                        double formulaPrice = (workers.Count * monthlyPay) + monthlyLease + monthlyCharges;
                        double formulaBought = 0;
                        foreach (var item in receipt)
                        {
                            formulaBought += item.Value.fullPrice;
                        }
                        double formulaPrices = formulaPrice / 3;
                        double conditionThisMonth = formulaBought * formulaPrices;
                        Console.WriteLine("Stanje {0} je {1} eura", statsDate, conditionThisMonth);
                        Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                        goBack = YesOrNo();
                        if (!goBack)
                            menuChoice = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Krivo unešena akcija!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Krivo unošena šifra!");
                Console.WriteLine("Vratiti se na glavni izbornik? y/n");
                goBack = YesOrNo();
                if (!goBack)
                    menuChoice = false;
                Console.Clear();
            }
            break;
        default:
            Console.WriteLine("Krivo unešena akcija!");
            break;
    };
} while (menuChoice);


static void ShowMenu()
{
    Console.WriteLine("1 - Artikli");
    Console.WriteLine("2 - Radnici");
    Console.WriteLine("3 - Racuni");
    Console.WriteLine("4 - Statistika");
    Console.WriteLine("0 - Izlaz iz aplikacije");
}

static void ShowArticleMenu()
{
    Console.WriteLine("1 - Unos artikla");
    Console.WriteLine("2 - Brisanje artikla");
    Console.WriteLine("3 - Uređivanje artikla");
    Console.WriteLine("4 - Ispis");
}

static void ShowPrintMenu()
{
    Console.WriteLine("a. Ispis svih artikala kako su spremljeni");
    Console.WriteLine("b. Ispis svih artikala sortirano po imenu");
    Console.WriteLine("c. Ispis svih artikala sortirano po datumu silazno");
    Console.WriteLine("d. Ispis svih artikala sortirano po datumu uzlazno");
    Console.WriteLine("e. Ispis svih artikala sortirano po količini");
    Console.WriteLine("f. Najprodavaniji artikl");
    Console.WriteLine("g. Najmanje prodavan artikl");
}

static void ShowWorkersMenu()
{
    Console.WriteLine("1 - Unos radnika");
    Console.WriteLine("2 - Brisanje radnika");
    Console.WriteLine("3 - Uređivanje radnika");
    Console.WriteLine("4 - Ispis");
}

static void ShowStatisticsMenu()
{
    Console.WriteLine("1 - Ukupan broj artikala u trgovini");
    Console.WriteLine("2 - Vrijednost artikala koji nisu prodani");
    Console.WriteLine("3 - Vrijednost artikla koji su prodani");
    Console.WriteLine("4 - Stanje po mjesecima");
}

static bool YesOrNo()
{
    while (true)
    {
        string ynChoice = Console.ReadLine();
        if (ynChoice == "y")
        {
            return true;
        }
        else if (ynChoice == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Krivo unešena akcija! Unesite y/n");
            continue;
        }
    }
}

static int CheckIfInt()
{

    string variable = Console.ReadLine();
    while (true)
    {
        bool res;
        int num;
        res = int.TryParse(variable, out num);
        if (res)
            return num;
        else
        {
            Console.WriteLine("Krivo unešen podatak! Upišite brojčanu vrijednost bez decimala.");
            variable = Console.ReadLine();
            continue;
        }

    }
}

static bool CheckIfYear(int variable)
{
    while (true)
    {
        if (variable < 10000 && variable > 999)
            return true;
        else
        {
            Console.WriteLine("Krivo unešen podatak! Upišite četveroznamenkast broj odnosno godinu.");
            return false;
        }

    }
}

static bool CheckIfMonth(int variable)
{
    while (true)
    {
        if (variable < 13 && variable > 0)
            return true;
        else
        {
            Console.WriteLine("Krivo unešen podatak! Upišite dvoznamenkasti broj odnosno mjesec.");
            return false;
        }

    }
}

static bool CheckIfDay(int variable)
{
    while (true)
    {
        if (variable < 32 && variable > 0)
            return true;
        else
        {
            Console.WriteLine("Krivo unešen podatak! Upišite dvoznamenkasti broj odnosno dan.");
            return false;
        }

    }
}
static double CheckIfDouble()
{

    string variable = Console.ReadLine();
    while (true)
    {
        bool res;
        double num;
        res = double.TryParse(variable, out num);
        if (res)
            return num;
        else
        {
            Console.WriteLine("Krivo unešen podatak! Upišite brojčanu vrijednost s decimalima.");
            variable = Console.ReadLine();
            continue;
        }

    }
}

static double CountDownDays(DateTime specificDate)
{
    DateTime today = DateTime.Today;
    var days = (specificDate - today).TotalDays;
    return days;
}

static double CountDownYears(DateTime specificDate)
{
    DateTime today = DateTime.Today;
    var years = (specificDate - today).TotalDays;
    years = years / 365;
    return years;
}

static (string tName, int tQuantity, double tPrice, DateTime tDate) findMostSoldArticle(Dictionary<string, (int q, double p, DateTime d)> dict)
{

    var mostSold = (tName: "", tQuantity: 0, tPrice: 0.1, tDate: new DateTime(2000, 01, 01));
    int mostSales = 100;
    foreach (var item in dict)
    {
        if (item.Value.q < mostSales)
        {
            mostSales = item.Value.q;
            mostSold.tName = item.Key;
            mostSold.tQuantity = item.Value.q;
            mostSold.tPrice = item.Value.p;
            mostSold.tDate = item.Value.d;
        }
    }
    return mostSold;
}

static (string tName, int tQuantity, double tPrice, DateTime tDate) findLeastSoldArticle(Dictionary<string, (int q, double p, DateTime d)> dict)
{

    var leastSold = (tName: "", tQuantity: 0, tPrice: 0.1, tDate: new DateTime(2000, 01, 01));
    int leastSales = 0;
    foreach (var item in dict)
    {
        if (item.Value.q > leastSales)
        {
            leastSales = item.Value.q;
            leastSold.tName = item.Key;
            leastSold.tQuantity = item.Value.q;
            leastSold.tPrice = item.Value.p;
            leastSold.tDate = item.Value.d;
        }
    }
    return leastSold;
}

static bool CheckIfBirthdayThisMonth(DateTime bd)
{
    var thisMonth = DateTime.Now.Month.ToString("00");
    var birthdayMonth = bd.Month.ToString("00");
    if (thisMonth == birthdayMonth)
        return true;
    return false;
}