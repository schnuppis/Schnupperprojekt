using System;
using System.Windows.Forms;

// !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

namespace Schnupperspiel
{
    public partial class frmGame : Form
    {
        public Game game = new Game();
        private Random random = new Random();
        public static int xPlayer = 750;
        public static int yPlayer = 450;

        public Panel gamePanel;

        public frmGame()
        {
            InitializeComponent();
        }
        private void loadGame(object sender, EventArgs e)
        {
            
            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800,500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);
            
            Label labelname = new Label();
            labelname.setPosition(820, 480);
            labelname.setSize(250, 55);

            labelname.setText("Münzenjäger:");

            game.add(labelname);

            Label Time = new Label();
            Time.setPosition(820,10);
            Time.setSize(220,55);

            Time.setText("Time");

            game.add(Time);

            Label Points = new Label();
            Points.setPosition(820, 70);
            Points.setSize(220, 55);

            Points.setText("Points");

            game.add(Points);

            Label Hightscore = new Label();
            Hightscore.setPosition(820, 130);
            Hightscore.setSize(220, 55);

            Hightscore.setText("Hightscore");

            game.add(Hightscore);

            Text hightscore = new Text();
            hightscore.setPosition(1050,130);
            hightscore.setSize(94, 44);

           

            game.addHighscoreText(hightscore);


            Text points = new Text();
            points.setPosition(1050, 70);
            points.setSize(94, 44);

           

            game.addPointsText(points);

            Text time = new Text();
            time.setPosition(1050, 10);
            time.setSize(94, 44);

            

            game.addTimeText(time);

            Button Start = new Button();
            Start.setPosition(12, 550);
            Start.setSize(181,62);
            Start.setColour(0,255,0);
            Start.setText("Start");

            Start.Click += new System.EventHandler(game.btnStart_Click);
            game.add(Start);

         

            Button Stop = new Button();
            Stop.setPosition(423, 550);
            Stop.setSize(181, 62);
            Stop.setColour(255, 0, 0);
            Stop.setText("Stop");

            Stop.Click += new System.EventHandler(game.btnStop_Click);
            game.add(Stop);

            Stop.Enabled = false;

            game.makeGame(this);

        }
        private void movePlayer(object sender, KeyEventArgs key)
        {
            /*Player player = gamePanel.getPlayer();
            if (key.KeyCode == Keys.D && game.checkPanelRight())
            {
                
            }
            if (key.KeyCode == Keys.A && game.checkPanelLeft())
            {
                
            }
            if (key.KeyCode == Keys.W && game.checkPanelTop())
            {
                
            }
            if (key.KeyCode == Keys.S && game.checkPanelBottom())
            {
                
            }*/
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
