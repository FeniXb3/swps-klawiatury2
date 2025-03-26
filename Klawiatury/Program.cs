﻿Console.CursorVisible = false;
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

    int directionX;
    int directionY;

    switch (pressedKeyInfo.Key)
    {
        case ConsoleKey.A:
            directionX = -hero.speed;
            directionY = -0;
            break;
        case ConsoleKey.D:
            directionX = hero.speed;
            directionY = 0;
            break;
        case ConsoleKey.W:
            directionX = -0;
            directionY = -hero.speed;
            break;
        case ConsoleKey.S:
            directionX = 0;
            directionY = hero.speed;
            break;
        default:
            directionX = 0;
            directionY = 0;
            break;
    }

    hero.x += directionX;
    hero.y += directionY;

    hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
    hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);

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