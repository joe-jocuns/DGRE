using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

        public string degreeObjectIsAmOrPm { get; set; }

        public DegreeObject() { }

        public DegreeObject DegreeObjectmaker(DateTime incomingDT,int incomingProject)
        {
            DegreeObject maker = new DegreeObject();

            maker.projectId = incomingProject;
            maker.degreeObjectMilSec = incomingDT.Millisecond;
            maker.degreeObjectSec = incomingDT.Second;
            maker.degreeObjectMinute = incomingDT.Minute;
            maker.degreeObjectHour = incomingDT.Hour;
            maker.degreeObjectDay = incomingDT.Day;
            maker.degreeObjectDayOfTheWeek = (int)incomingDT.DayOfWeek;
            maker.degreeObjectMonth = incomingDT.Month;
            maker.degreeObjectYear = incomingDT.Year;
            maker.degreeObjectIsAmOrPm = incomingDT.ToString("tt", CultureInfo.InvariantCulture);
            return maker;
        }

        public static implicit operator DegreeObject(SqlDataReader v)
        {
            throw new NotImplementedException();
        }
    }
}
