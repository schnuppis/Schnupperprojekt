using System;
using System.Drawing.Text;
using System.Threading.Tasks;
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
        public static int xCoin = 0;
        public static int yCoin = 0;
        public static int xEnemy = 0;
        public static int yEnemy = 0;
        public Panel gamePanel;
        public Wall wall;
        public int enemycount = 10;

        public frmGame()
        {
            InitializeComponent();
        }

        private Player createPlayer()
        {

            Player player = new Player();
            player.setSize(50,50);
            player.setSpeed(4);
            player.setPosition(xPlayer, yPlayer);
            return player;

        }

        


        private void loadGame(object sender, EventArgs e)
        {
            
            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);


            Label labelname = new Label();
            labelname.setPosition(820, 480);
            labelname.setSize(250, 55);
            labelname.setText("Münzenjäger:");
            game.add(labelname);

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


            Text TimeText = new Text();
            TimeText.setPosition(1050, 10);
            TimeText.setSize(94, 44);
            game.addTimeText(TimeText);

            Text PointsText = new Text();
            PointsText.setPosition(1050, 70);
            PointsText.setSize(94, 44);
            game.addPointsText(PointsText);

            Text HighscoreText = new Text();
            HighscoreText.setPosition(1050, 130);
            HighscoreText.setSize(94, 44);
            game.addHighscoreText(HighscoreText);

            
            Button startButton = new Button();
            startButton.setPosition(12, 550);
            startButton.setSize(181, 62);
            startButton.setColour(255,255,255);
            startButton.setText("Start");
            startButton.Click += new System.EventHandler(game.btnStart_Click);
            game.add(startButton);

            Button stopButton = new Button();
            stopButton.setPosition(423, 550);
            stopButton.setSize(181, 62);
            stopButton.setColour(255, 255, 255);
            stopButton.setText("Stop");
            stopButton.Enabled = false;
            stopButton.Click += new System.EventHandler(game.btnStop_Click);
            game.add(stopButton);

            /*Button einfachbutton = new Button();
            einfachbutton.setPosition(600, 550);
            einfachbutton.setSize(181, 62);
            einfachbutton.setColour(255, 255, 255);
            einfachbutton.setText("Einfach");
            game.add(einfachbutton);
            einfachbutton.Click += new System.EventHandler(einfach);

            Button normalbutton = new Button();
            normalbutton.setPosition(800, 550);
            normalbutton.setSize(181, 62);
            normalbutton.setColour(255, 255, 255);
            normalbutton.setText("Normal");
            game.add(normalbutton);
            normalbutton.Click += new System.EventHandler(normal);

            Button schwierigbutton = new Button();
            schwierigbutton.setPosition(1000, 550);
            schwierigbutton.setSize(181, 62);
            schwierigbutton.setColour(255, 255, 255);
            schwierigbutton.setText("Schwierig");
            game.add(schwierigbutton);
            schwierigbutton.Click += new System.EventHandler(schwierig);*/

            

            Wall wall = new Wall();

            wall.setPosition(431, 111);
            wall.setSize(30, 147);
            wall.setColour(255,255,255);
            gamePanel.add(wall);
            

            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);
            KeyDown += new KeyEventHandler(Schwierigkeit);
            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            
            game.setTime(120);
            game.setTimerGameInterval(1000);

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.Coin);
            
            Timer tmrEnemy = game.tmrEnemy;
            tmrEnemy.Tick += new System.EventHandler(this.Enemymovement);
            


            game.makeGame(this);
        }
        private void movePlayer(object sender, KeyEventArgs key)
        {
            

            Player player = gamePanel.getPlayer();
            if (key.KeyCode == Keys.D && game.checkPanelRight()&& !game.checkWallRight(player, player.getSpeed()))
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
            player.setPosition(player.getPositionX(), player.getPositionY());

        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {

            if(gamePanel.getEnemys().Count < enemycount)
            {
                xEnemy = random.Next(20, gamePanel.getWidth() - 40);
                yEnemy = random.Next(20, gamePanel.getHeight() - 40);
                CreateEnemy();
            }


            if(game.getTime()  < 0)
            {

                game.timeIsUp();
                game.stopGame();
                
                Highscore();
                
            }

        }

        private void Coins()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.addToList(game.getCoinList());
            coin.setPosition(xCoin, yCoin, gamePanel);


        }
        private void Coin(object sender, EventArgs e)
        {
            while(game.getCoinList().Count < 100)
            {
                  xCoin = random.Next(20, gamePanel.getWidth()-40);
                  yCoin = random.Next(20, gamePanel.getHeight()-40);

                if (game.checkCoinPosition(xCoin, yCoin) )
                {
                    Coins();
                }
                
            }
            game.LookForCoin(10);
            game.setScore(game.getPoints());
        }
        private void Highscore()
        {

            if (game.getHighscore() < game.getPoints())
            {
                game.setHighscore(game.getPoints());
            }
        }


        
        private void CreateEnemy()
        {
            
            Enemy enemy = new Enemy();
            enemy.setSize(50, 50);
            enemy.setSpeed(5);
            enemy.setPosition(xEnemy, yEnemy, gamePanel);
            

        }
        private void Enemymovement(object sender, EventArgs e)
        {   
            
            Player player = gamePanel.getPlayer();
            

            foreach (Enemy enemy in gamePanel.getEnemys())
            {
                if (enemy.getTop() < player.getTop() && !game.checkWallTop(enemy, enemy.getSpeed()))
                {
                    enemy.moveUp();
                }
                if (enemy.getLeft() < player.getLeft() && !game.checkWallRight(enemy, enemy.getSpeed()))
                {
                    enemy.moveRight();
                }
                if (!(enemy.getLeft() < player.getLeft() && !game.checkWallLeft(enemy, enemy.getSpeed())))
                {
                    enemy.moveLeft();
                }
                if(!(enemy.getTop() < player.getTop() && !game.checkWallBottom(enemy, enemy.getSpeed())))
                {
                    enemy.moveDown();
                }



                if (enemy.colidesWith(player))
                {
                    game.stopGame();
                }
            }
            
        }

        private void Schwierigkeit(object sender, KeyEventArgs key)
        {
            if(key.KeyCode == Keys.T)
            {
                einfach();
            }
            if (key.KeyCode == Keys.Z)
            {
                normal();
            }
            if (key.KeyCode == Keys.U)
            {
                schwierig();
            }
        }

            private void einfach()
        {
            Player player = gamePanel.getPlayer();
            player.setSpeed(6);
            enemycount = 4;
            foreach (Enemy enemy in gamePanel.getEnemys())
            {
                enemy.setSpeed(4);

            }
        }
        private void normal()
        {
            Player player = gamePanel.getPlayer();
            player.setSpeed(5);
            enemycount = 5;
            foreach (Enemy enemy in gamePanel.getEnemys())
            {
                enemy.setSpeed(5);

            }
        }
        private void schwierig()
        {
            Player player = gamePanel.getPlayer();
            player.setSpeed(4);
            enemycount = 6;
            foreach (Enemy enemy in gamePanel.getEnemys())
            {
                enemy.setSpeed(6);

            }
        }
    }
}
