using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проводник
{
    internal class Files
    {
        public static void Main(int pos, string p, int y, string[] paths, string[] pathsFiles)
        {
            if (pos == -2)
            {
                DirAdd(p);
            }
            else if (pos == -3)
            {
                FileAdd(p);
            }
            else if (pos == -4)
            {
                Delete(y, paths, pathsFiles);
            }
        }
        private static void DirAdd(string p)
        {
            Console.Write("Введите название папки: ");
            string folderName = Console.ReadLine();
            Directory.CreateDirectory($"{p}\\{folderName}");
        }
        private static void FileAdd(string p)
        {
            Console.Write("Введите название файла: ");
            string fileName = Console.ReadLine();
            File.Create($"{p}\\{fileName}").Close();
        }
        private static void Delete(int y, string[] paths, string[] pathsFiles)
        {
            try
            {
                if (y - 1 <= paths.Length && paths.Length > 0)
                {
                    Directory.Delete(paths[y - 2], true);
                }
                else
                {
                    File.Delete($"{pathsFiles[y - 2 - paths.Length]}");
                }
            }
            catch
            {
                return;
            }
        }
    }
}
