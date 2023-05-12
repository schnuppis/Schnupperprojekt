using Schnupperspiel;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

 !! ALS STARTDATEI "Schnupperspiel.csproj - Debug|AnyCPU" auswählen !!

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
            game.add(labelName);
           
            Label labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Highscore:");
            game.add(labelName);

            Text textName = new Text();
            addTimeText(textName)
            addPointsText(textName)
            addHighscoreText(textName)


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