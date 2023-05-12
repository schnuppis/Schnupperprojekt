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

        public int coinY = 30;
        public int coinX = 30;
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

            Label labelName2 = new Label();
            labelName2.setPosition(820, 10);
            labelName2.setSize(220, 55);
            labelName2.setText("Time:");
            game.add(labelName2);

            Label labelName3 = new Label();
            labelName3.setPosition(820, 70);
            labelName3.setSize(220, 55);
            labelName3.setText("Points:");
            game.add(labelName3);

            Label labelName4 = new Label();
            labelName4.setPosition(820, 130);
            labelName4.setSize(220, 55);
            labelName4.setText("Highscore");
            game.add(labelName4);

            Text textName1 = new Text();
            textName1.setPosition(1050, 10);
            textName1.setSize(94, 44);
            game.addTimeText(textName1);

            Text textName2 = new Text();
            textName2.setPosition(1050, 70);
            textName2.setSize(94, 44);
            game.addPointsText(textName2);

            Text textName3 = new Text();
            textName3.setPosition(1050, 130);
            textName3.setSize(94, 44);
            game.addHighscoreText(textName3);

            Button buttonName1 = new Button();
            buttonName1.setPosition(12, 550);
            buttonName1.setSize(181, 62);
            buttonName1.setColour(255, 255, 255);
            buttonName1.setText("Start");
            buttonName1.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttonName1);

            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(moveplayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            game.setTime(30);
            game.setTimerGameInterval(1000);
            

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            Timer tmrBot = game.tmrEnemy;
            tmrBot.Tick += new System.EventHandler(this.tmrBot_Tick);


            game.makeGame(this);
        }
        private void moveplayer(object sender, KeyEventArgs key)
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
            player.setPosition(player.getPositionX(),player.getPositionY());
        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();
            }
        }
        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            game.setScore(game.getPoints());
            game.LookForCoin(10);
            while (50 > game.getCoinList().Count)
            {
                CreatCoins();
            }
          

        }

        private void tmrBot_Tick(object sender, EventArgs e)
        {
        Player player = gamePanel.getPlayer(); 
        foreach (EnemyBot Bot in gamePanel.getEnemyBots())
            {
                if (player.getTop() > Bot.getTop())
                {
                    Bot.moveUp();   
                }
                if(player.getTop() < Bot.getTop())
                {
                    Bot.moveDown();
                }
                if(player.getLeft() > Bot.getLeft())
                {
                    Bot.moveRight();
                }
                if(player.getLeft() < Bot.getLeft())
                {
                    Bot.moveLeft();
                }
                if (Bot.colidesWith(player))
                {
                    game.stopGame();
                }
            }  
        }
        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50,50);
            player.setSpeed(15);
            player.setPosition(xPlayer,yPlayer);
            CreatBot(); 
            return player;
            

            

        }

        public void CreatCoins()
        {
            Coin coin = new Coin(); 
            coin.setSize(20,20);
            coin.addToList(game.getCoinList());
            coinX = random.Next(20, gamePanel.getWidth() - 40);
            coinY = random.Next(20, gamePanel.getHeight() - 40);
            coin.setPosition(coinX,coinY, gamePanel);
        } 
        public EnemyBot CreatBot()
        {
            EnemyBot bot = new EnemyBot(); 
            bot.setSize(50,50);
            bot.setSpeed(7);
            bot.setPosition(100, 100, gamePanel);
            return bot;
        }

    }
}

