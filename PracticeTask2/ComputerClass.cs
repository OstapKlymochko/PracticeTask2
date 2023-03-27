using System;

namespace PracticeTask2
{
	class ComputerClass: StudyingRoom
	{
		private uint computerCount;
		private string name;
		private uint places;
		public override uint Capacity { get; init; }
		public override double AreaPerStudent { get; init; }

		protected override double calculateAreaPerStudent()
		{
			return this.Area / (this.computerCount + this.places);
		}
		public ComputerClass() : base()
		{
			this.computerCount = 0;
			this.name = string.Empty;
			this.Capacity = 0;
			this.AreaPerStudent = 0;
		}
		public ComputerClass(string _rNum, uint _rArea, uint _rCompCount,string _rName, uint _places) : base(_rNum, _rArea)
		{
			this.computerCount = _rCompCount;
			this.name = _rName;
			this.AreaPerStudent = calculateAreaPerStudent();
			this.places = _places;
			this.Capacity = this.computerCount + this.places;
		}
		public override string ToString()
		{
			return $"{name}. {base.ToString()} {computerCount} комп'ютерів";
		}
		public uint ComputerCount { get { return computerCount; } set { computerCount = value; } }
		public string Name { get { return this.name; } set { this.name = value; } }
	}
}
