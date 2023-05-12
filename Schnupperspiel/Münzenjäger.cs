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

            Label labelScoreboard = new Label();
            labelScoreboard.setPosition(820, 480);
            labelScoreboard.setSize(250,55);
            labelScoreboard.setText("Scoreboard.");
            game.add(labelScoreboard);

            Label labelTime = new Label();
            labelTime.setPosition(820, 10);
            labelTime.setSize(220, 55);
            labelTime.setText("Time.");
            game.add(labelTime);
            
            Label labelPoints = new Label();
            labelPoints.setPosition(820, 70);
            labelPoints.setSize(220, 55);
            labelPoints.setText("Points.");
            game.add(labelPoints);

            Label labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Highscore.");
            game.add(labelhighscore);
            Text labelTime2 = new Text();
            labelTime2.setPosition(820, 10);
            labelTime2.setSize(220, 55);
            // labelTime2.setText("Münzenjäger.");
            game.add(labelTime2);
            Label labelPoints = new Label();

            labelPonts.setPosition(820, 70);
            labelPoints.setSize(220, 55);
            labelPoints.setText("Münzenjäger.");
            game.add(labelPoints);

            Label labelhighscore = new Label();
            labelhighscore.setPosition(820, 130);
            labelhighscore.setSize(220, 55);
            labelhighscore.setText("Münzenjäger.");
            game.add(labelhighscore);

            game.makeGame(this);

            Text textTime = new Text();

            Label labeltime = new Label();
            labeltime.setPosition(1050, 10);
            labeltime.setSize(94, 44);
            labeltime.setText("Time.");
            game.add(labeltime); 
            
            Label labelpoints = new Label();
            labelpoints.setPosition(1050, 70);
            labelpoints.setSize(94, 44);
            labelpoints.setText("Points.");
            game.add(labelpoints); 
            
            Label labelhighscore = new Label();
            labelhighscore.setPosition(1050, 130);
            labelhighscore.setSize(94, 44);
            labelhighscore.setText("Highscore.");
            game.add(labelhighscore);

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
