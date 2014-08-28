using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeckoDAL;


namespace GeckoBooking
{
    public partial class Lab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Text = string.Empty;

            //if (!IsPostBack)
            //{
            //    TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //}

            //CurrentDateLabel.Text = TextBox2.Text;

            if (IsPostBack)
            {
                CreateTable();
                Button1_OnClick(Page, e);
            }
        }



        protected void MyCheckedChanged(object sender, EventArgs e)
        {

            //CheckBox checkBox = (CheckBox) sender;
            //checkBox.Checked = true;
            Button2_OnClick(Page, e);
        }



        protected void CreateTable()
        {
            Table1.Rows.Clear();

            CurrentDateLabel.Text = "Selected date: " + TextBox2.Text;

            var courts = CourtDB.GetAllCourts();

            TableHeaderRow tbHeaderRow = new TableHeaderRow();

            TableHeaderCell tbHeaderTimeCell = new TableHeaderCell();
            tbHeaderRow.Cells.Add(tbHeaderTimeCell);

            for (int i = 0; i < courts.Count; i++)
            {
                TableHeaderCell tbHeaderCell = new TableHeaderCell();
                tbHeaderCell.Text = courts[i].Name + " " + courts[i].Id;
                tbHeaderRow.Cells.Add(tbHeaderCell);
            }

            Table1.Rows.Add(tbHeaderRow);

            for (int i = 0; i < SessionItem.OpenTimeSpan.Hours; i++)
            {
                DateTime dateTime =
                    DateTime.Parse(TextBox2.Text + " " + (SessionItem.DaySessionStartTime.Hour + i) + ":00:00");
                SessionItem sessionItem = new SessionItem(dateTime);
                TableRow trRow = new TableRow();
                TableCell timeCell = new TableCell();
                timeCell.Text = sessionItem.SessionTime.ToShortTimeString().TrimEnd(':');
                trRow.Cells.Add(timeCell);
                for (int j = 0; j < courts.Count; j++)
                {
                    TableCell tableCell = new TableCell();
                    if (!sessionItem.CourtVacancy[j])
                    {
                        tableCell.BackColor = Color.FromArgb(255, 0, 127);
                    }
                    else
                    {
                        tableCell.BackColor = Color.FromArgb(153, 255, 153);
                    }
                    trRow.Cells.Add(tableCell);

                    //var upPanel = new UpdatePanel()
                    //{
                    //    ID =
                    //        "UpdatePanel-" + courts[j].Id + "-" +
                    //        sessionItem.SessionTime.ToShortTimeString().TrimEnd(':'),
                    //    UpdateMode = UpdatePanelUpdateMode.Conditional
                    //};

                    var sessionItemButton = new SessionItemButton();

                    sessionItemButton.CssClass = "SIButton";
                    sessionItemButton.BackColor = sessionItem.CourtVacancy[j] ? Color.FromArgb(153,255,153) : Color.FromArgb(255,0,127);
                    sessionItemButton.Visible = sessionItem.CourtVacancy[j];

                    sessionItemButton.Court = courts[j];
                    sessionItemButton.StartSessionTime = sessionItem.SessionTime;

                    sessionItemButton.Click += Button2_OnClick;

                    //var checkBox = new CheckBox()
                    //{
                    //    Visible = sessionItem.CourtVacancy[j],
                    //    ID = "court"+courts[j].Id + "_time" + new string(sessionItem.SessionTime.ToShortTimeString().TakeWhile(c => c != ':').ToArray())

                    //    //AutoPostBack = true
                    //};

                    //checkBox.CheckedChanged += Button2_OnClick;

                    //upPanel.ContentTemplateContainer.Controls.Add(checkBox);

                    //upPanel.Triggers.Add(new AsyncPostBackTrigger() { ControlID = checkBox.ID });
                    //UpdatePanel3.Triggers.Add(new AsyncPostBackTrigger() { ControlID = checkBox.ID });

                    ((IParserAccessor)tableCell).AddParsedSubObject(sessionItemButton);
                }
                Table1.Rows.Add(trRow);
            }
        }


        public static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control descendant in GetAllControls(control))
                {
                    yield return descendant;
                }
            }
        }



        protected void Button2_OnClick(object sender, EventArgs e)
        {
            var button = sender as SessionItemButton;

            if (button != null)
            {
                button.BackColor = button.BackColor == Color.FromArgb(153, 255, 153) ? Color.FromArgb(255,0,191,255) : Color.FromArgb(153, 255, 153);
                var currentBooking = new Booking();
                currentBooking.User = UserDB.GetUserById(1);

                Label5.Text = DateTime.Now.ToString();
                Label5.Text += " Test: ";
                Label6.Text = "You have selected: ";
                IEnumerable<Control> cbList = GetAllControls(Table1);

                var enumerable = cbList as IList<Control> ?? cbList.ToList();

                foreach (var ctrl in enumerable)
                {
                    if (ctrl.GetType() == typeof(SessionItemButton))
                    {
                        var sessionItemButton = (SessionItemButton)ctrl;
                        if (sessionItemButton.BackColor == Color.FromArgb(255,0,191,255))
                        {
                            Session session = new Session(
                                sessionItemButton.Court,
                                sessionItemButton.StartSessionTime
                                );

                            currentBooking.Session.Add(session);

                            currentBooking.TotalCost += session.SessionCost;

                            //DateTime time = DateTime.Parse(cbBox.InputAttributes["value"].TrimStart('_'));
                            Label5.Text += ctrl.ID + " ";
                            Label6.Text += string.Format("<br/>CourtId: {0}  <br/>SessionStartTime: {1} <br/>Session cost: {2} kr",
                                sessionItemButton.Court.Id, sessionItemButton.StartSessionTime, session.SessionCost);
                        }
                    }
                }
                Label6.Text += string.Format("<br/><br/> Number of sessions: {0} <br/>TotalCost: {1} kr", currentBooking.Session.Count,
                    currentBooking.TotalCost);
                Session["CurrentBooking"] = currentBooking;
            }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            IEnumerable<Control> cbList = GetAllControls(Page);

            var enumerable = cbList as IList<Control> ?? cbList.ToList();

            foreach (var ctrl in enumerable)
            {
                if (ctrl.GetType() == typeof(CheckBox))
                {
                    var cbBox = (CheckBox)ctrl;
                    if (cbBox.Checked)
                    {
                        cbBox.Checked = false;
                    }
                }
            }
        }

        protected void ConfirmBooking_OnClick(object sender, EventArgs e)
        {
            var currentBooking = Session["CurrentBooking"] as Booking;

            if (currentBooking != null)
            {
                int affectedRows = BookingDB.AddBooking(currentBooking);

                if (affectedRows > 0)
                {
                    Label6.Text = "Booking was added!";
                }
                else
                {
                    Label6.Text = "Booking could not be added!";
                }
            }
            CreateTable();
        }
    }

    public class SessionItemButton : Button
    {
        public Court Court { get; set; }
        public DateTime StartSessionTime { get; set; }
    }
}