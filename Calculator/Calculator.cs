using Microsoft.VisualBasic;
using System.Text;

class Calculator
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            MathOperations();
            Console.Write("\nSelect the action you want to perform: ");
            if (!short.TryParse(Console.ReadLine(), out short act) || act < 1 || act > 14) { Invalid(); return; }
            try
            {
                switch (act)
                {
                    case 1: BasicOperation((a, b) => a + b); break;
                    case 2: BasicOperation((a, b) => a - b); break;
                    case 3: BasicOperation((a, b) => a * b); break;
                    case 4: BasicOperation((a, b) => { if (b == 0) throw new DivideByZeroException(); return a / b; }); break;
                    case 5: Factorial(); break;
                    case 6: Exponentiation(); break;
                    default: Invalid(); break;
                }
                Continue();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Hata: {ex.Message}");
                Console.ResetColor();
                Continue();
            }
        }
    }
    /// <summary>
    /// Matematiksel operasyonları numaralandırır ve renklendirir.
    /// Konsolda numarayı kırmızı, işlemi ise beyaz renkte yazar.
    /// </summary>
    /// <param name="number"> İşlemenin numarasını temsil eder (örn. "1. ", "2. "). </param>
    /// <param name="operation"> İşlemenin adını ve isteğe bağlı olarak emojisini içerir. </param>
    private static void Operation(string number, string operation)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(number);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(operation);
        Console.ResetColor();
    }

    /// <summary> Matematiksel operasyonları listeler. </summary>
    private static void MathOperations()
    {
        Operation(" 1. ", "Addition         |➕");
        Operation(" 2. ", "Subtraction      |➖");
        Operation(" 3. ", "Multiplication   |❌");
        Operation(" 4. ", "Division         |➗");
        Operation(" 5. ", "Factorial        |❗");
        Operation(" 6. ", "Exponentiation   |🔼");
        Operation(" 7. ", "Root             |🔽");
        Operation(" 8. ", "Logarithm        |📊");
        Operation(" 9. ", "Trigonometry     |📐");
        Operation("10. ", "M+               |➕");
        Operation("11. ", "M-               |➖");
        Operation("12. ", "MC               |🆑");
        Operation("13. ", "MR               |🔢");
        Operation("14. ", "Exit             |🔚");
    }

    /// <summary> Basit matematiksel işlemler için kullanıcıdan iki sayı alır ve verilen işlemi uygular. </summary>
    /// <param name="operation"> İki double parametre alan ve double döndüren matematiksel işlem (örneğin toplama, çarpma vb.). </param>
    private static void BasicOperation(Func<double, double, double> operation)
    {
        Console.Write("\nEnter the first number: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) { Invalid(); return; }
        Console.Write("Enter the second number: ");
        if (!double.TryParse(Console.ReadLine(), out double b)) { Invalid(); return; }

        double result = operation(a, b);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✔️ Result: {result}");
        Console.ResetColor();
    }

    /// <summary> Faktöriyel işlemini yapar. </summary>
    private static void Factorial()
    {
        Console.Write("\nEnter the number: ");
        if (!int.TryParse(Console.ReadLine(), out int a) || a < 0) { Invalid(); return; }

        long result = 1;

        for (int i = a; i > 0; i--) result *= i;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✔️ {a}!: {result}");
        Console.ResetColor();

    }

    /// <summary> Üs alma işlemini yapar. </summary>
    private static void Exponentiation()
    {
        Console.Write("\nEnter the base number: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) { Invalid(); return; }
        Console.Write("Enter the exponent number: ");
        if (!double.TryParse(Console.ReadLine(), out double b)) { Invalid(); return; }

        if (a == 0 && b == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUNDEFINED");
            Console.ResetColor();
            Continue();
            return;
        }

        double result = Math.Pow(a, b);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nResult: {result}");
        Console.ResetColor();
    }

    /// <summary> Herhangi bir tuşa basılana kadar ekranı bekletir. </summary>
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPress any key to continue");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;
    }

    /// <summary> Geçersiz bir işlem yapıldığında uyarı mesajı verir ve bir string döner. </summary>
    private static void Invalid()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n❌ You have performed an invalid operation.");
        Continue();
        Console.ResetColor();
        Console.CursorVisible = true;
    }
}