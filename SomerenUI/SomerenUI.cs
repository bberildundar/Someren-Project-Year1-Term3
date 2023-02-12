using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SomerenDAL;
using System.Drawing;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        DrinkService drinkService;
        RoomService roomService;
        StudentService studentService;
        TeacherService teacherService;
        RevenueReportService revenueReportService;
        CashRegisterService cashRegisterService;
        ActivityService activityService;
        SupervisorService supervisorService;
        ActivityStudentService activityStudentService;

        public SomerenUI()
        {
            InitializeComponent();
            drinkService = new DrinkService();
            roomService = new RoomService();
            studentService = new StudentService();
            teacherService = new TeacherService();
            revenueReportService = new RevenueReportService();
            cashRegisterService = new CashRegisterService();
            activityService = new ActivityService();
            supervisorService = new SupervisorService();
            activityStudentService = new ActivityStudentService();
        }

        public SomerenUI(string userName)
        {
            // Normal user panel
            InitializeComponent();
            drinkService = new DrinkService();
            roomService = new RoomService();
            studentService = new StudentService();
            teacherService = new TeacherService();
            revenueReportService = new RevenueReportService();
            cashRegisterService = new CashRegisterService();
            activityService = new ActivityService();
            supervisorService = new SupervisorService();
            activityStudentService = new ActivityStudentService();

            NonVisibleControls();
        }

        private void NonVisibleControls()
        {
            // Buttons are nonvisible for normal user
            // (Normal users cannot add/delete/update or cannot get revenue report.)
            btnAdd.Visible = false;
            btnAddActivity.Visible = false;
            btnAddParticipant.Visible = false;
            btnAddSupervisor.Visible = false;
            btnChangeActivity.Visible = false;
            btnDelete.Visible = false;
            btnGetReport.Visible = false;
            btnRemoveActivity.Visible = false;
            btnRemoveParticipant.Visible = false;
            btnRemoveSupervisor.Visible = false;
            btnUpdate.Visible = false;
            btnCalculate.Visible = false;
            btnCheckOut.Visible = false;

            // Information label is nonvisible for normal user
            label1.Visible = false;
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        //Panel controles & Read list
        private void showPanel(string panelName)
        {
            try
            {
                //Hide all panels before opening the panel that you want to open
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlTeachers.Hide();
                pnlRooms.Hide();
                pnlActivities.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();
                pnlRevenueReport.Hide();
                pnlSupervisor.Hide();
                pnlParticipants.Hide();
                lbl_Dashboard.Visible = false;

                switch (panelName)//devide the cases into the following parameters.
                {// make enum with the names of panels
                    case "Dashboard":
                        imgDashboard.Show();
                        lbl_Dashboard.Visible = true;
                        break;

                    case "Students":
                        pnlStudents.Show();
                        ReadListOfStudents();
                        break;

                    case "Teachers":
                        pnlTeachers.Show();
                        ReadListOfTeachers();
                        break;

                    case "Activities":
                        pnlActivities.Show();
                        TextBoxActivitiesClear();
                        ReadListOfActivities();
                        break;

                    case "Rooms":
                        pnlRooms.Show();
                        ReadListOfRooms();
                        break;

                    case "Drinks":
                        pnlDrinks.Show();
                        TextBoxDrinkClear();
                        ReadListOfDrinks();
                        break;

                    case "CashRegister":
                        pnlCashRegister.Show();
                        ReadListOfStudentsCashRegister();
                        ReadListOfDrinksCashRegister();
                        break;

                    case "Revenue Report":
                        pnlRevenueReport.Show();
                        ReportClear();
                        break;

                    case "Supervisor":
                        pnlSupervisor.Show();
                        ReadListOfSupervisor();
                        break;

                    case "Activities For Students":
                        pnlParticipants.Show();
                        DisplayActivites();
                        EnableButtons();
                        break;
                }
            }
            catch (Exception e)
            {
                BaseDao.ErrorLogging(e);
                MessageBox.Show($"Something went wrong while loading the {panelName}: " + e.Message);
            }
        }
        private void ReadListOfStudents()
        {
            // fill the students listview within the students panel with a list of students
            List<Student> studentList = studentService.GetStudents(); ;

            // clear the listview before filling it again
            listViewStudents.Items.Clear();
            listViewStudents.FullRowSelect = true;

            foreach (Student s in studentList)
            {
                ListViewItem li = new ListViewItem(s.Number.ToString());
                li.SubItems.Add(s.FirstName);
                li.SubItems.Add(s.LastName);
                //take the only date values from the BirthDate, leaving time.
                li.SubItems.Add(s.BirthDate.ToString("dd/MM/yyyy"));

                listViewStudents.Items.Add(li);
            }
        }
        private void ReadListOfTeachers()
        {
            List<Teacher> teacherList = teacherService.GetTeachers();

            listViewTeachers.Items.Clear();
            listViewTeachers.FullRowSelect = true;


            foreach (Teacher t in teacherList)
            {
                ListViewItem li2 = new ListViewItem(t.Number.ToString());
                li2.SubItems.Add(t.FirstName);
                li2.SubItems.Add(t.LastName);
                //change supervisor values into the supervior and not.
                if (t.Supervisor)
                    li2.SubItems.Add("Supervisor");
                else
                    li2.SubItems.Add("not Supervisor");

                listViewTeachers.Items.Add(li2);
            }
        }
        private void ReadListOfActivities()
        {
            List<Activity> activitiesList = activityService.GetActivities();

            listViewActivities.Items.Clear();
            listViewActivities.FullRowSelect = true;

            foreach (Activity a in activitiesList)
            {
                ListViewItem li = new ListViewItem(a.ActivityName.ToString());
                //take the only date and time values from the ActivityDateTime, leaving miliseconds etc.
                li.SubItems.Add(a.ActivityDateTime.ToString("dd/MM/yyyy H:mm"));
                li.SubItems.Add(a.ActivityEndDateTime.ToString("dd/MM/yyyy H:mm"));
                li.Tag = a;

                listViewActivities.Items.Add(li);
            }
        }
        private void ReadListOfRooms()
        {
            List<Room> roomList = roomService.GetRooms(); ;

            listViewRooms.Items.Clear();
            listViewRooms.FullRowSelect = true;

            foreach (Room r in roomList)
            {
                ListViewItem li = new ListViewItem(r.Number.ToString());
                //change room type values into the teacher room and student room.
                if (r.Type)
                {
                    li.SubItems.Add("Teacher room");
                }
                else
                {
                    li.SubItems.Add("Student room");
                }
                li.SubItems.Add(r.Capacity.ToString());

                listViewRooms.Items.Add(li);
            }
        }
        private void ReadListOfDrinks()
        {
            List<Drink> drinkList = drinkService.GetDrinks();

            listViewDrinks.Items.Clear();
            listViewDrinks.FullRowSelect = true;
            listViewDrinks.Columns[0].DisplayIndex = 4;


            foreach (Drink d in drinkList)
            {
                string fileLocation = @"..\..\..\icon.jpg";
                ImageList photoList = new ImageList();
                ListViewItem li = new ListViewItem();

                if (d.Stock < 10)
                {
                    photoList.ImageSize = new Size(20, 20);
                    photoList.Images.Add(Image.FromFile(fileLocation));
                    listViewDrinks.SmallImageList = photoList;
                    li.ImageIndex = 0;
                }
                //set the icon in the 4th column
                li.SubItems.Add(d.Name.ToString());
                if (d.Type)
                {
                    li.SubItems.Add("Alcohole");
                }
                else
                {
                    li.SubItems.Add("Non-Alcohole");
                }
                li.SubItems.Add(d.Price.ToString("0.00"));
                li.SubItems.Add(d.Stock.ToString());
                li.Tag = d;
                listViewDrinks.Items.Add(li);
            }
        }
        private void ReadListOfStudentsCashRegister()
        {
            // fill the students listview within the students panel with a list of students
            List<Student> studentList = studentService.GetStudents();

            // clear the listview before filling it again
            listViewStudentsCashRegister.Items.Clear();
            listViewStudentsCashRegister.FullRowSelect = true;

            foreach (Student s in studentList)
            {
                ListViewItem li = new ListViewItem(s.Number.ToString());
                li.SubItems.Add(s.FirstName);
                li.SubItems.Add(s.LastName);

                listViewStudentsCashRegister.Items.Add(li);
            }
        }
        private void ReadListOfDrinksCashRegister()
        {
            List<Drink> drinkList = drinkService.GetDrinks(); ;

            // clear the listview before filling it again
            listViewDrinksCashRegister.Items.Clear();
            listViewDrinksCashRegister.FullRowSelect = true;
            cmbAmount.SelectedIndex = 0;

            foreach (Drink d in drinkList)
            {
                ListViewItem li = new ListViewItem(d.Name);
                //change alcohole values into the alcoholic and not.
                if (d.Type)
                {
                    li.SubItems.Add("Alcohole");
                }
                else
                {
                    li.SubItems.Add("Non-Alcohole");
                }
                li.SubItems.Add(d.Price.ToString("f2"));
                li.SubItems.Add(d.Stock.ToString());
                li.Tag = d;

                listViewDrinksCashRegister.Items.Add(li);
            }
        }
        private void ReadListOfSupervisor()
        {
            listViewSupervisor.Items.Clear();
            listViewNonSupervisor.Items.Clear();
            listViewActivity.Items.Clear();

            listViewSupervisor.FullRowSelect = true;
            listViewNonSupervisor.FullRowSelect = true;
            listViewActivity.FullRowSelect = true;

            List<Activity> activitiesList = activityService.GetActivities();


            foreach (Activity a in activitiesList)
            {
                ListViewItem li = new ListViewItem(a.ActivityName.ToString());
                //take the only date and time values from the ActivityDateTime, leaving miliseconds etc.
                li.SubItems.Add(a.ActivityDateTime.ToString("dd/MM/yyyy H:mm"));
                li.SubItems.Add(a.ActivityEndDateTime.ToString("dd/MM/yyyy H:mm"));
                li.Tag = a;
                listViewActivity.Items.Add(li);
            }
        }

        //Main screen
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        //Menu controles
        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }
        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }
        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }
        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }
        private void drinksManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
        }
        private void cashRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("CashRegister");
        }
        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Revenue Report");
        }
        private void supervisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisor");
        }
        private void participatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities For Students");
        }

        // Assignment3

        //Drink management functions
        private void listViewDrinks_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (listViewDrinks.SelectedItems.Count == 0)
                {
                    return;
                }
                Drink selectedDrink = (Drink)listViewDrinks.SelectedItems[0].Tag;
                txtName.Text = selectedDrink.Name;
                txtPrice.Text = selectedDrink.Price.ToString("0.00");
                txtStock.Text = selectedDrink.Stock.ToString();
                if (selectedDrink.Type)
                {
                    cmbType.SelectedIndex = 1;//Alcohole
                }
                else
                {
                    cmbType.SelectedIndex = 2;//non-alcohole
                }
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }

            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void TextBoxDrinkClear()//initialize the text box
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            cmbType.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //check if all of necessary field is filled up, otherwise throw an exception.
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtStock.Text))
                {
                    MessageBox.Show("Please type all of mendatory fields.", "ERROR");
                    return;
                }
                Drink newDrink = new Drink();
                newDrink.Name = txtName.Text;
                if (cmbType.SelectedIndex == 1)
                {
                    newDrink.Type = true;
                }
                else if (cmbType.SelectedIndex == 2)
                {
                    newDrink.Type = false;
                }
                newDrink.Price = decimal.Parse(txtPrice.Text);
                newDrink.Stock = int.Parse(txtStock.Text);
                drinkService.Add(newDrink);
                TextBoxDrinkClear();
                showPanel("Drinks");
                MessageBox.Show("New drink is added!", "SUCCESS");
            }
            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDrinks.SelectedItems.Count > 0)//check if an item selected.
                {
                    Drink deleteDrink = (Drink)listViewDrinks.SelectedItems[0].Tag;
                    drinkService.Delete(deleteDrink);
                    TextBoxDrinkClear();
                    showPanel("Drinks");
                    MessageBox.Show("The drink is deleted!", "SUCCESS");
                }
            }

            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDrinks.SelectedItems[0] == null)
                {
                    return;
                }
                Drink updatedDrink = (Drink)listViewDrinks.SelectedItems[0].Tag;
                updatedDrink.Name = txtName.Text;
                updatedDrink.Price = decimal.Parse(txtPrice.Text);
                updatedDrink.Type = cmbType.SelectedIndex == 1;//Type =true -> Index =1
                updatedDrink.Stock = int.Parse(txtStock.Text);

                drinkService.Update(updatedDrink);
                TextBoxDrinkClear();//clear text box
                showPanel("Drinks");//refresh panel
                MessageBox.Show("The drink is updated!", "SUCCESS");
            }

            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation_Numaric(sender, e);
        }
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation_Numaric(sender, e);
        }
        private static void Validation_Numaric(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //Cash Register functions
        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            if (listViewDrinksCashRegister.SelectedItems.Count > 0)
            {
                int amount = int.Parse(cmbAmount.SelectedItem.ToString());
                decimal priceToPay = 0;

                if (amount > int.Parse(listViewDrinksCashRegister.SelectedItems[0].SubItems[3].Text))
                {
                    MessageBox.Show("Please enter a valid amount!, Invalid Amount", "ERROR");
                }
                else if (amount == 0)
                {
                    MessageBox.Show("Please enter an amount.", "ERROR");
                }
                else
                {
                    priceToPay = amount * decimal.Parse(listViewDrinksCashRegister.SelectedItems[0].SubItems[2].Text);
                }
                txtTotal.Text = $"{priceToPay: 0.00}";
            }
            else
            {
                MessageBox.Show("Please select the student and drink first.", "ERROR");
            }
        }
        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            if (listViewDrinksCashRegister.SelectedItems.Count > 0 && listViewStudentsCashRegister.SelectedItems.Count > 0 && txtTotal.Text != "")
            {
                //make a sales record
                Sale s = new Sale();
                Drink selectedDrink = (Drink)listViewDrinksCashRegister.SelectedItems[0].Tag;
                s.SaleId = 0;
                s.StudentId = int.Parse(listViewStudentsCashRegister.SelectedItems[0].SubItems[0].Text);
                s.DrinkId = selectedDrink.Id;
                s.SaleCount = int.Parse(cmbAmount.SelectedItem.ToString());
                s.TotalPayment = decimal.Parse(txtTotal.Text);
                s.SaleDate = DateTime.Now;

                //update drink stock 
                selectedDrink.Stock -= s.SaleCount;

                //set the textbox empty
                cmbAmount.SelectedIndex = 0;
                txtTotal.Clear();

                if (selectedDrink.Stock < 0)// go back if the stock is not enough
                {
                    MessageBox.Show("Stock is not enough, choose another drink.", "ERROR");
                    return;
                }

                //execute to add the sale and update current stock.
                cashRegisterService.AddSale(s);
                drinkService.Update(selectedDrink);

                txtTotal.Clear();
                cmbAmount.SelectedIndex = 0;

                ReadListOfDrinksCashRegister();
                ReadListOfStudentsCashRegister();
            }
            else
            {
                MessageBox.Show("To checkout, please be sure that you chose student and drink, then you calculated the total.", "ERROR");
            }
        }

        //Revenue Report functions
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
                {
                    MessageBox.Show("YOU CANNOT GET REPORT WITH INVALID DATE!", "ERROR");
                }
                else if (dtpDateFrom.Value.Date > DateTime.Now.Date || dtpDateTo.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("YOU CANNOT CHOOSE A FUTURE DATE!", "ERROR");
                }
                else
                {
                    RevenueReport revenueReport = revenueReportService.GetSales(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);
                    lblSalesReport.Text = revenueReport.NumberOfSales.ToString();
                    lblTotalCustomer.Text = revenueReport.NumberOfCustomers.ToString();
                    lblTurnOver.Text = $" € {revenueReport.TurnOver.ToString("00.00")}";
                }
            }
            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void ReportClear()//initialize the text box
        {
            lblSalesReport.Text = "0";
            lblTurnOver.Text = "0";
            lblTotalCustomer.Text = "0";
        }

        //Assignment4

        //Beril
        //4th Assignment Variant A: List Of Activities        

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewActivities.SelectedItems.Count == 0)
                {
                    return;
                }

                Activity selectedActivity = (Activity)listViewActivities.SelectedItems[0].Tag;
                txtNewActivityName.Text = selectedActivity.ActivityName;
                datePickerActivities.Value = Convert.ToDateTime(selectedActivity.ActivityDateTime.ToString("dd/MM/yyyy"));
                timePickerActivities.Value = Convert.ToDateTime(selectedActivity.ActivityDateTime.ToString("H:mm"));
                datePickerEnding.Value = Convert.ToDateTime(selectedActivity.ActivityEndDateTime.ToString("dd/MM/yyyy"));
                timePiclerEnding.Value = Convert.ToDateTime(selectedActivity.ActivityEndDateTime.ToString("H:mm"));

                btnChangeActivity.Enabled = true;
                btnRemoveActivity.Enabled = true;
                btnAddActivity.Enabled = false;
                btnAddActivity.Text = "To add new activity, please refresh this panel by clicking 'Activities' above.";
            }
            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void TextBoxActivitiesClear()
        {
            btnAddActivity.Text = "Add Activity";
            btnChangeActivity.Enabled = false;
            btnRemoveActivity.Enabled = false;
            btnAddActivity.Enabled = true;

            txtNewActivityName.Clear();
            datePickerActivities.Refresh();
            timePickerActivities.Refresh();
        }
        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewActivityName.Text))
            {
                MessageBox.Show("Please enter an activity name and select a datetime.", "ERROR");
            }
            else
            {
                DateTime activityTime = datePickerActivities.Value.Date + timePickerActivities.Value.TimeOfDay;
                DateTime activityEndTime = datePickerEnding.Value.Date + timePiclerEnding.Value.TimeOfDay;

                if (activityTime > activityEndTime)
                {
                    MessageBox.Show("Please enter valid dates and times.", "ERROR");
                    return;
                }
                else if (activityTime < DateTime.Now)
                {
                    MessageBox.Show("You entered a past date.", "ERROR");
                    return;
                }

                Activity newActivity = new Activity();                
                newActivity.ActivityName = txtNewActivityName.Text;
                newActivity.ActivityDateTime = activityTime;
                newActivity.ActivityEndDateTime = activityEndTime;

                //checking if the activity already exists:
                List<Activity> oldActivities = activityService.GetActivities();

                if (oldActivities.Contains(newActivity))
                {
                    //when the activity exists:
                    MessageBox.Show("This activity already exists. Please enter a valid activity.", "ERROR");                    
                    return;
                }
                else
                {
                    //adding the activity if it doesnt exist:
                    activityService.AddActivity(newActivity);
                }

                TextBoxActivitiesClear();
                showPanel("Activities");

                MessageBox.Show("Activity has been added.", "SUCCESS");
            }
        }
        private void btnChangeActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewActivities.SelectedItems[0] == null)
                {
                    return;
                }

                //processing the change

                if (string.IsNullOrEmpty(txtNewActivityName.Text))
                {
                    MessageBox.Show("Please enter an activity name.", "ERROR");
                }
                else
                {
                    DateTime activityTime = datePickerActivities.Value.Date + timePickerActivities.Value.TimeOfDay;
                    DateTime activityEndTime = datePickerEnding.Value.Date + timePiclerEnding.Value.TimeOfDay;

                    if (activityTime > activityEndTime)
                    {
                        MessageBox.Show("Please enter valid dates and times.", "ERROR");
                        return;
                    }
                    else if (activityTime < DateTime.Now)
                    {
                        MessageBox.Show("You entered a past date.", "ERROR");
                        return;
                    }

                    Activity changedActivity = (Activity)listViewActivities.SelectedItems[0].Tag;

                    changedActivity.ActivityName = txtNewActivityName.Text;
                    changedActivity.ActivityDateTime = activityTime;
                    changedActivity.ActivityEndDateTime = activityEndTime;

                    activityService.ChangeActivity(changedActivity);

                    TextBoxActivitiesClear();
                    showPanel("Activities");

                    MessageBox.Show("Activity has been changed.", "SUCCESS");
                }
            }

            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this activity?", "CONFIRMATION", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    activityService.RemoveActivity((Activity)listViewActivities.SelectedItems[0].Tag);

                    TextBoxActivitiesClear();
                    showPanel("Activities");
                    MessageBox.Show("Activity is removed.", "SUCCESS");
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        //Hyunwoo
        //4th Assignment Variant B: Acitivity Supervisor functions

        private void listViewActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewActivity.SelectedItems.Count == 0)
                {
                    return;
                }
                DisplaySupervisor();
                DisplayNonSupervisor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void listViewSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddSupervisor.Enabled = false;
            btnRemoveSupervisor.Enabled = true;
            listViewNonSupervisor.SelectedIndices.Clear();
        }
        private void listViewNonSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveSupervisor.Enabled = false;
            btnAddSupervisor.Enabled = true;
            listViewSupervisor.SelectedIndices.Clear();
        }
        private void btnAddSupervisor_Click(object sender, EventArgs e)
        {
            if (listViewNonSupervisor.SelectedItems.Count == 0 || listViewActivity.SelectedItems.Count == 0)
            {
                return;
            }
            try
            {
                Teacher selectedTeacher = (Teacher)listViewNonSupervisor.SelectedItems[0].Tag;
                Activity selectedActivity = (Activity)listViewActivity.SelectedItems[0].Tag;
                Supervisor newSupervisor = new Supervisor();
                newSupervisor.ActivityId = selectedActivity.ActivityId;
                newSupervisor.LecturerId = selectedTeacher.Number;
                supervisorService.AddSupervisor(newSupervisor);
                //Validation
                DisplaySupervisor();
                DisplayNonSupervisor();
                btnAddSupervisor.Enabled = false;
            }
            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void btnRemoveSupervisor_Click(object sender, EventArgs e)
        {
            if (listViewSupervisor.SelectedItems.Count == 0 || listViewActivity.SelectedItems.Count == 0)
            {
                return;
            }
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this Supervisor?", "CONFIRMATION", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Teacher selectedTeacher = (Teacher)listViewSupervisor.SelectedItems[0].Tag;
                    Activity selectedActivity = (Activity)listViewActivity.SelectedItems[0].Tag;
                    Supervisor supervisor = new Supervisor();
                    supervisor.ActivityId = selectedActivity.ActivityId;
                    supervisor.LecturerId = selectedTeacher.Number;
                    supervisorService.RemoveSupervisor(supervisor);
                    //Validation
                    DisplaySupervisor();
                    DisplayNonSupervisor();
                    btnRemoveSupervisor.Enabled = false;
                    MessageBox.Show("Supervisor is removed.", "SUCCESS");
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            catch (Exception ex)
            {
                BaseDao.ErrorLogging(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void DisplaySupervisor()
        {
            Activity selectedActivity = (Activity)listViewActivity.SelectedItems[0].Tag;

            //Supervisor list view
            List<Teacher> supervisors = teacherService.GetSupervisor(selectedActivity);

            listViewSupervisor.Items.Clear();
            listViewSupervisor.FullRowSelect = true;

            foreach (Teacher te in supervisors)
            {
                ListViewItem li2 = new ListViewItem(te.Number.ToString());
                li2.SubItems.Add(te.FirstName);
                li2.SubItems.Add(te.LastName);
                li2.Tag = te;
                //change supervisor values into the supervior and not.

                listViewSupervisor.Items.Add(li2);
            }
        }
        private void DisplayNonSupervisor()
        {
            Activity selectedActivity = (Activity)listViewActivity.SelectedItems[0].Tag;

            List<Teacher> nonSupervisors = teacherService.GetNonSupervisor(selectedActivity);

            listViewNonSupervisor.Items.Clear();
            listViewNonSupervisor.FullRowSelect = true;

            foreach (Teacher te in nonSupervisors)
            {
                ListViewItem li2 = new ListViewItem(te.Number.ToString());
                li2.SubItems.Add(te.FirstName);
                li2.SubItems.Add(te.LastName);
                if (te.Supervisor)
                {
                    li2.SubItems.Add("Supervisor");
                }
                else
                {
                    li2.SubItems.Add("Non-Supervisor");
                }
                li2.Tag = te;

                listViewNonSupervisor.Items.Add(li2);
            }
        }

        //Vedat
        //4th Assignment Variant C: Activity Student functions
        private void EnableButtons()
        {
            btnRemoveParticipant.Enabled = false;
            btnAddParticipant.Enabled = false;
        }
        private void DisplayActivites()
        {
            List<Activity> activitiesList = activityService.GetActivities();

            // Clear the items
            listViewActivityPa.Items.Clear();
            listViewActivityPa.FullRowSelect = true;

            foreach (Activity activity in activitiesList)
            {
                ListViewItem item = new ListViewItem(activity.ActivityName.ToString());
                item.SubItems.Add(activity.ActivityDateTime.ToString("dd/MM/yyyy H:mm"));
                item.SubItems.Add(activity.ActivityEndDateTime.ToString("dd/MM/yyyy H:mm"));
                item.Tag = activity;

                listViewActivityPa.Items.Add(item);
            }
        }
        private void DisplayParticipant()
        {
            Activity activity = (Activity)listViewActivityPa.SelectedItems[0].Tag;
            int activityId = activity.ActivityId;

            listViewParticipants.Items.Clear();
            listViewParticipants.FullRowSelect = true;

            List<Student> activityStudents = activityStudentService.GetParticipants(activityId);

            foreach (Student activityStudent in activityStudents)
            {
                ListViewItem li = new ListViewItem(activityStudent.Number.ToString());
                li.SubItems.Add(activityStudent.FirstName);
                li.SubItems.Add(activityStudent.LastName);
                li.SubItems.Add(activityStudent.BirthDate.ToString("dd/MM/yyyy"));
                li.Tag = activityStudent;

                listViewParticipants.Items.Add(li);
            }
        }
        private void DisplayNonParticipant()
        {
            Activity activity = (Activity)listViewActivityPa.SelectedItems[0].Tag;
            int activityId = activity.ActivityId;

            listViewNonParticipants.Items.Clear();
            listViewNonParticipants.FullRowSelect = true;

            List<Student> nonParticipators = activityStudentService.GetNotParticipators(activityId);

            foreach (Student nonParticipator in nonParticipators)
            {
                ListViewItem li = new ListViewItem(nonParticipator.Number.ToString());
                li.SubItems.Add(nonParticipator.FirstName);
                li.SubItems.Add(nonParticipator.LastName);
                li.SubItems.Add(nonParticipator.BirthDate.ToString("dd/MM/yyyy"));
                li.Tag = nonParticipator;

                listViewNonParticipants.Items.Add(li);
            }
        }
        private void listViewActivityPa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewActivityPa.SelectedItems.Count == 0)
            {
                return;
            }
            // Show the two listview again
            DisplayParticipant();
            DisplayNonParticipant();
        }
        private void listViewParticipants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewParticipants.SelectedItems.Count == 0)
            {
                return;
            }
            btnRemoveParticipant.Enabled = (listViewParticipants.SelectedItems.Count >= 0);
            listViewNonParticipants.SelectedIndices.Clear();
            btnAddParticipant.Enabled = false;
        }
        private void listViewNonParticipants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNonParticipants.SelectedItems.Count == 0)
            {
                return;
            }
            btnAddParticipant.Enabled = (listViewNonParticipants.SelectedItems.Count >= 0);
            listViewParticipants.SelectedIndices.Clear();
            btnRemoveParticipant.Enabled = false;
        }
        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            if (listViewNonParticipants.SelectedItems.Count == 0 || listViewActivityPa.SelectedItems.Count == 0)
            {
                return;
            }
            try
            {
                ActivityStudent activityStudent = new ActivityStudent();

                Student student = (Student)listViewNonParticipants.SelectedItems[0].Tag;
                Activity activity = (Activity)listViewActivityPa.SelectedItems[0].Tag;

                activityStudent.StudentId = student.Number;
                activityStudent.ActivityId = activity.ActivityId;

                activityStudentService.AddParticipant(activityStudent);

                DisplayParticipant();
                DisplayNonParticipant();
            }
            catch (Exception exp)
            {
                BaseDao.ErrorLogging(exp);
                MessageBox.Show(exp.Message, "Error Occured");
            }

        }
        private void btnRemoveParticipant_Click(object sender, EventArgs e)
        {

            if (listViewActivityPa.SelectedItems.Count == 0 || listViewParticipants.SelectedItems.Count == 0)
            {
                return;
            }

            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this participant?", "CONFIRMATION", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ActivityStudent activityStudent = new ActivityStudent();

                    Student student = (Student)listViewParticipants.SelectedItems[0].Tag;
                    Activity activity = (Activity)listViewActivityPa.SelectedItems[0].Tag;

                    activityStudent.StudentId = student.Number;
                    activityStudent.ActivityId = activity.ActivityId;

                    activityStudentService.DeleteParticipant(activityStudent);
                }
                else
                {
                    return;
                }
                DisplayParticipant();
                DisplayNonParticipant();
            }
            catch (Exception exp)
            {
                BaseDao.ErrorLogging(exp);
                MessageBox.Show(exp.Message, "Error Occured");
            }

        }
    }
}
