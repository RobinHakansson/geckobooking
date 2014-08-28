using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using GeckoDAL;

namespace GeckoBooking
{
    public class SessionItemButton : Button
    {
        public Court Court { get; set; }
        public DateTime StartSessionTime { get; set; }
    }
}