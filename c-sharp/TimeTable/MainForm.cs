using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimeTable
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TABLEcomboBox.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection constr = new SqlConnection(Program.strcon);
            SqlCommand comand = new SqlCommand("DELETE FROM " + TABLEcomboBox.Text + " WHERE id = '" + id + "'", constr);
            try
            {
                constr.Open();
                comand.ExecuteNonQuery();
                TABLEcomboBox_SelectionChangeCommitted(sender, e);
            }
            catch
            {
                MessageBox.Show("Failed to connect to data source\nid = " + id);
            }
            finally
            {
                constr.Close();
            }
        }

        private void TABLEcomboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT * FROM " + TABLEcomboBox.Text;
            try
            {
                dataGridView1.DataSource = executeQuery(sqlQuery).Tables[0];
            }
            catch
            {
                MessageBox.Show("Failed to connect to data source");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlQuery = "INSERT INTO " + TABLEcomboBox.Text + " (name) VALUES ('" + NAMEtextBox.Text + "');";
            executeCommandQuery(sqlQuery);
            TABLEcomboBox_SelectionChangeCommitted(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            cbxLinksTable.SelectedIndex = 0;
            cbxLinksTable_SelectionChangeCommitted(sender, e);
        }

        /// <summary>
        /// возвращает таблицу по запросу
        /// </summary>
        /// <param name="strQuery">запрос на выборку</param>
        /// <returns></returns>
        private DataSet executeQuery(string strQuery)
        {
            SqlConnection constr = new SqlConnection(Program.strcon);
            SqlCommand comand = new SqlCommand(strQuery, constr);
            DataSet ds = new DataSet();
            try
            {
                constr.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ds.Clear();
                ad.SelectCommand = comand;
                ad.Fill(ds);
            }
            catch
            {
                MessageBox.Show("Failed to connect to data source\n" + strQuery);
            }
            finally
            {
                constr.Close();
            }
            return (ds);
        }

        /// <summary>
        /// манипуляция с данными
        /// </summary>
        /// <param name="sqlQuery">запрос для обработки</param>
        private void executeCommandQuery(string sqlQuery)
        {
            SqlConnection constr = new SqlConnection(Program.strcon);
            SqlCommand comand = new SqlCommand(sqlQuery, constr);
            try
            {
                constr.Open();
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Failed to connect to data source or failed execute query\nQuery=" + sqlQuery);
            }
            finally
            {
                constr.Close();
            }
        }
        
        private void cbxLinksTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string t = cbxLinksTable.Text;
            string[] buf = t.Split('_');
            string t1 = buf[0];
            string t2 = buf[1];
            string sqlQuery = "SELECT " + t + ".id, " + t1 + ".name AS " + t1 + "_name, " + t2 + ".name AS " + t2 + "_name , " + t + ".weight " +
            "FROM " + t +
            " INNER JOIN " + t1 + " ON " + t + ".id_" + t1 + " = " + t1 + ".id " +
            " INNER JOIN " + t2 + " ON " + t + ".id_" + t2 + " = " + t2 + ".id " +
            " ORDER BY " + t1 + ".id," + t2 + ".id";
            try
            {
                grdLinksTable.DataSource = executeQuery(sqlQuery).Tables[0];
            }
            catch
            {
                MessageBox.Show("Failed to connect to data source\n" + sqlQuery);
            }
            cbxName1.DataSource = executeQuery("SELECT * FROM " + t1).Tables[0];
            cbxName1.DisplayMember = "name";
            cbxName1.ValueMember = "id";
            cbxName2.DataSource = executeQuery("SELECT * FROM " + t2).Tables[0];
            cbxName2.DisplayMember = "name";
            cbxName2.ValueMember = "id";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = grdLinksTable.CurrentRow.Cells[0].Value.ToString();
            executeCommandQuery("DELETE FROM " + cbxLinksTable.Text + " WHERE id = '" + id + "'");
            cbxLinksTable_SelectionChangeCommitted(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] buf = (cbxLinksTable.Text).Split('_');
            string t1 = buf[0];
            string t2 = buf[1];
            string sqlQuery = "INSERT INTO " + cbxLinksTable.Text + " (id_" + t1 + ", id_" + t2 + ", weight) VALUES ('" + cbxName1.SelectedValue + "', '" + cbxName2.SelectedValue + "', '" + tbxWeight.Text + "');";
            executeCommandQuery(sqlQuery);
            cbxLinksTable_SelectionChangeCommitted(sender, e);
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            cbxForGroup.ValueMember = "id";
            cbxForGroup.DisplayMember = "name";
            cbxForGroup.DataSource = executeQuery("SELECT * FROM groups").Tables[0];
            cbxOnDay.ValueMember = "id";
            cbxOnDay.DisplayMember = "name";
            cbxOnDay.DataSource = executeQuery("SELECT * FROM days").Tables[0];
            cbxForTeacher.ValueMember = "id";
            cbxForTeacher.DisplayMember = "name";
            cbxForTeacher.DataSource = executeQuery("SELECT * FROM teachers").Tables[0];
        }

        /// <summary>
        /// записываем данные из столбца в массив
        /// </summary>
        /// <param name="sqlQuery">запрос на выборку столбца</param>
        /// <returns></returns>
        private int[] GetData(string sqlQuery)
        {
            DataSet ds = executeQuery(sqlQuery);
            int[] array = new int[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                array[i] = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            return(array);
        }
        
        /// <summary>
        /// довернуть
        /// </summary>
        private void generateTimeTable()
        {

            // очищаем таблицу
            executeCommandQuery("DELETE FROM timetable;");

            int[] idGroups = GetData("SELECT id FROM groups");
           
            foreach (int idGroup in idGroups)
            {
                int[] idSubjects = GetData("SELECT id_subjects FROM groups_subjects WHERE id_groups = "+idGroup.ToString());
                foreach (int idSubject in idSubjects)
                {
                    int[] idTeachers = GetData("SELECT id_teachers FROM teachers_subjects WHERE id_subjects = "+idSubject.ToString());
                    int nCurrentWeightGroup;
                    int nMaxWeightGroup;
                    
                    //вычисляем текущую нагрузку на группу по конкретному предмету
                    nCurrentWeightGroup = getCurrentWeigthGroup(idSubject, idGroup);
                    //вычисляем текущую нагрузку на учителя
                    nMaxWeightGroup = getMaxWeigthGroup(idSubject, idGroup);
                    if (nMaxWeightGroup - nCurrentWeightGroup <= 0)
                        continue; // переходим к следующему предмету

                    foreach (int idTeacher in idTeachers)
                    {

                        if (nMaxWeightGroup - nCurrentWeightGroup <= 0)
                            break; // если заполнили то прекращаем текущий цикл и поднимаемся на предыдущий уровень

                        int nCurrentWeightTeacher;
                        int nMaxWeightTeacher;

                        //вычисляем текущую нагрузку на учителя
                        nCurrentWeightTeacher = getCurrentWeigthTeacher(idSubject, idTeacher);

                        //вычисляем максимальную нагрузку на учителя
                        nMaxWeightTeacher = getMaxWeigthTeacher(idSubject, idTeacher);

                        if (nMaxWeightTeacher - nCurrentWeightTeacher <= 0)
                            continue; // переходим к следующему учителю


                        int[] idRooms = GetData("SELECT id FROM rooms");
                        foreach (int idRoom in idRooms)
                        {

                            if (nMaxWeightGroup - nCurrentWeightGroup <= 0)
                                break; // если заполнили то прекращаем текущий цикл и поднимаемся на предыдущий уровень

                            int[] idDaysTimes = GetData("SELECT id FROM days_times");

                            foreach (int idDayTime in idDaysTimes)
                            {
                                if (nMaxWeightGroup - nCurrentWeightGroup <= 0)
                                    break; // если заполнили то прекращаем текущий цикл и поднимаемся на предыдущий уровень

                                bool bBusyRoom, bBusyTeacher, bBusyGroup;
                                
                                //проверям заняты в это время комната, учитель и группа
                                bBusyRoom = IsBusyRoom(idDayTime, idRoom);
                                bBusyTeacher = IsBusyTeacher(idDayTime, idTeacher);
                                bBusyGroup = IsBusyGroup(idDayTime, idGroup);
                              
                                if (bBusyRoom || bBusyTeacher || bBusyGroup)
                                    continue; // если хоть кто то занят переходим к следующему времени

                                // ура!!! мы нашли куда можно записать!
                                executeCommandQuery("INSERT INTO timetable(id_groups, id_subjects, id_teachers, id_rooms, id_days_times ) VALUES(" +
                                    idGroup.ToString() + ", " + idSubject.ToString() + ", " + idTeacher.ToString() + ", " + idRoom.ToString() + ", " + idDayTime.ToString() + ");");

                                nCurrentWeightTeacher = nCurrentWeightTeacher - 1; // минус один силе-ловкости
                                nCurrentWeightGroup = nCurrentWeightGroup + 1; // плюс один к интелекту

                                if (nMaxWeightGroup - nCurrentWeightGroup <= 0)
                                    break; // переходим к следующему предмету 
                            }
                        }
                    }
                }
            }
        }

        private int getCurrentWeigthGroup(int idSubject, int idGroup)
        {
            string sqlQuery = "SELECT SUM(days_times.weight) FROM timetable inner join days_times on days_times.id = timetable.id_days_times where id_subjects = " + idSubject + " and id_groups = " + idGroup;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            if ((dt.Rows.Count == 1) && (dt.Rows[0].ItemArray[0].ToString() != ""))
            {
                return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()));
            }
            return (0);
        }

        private int getMaxWeigthGroup(int idSubject, int idGroup)
        {
            string sqlQuery = "select weight from groups_subjects where id_groups = "+idGroup+" and id_subjects = "+idSubject;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()));
        }
        
        private int getCurrentWeigthTeacher(int idSubject, int idTeacher)
        {
            string sqlQuery = "SELECT SUM(days_times.weight) as sum_weight FROM timetable inner join days_times on days_times.id = timetable.id_days_times WHERE id_subjects = "+idSubject+" AND id_teachers = "+idTeacher;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            if ((dt.Rows.Count == 1) && (dt.Rows[0].ItemArray[0].ToString() != ""))
            {
                return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()));
            }
            return (0);
        }

        private int getMaxWeigthTeacher(int idSubject, int idTeacher)
        {
            string sqlQuery = "select weight from teachers_subjects where id_teachers = "+idTeacher+" and id_subjects = "+idSubject;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()));
        }

        private bool IsBusyRoom(int idDayTime, int idRoom)
        {
            string sqlQuery = "SELECT COUNT(*) FROM timetable WHERE id_days_times = " + idDayTime + " and id_rooms = " + idRoom;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) >= 1);
        }

        private bool IsBusyTeacher(int idDayTime, int idTeacher)
        {
            string sqlQuery = "SELECT COUNT(*) FROM timetable WHERE id_days_times = " + idDayTime + " and id_teachers = " + idTeacher;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) >= 1);
        }

        private bool IsBusyGroup(int idDayTime, int idGroup)
        {
            string sqlQuery = "SELECT COUNT(*) FROM timetable WHERE id_days_times = " + idDayTime + " and id_groups = " + idGroup;
            DataTable dt = executeQuery(sqlQuery).Tables[0];
            return (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) >= 1);
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            generateTimeTable();
        }

        private void cbxForGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbxForGroup.SelectedIndex < 0) || (cbxForTeacher.SelectedIndex < 0) || (cbxOnDay.SelectedIndex < 0)) return;
            string sqlQuery = "";
            if (rbGroup.Checked)
                sqlQuery = "SELECT times.name AS время, "
                                + "subjects.name AS предмет, "
                                + "rooms.name AS кабинет, "
                                + "teachers.name AS преподаватель "
                                + "FROM timetable "
                                + " INNER JOIN subjects ON subjects.id = timetable.id_subjects"
                                + " INNER JOIN rooms ON rooms.id = timetable.id_rooms"
                                + " INNER JOIN teachers ON teachers.id = timetable.id_teachers"
                                + " INNER JOIN days_times ON days_times.id = timetable.id_days_times"
                                + " INNER JOIN times ON days_times.id_times = times.id"
                                + " WHERE timetable.id_groups = " + cbxForGroup.SelectedValue + " AND days_times.id_days = " + cbxOnDay.SelectedValue;
            if (rbTeacher.Checked)
                sqlQuery = "SELECT times.name AS время, "
                                + "subjects.name AS предмет, "
                                + "rooms.name AS кабинет, "
                                + "groups.name AS класс "
                                + "FROM timetable "
                                + " INNER JOIN subjects ON subjects.id = timetable.id_subjects"
                                + " INNER JOIN rooms ON rooms.id = timetable.id_rooms"
                                + " INNER JOIN groups ON groups.id = timetable.id_groups"
                                + " INNER JOIN days_times ON days_times.id = timetable.id_days_times"
                                + " INNER JOIN times ON days_times.id_times = times.id"
                                + " WHERE timetable.id_teachers = " + cbxForTeacher.SelectedValue + " AND days_times.id_days = " + cbxOnDay.SelectedValue;
            grdTimetable.DataSource = executeQuery(sqlQuery).Tables[0];
        }

        private void rbGroup_CheckedChanged(object sender, EventArgs e)
        {
            cbxForGroup.Enabled = true;
            cbxForTeacher.Enabled = false;
            cbxForGroup_SelectedIndexChanged(sender, e);
        }

        private void rbTeacher_CheckedChanged(object sender, EventArgs e)
        {
            cbxForTeacher.Enabled = true;
            cbxForGroup.Enabled = false;
            cbxForGroup_SelectedIndexChanged(sender, e);
        }
    }
}