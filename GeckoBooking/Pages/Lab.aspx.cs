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

            if (!IsPostBack)
            {
                TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            //CurrentDateLabel.Text = TextBox2.Text;

            if (IsPostBack)
            {
                
                CreateTable();
                Button1_OnClick(Page,e);
            }

            if (1 == 2)
            {
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
                            tableCell.BackColor = Color.FromArgb(1, 250, 0, 0);
                        }
                        else
                        {
                            tableCell.BackColor = Color.FromArgb(1, 0, 250, 0);
                        }
                        trRow.Cells.Add(tableCell);

                        var upPanel = new UpdatePanel()
                        {
                            ID =
                                "UpdatePanel-" + courts[j].Id + "-" +
                                sessionItem.SessionTime.ToShortTimeString().TrimEnd(':'),
                            UpdateMode = UpdatePanelUpdateMode.Conditional
                        };



                        var checkBox = new CheckBox()
                        {
                            Visible = sessionItem.CourtVacancy[j],
                            ID = courts[j].Id + "-" + sessionItem.SessionTime.ToShortTimeString().TrimEnd(':'),
                            AutoPostBack = true
                        };


                        //checkBox.CheckedChanged += new EventHandler(MyCheckedChanged);

                        upPanel.ContentTemplateContainer.Controls.Add(checkBox);

                        //upPanel.Triggers.Add(new AsyncPostBackTrigger() { ControlID = checkBox.ID });
                        ((IParserAccessor) tableCell).AddParsedSubObject(upPanel);

                    }

                    Table1.Rows.Add(trRow);
                }
            }

        }

        protected void MyCheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = (CheckBox) sender;
            checkBox.Checked = true;
        }

        

        protected void CreateTable()
        {
            CurrentDateLabel.Text = "Selected date: "+TextBox2.Text;

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



                    var checkBox = new CheckBox()
                    {
                        Visible = sessionItem.CourtVacancy[j],
                        ID = "court"+courts[j].Id + "_time" + new string(sessionItem.SessionTime.ToShortTimeString().TakeWhile(c => c != ':').ToArray())
                        //,
                        //AutoPostBack = true
                    };


                    //checkBox.CheckedChanged += new EventHandler(MyCheckedChanged);

                    //upPanel.ContentTemplateContainer.Controls.Add(checkBox);

                    //upPanel.Triggers.Add(new AsyncPostBackTrigger() { ControlID = checkBox.ID });
                    //UpdatePanel2.Triggers.Add(new PostBackTrigger() { ControlID = checkBox.ID });
                   
                    ((IParserAccessor)tableCell).AddParsedSubObject(checkBox);


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
            Label5.Text = DateTime.Now.ToString();
            Label5.Text += " Test: ";
            Label6.Text = "You have selected: ";
            IEnumerable<Control> cbList = GetAllControls(Table1);

            var enumerable = cbList as IList<Control> ?? cbList.ToList();
            
            foreach (var ctrl in enumerable)
            {
                if (ctrl.GetType() == typeof (CheckBox))
                {
                    var cbBox = (CheckBox) ctrl;
                    if (cbBox.Checked)
                    {
                        Label5.Text += ctrl.ID + " ";
                        Label6.Text += ctrl.ID + " ";
                            //string.Format("session {0} {1}", ctrl.ID, Environment.NewLine);
                    }
                }
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
    }
}