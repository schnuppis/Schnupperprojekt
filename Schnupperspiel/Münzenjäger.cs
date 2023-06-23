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

        private Boolean enemyTurn = true;
        
        public int coinX = 0;
        public int coinY = 0;
        
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

            Label timeName = new Label();
            timeName.setPosition(820, 10);
            timeName.setSize(220, 55);
            timeName.setText("Time:");
            game.add(timeName);

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


            Text textTimer = new Text();
            textTimer.setPosition(1050, 10);
            textTimer.setSize(94, 44);
            game.addTimeText(textTimer);

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
            buttonStart.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttonStart);

            Button buttonEnd = new Button();
            buttonEnd.setPosition(423, 550);
            buttonEnd.setSize(181, 62);
            buttonEnd.setColour(255, 255, 255);
            buttonEnd.setText("End");
            buttonEnd.Enabled = false;
            buttonEnd.Click += new System.EventHandler(game.btnStop_Click);
            game.add(buttonEnd);

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
            }

            if (gamePanel.getEnemyBots().Count == 0)
            {
                createEnemyBot();
            }


        }

        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            while (game.getCoinList().Count<50)
            {
                coinX = random.Next(20, gamePanel.getWidth()-40);
                coinY = random.Next(20, gamePanel.getHeight()-40);

                if (game.checkCoinPosition(coinX, coinY))
                {
                    coins();
                }
            }

            game.LookForCoin(10);
            game.setScore(game.getPoints());
        }
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            moveEnemy();
        }

        private void createEnemyBot()
        {
            EnemyBot enemy = new EnemyBot();
            enemy.setSize(50, 50);
            enemy.setSpeed(8);
            enemy.setPosition(0, 0, gamePanel);
        }

        private void moveEnemy()
        {
            foreach(EnemyBot bot in gamePanel.getEnemyBots())
            {
                if (enemyTurn)
                {
                    bot.moveRight(); 
                }
                else 
                { 
                    bot.moveLeft();
                }
                
                if (bot.getLeft() > 750)
                { 
                    enemyTurn = false; 
                }
                
                if(bot.getLeft() < bot.getPositionX())
                {
                    enemyTurn = true;
                }

                if (bot.colidesWith(gamePanel.getPlayer()))
                {
                    game.stopGame();
                }

            }



        }
        public void coins()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.setPosition(coinX, coinY, gamePanel);
            coin.addToList(game.getCoinList());
        }
        
    
    }
}
