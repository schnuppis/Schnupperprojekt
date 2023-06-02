using System;
using System.Drawing.Text;
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

        private Player CreatePlayer()
        {
            Player Player = new Player();
            Player.setSize(50, 50);
            Player.setSpeed(4);
            Player.setPosition(xPlayer, yPlayer);
            return Player;
        }

        private void loadGame(object sender, EventArgs e)
        {

            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);

            Label time = new Label();
            time.setPosition(820, 0);
            time.setSize(250, 55);
            time.setText("Time:");

            Label points = new Label();
            points.setPosition(820, 100);
            points.setSize(250, 55);
            points.setText("Points:");

            Label highscore = new Label();
            highscore.setPosition(820, 200);
            highscore.setSize(250, 55);
            highscore.setText("High-Score:");

            game.add(time);
            game.add(points);
            game.add(highscore);

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

            Button Start = new Button();
            Start.setPosition(12, 550);
            Start.setSize(181, 62);
            Start.setColour(255, 255, 255);
            Start.setText("Start");
            Start.Click += new System.EventHandler(game.btnStart_Click);

            Button Stop = new Button();
            Stop.setPosition(423, 550);
            Stop.setSize(181, 62);
            Stop.setColour(255, 255, 255);
            Stop.setText("Stop");
            Stop.Enabled = false;
            Stop.Click += new System.EventHandler(game.btnStop_Click);

            KeyDown += new KeyEventHandler(movePlayer);
            KeyUp += new KeyEventHandler(movePlayer);

            game.add(Start);
            game.add(Stop);

            gamePanel.add(CreatePlayer());

            game.makeGame(this);
        }

        

        private void movePlayer(object sender, KeyEventArgs key)
        {
            Player Player = gamePanel.getPlayer();
            if (key.KeyCode == Keys.D & true & game.checkPanelRight())
            {
                _ = Player.moveRight();
            }
            if (key.KeyCode == Keys.A & true & game.checkPanelLeft())
            {
                 Player.moveLeft();
            }
            if (key.KeyCode == Keys.W & true & game.checkPanelTop())
            {
                _ = Player.moveUp();
            }
            if (key.KeyCode == Keys.S & true & game.checkPanelBottom())
            {
                _ = Player.moveDown();
            }
            _ = Player.getPositionX();
            _ = Player.getPositionY();
            Player.setPosition(Player.getPositionX(), Player.getPositionY());
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        
        }*/
    }
}
