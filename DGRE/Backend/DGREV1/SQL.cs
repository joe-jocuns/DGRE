using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Data.SqlClient;
using System.Runtime.Serialization;




namespace DGRE
{
    public class SQL
    {
        readonly string connectionString = @"Server=.\SQLEXPRESS;Database=DGRE;Trusted_Connection=True;";

        public void WriteToSql(DegreeObject incomingDegreeObject)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into log(date_time_milsec, date_time_sec, date_time_min, date_time_hour, date_time_day, date_time_week,date_time_month, date_time_year, date_time_am_or_pm)" +
                                                    " VALUES (@date_time_milsec, @date_time_sec, @date_time_min, @date_time_hour, @date_time_day, @date_time_week,@date_time_month, @date_time_year,@date_time_am_or_pm)", conn);
                    cmd.Parameters.AddWithValue("@date_time_milsec", incomingDegreeObject.degreeObjectMilSec);
                    cmd.Parameters.AddWithValue("@date_time_sec", incomingDegreeObject.degreeObjectSec);
                    cmd.Parameters.AddWithValue("@date_time_min", incomingDegreeObject.degreeObjectMinute);
                    cmd.Parameters.AddWithValue("@date_time_hour", incomingDegreeObject.degreeObjectHour);
                    cmd.Parameters.AddWithValue("@date_time_day", incomingDegreeObject.degreeObjectDay);
                    cmd.Parameters.AddWithValue("@date_time_week", incomingDegreeObject.degreeObjectDayOfTheWeek);
                    cmd.Parameters.AddWithValue("@date_time_year", incomingDegreeObject.degreeObjectYear);
                    cmd.Parameters.AddWithValue("@date_time_month", incomingDegreeObject.degreeObjectMonth);
                    cmd.Parameters.AddWithValue("@date_time_am_or_pm", incomingDegreeObject.degreeObjectIsAmOrPm);
                    //cmd.Parameters.AddWithValue("@project_id", incomingDegreeObject.project_id);
                    int v = cmd.ExecuteNonQuery();
                 



                }
            }
            catch (Exception)
            {

                throw;
            }




            // do ask do i join tables or make a seperate input for project id



        }




        public List<DegreeObject> ReadFromSQl(int projectid)
        {
            List<DegreeObject> lister = new List<DegreeObject>();

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from log JOIN Log_to_Project ON Log_to_Project.Log_Id = log.log_id where Project_Id = @projectid");
                cmd.Parameters.AddWithValue("@projectid", projectid);
                // error below
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    lister.Add(DegreeObjectMaker(reader));
                }
                reader.Close();

            }
            return lister;

        }

        public DegreeObject DegreeObjectMaker(SqlDataReader reader)
        {
            try
            {
                DegreeObject objecter = new DegreeObject();
                objecter.degreeId = Convert.ToInt32(reader["log_id"]);
                objecter.degreeId = Convert.ToInt32(reader["project_id"]);
                objecter.degreeObjectMilSec = Convert.ToInt32(reader["date_time_milsec"]);
                objecter.degreeObjectSec = Convert.ToInt32(reader["date_time_sec"]);
                objecter.degreeObjectMinute = Convert.ToInt32(reader["date_time_min"]);
                objecter.degreeObjectHour = Convert.ToInt32(reader["date_time_hour"]);
                objecter.degreeObjectDay = Convert.ToInt32(reader["date_time_day"]);
                objecter.degreeObjectDayOfTheWeek = Convert.ToInt32(reader["date_time_week"]);
                objecter.degreeObjectMonth = Convert.ToInt32(reader["date_time_month"]);
                objecter.degreeObjectYear = Convert.ToInt32(reader["date_time_year"]);
                objecter.degreeObjectIsAmOrPm = Convert.ToString(reader["date_time_am_or_pm"]);


                return objecter;
            }
            catch (Exception)
            {
                return null;

            }


        }
    }
}





