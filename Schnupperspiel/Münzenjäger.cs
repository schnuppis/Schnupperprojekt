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
        public static int xcoin = 0 ;
        public static int ycoin = 0;
        public Panel gamePanel;

        public frmGame()
        {
            InitializeComponent();
        }
        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50, 50);
            player.setSpeed(20);
            player.setPosition(xPlayer, yPlayer);
            return player;



        }

        public void createCoin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.addToList(game.getCoinList());

            coin.setPosition(xcoin, ycoin, gamePanel);

        }
        public void funkcoin (object sender, EventArgs e)
        {        game.LookForCoin(10);
            game.setScore(game.getPoints());
            while (game.getCoinList().Count < 5)
            {
                xcoin = random.Next(20, gamePanel.getWidth() - 40);
                ycoin = random.Next(20, gamePanel.getHeight() - 40);
                if (game.checkCoinPosition(xcoin, ycoin) == true)
                {
                    createCoin();   
                }

            }
        } 

        private void loadGame(object sender, EventArgs e)
        {

            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);

            Label titel = new Label();
            titel.setPosition(820, 480);
            titel.setSize(220, 55);
            titel.setText("Münzjäger");
            game.add(titel);

            Label time = new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("zeit");
            game.add(time);

            Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("punkte");
            game.add(points);

            Label highscore = new Label();
            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("highscore");
            game.add(highscore);

            Text Time = new Text();
            Time.setSize(94, 44);
            Time.setPosition(1050, 10);

            Text Points = new Text();
            Points.setSize(94, 44);
            Points.setPosition(1050, 70);
           
            Text Highscore = new Text();
            Highscore.setSize(94, 44);
            Highscore.setPosition(1050, 130);

            game.addTimeText(Time);
            game.addPointsText(Points);
            game.addHighscoreText(Highscore);

            Button start = new Button();
            start.setPosition(200, 550);
            start.setSize(181, 62);
            start.setColour(0, 255, 0);
            start.setText("start");
            game.add(start);
            start.Click += new System.EventHandler(game.btnStart_Click);

            Button stop = new Button();
            stop.setPosition(423, 550);
            stop.setSize(181, 62);
            stop.setColour(255, 0, 0);
            stop.setText("stop");
            game.add(stop);
            stop.Enabled = false;
            stop.Click += new System.EventHandler(game.btnStop_Click);

            gamePanel.add(createPlayer());

            Timer tmrGame = game.tmrGame;

            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            KeyDown += new KeyEventHandler(movePlayer);
            game.setTime(120);
            game.setTimerGameInterval(2000);

            Timer tmrCoin = game.tmrCoin;

            tmrCoin.Tick += new System.EventHandler(funkcoin);
            {
                if (game.getTime() == 0)
                {
                    game.timeIsUp();
                    game.stopGame();
                }


            }
            

            game.makeGame(this);


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
            

        }
        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();
            }


        }
        
    }
}


