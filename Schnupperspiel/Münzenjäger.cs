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
            gamePanel.setColour(0,0,0);
            game.setPanel(gamePanel);

            Label titel = new Label();
            titel.setPosition(820, 480);
            titel.setSize(220, 55);
            titel.setText("Münzjäger");
            game.add(titel);

            Label time = new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("zeit");
            game.add(time);

            Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("punkte");
            game.add(points);

            Label highscore= new Label();
            highscore.setPosition(820, 130);
            highscore.setSize(220, 55);
            highscore.setText("highscore");
            game.add(highscore);

            Text Time = new Text();
            Time.setSize(94, 44);
            Time.setPosition(1050, 10);

            Text Points = new Text();
            Points.setSize(94, 44);
            Points.setPosition(1050, 70);

            Text Highscore = new Text();
            Highscore.setSize(94, 44);
            Highscore.setPosition(1050, 130);

            game.addTimeText(Time);
            game.addPointsText(Points);
            game.addHighscoreText(Highscore);

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
