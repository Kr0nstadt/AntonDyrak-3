using Implementation;

class MainClass
{
    static void Main()
    {
        string variarty = "fghj";
        Variety variety = new Variety(variarty);
        List<string> list = new List<string>();
        Rearrangement rar = new Rearrangement(variety,0,list);
        list.ToArray();
        list.Sort();
        foreach (string s in list)
        {
            Console.WriteLine(s);
        }
    }
}