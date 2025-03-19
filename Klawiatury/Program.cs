Console.CursorVisible = false;
Player hero = new Player("Snake");

Console.WriteLine($"({hero.x}, {hero.y})");
hero.speed = 3;
hero.x = 119;
hero.y = 3;
while (true)
{
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");

    if (pressedKeyInfo.Key == ConsoleKey.A)
    {
        if (hero.x >= hero.speed)
        {
            hero.x -= hero.speed;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.D)
    {
        if (hero.x <= Console.BufferWidth - 1 - hero.speed)
        {
            hero.x += hero.speed;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.W)
    {
        if (hero.y >= hero.speed)
        {
            hero.y -= hero.speed;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.S)
    {
        if (hero.y <= Console.BufferHeight - 1 - hero.speed)
        {
            hero.y += hero.speed;
        }
    }

    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})     ");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);


/*
Player - klasa
 - hp - liczba
 - maxhp (domyslnie 100)
 - stamina
 - maxstamina
 - name - tekst
 - speed


Konrad - obiket typu gracz
 - hp - 100
 - maxhp - 100
 - stamina - 20
 -max stamina - 20
 - name - Konrad

 
Gremlin - obiket typu gracz
 - hp - 20
 - maxhp - 50
 - stamina - 120
 -max stamina - 120
 - name - Gremlin
*/