namespace Task_3
{
    internal class Program
    {
        //Доработайте программу из задания 1, используя ваш метод из задания 2.
        //При запуске программа должна:
        //Показать, сколько весит папка до очистки.Использовать метод из задания 2. 
        //Выполнить очистку.
        //Показать сколько файлов удалено и сколько места освобождено.
        //Показать, сколько папка весит после очистки.
        static void Main(string[] args)
        {
            string dirPath = @"D:\Programming\Skillfactory\C#_projects\Module_8_FinalExercises\Module_8_FinalExercises\Task_3\FolderForTask3\TestFolder";
            DirectoryInfo directory = new DirectoryInfo(dirPath);

            DirectorySize(directory,"Исходный размер папки: ");
            if (directory.Exists)
            {

            }
            else 
            {
                Console.WriteLine("Папки не существует и удаление невозможно");
            }

            
        }
        static void DeleteInFolder(DirectoryInfo directory, string dirPath)
        {
            if (directory.Exists)
            {
               
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    Console.WriteLine("Все файлы удалены");
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Console.WriteLine("Все папки удалены");                
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }
        }
        static void DirectorySize(DirectoryInfo directory, string message)
        {
            
            if (directory.Exists)
            {
                Console.WriteLine($"{message}{DirectoryAndFileSize(directory)} байт");
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }
        }

        static long DirectoryAndFileSize(DirectoryInfo directory)
        {
            long dirSize = 0;
            foreach (FileInfo file in directory.GetFiles())
            {
                dirSize += file.Length;
            }
            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                dirSize += DirectoryAndFileSize(subDirectory);
            }
            return dirSize;
        }
    }
}
