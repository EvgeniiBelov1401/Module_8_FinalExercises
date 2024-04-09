using System.Reflection.PortableExecutable;
using System.Text;
using Task_4.Modules;

namespace Task_4
{
    internal class Program
    {
        /*
         * Написать программу-загрузчик данных из бинарного формата в текст.

         На вход программа получает бинарный файл, предположительно, это база данных студентов.

            Свойства сущности Student:

            Имя — Name (string);
            Группа — Group (string);
            Дата рождения — DateOfBirth (DateTime).
            Средний балл — (decimal).
            Ваша программа должна:

            Cчитать данные о студентах из файла;
            Создать на рабочем столе директорию Students.
            Внутри раскидать всех студентов из файла по группам (каждая группа-отдельный текстовый файл), в файле группы студенты перечислены построчно в формате "Имя, дата рождения, средний балл".
        */

        static void Main(string[] args)
        {
            string filePath = @"D:\Programming\Skillfactory\C#_projects\Module_8_FinalExercises\Module_8_FinalExercises\Task_4\DataFolder\students.dat";
            

            Console.WriteLine("Для записи всех студентов нажмите 'ENTER'");
            Console.ReadLine();
            WriteStudentsInFile(FillStudenstList(), filePath);

            Console.Clear();
            Console.WriteLine("Данные успешно записаны");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Чтобы посмотреть всех студентов нажмите 'ENTER'");
            Console.ReadLine();
            Console.Clear();

            List<Students> studentsToRead = ShowAllStudentsList(filePath);
            
            foreach(Students student in studentsToRead)
            {
                Console.WriteLine($"Имя: {student.Name}\tГруппа: {student.Group}\t\tДата рождения: {student.DateOfBirth.ToString("dd.MM.yyyy")}\t Средний балл: {student.AverageScore}");
            }
        }

        static List<Students> FillStudenstList()
        {
            List<Students> students = new List<Students>()
            {
                new Students{Name="Иванов Иван", Group="Группа1", DateOfBirth=new DateTime(2007,01,23), AverageScore=4.6M},
                new Students{Name="Олег Олегов", Group="Группа2", DateOfBirth=new DateTime(2006,05,15), AverageScore=3.1M},
                new Students{Name="Игорь Игорев", Group="Группа3", DateOfBirth=new DateTime(2006,10,01), AverageScore=3.9M},
                new Students{Name="Алена Аленова", Group="Группа1", DateOfBirth=new DateTime(2007,12,14), AverageScore=4.1M},
                new Students{Name="Ирина Иринова", Group="Группа2", DateOfBirth=new DateTime(2006,04,21), AverageScore=3.2M},
                new Students{Name="Анна Аннова", Group="Группа3", DateOfBirth=new DateTime(2007,02,03), AverageScore=4.0M},
                new Students{Name="Николай Николаев", Group="Группа1", DateOfBirth=new DateTime(2006,07,18), AverageScore=4.9M},
                new Students{Name="Надежда Надеждина", Group="Группа2", DateOfBirth=new DateTime(2007,11,27), AverageScore=3.4M},
                new Students{Name="Алексей Алексеев", Group="Группа3", DateOfBirth=new DateTime(2007,08,01), AverageScore=3.3M},
            };
            return students;
        }

        static void WriteStudentsInFile(List<Students>students,string filePath)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            using BinaryWriter bw = new BinaryWriter(fs);

            foreach (Students student in students)
            {
                bw.Write(student.Name);
                bw.Write(student.Group);
                bw.Write(student.DateOfBirth.ToBinary());
                bw.Write(student.AverageScore);
            }
            bw.Flush();
            bw.Close();
            fs.Close();

        }

        static List<Students> ShowAllStudentsList(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<Students> result = new();
                using FileStream fs = new FileStream(filePath, FileMode.Open);
                using StreamReader sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());

                fs.Position = 0;

                BinaryReader br = new BinaryReader(fs);

                while (fs.Position < fs.Length)
                {
                    Students student = new Students();
                    student.Name = br.ReadString();
                    student.Group = br.ReadString();
                    long dt = br.ReadInt64();
                    student.DateOfBirth = DateTime.FromBinary(dt);
                    student.AverageScore = br.ReadDecimal();

                    result.Add(student);
                }

                fs.Close();
                return result;
            }
            else
            {
                return new List<Students>();
            }
            
        }
    }
}
