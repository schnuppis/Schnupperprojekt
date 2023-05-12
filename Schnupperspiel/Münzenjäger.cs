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
        private void loadGame(object sender, EventArgs e)
        {
            
            game.setFormColour(200,200,200);

            gamePanel = new Panel();
            gamePanel.setSize(800 , 500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);
            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger:");
            Text textName = new Text();
            game.add(labelName);

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);
            labelTime.setText("Time:");
            Text textTime = new Text();
            game.add(labelTime);

            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220, 55);
            labelPoints.setText("Points:");
            Text textPoints = new Text();
            game.add(labelPoints);

            Label labelHighscore = new Label();
            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220,55);
            labelHighscore.setText("Highscore");
            Text textHighscore = new Text();
            game.add(labelHighscore);


            

            Button buttonName = new Button();
            buttonName.setPosition(12, 550);
            buttonName.setSize(181, 62);
            buttonName.setColour(255, 255, 255);
            buttonName.setText("Start");
            buttonName.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttonName);

            Button buttonStop = new Button();
            buttonStop.setPosition(423, 550);
            buttonStop.setSize(181, 62);
            buttonStop.setColour(255, 255, 255);
            buttonStop.setText("Stop");
            buttonStop.Enabled = false;
            buttonStop.Click += new System.EventHandler(game.btnStop_Click);
            game.add(buttonStop);

            game.makeGame(this);



        }
        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50, 50);
            player.setSpeed(4);
            player.setPosition(xPlayer, yPlayer);
            createPlayer();
            KeyDown += new KeyEventHandler(movePlayer);
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
            player.getPositionX();
            player.getPositionY();
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
