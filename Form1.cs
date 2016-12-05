using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using test;

namespace Karma
{
    public partial class Form1 : Form
    {
        private bool isMouseDown = false;
        private Point FormLocation;
        // The location of form
        private Point mouseOffset;
        // The location of mouse 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0; int _y = 0; if (isMouseDown) { Point pt = Control.MousePosition; _x = mouseOffset.X - pt.X; _y = mouseOffset.Y - pt.Y; this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y); }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        // If click Exit, close this application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Check student ID validation
            char[] test = txtStudentID.Text.ToCharArray();
            bool invalid = false;
            for(int i = 0;i<test.Length; i++)
            {
                if ((int)test[i] < (int)'0' || (int)test[i] > (int)'9')
                {
                    invalid = true;
                    break;
                }
                    
            }

            // Eneter admin page
            if (txtStudentID.Text.Equals("admin"))
            {
                lblMessage.Text = "";
                lblPlease.Visible = false;
                txtStudentID.Visible = false;
                btnEnter.Visible = false;
                txtWelcome.Visible = true;
                //lblWelcome.Text = "Welcome, administrator! \nHere is result of roomats:";
                showName.Visible = true;
                showName.Text = "Admin";
                //Roomlist.Text = "The Completed Pairings ";

                Roomlist.Visible = true;
                String[,] list = Check.findAllRoomate();
                for (int i = 0;i<list.Length/2;i++)
                {
                    Roomlist.Text += "\r\n" + "Student A : "+list[i,0] +" | Student B : "+ list[i,1] ;
                }
            }
            // Incorrect input
            else if (invalid)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please enter your student ID ;)";
            }
            // Enter student page
            else
            {
                // !!Check if there exist this student:
                 StudentInfo studentInfo = Check.CheckStudent(txtStudentID.Text);
                // 
                //int studentInfo = test[1];

                lblMessage.Text = "";
                lblPlease.Visible = false;
                txtStudentID.Visible = false; 
                btnInfomation.Visible = true;
                showName.Visible = true;
                showName.Text = txtStudentID.Text;
                btnFindRoomate.Visible = true;
                // If no such student in database
                 if (studentInfo == null)
                //if (studentInfo == '0')
                {
                    btnFindRoomate.Enabled = false;
                }
                else
                {
                    StudentInformationEnable(false);
                    btnFindRoomate.Enabled = true;
                }
                btnEnter.Visible = false;
            }

        }

        private void btnInfomation_Click(object sender, EventArgs e)
        {
            ChangePage("Information");
            //Could use this to set the information
            //cmbCharacter.SelectedIndex = 1;
            StudentInfo studentInfo = Check.CheckStudent(txtStudentID.Text);
            //lblStudentGender.Visible = true;
            if (studentInfo == null)
            {
                
            }
            else
            {
                String[] Str = { "Sport", "Study", "Read", "Music", "Art", "Game", "Movie" };

                txtID.Text = studentInfo.getStudentID();
                txtStudentName.Text = studentInfo.getStudentName();
                txtStudentBirth.Text = Convert.ToString(studentInfo.getStudentBirth());

                int gender = studentInfo.getStudentGender();
                if (gender == 1)
                {
                    rdoFemale.Checked = false;
                    rdoMale.Checked = true;
                }


                StudentHabit studentHabit = Check.CheckStuHabit(txtStudentID.Text);
                if (studentHabit == null)
                {
                    lblInfoMessage.Text = "you haven't submit you habit.";
                }
                else
                {
                    //get interest;
                   
                    
                    for (int i = 0; i < 7;i++)
                    {
                        
                        if (studentHabit.getInterest().Contains(Str[i]))
                        {
                            //MessageBox.Show(Str[i]);
                            clbInterests.SetItemChecked(i,true);
                        }
                        
                        //clbInterests.CheckedItems(clbInterests[i]);
                        //interest = interest + "," + tmp.ToString();
                    }
                    //get other habits
                    cmbCharacter.SelectedIndex = studentHabit.getCharacter();
                    cmbBedtime.SelectedIndex = studentHabit.getBedtime();
                    cmbWaketime.SelectedIndex = studentHabit.getWaketime();
                    cmbSmoke.SelectedIndex = studentHabit.getSmoke();
                    cmbClean.SelectedIndex = studentHabit.getClean();
                }


                StudentWill studentWill = Check.CheckStuWill(txtStudentID.Text);
                if (studentWill == null)
                {
                    lblInfoMessage.Text = "Please fill your information";
                }
                else
                {
                    //get interest;
                    //String[] Str = { "Sport", "Study", "Read", "Music", "Art", "Game", "Movie" };

                    for (int i = 0; i < 7; i++)
                    {

                        if (studentWill.getW_interest().Contains(Str[i]))
                        {
                            //MessageBox.Show(Str[i]);
                            clbWInterests.SetItemChecked(i, true);
                        }

                        //clbInterests.CheckedItems(clbInterests[i]);
                        //interest = interest + "," + tmp.ToString();
                    }
                    //get other habits
                    cmbWCharacter.SelectedIndex = studentWill.getW_character();
                    cmbWBedtime.SelectedIndex = studentWill.getW_bedtime();
                    cmbWWaketime.SelectedIndex = studentWill.getW_waketime();
                    cmbWSmoke.SelectedIndex = studentWill.getW_smoke();
                    cmbWClean.SelectedIndex = studentWill.getW_clean();
                }
            }

            

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            lblMessage.Text = "";
            
            showName.Text = "";
            showName.Visible = false;
            lblPlease.Visible = true;
            txtStudentID.Visible = true;
            btnEnter.Visible = true;

            showRoomateInfo.Visible = false;
            btnRoomInfo.Visible = false;
            lblRoomID.Visible = false;
            lblRoomName.Visible = false;
            lblRoomBirth.Visible = false;
            txtRoomID.Visible = false;
            txtRoomName.Visible = false;
            txtRoomBirth.Visible = false;
            txtWelcome.Visible = false;
            Roomlist.Visible = false;

            txtID.Text = "";
            lblInfoMessage.Text = "";
            txtStudentName.Text = "";
            txtStudentBirth.Text = "eg.19970723";
            rdoFemale.Visible = true;
            
            cmbCharacter.SelectedIndex = -1;

            for (int i = 0; i < 7 ;i++)
            {
                clbInterests.SetItemChecked(i, false);
                clbWInterests.SetItemChecked(i,false);
            }
            
            cmbBedtime.SelectedIndex = -1;
            cmbWaketime.SelectedIndex = -1;
            cmbSmoke.SelectedIndex = -1;
            cmbClean.SelectedIndex = -1;

            cmbWCharacter.SelectedIndex = -1;
            
            cmbWBedtime.SelectedIndex = -1;
            cmbWWaketime.SelectedIndex = -1;
            cmbWSmoke.SelectedIndex = -1;
            cmbWClean.SelectedIndex = -1;
            ChangePage("home");
            StudentInformationEnable(true);


        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            showRoomateInfo.Visible = false;
            btnRoomInfo.Visible = false;
            lblRoomID.Visible = false;
            lblRoomName.Visible = false;
            lblRoomBirth.Visible = false;
            txtRoomID.Visible = false;
            txtRoomName.Visible = false;
            txtRoomBirth.Visible = false;
            txtWelcome.Visible = false;

            btnEnter.Visible = false;
            ChangePage("back");
            
        }

        public void ChangePage(String pagename)
        {
            bool state = true;
            bool inversestate = true;
           
            if (pagename.Equals("Information"))
            {
                state = false;
                inversestate = true;
            }
            else if (pagename.Equals("back"))
            {
                state = true;
                inversestate = false;
            }else if (pagename.Equals("home"))
            {
                state = false;
                inversestate = false;
               
            }


            btnInfomation.Visible = state;
            btnFindRoomate.Visible = state;
            

            showInformation.Visible = inversestate;
            showYourInfo.Visible = inversestate;


            btnSave.Visible = inversestate;
            btnBack.Visible = inversestate;

            lblInfoMessage.Visible = inversestate;

            // Your info part
            lblStudentID.Visible = inversestate;
            txtID.Visible = inversestate;
            txtID.Text = txtStudentID.Text;
            lblStudentName.Visible = inversestate;
            txtStudentName.Visible = inversestate;
            lblStudentBirth.Visible = inversestate;
            txtStudentBirth.Visible = inversestate;
            lblStudentGender.Visible = inversestate;
            rdoFemale.Visible = inversestate;
            rdoMale.Visible = inversestate;

            // Tab part
            tab.Visible = inversestate;

            // Your habit part
            lblCharacter.Visible = inversestate;
            lblInterest.Visible = inversestate;
            lblBedtime.Visible = inversestate;
            lblWaketime.Visible = inversestate;
            lblSmoke.Visible = inversestate;
            lblClean.Visible = inversestate;
            cmbCharacter.Visible = inversestate;
            clbInterests.Visible = inversestate;
            cmbBedtime.Visible = inversestate;
            cmbWaketime.Visible = inversestate;
            cmbSmoke.Visible = inversestate;
            cmbClean.Visible = inversestate;

            // Your will part
            lblWCharacter.Visible = inversestate;
            lblWInterests.Visible = inversestate;
            lblWBedtime.Visible = inversestate;
            lblWWaketime.Visible = inversestate;
            lblWSmoke.Visible = inversestate;
            lblWClean.Visible = inversestate;
            cmbWCharacter.Visible = inversestate;
            clbWInterests.Visible = inversestate;
            cmbWBedtime.Visible = inversestate;
            cmbWWaketime.Visible = inversestate;
            cmbWSmoke.Visible = inversestate;
            cmbWClean.Visible = inversestate;

        }

        private void StudentInformationEnable(bool state)
        {
            txtStudentName.Enabled = state;
            txtStudentBirth.Enabled = state;
            rdoFemale.Enabled = state;
            rdoMale.Enabled = state;

            btnSave.Enabled = state;

            //// Your habit part
            cmbCharacter.Enabled = state;
            clbInterests.Enabled = state;
            cmbBedtime.Enabled = state;
            cmbWaketime.Enabled = state;
            cmbSmoke.Enabled = state;
            cmbClean.Enabled = state;

            //// Your will part
            cmbWCharacter.Enabled = state;
            clbWInterests.Enabled = state;
            cmbWBedtime.Enabled = state;
            cmbWWaketime.Enabled = state;
            cmbWSmoke.Enabled = state;
            cmbWClean.Enabled = state;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // !!Save the information in to database
            // Store the informaton of student
            String studentID = txtStudentID.Text;
            String studentName = txtStudentName.Text;
            int studentBirth = int.Parse(txtStudentBirth.Text);
            int studentGender;
            if (rdoFemale.Checked)
            {
                studentGender = 0;
            }
            else
            {
                studentGender = 1;
            }
            StudentInfo studentI = new StudentInfo(studentID, studentName, studentBirth, studentGender);
            int save = Check.storeStudentInfo(studentI);

            int character = cmbCharacter.SelectedIndex;
            String interest = "";
            foreach (object tmp in clbInterests.CheckedItems)
            {
                interest = interest+tmp.ToString()+",";
            }
            int bedtime = cmbBedtime.SelectedIndex;
            int waketime = cmbWaketime.SelectedIndex;
            int smoke = cmbSmoke.SelectedIndex;
            int clean = cmbClean.SelectedIndex;
            StudentHabit studentHabit = new StudentHabit(studentID, character, interest, bedtime, waketime, smoke, clean);
            int a = Check.storeStudentHabit(studentHabit);

            int Wcharacter = cmbWCharacter.SelectedIndex;
            String Winterest = "";
            foreach (object tmp in clbInterests.CheckedItems)
            {
                Winterest = Winterest  + tmp.ToString() + ",";
            }
            int Wbedtime = cmbWBedtime.SelectedIndex;
            int Wwaketime = cmbWWaketime.SelectedIndex;
            int Wsmoke = cmbWSmoke.SelectedIndex;
            int Wclean = cmbWClean.SelectedIndex;
            StudentWill studentWill = new StudentWill(studentID, Wcharacter, Winterest, Wbedtime, Wwaketime, Wsmoke, Wclean);
            int b = Check.storeStudentWill(studentWill);

            // Store StudnetHabit studentH
            // Store StudentWill studentW

            //int save = 1;
            if (save == 1 && a == 1 && b==1)
            {
                
                //if(rdoFemale.Checked ) lblInfoMessage.Text ="女生" + cmbCharacter.SelectedIndex +a ;
                //else lblInfoMessage.Text = "男生" + cmbCharacter.SelectedIndex + a;
                lblInfoMessage.Text = "Information have saved!";
            }
            else
            {
                lblInfoMessage.Text = "Please input all the information!";
            }
        }

        private void btnFindRoomate_Click(object sender, EventArgs e)
        {

             btnInfomation.Visible = false;
             btnFindRoomate.Visible = false;
             btnBack.Visible = true;
            //String[] roommate = new String[1];
            String  roommate = Check.findRoomate(showName.Text);
            String roommateID = "";
            //StudentRoomate studentRoomate = Check.CheckStuRoomate(showName.Text);
            ///if (studentRoomate == null)
            //{

            //}
            //else
            //{
            if (!roommate.Equals( "No way!"))
            {
                roommateID = roommate;
                StudentInfo studentR = Check.CheckStudent(roommateID);
                if (studentR == null)
                {
                    MessageBox.Show(" Sorry your roomate still in the way.");
                }
                else
                {
                    showRoomateInfo.Visible = true;
                    btnRoomInfo.Visible = true;
                    lblRoomID.Visible = true;
                    lblRoomName.Visible = true;
                    lblRoomBirth.Visible = true;
                    txtRoomID.Visible = true;
                    txtRoomName.Visible = true;
                    txtRoomBirth.Visible = true;
                    
                    txtRoomID.Text = studentR.getStudentID();
                    txtRoomName.Text = studentR.getStudentName();
                    txtRoomBirth.Text = studentR.getStudentBirth().ToString();
                }

                //}
            }else
            {
                MessageBox.Show(" Sorry your roomate still in the way.");
                //txtRoomName.Text = roommate;
                showRoomateInfo.Visible = true;
                btnRoomInfo.Visible = true;
                lblRoomID.Visible = true;
                lblRoomName.Visible = true;
                lblRoomBirth.Visible = true;
                txtRoomID.Visible = true;
                txtRoomName.Visible = true;
                txtRoomBirth.Visible = true;
            }

        }
    }

   
}
