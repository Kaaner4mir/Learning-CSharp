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
                    ListingTasks();
                    UpdatingTask();
                    break;
                case 4:
                    ListingTasks();
                    DeletingTask();
                    break;
                case 5:
                    Exit();
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
    }

    private static void UpdatingTask()
    {
        Console.Write("🔎 Güncellemek istediğiniz görev numarasını giriniz: ");
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
                    task.TaskName = Console.ReadLine();
                    Valid();
                    break;
                case 2:
                    Console.Write("\n🖋️ Yeni görev açıklamasını giriniz: ");
                    task.TaskDescription = Console.ReadLine();
                    Valid();
                    break;
                case 3:
                    Console.Write("\n↩️ Yeni görev durumunu giriniz: ");
                    task.Status = Console.ReadLine();
                    Valid();
                    break;
                default:
                    Invalid();
                    break;
            }
        }
    }

    private static void DeletingTask()
    {
        Console.Write("🔎 Silmek istediğiniz görev numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Invalid(); return; }

        var task = _tasks.FirstOrDefault(x => x.Id == id);

        if (task == null)
            IdNotFound();
        else
        {
            _tasks.Remove(task);
            Valid();
        }
    }

    private static void Exit()
    {
        Console.Write("❓Çıkmak istediğinize emin misiniz?(E/H): ");
        string? act = Console.ReadLine();

        if (act == null)
            Invalid();
        else
        {
            if (act.ToLower() == "e")
                Environment.Exit(0);
            else if (act.ToLower() == "h")
                return;
            else
                Invalid();
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
        Action("5. ", "Çıkış                       |❌");
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


