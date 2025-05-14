Console.CursorVisible = false;

Dictionary<ConsoleKey, string> keyActionMap = new Dictionary<ConsoleKey, string>();
keyActionMap.Add(ConsoleKey.A, "moveLeft");
keyActionMap.Add(ConsoleKey.D, "moveRight");
keyActionMap.Add(ConsoleKey.W, "moveUp");
keyActionMap.Add(ConsoleKey.S, "moveDown");
keyActionMap.Add(ConsoleKey.C, "clone");
keyActionMap.Add(ConsoleKey.Escape, "quitGame");

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

List<Character> characters = new List<Character>();

Point startingPosition = new Point(4, 0);
Player hero = new Player("Snake", "@", startingPosition, keyActionMap);
characters.Add(hero);

for (int i = 0; i < 10; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L", new Point(20 - i, 8));
    characters.Add(npc);
}

Level firstLevel = new Level();
firstLevel.Display();

foreach (Character element in characters)
{
    element.Display();
}
bool isPlaying = true;

while (isPlaying)
{
    // We're saving last characters count before the loop
    // so that the new clone will not perform it's action
    // untill next turn.
    // FIXME: If we add removing clones (or if any character
    // would be removed), it would crash.
    int charactersCount = characters.Count;
    for (int i = 0; i < charactersCount; i++)
    {
        Character element = characters[i];
        string chosenAction = element.ChooseAction();
        
        if (directionsMap.ContainsKey(chosenAction))
        {
            firstLevel.RedrawCell(element.position);
            Point direction = directionsMap[chosenAction];
            element.Move(direction, firstLevel);
            element.Display();
        }
        else
        {
            switch (chosenAction)
            {
                case "clone":
                    PlayerClone clone = new PlayerClone(hero.name, "C", startingPosition, keyActionMap, hero);
                    characters.Add(clone);
                    clone.Display();
                    break;
                case "quitGame":
                    isPlaying = false;
                    break;
            }
        }
    }
}

Console.SetCursorPosition(0, firstLevel.GetHeight());
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