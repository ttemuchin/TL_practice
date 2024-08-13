using System.Text;
using System.Xml.Linq;

public class Program
{
    const string path = @"C:\Users\ttemuchin4\source\repos\TL_practice\Dictionary\dict.txt";

    public static void Main( string[] args )
    {
        bool active = true;
        Console.WriteLine( "## DICTIONARY ##" );
        Console.WriteLine( "Доступные команды: append, show, en, ru, end" );
        while ( active )
        {
            var dict = LoadDictFromFile();

            string cmd = Console.ReadLine();
            if ( cmd == "append" )
            {
                Append();
            }
            else if ( cmd == "show" )
            {
                PrintAllWords( dict );
            }
            else if ( cmd == "end" )
            {
                active = false;
            }
            else if ( cmd == "ru" )
            {
                Ru_En( dict );
            }
            else if ( cmd == "en" )
            {
                En_Ru( dict );
            }
        }
        Console.WriteLine( "## Thank you for using our app! ##" );
    }


    static Dictionary<string, string> LoadDictFromFile()
    {
        var dict = new Dictionary<string, string>();

        string line;
        StreamReader reader = new StreamReader( path );
        while ( ( line = reader.ReadLine() ) != null )
        {
            string[] en_ru = line.Split( ':' );
            dict.Add( en_ru[ 0 ], en_ru[ 1 ] );
        }
        reader.Close();

        return dict;
    }

    static void En_Ru( Dictionary<string, string> dict )
    {
        // с англ на рус
        Console.Write( "Введите слово на английском языке: " );
        string word = Console.ReadLine();
        if ( dict.TryGetValue( word, out string translation ) )
        {
            Console.WriteLine( translation );
        }
        else
        {
            Console.WriteLine( "Такого слова нет в словаре. Добавьте его!" );
        }
    }
    static void Ru_En( Dictionary<string, string> dict )
    {
        // с рус на англ
        Console.Write( "Введите слово на русском языке: " );
        string word = Console.ReadLine();
        bool flag = false;
        foreach ( var (en, ru) in dict )
        {
            if ( word == ru )
            {
                Console.WriteLine( en );
                flag = true;
            }
        }
        if ( !flag )
        {
            Console.WriteLine( "Кажется, такого слова в словаре ещё нет. Хотите добавить? Воспользуйтесь командой append!" );
        }
    }

    static void Append()
    {
        Console.Write( "Введите слово на английском языке: " );
        string en = Console.ReadLine();
        Console.Write( "Введите его перевод: " );
        string ru = Console.ReadLine();
        string pair = en + ":" + ru;

        using ( TextWriter writer = new StreamWriter( path, true ) )
        {
            writer.WriteLine( pair );
        }

    }
    static void PrintAllWords( Dictionary<string, string> dict )
    {
        int count = 0;
        foreach ( KeyValuePair<string, string> word in dict )
        {
            count++;
            Console.WriteLine( $"{count}.{word.Key} - {word.Value}" );
        }
    }
}