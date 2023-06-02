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

            Label timeLabel = new Label();
            timeLabel.setPosition(820, 0);
            timeLabel.setSize(250, 55);
            timeLabel.setText("Time:");

            Label pointsLabel = new Label();
            pointsLabel.setPosition(820, 100);
            pointsLabel.setSize(250, 55);
            pointsLabel.setText("Points:");

            Label highscoreLabel = new Label();
            highscoreLabel.setPosition(820, 200);
            highscoreLabel.setSize(250, 55);
            highscoreLabel.setText("High-Score:");

            game.add(timeLabel);
            game.add(pointsLabel);
            game.add(highscoreLabel);

            Text textName = new Text();
            Text TimeText = new Text();
            Text PointsText = new Text();
            Text HighscoreText = new Text();

            PointsText.setPosition(1050, 10);
            TimeText.setPosition(1050, 70);
            HighscoreText.setPosition(1050, 130);

            PointsText.setSize(94, 44);
            TimeText.setSize(94, 44);
            HighscoreText.setSize(94, 44);

            game.addPointsText(textName);
            game.addTimeText(textName);
            game.addHighscoreText(textName);
            


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
