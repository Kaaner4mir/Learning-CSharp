using System.Text;

class Calculator
{
    static double memory = 0;

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
                    case 7: Root(); break;
                    case 8: Logarithm(); break;
                    case 9: Trigonometry(); break;
                    case 10: MemoryPlus(); break;
                    case 11: MemoryMinus(); break;
                    case 12: MemoryClear(); break;
                    case 13: MemoryRecall(); break;
                    case 14: Exit(); break;
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

    /// <summary> Kök işlemlerini yapar. </summary>
    private static void Root()
    {
        Console.Write("\nEnter the radicand: ");
        if (!double.TryParse(Console.ReadLine(), out double radicand))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid input! Radicand must be a number.");
            Console.ResetColor();
            return;
        }

        Console.Write("Enter the degree of the root: ");
        if (!int.TryParse(Console.ReadLine(), out int rootDegree) || rootDegree <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid root degree! It must be a positive integer greater than zero.");
            Console.ResetColor();
            return;
        }

        if (rootDegree % 2 == 0 && radicand < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou cannot take an even root of a negative number (result would be complex).");
            Console.ResetColor();
            return;
        }

        double result = Math.Pow(radicand, 1.0 / rootDegree);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{rootDegree}ᵗʰ root of {radicand} = {result:F4}");
        Console.ResetColor();
    }

    /// <summary> Logaritma işlemini yapar. </summary>
    private static void Logarithm()
    {
        Console.Write("\nEnter the number: ");
        if (!double.TryParse(Console.ReadLine(), out double num) || num <= 0) { Invalid(); return; }
        Console.Write("\nEnter the base number: ");
        if (!double.TryParse(Console.ReadLine(), out double baseNum) || baseNum <= 0 || baseNum == 1) { Invalid(); return; }

        double result = Math.Log(num) / Math.Log(baseNum);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nLog₍{baseNum}₎({num}) = {result:F4}");
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

    /// <summary> Trigonometrik işlemleri yapar. </summary>
    private static void Trigonometry()
    {
        TrigonometricOperations();
        Console.Write("\nSelect the action you want to perform: ");
        if (!short.TryParse(Console.ReadLine(), out short act)) { Invalid(); return; }

        switch (act)
        {
            case 1: Sine(); break;
            case 2: Cosine(); break;
            case 3: Tangent(); break;
            case 4: Cotangent(); break;
            case 5: Secant(); break;
            case 6: Cosecant(); break;
            default: Invalid(); break;
        }

    }

    /// <summary> Sinüs işlemini yapar. </summary>
    private static void Sine()
    {
        Console.Write("\nEnter the degree: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }

        double radian = degree * (Math.PI / 180);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSine {degree}° : {Math.Sin(radian)}");
        Console.ResetColor();
    }

    /// <summary> Kosinüs işlemini yapar. </summary>
    private static void Cosine()
    {
        Console.Write("\nEnter the degree: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }

        double radian = degree * (Math.PI / 180);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nCosine {degree}° : {Math.Cos(radian)}");
        Console.ResetColor();
    }

    /// <summary> Tanjant işlemini yapar. </summary>
    private static void Tangent()
    {
        Console.Write("\nEnter the degree: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }

        double radian = degree * (Math.PI / 180);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\\nTangent {degree}° : {Math.Tan(radian)}");
        Console.ResetColor();
    }

    /// <summary> Kotanjant işlemini yapar. </summary>
    private static void Cotangent()
    {
        Console.Write("\nEnter the degree: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }

        double radian = degree * (Math.PI / 180);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nCotangent {degree}° : {1 / Math.Tan(radian)}");
        Console.ResetColor();
    }

    /// <summary> Sekant işlemini yapar. </summary>
    private static void Secant()
    {
        Console.Write("\nEnter the degree: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }

        double radian = degree * (Math.PI / 180);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSecant {degree}° : {1 / Math.Cos(radian)}");
        Console.ResetColor();
    }

    /// <summary> Kosekant işlemini yapar. </summary>
    private static void Cosecant()
    {
        Console.Write("\nEnter the degree: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }

        double radian = degree * (Math.PI / 180);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nCosecant {degree}° : {1 / Math.Sin(radian)}");
        Console.ResetColor();
    }

    /// <summary> İstenilen sayıyı hazıfaya ekler. </summary>
    private static void MemoryPlus()
    {
        Console.Write("\nEnter the number you want to add to memory: ");
        if (!double.TryParse(Console.ReadLine(), out double addNumber)) { Invalid(); return; }

        memory += addNumber;

        Valid();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMemory: {memory}  <>  Added: {addNumber}");
        Console.ResetColor();
    }

    /// <summary> İstenilen sayıyı hafızadan siler. </summary>
    private static void MemoryMinus()
    {
        Console.Write("\nEnter the number you want to remove from memory: ");
        if (!double.TryParse(Console.ReadLine(), out double addNumber)) { Invalid(); return; }

        memory -= addNumber;

        Valid();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMemory: {memory}  <>  Deleted: {addNumber}");
        Console.ResetColor();
    }

    /// <summary> Hafızayı sıfırlar. </summary>
    private static void MemoryClear()
    {
        Valid();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMemory: {memory}");
        Console.ResetColor();
    }

    /// <summary> Hafızayı ekrana getirir. </summary>
    private static void MemoryRecall()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMemory: {memory}");
        Console.ResetColor();
    }

    /// <summary> Çıkış işlemini başlatır. </summary>
    private static void Exit()
    {
        Console.Write("\nAre you sure you want to exit (Y/N): ");
        string? act = Console.ReadLine();

        if (string.IsNullOrEmpty(act) || string.IsNullOrWhiteSpace(act)) { Invalid(); return; }
        if (act.ToLower() == "y")
        {
            Environment.Exit(0);
        }
        else if (act.ToLower() == "n")
        {
            return;
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Trigonometrik operasyonları numaralandırır ve renklendirir.
    /// Konsolda numarayı kırmızı işlemi is beyaz renkte yazar.
    /// </summary>
    private static void TrigonometricOperations()
    {
        Console.Clear();
        Operation("1. ", "Sine        | 📐");
        Operation("2. ", "Cosine      | 📐");
        Operation("3. ", "Tangent     | 📐");
        Operation("4. ", "Cotange     | 📐");
        Operation("5. ", "Secant      | 📐");
        Operation("6. ", "Cosecan     | 📐");
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

    /// <summary> İşlem başarılı bir şekilde gerçekleştiğinde bilgi mesajı verir. </summary>
    private static void Valid()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✔️ Your transaction has been successfully completed..");
        Console.ResetColor();
        Console.CursorVisible = true;
    }
}