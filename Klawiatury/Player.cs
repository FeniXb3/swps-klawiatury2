
class Player : Character
{
    public string chosenAction;
    Dictionary<ConsoleKey, string> keyBindings;

    public Player(string name, string avatar, Point position, Dictionary<ConsoleKey, string> keyActionMap) : base(name, avatar, position)
    {
        keyBindings = keyActionMap;
    }

    public override string ChooseAction()
    {
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
        chosenAction = keyBindings.GetValueOrDefault(pressedKeyInfo.Key, "none");

        return chosenAction;
    }

    public override void Move(Point direction, Level level)
    {
        base.Move(direction, level);
        // speed += 1;
    }
}