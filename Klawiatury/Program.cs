Console.CursorVisible = false;

Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Player hero = new Player("Snake");

hero.speed = 1;
hero.position.x = 119;
hero.position.y = 3;

while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.position.x}, {hero.position.y})     ");

    Console.SetCursorPosition(hero.position.x, hero.position.y);
    Console.Write("@");
    
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    Console.SetCursorPosition(hero.position.x, hero.position.y);
    Console.Write(" ");

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        hero.position.x += direction.x * hero.speed;
        hero.position.y += direction.y * hero.speed;

        hero.position.x = Math.Clamp(hero.position.x, 0, Console.BufferWidth - 1);
        hero.position.y = Math.Clamp(hero.position.y, 0, Console.BufferHeight - 1);

        hero.speed += 1;
    }
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