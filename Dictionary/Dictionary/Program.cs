using System.Text;
const string path = @"C:\Users\hp\source\repos\TL_practice\Dictionary\dict.txt";

Main();

static void Main()
{
    bool active = true;
    Console.WriteLine( "## DICTIONARY ##" );
    Console.WriteLine( "Доступные команды: append, show, en, ru, end" );
    while ( active )
    {
        var dict = OpenDictionary();

        string cmd = Console.ReadLine();
        if ( cmd == "append" )
        {
            Console.Write( "Введите слово на английском языке: " );
            string en = Console.ReadLine();
            Console.Write( "Введите его перевод: " );
            string ru = Console.ReadLine();
            string pair = en + ":" + ru;
            Append( pair );
        }
        else if ( cmd == "show" )
        {
            int count = 0;
            foreach ( var word in dict )
            {
                count++;
                Console.WriteLine( $"{count}.{word.Key} - {word.Value}" );
            }
        }
        else if ( cmd == "end" )
        {
            active = false;
        }
        else if ( cmd == "ru" )
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
        else if ( cmd == "en" )
        {
            // с англ на рус
            Console.Write( "Введите слово на английском языке: " );
            string word = Console.ReadLine();
            Console.WriteLine( dict[ word ] );
        }
    }
    Console.WriteLine( "## Thank you for using our app! ##" );
}
static Dictionary<string, string> OpenDictionary()
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
static void Append( string pair )
{
    using ( FileStream fstream = new FileStream( path, FileMode.Append, FileAccess.Write ) )
    using ( StreamWriter sw = new StreamWriter( fstream ) )
    {
        sw.WriteLine( pair );
    }
}