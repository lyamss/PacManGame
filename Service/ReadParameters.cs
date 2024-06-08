using Raylib_cs;

namespace PacMan.Service
{
    public static class ReadParameters
    {
        private static string Help =
        @"Commands:
        `-Help` or `-h` | Shows this menu
        `-FPS`          | Sets the games frame rate (Default: Unlimited)";

        public static void SelectParam(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "-fps":
                        if (int.TryParse(args[++i], out int fps))
                            Raylib.SetTargetFPS(Math.Max(1, fps));
                        break;
                    case "-h":
                    case "-help":
                        Console.WriteLine(Help);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}