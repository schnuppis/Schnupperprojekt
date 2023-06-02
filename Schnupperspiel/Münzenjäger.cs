using System;
using System.Drawing.Text;
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

		private Player CreatePlayer()
		{
			Player Player = new Player();
			Player.setSize(50, 50);
			Player.setSpeed(4);
			Player.setPosition(xPlayer, yPlayer);
			return Player;
		}

		public int CoinX;
		public int CoinY;

		void GenerateCoins()
		{
			Coin Coin = new Coin();
			Coin.setSize(20, 20);
			Coin.addToList(game.getCoinList());
			Coin.setPosition(random.Next(20,gamePanel.getWidth() -40), random.Next(20, gamePanel.getHeight() - 40), gamePanel);
		}

		private void loadGame(object sender, EventArgs e)
		{

			game.setFormColour(200, 200, 200);

			gamePanel = new Panel();
			gamePanel.setSize(800, 500);
			gamePanel.setColour(0, 0, 0);
			game.setPanel(gamePanel);

			Label time = new Label();
			time.setPosition(820, 0);
			time.setSize(250, 55);
			time.setText("Time:");

			Label points = new Label();
			points.setPosition(820, 100);
			points.setSize(250, 55);
			points.setText("Points:");

			Label highscore = new Label();
			highscore.setPosition(820, 200);
			highscore.setSize(250, 55);
			highscore.setText("High-Score:");

			game.add(time);
			game.add(points);
			game.add(highscore);

			Text textName = new Text();
			Text TimeText = new Text();
			Text PointsText = new Text();
			Text HighscoreText = new Text();

			PointsText.setPosition(1050, 100);
			TimeText.setPosition(1050, 10);
			HighscoreText.setPosition(1050, 200);

			PointsText.setSize(200, 44);
			TimeText.setSize(94, 44);
			HighscoreText.setSize(200, 44);

			game.addPointsText(PointsText);
			game.addTimeText(TimeText);
			game.addHighscoreText(HighscoreText);

			Button Start = new Button();
			Start.setPosition(12, 550);
			Start.setSize(181, 62);
			Start.setColour(255, 255, 255);
			Start.setText("Start");
			Start.Click += new System.EventHandler(game.btnStart_Click);

			Button Stop = new Button();
			Stop.setPosition(423, 550);
			Stop.setSize(181, 62);
			Stop.setColour(255, 255, 255);
			Stop.setText("Stop");
			Stop.Enabled = false;
			Stop.Click += new System.EventHandler(game.btnStop_Click);

			KeyDown += new KeyEventHandler(MovePlayer);
			KeyUp += new KeyEventHandler(MovePlayer);

			game.add(Start);
			game.add(Stop);

			gamePanel.add(CreatePlayer());
			

			Timer tmrGame = game.tmrGame;

			Timer tmrCoin = game.tmrCoin;
			tmrCoin.Tick += new System.EventHandler(this.CoinHandler);

			tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
			game.setTime(31556952);
			game.setTimerGameInterval(1000);

			game.makeGame(this);
		}
		
		public void CoinHandler (object sender, EventArgs e)
		{
			while (game.getCoinList().Count <= 100)
			{
				GenerateCoins();
                game.checkCoinPosition(CoinY, CoinX);
			}
            game.LookForCoin(10);
            game.setScore(game.getPoints());
        }

		private void MovePlayer(object sender, KeyEventArgs key)
		{
			Player Player = gamePanel.getPlayer();
			if (key.KeyCode == Keys.D & true & game.checkPanelRight())
			{
				_ = Player.moveRight();
			}
			if (key.KeyCode == Keys.A & true & game.checkPanelLeft())
			{
				 Player.moveLeft();
			}
			if (key.KeyCode == Keys.W & true & game.checkPanelTop())
			{
				_ = Player.moveUp();
			}
			if (key.KeyCode == Keys.S & true & game.checkPanelBottom())
			{
				_ = Player.moveDown();
			}
			_ = Player.getPositionX();
			_ = Player.getPositionY();
			Player.setPosition(Player.getPositionX(), Player.getPositionY());
		}
		private void tmrGame_Tick(object sender, EventArgs e)
		{
			if (game.getTime()==0)
			{
				game.timeIsUp();
				game.stopGame();
			}
		}
	}
}
