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
            gamePanel.setColour(0, 0, 0);
            game.setPanel(gamePanel);
            //2 aufgabe titel,highscore,name
            //Label titel
            Label titel = new Label();
            titel.setPosition(820, 480);
            titel.setSize(250, 55);
            titel.setText("Münzenjäger");
            game.add(titel);
            //time
            Label time = new Label();
            time.setPosition(820, 10);
            time.setSize(220, 55);
            time.setText("Time:");
            game.add(time);
            //points :D
            Label points = new Label();
            points.setPosition(820, 70);
            points.setSize(220, 55);
            points.setText("Points:");
            game.add(points);
            //highscore
            Label high = new Label();
            high.setPosition(820, 130);
            high.setSize(220,55);
            high.setText("Highscore:");
            game.add(high);
            //output points high usw
            Text outtime = new Text();
            outtime.setPosition(1050, 10);
            outtime.setSize(94, 44);
            game.addTimeText(outtime);
            
            Text outpoints = new Text();
            outpoints.setPosition(1050, 70);
            outpoints.setSize(94, 44);
            game.addPointsText(outpoints);

            Text outhigh = new Text();
            outhigh.setPosition(1050, 130);
            outhigh.setSize(94, 44);
            game.addHighscoreText(outhigh);
            //aufgabe 4 yay
            //startknopf
            Button startb = new Button();
            startb.setPosition(12, 550);
            startb.setSize(300, 62);
            startb.setColour(255,255,255);
            startb.setText("Start :D");
            game.add(startb);
            //click button 
            startb.Click += new System.EventHandler(game.btnStart_Click);
            
            //add player
            gamePanel.add(createPlayer());
            //
            KeyDown += new KeyEventHandler(movePlayer);
            
            game.makeGame(this);
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
        /*private void tmrGame_Tick(object sender, EventArgs e)
        {
        }*/
    }
}
