using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/// <summary>
/// ATM simülasyonunu yöneten sınıftır. Para çekme, yatırma, hesap görüntüleme gibi işlemleri içerir.
/// </summary>
class Atm
{
    static List<MyAccounts> _myAccounts = new List<MyAccounts>();
    static List<CreditCards> _creditCards = new List<CreditCards>();
    static Random _idGenerator = new Random();

    /// <summary>
    /// Uygulamanın başlangıç noktasıdır. Ana menüyü göstererek kullanıcı işlemlerini yönetir.
    /// </summary>
    public static void Main()
    {
        ExampleAccounts();
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Operations();
            Console.Write("\nLütfen yapmak istediğiniz işlemi numerik olarak seçiniz: ");
            if (!ushort.TryParse(Console.ReadLine(), out ushort act)) { Invalid(); Continue(); continue; }
            Loading();

            switch (act)
            {
                case 1: Console.Clear(); ListingMyAccounts(); ListingCreditCards(); break;
                case 2: WithdrawMoney(); break;
                case 3: DepositMoney(); break;
                case 4: break;
                case 5: break;
                case 6: break;
                case 7: break;
                case 8: return;
                default: Invalid(); break;
            }
            Continue();
        }
    }

    /// <summary>
    /// Örnek banka hesabı ve kredi kartlarını listeye ekler.
    /// </summary>
    private static void ExampleAccounts()
    {
        _myAccounts.Add(new MyAccounts()
        {
            Id = _idGenerator.Next(1000000, 9999999),
            Name = "Ana hesap",
            Branch = "Ankara/Çankaya",
            Currency = "TRY",
            Balance = 478144m
        });

        _myAccounts.Add(new MyAccounts()
        {
            Id = _idGenerator.Next(1000000, 9999999),
            Name = "Birikim hesabı",
            Branch = "İstanbul/Kadıköy",
            Currency = "TRY",
            Balance = 2046047m
        });

        _creditCards.Add(new CreditCards()
        {
            Id = _idGenerator.Next(1000000, 9999999),
            Name = "Kredi kartı",
            Branch = "İstanbul/Kadıköy",
            Currency = "TRY",
            Balance = 200000m
        });
    }

    /// <summary>
    /// Konsolda basit bir yükleme animasyonu gösterir.
    /// </summary>
    private static void Loading()
    {
        Console.CursorVisible = false;
        char[] items = { '-', '\\', '|', '/', '-', '\\', '|', '/' };
        int loopCount = 0;
        int loopDuration = 50;

        while (loopCount < 4)
        {
            foreach (var item in items)
            {
                Console.Write(item);
                Thread.Sleep(loopDuration);
                Console.Clear();
            }
            loopCount++;
        }
        Console.CursorVisible = true;
    }

    /// <summary>
    /// Banka hesaplarını ekranda listeler.
    /// </summary>
    private static void ListingMyAccounts()
    {
        foreach (var item in _myAccounts)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"".PadLeft(8)}<< {item.Name} >>\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"🆔 Hesap numarası: {item.Id}\n" +
                              $"🏦 Şube adı      : {item.Branch}\n" +
                              $"💰 Para birimi   : {item.Currency}\n" +
                              $"💲 Bakiye        : {item.Balance} {item.Currency}\n" +
                              "-----------------------------------------");
        }
    }

    /// <summary>
    /// Kredi kartlarını ekranda listeler.
    /// </summary>
    private static void ListingCreditCards()
    {
        foreach (var item in _creditCards)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{"".PadLeft(8)}<< {item.Name} >>\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"🆔 Hesap numarası: {item.Id}\n" +
                              $"🏦 Şube adı      : {item.Branch}\n" +
                              $"💰 Para birimi   : {item.Currency}\n" +
                              $"💲 Bakiye        : {item.Balance} {item.Currency}\n" +
                              "-----------------------------------------");
        }
    }

    /// <summary>
    /// Kullanıcıdan bir tuşa basarak devam etmesini ister.
    /// </summary>
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n💡 Devam etmek için herhangi bir tuşa basınız");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;
        Loading();
    }

    /// <summary>
    /// Kullanıcıya geçersiz işlem uyarısı verir.
    /// </summary>
    private static void Invalid()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n❌ Geçersiz bir işlem yaptınız!");
        Console.ResetColor();
    }

    /// <summary>
    /// İşlemin başarıyla gerçekleştiğini bildirir.
    /// </summary>
    private static void Valid()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✔️ İşleminiz başarılı bir şekilde gerçekleşmiştir.");
        Console.ResetColor();
    }

    /// <summary>
    /// Menü seçeneklerini renklendirerek ekrana yazdırır.
    /// </summary>
    /// <param name="message1">Numaralı başlık</param>
    /// <param name="message2">Açıklama metni</param>
    private static void Action(string message1, string message2)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(message1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message2);
        Console.ResetColor();
    }

    /// <summary>
    /// Ana işlem menüsünü listeler.
    /// </summary>
    private static void Operations()
    {
        Action("1. ", "Bilgilerimi görüntüle    |📜");
        Action("2. ", "Para çekme               |💲");
        Action("3. ", "Para yatırma             |💲");
        Action("4. ", "Transfer işlemleri       |💸");
        Action("5. ", "Ödemeler                 |💳");
        Action("6. ", "Başvurular               |📑");
        Action("7. ", "Hesap özeti              |🖨️");
        Action("8. ", "Çıkış                    |🔚");
    }

    /// <summary>
    /// Para çekme işlemini gerçekleştirir.
    /// </summary>
    private static void WithdrawMoney()
    {
        ListingMyAccounts();
        ListingCreditCards();
        Console.Write("Lütfen para çekmek istediğiniz hesaba ait hesap numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Invalid(); return; }

        var account = _myAccounts.FirstOrDefault(x => x.Id == id);
        if (account != null)
        {
            Console.Write("\nÇekmek istediğiniz tutarı giriniz: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount)) { Invalid(); return; }

            if (withdrawAmount < 50)
                Message(ConsoleColor.Yellow, "\nÇekmek istediğiniz tutar en az 50 TRY olmalıdır!");
            else if (withdrawAmount > account.Balance)
                Message(ConsoleColor.Red, "\nYetersiz bakiye!");
            else
            {
                account.Balance -= withdrawAmount;
                Valid();
                Console.WriteLine($"Mevcut yeni bakiyeniz: {account.Balance} {account.Currency}");
            }
        }
        else
        {
            AccountNotFound();
        }
    }

    /// <summary>
    /// Para yatırma işlemini gerçekleştirir.
    /// </summary>
    private static void DepositMoney()
    {
        ListingMyAccounts();
        ListingCreditCards();
        Console.Write("Lütfen para yatırmak istediğiniz hesaba ait hesap numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Invalid(); return; }

        var account = _myAccounts.FirstOrDefault(x => x.Id == id);
        if (account != null)
        {
            Console.Write("\nYatırmak istediğiniz tutarı giriniz: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal depositMoney)) { Invalid(); return; }

            if (depositMoney < 50)
                Message(ConsoleColor.Yellow, "\nYatırmak istediğiniz tutar en az 50 TRY olmalıdır!");
            else
            {
                account.Balance += depositMoney;
                Valid();
                Console.WriteLine($"Mevcut yeni bakiyeniz: {account.Balance} {account.Currency}");
            }
        }
        else
        {
            AccountNotFound();
        }
    }

    /// <summary>
    /// Girilen hesap numarasına sahip bir hesap bulunamazsa kullanıcıyı bilgilendirir.
    /// </summary>
    private static void AccountNotFound()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nGirmiş olduğunuz hesap numarasına ait hesap bulunamadı!");
        Console.ResetColor();
    }

    /// <summary>
    /// Konsola belirtilen renkte mesaj yazdırır.
    /// </summary>
    /// <param name="color">Yazı rengi</param>
    /// <param name="message">Yazılacak mesaj</param>
    private static void Message(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}


