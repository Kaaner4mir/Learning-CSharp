using System.Text;

class Program
{
    static List<Questions> _questions = new List<Questions>();
    static int _questionCounter = 1;
    static int _yourScore = 0;

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        ExampleQuestions();

        foreach (var item in _questions)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{_questionCounter}. Soru: {item.Question}: ");
            string? answer = Console.ReadLine();

            if (!string.IsNullOrEmpty(answer))
            {
                if (answer.Trim().ToLower() == item.Answer.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    _yourScore += item.Point;
                    Console.WriteLine($"\n✔️ Tebrikler  +{item.Point}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n❌ Yanlış cevap");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nDoğru cevap: {item.Answer}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCevap boş olamaz, geçiliyor.");
            }

            Console.ResetColor();
            _questionCounter++;
            Continue();
        }

        Console.WriteLine($"\nQuiz tamamlandı! Toplam puanınız: {_yourScore}");
        Continue();
    }

    /// <summary>
    /// Soruları listeye ekler.
    /// </summary>
    private static void ExampleQuestions()
    {
        _questions.Add(new Questions { Id = 1, Question = "1 kilogram kaç gramdır?", Answer = "1000", Point = 5 });
        _questions.Add(new Questions { Id = 2, Question = "Türkiye'nin başkenti neresidir?", Answer = "Ankara", Point = 5 });
        _questions.Add(new Questions { Id = 3, Question = "Su kaç derecede kaynar? (Deniz seviyesinde)", Answer = "100", Point = 5 });
        _questions.Add(new Questions { Id = 4, Question = "En küçük asal sayı nedir?", Answer = "2", Point = 7 });
        _questions.Add(new Questions { Id = 5, Question = "Dünyanın en büyük okyanusu hangisidir?", Answer = "Pasifik Okyanusu", Point = 8 });
        _questions.Add(new Questions { Id = 6, Question = "İnsan vücudundaki en uzun kemik hangisidir?", Answer = "Uyluk kemiği", Point = 8 });
        _questions.Add(new Questions { Id = 7, Question = "Cumhuriyet ne zaman ilan edilmiştir? (Türkiye)", Answer = "1923", Point = 10 });
        _questions.Add(new Questions { Id = 8, Question = "Atatürk'ün doğum yılı nedir?", Answer = "1881", Point = 10 });
        _questions.Add(new Questions { Id = 9, Question = "Türkiye’nin en uzun nehri hangisidir?", Answer = "Kızılırmak", Point = 12 });
        _questions.Add(new Questions { Id = 10, Question = "Güneş sisteminde en büyük gezegen hangisidir?", Answer = "Jüpiter", Point = 12 });
        _questions.Add(new Questions { Id = 11, Question = "İstiklal Marşı'nın yazarı kimdir?", Answer = "Mehmet Akif Ersoy", Point = 15 });
        _questions.Add(new Questions { Id = 12, Question = "Osmanlı Devleti'nin kurucusu kimdir?", Answer = "Osman", Point = 15 });
        _questions.Add(new Questions { Id = 13, Question = "Dünya üzerinde en fazla kullanılan para birimi hangisidir?", Answer = "Dolar", Point = 15 });
        _questions.Add(new Questions { Id = 14, Question = "Kızıl gezegen olarak bilinen gezegenin adı nedir?", Answer = "Mars", Point = 17 });
        _questions.Add(new Questions { Id = 15, Question = "Vücudumuzdaki kanı hangi organ pompalar?", Answer = "Kalp", Point = 17 });
        _questions.Add(new Questions { Id = 16, Question = "Türkiye'nin en kalabalık şehri hangisidir?", Answer = "İstanbul", Point = 20 });
    }

    /// <summary>
    /// Kullanıcının devam etmesi için ekran temizliği ve bekleme sağlar.
    /// </summary>
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDevam etmek için bir tuşa basınız");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.CursorVisible = true;
    }
}


