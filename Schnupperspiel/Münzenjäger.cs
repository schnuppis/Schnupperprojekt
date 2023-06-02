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
        Boolean enemyRight = true;


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
            labelName.setText("Münzenjäger:");
            game.add(labelName);

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);
            labelTime.setText("Time:");
            game.add(labelTime);

            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220, 55)
; labelPoints.setText("Points:");
            game.add(labelPoints);

            Label labelHighscore = new Label();
            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220, 55);
            labelHighscore.setText("Highscore:");
            game.add(labelHighscore);

            Text textName = new Text();

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
            textHighscore.setSize(94, 44);
            game.addHighscoreText(textHighscore);

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

            game.setTime(30);
            game.setTimerGameInterval(1000);

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);
            Timer tmrEnemy = game.tmrEnemy;
            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);

            Wall hinderniss = new Wall();
            hinderniss.setPosition(431, 111);
            hinderniss.setSize(30, 147);
            hinderniss.setColour(255, 255, 255);
            game.add(hinderniss);




















            game.makeGame(this);
        }
        private Player createPlayer()
        {
            Player player = new Player();
            player.setPosition(xPlayer, yPlayer);
            player.setSize(50, 50);
            player.setSpeed(4);

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
            if (game.getTime() == 0) { game.timeIsUp(); game.stopGame(); }
            if (game.getTime() == 25) { createBot(); }
        }
        int xcoin = 0;
        int ycoin;
        private void greateCoins()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.addToList(game.getCoinList());
            coin.setPosition(xcoin, ycoin, gamePanel);


        }
        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            while (game.getCoinList().Count < 20)
            {
                xcoin = random.Next(20, gamePanel.getWidth() - 40);
                ycoin = random.Next(20, gamePanel.getHeight() - 40);

                greateCoins();
            }
            game.LookForCoin(10);
            int i = game.getPoints();
            game.setScore(i);

        }
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            foreach (EnemyBot bot in gamePanel.getEnemyBots())
            {
                if (enemyRight == true)
                { bot.moveRight(); }
                else {  bot.moveLeft(); }
                if (bot.getLeft() > 800)
                {
                    enemyRight = false;
                }
                if (bot.getLeft() < bot.getPositionX())
                {
                    enemyRight = true; 
                }
                if (gamePanel.getPlayer().colidesWith(bot))
                {
                    game.stopGame();
                }

                
            } 
        }
        private EnemyBot createBot()
        {
            EnemyBot bot = new EnemyBot();
            bot.setSize(50, 50);
            bot.setPosition(100, 100, gamePanel);
            bot.setSpeed(13);
            return bot;
        }
    }
}
          
