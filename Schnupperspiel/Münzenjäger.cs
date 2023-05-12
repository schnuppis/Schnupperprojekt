using System;
using System.Windows.Forms;

// !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

namespace Schnupperspiel
{
    public partial class frmGame : Form
    {
        public Game game = new Game();
        private Random random = new Random();
        

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


            Label labelScoreboard = new Label();
            labelScoreboard.setPosition(820, 480);
            labelScoreboard.setSize(250, 55);
            labelScoreboard.setText("Münzenjäger");
            game.add(labelScoreboard);

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220,55);
            labelTime.setText("Time:");
            game.add(labelTime);

            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220,55);
            labelPoints.setText("Points:");
            game.add(labelPoints);

            Label labelHighscore = new Label();
            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220, 55);
            labelHighscore.setText("Highscore:");
            game.add(labelHighscore);

            Text textTime = new Text();
            textTime.setPosition(1050, 10);
            textTime.setSize(94, 44);
            game.addTimeText(textTime);

            Text textPoints = new Text();
            textPoints.setPosition(1050, 70);
            textPoints.setSize(94, 44);
            game.addPointsText(textPoints);

            Text textHighscore = new Text();
            textHighscore.setPosition(1050, 130);
            textHighscore.setSize(94,44);
            game.addHighscoreText(textHighscore);

            Button buttonStart = new Button();
            buttonStart.setPosition(12, 550);
            buttonStart.setSize(181, 62);
            buttonStart.setColour(2, 255, 0);
            buttonStart.setText("Start");
            buttonStart.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttonStart);

            Button buttonStop = new Button();
            buttonStop.setPosition(12, 550);
            buttonStop.setSize(181, 62);
            buttonStop.setColour(255, 0, 0);
            buttonStop.setText("Stop");
            buttonStop.Enabled = false;
            buttonStop.Click += new System.EventHandler(game.btnStop_Click);
            game.add(buttonStop);

            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);

            game.makeGame(this);
        }
        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50, 50);
            player.setSpeed(4);
            player.setPosition(0,0);
            return player;

        }
        private void movePlayer(object sender, KeyEventArgs key)
        {
           Player player = gamePanel.getPlayer();
            if (key.KeyCode == Keys.D && game.checkPanelRight())
            {
                player.moveRight();
            }
            if (key.KeyCode == Keys.A && game.checkPanelLeft())
            {
                player.moveLeft();
            }
            if (key.KeyCode == Keys.W && game.checkPanelTop())
            {
                player.moveUp();
            }
            if (key.KeyCode == Keys.S && game.checkPanelBottom())
            {
                player.moveDown();
            }
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
