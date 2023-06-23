using System;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

namespace Schnupperspiel
{
    public partial class frmGame : Form
    {
        public Game game = new Game();
        private Random random = new Random();
        public static int xPlayer = 750;
        public static int yPlayer = 450;
        public int xCoin = 0;
        public int yCoin = 0;
        public static int xEnemy = 0;
        public static int yEnemy = 0;
        public bool moveright = true;
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
           
            
            
            
            Label Namelabel = new Label();
            Namelabel.setPosition(820, 10);
            Namelabel.setSize(220, 55);
            Namelabel.setText("time:");

            Label labelname = new Label();
            labelname.setPosition(820, 70);
            labelname.setSize(220, 55);
            labelname.setText("points:");


            Label LabelName = new Label();
            LabelName.setPosition(820, 130);
            LabelName.setSize(220, 55);
            LabelName.setText("highscore:");





            game.add(Namelabel);
            game.add(labelname);
            game.add(LabelName);
            game.add(labelName);
           
            Text textTime= new Text();
            textTime.setPosition(1050, 10);
            textTime.setSize(94, 44);

            Text textPoints= new Text();
            textPoints.setPosition(1050, 70);
            textPoints.setSize(94, 44);

            Text textHighscore = new Text();
            textHighscore.setPosition(1050, 130);
            textHighscore.setSize(94, 44);



            game.addTimeText(textTime);
            game.addPointsText(textPoints);
            game.addHighscoreText(textHighscore);

            Button buttonName = new Button();
            buttonName.setPosition(12, 550);
            buttonName.setSize(181, 62);
            buttonName.setColour(255,255, 255);
            buttonName.setText("Start");

            game.add(buttonName);
            
            buttonName.Click += new System.EventHandler(game.btnStart_Click);

            Button buttonStop = new Button();
            buttonStop.setPosition(423, 550);
            buttonStop.setSize(181, 62);
            buttonStop.setColour(255, 255, 255);
            buttonStop.setText("Stop");


            buttonStop.Enabled = false;

            


            game.add(buttonStop);

            buttonStop.Click += new System.EventHandler(game.btnStop_Click);


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
        private void tmrCoin_Tick(object sender, EventArgs e)
        {
            
            while(game.getCoinList().Count < 25)
            {   
                xCoin= random.Next(20, gamePanel.getWidth() -40);
                yCoin = random.Next(20, gamePanel.getHeight() - 40);
                if (game.checkCoinPosition(xCoin, yCoin)) 
                {
                    createCoin();
                }
            }
            game.LookForCoin(5);
            game.getPoints();
            game.setScore(game.getPoints());
            
        }

        private Enemy createEnemyBot()
        {
            EnemyBot enemy = new EnemyBot();
            enemy.setSize(65, 65); 
            enemy.setSpeed(8);
            enemy.setPosition(50,50, gamePanel);
            
            return null;
        }

             
        private Player createPlayer()
        {

            Player player = new Player();

            player.setSize(50,50);
            player.setSpeed(9);
            player.setPosition(xPlayer, yPlayer);       

            return player;
        }
        
        private void createCoin() {
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
            }
            if (game.getTime() == 59)
            {

                createEnemyBot();
            



            }
        } 
        private void tmrEnemy_Tick(object sender, EventArgs e)
        {
            Player player = gamePanel.getPlayer();
            foreach (EnemyBot bot in gamePanel.getEnemyBots())
            {
                if (bot.colidesWith(player)){

                    game.stopGame();

                }
                



               
              if (moveright)
                {
                    bot.moveRight();
                    
                } else
                {

                    bot.moveLeft(); 
                } 
                if (bot.getLeft()>800){ 
                
                    moveright = false;
                
                }
                if (bot.getLeft() < bot.getPositionX())
                {

                    moveright = true;
                }
                }
        }
    }
}
