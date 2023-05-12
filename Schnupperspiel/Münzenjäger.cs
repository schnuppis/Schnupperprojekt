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


            Label lableName = new Label();
            lableName.setPosition(820, 480);
            lableName.setSize(250, 55);

            lableName.setText("Münzenjäger:");
            game.add(lableName);

            Label Timelable = new Label();
            Timelable.setPosition(820, 10);
            Timelable.setSize(220, 55);
            Timelable.setText("time");
            game.add(Timelable);


            Label Pointlable = new Label();
            Pointlable.setPosition(820, 70);
            Pointlable.setSize(220, 55);
            Pointlable.setText("points");
            game.add(Pointlable);

            Label Highscorelable = new Label();
            Highscorelable.setPosition(820, 130);
            Highscorelable.setSize(220, 55);
            Highscorelable.setText("highscore");
            game.add(Highscorelable);


            Text TimeText = new Text();
            TimeText.setPosition(1050, 10);
            TimeText.setSize(94, 44);


            Text PointsText = new Text();
            PointsText.setPosition(1050, 70);
            PointsText.setSize(94, 44);

            Text HighscoreText = new Text();
            HighscoreText.setPosition(1050, 130);
            HighscoreText.setSize(94, 44);


            game.addTimeText(TimeText);
            game.addPointsText(PointsText);
            game.addHighscoreText(HighscoreText);

            Button buttongame = new Button();
            buttongame.setPosition(12, 550);
            buttongame.setSize(181, 62);
            buttongame.setColour(255, 255, 255);
            buttongame.setText("Start");
            buttongame.Click += new System.EventHandler(game.btnStart_Click);
            game.add(buttongame);


            Button buttonstop = new Button();
            buttonstop.setPosition(423, 550);
            buttonstop.setSize(181, 62);
            buttonstop.setColour(255, 255, 255);
            buttonstop.setText("Stop");
            buttonstop.Enabled = false;
            buttonstop.Click += new System.EventHandler(game.btnStop_Click);

            game.add(buttonstop);


            game.makeGame(this);

            gamePanel.add(createPlayer());
            KeyDown += new KeyEventHandler(movePlayer);


        }


        
        private Player createPlayer()
        {
            Player player = new Player();
            player.setSize(50, 50);
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
            }
            player.setPosition(player.getPositionX(), player.getPositionY());
        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {
        }
    }
}
