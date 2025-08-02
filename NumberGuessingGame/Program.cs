using System;
using System.Text;

class Program
{
    static Random _rnd = new Random();
    static int attempt = 0;

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            int correctNumber = _rnd.Next(1, 101); // 1-100 arası dahil
            attempt = 0;

            while (attempt < 10)
            {
                Console.Write("\n❓Aklımdan 1 ile 100 arasında bir sayı tuttum, bakalım bilebilecek misin: ");
                if (!int.TryParse(Console.ReadLine(), out int inputVal))
                {
                    Invalid();
                    continue;
                }

                if (inputVal < 1 || inputVal > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Lütfen 1 ile 100 arasında bir sayı gir.");
                    Console.ResetColor();
                    continue;
                }

                if (correctNumber == inputVal)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n🚀 Vay canına! Zihnimi mi okudun? Bildin!");
                    Console.ResetColor();

                    Console.Write("\n🎲 Şansını tekrar denemek ister misin yoksa emekli mi oluyorsun? (E/H): ");
                    string? decision = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(decision))
                    {
                        Invalid();
                        return;
                    }

                    if (decision.Trim().ToLower() == "e")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (decision.Trim().ToLower() == "h")
                    {
                        Console.WriteLine("👋 Oyunu oynadığın için teşekkürler!");
                        return;
                    }
                    else
                    {
                        Invalid();
                        return;
                    }
                }
                else
                {
                    attempt++;
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"\n😅 Bu işte bir numara var… ama o bu değil! Kalan hakkın: {10 - attempt}");


                    if (inputVal < correctNumber)
                        Console.WriteLine("\n ⬆ Daha büyük bir sayı dene!");
                    else
                        Console.WriteLine("\n ⬇️ Daha küçük bir sayı dene!");

                    Console.ResetColor();
                }
            }

            if (attempt >= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Hakkın bitti! Doğru sayı: {correctNumber}");
                Console.ResetColor();

                Console.Write("\n🔁 Yeni bir oyun başlatmak ister misin? (E/H): ");
                string? restart = Console.ReadLine();

                Console.Clear();

                if (restart?.Trim().ToLower() != "e")
                {
                    Console.WriteLine("\n👋 Oyunu oynadığın için teşekkürler!");
                    Thread.Sleep(4000);
                    return;
                }
            }
        }
    }

    private static void Invalid()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Geçersiz bir işlem yaptınız!");
        Console.ResetColor();
        Continue();
    }

    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Devam etmek için bir tuşa basınız ▶️");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;
    }
}
