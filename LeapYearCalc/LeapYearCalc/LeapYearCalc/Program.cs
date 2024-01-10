using static System.Console;
//using Wpf = Microsoft.Win32;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                ShowMenu();

                var input = ReadLine();

                switch (input)
                { //ReadKey().KeyChar) {
                    case "1": CalcualteLeapYear(); break;
                    case "99": SplitString(); break;
                    case "0": WriteLine(); return;

                    default: ShowMenu(); break;
                }
            }
            catch (Exception ex)
            {
                WriteLine();
                WriteLine("There was an error: ");
                while (ex != null)
                {
                    WriteLine(ex.Message);
                    ex = ex.InnerException;
                }
            }

            WriteLine();
            WriteLine("Press <ENTER> to return to menu.");
            ReadLine();
        }
    }

    private static void CalcualteLeapYear()
    {
        WriteLine("Enter year: ");
        var year = float.Parse(ReadLine());

        if(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
        {
            WriteLine($"The year {year} is a leap year.");
        }
        else
        {
            WriteLine($"The year {year} is not a leap year.");
        }

    }

    private static void SplitString()
    {
        WriteLine("Hit <Enter> to choose file with string(s) to read.");
        ReadLine();
        WriteLine($"Number of strings = {HandleItemLine(GetContent(GetFileDialog("pub")))}");
    }

    private static int HandleItemLine(string line)
    {
        return line
          .Split(new char[] { ' ', '\r', '\n' })
          .Where(c => !string.IsNullOrEmpty(c))
          .ToArray()
          .Count();
    }

    public static void ShowMenu()
    {
        Clear();
        WriteLine("PREREQ:");
        WriteLine("1. Set first req here,");
        WriteLine("2. Set second req here");
        WriteLine("");
        WriteLine("- Select DecryptionService command.");
        WriteLine("");
        WriteLine(" 1) Calculate Leap Year.");
        WriteLine(" 2) Split a string.");
        WriteLine(" 0) Exit");

        WriteLine("");
        Write(" > ");
    }

    private static Stream GetFileDialog(string suffix)
    {
        //Wpf.OpenFileDialog openFileDialog = new Wpf.OpenFileDialog
        //{
        //    //InitialDirectory = Environment.CurrentDirectory,
        //    Filter = $"{char.ToUpper(suffix[0]) + suffix.Substring(1)} files (*.{suffix})|*.{suffix}|All files (*.*)|*.*",
        //    FilterIndex = 1,
        //    RestoreDirectory = true
        //};

        //if ((bool)openFileDialog.ShowDialog())
        //{
        //    //Read the contents of the file into a stream
        //    return openFileDialog.OpenFile();
        //}

        return null;
    }

    private static string GetContent(Stream stream)
    {
        stream.Position = 0;

        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}

