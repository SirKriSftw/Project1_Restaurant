using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestAPP.Models
{
    public class OrderModel
    {
        #region Columns / Properties
        public int orderID { get; set; }
        public int resID { get; set; }
        public double cost { get; set; }
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");

        public List<OrderModel> GetOrders()
        {
            string query = "SELECT * FROM Orders";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<OrderModel> orders = new List<OrderModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    throw new Exception("No orders found");
                while (reader.Read())
                {
                    orders.Add(new OrderModel()
                    {
                        orderID = reader.GetInt32(0),
                        resID = reader.GetInt32(1),
                        cost = reader.GetDouble(2),
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
            return orders;
        }

        public OrderModel GetOrderByID(int orderID)
        {
            string query = "SELECT * FROM Orders WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderID",orderID);
            OrderModel order = new OrderModel();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    order.orderID = reader.GetInt32(0);
                    order.resID = reader.GetInt32(1);
                    order.cost = reader.GetDouble(2);
                }

                else
                {
                    throw new Exception("Order not found");
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
            return order;
        }

        public List<OrderModel> GetReservationOrders(int resID)
        {
            string query = "SELECT * FROM Orders WHERE resID=@resID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@resID",resID);
            List<OrderModel> orders = new List<OrderModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    throw new Exception("No orders found");
                while (reader.Read())
                {
                    orders.Add(new OrderModel()
                    {
                        orderID = reader.GetInt32(0),
                        resID = resID,
                        cost = reader.GetDouble(2),
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
            return orders;
        }

        public List<OrderModel> GetUserOrders(int userID)
        {
            string query = "SELECT * FROM Orders WHERE resID = (SELECT resID FROM Users WHERE userID=@userID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID",userID);
            List<OrderModel> orders = new List<OrderModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No orders found");
                while (reader.Read())
                {
                    orders.Add(new OrderModel()
                    {
                        orderID = reader.GetInt32(0),
                        resID = reader.GetInt32(1),
                        cost = reader.GetDouble(2),
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
            return orders;
        }

        public string AddOrder(int resID)
        {
            string query = "INSERT INTO Orders VALUES(@resID,0)";
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

            return "Order added successfully to reservation #" + resID;
        }

        public string EditOrder(int orderID, int newResID)
        {
            string query = "UPDATE Orders SET resID=@resID WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@resID", newResID);
            cmd.Parameters.AddWithValue("@orderID", orderID);
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

            return "Order edited successfully to reservation #" + newResID;
        }

        public string DelOrder(int orderID)
        {
            string query = "DELETE FROM Orders WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderID", orderID);
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

            return "Order #" + orderID + " deleted successfully";
        }












    }    
}


