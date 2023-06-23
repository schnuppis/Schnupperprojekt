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
            gamePanel.setSize(800, 500);
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);
            
            Label labelName = new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger:");
            game.add(labelName);
            
            Label timeName =new Label();
            timeName.setPosition(820, 10);
            timeName.setSize(220, 55);
            timeName.setText("Time:");
            game.add(timeName);

            Label pointsName =new Label();
            pointsName.setPosition(820, 70);
            pointsName.setSize(220, 55);
            pointsName.setText("Points:");
            game.add(pointsName);

            Label highscoreName =new Label();
            highscoreName.setPosition(820, 130);
            highscoreName.setSize(220, 55);
            highscoreName.setText("Highscore:");
            game.add(highscoreName);

            
            Text textTimer =new Text();
            textTimer.setPosition(1050, 10);
            textTimer.setSize(94, 44);
            game.addTimeText(textTimer);

            Text textPoints =new Text();
            textPoints.setPosition(1050, 70);
            textPoints.setSize(94, 44);
            game.addPointsText(textPoints);

            Text textHighscore = new Text();
            textHighscore.setPosition(1050, 130);
            textHighscore.setSize(94, 44);
            game.addHighscoreText(textHighscore);

            Button buttonStart =new Button();
            buttonStart.setPosition(12, 550);
            buttonStart.setSize(181, 62);
            buttonStart.setColour(255, 255, 255);
            buttonStart.setText("Start");
            buttonStart.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttonStart);

            Button buttonEnd =new Button();
            buttonEnd.setPosition(423, 550);
            buttonEnd.setSize(181, 62);
            buttonEnd.setColour(255, 255, 255);
            buttonEnd.setText("End");
            buttonEnd.Enabled= false;
            buttonEnd.Click += new System.EventHandler(game.btnStop_Click);
            game.add(buttonEnd);

            
            
            
            
            
            
           

            

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
