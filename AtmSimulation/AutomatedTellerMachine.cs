using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class AutomatedTellerMachine
{
    static Random rnd = new Random();

    static List<MyAccounts> _myAccounts = new List<MyAccounts>();
    static List<CreditCards> _creditCards = new List<CreditCards>();
    static List<ThirdParyAccount> _thirdPartyAccounts = new List<ThirdParyAccount>();
    static List<Summary> _summary = new List<Summary>();

    /// <summary>
    /// Programın giriş noktasıdır. Örnek hesapları oluşturur ve kullanıcıdan işlem seçmesini sağlar.
    /// </summary>
    private static void Main()
    {
        Example();

        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Loading();
            Operations();

            Console.Write("\n🔎 Yapmak istediğiniz işlemi numerik olarak giriniz (1-7): ");
            if (!ushort.TryParse(Console.ReadLine(), out ushort input)) { Invalid(); return; }

            Console.Clear();

            switch (input)
            {
                case 1: ShowBalance(); break;
                case 2: ShowBalance(); WithdrawMoney(); break;
                case 3: ShowBalance(); DepositMoney(); break;
                case 4: ShowBalance(); Transfer(); break;
                case 5: Payments(); break;
                case 6: Summary(); break;
                case 7: Exit(); break;
                default: Invalid(); break;
            }

            Continue();
        }
    }

    /// <summary>
    /// Girilen hesap numarasına ait hesap bulunamadığında bilgilendirme mesajı gösterir.
    /// </summary>
    private static void AccountNotFound()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n⚠️ Girmiş olduğunuz hesap numarasına ait hesap bulunamadı");
        Console.ResetColor();
    }

    /// <summary>
    /// Konsola belirli renklerle mesaj yazdırır.
    /// </summary>
    /// <param name="message1">İlk mesaj (cyan renkli)</param>
    /// <param name="message2">İkinci mesaj (beyaz renkli)</param>
    private static void Action(string message1, string message2)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(message1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message2);
    }

    /// <summary>
    /// Kullanıcıdan bir tuşa basmasını bekler ve devam etmesini sağlar.
    /// </summary>
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDevam etmek için herhangi bir tuşa basınız ▶️");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;
    }

    /// <summary>
    /// Kullanıcıdan hesap numarası ve tutar alarak para yatırma işlemini gerçekleştirir.
    /// </summary>
    private static void DepositMoney()
    {
        Console.Write("\n🔎 Para yatırmak istediğiniz hesaba ait hesap numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Invalid(); return; }

        var account = _myAccounts.FirstOrDefault(x => x.Id == id);

        if (account != null)
        {
            Console.Write("\nYatırmak istediğiniz tutarı giriniz: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal depositAmaount)) { Invalid(); return; }

            if (depositAmaount < 50) { Message("\n⚠️ Yatırmak istediğiniz tutar en az 50 TRY olmalıdır"); return; }
            else
            {
                account.Balance += depositAmaount;
                Valid();
                Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                _summary.Add(new Summary()
                {
                    Id = rnd.Next(10000, 99999),
                    Time = DateTime.Now,
                    Type = "Para yatırma",
                    Description = $"➕ Hesaba {depositAmaount} {account.Currency} yatırıldı.",
                    Amount = account.Balance
                });
            }
        }
        else
        {
            AccountNotFound();
        }
    }

    /// <summary>
    /// Örnek hesap, kredi kartı ve üçüncü parti hesap verilerini oluşturur.
    /// </summary>
    private static void Example()
    {
        _myAccounts.Add(new MyAccounts()
        {
            Id = rnd.Next(1000, 9999),
            Owner = "Emirhan Kaaner",
            AccountName = "Maaş hesabım",
            Branch = "İstabul/Ataşehir",
            Currency = "TRY",
            Balance = 159045.7119m
        });
        _myAccounts.Add(new MyAccounts()
        {
            Id = rnd.Next(1000, 9999),
            Owner = "Emirhan Kaaner",
            AccountName = "BES hesabım",
            Branch = "Ankara/Çankaya",
            Currency = "TRY",
            Balance = 1053982.7591m
        });
        _creditCards.Add(new CreditCards()
        {
            Id = rnd.Next(1000, 9999),
            Owner = "Emirhan Kaaner",
            AccountName = "Kredi kartım",
            Currency = "TRY",
            Limit = 100000m,
            CurrentDebt = 17200.75m
        });

        _thirdPartyAccounts.Add(new ThirdParyAccount()
        {
            Id = rnd.Next(1000, 9999),
            Owner = "Ali Yılmaz",
            AccountName = "Ana hesap",
            Currency = "TRY",
        });
        _thirdPartyAccounts.Add(new ThirdParyAccount()
        {
            Id = rnd.Next(1000, 9999),
            Owner = "Ayşe Korkmaz",
            AccountName = "Birikim hesabı",
            Currency = "TRY",
        });
    }

    /// <summary>
    /// Programdan çıkış yapılmasını sağlar.
    /// </summary>
    private static void Exit()
    {
        Console.Clear();

        Console.Write("\nÇıkmak istediğinize emin misiniz ?(E/H): ");
        string? act = Console.ReadLine();

        if (string.IsNullOrEmpty(act) || string.IsNullOrWhiteSpace(act))
        {
            Invalid();
            return;
        }
        else
        {
            if (act.ToLower() == "e")
            {
                Environment.Exit(0);
            }
            else if (act.ToLower() == "h")
            {
                return;
            }
            else
            {
                Invalid();
                return;
            }
        }
    }

    /// <summary>
    /// Geçersiz işlem yapıldığında uyarı mesajı gösterir.
    /// </summary>
    private static void Invalid()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n❌ Geçersiz bir işlem yaptınız!");
        Console.ResetColor();
    }

    /// <summary>
    /// Kredi kartlarını listeler ve detaylarını gösterir.
    /// </summary>
    private static void ListingCreditCards()
    {
        foreach (var item in _creditCards)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"".PadLeft(7)}<< {item.AccountName} >>\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"➡️ Hesap numarası         : {item.Id}\n" +
                              $"➡️ Hesap sahibi          : {item.Owner}\n" +
                              $"➡️ Para birimi           : {item.Currency}\n" +
                              $"➡️ Kart limiti           : {item.Limit} {item.Currency}\n" +
                              $"➡️ Kullanılabilir limit  : {item.Limit - item.CurrentDebt} {item.Currency}\n" +
                              $"➡️ Toplam dönem borcu    : {item.CurrentDebt} {item.Currency}\n" +
                              $"➡️ Asgari ödeme tutarı   : {item.CurrentDebt * 0.25m} {item.Currency}");
        }
    }

    /// <summary>
    /// Kullanıcının hesaplarını listeler.
    /// </summary>
    private static void ListingMyAccounts()
    {
        foreach (var item in _myAccounts)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"".PadLeft(7)}<< {item.AccountName} >>\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"➡️ Hesap numarası: {item.Id}\n" +
                              $"➡️ Hesap sahibi  : {item.Owner}\n" +
                              $"➡️ Şube adı      : {item.Branch}\n" +
                              $"➡️ Para birimi   : {item.Currency}\n" +
                              $"➡️ Bakiye        : {item.Balance} {item.Currency}\n");
        }
    }

    /// <summary>
    /// Üçüncü taraf hesapları listeler.
    /// </summary>
    private static void ListingThirdPartyAccounts()
    {
        foreach (var item in _thirdPartyAccounts)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"".PadLeft(7)}<< {item.AccountName} >>\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"➡️ Hesap numarası: {item.Id}\n" +
                              $"➡️ Hesap sahibi  : {item.Owner}\n" +
                              $"➡️ Para birimi   : {item.Currency}\n");
        }
    }

    /// <summary>
    /// Ekranda yükleme animasyonu gösterir.
    /// </summary>
    private static void Loading()
    {
        Console.Clear();

        char[] items = { '-', '\\', '|', '/', '-', '\\', '|', '/' };

        int loopCounter = 0;
        int loopDuration = 50;

        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;

        while (loopCounter < 4)
        {
            foreach (var item in items)
            {
                Console.Write(item);
                Thread.Sleep(loopDuration);
                Console.Clear();
            }
            loopCounter++;
        }

        Console.ResetColor();
        Console.CursorVisible = true;
    }

    /// <summary>
    /// Sarı renkte uyarı mesajı gösterir.
    /// </summary>
    /// <param name="message">Gösterilecek mesaj</param>
    private static void Message(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Kullanıcının yapabileceği işlemleri listeler.
    /// </summary>
    private static void Operations()
    {
        Action("1. ", "🔎 Bakiye sorgulama");
        Action("2. ", "💰 Para çekme");
        Action("3. ", "💵 Para yatırma");
        Action("4. ", "💸 Transfer işlemleri");
        Action("5. ", "💲 Ödemeler");
        Action("6. ", "📜 Hesap dökümü");
        Action("7. ", "🔚 Çıkış");
    }

    /// <summary>
    /// Ödeme menüsünü gösterir ve kredi kartı borcu veya fatura ödemesine yönlendirir.
    /// </summary>
    private static void Payments()
    {
        Action("💳 1. ", "Kredi kart borç ödeme");
        Action("🧾 2. ", "Fatura ödeme");

        Console.Write("\n🔎 Yapmak istediğiniz işlemi numerik olarak giriniz: ");
        if (!short.TryParse(Console.ReadLine(), out short inputVal)) { Invalid(); return; }

        switch (inputVal)
        {
            case 1:
                PayCreditCardDebt();
                break;
            case 2:
                PayBills();
                break;
            default:
                Invalid();
                break;
        }
    }

    /// <summary>
    /// Kredi kartı borcunun ödenmesini sağlar.
    /// </summary>
    private static void PayCreditCardDebt()
    {
        Console.Clear();
        ListingCreditCards();

        Console.Write("\n🔎 Borcunu ödemek istediğiniz kredi kartı numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int cardId)) { Invalid(); return; }

        var card = _creditCards.FirstOrDefault(x => x.Id == cardId);
        if (card == null) { AccountNotFound(); return; }

        Console.Clear();
        ListingMyAccounts();

        Console.Write("\n🔎 Ödeme yapmak istediğiniz hesabın numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int accountId)) { Invalid(); return; }

        var account = _myAccounts.FirstOrDefault(x => x.Id == accountId);
        if (account == null) { AccountNotFound(); return; }

        Console.Write("\n🔎 Ödemek istediğiniz tutarı giriniz: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal paymentAmount)) { Invalid(); return; }

        if (paymentAmount < 50)
        {
            Message("\n⚠️ Ödeme tutarı en az 50 TRY olmalıdır");
            return;
        }
        if (paymentAmount > account.Balance)
        {
            Message("\n⚠️ Yetersiz bakiye");
            return;
        }
        if (paymentAmount > card.CurrentDebt)
        {
            Message("\n⚠️ Ödeme tutarı kart borcundan fazla olamaz");
            return;
        }

        account.Balance -= paymentAmount;
        card.CurrentDebt -= paymentAmount;

        Valid();
        Console.WriteLine($"\nKalan dönem borcu: {card.CurrentDebt} {card.Currency}");
        Console.WriteLine($"Mevcut yeni hesap bakiyesi: {account.Balance} {account.Currency}");

        _summary.Add(new Summary()
        {
            Id = rnd.Next(10000, 99999),
            Time = DateTime.Now,
            Type = "Kredi Kartı Borç Ödeme",
            Description = $"➕ {card.AccountName} kartına {paymentAmount} {card.Currency} borç ödemesi yapıldı.",
            Amount = account.Balance
        });
    }

    /// <summary>
    /// Fatura ödemelerini listeler ve ödeme işlemini gerçekleştirir.
    /// </summary>
    /// <returns>Ödeme işleminin başarı durumu</returns>
    private static bool PayBills()
    {
        Action("⚡ 1. ", "Elektrik faturası (1754.4561 TRY)");
        Action("💧 2. ", "Su faturası (429.0459 TRY)");
        Action("🛢️ 3. ", "Doğalgaz faturası (2491.0196 TRY)");
        Action("🛜 4. ", "İnternet fatarası (349.9999 TRY)");
        Action("📱 5. ", "Telefon faturası (759.4564 TRY)");

        Console.Write("\n🔎 Yapmak istediğiniz işlemi numerik olarak giriniz (1-7): ");
        if (!short.TryParse(Console.ReadLine(), out short act)) { Invalid(); return false; }

        Console.Write("\nGönderen hesaba ait hesap numarasını giriniz: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal senderId)) { Invalid(); return false; }

        var account = _myAccounts.FirstOrDefault(x => x.Id == senderId);

        if (account != null)
        {
            switch (act)
            {
                case 1:
                    account.Balance -= 1754.4561m;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                    break;
                case 2:
                    account.Balance -= 429.0459m;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                    break;
                case 3:
                    account.Balance -= 2491.0196m;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                    break;
                case 4:
                    account.Balance -= 349.9999m;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                    break;
                case 5:
                    account.Balance -= 759.4564m;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                    break;
                default:
                    Invalid();
                    break;
            }
            _summary.Add(new Summary()
            {
                Id = rnd.Next(10000, 99999),
                Time = DateTime.Now,
                Type = "Fatura Ödeme",
                Description = $"➕ Faturanız ödenmiştir",
                Amount = account.Balance
            });
        }
        else
        {
            AccountNotFound();
        }

        return true;
    }

    /// <summary>
    /// Kullanıcının hesap ve kredi kartı bakiyelerini gösterir.
    /// </summary>
    private static void ShowBalance()
    {
        ListingMyAccounts();
        ListingCreditCards();
    }

    /// <summary>
    /// Hesap hareket özetini gösterir. (Henüz tamamlanmamış)
    /// </summary>
    private static void Summary()
    {
        foreach (var item in _myAccounts)
        {
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Transfer işlemleri menüsünü gösterir ve seçim yapar.
    /// </summary>
    private static void Transfer()
    {
        Action("\n\n1. ", "Hesaplarım arası transfer");
        Action("2. ", "Başka hesaba transfer");

        Console.Write("\n🔎 Yapmak istediğiniz işlemi numerik olarak giriniz: ");

        if (!short.TryParse(Console.ReadLine(), out short inputVal)) { Invalid(); return; }

        switch (inputVal)
        {
            case 1:
                TransferAmongMyAccounts();
                break;
            case 2:
                TransferAnotherAccount();
                break;
            default:
                AccountNotFound();
                break;
        }
    }

    /// <summary>
    /// Başka bir hesaba transfer işlemini gerçekleştirir.
    /// </summary>
    private static void TransferAnotherAccount()
    {
        Console.Clear();

        ListingThirdPartyAccounts();

        Console.Write("\n🔎 Alıcı hesaba ait hesap numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int recieverId)) { Invalid(); return; }

        var recieverAccount = _thirdPartyAccounts.FirstOrDefault(x => x.Id == recieverId);

        if (recieverAccount != null)
        {
            Console.Clear();

            ListingMyAccounts();

            Console.Write("\n🔎 Gönderen hesaba ait hesap numarasını giriniz: ");
            if (!int.TryParse(Console.ReadLine(), out int senderId)) { Invalid(); return; }

            var senderAccount = _myAccounts.FirstOrDefault(x => x.Id == senderId);

            if (senderAccount != null)
            {
                Console.Write("🔎 Göndermek istediğiniz tutarı giriniz: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount)) { Invalid(); return; }

                if (transferAmount < 50) { Message("\n⚠️ Yatırmak istediğiniz tutar en az 50 TRY olmalıdır"); return; }
                else if (transferAmount > senderAccount.Balance) { Message("\n⚠️ Yetersiz bakiye"); return; }
                else
                {
                    senderAccount.Balance -= transferAmount;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {senderAccount.Balance} {senderAccount.Currency}");
                    _summary.Add(new Summary()
                    {
                        Id = rnd.Next(10000, 99999),
                        Time = DateTime.Now,
                        Type = "Para çekme",
                        Description = $"➕ Hesaptan {transferAmount} {senderAccount.Currency} transfer edildi.",
                        Amount = senderAccount.Balance
                    });
                }
            }
            else
            {
                AccountNotFound();
            }
        }
        else
        {
            AccountNotFound();
        }
    }

    /// <summary>
    /// Kendi hesapları arasında transfer işlemini gerçekleştirir.
    /// </summary>
    private static void TransferAmongMyAccounts()
    {
        Console.Clear();

        ListingMyAccounts();

        Console.Write("\n🔎 Alıcı hesaba ait hesap numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int recieverId)) { Invalid(); return; }

        var recieverAccount = _thirdPartyAccounts.FirstOrDefault(x => x.Id == recieverId);

        if (recieverAccount != null)
        {
            Console.Write("\n🔎 Gönderen hesaba ait hesap numarasını giriniz: ");
            if (!int.TryParse(Console.ReadLine(), out int senderId)) { Invalid(); return; }

            var senderAccount = _myAccounts.FirstOrDefault(x => x.Id == senderId);

            if (senderAccount != null)
            {
                Console.Write("🔎 Göndermek istediğiniz tutarı giriniz: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount)) { Invalid(); return; }

                if (transferAmount < 50) { Message("\n⚠️ Yatırmak istediğiniz tutar en az 50 TRY olmalıdır"); return; }
                else if (transferAmount > senderAccount.Balance) { Message("\n⚠️ Yetersiz bakiye"); return; }
                else
                {
                    senderAccount.Balance -= transferAmount;
                    Valid();
                    Console.WriteLine($"\nMevcut yeni bakiye: {senderAccount.Balance} {senderAccount.Currency}");
                    _summary.Add(new Summary()
                    {
                        Id = rnd.Next(10000, 99999),
                        Time = DateTime.Now,
                        Type = "Para çekme",
                        Description = $"➕ Hesaptan {transferAmount} {senderAccount.Currency} transfer edildi.",
                        Amount = senderAccount.Balance
                    });
                }
            }
            else
            {
                AccountNotFound();
            }
        }
        else
        {
            AccountNotFound();
        }
    }

    /// <summary>
    /// Para çekme işlemi gerçekleştirir.
    /// </summary>
    private static void WithdrawMoney()
    {
        Console.Write("\n🔎 Para çekmek istediğiniz hesaba ait hesap numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Invalid(); return; }

        var account = _myAccounts.FirstOrDefault(x => x.Id == id);

        if (account != null)
        {
            Console.Write("\nÇekmek istediğiniz tutarı giriniz: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount)) { Invalid(); return; }

            if (withdrawAmount < 50) { Message("\n⚠️ Çekmek istediğiniz tutar en az 50 TRY olmalıdır"); return; }
            else if (withdrawAmount > account.Balance) { Message("\n⚠️ Yetersiz bakiye"); return; }
            else
            {
                account.Balance -= withdrawAmount;
                Valid();
                Console.WriteLine($"\nMevcut yeni bakiye: {account.Balance} {account.Currency}");
                _summary.Add(new Summary()
                {
                    Id = rnd.Next(10000, 99999),
                    Time = DateTime.Now,
                    Type = "Para çekme",
                    Description = $"➕ Hesaptan {withdrawAmount} {account.Currency} çekildi.",
                    Amount = account.Balance
                });
            }
        }
        else
        {
            AccountNotFound();
        }
    }

    /// <summary>
    /// Başarılı işlem mesajı gösterir.
    /// </summary>
    private static void Valid()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✔️ İşleminiz başarıyla gerçekleşti");
        Console.ResetColor();
    }
}
