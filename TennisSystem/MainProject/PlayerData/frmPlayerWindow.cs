using System;
using System.Data;
using System.Windows.Forms;
using MainProject.Presenters;
using System.Data.SqlClient;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MainProject.PlayerData
{
    public partial class frmPlayerWindow : Form
    {
        public MainPresenter _pressenter;

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;

        public string _firstName;
        public string _secondName;

        public frmPlayerWindow(MainPresenter p)
        {
            InitializeComponent();

            _pressenter = p;         
        }
        
        public void DataBase(string First,string Second)
        {
            
            con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = D:\D\shadow\Desktop\MCU\專研\GIT\TeamGit\TeamGit\TennisSystem\MainProject\PlayerData.mdf;
                                    Integrated Security = True");

            // 修改資料庫路徑 -> (@"AttachDbFilename) = 資料庫路徑 //

            con.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Table]");
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            _firstName = First.Trim();
            _secondName = Second.Trim();

            #region >>> FirstName Data <<<
            if (_firstName == "CILIC")
            {
                pictureBox1.Image = Properties.Resources.Player_Cilic;
                label8.Text = dt.Rows[0]["Name"].ToString();
                label10.Text = dt.Rows[0]["Country"].ToString();
                label12.Text = dt.Rows[0]["Ranking"].ToString();
                label14.Text = dt.Rows[0]["Born"].ToString();
                label16.Text = dt.Rows[0]["Height"].ToString();
                label18.Text = dt.Rows[0]["Weight"].ToString();
                label20.Text = dt.Rows[0]["Plays"].ToString();
            }

            else if (_firstName == "DJO" || _firstName == "DJOKOVIC" || _firstName == "DJUKOVIC")
            {
                pictureBox1.Image = Properties.Resources.Player_Djokovic;
                label8.Text = dt.Rows[1]["Name"].ToString();
                label10.Text = dt.Rows[1]["Country"].ToString();
                label12.Text = dt.Rows[1]["Ranking"].ToString();
                label14.Text = dt.Rows[1]["Born"].ToString();
                label16.Text = dt.Rows[1]["Height"].ToString();
                label18.Text = dt.Rows[1]["Weight"].ToString();
                label20.Text = dt.Rows[1]["Plays"].ToString();
            }

            else if (_firstName == "FEDERER" || _firstName == "FED" || _firstName == "FER")
            {
                pictureBox1.Image = Properties.Resources.Player_Federer;
                label8.Text = dt.Rows[2]["Name"].ToString();
                label10.Text = dt.Rows[2]["Country"].ToString();
                label12.Text = dt.Rows[2]["Ranking"].ToString();
                label14.Text = dt.Rows[2]["Born"].ToString();
                label16.Text = dt.Rows[2]["Height"].ToString();
                label18.Text = dt.Rows[2]["Weight"].ToString();
                label20.Text = dt.Rows[2]["Plays"].ToString();
            }

            else if (_firstName == "DE MINAUR")
            {
                pictureBox1.Image = Properties.Resources.Player_Minaur;
                label8.Text = dt.Rows[3]["Name"].ToString();
                label10.Text = dt.Rows[3]["Country"].ToString();
                label12.Text = dt.Rows[3]["Ranking"].ToString();
                label14.Text = dt.Rows[3]["Born"].ToString();
                label16.Text = dt.Rows[3]["Height"].ToString();
                label18.Text = dt.Rows[3]["Weight"].ToString();
                label20.Text = dt.Rows[3]["Plays"].ToString();
            }

            else if (_firstName == "MURRAY" || _firstName == "MUR")
            {
                pictureBox1.Image = Properties.Resources.Player_Murray;
                label8.Text = dt.Rows[4]["Name"].ToString();
                label10.Text = dt.Rows[4]["Country"].ToString();
                label12.Text = dt.Rows[4]["Ranking"].ToString();
                label14.Text = dt.Rows[4]["Born"].ToString();
                label16.Text = dt.Rows[4]["Height"].ToString();
                label18.Text = dt.Rows[4]["Weight"].ToString();
                label20.Text = dt.Rows[4]["Plays"].ToString();
            }

            else if (_firstName == "NADAL" || _firstName == "NAD")
            {
                pictureBox1.Image = Properties.Resources.Player_Nadal;
                label8.Text = dt.Rows[5]["Name"].ToString();
                label10.Text = dt.Rows[5]["Country"].ToString();
                label12.Text = dt.Rows[5]["Ranking"].ToString();
                label14.Text = dt.Rows[5]["Born"].ToString();
                label16.Text = dt.Rows[5]["Height"].ToString();
                label18.Text = dt.Rows[5]["Weight"].ToString();
                label20.Text = dt.Rows[5]["Plays"].ToString();
            }

            else if (_firstName == "RAONIC")
            {
                pictureBox1.Image = Properties.Resources.Player_Raonic;
                label8.Text = dt.Rows[6]["Name"].ToString();
                label10.Text = dt.Rows[6]["Country"].ToString();
                label12.Text = dt.Rows[6]["Ranking"].ToString();
                label14.Text = dt.Rows[6]["Born"].ToString();
                label16.Text = dt.Rows[6]["Height"].ToString();
                label18.Text = dt.Rows[6]["Weight"].ToString();
                label20.Text = dt.Rows[6]["Plays"].ToString();
            }

            else if (_firstName == "S.WILLIAMS" || _firstName == "WILLIAMS" || _firstName == "WIL")
            {
                pictureBox1.Image = Properties.Resources.Player_S_Williams;
                label8.Text = dt.Rows[7]["Name"].ToString();
                label10.Text = dt.Rows[7]["Country"].ToString();
                label12.Text = dt.Rows[7]["Ranking"].ToString();
                label14.Text = dt.Rows[7]["Born"].ToString();
                label16.Text = dt.Rows[7]["Height"].ToString();
                label18.Text = dt.Rows[7]["Weight"].ToString();
                label20.Text = dt.Rows[7]["Plays"].ToString();
            }

            else if (_firstName == "SHAPOVALOV")
            {
                pictureBox1.Image = Properties.Resources.Player_Shapovalov;
                label8.Text = dt.Rows[8]["Name"].ToString();
                label10.Text = dt.Rows[8]["Country"].ToString();
                label12.Text = dt.Rows[8]["Ranking"].ToString();
                label14.Text = dt.Rows[8]["Born"].ToString();
                label16.Text = dt.Rows[8]["Height"].ToString();
                label18.Text = dt.Rows[8]["Weight"].ToString();
                label20.Text = dt.Rows[8]["Plays"].ToString();
            }

            else if (_firstName == "SHA")
            {
                pictureBox1.Image = Properties.Resources.Player_Sharapova;
                label8.Text = dt.Rows[9]["Name"].ToString();
                label10.Text = dt.Rows[9]["Country"].ToString();
                label12.Text = dt.Rows[9]["Ranking"].ToString();
                label14.Text = dt.Rows[9]["Born"].ToString();
                label16.Text = dt.Rows[9]["Height"].ToString();
                label18.Text = dt.Rows[9]["Weight"].ToString();
                label20.Text = dt.Rows[9]["Plays"].ToString();
            }

            else if (_firstName == "V.WILLIAMS" || _firstName == "V.W|LL|AMS")
            {
                pictureBox1.Image = Properties.Resources.Player_V_Williams;
                label8.Text = dt.Rows[10]["Name"].ToString();
                label10.Text = dt.Rows[10]["Country"].ToString();
                label12.Text = dt.Rows[10]["Ranking"].ToString();
                label14.Text = dt.Rows[10]["Born"].ToString();
                label16.Text = dt.Rows[10]["Height"].ToString();
                label18.Text = dt.Rows[10]["Weight"].ToString();
                label20.Text = dt.Rows[10]["Plays"].ToString();
            }

            else if (_firstName == "VANDEWEGHE" || _firstName == "VANDEWEG HE")
            {
                pictureBox1.Image = Properties.Resources.Player_Vandeweghe;
                label8.Text = dt.Rows[11]["Name"].ToString();
                label10.Text = dt.Rows[11]["Country"].ToString();
                label12.Text = dt.Rows[11]["Ranking"].ToString();
                label14.Text = dt.Rows[11]["Born"].ToString();
                label16.Text = dt.Rows[11]["Height"].ToString();
                label18.Text = dt.Rows[11]["Weight"].ToString();
                label20.Text = dt.Rows[11]["Plays"].ToString();
            }
            #endregion

            #region >>> SecondtName Data <<<
            if (_secondName == "CILIC")
            {
                pictureBox2.Image = Properties.Resources.Player_Cilic;
                label9.Text = dt.Rows[0]["Name"].ToString();
                label11.Text = dt.Rows[0]["Country"].ToString();
                label13.Text = dt.Rows[0]["Ranking"].ToString();
                label15.Text = dt.Rows[0]["Born"].ToString();
                label17.Text = dt.Rows[0]["Height"].ToString();
                label19.Text = dt.Rows[0]["Weight"].ToString();
                label21.Text = dt.Rows[0]["Plays"].ToString();
            }

            else if (_secondName == "DJO" || _secondName == "DJOKOVIC" || _secondName == "DJUKOVIC")
            {
                pictureBox2.Image = Properties.Resources.Player_Djokovic;
                label9.Text = dt.Rows[1]["Name"].ToString();
                label11.Text = dt.Rows[1]["Country"].ToString();
                label13.Text = dt.Rows[1]["Ranking"].ToString();
                label15.Text = dt.Rows[1]["Born"].ToString();
                label17.Text = dt.Rows[1]["Height"].ToString();
                label19.Text = dt.Rows[1]["Weight"].ToString();
                label21.Text = dt.Rows[1]["Plays"].ToString();
            }

            else if (_secondName == "FEDERER" || _secondName == "FED" || _secondName == "FER")
            {
                pictureBox2.Image = Properties.Resources.Player_Federer;
                label9.Text = dt.Rows[2]["Name"].ToString();
                label11.Text = dt.Rows[2]["Country"].ToString();
                label13.Text = dt.Rows[2]["Ranking"].ToString();
                label15.Text = dt.Rows[2]["Born"].ToString();
                label17.Text = dt.Rows[2]["Height"].ToString();
                label19.Text = dt.Rows[2]["Weight"].ToString();
                label21.Text = dt.Rows[2]["Plays"].ToString();
            }

            else if (_secondName == "DE MINAUR")
            {
                pictureBox2.Image = Properties.Resources.Player_Minaur;
                label9.Text = dt.Rows[3]["Name"].ToString();
                label11.Text = dt.Rows[3]["Country"].ToString();
                label13.Text = dt.Rows[3]["Ranking"].ToString();
                label15.Text = dt.Rows[3]["Born"].ToString();
                label17.Text = dt.Rows[3]["Height"].ToString();
                label19.Text = dt.Rows[3]["Weight"].ToString();
                label21.Text = dt.Rows[3]["Plays"].ToString();
            }

            else if (_secondName == "MURRAY" || _secondName == "MUR")
            {
                pictureBox2.Image = Properties.Resources.Player_Murray;
                label9.Text = dt.Rows[4]["Name"].ToString();
                label11.Text = dt.Rows[4]["Country"].ToString();
                label13.Text = dt.Rows[4]["Ranking"].ToString();
                label15.Text = dt.Rows[4]["Born"].ToString();
                label17.Text = dt.Rows[4]["Height"].ToString();
                label19.Text = dt.Rows[4]["Weight"].ToString();
                label21.Text = dt.Rows[4]["Plays"].ToString();
            }

            else if (_secondName == "NADAL" || _secondName == "NAD")
            {
                pictureBox2.Image = Properties.Resources.Player_Nadal;
                label9.Text = dt.Rows[5]["Name"].ToString();
                label11.Text = dt.Rows[5]["Country"].ToString();
                label13.Text = dt.Rows[5]["Ranking"].ToString();
                label15.Text = dt.Rows[5]["Born"].ToString();
                label17.Text = dt.Rows[5]["Height"].ToString();
                label19.Text = dt.Rows[5]["Weight"].ToString();
                label21.Text = dt.Rows[5]["Plays"].ToString();
            }

            else if (_secondName == "RAONIC")
            {
                pictureBox2.Image = Properties.Resources.Player_Raonic;
                label9.Text = dt.Rows[6]["Name"].ToString();
                label11.Text = dt.Rows[6]["Country"].ToString();
                label13.Text = dt.Rows[6]["Ranking"].ToString();
                label15.Text = dt.Rows[6]["Born"].ToString();
                label17.Text = dt.Rows[6]["Height"].ToString();
                label19.Text = dt.Rows[6]["Weight"].ToString();
                label21.Text = dt.Rows[6]["Plays"].ToString();
            }

            else if (_secondName == "S.WILLIAMS" || _secondName == "WILLIAMS" || _secondName == "WIL")
            {
                pictureBox2.Image = Properties.Resources.Player_S_Williams;
                label9.Text = dt.Rows[7]["Name"].ToString();
                label11.Text = dt.Rows[7]["Country"].ToString();
                label13.Text = dt.Rows[7]["Ranking"].ToString();
                label15.Text = dt.Rows[7]["Born"].ToString();
                label17.Text = dt.Rows[7]["Height"].ToString();
                label19.Text = dt.Rows[7]["Weight"].ToString();
                label21.Text = dt.Rows[7]["Plays"].ToString();
            }

            else if (_secondName == "SHAPOVALOV")
            {
                pictureBox2.Image = Properties.Resources.Player_Shapovalov;
                label9.Text = dt.Rows[8]["Name"].ToString();
                label11.Text = dt.Rows[8]["Country"].ToString();
                label13.Text = dt.Rows[8]["Ranking"].ToString();
                label15.Text = dt.Rows[8]["Born"].ToString();
                label17.Text = dt.Rows[8]["Height"].ToString();
                label19.Text = dt.Rows[8]["Weight"].ToString();
                label21.Text = dt.Rows[8]["Plays"].ToString();
            }

            else if (_secondName == "SHA")
            {
                pictureBox2.Image = Properties.Resources.Player_Sharapova;
                label9.Text = dt.Rows[9]["Name"].ToString();
                label11.Text = dt.Rows[9]["Country"].ToString();
                label13.Text = dt.Rows[9]["Ranking"].ToString();
                label15.Text = dt.Rows[9]["Born"].ToString();
                label17.Text = dt.Rows[9]["Height"].ToString();
                label19.Text = dt.Rows[9]["Weight"].ToString();
                label21.Text = dt.Rows[9]["Plays"].ToString();
            }

            else if (_secondName == "V.WILLIAMS" || _secondName == "V.W|LL|AMS")
            {
                pictureBox2.Image = Properties.Resources.Player_V_Williams;
                label9.Text = dt.Rows[10]["Name"].ToString();
                label11.Text = dt.Rows[10]["Country"].ToString();
                label13.Text = dt.Rows[10]["Ranking"].ToString();
                label15.Text = dt.Rows[10]["Born"].ToString();
                label17.Text = dt.Rows[10]["Height"].ToString();
                label19.Text = dt.Rows[10]["Weight"].ToString();
                label21.Text = dt.Rows[10]["Plays"].ToString();
            }

            else if (_secondName == "VANDEWEGHE" || _secondName == "VANDEWEG HE")
            {
                pictureBox2.Image = Properties.Resources.Player_Vandeweghe;
                label9.Text = dt.Rows[11]["Name"].ToString();
                label11.Text = dt.Rows[11]["Country"].ToString();
                label13.Text = dt.Rows[11]["Ranking"].ToString();
                label15.Text = dt.Rows[11]["Born"].ToString();
                label17.Text = dt.Rows[11]["Height"].ToString();
                label19.Text = dt.Rows[11]["Weight"].ToString();
                label21.Text = dt.Rows[11]["Plays"].ToString();
            }
            #endregion
        }
    }
}
