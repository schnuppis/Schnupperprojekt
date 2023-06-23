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
        public static int xCoins = 750;
        public static int yCoins = 750;

        public bool enemyBotTurn = true;

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

            Label time = new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("Time:");
            game.add(time);

            Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("Points:");
            game.add(points);

            Label highscore = new Label();
            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("Highscore:");
            game.add(highscore);



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
            game.add(buttonName);

            buttonName.Click += new System.EventHandler(game.btnStart_Click);

            Button nameButton = new Button();
            nameButton.setPosition(423, 550);
            nameButton.setSize(181, 62);
            nameButton.setColour(255, 255, 255);
            nameButton.setText("Stop");
            game.add(nameButton);


            nameButton.Click += new System.EventHandler(game.btnStop_Click);
            nameButton.Enabled = false;

            gamePanel.add(createPlayer());

            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            game.setTime(60);
            game.setTimerGameInterval(1000);


            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            Timer tmrEnemy = game.tmrEnemy;
            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);

            Wall wall = new Wall();
            wall.setPosition(431, 111);
            wall.setSize(30, 147);
            wall.setColour(255, 255, 255);
           
            

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
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();
            }
            if (gamePanel.getEnemyBots().Count == 0)
            {
                createEnemybot();
            }
        }

        private void tmrCoin_Tick(object sender, EventArgs e) {
            while (game.getCoinList().Count < 20) 
            { 
                xCoins = random.Next(20, gamePanel.getWidth() - 40); 
                yCoins = random.Next(20, gamePanel.getHeight() - 40);
                    if (game.checkCoinPosition(xCoins, yCoins))
                    {
                    createCoin();
                    
                    }
            }
            game.LookForCoin(5);
            game.getPoints();
            game.setScore(game.getPoints());
        }

 
        private void createCoin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.setPosition(xCoins, yCoins, gamePanel);
            coin.addToList(game.getCoinList());
        }
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            moveEnemyBot();
        }
        private void createEnemybot()
        {
            EnemyBot bot = new EnemyBot();
            bot.setSize(50, 50);
            bot.setPosition(0, 0, gamePanel);
            bot.setSpeed(10);
        }
        private void moveEnemyBot()
        {
            foreach (EnemyBot enemyBot in gamePanel.getEnemyBots())
            {
                if (enemyBotTurn == true)
                {
                    enemyBot.moveRight();
                } 
                else
                {
                    enemyBot.moveLeft();
                }

                if (enemyBot.getLeft() > 740)
                {
                    enemyBotTurn = false;
                }
                if (enemyBot.getLeft() < enemyBot.getPositionX())
                {
                    enemyBotTurn = true;
                }
                if (enemyBot.colidesWith(gamePanel.getPlayer()))
                {
                    game.stopGame();
                }
            }
        }
    }
}

