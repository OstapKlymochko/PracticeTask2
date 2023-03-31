using System;

namespace PracticeTask2
{
	public class Student
	{
		public string Name { get; set; }
		public uint Age { get; set; }
		private bool onLesson;
		public Student(string name = "Aндрiй", uint age = 17)
		{
			this.Name = name;
			this.Age = age;
			onLesson = true;
		}
		public void onLessonStarted(object sender)
		{
            Console.WriteLine("Пара почалась, мушу бiгти до аудиторії {0}!", (sender as StudyingRoom).RoomNumber);
            onLesson = true;
			Console.ReadLine();
		}
		public void onLessonEnded(object sender)
		{
			Console.WriteLine("Пара закiнчилась, пора в їдальню!");
			onLesson = false;
			Console.ReadLine();
		}
	}
}
