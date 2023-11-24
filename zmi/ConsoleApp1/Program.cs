using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

enum Border
{
    MaxRight = 40,
    MaxBottom = 20
}

enum GameMode
{
    Normal,
    NoBorder
}

class SnakeGame
{
    private static int score = 0;
    private static bool gameover = false;
    private static Direction direction = Direction.Right;
    private static Snake snake;
    private static Food food;

    static async Task Main()
    {
        Console.Title = "Змейка";
        Console.CursorVisible = false;

        GameMode selectedMode = DisplayMenu();

        switch (selectedMode)
        {
            case GameMode.Normal:
                snake = new Snake();
                break;
            case GameMode.NoBorder:
                snake = new SnakeNoBorder();
                break;
        }

        food = new Food();

        Task gameTask = GameLoop();

        await gameTask;

        Console.Clear();
        Console.WriteLine("Игра окончена. Ваш счет: " + score);
    }

    private static GameMode DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Выберите режим игры:");

        string[] menuItems = { "Обычная змейка", "Змейка без границ" };
        int selectedItem = 0;

        while (true)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }

                Console.WriteLine($"   {menuItems[i]}   ");

                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedItem = (selectedItem - 1 + menuItems.Length) % menuItems.Length;
                    break;
                case ConsoleKey.DownArrow:
                    selectedItem = (selectedItem + 1) % menuItems.Length;
                    break;
                case ConsoleKey.Enter:
                    return selectedItem == 0 ? GameMode.Normal : GameMode.NoBorder;
            }

            Console.Clear();
        }
    }

    private static async Task GameLoop()
    {
        while (!gameover)
        {
            Draw();
            Update();
            await Task.Delay(100);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangeDirection(key);
            }
        }
    }

    private static void Draw()
    {
        Console.Clear();

        DrawBorders();
        snake.Draw();
        food.Draw();
        DrawScore();
    }

    private static void DrawBorders()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i <= (int)Border.MaxRight + 1; i++)
        {
            Console.Write("■");
        }

        for (int i = 1; i <= (int)Border.MaxBottom; i++)
        {
            Console.SetCursorPosition((int)Border.MaxRight + 1, i);
            Console.Write("■");
        }

        Console.SetCursorPosition(0, (int)Border.MaxBottom);
        for (int i = 0; i <= (int)Border.MaxRight + 1; i++)
        {
            Console.Write("■");
        }
    }

    private static void DrawScore()
    {
        Console.SetCursorPosition((int)Border.MaxRight - 10, (int)Border.MaxBottom + 1);
        Console.Write($"Яблоки: {score}");
    }

    private static void Update()
    {
        snake.Move(direction);

        if (snake.CollisionWithFood(food))
        {
            snake.Eat(food);
            food.Generate();
            score++;
        }

        if (snake.CollisionWithBorder() || snake.CollisionWithItself())
        {
            gameover = true;
        }
    }

    private static void ChangeDirection(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (direction != Direction.Down)
                    direction = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                if (direction != Direction.Up)
                    direction = Direction.Down;
                break;
            case ConsoleKey.LeftArrow:
                if (direction != Direction.Right)
                    direction = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                if (direction != Direction.Left)
                    direction = Direction.Right;
                break;
        }
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}

class Snake
{
    protected List<Point> body;
    protected Direction currentDirection;

    public Snake()
    {
        body = new List<Point>
        {
            new Point(10, 10),
            new Point(9, 10),
            new Point(8, 10)
        };

        currentDirection = Direction.Right;
    }

    public virtual void Move(Direction direction)
    {
        currentDirection = direction;

        Point head = body.First();
        Point newHead = new Point(head.X, head.Y);

        switch (direction)
        {
            case Direction.Up:
                newHead.Y--;
                break;
            case Direction.Down:
                newHead.Y++;
                break;
            case Direction.Left:
                newHead.X--;
                break;
            case Direction.Right:
                newHead.X++;
                break;
        }

        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1);
    }

    public void Eat(Food food)
    {
        body.Add(new Point(0, 0)); 
    }

    public bool CollisionWithFood(Food food)
    {
        return body.First().Equals(food.Position);
    }

    public bool CollisionWithItself()
    {
        Point head = body.First();
        return body.Skip(1).Any(segment => segment.Equals(head));
    }

    public virtual bool CollisionWithBorder()
    {
        Point head = body.First();
        return head.X < 0 || head.X >= (int)Border.MaxRight || head.Y < 0 || head.Y >= (int)Border.MaxBottom;
    }

    public virtual void Draw()
    {
        // Голова яшера
        Point head = body.First();
        Console.SetCursorPosition(head.X, head.Y);
        Console.Write("▲");

        // ноги
        foreach (var point in body.Skip(1))
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write("O");
        }
    }
}

class SnakeNoBorder : Snake
{
    public override void Move(Direction direction)
    {
        currentDirection = direction;

        Point head = body.First();
        Point newHead = new Point(head.X, head.Y);

        switch (direction)
        {
            case Direction.Up:
                newHead.Y = (newHead.Y - 1 + (int)Border.MaxBottom) % (int)Border.MaxBottom;
                break;
            case Direction.Down:
                newHead.Y = (newHead.Y + 1) % (int)Border.MaxBottom;
                break;
            case Direction.Left:
                newHead.X = (newHead.X - 1 + (int)Border.MaxRight) % (int)Border.MaxRight;
                break;
            case Direction.Right:
                newHead.X = (newHead.X + 1) % (int)Border.MaxRight;
                break;
        }

        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1);
    }

    public override bool CollisionWithBorder()
    {
        return false; // Без рниц тут
    }
}

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Point))
            return false;

        Point other = (Point)obj;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

class Food
{
    public Point Position { get; private set; }

    public Food()
    {
        Generate();
    }

    public void Generate()
    {
        Random random = new Random();
        Position = new Point(random.Next(1, (int)Border.MaxRight), random.Next(1, (int)Border.MaxBottom));
    }

    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write("■");
    }
}
