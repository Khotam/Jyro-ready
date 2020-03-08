﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;


namespace Jyro.DAL
{
    public class TicketManager : DbManager
    {

        public void Create(Ticket t)
        {
            var connection = Connection;
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }
        }

        public void Update(Ticket t)
        {
            var connection = Connection;
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }
        }



        public void Delete(int id)
        {
            var connection = Connection;
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public Ticket GetById(int id)
        {
            var connection = Connection;
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            // if we are here - something went wrong
            return null;
        }

        public List<Ticket> GetAll()
        {
            var connection = Connection;
            var result = new List<Ticket>();
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public List<Ticket> GetBackLogTickets()
        {
            var connection = Connection;
            var result = new List<Ticket>();
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;

        }

        public void SetTicketStatusAndSprint(Ticket t, int lastSprint)
        {
            var connection = Connection;
            try
            {
                var sql = $"UPDATE ti_ticket SET ti_status_7717=1, ti_sprint_id_7717={lastSprint} WHERE ti_id_7717={t.Id}";
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public void ChangeTicketStatuses(int id)
        {
            var connection = Connection;
            try
            {
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
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private Ticket GetFromReader(SqlCeDataReader reader)
        {
            var t = new Ticket
            {
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
