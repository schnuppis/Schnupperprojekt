using System;
using System.Windows.Forms;

// !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

namespace Schnupperspiel
{
    public partial class frmGame : Form
    {
        public Game game = new Game();
        private Random random = new Random();

        private int xCoin = 0;
        /*1*/
        private int yCoin = 0;

        public static int xPlayer = 750;
        /*0 / 2*/
        public static int yPlayer = 450;
        private Boolean enemyBotTurn = true;
        private Boolean speedAdded = false;

        public Panel gamePanel;

        public frmGame()
        {
            InitializeComponent();
        }
        //8

        private void loadGame(object sender, EventArgs e)
        {
            Timer tmrGame = game.tmrGame;

            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            Timer tmrCoin = game.tmrCoin;

            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);
            Timer tmrEnemy = game.tmrEnemy;

            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);
            Timer tmrSpeed = game.tmrSpeed;

            tmrSpeed.Tick += new System.EventHandler(this.tmrSpeed_Tick);
            game.setTime(60);
            game.setTimerGameInterval(1000);
            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800,500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

            Label timeLbl = new Label();
            timeLbl.setPosition(820, 10);
            timeLbl.setSize(220, 55);
            timeLbl.setText("Time:");
            game.add(timeLbl);
                
            //Punktelabel
            Label pointsLbl = new Label();
            pointsLbl.setPosition(820, 70);
            pointsLbl.setSize(220, 55);
            pointsLbl.setText("Points:");
            game.add(pointsLbl);

            //Höchstpunktezahllabel
            Label highscoreLbl = new Label();
            highscoreLbl.setPosition(820, 130);
            highscoreLbl.setSize(220, 55);
            highscoreLbl.setText("Highscore:");
            game.add(highscoreLbl);

            //Namelabel
            Label nameLbl = new Label();
            nameLbl.setPosition(820, 480);
            nameLbl.setSize(250, 55);
            nameLbl.setText("Münzenjäger");
            game.add(nameLbl);

            Text timeText = new Text();
            timeText.setPosition(1050, 10);
            timeText.setSize(94, 44);
            game.addTimeText(timeText);

            //Punktetext
            Text pointsText = new Text();
            pointsText.setPosition(1050, 70);
            pointsText.setSize(94, 44);
            game.addPointsText(pointsText);

            //Höchstpunktezahltext
            Text highscoreText = new Text();
            highscoreText.setPosition(1050, 130);
            highscoreText.setSize(94, 44);
            game.addHighscoreText(highscoreText);

            Button playBtn = new Button();
            playBtn.setColour(255, 255, 255);
            playBtn.setPosition(12, 550);
            playBtn.setSize(181, 62);
            playBtn.setText("Start");
            playBtn.Click += new System.EventHandler(game.btnStart_Click);
            game.add(playBtn);

            Button pauseBtn = new Button();
            pauseBtn.setPosition(212, 550);
            pauseBtn.setSize(181, 62);
            pauseBtn.setColour(255, 255, 255);
            pauseBtn.setText("Stop");
            pauseBtn.Click += new System.EventHandler(game.btnStop_Click);
            pauseBtn.Enabled = false;
            game.add(pauseBtn);

            Wall wall = new Wall();
            wall.setPosition(431, 111);
            wall.setSize(30, 147);
            wall.setColour(255, 255, 255);
            gamePanel.add(wall);

            gamePanel.add(createPlayer());

            KeyDown += new KeyEventHandler(movePlayer);

            game.makeGame(this);
        }
        //7
        private Player createPlayer()
        {
            Player player = new Player();
            player.setPosition(xPlayer, yPlayer);
            player.setSize(50, 50);
            player.setSpeed(4);
            return player;
        }
        //7

        private void movePlayer(object sender, KeyEventArgs key)
        {
            Player player = gamePanel.getPlayer();
            if (key.KeyCode == Keys.D && game.checkPanelRight() && !game.checkWallRight(player, player.getSpeed()))
            {
                player.moveRight();
            }
            if (key.KeyCode == Keys.A && game.checkPanelLeft() && !game.checkWallLeft(player, player.getSpeed()))
            {
                player.moveLeft();
            }
            if (key.KeyCode == Keys.W && game.checkPanelTop() && !game.checkWallTop(player, player.getSpeed()))
            {
                player.moveUp();
            }
            if (key.KeyCode == Keys.S && game.checkPanelBottom() && !game.checkWallBottom(player, player.getSpeed()))
            {
                player.moveDown();
            }
            if (key.KeyCode == Keys.M && !speedAdded)
            {
                btnSpeed_Click();
                speedAdded = true;
            }


            player.setPosition(player.getPositionX(), player.getPositionY());
        }
        //6
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if (game.getTime() <= 0)
            {
                game.timeIsUp();
                game.stopGame();
                showHighscore();

            }
            if (game.getTime() > 0)
            {
                if (gamePanel.getEnemys().Count == 0)
                {
                    createEnemy();
                    
                }
                if (gamePanel.getEnemyBots().Count == 0)
                {
                    createEnemyBot();
                }
            }
        }
        //3
        private void createEnemyBot()
        {
            EnemyBot bot = new EnemyBot();
            bot.setPosition(0, 400, gamePanel);
            bot.setSize(50, 50);
            bot.setSpeed(5);
        }
        //1
        private void createEnemy()
        {
            Enemy enemy = new Enemy();
            enemy.setPosition(5, 5, gamePanel);
            enemy.setSize(50, 50);
            enemy.setSpeed(3);
        }
        //4
        private void showHighscore()
        {
            if (game.getPoints() > game.getHighscore())
            {
                game.setHighscore(game.getPoints());
            }
        }

        //5
        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            game.setScore(game.getPoints());
            game.LookForCoin(10);

            while (game.getCoinList().Count < 10)
            {
                xCoin = random.Next(20, gamePanel.getWidth() - 40);
                yCoin = random.Next(20, gamePanel.getHeight() - 40);
                if (game.checkCoinPosition(xCoin, yCoin))
                {
                    createCoin();
                }
            }
        }

        //5
        private void createCoin()
        {
            Coin coin = new Coin();
            coin.setPosition(xCoin, yCoin, gamePanel);

            coin.setSize(20, 20);
            coin.addToList(game.getCoinList());
        }




        //3
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            moveEnemyBot();
            moveEnemy();
        }
        //1
        private void moveEnemy()
        {
            Player player = gamePanel.getPlayer();
            foreach (Enemy enemy in gamePanel.getEnemys())
            {
                if (!game.checkWallBottom(enemy, enemy.getSpeed()) && enemy.getTop() < player.getTop())
                {
                    enemy.moveUp();
                }
                if (!game.checkWallTop(enemy, enemy.getSpeed()) && enemy.getTop() > player.getTop())
                {
                    enemy.moveDown();
                }
                if (!game.checkWallRight(enemy, enemy.getSpeed()) && enemy.getLeft() < player.getLeft())
                {
                    enemy.moveRight();
                }
                if (!game.checkWallLeft(enemy, enemy.getSpeed()) && enemy.getLeft() > player.getLeft())
                {
                    enemy.moveLeft();
                }
                if (enemy.colidesWith(player))
                {
                    game.stopGame();
                }
            }
        }
        //3
        private void moveEnemyBot()
        {
            foreach (EnemyBot bot in gamePanel.getEnemyBots())
            {
                if (enemyBotTurn == true)
                {
                    bot.moveRight();
                }
                else
                {
                    bot.moveLeft();
                }

                if (bot.getLeft() > 800)
                {
                    enemyBotTurn = false;
                }
                if (bot.getLeft() < bot.getPositionX())
                {
                    enemyBotTurn = true;
                }
                if (bot.colidesWith(gamePanel.getPlayer()))
                {
                    game.stopGame();
                }
            }

        }
        //2
        private void btnSpeed_Click()
        {
            game.setAddedPlayerSpeed(5);

            game.setTimerSpeedInterval(1000);

            game.setSpeedTime(5);

            game.setSpeedDelay(10);
            game.speed();
        }

        //2
        private void tmrSpeed_Tick(object sender, EventArgs e)
        {
            int speed;
            int time = game.getSpeedTime();
            if (time == 0)
            {
                Player player = gamePanel.getPlayer();
                speed = player.getSpeed();
                speed -= game.getAddedPlayerSpeed();
                player.setSpeed(speed);
            }
            if (time == game.getSpeedDelay())
            {
                game.tmrSpeed.Enabled = false;
                speedAdded= false;
            }
        }
    }
}
