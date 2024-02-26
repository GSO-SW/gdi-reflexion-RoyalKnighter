using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Frogger
{
    public partial class FrmFrogger : Form
    {
        public static int menu = 0;
        public static int anzahlBereiche = 7;
        public static int breite = -1;
        public static int hoehe = -1;
        public static int hoeheJeBereich = -1;
        public static Bahn[] alleBahnen = new Bahn[anzahlBereiche + 2];
        public static List<Hindernis> alleHindernisse = new List<Hindernis>();
        public static Rectangle spieler1;
        public static Rectangle spieler2;
        public static Random rndBahn = new Random();
        public static int spieler1InBereich = 0;
        public static int spieler2InBereich = 0;
        public static int startVerzoegerungPlayer1 = 5;
        public static bool inputBlockedPlayer1 = true;
        public static int startVerzoegerungPlayer2 = 5;
        public static bool inputBlockedPlayer2 = true;
        public static bool gameOver = false;
        public static bool gameOverPlayer1 = false;
        public static bool gameOverPlayer2 = false;
        public StringFormat stringFormat = new StringFormat();
        public Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

        public static bool image = true;
        public static bool secondPlayer = false;
        public static bool coop = true;
        public static bool player1Win = false;
        public static bool player2Win = false;
        public static bool lose = false;

        public static double streetSpawnRate = 1;
        public static double streetSpawnRateInc = 0.5;
        public static double carSpawnRateFrom = 20;
        public static double carSpawnRateFromInc = -1.5;
        public static double carSpawnRateTo = 60;
        public static double carSpawnRateToInc = -2;
        public static double carSpeedFrom = 10;
        public static double carSpeedFromInc = 2;
        public static double carSpeedTo = 15;
        public static double carSpeedToInc = 2.5;

        public static double railSpawnRate = -1;
        public static double railSpawnRateInc = 0.6;
        public static double trainSpawnRateFrom = 40;
        public static double trainSpawnRateFromInc = -2;
        public static double trainSpawnRateTo = 100;
        public static double trainSpawnRateToInc = -1.5;
        public static double trainSpeedFrom = 50;
        public static double trainSpeedFromInc = 2;
        public static double trainSpeedTo = 100;
        public static double trainSpeedToInc = 2.5;

        public static double riverSpawnRate = 3;
        public static double riverSpawnRateInc = 0.4;
        public static double raftSpawnRateFrom = 10;
        public static double raftSpawnRateFromInc = 2;
        public static double raftSpawnRateTo = 15;
        public static double raftSpawnRateToInc = 2.1;
        public static double raftSpeedFrom = 10;
        public static double raftSpeedFromInc = 2;
        public static double raftSpeedTo = 20;
        public static double raftSpeedToInc = 2.3;

        public static double grassSpawnRate = 10;
        public static double grassSpawnRateInc = -1;
        public static double blockadeSpawnRate = 20;
        public static double blockadeSpawnRateInc = -0.8;

        public static double streetSpawnRateMin = 0;
        public static double carSpawnRateFromMin = 0;
        public static double carSpawnRateToMin = 0;
        public static double carSpeedFromMin = 0;
        public static double carSpeedToMin = 0;

        public static double railSpawnRateMin = 0;
        public static double trainSpawnRateFromMin = 0;
        public static double trainSpawnRateToMin = 0;
        public static double trainSpeedFromMin = 0;
        public static double trainSpeedToMin = 0;

        public static double riverSpawnRateMin = 0;
        public static double raftSpawnRateFromMin = 0;
        public static double raftSpawnRateToMin = 0;
        public static double raftSpeedFromMin = 0;
        public static double raftSpeedToMin = 0;

        public static double grassSpawnRateMin = 0;
        public static double blockadeSpawnRateMin = 0;


        public static double streetSpawnRateStandard = 1;
        public static double streetSpawnRateIncStandard = 0.5;
        public static double streetSpawnRateMinStandard = 0;
        public static double carSpawnRateFromStandard = 20;
        public static double carSpawnRateFromIncStandard = -1.5;
        public static double carSpawnRateFromMinStandard = 0;
        public static double carSpawnRateToStandard = 60;
        public static double carSpawnRateToIncStandard = -2;
        public static double carSpawnRateToMinStandard = 0;
        public static double carSpeedFromStandard = 10;
        public static double carSpeedFromIncStandard = 2;
        public static double carSpeedFromMinStandard = 0;
        public static double carSpeedToStandard = 15;
        public static double carSpeedToIncStandard = 2.5;
        public static double carSpeedToMinStandard = 0;

        public static double railSpawnRateStandard = -1;
        public static double railSpawnRateIncStandard = 0.6;
        public static double railSpawnRateMinStandard = 0;
        public static double trainSpawnRateFromStandard = 40;
        public static double trainSpawnRateFromIncStandard = -2;
        public static double trainSpawnRateFromMinStandard = 0;
        public static double trainSpawnRateToStandard = 100;
        public static double trainSpawnRateToIncStandard = -1.5;
        public static double trainSpawnRateToMinStandard = 0;
        public static double trainSpeedFromStandard = 50;
        public static double trainSpeedFromIncStandard = 2;
        public static double trainSpeedFromMinStandard = 0;
        public static double trainSpeedToStandard = 100;
        public static double trainSpeedToIncStandard = 2.5;
        public static double trainSpeedToMinStandard = 0;

        public static double riverSpawnRateStandard = 3;
        public static double riverSpawnRateIncStandard = 0.4;
        public static double riverSpawnRateMinStandard = 0;
        public static double raftSpawnRateFromStandard = 10;
        public static double raftSpawnRateFromIncStandard = 2;
        public static double raftSpawnRateFromMinStandard = 0;
        public static double raftSpawnRateToStandard = 15;
        public static double raftSpawnRateToIncStandard = 2.1;
        public static double raftSpawnRateToMinStandard = 0;
        public static double raftSpeedFromStandard = 10;
        public static double raftSpeedFromIncStandard = 2;
        public static double raftSpeedFromMinStandard = 0;
        public static double raftSpeedToStandard = 20;
        public static double raftSpeedToIncStandard = 2.3;
        public static double raftSpeedToMinStandard = 0;

        public static double grassSpawnRateStandard = 10;
        public static double grassSpawnRateIncStandard = -1;
        public static double grassSpawnRateMinStandard = 0;
        public static double blockadeSpawnRateStandard = 20;
        public static double blockadeSpawnRateIncStandard = -0.8;
        public static double blockadeSpawnRateMinStandard = 0;

        public FrmFrogger()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmFrogger_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void FrmFrogger_Paint(object sender, PaintEventArgs e)
        {
            switch (menu)
            {
                case 0:
                    if (this.Controls.Count <= 0)
                    {
                        Button btn1 = new Button();
                        btn1.Text = "Singleplayer";
                        btn1.BackColor = Color.Yellow;
                        btn1.Width = 200;
                        btn1.Height = 50;
                        btn1.Font = new Font(btn1.Font.FontFamily, 15);
                        btn1.FlatStyle = FlatStyle.Flat;
                        btn1.FlatAppearance.BorderSize = 0;
                        btn1.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 - 55);
                        btn1.Click += Btn1_Click;

                        Button btn2 = new Button();
                        btn2.Text = "Multiplayer";
                        btn2.BackColor = Color.Yellow;
                        btn2.Width = 200;
                        btn2.Height = 50;
                        btn2.Font = new Font(btn2.Font.FontFamily, 15);
                        btn2.FlatStyle = FlatStyle.Flat;
                        btn2.FlatAppearance.BorderSize = 0;
                        btn2.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 + 5);
                        btn2.Click += Btn2_Click;

                        this.Controls.Add(btn1);
                        this.Controls.Add(btn2);
                    }
                    break;
                case 1:
                    if (this.Controls.Count <= 0)
                    {
                        Button btn3 = new Button();
                        btn3.Text = "Zusammen";
                        btn3.BackColor = Color.Yellow;
                        btn3.Width = 200;
                        btn3.Height = 50;
                        btn3.Font = new Font(btn3.Font.FontFamily, 15);
                        btn3.FlatStyle = FlatStyle.Flat;
                        btn3.FlatAppearance.BorderSize = 0;
                        btn3.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 - 85);
                        btn3.Click += Btn3_Click;

                        Button btn4 = new Button();
                        btn4.Text = "Gegeneinander";
                        btn4.BackColor = Color.Yellow;
                        btn4.Width = 200;
                        btn4.Height = 50;
                        btn4.Font = new Font(btn4.Font.FontFamily, 15);
                        btn4.FlatStyle = FlatStyle.Flat;
                        btn4.FlatAppearance.BorderSize = 0;
                        btn4.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 - 25);
                        btn4.Click += Btn4_Click;

                        Button btn5 = new Button();
                        btn5.Text = "Zurück";
                        btn5.BackColor = Color.Yellow;
                        btn5.Width = 200;
                        btn5.Height = 50;
                        btn5.Font = new Font(btn5.Font.FontFamily, 15);
                        btn5.FlatStyle = FlatStyle.Flat;
                        btn5.FlatAppearance.BorderSize = 0;
                        btn5.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 + 35);
                        btn5.Click += Btn5_Click;

                        this.Controls.Add(btn3);
                        this.Controls.Add(btn4);
                        this.Controls.Add(btn5);
                    }
                    break;
                case 2:
                    Button btn6 = new Button();
                    btn6.Text = "Straßen bearbeiten";
                    btn6.BackColor = Color.Yellow;
                    btn6.Width = 200;
                    btn6.Height = 50;
                    btn6.Font = new Font(btn6.Font.FontFamily, 15);
                    btn6.FlatStyle = FlatStyle.Flat;
                    btn6.FlatAppearance.BorderSize = 0;
                    btn6.Location = new Point(ClientSize.Width / 2 - 205, ClientSize.Height / 2 - 85);
                    btn6.Click += Btn6_Click;

                    Button btn7 = new Button();
                    btn7.Text = "Schienen bearbeiten";
                    btn7.BackColor = Color.Yellow;
                    btn7.Width = 200;
                    btn7.Height = 50;
                    btn7.Font = new Font(btn7.Font.FontFamily, 15);
                    btn7.FlatStyle = FlatStyle.Flat;
                    btn7.FlatAppearance.BorderSize = 0;
                    btn7.Location = new Point(ClientSize.Width / 2 + 5, ClientSize.Height / 2 - 85);
                    btn7.Click += Btn7_Click;

                    Button btn8 = new Button();
                    btn8.Text = "Flüsse bearbeiten";
                    btn8.BackColor = Color.Yellow;
                    btn8.Width = 200;
                    btn8.Height = 50;
                    btn8.Font = new Font(btn8.Font.FontFamily, 15);
                    btn8.FlatStyle = FlatStyle.Flat;
                    btn8.FlatAppearance.BorderSize = 0;
                    btn8.Location = new Point(ClientSize.Width / 2 - 205, ClientSize.Height / 2 - 25);
                    btn8.Click += Btn8_Click;

                    Button btn9 = new Button();
                    btn9.Text = "Wiesen bearbeiten";
                    btn9.BackColor = Color.Yellow;
                    btn9.Width = 200;
                    btn9.Height = 50;
                    btn9.Font = new Font(btn9.Font.FontFamily, 15);
                    btn9.FlatStyle = FlatStyle.Flat;
                    btn9.FlatAppearance.BorderSize = 0;
                    btn9.Location = new Point(ClientSize.Width / 2 + 5, ClientSize.Height / 2 - 25);
                    btn9.Click += Btn9_Click;

                    Button btn10 = new Button();
                    btn10.Text = "Zurück";
                    btn10.BackColor = Color.Yellow;
                    btn10.Width = 200;
                    btn10.Height = 50;
                    btn10.Font = new Font(btn10.Font.FontFamily, 15);
                    btn10.FlatStyle = FlatStyle.Flat;
                    btn10.FlatAppearance.BorderSize = 0;
                    btn10.Location = new Point(ClientSize.Width / 2 - 205, ClientSize.Height / 2 + 35);
                    btn10.Click += Btn10_Click;

                    Button btn11 = new Button();
                    btn11.Text = "Start";
                    btn11.BackColor = Color.Yellow;
                    btn11.Width = 200;
                    btn11.Height = 50;
                    btn11.Font = new Font(btn11.Font.FontFamily, 15);
                    btn11.FlatStyle = FlatStyle.Flat;
                    btn11.FlatAppearance.BorderSize = 0;
                    btn11.Location = new Point(ClientSize.Width / 2 + 5, ClientSize.Height / 2 + 35);
                    btn11.Click += Btn11_Click;

                    this.Controls.Add(btn6);
                    this.Controls.Add(btn7);
                    this.Controls.Add(btn8);
                    this.Controls.Add(btn9);
                    this.Controls.Add(btn10);
                    this.Controls.Add(btn11);
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    if (this.Controls.Count <= 0)
                    {
                        Label l1 = new Label();
                        l1.Location = new Point(ClientSize.Width / 2 - 280, 10);
                        l1.Width = 180;
                        l1.Height = 20;
                        l1.Font = new Font(l1.Font.FontFamily, 11);

                        TextBox tb1 = new TextBox();
                        tb1.Name = "tb1";
                        tb1.Location = new Point(ClientSize.Width / 2 - 280, 30);
                        tb1.Width = 180;
                        tb1.Height = 30;
                        tb1.Font = new Font(tb1.Font.FontFamily, 13);
                        tb1.ReadOnly = false;
                        tb1.Enabled = true;
                        tb1.TextChanged += TextboxOnlyNumberic;

                        Label l2 = new Label();
                        l2.Text = "Min:";
                        l2.Location = new Point(ClientSize.Width / 2 - 90, 10);
                        l2.Width = 180;
                        l2.Height = 20;
                        l2.Font = new Font(l2.Font.FontFamily, 11);

                        TextBox tb2 = new TextBox();
                        tb2.Name = "tb2";
                        tb2.Location = new Point(ClientSize.Width / 2 - 90, 30);
                        tb2.Width = 180;
                        tb2.Height = 30;
                        tb2.Font = new Font(tb2.Font.FontFamily, 13);
                        tb2.ReadOnly = false;
                        tb2.Enabled = true;
                        tb2.TextChanged += TextboxOnlyNumberic;

                        Label l3 = new Label();
                        l3.Text = "Min:";
                        l3.Location = new Point(ClientSize.Width / 2 + 100, 10);
                        l3.Width = 180;
                        l3.Height = 20;
                        l3.Font = new Font(l3.Font.FontFamily, 11);

                        TextBox tb3 = new TextBox();
                        tb3.Name = "tb3";
                        tb3.Location = new Point(ClientSize.Width / 2 + 100, 30);
                        tb3.Width = 180;
                        tb3.Height = 30;
                        tb3.Font = new Font(tb3.Font.FontFamily, 13);
                        tb3.ReadOnly = false;
                        tb3.Enabled = true;
                        tb3.TextChanged += TextboxOnlyNumberic;


                        Label l4 = new Label();
                        l4.Location = new Point(ClientSize.Width / 2 - 280, 70);
                        l4.Width = 180;
                        l4.Height = 20;
                        l4.Font = new Font(l4.Font.FontFamily, 11);

                        TextBox tb4 = new TextBox();
                        tb4.Name = "tb4";
                        tb4.Location = new Point(ClientSize.Width / 2 - 280, 90);
                        tb4.Width = 180;
                        tb4.Height = 30;
                        tb4.Font = new Font(tb4.Font.FontFamily, 13);
                        tb4.ReadOnly = false;
                        tb4.Enabled = true;
                        tb4.TextChanged += TextboxOnlyNumberic;

                        Label l5 = new Label();
                        l5.Text = "Min:";
                        l5.Location = new Point(ClientSize.Width / 2 - 90, 70);
                        l5.Width = 180;
                        l5.Height = 20;
                        l5.Font = new Font(l5.Font.FontFamily, 11);

                        TextBox tb5 = new TextBox();
                        tb5.Name = "tb5";
                        tb5.Location = new Point(ClientSize.Width / 2 - 90, 90);
                        tb5.Width = 180;
                        tb5.Height = 30;
                        tb5.Font = new Font(tb5.Font.FontFamily, 13);
                        tb5.ReadOnly = false;
                        tb5.Enabled = true;
                        tb5.TextChanged += TextboxOnlyNumberic;

                        Label l6 = new Label();
                        l6.Text = "Min:";
                        l6.Location = new Point(ClientSize.Width / 2 + 100, 70);
                        l6.Width = 180;
                        l6.Height = 20;
                        l6.Font = new Font(l6.Font.FontFamily, 11);

                        TextBox tb6 = new TextBox();
                        tb6.Name = "tb6";
                        tb6.Location = new Point(ClientSize.Width / 2 + 100, 90);
                        tb6.Width = 180;
                        tb6.Height = 30;
                        tb6.Font = new Font(tb6.Font.FontFamily, 13);
                        tb6.ReadOnly = false;
                        tb6.Enabled = true;
                        tb6.TextChanged += TextboxOnlyNumberic;


                        Label l7 = new Label();
                        l7.Location = new Point(ClientSize.Width / 2 - 280, 120);
                        l7.Width = 180;
                        l7.Height = 20;
                        l7.Font = new Font(l7.Font.FontFamily, 11);

                        TextBox tb7 = new TextBox();
                        tb7.Name = "tb7";
                        tb7.Location = new Point(ClientSize.Width / 2 - 280, 140);
                        tb7.Width = 180;
                        tb7.Height = 30;
                        tb7.Font = new Font(tb7.Font.FontFamily, 13);
                        tb7.ReadOnly = false;
                        tb7.Enabled = true;
                        tb7.TextChanged += TextboxOnlyNumberic;

                        Label l8 = new Label();
                        l8.Text = "Min:";
                        l8.Location = new Point(ClientSize.Width / 2 - 90, 120);
                        l8.Width = 180;
                        l8.Height = 20;
                        l8.Font = new Font(l8.Font.FontFamily, 11);

                        TextBox tb8 = new TextBox();
                        tb8.Name = "tb8";
                        tb8.Location = new Point(ClientSize.Width / 2 - 90, 140);
                        tb8.Width = 180;
                        tb8.Height = 30;
                        tb8.Font = new Font(tb8.Font.FontFamily, 13);
                        tb8.ReadOnly = false;
                        tb8.Enabled = true;
                        tb8.TextChanged += TextboxOnlyNumberic;

                        Label l9 = new Label();
                        l9.Text = "Min:";
                        l9.Location = new Point(ClientSize.Width / 2 + 100, 120);
                        l9.Width = 180;
                        l9.Height = 20;
                        l9.Font = new Font(l9.Font.FontFamily, 11);

                        TextBox tb9 = new TextBox();
                        tb9.Name = "tb9";
                        tb9.Location = new Point(ClientSize.Width / 2 + 100, 140);
                        tb9.Width = 180;
                        tb9.Height = 30;
                        tb9.Font = new Font(tb9.Font.FontFamily, 13);
                        tb9.ReadOnly = false;
                        tb9.Enabled = true;
                        tb9.TextChanged += TextboxOnlyNumberic;


                        Label l10 = new Label();
                        l10.Location = new Point(ClientSize.Width / 2 - 280, 180);
                        l10.Width = 180;
                        l10.Height = 20;
                        l10.Font = new Font(l10.Font.FontFamily, 11);

                        TextBox tb10 = new TextBox();
                        tb10.Name = "tb10";
                        tb10.Location = new Point(ClientSize.Width / 2 - 280, 200);
                        tb10.Width = 180;
                        tb10.Height = 30;
                        tb10.Font = new Font(tb10.Font.FontFamily, 13);
                        tb10.ReadOnly = false;
                        tb10.Enabled = true;
                        tb10.TextChanged += TextboxOnlyNumberic;

                        Label l11 = new Label();
                        l11.Text = "Min:";
                        l11.Location = new Point(ClientSize.Width / 2 - 90, 180);
                        l11.Width = 180;
                        l11.Height = 20;
                        l11.Font = new Font(l11.Font.FontFamily, 11);

                        TextBox tb11 = new TextBox();
                        tb11.Name = "tb11";
                        tb11.Location = new Point(ClientSize.Width / 2 - 90, 200);
                        tb11.Width = 180;
                        tb11.Height = 30;
                        tb11.Font = new Font(tb11.Font.FontFamily, 13);
                        tb11.ReadOnly = false;
                        tb11.Enabled = true;
                        tb11.TextChanged += TextboxOnlyNumberic;

                        Label l12 = new Label();
                        l12.Text = "Min:";
                        l12.Location = new Point(ClientSize.Width / 2 + 100, 180);
                        l12.Width = 180;
                        l12.Height = 20;
                        l12.Font = new Font(l12.Font.FontFamily, 11);

                        TextBox tb12 = new TextBox();
                        tb12.Name = "tb12";
                        tb12.Location = new Point(ClientSize.Width / 2 + 100, 200);
                        tb12.Width = 180;
                        tb12.Height = 30;
                        tb12.Font = new Font(tb12.Font.FontFamily, 13);
                        tb12.ReadOnly = false;
                        tb12.Enabled = true;
                        tb12.TextChanged += TextboxOnlyNumberic;


                        Label l13 = new Label();
                        l13.Location = new Point(ClientSize.Width / 2 - 280, 240);
                        l13.Width = 180;
                        l13.Height = 20;
                        l13.Font = new Font(l13.Font.FontFamily, 11);

                        TextBox tb13 = new TextBox();
                        tb13.Name = "tb13";
                        tb13.Location = new Point(ClientSize.Width / 2 - 280, 260);
                        tb13.Width = 180;
                        tb13.Height = 30;
                        tb13.Font = new Font(tb13.Font.FontFamily, 13);
                        tb13.ReadOnly = false;
                        tb13.Enabled = true;
                        tb13.TextChanged += TextboxOnlyNumberic;

                        Label l14 = new Label();
                        l14.Text = "Min:";
                        l14.Location = new Point(ClientSize.Width / 2 - 90, 240);
                        l14.Width = 180;
                        l14.Height = 20;
                        l14.Font = new Font(l14.Font.FontFamily, 11);

                        TextBox tb14 = new TextBox();
                        tb14.Name = "tb14";
                        tb14.Location = new Point(ClientSize.Width / 2 - 90, 260);
                        tb14.Width = 180;
                        tb14.Height = 30;
                        tb14.Font = new Font(tb14.Font.FontFamily, 13);
                        tb14.ReadOnly = false;
                        tb14.Enabled = true;
                        tb14.TextChanged += TextboxOnlyNumberic;

                        Label l15 = new Label();
                        l15.Text = "Min:";
                        l15.Location = new Point(ClientSize.Width / 2 + 100, 240);
                        l15.Width = 180;
                        l15.Height = 20;
                        l15.Font = new Font(l15.Font.FontFamily, 11);

                        TextBox tb15 = new TextBox();
                        tb15.Name = "tb15";
                        tb15.Location = new Point(ClientSize.Width / 2 + 100, 260);
                        tb15.Width = 180;
                        tb15.Height = 30;
                        tb15.Font = new Font(tb15.Font.FontFamily, 13);
                        tb15.ReadOnly = false;
                        tb15.Enabled = true;
                        tb15.TextChanged += TextboxOnlyNumberic;

                        Button btn12 = new Button();
                        btn12.Text = "Zurück";
                        btn12.BackColor = Color.Yellow;
                        btn12.Width = 410;
                        btn12.Height = 50;
                        btn12.Font = new Font(btn12.Font.FontFamily, 15);
                        btn12.FlatStyle = FlatStyle.Flat;
                        btn12.FlatAppearance.BorderSize = 0;
                        btn12.Location = new Point(ClientSize.Width / 2 - 205, 310);
                        btn12.Click += Btn12_Click;

                        switch (menu)
                        {
                            case 3:
                                l1.Text = "Spawn wahrscheinlichkeit:";
                                l4.Text = "Auto Spawn rate von:";
                                l7.Text = "Auto Spawn rate bis:";
                                l10.Text = "Auto Speed von:";
                                l13.Text = "Auto Speed bis:";

                                tb1.Text = streetSpawnRate.ToString();
                                tb2.Text = streetSpawnRateInc.ToString();
                                tb3.Text = streetSpawnRateMin.ToString();
                                tb4.Text = carSpawnRateFrom.ToString();
                                tb5.Text = carSpawnRateFromInc.ToString();
                                tb6.Text = carSpawnRateFromMin.ToString();
                                tb7.Text = carSpawnRateTo.ToString();
                                tb8.Text = carSpawnRateToInc.ToString();
                                tb9.Text = carSpawnRateToMin.ToString();
                                tb10.Text = carSpeedFrom.ToString();
                                tb11.Text = carSpeedFromInc.ToString();
                                tb12.Text = carSpeedFromMin.ToString();
                                tb13.Text = carSpeedTo.ToString();
                                tb14.Text = carSpeedToInc.ToString();
                                tb15.Text = carSpeedToMin.ToString();
                                break;
                            case 4:
                                l1.Text = "Spawn wahrscheinlichkeit:";
                                l4.Text = "Zug Spawn rate von:";
                                l7.Text = "Zug Spawn rate bis:";
                                l10.Text = "Zug Speed von:";
                                l13.Text = "Zug Speed bis:";

                                tb1.Text = railSpawnRate.ToString();
                                tb2.Text = railSpawnRateInc.ToString();
                                tb3.Text = railSpawnRateMin.ToString();
                                tb4.Text = trainSpawnRateFrom.ToString();
                                tb5.Text = trainSpawnRateFromInc.ToString();
                                tb6.Text = trainSpawnRateFromMin.ToString();
                                tb7.Text = trainSpawnRateTo.ToString();
                                tb8.Text = trainSpawnRateToInc.ToString();
                                tb9.Text = trainSpawnRateToMin.ToString();
                                tb10.Text = trainSpeedFrom.ToString();
                                tb11.Text = trainSpeedFromInc.ToString();
                                tb12.Text = trainSpeedFromMin.ToString();
                                tb13.Text = trainSpeedTo.ToString();
                                tb14.Text = trainSpeedToInc.ToString();
                                tb15.Text = trainSpeedToMin.ToString();
                                break;
                            case 5:
                                l1.Text = "Spawn wahrscheinlichkeit:";
                                l4.Text = "Floß Spawn rate von:";
                                l7.Text = "Floß Spawn rate bis:";
                                l10.Text = "Floß Speed von:";
                                l13.Text = "Floß Speed bis:";

                                tb1.Text = riverSpawnRate.ToString();
                                tb2.Text = riverSpawnRateInc.ToString();
                                tb3.Text = riverSpawnRateMin.ToString();
                                tb4.Text = raftSpawnRateFrom.ToString();
                                tb5.Text = raftSpawnRateFromInc.ToString();
                                tb6.Text = raftSpawnRateFromMin.ToString();
                                tb7.Text = raftSpawnRateTo.ToString();
                                tb8.Text = raftSpawnRateToInc.ToString();
                                tb9.Text = raftSpawnRateToMin.ToString();
                                tb10.Text = raftSpeedFrom.ToString();
                                tb11.Text = raftSpeedFromInc.ToString();
                                tb12.Text = raftSpeedFromMin.ToString();
                                tb13.Text = raftSpeedTo.ToString();
                                tb14.Text = raftSpeedToInc.ToString();
                                tb15.Text = raftSpeedToMin.ToString();
                                break;
                            case 6:
                                l1.Text = "Spawn wahrscheinlichkeit:";
                                l4.Text = "Blockade Spawn wahrscheinlichkeit:";

                                tb1.Text = grassSpawnRate.ToString();
                                tb2.Text = grassSpawnRateInc.ToString();
                                tb3.Text = grassSpawnRateMin.ToString();
                                tb4.Text = grassSpawnRate.ToString();
                                tb5.Text = grassSpawnRateInc.ToString();
                                tb6.Text = blockadeSpawnRateMin.ToString();
                                break;
                        }

                        switch (menu)
                        {
                            case 6:
                                this.Controls.Add(l1);
                                this.Controls.Add(l2);
                                this.Controls.Add(l3);
                                this.Controls.Add(l4);
                                this.Controls.Add(l5);
                                this.Controls.Add(l6);
                                this.Controls.Add(tb1);
                                this.Controls.Add(tb2);
                                this.Controls.Add(tb3);
                                this.Controls.Add(tb4);
                                this.Controls.Add(tb5);
                                this.Controls.Add(tb6);
                                this.Controls.Add(btn12);
                                break;
                            default:
                                this.Controls.Add(l1);
                                this.Controls.Add(l2);
                                this.Controls.Add(l3);
                                this.Controls.Add(l4);
                                this.Controls.Add(l5);
                                this.Controls.Add(l6);
                                this.Controls.Add(l7);
                                this.Controls.Add(l8);
                                this.Controls.Add(l9);
                                this.Controls.Add(l10);
                                this.Controls.Add(l11);
                                this.Controls.Add(l12);
                                this.Controls.Add(l13);
                                this.Controls.Add(l14);
                                this.Controls.Add(l15);
                                this.Controls.Add(tb1);
                                this.Controls.Add(tb2);
                                this.Controls.Add(tb3);
                                this.Controls.Add(tb4);
                                this.Controls.Add(tb5);
                                this.Controls.Add(tb6);
                                this.Controls.Add(tb7);
                                this.Controls.Add(tb8);
                                this.Controls.Add(tb9);
                                this.Controls.Add(tb10);
                                this.Controls.Add(tb11);
                                this.Controls.Add(tb12);
                                this.Controls.Add(tb13);
                                this.Controls.Add(tb14);
                                this.Controls.Add(tb15);
                                this.Controls.Add(btn12);
                                break;
                        }
                    }
                    break;
                case 7:
                    if (tmrGameTick.Enabled == false && !gameOver)
                    {
                        breite = this.ClientSize.Width;
                        hoehe = this.ClientSize.Height;

                        hoeheJeBereich = hoehe / (anzahlBereiche + 2);

                        if (secondPlayer)
                        {
                            spieler1 = new Rectangle((breite / 2) - 35, hoehe - 35, 30, 30);
                            spieler2 = new Rectangle((breite / 2) + 5, hoehe - 35, 30, 30);
                        }
                        else
                        {
                            spieler1 = new Rectangle((breite / 2) - 15, hoehe - 35, 30, 30);
                        }

                        for (int i = 0; i < alleBahnen.Length; i++)
                        {
                            if (i == 0)
                            {
                                alleBahnen[i] = new Bahn(new Rectangle(0, i * hoeheJeBereich, breite, hoeheJeBereich), 0);
                            }
                            else if (i == alleBahnen.Length - 1)
                            {
                                alleBahnen[i] = new Bahn(new Rectangle(0, i * hoeheJeBereich, breite, hoeheJeBereich), 0);
                            }
                            else
                            {
                                alleBahnen[i] = new Bahn(new Rectangle(0, i * hoeheJeBereich, breite, hoeheJeBereich), GetRandomBahn());
                            }
                        }

                        spieler1InBereich = 0;
                        spieler2InBereich = 0;
                        startVerzoegerungPlayer1 = 5;
                        inputBlockedPlayer1 = true;
                        startVerzoegerungPlayer1 = 5;
                        inputBlockedPlayer1 = true;
                        gameOver = false;
                        gameOverPlayer1 = false;
                        gameOverPlayer2 = false;
                        player1Win = false;
                        player2Win = false;

                        tmrGameTick.Start();
                    }

                    for (int i = 0; i < alleBahnen.Length; i++)
                    {
                        if (i == 0)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), alleBahnen[i].Rectangle);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(alleBahnen[i].SolidBrush, alleBahnen[i].Rectangle);
                        }

                        if (image)
                        {
                            try
                            {
                                switch (alleBahnen[i].Type)
                                {
                                    case 0:
                                        e.Graphics.DrawImage(Image.FromFile("grass.png"), alleBahnen[i].Rectangle);
                                        break;
                                    case 1:
                                        e.Graphics.DrawImage(Image.FromFile("street.png"), alleBahnen[i].Rectangle);
                                        break;
                                    case 2:
                                        e.Graphics.DrawImage(Image.FromFile("rails.png"), alleBahnen[i].Rectangle);
                                        break;
                                    case 3:
                                        e.Graphics.DrawImage(Image.FromFile("river.png"), alleBahnen[i].Rectangle);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        e.Graphics.DrawRectangle(new Pen(Color.Black), alleBahnen[i].Rectangle);


                        foreach (Hindernis aktuellesHindernis in alleBahnen[i].AlleHindernisse)
                        {
                            SolidBrush solidBrush = new SolidBrush(Color.Red);

                            switch (aktuellesHindernis.Type)
                            {
                                case 0:
                                    switch (aktuellesHindernis.Color)
                                    {
                                        default:
                                            if (image)
                                            {
                                                try
                                                {
                                                    e.Graphics.DrawImage(Image.FromFile("car.png"), aktuellesHindernis.Rectangle);
                                                }
                                                catch (Exception ex)
                                                {
                                                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), aktuellesHindernis.Rectangle);
                                                }
                                            }
                                            else
                                            {
                                                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), aktuellesHindernis.Rectangle);
                                            }
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (aktuellesHindernis.Color)
                                    {
                                        default:
                                            if (image)
                                            {
                                                try
                                                {
                                                    e.Graphics.DrawImage(Image.FromFile("tree.png"), aktuellesHindernis.Rectangle);
                                                }
                                                catch (Exception ex)
                                                {
                                                    e.Graphics.FillRectangle(new SolidBrush(Color.Brown), aktuellesHindernis.Rectangle);
                                                }
                                            }
                                            else
                                            {
                                                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), aktuellesHindernis.Rectangle);
                                            }
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (aktuellesHindernis.Color)
                                    {
                                        default:
                                            if (image)
                                            {
                                                try
                                                {
                                                    e.Graphics.DrawImage(Image.FromFile("copse.png"), aktuellesHindernis.Rectangle);
                                                }
                                                catch (Exception ex)
                                                {
                                                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), aktuellesHindernis.Rectangle);
                                                }
                                            }
                                            else
                                            {
                                                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), aktuellesHindernis.Rectangle);
                                            }
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (aktuellesHindernis.Color)
                                    {
                                        default:
                                            if (image)
                                            {
                                                try
                                                {
                                                    if (aktuellesHindernis.richtung)
                                                    {
                                                        e.Graphics.DrawImage(Image.FromFile("train-1.png"), aktuellesHindernis.Rectangle);
                                                    }
                                                    else
                                                    {
                                                        e.Graphics.DrawImage(Image.FromFile("train-2.png"), aktuellesHindernis.Rectangle);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), aktuellesHindernis.Rectangle);
                                                }
                                            }
                                            else
                                            {
                                                e.Graphics.FillRectangle(new SolidBrush(Color.Red), aktuellesHindernis.Rectangle);
                                            }
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (aktuellesHindernis.Color)
                                    {
                                        default:
                                            if (image)
                                            {
                                                try
                                                {
                                                    e.Graphics.DrawImage(Image.FromFile("raft.png"), aktuellesHindernis.Rectangle);
                                                }
                                                catch (Exception ex)
                                                {
                                                    e.Graphics.FillRectangle(new SolidBrush(Color.SaddleBrown), aktuellesHindernis.Rectangle);
                                                }
                                            }
                                            else
                                            {
                                                e.Graphics.FillRectangle(new SolidBrush(Color.SaddleBrown), aktuellesHindernis.Rectangle);
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                    }

                    if (gameOverPlayer1)
                    {
                        if (image)
                        {
                            try
                            {
                                e.Graphics.DrawImage(Image.FromFile("frog-1-dead.png"), spieler1);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.FillEllipse(new SolidBrush(Color.Red), spieler1);
                            }
                        }
                        else
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), spieler1);
                        }
                    }
                    else
                    {
                        if (image)
                        {
                            try
                            {
                                e.Graphics.DrawImage(Image.FromFile("frog-1.png"), spieler1);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.FillEllipse(new SolidBrush(Color.Green), spieler1);
                            }
                        }
                        else
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Green), spieler1);
                        }
                    }

                    if (secondPlayer)
                    {
                        if (gameOverPlayer2)
                        {
                            if (image)
                            {
                                try
                                {
                                    e.Graphics.DrawImage(Image.FromFile("frog-2-dead.png"), spieler2);
                                }
                                catch (Exception ex)
                                {
                                    e.Graphics.FillEllipse(new SolidBrush(Color.Red), spieler2);
                                }
                            }
                            else
                            {
                                e.Graphics.FillEllipse(new SolidBrush(Color.Red), spieler2);
                            }
                        }
                        else
                        {
                            if (image)
                            {
                                try
                                {
                                    e.Graphics.DrawImage(Image.FromFile("frog-2.png"), spieler2);
                                }
                                catch (Exception ex)
                                {
                                    e.Graphics.FillEllipse(new SolidBrush(Color.YellowGreen), spieler2);
                                }
                            }
                            else
                            {
                                e.Graphics.FillEllipse(new SolidBrush(Color.YellowGreen), spieler2);
                            }
                        }
                    }
                    break;
            }
        }

        private int GetRandomBahn()
        {
            if ((int)streetSpawnRate < 0)
            {
                streetSpawnRate = 0;
            }

            if ((int)railSpawnRate < 0)
            {
                railSpawnRate = 0;
            }

            if ((int)riverSpawnRate < 0)
            {
                riverSpawnRate = 0;
            }

            if ((int)grassSpawnRate < 0)
            {
                grassSpawnRate = 0;
            }

            int maxValue = (int)streetSpawnRate + (int)railSpawnRate + (int)riverSpawnRate + (int)grassSpawnRate;

            if (maxValue > 0)
            {
                int rndNum = rndBahn.Next(maxValue);

                if (rndNum < streetSpawnRate)
                {
                    return 1;
                }
                else if (rndNum < streetSpawnRate + railSpawnRate)
                {
                    return 2;
                }
                else if (rndNum < streetSpawnRate + railSpawnRate + riverSpawnRate)
                {
                    return 3;
                }
            }
            return 0;
        }

        private void TextboxOnlyNumberic(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            double num = 0;

            switch (textBox.Name)
            {
                case "tb1":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                streetSpawnRate = num;
                            }
                            else
                            {
                                textBox.Text = streetSpawnRateStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                railSpawnRate = num;
                            }
                            else
                            {
                                textBox.Text = railSpawnRateStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                riverSpawnRate = num;
                            }
                            else
                            {
                                textBox.Text = riverSpawnRateStandard.ToString();
                            }
                            break;
                        case 6:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                grassSpawnRate = num;
                            }
                            else
                            {
                                textBox.Text = grassSpawnRateStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb2":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                streetSpawnRateInc = num;
                            }
                            else
                            {
                                textBox.Text = streetSpawnRateIncStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                railSpawnRateInc = num;
                            }
                            else
                            {
                                textBox.Text = railSpawnRateIncStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                riverSpawnRateInc = num;
                            }
                            else
                            {
                                textBox.Text = riverSpawnRateIncStandard.ToString();
                            }
                            break;
                        case 6:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                grassSpawnRateInc = num;
                            }
                            else
                            {
                                textBox.Text = grassSpawnRateIncStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb3":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                streetSpawnRateMin = num;
                            }
                            else
                            {
                                textBox.Text = streetSpawnRateMinStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                railSpawnRateMin = num;
                            }
                            else
                            {
                                textBox.Text = railSpawnRateMinStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                riverSpawnRateMin = num;
                            }
                            else
                            {
                                textBox.Text = riverSpawnRateMinStandard.ToString();
                            }
                            break;
                        case 6:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                grassSpawnRateMin = num;
                            }
                            else
                            {
                                textBox.Text = grassSpawnRateMinStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb4":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpawnRateFrom = num;
                            }
                            else
                            {
                                textBox.Text = carSpawnRateFromStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpawnRateFrom = num;
                            }
                            else
                            {
                                textBox.Text = trainSpawnRateFromStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpawnRateFrom = num;
                            }
                            else
                            {
                                textBox.Text = raftSpawnRateFromStandard.ToString();
                            }
                            break;
                        case 6:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                blockadeSpawnRate = num;
                            }
                            else
                            {
                                textBox.Text = blockadeSpawnRateStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb5":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpawnRateFromInc = num;
                            }
                            else
                            {
                                textBox.Text = carSpawnRateFromIncStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpawnRateFromInc = num;
                            }
                            else
                            {
                                textBox.Text = trainSpawnRateFromIncStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpawnRateFromInc = num;
                            }
                            else
                            {
                                textBox.Text = raftSpawnRateFromIncStandard.ToString();
                            }
                            break;
                        case 6:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                blockadeSpawnRateInc = num;
                            }
                            else
                            {
                                textBox.Text = blockadeSpawnRateIncStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb6":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpawnRateFromMin = num;
                            }
                            else
                            {
                                textBox.Text = carSpawnRateFromMinStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpawnRateFromMin = num;
                            }
                            else
                            {
                                textBox.Text = trainSpawnRateFromMinStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpawnRateFromMin = num;
                            }
                            else
                            {
                                textBox.Text = raftSpawnRateFromMinStandard.ToString();
                            }
                            break;
                        case 6:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                blockadeSpawnRateMin = num;
                            }
                            else
                            {
                                textBox.Text = blockadeSpawnRateMinStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb7":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpawnRateTo = num;
                            }
                            else
                            {
                                textBox.Text = carSpawnRateToStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpawnRateTo = num;
                            }
                            else
                            {
                                textBox.Text = trainSpawnRateToStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpawnRateTo = num;
                            }
                            else
                            {
                                textBox.Text = raftSpawnRateToStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb8":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpawnRateToInc = num;
                            }
                            else
                            {
                                textBox.Text = carSpawnRateToIncStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpawnRateToInc = num;
                            }
                            else
                            {
                                textBox.Text = trainSpawnRateToIncStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpawnRateToInc = num;
                            }
                            else
                            {
                                textBox.Text = raftSpawnRateToIncStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb9":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpawnRateToMin = num;
                            }
                            else
                            {
                                textBox.Text = carSpawnRateToMinStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpawnRateToMin = num;
                            }
                            else
                            {
                                textBox.Text = trainSpawnRateToMinStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpawnRateToMin = num;
                            }
                            else
                            {
                                textBox.Text = raftSpawnRateToMinStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb10":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpeedFrom = num;
                            }
                            else
                            {
                                textBox.Text = carSpeedFromStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpeedFrom = num;
                            }
                            else
                            {
                                textBox.Text = trainSpeedFromStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpeedFrom = num;
                            }
                            else
                            {
                                textBox.Text = raftSpeedFromStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb11":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpeedFromInc = num;
                            }
                            else
                            {
                                textBox.Text = carSpeedFromIncStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpeedFromInc = num;
                            }
                            else
                            {
                                textBox.Text = trainSpeedFromIncStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpeedFromInc = num;
                            }
                            else
                            {
                                textBox.Text = raftSpeedFromIncStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb12":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpeedFromMin = num;
                            }
                            else
                            {
                                textBox.Text = carSpeedFromMinStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpeedFromMin = num;
                            }
                            else
                            {
                                textBox.Text = trainSpeedFromMinStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpeedFromMin = num;
                            }
                            else
                            {
                                textBox.Text = raftSpeedFromMinStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb13":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpeedTo = num;
                            }
                            else
                            {
                                textBox.Text = carSpeedToStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpeedTo = num;
                            }
                            else
                            {
                                textBox.Text = trainSpeedToStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpeedTo = num;
                            }
                            else
                            {
                                textBox.Text = raftSpeedToStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb14":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpeedToInc = num;
                            }
                            else
                            {
                                textBox.Text = carSpeedToIncStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpeedToInc = num;
                            }
                            else
                            {
                                textBox.Text = trainSpeedToIncStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpeedToInc = num;
                            }
                            else
                            {
                                textBox.Text = raftSpeedToIncStandard.ToString();
                            }
                            break;
                    }
                    break;
                case "tb15":
                    switch (menu)
                    {
                        case 3:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                carSpeedToMin = num;
                            }
                            else
                            {
                                textBox.Text = carSpeedToMinStandard.ToString();
                            }
                            break;
                        case 4:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                trainSpeedToMin = num;
                            }
                            else
                            {
                                textBox.Text = trainSpeedToMinStandard.ToString();
                            }
                            break;
                        case 5:
                            if (double.TryParse(textBox.Text, out num))
                            {
                                raftSpeedToMin = num;
                            }
                            else
                            {
                                textBox.Text = raftSpeedToMinStandard.ToString();
                            }
                            break;
                    }
                    break;
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            menu = 2;
            secondPlayer = false;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            menu = 1;
            secondPlayer = true;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            menu = 2;
            coop = true;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            menu = 2;
            coop = false;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            menu = 0;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            menu = 3;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            menu = 4;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            menu = 5;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            menu = 6;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn10_Click(object sender, EventArgs e)
        {
            menu = 0;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn11_Click(object sender, EventArgs e)
        {
            menu = 7;
            this.Controls.Clear();
            this.Refresh();
        }

        private void Btn12_Click(object sender, EventArgs e)
        {
            menu = 2;
            this.Controls.Clear();
            this.Refresh();
        }

        private void tmrGameTick_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (startVerzoegerungPlayer1 > 0)
                {
                    startVerzoegerungPlayer1--;
                    inputBlockedPlayer1 = true;
                }
                else
                {
                    inputBlockedPlayer1 = false;
                }

                if (startVerzoegerungPlayer2 > 0)
                {
                    startVerzoegerungPlayer2--;
                    inputBlockedPlayer2 = true;
                }
                else
                {
                    inputBlockedPlayer2 = false;
                }

                for (int i = 1; i < alleBahnen.Length - 1; i++)
                {
                    alleBahnen[i].UpdateBahn();
                }

                this.Refresh();
            }
        }

        private void FrmFrogger_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameOver)
            {
                if (!inputBlockedPlayer1 && !gameOverPlayer1 && !player1Win)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            if (alleBahnen[alleBahnen.Length - spieler1InBereich - 2].CheckForCollision(0, true))
                            {
                                spieler1.Y = spieler1.Y - hoeheJeBereich;
                                spieler1InBereich++;

                                if (spieler1InBereich >= alleBahnen.Length - 1)
                                {
                                    if (secondPlayer && coop)
                                    {
                                        if (player2Win)
                                        {
                                            lose = false;
                                            gameOver = true;
                                            PlaySound(2);
                                        }
                                        else
                                        {
                                            player1Win = true;
                                        }
                                    }
                                    else
                                    {
                                        lose = false;
                                        gameOver = true;
                                        PlaySound(2);
                                    }
                                }

                                PlaySound(0);

                                startVerzoegerungPlayer1 = 3;
                                inputBlockedPlayer1 = true;
                            }
                            break;
                        case Keys.Down:
                            if (spieler1InBereich > 0 && alleBahnen[alleBahnen.Length - spieler1InBereich].CheckForCollision(1, true))
                            {
                                spieler1.Y = spieler1.Y + hoeheJeBereich;
                                spieler1InBereich--;

                                PlaySound(0);

                                startVerzoegerungPlayer1 = 3;
                                inputBlockedPlayer1 = true;
                            }
                            break;
                        case Keys.Left:
                            if (alleBahnen[alleBahnen.Length - spieler1InBereich - 1].CheckForCollision(2, true))
                            {
                                if (spieler1.X - hoeheJeBereich >= 0)
                                {
                                    spieler1.X = spieler1.X - hoeheJeBereich;

                                    PlaySound(0);

                                    startVerzoegerungPlayer1 = 3;
                                    inputBlockedPlayer1 = true;
                                }
                            }
                            break;
                        case Keys.Right:
                            if (alleBahnen[alleBahnen.Length - spieler1InBereich - 1].CheckForCollision(3, true))
                            {
                                if (spieler1.Right + hoeheJeBereich <= breite)
                                {
                                    spieler1.X = spieler1.X + hoeheJeBereich;

                                    PlaySound(0);

                                    startVerzoegerungPlayer1 = 3;
                                    inputBlockedPlayer1 = true;
                                }
                            }
                            break;
                    }
                }

                if (secondPlayer && !inputBlockedPlayer2 && !gameOverPlayer2 && !player2Win)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.W:
                            if (alleBahnen[alleBahnen.Length - spieler2InBereich - 2].CheckForCollision(0, false))
                            {
                                spieler2.Y = spieler2.Y - hoeheJeBereich;
                                spieler2InBereich++;

                                if (spieler2InBereich >= alleBahnen.Length - 1)
                                {
                                    if (coop)
                                    {
                                        if (player1Win)
                                        {
                                            lose = false;
                                            gameOver = true;
                                            PlaySound(2);
                                        }
                                        else
                                        {
                                            player2Win = true;
                                        }
                                    }
                                    else
                                    {
                                        lose = false;
                                        gameOver = true;
                                        PlaySound(2);
                                    }
                                }

                                PlaySound(0);

                                startVerzoegerungPlayer2 = 3;
                                inputBlockedPlayer2 = true;
                            }
                            break;
                        case Keys.S:
                            if (spieler2InBereich > 0 && alleBahnen[alleBahnen.Length - spieler2InBereich].CheckForCollision(1, false))
                            {
                                spieler2.Y = spieler2.Y + hoeheJeBereich;
                                spieler2InBereich--;

                                PlaySound(0);

                                startVerzoegerungPlayer2 = 3;
                                inputBlockedPlayer2 = true;
                            }
                            break;
                        case Keys.A:
                            if (alleBahnen[alleBahnen.Length - spieler2InBereich - 1].CheckForCollision(2, false))
                            {
                                if (spieler2.X - hoeheJeBereich >= 0)
                                {
                                    spieler2.X = spieler2.X - hoeheJeBereich;

                                    PlaySound(0);

                                    startVerzoegerungPlayer2 = 3;
                                    inputBlockedPlayer2 = true;
                                }
                            }
                            break;
                        case Keys.D:
                            if (alleBahnen[alleBahnen.Length - spieler2InBereich - 1].CheckForCollision(3, false))
                            {
                                if (spieler2.Right + hoeheJeBereich <= breite)
                                {
                                    spieler2.X = spieler2.X + hoeheJeBereich;

                                    PlaySound(0);

                                    startVerzoegerungPlayer2 = 3;
                                    inputBlockedPlayer2 = true;
                                }
                            }
                            break;
                    }
                }
            }

            if (e.KeyCode == Keys.Enter && gameOver)
            {
                if (lose)
                {
                    menu = 0;

                    streetSpawnRate = streetSpawnRateStandard;
                    streetSpawnRateInc = streetSpawnRateIncStandard;
                    streetSpawnRateMin = streetSpawnRateMinStandard;
                    carSpawnRateFrom = carSpawnRateFromStandard;
                    carSpawnRateFromInc = carSpawnRateFromIncStandard;
                    carSpawnRateFromMin = carSpawnRateFromMinStandard;
                    carSpawnRateTo = carSpawnRateToStandard;
                    carSpawnRateToInc = carSpawnRateToIncStandard;
                    carSpawnRateToMin = carSpawnRateToMinStandard;
                    carSpeedFrom = carSpeedFromStandard;
                    carSpeedFromInc = carSpeedFromIncStandard;
                    carSpeedFromMin = carSpeedFromMinStandard;
                    carSpeedTo = carSpeedToStandard;
                    carSpeedToInc = carSpeedToIncStandard;
                    carSpeedToMin = carSpeedToMinStandard;

                    railSpawnRate = railSpawnRateStandard;
                    railSpawnRateInc = railSpawnRateIncStandard;
                    railSpawnRateMin = railSpawnRateMinStandard;
                    trainSpawnRateFrom = trainSpawnRateFromStandard;
                    trainSpawnRateFromInc = trainSpawnRateFromIncStandard;
                    trainSpawnRateFromMin = trainSpawnRateFromMinStandard;
                    trainSpawnRateTo = trainSpawnRateToStandard;
                    trainSpawnRateToInc = trainSpawnRateToIncStandard;
                    trainSpawnRateToMin = trainSpawnRateToMinStandard;
                    trainSpeedFrom = trainSpeedFromStandard;
                    trainSpeedFromInc = trainSpeedFromIncStandard;
                    trainSpeedFromMin = trainSpeedFromMinStandard;
                    trainSpeedTo = trainSpeedToStandard;
                    trainSpeedToInc = trainSpeedToIncStandard;
                    trainSpeedToMin = trainSpeedToMinStandard;

                    riverSpawnRate = riverSpawnRateStandard;
                    riverSpawnRateInc = riverSpawnRateIncStandard;
                    riverSpawnRateMin = riverSpawnRateMinStandard;
                    raftSpawnRateFrom = raftSpawnRateFromStandard;
                    raftSpawnRateFromInc = raftSpawnRateFromIncStandard;
                    raftSpawnRateFromMin = raftSpawnRateFromMinStandard;
                    raftSpawnRateTo = raftSpawnRateToStandard;
                    raftSpawnRateToInc = raftSpawnRateToIncStandard;
                    raftSpawnRateToMin = raftSpawnRateToMinStandard;
                    raftSpeedFrom = raftSpeedFromStandard;
                    raftSpeedFromInc = raftSpeedFromIncStandard;
                    raftSpeedFromMin = raftSpeedFromMinStandard;
                    raftSpeedTo = raftSpeedToStandard;
                    raftSpeedToInc = raftSpeedToIncStandard;
                    raftSpeedToMin = raftSpeedToMinStandard;

                    grassSpawnRate = grassSpawnRateStandard;
                    grassSpawnRateInc = grassSpawnRateIncStandard;
                    grassSpawnRateMin = grassSpawnRateMinStandard;
                    blockadeSpawnRate = blockadeSpawnRateStandard;
                    blockadeSpawnRateInc = blockadeSpawnRateIncStandard;
                    blockadeSpawnRateMin = blockadeSpawnRateMinStandard;
                }
                else
                {
                    streetSpawnRate += streetSpawnRateInc;
                    carSpawnRateFrom += carSpawnRateFromInc;
                    carSpawnRateTo += carSpawnRateToInc;
                    carSpeedFrom += carSpeedFromInc;
                    carSpeedTo += carSpeedToInc;

                    railSpawnRate += railSpawnRateInc;
                    trainSpawnRateFrom += trainSpawnRateFromInc;
                    trainSpawnRateTo += trainSpawnRateToInc;
                    trainSpeedFrom += trainSpeedFromInc;
                    trainSpeedTo += trainSpeedToInc;

                    riverSpawnRate += riverSpawnRateInc;
                    raftSpawnRateFrom += raftSpawnRateFromInc;
                    raftSpawnRateTo += raftSpawnRateToInc;
                    raftSpeedFrom += raftSpeedFromInc;
                    raftSpeedTo += raftSpeedToInc;

                    grassSpawnRate += grassSpawnRateInc;
                    blockadeSpawnRate += blockadeSpawnRateInc;

                    if (streetSpawnRate < streetSpawnRateMin)
                        streetSpawnRate = streetSpawnRateMin;

                    if (carSpawnRateFrom < carSpawnRateFromMin)
                        carSpawnRateFrom = carSpawnRateFromMin;

                    if (carSpawnRateTo < carSpawnRateToMin)
                        carSpawnRateTo = carSpawnRateToMin;

                    if (carSpeedFrom < carSpeedFromMin)
                        carSpeedFrom = carSpeedFromMin;

                    if (carSpeedTo < carSpeedToMin)
                        carSpeedTo = carSpeedToMin;


                    if (railSpawnRate < railSpawnRateMin)
                        railSpawnRate = railSpawnRateMin;

                    if (trainSpawnRateFrom < trainSpawnRateFromMin)
                        trainSpawnRateFrom = trainSpawnRateFromMin;

                    if (trainSpawnRateTo < trainSpawnRateToMin)
                        trainSpawnRateTo = trainSpawnRateToMin;

                    if (trainSpeedFrom < trainSpeedFromMin)
                        trainSpeedFrom = trainSpeedFromMin;

                    if (trainSpeedTo < trainSpeedToMin)
                        trainSpeedTo = trainSpeedToMin;


                    if (riverSpawnRate < riverSpawnRateMin)
                        riverSpawnRate = riverSpawnRateMin;

                    if (raftSpawnRateFrom < raftSpawnRateFromMin)
                        raftSpawnRateFrom = raftSpawnRateFromMin;

                    if (raftSpawnRateTo < raftSpawnRateToMin)
                        raftSpawnRateTo = raftSpawnRateToMin;

                    if (raftSpeedFrom < raftSpeedFromMin)
                        raftSpeedFrom = raftSpeedFromMin;

                    if (raftSpeedTo < raftSpeedToMin)
                        raftSpeedTo = raftSpeedToMin;


                    if (grassSpawnRate < grassSpawnRateMin)
                        grassSpawnRate = grassSpawnRateMin;

                    if (blockadeSpawnRate < blockadeSpawnRateMin)
                        blockadeSpawnRate = blockadeSpawnRateMin;
                }

                gameOver = false;
                tmrGameTick.Stop();
            }

            this.Refresh();
        }

        public static void PlaySound(int type)
        {
            try
            {
                string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string sFile = "";

                switch (type)
                {
                    case 0:
                        sFile = System.IO.Path.Combine(sCurrentDirectory, @".\jump" + rndBahn.Next(2) + ".wav");
                        break;
                    case 1:
                        sFile = System.IO.Path.Combine(sCurrentDirectory, @".\crash" + rndBahn.Next(3) + ".wav");
                        break;
                    case 2:
                        sFile = System.IO.Path.Combine(sCurrentDirectory, @".\win1.wav");
                        break;
                }

                SoundPlayer simpleSound = new SoundPlayer(Path.GetFullPath(sFile));
                simpleSound.Play();
            }
            catch (Exception ex)
            {

            }
        }

        public static void GameOver(bool player)
        {
            PlaySound(1);

            if (player)
            {
                gameOverPlayer1 = true;
            }
            else
            {
                gameOverPlayer2 = true;
            }

            if (secondPlayer)
            {
                if (coop)
                {
                    if (!gameOverPlayer1 || !gameOverPlayer2)
                    {
                        lose = true;
                        gameOver = true;
                    }
                }
                else if (gameOverPlayer1 && gameOverPlayer2)
                {
                    lose = true;
                    gameOver = true;
                }
                else if ((player1Win && gameOverPlayer2) || (player2Win && gameOverPlayer1))
                {
                    lose = false;
                    gameOver = true;
                }
            }
            else if (gameOverPlayer1)
            {
                lose = true;
                gameOver = true;
            }
        }
    }
}