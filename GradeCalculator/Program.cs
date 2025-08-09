using System.Text;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            try
            {
                Console.Clear();
                Console.Write("🔘 Sınav sayısını giriniz: ");
                if (!short.TryParse(Console.ReadLine(), out short gradeNumber)) { Invalid(); continue; }

                double totalGrade = 0;

                for (int i = 0; i < gradeNumber; i++)
                {
                    Console.Write($"\n🖊️ {i + 1}. sınav notunuzu giriniz: ");
                    if (!double.TryParse(Console.ReadLine(), out double grade)) { Invalid(); continue; }
                    totalGrade += grade;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nOrtalamanız: {totalGrade / gradeNumber}");
                Console.ResetColor();

                Continue();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
    private static void Invalid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n❗Geçersiz bir işlem yaptınız");
        Console.ResetColor();
        Continue();
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
}