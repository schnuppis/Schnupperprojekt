using System;
using System.Deployment.Application;
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
        public static int xCoin = 750;
        public static int yCoin = 450;
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
            labelScoreboard.setSize(250,55);
            labelScoreboard.setText("Scoreboard:");
            game.add(labelScoreboard);

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);
            labelTime.setText("Time:");
            game.add(labelTime);
            
            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220, 55);
            labelPoints.setText("Points:");
            game.add(labelPoints);

            Label labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Highscore:");
            game.add(labelhighscore);
            Text labelTime2 = new Text();
            labelTime2.setPosition(820, 10);
            labelTime2.setSize(220, 55);
            // labelTime2.setText("Münzenjäger.");
            game.add(labelTime2);
            Label TextPoints = new Label();

            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220, 55);
            
            game.add(labelPoints);

            Label Labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Highscore:");
            game.add(labelhighscore);

           

            Text textTime = new Text();

            Text Texttime = new Text();
            Texttime.setPosition(1050, 10);
            Texttime.setSize(94, 44);
            game.addTimeText(Texttime); 
            
            Text Textpoints = new Text();
            Textpoints.setPosition(1050, 70);
            Textpoints.setSize(94, 44);
            game.addPointsText(Textpoints); 
            
            Text Texthighscore = new Text();
            Texthighscore.setPosition(1050, 130);
            Texthighscore.setSize(94, 44);
            game.addHighscoreText(Texthighscore);

         

            Button buttonstart = new Button();
            buttonstart.setPosition(12, 550);
            buttonstart.setSize(181, 62);
            buttonstart.setColour(255, 255, 255);
            buttonstart.setText("Start");
            game.add(buttonstart);
           
            buttonstart.Click += new System.EventHandler(game.btnStart_Click);
            Button buttonstop = new Button();
            buttonstop.setPosition (480, 550);
            buttonstop.setSize(181, 62);
            buttonstop.setColour(255,255,255);
            buttonstop.setText("Stop");
            buttonstop.Enabled = false;
            buttonstop.Click += new System.EventHandler(game.btnStop_Click);
            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);
            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            game.setTime(100);
            game.setTimerGameInterval(1000);
            game.add(buttonstop);
            

            game.makeGame(this);
        }
       private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50,50);
            player.setSpeed(4);
            player.setPosition(50, 50);       
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
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (game.getTime() == 0) { 
                game.timeIsUp();
                game.stopGame(); 
            }
        }private void Spawner()
        {
            Coin coin = new Coin();
            coin.addToList(game.getCoinList());
            coin.setSize(20, 20);
        }
    }
}
