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
    // Class for managing Tickets which inherits from DbManager
    public class TicketManager : DbManager 
    {
        // Method for inserting tickets to the database
        public void Create(Ticket t)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for inserting data to the ti_ticket table
                var sql = $@"
INSERT INTO ti_ticket (ti_summary_7717, ti_description_7717, ti_estimation_7717, ti_priority_7717, ti_status_7717, ti_sprint_id_7717) 
VALUES('{t.Summary}', '{t.Description}', {t.Estimation}, '{(int)t.Priority}', '{(int)t.Status}', '')";
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

        // Method for updating tickets in the database
        public void Update(Ticket t)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for updating data in the ti_ticket table
                var sql = $@"
UPDATE ti_ticket SET 
    ti_summary_7717 = '{t.Summary}', 
    ti_description_7717 = '{t.Description}',
    ti_estimation_7717 = {t.Estimation}, 
    ti_priority_7717 = '{(int)t.Priority}', 
    ti_status_7717 = '{(int)t.Status}'
WHERE ti_id_7717 ={t.Id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
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


        // Method for deleting tickets from the database
        public void Delete(int id)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for deleting data from the ti_ticket table
                var sql = $"DELETE FROM ti_ticket WHERE ti_id_7717 ={id}";
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

        // Method for getting specific Ticket instance by its ID from the database
        public Ticket GetById(int id)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for getting data by ID from the ti_ticket table
                var sql = $@"
SELECT ti_id_7717, ti_summary_7717, ti_description_7717, ti_estimation_7717, ti_priority_7717, ti_status_7717, ti_sprint_id_7717,
FROM ti_ticket
WHERE ti_id_7717 = {id}";
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

        // Method for getting all Ticket instances from the database
        public List<Ticket> GetAll()
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            var result = new List<Ticket>();
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for getting all Tickets instances from the ti_ticket table
                var sql = "SELECT ti_id_7717, ti_summary_7717, ti_description_7717, ti_estimation_7717, ti_priority_7717, ti_status_7717, ti_sprint_id_7717 FROM ti_ticket";
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

        // Method for getting all Ticket instances with status of Backlog from the database to use in SprintCreateForm.cs
        public List<Ticket> GetBackLogTickets()
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            var result = new List<Ticket>();
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for getting all Tickets instances with status of Backlog from the ti_ticket table
                var sql = $"SELECT ti_id_7717, ti_summary_7717, ti_description_7717, ti_estimation_7717, ti_priority_7717, ti_status_7717, ti_sprint_id_7717 FROM ti_ticket WHERE ti_status_7717 = {0}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var t = GetFromReader(reader);
                    result.Add(t);
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

        // Method for setting the status of ticket and sprint
        public void SetTicketStatusAndSprint(Ticket t, int lastSprintID)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for updating specific Ticket instances in the ti_ticket table
                var sql = $"UPDATE ti_ticket SET ti_status_7717=1, ti_sprint_id_7717={lastSprintID} WHERE ti_id_7717={t.Id}";
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

        // Method for changing Tickets status to done when complete button is clicked in SprintListForm.cs
        public void AlterTicketStatuses(int id)
        {
            // Assigning Connection which is inherited from DbManager to connection variable
            var connection = Connection;
            // try / catch for showing error messages in case of error occurs
            try
            {
                /// SQL statement for updating specific Ticket instances statuses in the ti_ticket table
                var sql = $"UPDATE ti_ticket SET ti_status_7717=2 WHERE ti_sprint_id_7717={id}";
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
        private Ticket GetFromReader(SqlCeDataReader reader)
        {
            var t = new Ticket
            {
                // Converting values
                Id = Convert.ToInt32(reader.GetValue(0)),
                Summary = reader.GetValue(1).ToString(),
                Description = reader.GetValue(2).ToString(),
                Estimation = Convert.ToInt32(reader.GetValue(3)),
                Priority = (Ticket.Priorities)Convert.ToInt32(reader.GetValue(4)),
                Status = (Ticket.Statuses)Convert.ToInt32(reader.GetValue(5)),
                SprintId = new SprintManager().GetById(Convert.ToInt32(reader.GetValue(6)))
            };

            return t;
        }


    }
}
