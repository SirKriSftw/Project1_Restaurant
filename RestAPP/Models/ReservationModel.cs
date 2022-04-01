using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace RestAPP.Models
{
    public class ReservationModel
    {
        #region Columns / Properties
        public int resID { get; set; }
        public int userID { get; set; }
        public DateTime resDateTime { get; set; }
        public double total { get; set; } = 0.0;
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");

        public List<ReservationModel> GetReservations()
        {
            string query = "SELECT * FROM Reservations";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ReservationModel> reservations = new List<ReservationModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No reservations found");
                while (reader.Read())
                {
                    reservations.Add(new ReservationModel()
                    {
                        resID = reader.GetInt32(0),
                        userID = reader.GetInt32(1),
                        resDateTime = reader.GetDateTime(2),
                        total = reader.GetDouble(3)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return reservations;
        }

        public List<ReservationModel> GetUserReservations(int userID)
        {
            string query = "SELECT * FROM Reservations WHERE userID = @userID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            List<ReservationModel> reservations = new List<ReservationModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No reservations found");
                while (reader.Read())
                {
                    reservations.Add(new ReservationModel()
                    {
                        resID = reader.GetInt32(0),
                        userID = reader.GetInt32(1),
                        resDateTime = reader.GetDateTime(2),
                        total = reader.GetDouble(3)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return reservations;
        }

        public ReservationModel GetReservation(int resID)
        {
            string query = "SELECT * FROM Reservations WHERE resID = @resID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@resID", resID);
            ReservationModel reservation = new ReservationModel();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reservation.resID = resID;
                    reservation.userID = reader.GetInt32(1);
                    reservation.resDateTime = reader.GetDateTime(2);
                    reservation.total = reader.GetDouble(3);
                }
                else
                {
                    throw new Exception("Reservation not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return reservation;
        }

        public string AddReservation(int userID, DateTime resDateTime)
        {
            string query = "INSERT INTO Reservations VALUES(@userID, @resDateTime, @total)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@resDateTime", resDateTime);
            cmd.Parameters.AddWithValue("@total", 0);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return "Reservation for the " + resDateTime + " added successfully";
        }

        public string EditReservation(int resID, DateTime resDateTime)
        {
            string query = "UPDATE Reservations SET resDateTime=@resDateTime WHERE resID=@resID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@resID", resID);
            cmd.Parameters.AddWithValue("@resDateTime", resDateTime);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return "Reservation updated to " + resDateTime + " successfully";
        }

        public string DelReservation(int resID)
        {
            string query = "DELETE FROM Reservations WHERE resID=@resID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@resID", resID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return "Reservation " + resID + " deleted successfully";
        }
    }
}
