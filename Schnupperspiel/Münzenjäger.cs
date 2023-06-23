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
            Label labelName= new Label();
            labelName.setPosition(820, 480);
            labelName.setSize(250, 55);
            labelName.setText("Münzenjäger:");
            game.add(labelName);
            //Time
            Label time= new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("Time:");
            game.add(time);
            //Points
            Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("Points:");
            game.add(points);
            //highscore
            Label highscore = new Label();
            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("Highscore:");
            game.add(highscore);

            Text outtime = new Text();
            outtime.setPosition(1050, 10);
            outtime.setSize(94, 44);
            game.addHighscoreText(outtime);

            Text outpoints = new Text();
            outpoints.setPosition(1050, 70);
            outpoints.setSize(94, 44);
            game.addHighscoreText(outpoints);

            Text outhigh = new Text();
            outhigh.setPosition(1050, 130);
            outhigh.setSize(94, 44);
            game.addHighscoreText(outhigh);



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
