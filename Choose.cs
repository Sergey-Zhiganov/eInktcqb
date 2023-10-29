using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проводник
{
    internal class Choose
    {
        public static void Disk()
        {
            Arrow arrow = new Arrow();
            DriveInfo[] drivers = DriveInfo.GetDrives();
            Console.WriteLine("Выбор диска:");
            foreach (DriveInfo driver in drivers)
            {
                Console.WriteLine($"  {driver.Name} (свободно {Math.Round((double)driver.TotalFreeSpace / 1073741824, 2)} ГБ / {Math.Round((double)driver.TotalSize / 1073741824, 2)} ГБ)");
            }
            int pos = arrow.Show(1, drivers.Length);
            if (pos == -1)
            {
                Console.SetCursorPosition(0, drivers.Length + 1);
                return;
            }
            Directories(drivers[pos - 1].Name);
            Console.Clear();
        }
        private static void Directories(string p)
        {
            while (true)
            {
                Arrow arrow = new Arrow();
                string[] paths = Directory.GetDirectories(p);
                string[] pathsFiles = Directory.GetFiles(p);
                Print(paths, pathsFiles, p);
                int pos = arrow.Show(1, paths.Length + pathsFiles.Length);
                if (pos == -1)
                {
                    return;
                }
                else if (pos < -1)
                {
                    int y = Console.GetCursorPosition().Top;
                    Console.SetCursorPosition(0, paths.Length + pathsFiles.Length + 5);
                    Files.Main(pos, p, y, paths, pathsFiles);
                }
                else if (pos <= paths.Length)
                {
                    Directories(paths[pos - 1]);
                }
                else
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = pathsFiles[pos - paths.Length - 1],
                        UseShellExecute = true
                    });
                }
            }
        }
        private static void Print(string[] paths, string[] pathsFiles, string p)
        {
            Console.Clear();
            Console.Write("Текущая папка: ");
            if (p.Substring(p.LastIndexOf("\\") + 1) != "")
            {
                Console.Write(p.Substring(p.LastIndexOf("\\") + 1));
            }
            else
            {
                Console.WriteLine(p);
            }
            string[,] pathsData = new string[paths.Length + pathsFiles.Length, 2];
            int a = 1;
            int num = Console.GetCursorPosition().Left;
            int b = 1;
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    Console.SetCursorPosition(num + 7, 0);
                    Console.WriteLine("Последнее изменение");
                }
                try
                {
                    foreach (string path in paths)
                    {
                        string paths1 = path.Substring(path.LastIndexOf("\\") + 1);
                        if (paths1.Length > num)
                        {
                            num = paths1.Length;
                        }
                        if (i == 1)
                        {
                            Console.WriteLine("  " + paths1);
                            Console.SetCursorPosition(num + 7, a);
                            Console.WriteLine(Directory.GetLastWriteTime(path));
                            a++;
                        }
                    }
                }
                catch { }
                try
                {
                    foreach (string path in pathsFiles)
                    {
                        string paths1 = path.Substring(path.LastIndexOf("\\") + 1);
                        if (paths1.Length > num)
                        {
                            num = paths1.Length;
                        }
                        if (i == 1)
                        {
                            Console.WriteLine("  " + paths1);
                            Console.SetCursorPosition(num + 7, a);
                            Console.WriteLine(File.GetLastWriteTime(path));
                            a++;
                        }
                    }
                }
                catch { }
            }
            Console.WriteLine();
            Console.WriteLine("F1 - Создание папки");
            Console.WriteLine("F2 - Создание файла");
            Console.WriteLine("F3 - Удаление папки/файла");
        }
    }
}
