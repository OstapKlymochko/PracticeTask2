using System;

namespace PracticeTask2
{
    class Classroom : StudyingRoom
    {
        private uint twoPlacesDesks;
		private uint threePlacesDesks;
		private string namedAfter = string.Empty;

		public override uint Capacity { get; init; }
		public override double AreaPerStudent { get; init; }
		public Classroom(): base()
		{
		
			this.twoPlacesDesks = 0;
			this.threePlacesDesks = 0;
			this.Capacity = 0;
			this.AreaPerStudent = 0;
		}
		public Classroom(string _rNum, uint _rArea, uint _rTwo, uint _rThree, string _rName) : base(_rNum, _rArea) 
		{

			this.twoPlacesDesks = _rTwo;
			this.threePlacesDesks = _rThree;
			this.Capacity = this.twoPlacesDesks * 2 + this.threePlacesDesks * 3;
			this.AreaPerStudent = calculateAreaPerStudent();
			namedAfter = _rName;

		}
		protected override double calculateAreaPerStudent()
		{
			try
			{
				return this.Area / this.Capacity;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return 0;
			}
		}
		public override string ToString()
		{
			string name = namedAfter == string.Empty ? namedAfter : $"Аудиторія імені {namedAfter}. ";
			return $"{name}{base.ToString()} {twoPlacesDesks} двомісних парт, {threePlacesDesks} трьохмісних парт.";
		}
		public uint TwoPlacesDesks 
		{
			get { return this.twoPlacesDesks ;}	
			set { this.twoPlacesDesks = value ; }
		}
		public uint ThreePlacesDesks
		{
			get { return this.threePlacesDesks ;}
			set { this.threePlacesDesks= value ; }
		}
		public string NamedAfter
		{
			get { return this.namedAfter;  }
		}
	}
}
