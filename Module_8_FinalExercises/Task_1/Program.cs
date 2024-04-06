namespace Task_1
{
    internal class Program
    {
        //Напишите программу, которая чистит нужную нам папку от файлов  и папок, 
        //которые не использовались более 30 минут
        static void Main(string[] args)
        {
            int minutes = 30;
            string dirPath = @"D:\Programming\Skillfactory\C#_projects\Module_8_FinalExercises\Module_8_FinalExercises\Task_1\FolderForTask1\TestFolder";
            DirectoryInfo directory = new DirectoryInfo(dirPath);

            if (directory.Exists)
            {
                if (DateTime.Now-directory.LastAccessTime>TimeSpan.FromMinutes(minutes))
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
                    Console.WriteLine($"Время последнего доступа меньше {minutes} минут");
                }
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }
            
        }
    }
}
