using System;
using System.Data;
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

            labelname.setText("Münzenjäger");
            game.add(labelname);

            Label labelnametime = new Label();
            labelnametime.setPosition(820, 10);
            labelnametime.setSize(220, 55);

            labelnametime.setText("Time:");
            game.add(labelnametime);

            Label labelnamepoints = new Label();
            labelnamepoints.setPosition(820, 70);
            labelnamepoints.setSize(220, 55);

            labelnamepoints.setText("Points:");
            game.add(labelnamepoints);

            Label labelnamehighscore = new Label();
            labelnamehighscore.setPosition(820, 130);
            labelnamehighscore.setSize(220, 55);

            labelnamehighscore.setText("Highscore:");
            game.add(labelnamehighscore);

            Text TextTime = new Text();
            game.addTimeText(TextTime);
            TextTime.setPosition(1050, 10);
            TextTime.setSize(94, 44);

            Text TextPoints = new Text();
            game.addPointsText(TextPoints);
            TextPoints.setPosition(1050, 70);
            TextPoints.setSize(94, 44);

            Text TextHighscore = new Text();
            game.addHighscoreText(TextHighscore);
            TextHighscore.setPosition(1050, 130);
            TextHighscore.setSize(94, 44);

            Button Startbutton = new Button();
            game.add(Startbutton);
            Startbutton.setPosition(12, 550);
            Startbutton.setSize(181, 62);
            Startbutton.setColour(0, 255, 0);
            Startbutton.setText("Start");

            Startbutton.Click += new System.EventHandler(game.btnStart_Click);

            Button Stopbutton = new Button();
            game.add(Stopbutton);
            Stopbutton.setPosition(423, 550);
            Stopbutton.setSize(181, 62);
            Stopbutton.setColour(255, 0, 0);
            Stopbutton.setText("Stop");

            Stopbutton.Enabled = false;
            Stopbutton.Click += new System.EventHandler(game.btnStop_Click);

            gamePanel.add(createPlayer());

            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            game.setTime(100);
            game.setTimerGameInterval(1000);
            



            game.makeGame(this);
        }
        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50, 50);
            player.setSpeed(8);
            player.setPosition(xPlayer, yPlayer);
            return player;

            

        }
        private void movePlayer(object sender, KeyEventArgs key) { 
       
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
                
                player.getPositionX();  
                player.getPositionY();  
            }
            player.setPosition(player.getPositionX(), player.getPositionY());
        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();

            }
        }    
    }
}
