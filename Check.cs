using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Karma
{
    class Check
    {
        static string con = "Host = localhost; Database = information; Username = root; Password =";
        static MySqlConnection mycon = null;

        static int Count(MySqlDataReader dr)
        {
            int i = 0;
            while (dr.Read())
                i += 1;
            return i;
        }
        static public int storeStudentInfo(StudentInfo studentI)
        {

            try
            {
                string getName = studentI.getStudentName();
                string getID = studentI.getStudentID();
                int getBirth = studentI.getStudentBirth();
                int getGender = studentI.getStudentGender();

                mycon = new MySqlConnection(con);
                mycon.Open();
                MySqlCommand mycom = null;

                String sql = "INSERT INTO `information`(`studentID`, `studentName`, `studentBirth`, `studentGender`) VALUES ('" + getID + "','" + getName + "','" + getBirth + "','" + getGender + "' )";
                //information.Text = sql;

                mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

            finally
            {
                mycon.Close();
            }




        }

        static public int storeStudentHabit(StudentHabit studentH)
        {
            try
            {
                mycon = new MySqlConnection(con);
                mycon.Open();
                MySqlCommand mycom = null;

                String sql = "INSERT INTO `habit`(`studentID`, `character`, `interest`, `bedtime`, `waketime`, `smoke`, `clean`) VALUES ('" + studentH.getStudentID() + "','" + studentH.getCharacter() + "','" + studentH.getInterest() + "','" + studentH.getBedtime() + "','" + studentH.getWaketime() + "','" + studentH.getSmoke() + "','" + studentH.getClean() + "' )";
                //information.Text = sql;

                mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                mycon.Close();
            }
        }

        static public int storeStudentWill(StudentWill studentW)
        {
            try
            {
                mycon = new MySqlConnection(con);
                mycon.Open();
                MySqlCommand mycom = null;

                String sql = "INSERT INTO `will`(`studentID`, `w_character`, `w_interest`, `w_bedtime`, `w_waketime`, `w_smoke`, `w_clean`) VALUES ('" + studentW.getStudentID() + "','" + studentW.getW_character() + "','" + studentW.getW_interest() + "','" + studentW.getW_bedtime() + "','" + studentW.getW_waketime() + "','" + studentW.getW_smoke() + "','" + studentW.getW_clean() + "' )";
                //information.Text = sql;

                mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                mycon.Close();
            }
        }
 

        static public StudentInfo CheckStudent(String id)
        {
            //String result;
            StudentInfo student;

            mycon = new MySqlConnection(con);
            mycon.Open();
            MySqlCommand mycom = null;
            MySqlDataReader myrec = null;
            String sql = "select* from information where studentID = '" + id + "'";
            //information.Text = sql;

            mycom = new MySqlCommand(sql, mycon);
            myrec = mycom.ExecuteReader();
            myrec.Read();

            if (myrec.HasRows)
            {
                student = new StudentInfo(id, myrec.GetString("studentName"),int.Parse(myrec.GetString("studentBirth")), int.Parse(myrec.GetString("studentGender")));
                Console.Write(id + "\n"+ myrec.GetString("studentName")
                                +"\n"+ int.Parse(myrec.GetString("studentBirth"))
                                +"\n"+ int.Parse(myrec.GetString("studentGender")));
            
            }
            else
            {
                return null;
             }
            mycon.Close();

            return student;
        }

        static public StudentHabit CheckStuHabit(String id)
        {
            StudentHabit Student;

            mycon = new MySqlConnection(con);
            mycon.Open();
            MySqlCommand mycom = null;
            MySqlDataReader myrec = null;
            String sql = "select* from habit where studentID = '" + id + "'";
            //information.Text = sql;

            mycom = new MySqlCommand(sql, mycon);
            myrec = mycom.ExecuteReader();
            myrec.Read();
            if (!myrec.HasRows)
            {
                return null;
            }
            else
            {
                Student= new StudentHabit(id,int.Parse(myrec.GetString("character")), myrec.GetString("interest"),int.Parse(myrec.GetString("bedtime")),  int.Parse(myrec.GetString("waketime")), int.Parse(myrec.GetString("smoke")), int.Parse(myrec.GetString("clean")));

            }
            mycon.Close();

            return Student;
        }

        static public StudentRoomate CheckStuRoomate(String id)
        {
            StudentRoomate student;
            mycon = new MySqlConnection(con);
            mycon.Open();
            MySqlCommand mycom = null;
            MySqlDataReader myrec = null;
            String sql = "select* from roomate where roomateA = '" + id + "' OR roomateB = '"+ id +"'";
           
            mycom = new MySqlCommand(sql, mycon);
            myrec = mycom.ExecuteReader();
            myrec.Read();
            if (!myrec.HasRows)
            {
                return null;
            }
            else{
                //    sql = "select* from roomate where roomateB = '" + id + "'";
                //    mycom = new MySqlCommand(sql, mycon);
                //    //myrec = mycom.ExecuteReader();
                //    myrec.Read();
                //    if (!myrec.HasRows)
                //    {
                //        return null;
                //    }
                //    else
                //    {
                //        student= new StudentRoomate(id, myrec.GetString("roomateA"));

                //    }

                //}
                //else
                //{
                //    student = new StudentRoomate(id, myrec.GetString("roomateB"));
                //}
                if (myrec.GetString("roomateB") == id)
                {
                    student = new StudentRoomate(id, myrec.GetString("roomateA"));
                }
                else
                {
                    student = new StudentRoomate(id, myrec.GetString("roomateB"));
                }
            }
            mycon.Close();
            return student;
        }

        static public StudentWill CheckStuWill(String id)
        {
            StudentWill Student;

            mycon = new MySqlConnection(con);
            mycon.Open();
            MySqlCommand mycom = null;
            MySqlDataReader myrec = null;
            String sql = "select* from will where studentID = '" + id + "'";
            //information.Text = sql;

            mycom = new MySqlCommand(sql, mycon);
            myrec = mycom.ExecuteReader();
            myrec.Read();
            if (!myrec.HasRows)
            {
                return null;
            }
            else
            {
                Student = new StudentWill(id, int.Parse(myrec.GetString("w_character")), myrec.GetString("w_interest"), int.Parse(myrec.GetString("w_bedtime")), int.Parse(myrec.GetString("w_waketime")), int.Parse(myrec.GetString("w_smoke")), int.Parse(myrec.GetString("w_clean")));

            }
            mycon.Close();

            return Student;
        }

        static public string[,] findAllRoomate()
        {
            try
            {
                mycon = new MySqlConnection(con);
                mycon.Open();



                MySqlCommand mycom = null;

                MySqlDataReader myr = null;
                MySqlDataReader myroom = null;

                String mysta = "SELECT * FROM `roomate` WHERE 1";
                mycom = new MySqlCommand(mysta, mycon);
                myr = mycom.ExecuteReader();

                int t = Count(myr);
                myr.Close();
                myroom = mycom.ExecuteReader();
                String[,] rminfo = new String[t, 2];
                for (int i = 0; i < t; i++)
                {
                    myroom.Read();

                    rminfo[i, 0] = myroom["roomateA"].ToString();
                    rminfo[i, 1] = myroom["roomateB"].ToString();


                }
                return rminfo;

            }
            catch (Exception e)
            {
                return null;

            }
            finally
            {
                mycon.Close();
            }

        }
        static public string findRoomate(String id)
        {
            try
            {
                StudentWill studentW;

                mycon = new MySqlConnection(con);
                mycon.Open();
                String returnvalue;


                MySqlCommand mycom = null;

                MySqlDataReader mystate = null;

                String mysta = "SELECT * FROM `information` WHERE `studentID` ='" + id + "'";
                mycom = new MySqlCommand(mysta, mycon);
                mystate = mycom.ExecuteReader();
                mystate.Read();
                String sgender = mystate["studentGender"].ToString();
                String sta = mystate["state"].ToString();
                mystate.Close();
                if (sta.CompareTo("1") == 0)
                {
                    String myroomateA = "SELECT * FROM `roomate` WHERE `roomateB` ='" + id + "' OR `roomateA` = '" + id + "'";
                    mycom = new MySqlCommand(myroomateA, mycon);
                    MySqlDataReader myrooma = null;
                    myrooma = mycom.ExecuteReader();
                    myrooma.Read();

                    String[] room = new String[1];

                    if (id.CompareTo(myrooma["roomateA"].ToString()) == 0)
                    {
                        returnvalue = myrooma["roomateB"].ToString();
                        return returnvalue;
                    }
                    else
                    {
                        returnvalue = myrooma["roomateA"].ToString();
                        return returnvalue;
                    }
                }
              
                else
                {



                    MySqlDataReader myrec = null;
                    String sql = "select* from `will` where studentID = '" + id + "'";


                    mycom = new MySqlCommand(sql, mycon);
                    myrec = mycom.ExecuteReader();
                    myrec.Read();


                    if (myrec == null)
                    {
                        return null;
                    }
                    else
                    {
                        studentW= new StudentWill(id,int.Parse(myrec["w_character"].ToString()),
                            myrec.GetString("w_interest"),int.Parse(myrec["w_bedtime"].ToString()),
                            int.Parse(myrec["w_waketime"].ToString()),int.Parse(myrec["w_smoke"].ToString()),
                            int.Parse(myrec["w_clean"].ToString()));
                    }
                    String waketime = studentW.getW_waketime().ToString();
                    String bedtime = studentW.getW_bedtime().ToString();
                    String character = studentW.getW_character().ToString();
                    String smoke = studentW.getW_smoke().ToString();
                    String clean = studentW.getW_clean().ToString();

                    String[] sw = { waketime, bedtime, smoke, clean, character, studentW.getW_interest() };


                    String l1 = "SELECT information.studentID FROM `habit` join `information`on habit.studentID = information.studentID WHERE `waketime`= '" 
                        + studentW.getW_waketime() + "'AND `bedtime`='" + studentW.getW_bedtime() + "' AND `smoke`='" 
                        + studentW.getW_smoke() + "' AND `clean` = '" + studentW.getW_clean() + "' AND `character` = '" 
                        + studentW.getW_character() + "' AND `interest` = '" + studentW.getW_interest() 
                        + "' AND `studentGender` ='" + sgender + "' AND `state`= 0";
                    myrec.Close();




                    MySqlCommand mycomm = new MySqlCommand(l1, mycon);

                    MySqlDataReader myred_cunt = null;
                    myred_cunt = mycomm.ExecuteReader();
                    int count = Count(myred_cunt);
                    myred_cunt.Close();

                    MySqlDataReader myred = null;
                    myred = mycomm.ExecuteReader();



                    int i = 0;
                    String[] sid = new String[count];
                    //String[] sid = new String[2];
                    //myred.Read();
                    //test[0] = myred["studentID"].ToString();

                    // myred.Read();
                    //test[1] = myred["studentID"].ToString();

                    while (i < count)
                    {
                        while (myred.Read())
                        {

                            //test[i] = myred["studentID"].ToString();
                            sid[i] = myred["studentID"].ToString();
                            i++;
                        }
                    }


                    if (count == 0)
                    {

                        returnvalue = "No way!";
                        return returnvalue;

                    }
                    else
                    {
                        myred.Close();
                        String choose = "INSERT INTO `roomate`(`roomateA`, `roomateB`) VALUES ('" + sid[0] + "','" + id + "')";
                        MySqlCommand mycommm = new MySqlCommand(choose, mycon);

                        MySqlDataReader myread = null;
                        myread = mycommm.ExecuteReader();

                        if (myread == null)
                            return null;
                        else
                        {
                            myread.Close();
                            String changestate = "UPDATE `information` SET `state`= 1 WHERE `studentID` = '" + id + "' OR `studentID` = '" + sid[0] + "'";
                            MySqlCommand mycoms = new MySqlCommand(changestate, mycon);

                            MySqlDataReader mychange = null;
                            mychange = mycoms.ExecuteReader();

                            
                            if (mychange == null)
                            {
                                returnvalue = "choose false";
                                mychange.Close();
                                return null;
                            }
                            else if (sid[0].Equals(id))
                            { 
                                returnvalue = sid[1];
                                mychange.Close();
                                return returnvalue;
                            }
                            else {
                                returnvalue = sid[0];
                                return returnvalue;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string t = "Error:" + e;
               
                return t;
            }
            finally
            {

                mycon.Close();
            }

        }
    
    }
}