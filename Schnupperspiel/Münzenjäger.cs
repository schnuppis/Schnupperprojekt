using System;
using System.Data;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Xml;

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
        private int xCoin = 0;
        private int yCoin = 0;
        private void loadGame(object sender, EventArgs e)
        {

            game.setFormColour(0, 0, 0);


            gamePanel = new Panel();
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);
            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger");
            game.add(labelName);
            Label labeltime = new Label();
            labeltime.setPosition(820, 10);
            labeltime.setSize(220, 55);
            labeltime.setText("Time");
            game.add(labeltime);
            Label labelpoints = new Label();
            labelpoints.setPosition(820, 70);
            labelpoints.setSize(220, 55);
            labelpoints.setText("Points");
            game.add(labelpoints);
            Label labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Highscore");
            game.add(labelhighscore);
            
            Text Timetext = new Text();
            Timetext.setPosition(1050, 10);
            Timetext.setSize(94, 44);
            game.addTimeText(Timetext);
            Text PointsText = new Text();
            PointsText.setPosition(1050, 70);
            PointsText.setSize(94, 44);
            game.addPointsText(PointsText);
            Text HighscoreText = new Text();
            HighscoreText.setPosition(1050, 130);
            HighscoreText.setSize(94, 44);
            game.addHighscoreText(HighscoreText);
            Button buttonName = new Button();
            buttonName.setPosition(12, 550);
            buttonName.setSize(181, 62);
            buttonName.setColour(255, 255, 255);
            buttonName.setText("Start");
            buttonName.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttonName);
            Button buttonStop = new Button();
            buttonStop.setPosition(423, 550);
            buttonStop.setSize(181, 62);
            buttonStop.setColour(255, 255, 255);
            buttonStop.setText("Stop");
            buttonStop.Enabled = false;
            buttonStop.Click += new System.EventHandler(game.btnStop_Click);
            game.add(buttonStop);
            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);
            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            game.setTime(60);
            game.setTimerGameInterval(1000);
            
            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.coinsTimer);


























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
            { player.moveRight();
                
            }
            if (key.KeyCode == Keys.A && game.checkPanelLeft())
            { player.moveLeft();
                
            }
            if (key.KeyCode == Keys.W && game.checkPanelTop())
            { player.moveUp();
                
            }
            if (key.KeyCode == Keys.S && game.checkPanelBottom())
            { 
                player.moveDown();
            }
            player.setPosition(player.getPositionX(), player.getPositionY()); 
        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (game.getTime() == 0)
            {
                game.Update();
                game.stopGame();
                if (game.getPoints() > game.getHighscore())
                {
                    game.setHighscore(game.getPoints());
                }
               
                            
            }
        }

        private void createCoins()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            
            coin.setPosition(xCoin, yCoin, gamePanel);
            coin.addToList(game.getCoinList());
        }
        private void coinsTimer(object sender, EventArgs e)
            
        {
            while(game.getCoinList().Count<20)
            {
                xCoin = random.Next(20, gamePanel.getWidth() - 40);
                yCoin = random.Next(20, gamePanel.getHeight() - 40);
                if (game.checkCoinPosition(xCoin, yCoin))
                {
                    createCoins();
                }
            }
            game.LookForCoin(10);
            
            game.setScore(game.getPoints());
            

            
                    


                


              

        }
    }
}
