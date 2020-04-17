using System;

namespace Lection17_04
{
    struct Person
    {
        public string Name { get; set; } //открытое свойство для имени
        public int Age { get; set; } //открытой свойство для возраста
        public Person(string name) //констуктор с именем
        {
            Name = name;
            Age = 18;
        }
        public Person(string name, int age) //конструктор с именем и возрастом
        {
            Name = name;
            Age = age;
        }

        public void Info()
        {
            Console.WriteLine("Имя - {0}, возраст - {1}", Name, Age);
        }
    }
    class Program
    {
        enum Season
        {
            Spring, //0 - весна
            Summer, //1 - лето
            Autumn, //2 - осень
            Winter  //3 - зима
        }

        enum SummerMonth : byte
        {
            June = 6, //июнь - 6
            July, //июль - 7
            August //август - 8
        }

        [Flags]
        enum Color
        {
            Black = 0, //черный - 0
            Red = 1, //красный - 1
            Yellow = 2, //жёлтый - 2
            Blue = 4, //синий - 4
            Green = Yellow | Blue, //зелёный - 6
            White = Red | Yellow | Blue //белый - 7
        }
        static void Main(string[] args)
        {
            //1 задание
            PrintPersonInfo(("Артём Черепанов", 27));
            var newuser = GetUser("nicelogin", "awesomepassword");
            Console.WriteLine("Логин: {0}, пароль {1}", newuser.Item1, newuser.Item2);
            int[] numbers = { 1, 5, 7, 143 };
            var arrinfo = GetArrayData(numbers);
            Console.WriteLine("Сумма:{0}, количество элементов: {1}", arrinfo.sum, arrinfo.count);
            Console.WriteLine();
            //2 задание
            Color orange = Color.Red | Color.Yellow;
            SummerMonth june = SummerMonth.June;
            Console.WriteLine("Зима({0}) + оранжевый({1}) + июнь({2}) = {3}", (int)Season.Winter, (int)orange, (int)june,
                (int)Season.Winter + (int)orange + (int)june); //да, это длинный и некрасивый вывод приведенных к цеочисленному типу переменных, как вы узнали?
            Console.WriteLine();
            //3 задание
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("{0} - {1}", i, (Color)i);
            }
            Console.WriteLine();
            for (Color i = Color.Black; i <= Color.White; i++)
            {
                Console.WriteLine(i);
            }
            //4 задание
            Person student = new Person("Вика");
            Person teacher = new Person("Валерий Альбертович", 54);
            student.Info();
            teacher.Info();
            student.Name = "А я теперь не Вика";
            student.Age = 33;
            student.Info();
        }

        static void PrintPersonInfo((string name, int age) person) //метод для вывода информации о человеке
        {
            Console.WriteLine("Имя: {0}, возраст - {1}", person.name, person.age);
        }

        private static (string, string) GetUser(string login, string password) //метод, возвращающий
        {
            var user = (login, password);
            return user;
        }
        private static (int sum, int count) GetArrayData(int[] numbers)
        {
            var result = (sum: 0, count: numbers.Length);
            for (int i = 0; i < numbers.Length; i++)
            {
                result.sum += numbers[i];
            }
            return result;
        }
    }
}
