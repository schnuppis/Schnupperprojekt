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
        public static int xCoin = 450;
        public static int yCoin = 450;
        public Panel gamePanel;

        public frmGame()
        {
            InitializeComponent();
        }
        private void loadGame(object sender, EventArgs e)
        {
            
            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800,500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

            Label labelName= new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger:");
            game.add(labelName);
            //Time
            Label time= new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("Time:");
            game.add(time);
            //Points
            Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("Points:");
            game.add(points);
            //highscore
            Label highscore = new Label();
            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("Highscore:");
            game.add(highscore);

            Text outtime = new Text();
            outtime.setPosition(1050, 10);
            outtime.setSize(94, 44);
            game.addTimeText(outtime);

            Text outpoints = new Text();
            outpoints.setPosition(1050, 70);
            outpoints.setSize(94, 44);
            game.addPointsText(outpoints);

            Text outhigh = new Text();
            outhigh.setPosition(1050, 130);
            outhigh.setSize(94, 44);
            game.addHighscoreText(outhigh);
           
            Button button = new Button();
            button.setPosition(12, 550);
            button.setSize(181, 62);
            button.setColour(255, 255, 255);
            button.setText("Start");
            button.Click += new System.EventHandler(game.btnStart_Click);
            game.add(button);

            Button stop = new Button();
            stop.setPosition(423, 550);
            stop.setSize(181, 62);
            stop.setColour(255, 255, 255);
            stop.setText("Stop");
            stop.Click += new System.EventHandler(game.btnStop_Click);
            stop.Enabled = false;
            game.add(stop);

            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            game.setTime(10);
            game.setTimerGameInterval(1000);

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.timerCoin_Tick);

            Timer tmrEnemy = game.tmrEnemy;
            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);

            








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
            if (game.getTime() <= 0) { game.timeIsUp();
                game.stopGame(); }
            if (game.getTime() == 10)
            {
                createEnemy();
            }
            
                
        }
        private void createCoin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.addToList(game.getCoinList());
            coin.setPosition(xCoin, yCoin, gamePanel);
            

        }
        private void timerCoin_Tick(object sender, EventArgs e)
        {
            while (game.getCoinList().Count < 10)
            {
                

               xCoin = random.Next(20, gamePanel.getWidth() - 40);
               yCoin = random.Next(20, gamePanel.getHeight() - 40);
                game.checkCoinPosition(xCoin, yCoin);
                if (game.checkCoinPosition(xCoin, yCoin))
                {
                    createCoin();
                }
               
            }
            game.LookForCoin(1);
            game.setScore(game.getPoints());
        }
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            
            foreach (EnemyBot bot in gamePanel.getEnemyBots())
            {

            }
        }
        private void createEnemy()
        {
            Enemy enemy = new Enemy();
            enemy.setSize(50, 50);
            enemy.setSpeed(4);
            enemy.setPosition(0,0,gamePanel);
        }
    }
}
