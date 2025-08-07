using System.Text;

class Program
{
    static Random _rnd = new Random();
    static List<Task> _tasks = new List<Task>();

    public static void Main()
    {
        ExampleTasks();
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();

            Operations();

            Console.Write("\n🔎 Lütfen yapmak istediğiniz işlemi numerik olarak giriniz: ");
            if (!short.TryParse(Console.ReadLine(), out short inputVal)) { Invalid(); continue; }
            Loading();
            switch (inputVal)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    ListingTasks();
                    break;
                case 3:
                    UpdatingTask();
                    break;
                default:
                    Invalid();
                    break;
            }
            Continue();
            Loading();
        }
    }
    private static void AddTask()
    {
        try
        {
            Console.Write("➕ Görev adını giriniz: ");
            string? taskName = Console.ReadLine();

            Console.Write("🖋️ Görevin açıklamasını giriniz: ");
            string? taskDescription = Console.ReadLine();

            Console.Write("↩️ Öncelik durumunu giriniz: ");
            string? priority = Console.ReadLine();

            _tasks.Add(new Task()
            {
                Id = _rnd.Next(1000, 9999),
                TaskName = taskName,
                TaskDescription = taskDescription,
                DateOfCreation = DateTime.Now,
                EndTime = DateTime.Now.AddDays(5),
                Status = "Yapılacak"
            });
            Valid();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }
    }
    private static void ListingTasks()
    {
        Console.Clear();
        foreach (var item in _tasks)
        {
            Action("Görev Numarası     : ", $"{item.Id}");
            Action("Görev Adı          : ", $"{item.TaskName}");
            Action("Açıklama           : ", $"{item.TaskDescription}");
            Action("Oluşturulma Tarihi : ", $"{item.DateOfCreation}");
            Action("Bitiş Tarihi       : ", $"{item.EndTime}");
            Action("Durum              : ", $"{item.Status}");

            Console.WriteLine(new string('-', 40));
        }
    }
    private static void ExampleTasks()
    {
        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Rapor Hazırlama",
            TaskDescription = "Aylık satış raporunu hazırlama.",
            DateOfCreation = DateTime.Now.AddDays(-2),
            EndTime = DateTime.Now.AddDays(3),
            Status = "Yapılacak"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Toplantı Planlama",
            TaskDescription = "Pazartesi günü müşteri toplantısını organize et.",
            DateOfCreation = DateTime.Now.AddDays(-1),
            EndTime = DateTime.Now.AddDays(2),
            Status = "Devam Ediyor"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "E-posta Gönderme",
            TaskDescription = "Tüm ekibe proje güncellemesi e-postası gönder.",
            DateOfCreation = DateTime.Now,
            EndTime = DateTime.Now.AddDays(1),
            Status = "Tamamlandı"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Sunum Hazırlama",
            TaskDescription = "Yeni ürün tanıtım sunumunu hazırla.",
            DateOfCreation = DateTime.Now.AddDays(-4),
            EndTime = DateTime.Now.AddDays(5),
            Status = "Yapılacak"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Kod Revizyonu",
            TaskDescription = "Son commit'lerdeki kodları gözden geçir.",
            DateOfCreation = DateTime.Now.AddDays(-3),
            EndTime = DateTime.Now.AddDays(2),
            Status = "Devam Ediyor"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Veri Analizi",
            TaskDescription = "Geçen ayın satış verilerini analiz et.",
            DateOfCreation = DateTime.Now.AddDays(-5),
            EndTime = DateTime.Now.AddDays(4),
            Status = "Yapılacak"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Müşteri Görüşmesi",
            TaskDescription = "Yeni müşteri ile ilk toplantıyı yap.",
            DateOfCreation = DateTime.Now.AddDays(-2),
            EndTime = DateTime.Now.AddDays(1),
            Status = "Tamamlandı"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Depo Kontrolü",
            TaskDescription = "Stok seviyelerini kontrol et.",
            DateOfCreation = DateTime.Now.AddDays(-1),
            EndTime = DateTime.Now.AddDays(3),
            Status = "Devam Ediyor"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Fatura Kesme",
            TaskDescription = "Bu ayki müşterilere faturaları gönder.",
            DateOfCreation = DateTime.Now.AddDays(-3),
            EndTime = DateTime.Now.AddDays(2),
            Status = "Devam ediyor"
        });

        _tasks.Add(new Task()
        {
            Id = _rnd.Next(1000, 9999),
            TaskName = "Sosyal Medya Paylaşımı",
            TaskDescription = "Yeni kampanya görsellerini paylaş.",
            DateOfCreation = DateTime.Now,
            EndTime = DateTime.Now.AddDays(1),
            Status = "Yapılacak"
        });

    }
    private static void UpdatingTask()
    {
        Console.Clear();
        ListingTasks();
        Console.Write("🔎 Güncellemek istediğiniz görevini numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Invalid(); return; }

        var task = _tasks.FirstOrDefault(x => x.Id == id);

        if (task == null)
            IdNotFound();
        else
        {
            Console.Clear();
            Action("1. ", "Görev adı            |➕");
            Action("2. ", "Görev açıklaması     |🖋️");
            Action("3. ", "Öncelik durumu       |↩️");

            Console.Write("\n🔃 Lütfen güncellemek istediğiniz özelliği numerik olarak seçiniz: ");
            if (!short.TryParse(Console.ReadLine(), out short inputVal)) { Invalid(); return; }

            switch (inputVal)
            {
                case 1:
                    Console.Write("\n➕ Yeni görev adını giriniz: ");
                    string? newTaskName = Console.ReadLine();
                    task.TaskName = newTaskName;
                    Valid();
                    break;
                case 2:
                    Console.Write("\n🖋️ Yeni görev açıklamasını giriniz: ");
                    string? newTaskDescription = Console.ReadLine();
                    task.TaskDescription = newTaskDescription;
                    Valid();
                    break;
                case 3:
                    Console.Write("\n↩️ Yeni görev açıklamasını giriniz: ");
                    string? newStatus = Console.ReadLine();
                    task.Status = newStatus;
                    Valid();
                    break;
                default:
                    Invalid();
                    break;

            }
        }

    }
    private static void Action(string message1, string message2)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(message1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message2);
        Console.ResetColor();
    }
    private static void Operations()
    {
        Action("1. ", "Görev ekleme                |➕");
        Action("2. ", "Görev listeleme             |📋");
        Action("3. ", "Görev güncelleme            |🔃");
        Action("4. ", "Görev silme                 |🗑️");
        Action("5. ", "Görev durumu değiştirme     |💱");
        Action("6. ", "Çıkış                       |❌");
    }
    private static void Invalid()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n❌ Yapmak istediğiniz işlem geçersizdir!");
        Console.ResetColor();
    }
    private static void Valid()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✔️ İşleminiz başarılı bir şekilde gerçekleşti");
        Console.ResetColor();
    }
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDevam etmek için bir tuşa basınız ▶️");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;
    }
    private static void IdNotFound()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n🆔 ID bulunamadı!");
        Console.ResetColor();
    }
    private static void Loading()
    {
        Console.CursorVisible = false;
        Console.Clear();

        int loopTime = 0;
        int loopDuration = 50;

        char[] items = { '-', '\\', '|', '/', '-', '\\', '|', '/' };

        while (loopTime < 4)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
                Thread.Sleep(loopDuration);
                Console.Clear();
            }
            loopTime++;
        }
        Console.CursorVisible = true;
    }
}