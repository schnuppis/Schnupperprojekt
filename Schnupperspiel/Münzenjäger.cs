using System;
using System.Data;
using System.Drawing.Text;
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
            
            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.add(createPlayer());
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

            Label labelName = new Label();

            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger:");

            game.add(labelName);

            Label labelTime = new Label();

            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);

            game.add(labelTime);

            Label labelPoints = new Label();

            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220, 55);

            game.add(labelPoints);

            Label labelHighscore = new Label();


            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220, 55);

            game.add(labelHighscore);

            Text textTime = new Text();

            textTime.setPosition(1050, 10);
            textTime.setSize(94, 44);

            game.addTimeText(textTime);

            Text textPoints = new Text();

            textPoints.setPosition(1050, 70);
            textPoints.setSize(94, 44);
            game.addTimeText(textPoints);

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

            Button buttonName2 = new Button();

            buttonName2.setPosition(423, 550);
            buttonName2.setSize(181, 62);
            buttonName2.setColour(255, 255, 255);
            buttonName2.setText("Stop");

            game.add(buttonName2);

            buttonName.Enabled = false;

            buttonName.Click += new System.EventHandler(game.btnStop_Click);

            KeyDown += new KeyEventHandler(movePlayer);

            Timer tmrGame = game.tmrGame;

            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick); 
 


            





            
        }
        private Player createPlayer()
        {

            Player player = new Player();

            player.setSize(50, 50);
            player.setSpeed(4);
            player.setPosition(10, 10);
            game.add(player); 
            return player;

           









        }
        private void movePlayer(object sender, KeyEventArgs key)
        {
            /*Player player = gamePanel.getPlayer();
            if (key.KeyCode == Keys.D && game.checkPanelRight())
            {
                
            }
            if (key.KeyCode == Keys.A && game.checkPanelLeft())
            {
                
            }
            if (key.KeyCode == Keys.W && game.checkPanelTop())
            {
                
            }
            if (key.KeyCode == Keys.S && game.checkPanelBottom())
            {
                
            }*/
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
