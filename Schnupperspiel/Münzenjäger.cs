using System;
using System.Drawing.Text;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
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
        public int CoinX;
        public int CoinY;

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

            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger");
            game.add(labelName);

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

            Label labelHighscore = new Label();
            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220, 55);
            labelHighscore.setText("Highscore:");
            game.add(labelHighscore);

            Text textTime = new Text();
            textTime.setPosition(1050, 20);
            textTime.setSize(94, 44);
            game.addTimeText(textTime);

            Text textPoints = new Text();
            textPoints.setPosition(1050, 70);
            textPoints.setSize(94, 44);
            game.addPointsText(textPoints);

            Text textHighscore = new Text();
            textHighscore.setPosition(1050, 130);
            textHighscore.setSize(94, 44);
            game.addHighscoreText(textHighscore);

            Button buttonStart = new Button();
            buttonStart.setPosition(12, 550);
            buttonStart.setSize(181, 62);
            buttonStart.setColour(255, 255, 255);
            buttonStart.setText("Start");
            game.add(buttonStart);

            buttonStart.Click += new System.EventHandler(game.btnStart_Click);

            Button buttonStopp = new Button();
            buttonStopp.setPosition(423, 550);
            buttonStopp.setSize(181, 62);
            buttonStopp.setColour(255, 255, 255);
            buttonStopp.setText("Stopp");
            game.add(buttonStopp);

            buttonStopp.Enabled = false;
            buttonStopp.Click += new System.EventHandler(game.btnStop_Click);

            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            game.setTime(60);
            game.setTimerGameInterval(1000);

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            

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
            if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();
                if (game.getPoints() > game.getHighscore()) 
                {
                    game.setHighscore(game.getPoints());
                }
            
                        
                        }
        }

        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            game.LookForCoin(10);
            game.setScore(game.getPoints());
            while (game.getCoinList().Count < 40)
            {
                CoinX = random.Next(20, gamePanel.getWidth() - 40);
                CoinY = random.Next(20, gamePanel.getWidth() - 40);
                if (game.checkCoinPosition(CoinX, CoinY))
                {
                    coin();
                }
               
            }
        }
        private void coin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.setPosition(CoinX, CoinY, gamePanel);
            coin.addToList(game.getCoinList());
        }
    }
}
