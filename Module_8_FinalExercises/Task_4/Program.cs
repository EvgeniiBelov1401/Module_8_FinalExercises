using Task_4.Modules;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Programming\Skillfactory\C#_projects\Module_8_FinalExercises\Module_8_FinalExercises\Task_4\DataFolder\students.dat";
            List<Students> allStudentsList = FillStudenstList();


            Console.WriteLine("Для записи всех студентов нажмите 'ENTER'");
            Console.ReadLine();
            WriteStudentsInFile(allStudentsList,filePath);
            Console.Clear();
            Console.WriteLine("Данные успешно записаны");

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
           BinaryWriter bw=new BinaryWriter(new FileStream(filePath, FileMode.Create));
            foreach (Students student in students)
            {
                bw.Write(student.Name);
                bw.Write(student.Group);
                bw.Write(student.DateOfBirth.ToBinary());
                bw.Write(student.AverageScore);
            }
            bw.Close();
        }
    }
}
