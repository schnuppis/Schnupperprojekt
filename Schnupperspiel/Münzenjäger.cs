using System;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
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

        int Xcoin = 0;
        int Ycoin = 0;

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
            labelName.setPosition(850, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjager:");
            game.add(labelName);

            Label labelName1 = new Label();
            labelName1.setPosition(820, 10);
            labelName1.setSize(220, 55);
            labelName1.setText("Time:");
            game.add(labelName1);

            Label labelName2 = new Label();
            labelName2.setPosition(820, 70);
            labelName2.setSize(220, 55);
            labelName2.setText("Points:");
            game.add(labelName2);

            Label labelName3 = new Label();
            labelName3.setPosition(820, 130);
            labelName3.setSize(220, 55);
            labelName3.setText("Highscore:");
            game.add(labelName3);

            Text textName = new Text();
            textName.setPosition(1050, 10);
            textName.setSize(94, 44);
            game.addTimeText(textName);

            Text textName1 = new Text();
            textName1.setPosition(1050, 70);
            textName1.setSize(94, 44);
            game.addPointsText(textName1);

            Text textName2 = new Text();
            textName2.setPosition(1050, 130);
            textName2.setSize(94, 44);
            game.addHighscoreText(textName2);

            Button buttonName = new Button();
            buttonName.setPosition(12, 550);
            buttonName.setSize(181, 62);
            buttonName.setColour(255, 255, 255);
            buttonName.setText("Start:");
            game.add(buttonName);

            buttonName.Click += new System.EventHandler(game.btnStart_Click);

            Button buttonName1 = new Button();
            buttonName1.setPosition(423, 550);
            buttonName1.setSize(181, 62);
            buttonName1.setColour(255, 255, 255);
            buttonName1.setText("Stop:");
            game.add(buttonName1);

            buttonName1.Enabled = false;

            buttonName1.Click += new System.EventHandler(game.btnStop_Click);

            gamePanel.add(createPlayer());


            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            game.setTime(30);
            game.setTimerGameInterval(1000);

            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            Timer tmrEnemybot = game.tmrEnemy;
            tmrEnemybot.Tick += new System.EventHandler(this.tmrEnemybot_Tick);





            game.makeGame(this);
        }


        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50, 50);
            player.setSpeed(20);
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
        private void createCoin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.addToList(game.getCoinList());
            coin.setPosition(Xcoin, Ycoin, gamePanel);
        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            game.setScore( game.getPoints());

            if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();
               
            }
        }


        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            while (game.getCoinList().Count < 200)
            {
                Xcoin = random.Next(20, gamePanel.getWidth() - 40);
                Ycoin = random.Next(20, gamePanel.getHeight() - 40);

                if (game.checkCoinPosition(Xcoin, Ycoin))
                {
                    createCoin();
                }

            }
            game.LookForCoin(10);
        }
        private void createEnemybot()
        {

        }

            private void tmrEnemybot_Tick(object sender, EventArgs e)
            {
            EnemyBot EnemyBot = new EnemyBot();
            EnemyBot.setSize(50, 50);
            EnemyBot.setSpeed(15);
            EnemyBot.setPosition(45, 30, gamePanel);
        }
        /*private void MoveEnemyBot()
        {
        foreach(EnemyBot bot in gamePanel.getEnemyBots())
           
                if (MoveEnemyBotRight)
            {

            }
        }
        */

        }
}
