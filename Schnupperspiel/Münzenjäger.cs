using Schnupperspiel;
using System;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Xml.Linq;

 //!! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

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
            gamePanel.setSize(800,500);
            gamePanel.setColour(0,0,0);
           
            game.setPanel(gamePanel); 

            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("CoinHunter:");
            game.add(labelName);
           
            Label labeltime = new Label();
            labeltime.setPosition(820, 10);
            labeltime.setSize(220, 55);
            labeltime.setText("Text:");
           
            Label labelpoints = new Label();
            labelpoints.setPosition(820, 70);
            labelpoints.setSize(220, 55);
            labelpoints.setText("Points:");
            game.add(labelpoints);
           
            Label labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Highscore:");
            game.add(labelhighscore);

            Text texttime = new Text();
            texttime.setPosition(1050, 10);
            texttime.setSize(94, 44);
            game.addTimeText(texttime);

            Text textpoints = new Text();
            textpoints.setPosition(1050, 70);
            textpoints.setSize(94, 44);
            game.addPointsText(textpoints);

            Text texthighscore = new Text();
            texthighscore.setPosition(1050, 130);
            texthighscore.setSize(94, 44);
            game.addHighscoreText(texthighscore);

            Button buttonName = new Button();
            buttonName.setText("Start");
            buttonName.setPosition(12, 550);
            buttonName.setSize(181, 62);
            buttonName.setColour(255, 255, 255);
           
            buttonName.Click += new System.EventHandler(game.btnStart_Click);
           
            Button ButtonStop = new Button();
            ButtonStop.setPosition(423, 550);
            ButtonStop.setSize(181, 62);
            ButtonStop.setColour(255, 255, 255);
            Button.setText("Stop");

            buttonStop.Enabled = false;
            buttonStop.Click += new System.EventHandler(game.btnStop_Click);
            
            private Player createPlayer()

            
            
            
            
            
            game.makeGame(this);
        }
        private void movePlayer(object sender, KeyEventArgs key)
        {
            /*Player player = gamePanel.getPlayer();
            /if (key.KeyCode == Keys.D && game.checkPanelRight())
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