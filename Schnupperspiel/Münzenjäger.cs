using System;
using System.Drawing.Text;
using System.Reflection.Emit;
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


            game.makeGame(this);
        }
     
            private Player createPlayer() {         
            Player player = new Player();
            player.setSize(50,50);
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
                
                player.getPositionX();
                player.getPositionY();
            }
            player.setPosition(player.getPositionX(), player.getPositionY());
        }
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
