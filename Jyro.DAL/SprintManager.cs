using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;


namespace Jyro.DAL
{
    // Class for managing Sprints which inherits from DbManager
    public class SprintManager : DbManager
    {
        // Method for inserting sprints to the database
        public void Create(Sprint s)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for inserting data to the sp_sprint table
                var sql = $@"
INSERT INTO sp_sprint (sp_name_7717, sp_date_7717, sp_no_of_developers_7717, sp_status_7717) 
VALUES('{s.Name}', '{s.Date:yyyy-MM-dd}', {s.NumberOfDevelopers}, {(int)s.Status})";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Closing connection if not closed
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }
        }


        // Method for getting specific Sprint instance by its ID from the database
        public Sprint GetById(int id)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for getting data by ID from the sp_sprint table
                var sql = $@"
SELECT sp_id_7717, sp_name_7717, sp_date_7717, sp_no_of_developers_7717, sp_status_7717
FROM sp_sprint
WHERE sp_id_7717 = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var a = GetFromReader(reader);
                    return a;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Closing connection if not closed
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            // if we are here - something went wrong
            return null;
        }

        // Method for getting all Sprint instances from the database
        public List<Sprint> GetAll()
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            var result = new List<Sprint>();
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for getting all Tickets instances from the sp_sprint table
                var sql = "SELECT sp_id_7717, sp_name_7717, sp_date_7717, sp_no_of_developers_7717, sp_status_7717 FROM sp_sprint";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var a = GetFromReader(reader);
                    result.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Closing connection if not closed
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        // Method for changing Sprints status to done when complete button is clicked in SprintListForm.cs
        public void AlterSprintStatuses(int id)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for updating specific Sprint instances statuses in the sp_sprint table
                var sql = $"UPDATE sp_sprint SET sp_status_7717=1 WHERE sp_id_7717={id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Closing connection if not closed
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        // Helper method for reading values taken from seminar code
        private Sprint GetFromReader(SqlCeDataReader reader)
        {
            var s = new Sprint
            {
                // Converting values
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString(),
                Date = Convert.ToDateTime(reader.GetValue(2)),
                NumberOfDevelopers = Convert.ToInt32(reader.GetValue(3)),
                Status = (Sprint.SprintStatuses)Convert.ToInt32(reader.GetValue(4)),
            };

            return s;
        }
    }
}
