using System;
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


        public int CoinX = 0;
        public int CoinY = 0;

        public Boolean EnemyTurn = true;

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

            Label timerName = new Label();
            timerName.setPosition(820, 10);
            timerName.setSize(220, 55);
            timerName.setText("Time:");
            game.add(timerName);

            Label pointsName = new Label();
            pointsName.setPosition(820, 70);
            pointsName.setSize(220, 55);
            pointsName.setText("Points:");
            game.add(pointsName);

            Label highscoreName = new Label();
            highscoreName.setPosition(820, 130);
            highscoreName.setSize(220, 55);
            highscoreName.setText("Highscore:");
            game.add(highscoreName);

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

            Button stopButton = new Button();
            stopButton.setPosition(423, 550);
            stopButton.setSize(181, 62);
            stopButton.setColour(255, 255, 255);
            stopButton.setText("Stop");
            game.add(stopButton);

            Wall wall= new Wall();
            wall.setPosition(431, 111);
            wall.setSize(30, 147);
            wall.setColour(255,255, 255);
            gamePanel.add(wall);

            stopButton.Enabled = false;

            stopButton.Click += new System.EventHandler(game.btnStop_Click);

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


            game.makeGame(this);
        }

        private Player createPlayer()

        {

            Player player = new Player();

            player.setSize(50, 50);
            player.setPosition(500, 300);
            player.setSpeed(15);

            return player;


        }

        public void coins()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.setPosition(CoinX, CoinY, gamePanel);
            coin.addToList(game.getCoinList());
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

        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            while (game.getCoinList().Count < 100)
            {
                CoinX = random.Next(20, gamePanel.getWidth() - 40);
                CoinY = random.Next(20, gamePanel.getHeight() - 40);

                if (game.checkCoinPosition(CoinX, CoinY))
                {
                    coins();

                }
            }
            game.LookForCoin(20);
            game.setScore(game.getPoints());

        }

        private void createEnemyBot()
        {
            EnemyBot enemy = new EnemyBot();
            enemy.setSize(50, 50);
            enemy.setSpeed(15);
            enemy.setPosition(0, 0, gamePanel);
        }


        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            moveEnemy();
        }
        
        private void moveEnemy()
        {
            foreach (EnemyBot bot in gamePanel.getEnemyBots())
            {
                if (EnemyTurn)
                {
                    bot.moveRight();
                }
                else
                {
                    bot.moveLeft();
                }
            
                if (bot.getLeft() > 740)
                {
                    EnemyTurn = false;
                }
            
                if (bot.getLeft() < bot.getPositionX())
                {
                    EnemyTurn = true;
                }
                if (bot.colidesWith(gamePanel.getPlayer())){
                    game.stopGame();
                }
            }

                    
        }
        
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            game.getTime();

            if (game.getTime() <= 0)
            {
                game.timeIsUp();
                game.stopGame();   
            }

            if (gamePanel.getEnemyBots().Count == 0)
            {
                createEnemyBot();
            }
        }
    }
}
