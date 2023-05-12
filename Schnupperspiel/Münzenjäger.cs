using System;
using System.Security.Cryptography;
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
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);

            Button start = new Button();
            Button stop = new Button();

            start.setPosition(12, 550);
            start.setSize(181, 62);
            start.setText("Start");
            start.setColour(255, 255, 255);
            start.Click += new System.EventHandler(game.btnStart_Click);

            stop.setPosition(423, 550);
            stop.setSize(181, 62);
            stop.setText("Stop");
            stop.setColour(255, 255, 255);
            stop.Enabled = false;
            stop.Click += new System.EventHandler(game.btnStop_Click);

            Text timetext = new Text();
            Text pointtext = new Text();
            Text highscoretext = new Text();

            timetext.setPosition(1050, 10);
            timetext.setSize(94, 44);

            pointtext.setPosition(1050, 70);
            pointtext.setSize(94, 44);

            highscoretext.setPosition(1050, 130);
            highscoretext.setSize(94, 44);


            Label name = new Label();
            Label points = new Label();
            Label time = new Label();
            Label highscore = new Label();

            name.setPosition(820, 480);
            name.setSize(250, 55);
            name.setText("Münzenjäger");

            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("Time:");

            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("Points:");

            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("Higscore:");

            KeyDown += new KeyEventHandler(movePlayer);
            
            
            game.add(name);
            game.add(time);
            game.add(points);
            game.add(highscore);
           
            game.addTimeText(timetext);
            game.addPointsText(pointtext);
            game.addHighscoreText(highscoretext);

            game.add(start);
            game.add(stop);
            gamePanel.add(createPlayer());


          


            game.makeGame(this);
        }
        private Player createPlayer()
        {

            Player player = new Player();

            player.setSize(50, 50);
            player.setSpeed(4);
            player.setPosition(xPlayer, yPlayer);
            

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
            player.setPosition(player.getPositionX(), player.getPositionY());
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
