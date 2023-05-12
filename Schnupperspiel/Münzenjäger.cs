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
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

            Label Titellabel =new Label();
            Titellabel.setPosition(820, 480);
            Titellabel.setSize(250, 55);
            Titellabel.setText("Münzenjäger");

            Label TimeLabel = new Label();
            TimeLabel.setPosition(820, 10);
            TimeLabel.setSize(220, 55);
            TimeLabel.setText("time:");

            Label PointsLabel = new Label();
            PointsLabel.setPosition(820, 70);
            PointsLabel.setSize(220, 55);
            PointsLabel.setText("Points:");

            Label Highscore = new Label();
            Highscore.setPosition(820, 130);
            Highscore.setSize(220, 55);
            Highscore.setText("Highscore:");

            game.add(Highscore);
            game.add(PointsLabel);
            game.add(Titellabel);
            game.add(TimeLabel);

            Text TimeText = new Text();
            TimeText.setPosition(1050, 10);
            TimeText.setSize(94, 44);

            Text PointsText = new Text();
            PointsText.setPosition(1050, 70);
            PointsText.setSize(94, 44);

            Text HighscoreText = new Text();
            HighscoreText.setPosition(1050, 130);
            HighscoreText.setSize(94, 44);

            game.add(HighscoreText);
            game.add(PointsText);
            game.add(TimeText);

            Button startButton = new Button();
            startButton.setPosition(12, 550);
            startButton.setSize(181, 62);
            startButton.setColour(255, 255, 255);
            startButton.setText("Start");

            startButton.Click += new System.EventHandler(game.btnStart_Click);

            Button stopButton = new Button();
            stopButton.setPosition(423, 550);
            stopButton.setSize(181, 62);
            stopButton.setColour(255, 255, 255);
            stopButton.setText("Stop");

            stopButton.Enabled = false;
            stopButton.Click += new System.EventHandler(game.btnStop_Click);

            game.add(startButton);
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
