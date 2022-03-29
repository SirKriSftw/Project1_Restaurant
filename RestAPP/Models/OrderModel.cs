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
    }
}
