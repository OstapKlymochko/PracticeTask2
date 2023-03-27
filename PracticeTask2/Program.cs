using System;


namespace PracticeTask2
{
	class Program
	{
		static void Main()
		{
			ComputerClass k = new ComputerClass("A-270", 40, 16, "Soft Serve Lab", 10);
			k.InstallProjector();
			ComputerClass k1 = new ComputerClass("A-115", 45, 20, "N-ix Lab", 15);
			ComputerClass k2 = new ComputerClass("A-120", 45, 20, string.Empty, 15);
			Console.WriteLine(k2);
			k.InstallProjector();
			Classroom c = new Classroom("A-265", 30, 3, 3, "Стефана Баха");
			Classroom c1 = new Classroom("A-439", 200, 30, 0, string.Empty);
			c1.InstallProjector();
			Classroom c2 = new Classroom("A-216", 200, 35, 5, string.Empty);
			c2.InstallProjector();
			Classroom c3 = new Classroom("A-263", 30, 0, 10, string.Empty);

			List<StudyingRoom> arr = new List<StudyingRoom>
			{
				k,
				k1,
				k2,
				c3,
				c2,
				c1,
				c
			};
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
			Console.Write("Комп'ютерний клас чи Аудиторія(1 або 2)");
			choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					Console.Write("Введіть назву приміщення, площу, кiлькiсть комп'ютерiв, назву i кiлькiсть звичайних мiсць: ");
					try
					{
						string[] input = Console.ReadLine().Split(' ');
						if (uint.TryParse(input[1], out uint area) && uint.TryParse(input[2], out uint cCount) && uint.TryParse(input[4], out uint pCount))
						{
							//Console.WriteLine($"{capacity} {area}");
							arr.Add(new ComputerClass(input[0], area, cCount, input[3], pCount));

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
					break;
				case "2":
					Console.Write("Введіть назву приміщення, площу, кiлькiсть довмiсних i трьохмiсних парт i в честь кого вона названа: ");
					try
					{
						string[] input = Console.ReadLine().Split(' ');
						if (uint.TryParse(input[1], out uint area) && uint.TryParse(input[2], out uint twoCount) && uint.TryParse(input[3], out uint threeCount))
						{
							//Console.WriteLine($"{capacity} {area}");
							arr.Add(new Classroom(input[0], area, twoCount, threeCount, input[4]));

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
					break;
				default:
					goto noNewRoom;
			}
		noNewRoom:
			StudyingRoom maxAreaRoom = arr[0];
			StudyingRoom maxPlacePerStudentRoom = arr[0];
			bool projectorResult = true;
			uint roomN = 2;
			List<StudyingRoom> secondFloor = new List<StudyingRoom>();
			foreach (StudyingRoom room in arr)
			{
				Console.WriteLine(room);
				if (room > maxAreaRoom)
				{
					maxAreaRoom = room;
				}
				if (room.AreaPerStudent > maxPlacePerStudentRoom.AreaPerStudent && room.bigEnoughForLessons)
				{
					maxPlacePerStudentRoom = room;
				}
				if (room.Capacity >= 100 && !room.ContainsProjector)
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
			Console.WriteLine("\n\n");
			arr.Sort();
			Console.WriteLine("Три наймiсткіші приміщення:");
			Console.WriteLine(arr[arr.Count - 1]);
			Console.WriteLine(arr[arr.Count - 2]);
			Console.WriteLine(arr[arr.Count - 3]);

		}
	}
	}
