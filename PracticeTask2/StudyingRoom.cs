using System;

namespace PracticeTask2
{
    class StudyingRoom: IComparable<StudyingRoom>
    {
        protected string roomNumber;
        protected uint capacity;
        protected uint area;
        protected double areaPerStudent;
        private bool containsProjector = false;

        public StudyingRoom()
        {
            this.roomNumber = "A-000";
            this.capacity = 0;
            this.area = 0;
            this.areaPerStudent = 0.0;
        }
        public StudyingRoom(string _rNum, uint _rCap, uint _rArea)
        {
            this.roomNumber= _rNum;
            this.capacity = _rCap;
            this.area = _rArea;
            this.areaPerStudent = _rArea / _rCap;
        }
        public override string ToString()
        {
            return $"{roomNumber}. {area} м^2. {capacity} Студентів. {areaPerStudent} м^2 на одного студента.";
        }
        public override bool Equals(object obj)
        {
            StudyingRoom S = obj as StudyingRoom;
            return this.area == S.area && this.capacity == S.capacity;
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
        public int CompareTo(StudyingRoom S)
        {
            int res = (int)this.area - (int)S.area;
         
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
       
        public double AreaPerStudent
        {
            get
            {
                return this.areaPerStudent;
            }
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
                return this.capacity >= 12;
            }
        }
        public uint Capacity
        {
            get
            {
                return this.capacity;
            }
        }
        public bool ContainsProjector
        {
            get
            {
                return containsProjector;
            }
        }
        public void InstallProjector()
        {
            this.containsProjector = true;
        }
        public void RemoveProjector()
        {
            this.containsProjector = false;
        }

    }
}
