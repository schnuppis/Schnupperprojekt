using System;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Xml.Linq;

// !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

namespace Schnupperspiel
{
    public partial class frmGame : Form




    {
        public Game game = new Game();
        private Random random = new Random();
        public static int xPlayer = 750;
        public static int yPlayer = 450;


        public  int xCoin = 0;
        public  int yCoin = 0;


        public bool left = true;



    










        public Panel gamePanel;

        public frmGame()
        {
            InitializeComponent();
        }
        private void loadGame(object sender, EventArgs e)

        {



            Timer tmrCoin = game.tmrCoin;
            tmrCoin.Tick += new System.EventHandler(this.tmrCoin_Tick);

            




            Timer tmrGame = game.tmrGame;
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            game.setTime(100);
            game.setTimerGameInterval(1000);



            game.setFormColour(200, 200, 200);


            Timer tmrEnemy = game.tmrEnemy;
           
            tmrEnemy.Tick += new System.EventHandler(this.tmrEnemy_Tick);




         






            gamePanel = new Panel();
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);

            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger");
            game.add(labelName);

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);
            labelTime.setText("Time");
            game.add(labelTime);





            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(250, 55);
            labelPoints.setText("Points");
            game.add(labelPoints);

            Label labelHighscore = new Label();
            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220, 55);
            labelHighscore.setText("Highscore");
            game.add(labelHighscore);








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



            Button StopbuttonName = new Button();
            StopbuttonName.setPosition(423, 550);
            StopbuttonName.setSize(181, 62);
            StopbuttonName.setColour(255, 255, 255);
            StopbuttonName.setText("Stop");
            game.add(StopbuttonName);

            StopbuttonName.Enabled = false;
            StopbuttonName.Click += new System.EventHandler(game.btnStop_Click);




            game.add(labelName);

            gamePanel.add(createPlayer());

          


            KeyDown += new KeyEventHandler(movePlayer);

            
          


            
            

            game.makeGame(this);
            
        }
        private Player createPlayer()
        { 
            

            Player player = new Player();
            player.setSize(50, 50);
            player.setSpeed(50);
            player.setPosition  (xPlayer , yPlayer);
            return player;

            






            }


        private void creatCoin()
        {
            Coin coin = new Coin();
            coin.setSize(20, 20);
            coin.setPosition(xCoin, yCoin, gamePanel); 
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
        private void tmrGame_Tick(object sender, EventArgs e)
        {
           if (game.getTime() == 0)
            {
                game.timeIsUp();
                game.stopGame();

                if (game.getPoints() > game.getHighscore())
                {

                    game.setHighscore(game.getPoints());
                }
            }

           if (gamePanel.getEnemyBots().Count < 21)
            {
                createEnemy();
            }
        }
        private void tmrCoin_Tick(object sender, EventArgs e)


        {
            game.LookForCoin(10);
            game.setScore(game.getPoints());
           




            while (game.getCoinList().Count < 60)
            {
                xCoin = random.Next(20, gamePanel.getWidth() - 40);
                yCoin = random.Next(20, gamePanel.getWidth() - 40);
                if (game.checkCoinPosition(xCoin, yCoin))
                { creatCoin(); }
                


            }

        }
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            

            foreach (EnemyBot bot in gamePanel.getEnemyBots()) {

                if (left) {
                    bot.moveRight();
                }
                else
                {
                    bot.moveLeft();
                }

                if (bot.getLeft() >= 750)
                {
                    left = false;
                }
                if (bot.getLeft() <= 0)
                {
                    left = true;
                }
                if (gamePanel. getPlayer().colidesWith(bot))
                {
                    game.stopGame();
                }

            }

          


        }
        private EnemyBot createEnemy()
        {
            EnemyBot bot = new EnemyBot();

            bot.setSize(40, 40);
            bot.setSpeed(80);
            bot.setPosition(random.Next(1, 750), random.Next(1, 350), gamePanel);
            return bot;







        }






    }
}
