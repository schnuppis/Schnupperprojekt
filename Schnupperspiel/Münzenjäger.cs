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

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);
            labelTime.setText("Time:");

            game.add(labelTime);

            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220,55);
            labelPoints.setText("Points:");

            game.add(labelPoints);

            Label labelHighscore = new Label();
            labelHighscore.setPosition(820, 130);
            labelHighscore.setSize(220, 55);
            labelHighscore.setText("Highscore:");

            game.add(labelHighscore);

            Text textTime = new Text();

            Text textPoints = new Text();
            textPoints.setPosition(1055, 10);
            textPoints.setSize(94, 44);

            game.addPointsText(textPoints);

            Text texttime = new Text();
            texttime.setPosition(1055, 70);
            texttime.setSize(94, 44);

            game.addTimeText(texttime);

            Text texthighscore = new Text();
            texthighscore.setPosition(1055, 130);
            texthighscore.setSize(94, 44);
           
            game.addHighscoreText(texthighscore);

            Button buttonName = new Button();

            buttonName.setPosition(12, 550);
            buttonName.setSize(181,62);
            buttonName.setColour(255, 255, 255);
            buttonName.setText("Start");

            game.add(buttonName);

            buttonName.Click += new System.EventHandler(game.btnStart_Click);

            game.add(buttonName);
            
            Button buttonText = new Button();

            buttonText.setPosition(423, 550);
            buttonText.setSize(181, 62);
            buttonText.setColour(255, 255, 255);
            buttonText.setText("Stop");

            game.add(buttonText);








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
