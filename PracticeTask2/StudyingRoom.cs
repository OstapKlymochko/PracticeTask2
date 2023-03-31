using System;

namespace PracticeTask2
{
    abstract class StudyingRoom : IComparable
    {
        protected string roomNumber;
        abstract public uint Capacity { get; init; }
        protected uint area;
        abstract public double AreaPerStudent { get; init; }
        private bool containsProjector = false;

		public delegate void MyEvent(object sender);

		public event MyEvent projectorInstalled;
		public event MyEvent projectorUnInstalled;

		public event MyEvent lessonStarted;
		public event MyEvent lessonEnded;

		protected abstract double calculateAreaPerStudent();
        public StudyingRoom()
        {
            this.roomNumber = "A-000";
            this.area = 0;
        }
        public StudyingRoom(string _rNum, uint _rArea)
        {
            this.roomNumber= _rNum;
            this.area = _rArea;
        }
        public override string ToString()
        {
            return $"{this.roomNumber}. {this.area} м^2. {this.Capacity} Студентів. {this.AreaPerStudent} м^2 на одного студента.";
        }
        public override bool Equals(object obj)
        {
            StudyingRoom S = obj as StudyingRoom;
            return this.roomNumber == S.roomNumber && this.area == S.area && this.Capacity == S.Capacity;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator == (StudyingRoom left, StudyingRoom right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(StudyingRoom left, StudyingRoom right)
        {
            return !left.Equals(right);
        }
        public int CompareTo(object obj)
        {
            StudyingRoom S = obj as StudyingRoom;
            int res = (int)this.Capacity - (int)S.Capacity;
         
            if(res == 0)
            {
                return 0;
            }
            else if(res > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public static bool operator >(StudyingRoom left, StudyingRoom right)
        {
            return left.CompareTo(right) > 0;
        }
        public static bool operator <(StudyingRoom left, StudyingRoom right)
        {
            return left.CompareTo(right) < 0;
        }
       
        public string RoomNumber
        {
            get
            {
                return this.roomNumber;
            }
        }
        public uint Area
        {
            get
            {
                return this.area;
            }
        }
        public bool bigEnoughForLessons
        {
            get
            {
                return this.Capacity >= 12;
            }
        }
     
        public bool ContainsProjector
        {
            get
            {
                return containsProjector;
            }
        }
		public void startLesson()
		{
			if (lessonStarted != null)
			{
				lessonStarted(this);
			}
		}
		public void endLesson()
		{
			if (lessonStarted != null)
			{
				lessonEnded(this);
			}
		}

		public void InstallProjector()
        {
			if (projectorInstalled != null)
			{
				projectorInstalled(this);
			}
			this.containsProjector = true;
        }
        public void RemoveProjector()
        {
			if (projectorUnInstalled != null)
			{
				projectorUnInstalled(this);
			}
			this.containsProjector = false;
        }

    }
}
