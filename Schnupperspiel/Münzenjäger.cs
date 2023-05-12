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
            labelTime.setSize(220, 55);
            labelTime.setPosition(820, 10);
            labelTime.setText("Time");
            game.add(labelTime);
            

            Label labelPoints = new Label();
            labelPoints.setSize(220, 55);
            labelPoints.setPosition(820, 70);
            labelPoints.setText("Point");
            game.add(labelPoints);


            Label labelHighscore = new Label();
            labelHighscore.setSize(220, 55);
            labelHighscore.setPosition(820, 130);
            labelHighscore.setText("Highscore");
            game.add(labelHighscore);


            Text textTime = new Text();
            textTime.setPosition(1050, 10);
            textTime.setSize(94, 44);

            Text textPoints = new Text();
            textPoints.setPosition(1050, 70);
            textPoints.setSize(94, 44);

            Text textHighscore = new Text();
            textHighscore.setPosition(1050, 130);
            textHighscore.setSize(94, 44);

            game.addTimeText(textTime);
            game.addPointsText(textPoints);
            game.addHighscoreText(textHighscore);

            Button buttonName = new Button();
            buttonName.setText("Start");
            buttonName.setPosition(12, 550);
            buttonName.setSize(181, 62);
            buttonName.setColour(255,255,255);
            buttonName.Click += new System.EventHandler(game.btnStart_Click);

            Button buttonStop = new Button();
            buttonStop.setText("Stop");
            buttonStop.setPosition(423, 550);
            buttonStop.setSize(181, 62);
            buttonStop.setColour(255, 255, 255);
            buttonStop.Click += new System.EventHandler(game.btnStart_Click);

            buttonName.Enabled = false;
            buttonName.Click += new System.EventHandler(game.btnStop_Click);



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
