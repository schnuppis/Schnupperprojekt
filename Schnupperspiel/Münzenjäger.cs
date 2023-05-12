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
            
            game.setFormColour(200, 200, 200);

            gamePanel = new Panel();
            gamePanel.setSize(800,500);
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger");

            game.add(labelName);

            Label labelName2 = new Label();
            labelName2.setPosition(820,10);
            labelName2.setSize(220,55);
            labelName2.setText("Time:");
            game.add(labelName2);

            Label labelName3 = new Label();
            labelName3.setPosition(820, 70);
            labelName3.setSize(220,55);
            labelName3.setText("Points:");
            game.add(labelName3);

            Label labelName4 = new Label();
            labelName4.setPosition(820,130);
            labelName4.setSize(220,55);
            labelName4.setText("Highscore");
            game.add(labelName4);
            
            Text textName1 = new Text();
            textName1.setPosition(1050, 10);
            textName1.setSize(94, 44);
            game.addTimeText(textName1);

            Text textName2 = new Text();
            textName2.setPosition(1050,70);
            textName2.setSize(94, 44);
            game.addHighscoreText(textName2);

            Text textName3 = new Text();
            textName3.setPosition(1050, 130);
            textName3.setSize(94,44);


            game.makeGame(this);
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

