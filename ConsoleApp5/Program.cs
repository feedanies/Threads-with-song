using System.Diagnostics;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string edge = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            string song1Path = Path.GetFullPath("song1.mp3");
            string song2Path = Path.GetFullPath("song2.mp3");

            Process? song1 = null;
            Process? song2 = null;


            Thread menuThread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - 1ci mahnini ac (Lele Pons-Se te nota)");
                    Console.WriteLine("2 - 2ci mahnini ac (Bebe Rexha-Say my name)");
                    Console.WriteLine("3 - Her ikisini bagla");
                    Console.WriteLine("4 - 1ci mahnini bagla");
                    Console.WriteLine("5 - 2ci mahnini bagla");
                    Console.WriteLine("0 - Cixis");

                    Console.Write("Seciminiz: ");
                    var key = Console.ReadKey().Key;
                    Console.WriteLine();

                    if (key == ConsoleKey.D1)
                    {
                        if (song1 == null)
                        {
                            Thread player1 = new Thread(() =>
                            {
                                song1 = Process.Start(edge, $"--user-data-dir=C:\\Temp\\player1 --no-first-run \"{song1Path}\"");
                                Console.WriteLine("1ci mahni acildi...");
                            });
                            player1.IsBackground = true;
                            player1.Start();
                        }
                        else
                        {
                            Console.WriteLine("Hal-hazirda 1ci mahni oxunur...");
                        }
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        if (song2 == null)
                        {
                            Thread player2 = new Thread(() =>
                            {
                                song2 = Process.Start(edge, $"--user-data-dir=C:\\Temp\\player2 --no-first-run \"{song2Path}\"");
                                Console.WriteLine("2ci mahni acildi...");
                            });
                            player2.IsBackground = true;
                            player2.Start();
                        }
                        else
                        {
                            Console.WriteLine("Hal-hazirda 2ci mahni oxunur...");
                        }
                    }
                    else if (key == ConsoleKey.D3)
                    {
                        if(song1 != null && song2 != null)
                        {
                            if (song1 != null) { song1.Kill(); song1 = null; }
                            if (song2 != null) { song2.Kill(); song2 = null; }
                            Console.WriteLine("Her iki mahni baglandi...");
                        }
                        else if(song1!=null && song2 == null)
                        {
                            Console.WriteLine("Hal-hazirda yalniz 1ci mahni oxunur...");
                        }
                        else if (song1 == null && song2 != null)
                        {
                            Console.WriteLine("Hal-hazirda yalniz 2ci mahni oxunur...");
                        }
                        else
                        {
                            Console.WriteLine("Hecbir mahni oxunmur...");
                        }
                    }
                    else if (key == ConsoleKey.D4)
                    {
                        if (song1 != null) { song1.Kill(); song1 = null; Console.WriteLine("1ci mahni baglandi..."); }
                        else
                        {
                            Console.WriteLine("Hal-hazirda 1ci mahni oxunmur...");
                        }
                        
                    }
                    else if (key == ConsoleKey.D5)
                    {
                        if (song2 != null) { song2.Kill(); song2 = null; Console.WriteLine("2ci mahni baglandi..."); }
                        else
                        {
                            Console.WriteLine("Hal-hazirda 2ci mahni oxunmur...");
                        }
                    }
                    else if (key == ConsoleKey.D0)
                    {
                        if (song1 != null) { song1.Kill(); }
                        if (song2 != null) { song2.Kill(); }
                        break;
                    }
                }
            });
            menuThread.Start();

            Console.WriteLine("Main thread end...");



        }
    }
}
