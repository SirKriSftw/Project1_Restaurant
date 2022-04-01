using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.Generic;

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
            cmd.Parameters.AddWithValue("@orderID", orderID);
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
            string query = "SELECT OD.orderID, dishID, quantity FROM OrderedDishes OD JOIN " +
                "(SELECT O.orderID FROM Orders O JOIN Reservations R ON O.resID=@resID AND R.resID=@resID) " +
                "AS ORes ON OD.orderID = ORes.orderID";
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
            string query = "SELECT OD.orderID, dishID, quantity FROM OrderedDishes OD JOIN" +
                " (SELECT O.orderID FROM Orders O JOIN " +
                "(SELECT resID FROM Reservations R JOIN " +
                "Users U ON R.userID = @userID AND U.userID = @userID) " +
                "AS URes ON O.resID = URes.resID) " +
                "AS ORes ON OD.orderID = ORes.orderID";
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

        public string AddOrderedDish(OrderDishModel newOrderDish)
        {
            string query = "INSERT INTO OrderedDishes VALUES(@orderID, @dishID, @qty)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderID", newOrderDish.orderID);
            cmd.Parameters.AddWithValue("@dishID", newOrderDish.dishID);
            cmd.Parameters.AddWithValue("@qty", newOrderDish.quantity);

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

            return "New ordered dish added successfully";
        }

        public string AddMultipleOrderedDishes(List<OrderDishModel> newOrderedDishes)
        {
            string output = "Sucessfully added ";
            string query = "INSERT INTO OrderedDishes VALUES(@orderID, @dishID, @qty)";
            SqlCommand cmd;
            try
            {
                conn.Open();
                foreach (OrderDishModel newOrderDish in newOrderedDishes)
                {
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderID", newOrderDish.orderID);
                    cmd.Parameters.AddWithValue("@dishID", newOrderDish.dishID);
                    cmd.Parameters.AddWithValue("@qty", newOrderDish.quantity);
                    cmd.ExecuteNonQuery();
                    output = output + " " + newOrderDish.dishID;
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

            return output;
        }
        public string EditOrderedDish(OrderDishModel editOrderDish)
        {
            string query = "UPDATE OrderedDishes SET quantity=@qty WHERE orderID=@orderID AND dishID=@dishID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderID", editOrderDish.orderID);
            cmd.Parameters.AddWithValue("@dishID", editOrderDish.dishID);
            cmd.Parameters.AddWithValue("@qty", editOrderDish.quantity);

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

            return "Edited ordered dish successfully";
        }

        public string DelOrderedDish(int orderID, int dishID)
        {
            string query = "DELETE FROM OrderedDishes WHERE orderID=@orderID AND dishID=@dishID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.Parameters.AddWithValue("@dishID", dishID);

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

            return "Deleted ordered dish successfully";
        }
    }
}
