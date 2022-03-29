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
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");
    }
}
