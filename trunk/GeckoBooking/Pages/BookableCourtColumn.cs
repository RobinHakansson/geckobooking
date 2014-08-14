using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeckoBooking
{
    public class BookableCourtColumn : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            var cBox = new CheckBox();
            cBox.ID = "SessionCheckBox";
            container.Controls.Add(cBox);
        }

    }
}