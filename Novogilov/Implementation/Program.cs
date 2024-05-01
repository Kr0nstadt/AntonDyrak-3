using Implementation;


class MainClass
{
    static void Main()
    {
        string variarty = "fghj";
        Variety variety = new Variety(variarty);
        List<char[]> list = new List<char[]>();
        Rearrangement rar = new Rearrangement(variety);
        list = rar.result;
        foreach (char[] c in list)
        {
            foreach (char c2 in c)
            {
                Console.Write(c2);
            }
            Console.WriteLine();
        }
    }
}