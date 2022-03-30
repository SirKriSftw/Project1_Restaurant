using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestAPP.Models
{
    public class OrderDishModel
    {
        #region Columns / Properties
        public int orderID { get; set; }
        public int dishID { get; set; }
        public int quantity { get; set; }
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");

        public List<OrderDishModel> GetOrderedDishes()
        {
            string query = "SELECT * FROM OrderedDishes";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<OrderDishModel> orderedDishes = new List<OrderDishModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No ordered dishes found");
                while (reader.Read())
                {
                    orderedDishes.Add(new OrderDishModel()
                    {
                        orderID = reader.GetInt32(0),
                        dishID = reader.GetInt32(1),
                        quantity = reader.GetInt32(2)
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
            return orderedDishes;
        }

        public List<OrderDishModel> GetOrdersDishes(int orderID)
        {
            string query = "SELECT * FROM OrderedDishes WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderID",orderID);
            List<OrderDishModel> orderedDishes = new List<OrderDishModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No ordered dishes found");
                while (reader.Read())
                {
                    orderedDishes.Add(new OrderDishModel()
                    {
                        orderID = reader.GetInt32(0),
                        dishID = reader.GetInt32(1),
                        quantity = reader.GetInt32(2)
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
            return orderedDishes;
        }

        public List<OrderDishModel> GetResDishes(int resID)
        {
            string query = "SELECT * FROM OrderedDishes WHERE orderID = (SELECT orderID FROM Orders WHERE resID=@resID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@resID", resID);
            List<OrderDishModel> orderedDishes = new List<OrderDishModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No ordered dishes found");
                while (reader.Read())
                {
                    orderedDishes.Add(new OrderDishModel()
                    {
                        orderID = reader.GetInt32(0),
                        dishID = reader.GetInt32(1),
                        quantity = reader.GetInt32(2)
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
            return orderedDishes;
        }

        public List<OrderDishModel> GetUserDishes(int userID)
        {
            string query = "SELECT * FROM OrderedDishes WHERE orderID = (SELECT orderID FROM Orders WHERE resID=(SELECT resID FROM Reservations WHERE userID=@userID))";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            List<OrderDishModel> orderedDishes = new List<OrderDishModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No ordered dishes found");
                while (reader.Read())
                {
                    orderedDishes.Add(new OrderDishModel()
                    {
                        orderID = reader.GetInt32(0),
                        dishID = reader.GetInt32(1),
                        quantity = reader.GetInt32(2)
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
            return orderedDishes;
        }
    }
}
