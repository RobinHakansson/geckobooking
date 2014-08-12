using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeckoBooking
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertMsg", "$(document).ready(function(){alert('Overrides successfully Updated.');});", true);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertMsg", "$(document).ready(function(){ console.error('Error', 'Here VVV'); });", true);

            //Console.WriteLine("You click me ...................");
            //System.Diagnostics.Debug.WriteLine("You click me ..................");
            //System.Diagnostics.Trace.WriteLine("You click me ..................");

        }
    }
}