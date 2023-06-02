using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Drawing;

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
        int CoinX = 0;
        int CoinY = 0;

        Boolean MoveBot = true;
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


            Label labelNametime = new Label();
            labelNametime.setPosition(820, 10);
            labelNametime.setSize(220, 55);

            labelNametime.setText("Time:");
            game.add(labelNametime);

            Label labelNamepoints = new Label();
            labelNamepoints.setPosition(820, 70);
            labelNamepoints.setSize(220, 55);

            labelNamepoints.setText("Points:");
            game.add(labelNamepoints);

            Label labelNamehighscore = new Label();
            labelNamehighscore.setPosition(820, 130);
            labelNamehighscore.setSize(250, 55);

            labelNamehighscore.setText("Highscore:");
            game.add(labelNamehighscore);

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

            Button buttonS = new Button();
            game.add(buttonS);
            buttonS.setPosition(12, 550);
            buttonS.setSize(181, 62);
            buttonS.setColour(176, 244, 230);
            buttonS.setText("Start");

            buttonS.Click += new System.EventHandler(game.btnStart_Click);

            Button buttonP = new Button();
            game.add(buttonP);
            buttonP.setPosition(423, 550);
            buttonP.setSize(181, 62);
            buttonP.setColour(95, 158, 160);
            buttonP.setText("Stop");

            buttonP.Enabled = false;
            buttonP.Click += new System.EventHandler(game.btnStop_Click);

            gamePanel.add(createPlayer());

            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            game.setTime(100);
            game.setTimerGameInterval(1000);

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            Timer tmrEnemy = game.tmrEnemy;
            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);

            Wall WallS = new Wall();
            gamePanel.add(WallS);
            WallS.setPosition(431, 111);
            WallS.setSize(30, 147);
            WallS.setColour(95, 158, 160);

            Wall WallB = new Wall();
            gamePanel.add(WallB);
            WallB.setPosition(111, 431);
            WallB.setSize(147, 30);
            WallB.setColour(176, 244, 230);

            game.makeGame(this);
        }

        private void createEnemy()
        {
            EnemyBot Enemy = new EnemyBot();
            Enemy.setSize(50, 50);
            Enemy.setSpeed(7);
            Enemy.setPosition(random.Next(1, 780), random.Next(1, 380), gamePanel);
            Color sadf = Color.FromArgb(255, 255, 255);
            Enemy.setColor(sadf);


        }
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            moveEnemy();

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
            if (key.KeyCode == Keys.D && game.checkPanelRight() && !game.checkWallRight(player, 4))
            {
                player.moveRight();
            }
            if (key.KeyCode == Keys.A && game.checkPanelLeft() && !game.checkWallLeft(player, 4))
            {
                player.moveLeft();
            }
            if (key.KeyCode == Keys.W && game.checkPanelTop() && !game.checkWallTop(player, 4))
            {
                player.moveUp();
            }
            if (key.KeyCode == Keys.S && game.checkPanelBottom() && !game.checkWallBottom(player, 4))
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

            if (gamePanel.getEnemyBots().Count == 0)
            {
                createEnemy();
            }

        }

        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            while (game.getCoinList().Count < 20)
            {
                CoinX = random.Next(20, gamePanel.getWidth() - 40);
                CoinY = random.Next(20, gamePanel.getHeight() - 40);
                if (game.checkCoinPosition(CoinX, CoinY))
                {
                    createCoin();

                }



            }

            game.LookForCoin(10);
            game.setScore(game.getPoints());


        }


        public void createCoin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);

            coin.setPosition(CoinX, CoinY, gamePanel);
            coin.addToList(game.getCoinList());


        }

        private void moveEnemy()
        {
            foreach (EnemyBot bot in gamePanel.getEnemyBots())
            {
                if (MoveBot == true)
                {
                    bot.moveRight();
                }
                else
                {
                    bot.moveLeft();
                }
                if (bot.getLeft() > 780)
                {
                    MoveBot = false;
                }
                else if (bot.getLeft() < 21)
                {
                    MoveBot = true;
                }
                if (bot.colidesWith(gamePanel.getPlayer()))
                {
                    game.stopGame();
                }
            }






        }
    }
}
