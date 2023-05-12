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
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

           Label labelname = new Label();
            labelname.setPosition(820, 480);
            labelname.setSize(250, 55);
            labelname.setText("Münzenjäger:");
            game.add(labelname);

           Label time = new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("Time:");
            game.add(time);

           Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("Points:");
            game.add(points);

           Label highscore = new Label();
            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("Highscore:");
            game.add(highscore);


            Text TimeText = new Text();
            TimeText.setPosition(1050, 10);
            TimeText.setSize(94, 44);
            game.addTimeText(TimeText);

            Text PointsText = new Text();
            PointsText.setPosition(1050, 70);
            PointsText.setSize(94, 44);
            game.addPointsText(PointsText);

            Text HighscoreText = new Text();
            HighscoreText.setPosition(1050, 130);
            HighscoreText.setSize(94, 44);
            game.addHighscoreText(HighscoreText);

            
            Button startButton = new Button();
            startButton.setPosition(12, 550);
            startButton.setSize(181, 62);
            startButton.setColour(255,255,255);
            startButton.setText("Start");
            startButton.Click += new System.EventHandler(game.btnStart_Click);
            game.add(startButton);

            Button stopButton = new Button();
            stopButton.setPosition(423, 550);
            stopButton.setSize(181, 62);
            stopButton.setColour(255, 255, 255);
            stopButton.setText("Stop");
            stopButton.Enabled = false;
            stopButton.Click += new System.EventHandler(game.btnStop_Click);
            game.add(stopButton);


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
