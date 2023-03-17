using System;


namespace PracticeTask2
{
     class Program
    {
        static void Main()
        {
            StudyingRoom a = new StudyingRoom("A-270", 30, 100);
            a.InstallProjector();
            StudyingRoom b = new StudyingRoom("A-439", 110, 200);
            b.InstallProjector();
            StudyingRoom c = new StudyingRoom("A-265", 20, 80);
            StudyingRoom d = new StudyingRoom("A-260", 15, 90);
            StudyingRoom e = new StudyingRoom("A-216", 100, 200);
            e.InstallProjector();
            //StudyingRoom[] arr = new StudyingRoom[5] { a, b, c, d, e }; 
            List<StudyingRoom> arr = new List<StudyingRoom>();
            arr.Add(a);
            arr.Add(b);
            arr.Add(c);
            arr.Add(d);
            arr.Add(e);
            Console.Write("Додати нового користувача?(так або ні) ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "так":
                    break;
                case "ні":
                    goto noNewRoom;
                default:
                    goto noNewRoom;
            }
            try
            {
                Console.Write("Введіть назву приміщення кількість студентів і площу: ");
                string [] input = Console.ReadLine().Split(' ');
                if (uint.TryParse(input[1], out uint capacity) && uint.TryParse(input[2], out uint area))
                {
                    //Console.WriteLine($"{capacity} {area}");
                    arr.Add(new StudyingRoom(input[0], capacity, area));
                }
                else
                {
                    Console.WriteLine("Невалідні дані :(");

                }
            }
            catch 
            {
                Console.WriteLine("Халепа :(");
            }
        noNewRoom:
            //Console.WriteLine("smth");
            StudyingRoom maxAreaRoom = arr[0];
            StudyingRoom maxPlacePerStudentRoom = arr[0];
            bool projectorResult = true;
            uint roomN = 2;
            List<StudyingRoom> secondFloor = new List<StudyingRoom>();
            foreach (StudyingRoom room in arr)
            {
                Console.WriteLine(room);
                if(room > maxAreaRoom)
                {
                    maxAreaRoom = room;
                }
                if(room.AreaPerStudent > maxPlacePerStudentRoom.AreaPerStudent && room.bigEnoughForLessons)
                {
                    maxPlacePerStudentRoom = room;
                }
                if(room.Capacity >= 100 && !room.ContainsProjector)
                {
                    projectorResult = false;
                }
                string num = room.RoomNumber.Split('-')[1][0].ToString();
                //Console.WriteLine($"{num[0].GetType()}");

                if (uint.TryParse(num, out uint roomNumber) && roomNumber == 2)
                {
                    secondFloor.Add(room);
                }

            }
            Console.WriteLine($"\n\nНаймісткіше приміщення: {maxAreaRoom}");
            Console.WriteLine($"Найбільша площа на одного студента: {maxPlacePerStudentRoom}");
            Console.WriteLine(projectorResult ? "У всіх лекційних аудиторіях є проектор." : "Не у всіх лекційних аудиторіях є проектор.");
            Console.WriteLine("\nПриміщення на другому поверсі:");
            foreach (StudyingRoom room in secondFloor)
            {
                Console.WriteLine(room);
            }
        }
    }
}