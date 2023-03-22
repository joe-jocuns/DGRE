using System;
using System.Collections.Generic;
using System.Text;

namespace DGRE
{
    public class DegreeObject
    {
        public int degreeId { get; set; }

        public int projectId { get; set; }

        public int degreeObjectMilSec { get; set; }

        public int degreeObjectSec { get; set; }

        public int degreeObjectMinute { get; set; }

        public int degreeObjectHour { get; set; }

        public int degreeObjectDay { get; set; }

        public int degreeObjectDayOfTheWeek{ get; set; }

        public int degreeObjectMonth { get; set; }

        public int degreeObjectYear { get; set; }

        public void DTtoDGREobjectMilSec(DateTime incomingDT)
        {
            degreeObjectMilSec = incomingDT.Millisecond;
        }

        public DegreeObject() { }

        public DegreeObject(int degreeId, int projectId, int degreeObjectMilSec, int degreeObjectSec, int degreeObjectMinute, int degreeObjectHour, int degreeObjectDay, int degreeObjectDayOfTheWeek, int degreeObjectMonth, int degreeObjectYear)
        {
            this.degreeId = degreeId;
            this.projectId = projectId;
            this.degreeObjectMilSec = degreeObjectMilSec;
            this.degreeObjectSec = degreeObjectSec;
            this.degreeObjectMinute = degreeObjectMinute;
            this.degreeObjectHour = degreeObjectHour;
            this.degreeObjectDay = degreeObjectDay;
            this.degreeObjectDayOfTheWeek = degreeObjectDayOfTheWeek;
            this.degreeObjectMonth = degreeObjectMonth;
            this.degreeObjectYear = degreeObjectYear;
        }
    }
}
