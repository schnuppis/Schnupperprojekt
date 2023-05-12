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

        public Panel gamePanel;

        public frmGame()
        {
            InitializeComponent();
        }

        private int xcoin;
        private int ycoin;

        private int xenemy;
        private int yenemy;

        private void loadGame(object sender, EventArgs e)
        {

            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);

            Label Titellabel = new Label();
            Titellabel.setPosition(820, 480);
            Titellabel.setSize(250, 55);
            Titellabel.setText("Münzenjäger");

            Label TimeLabel = new Label();
            TimeLabel.setPosition(820, 10);
            TimeLabel.setSize(220, 55);
            TimeLabel.setText("time:");

            Label PointsLabel = new Label();
            PointsLabel.setPosition(820, 70);
            PointsLabel.setSize(220, 55);
            PointsLabel.setText("Points:");

            Label Highscore = new Label();
            Highscore.setPosition(820, 130);
            Highscore.setSize(220, 55);
            Highscore.setText("Highscore:");

            game.add(Highscore);
            game.add(PointsLabel);
            game.add(Titellabel);
            game.add(TimeLabel);

            Text TimeText = new Text();
            TimeText.setPosition(1050, 10);
            TimeText.setSize(94, 44);

            Text PointsText = new Text();
            PointsText.setPosition(1050, 70);
            PointsText.setSize(94, 44);

            Text HighscoreText = new Text();
            HighscoreText.setPosition(1050, 130);
            HighscoreText.setSize(94, 44);

            game.addHighscoreText(HighscoreText);
            game.addPointsText(PointsText);
            game.addTimeText(TimeText);

            Button startButton = new Button();
            startButton.setPosition(12, 550);
            startButton.setSize(181, 62);
            startButton.setColour(255, 255, 255);
            startButton.setText("Start");

            startButton.Click += new System.EventHandler(game.btnStart_Click);

            Button stopButton = new Button();
            stopButton.setPosition(423, 550);
            stopButton.setSize(181, 62);
            stopButton.setColour(255, 255, 255);
            stopButton.setText("Stop");

            stopButton.Enabled = false;
            stopButton.Click += new System.EventHandler(game.btnStop_Click);

            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            Timer tmrCoin = game.tmrCoin;
            game.tmrCoin.Tick += new System.EventHandler(this.Coinclass);

            


            game.setTime(60);
            game.setTimerGameInterval(1000);

           
            game.add(startButton);
            game.add(stopButton);

            gamePanel.add(createPlayer());
            game.makeGame(this);
        }

        private Player createPlayer()
        {
            Player player = new Player();
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

            if (game.getTime() == 0)
            {
                tmrGame_Tick();
                game.timeIsUp();
                game.stopGame();
            }

           

        }

        private void Coins()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.setPosition(xcoin, ycoin, gamePanel);
            coin.addToList(game.getCoinList());
        }

        private void Coinclass(object sender, EventArgs e)
        {


            game.LookForCoin(10);



            while (game.getCoinList().Count < 10)
            {
                xcoin = random.Next(20, gamePanel.getWidth() - 40);
                ycoin = random.Next(20, gamePanel.getHeight() - 40);

                if (game.checkCoinPosition(xcoin, ycoin))
                {
                    Coins();
                    game.setScore(game.getPoints());
                }

            }
        }
        private void tmrGame_Tick() {

            if (game.getHighscore() > game.getPoints())
            {
                game.setHighscore(game.getPoints());
            }

        }
       



    }
        

    }

