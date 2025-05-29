// See https://aka.ms/new-console-template for more information

string a = "3.123";

Convert.ToDecimal(a);

string[] myArray = { "apple", "banana", "cherry" };
Array.Sort(myArray);

RPG();

static void CheckPermissions(string role, int level)
{
    for (int i = 0; i < 100; i++)
    {
        break;
    }


    if (role.Contains("Admin"))
    {
        switch (level)
        {
            case > 55:
                Console.WriteLine("Welcome, Super Admin user.");
                break;
            case < 55:
                Console.WriteLine("Welcome, Super Admin user.");
                break;
            default:
                Console.WriteLine("Welcome, Admin user.");
                break;
        }
    }
    else if (role.Contains("Manager"))
    {
        switch (level)
        {
            case > 20:
                Console.WriteLine("Contact an Admin for access.");
                break;
            default:
                Console.WriteLine("You do not have sufficient privileges.");
                break;
        }
    }
    else
    {
        Console.WriteLine("You do not have sufficient privileges.\r\n");
    }

}

static void RPG()
{
    var HeroHP = 10;
    var MonsterHP = 10;

    do
    {
        Random dice = new Random();
        var heroAtk = dice.Next(10) + 1;
        //hero attacks
        MonsterHP = MonsterHP - heroAtk;
        Console.WriteLine($"Monster was damaged and lost {heroAtk} health and now has {MonsterHP} health");

        var monsterAtk = dice.Next(10) + 1;
        HeroHP = HeroHP - monsterAtk;
        Console.WriteLine($"Hero was damaged and lost {monsterAtk} health and now has {HeroHP} health");


    } while (HeroHP > 0 && MonsterHP > 0);

    Console.WriteLine($"{(HeroHP > 0 ? "Hero" : "Monster")} wins!");
}

