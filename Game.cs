using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Schnupperspiel
{
    public class Button : System.Windows.Forms.Button
    {
        public Button()
        {
            Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UseVisualStyleBackColor = false;
            Visible = false;
        }
        public void setSize(int w, int h)
        {
            Size = new System.Drawing.Size(w, h);
        }
        public void setPosition(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
            Visible = true;
        }
        public void setColour(int r, int g, int b)
        {
            BackColor = Color.FromArgb(r, g, b);
        }
        public void setText(String text)
        {
            Text = text;
            Name = text;
        }
    }
    public class Panel : System.Windows.Forms.Panel
    {

        public Panel()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Location = new System.Drawing.Point(12, 12);
            Name = "pnlGame";
            Visible = false;
        }

        public Player getPlayer()
        {
            foreach (Control c in Controls)
            {
                if (c is Player player)
                {
                    return player;
                }
            }
            return null;
        }

        public List<Enemy> getEnemys()
        {
            List<Enemy> list = new List<Enemy>();
            foreach (Control c in Controls)
            {
                if (c is Enemy enemy)
                {
                    list.Add(enemy);
                }
            }
            return list;
        }
        public List<EnemyBot> getEnemyBots()
        {
            List<EnemyBot> list = new List<EnemyBot>();
            foreach (Control c in Controls)
            {
                if (c is EnemyBot bot)
                {
                    list.Add(bot);
                }
            }
            return list;
        }
        public List<Wall> getWalls()
        {
            List<Wall> list = new List<Wall>();
            foreach (Control c in Controls)
            {
                if (c is Wall wall)
                {
                    list.Add(wall);
                }
            }
            return list;
        }

        public void add(Control control)
        {
            Controls.Add(control);
        }

        public void setColour(int r, int g, int b)
        {
            BackColor = Color.FromArgb(r, g, b);
        }
        public void setSize(int w, int h)
        {
            Size = new System.Drawing.Size(w, h);
            Visible = true;
        }

        public int getWidth()
        {
            return Width;
        }
        public int getHeight()
        {
            return Height;
        }

    }

    public class Label : System.Windows.Forms.Label
    {

        public Label()
        {
            AutoSize = false;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Visible = false;
        }
        public void setPosition(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
            Visible = true;
        }
        public void setSize(int w, int h)
        {
            Size = new System.Drawing.Size(w, h);
        }
        public void setText(String text)
        {
            Text = text;
        }
    }

    public class Text : TextBox
    {

        public Text()
        {
            Enabled = false;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            Visible = false;
        }
        public void setPosition(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
            Visible = true;
        }
        public void setSize(int w, int h)
        {
            Size = new System.Drawing.Size(w, h);
        }
    }
    public class GameObject : PictureBox
    {
        public Boolean colidesWith(GameObject gameObject)
        {
            Boolean test = false;

            var rect1 = new System.Drawing.Rectangle(this.Location, this.Size);
            var rect2 = new System.Drawing.Rectangle(gameObject.Location, gameObject.Size);

            if (rect1.IntersectsWith(rect2))
            {
                test = true;
            }
        
            return test;
        }
    }
    public class Coin : GameObject
    {

        public void setSize(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public void setPosition(int x, int y, Panel panel)
        {
            Visible = true;
            Image = Image.FromFile("../Image/coin.PNG");
            panel.add(this);
            Left = x;
            Top = y;
            SendToBack();
        }
        public void addToList(List<Coin> coinList)
        {
            coinList.Add(this);
        }
    }

    public class Wall : GameObject
    {
        public Wall()
        {
            TabStop = false;
            Visible = false;
        }
        public void setPosition(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
            Visible = true;
        }
        public void setSize(int w, int h)
        {
            Size = new System.Drawing.Size(w, h);
        }
        public void setColour(int r, int g, int b)
        {
            BackColor = Color.FromArgb(r, g, b);
        }
        public int getWidth()
        {
            return Width;
        }
        public int getHeight()
        {
            return Height;
        }
        public int getLeft()
        {
            return Left;
        }
        public int getTop()
        {
            return Top;
        }
    }

    public class Enemy : GameObject
    {
        private int xEnemy = 0;
        private int yEnemy = 0;
        public static int enemySpeed = 1;
        private int widthEnemy = 0;
        private int heightEnemy = 0;

        public Enemy()
        {
            Visible = true;
        }
        public void setPosition(int x, int y, Panel panel)
        {
            xEnemy = x;
            yEnemy = y;
            Location = new Point(xEnemy, yEnemy);
            Image = Image.FromFile("../Image/enemy.PNG");
            panel.add(this);
            BringToFront();
        }
        public void setSize(int w, int h)
        {
            widthEnemy = w;
            heightEnemy = h;
            Width = widthEnemy;
            Height = heightEnemy;
        }
        public void setSpeed(int speed)
        {
            enemySpeed = speed;
        }

        public int getSpeed()
        {
            return enemySpeed;
        }

        public int getTop()
        {
            return Location.Y;
        }
        public int getBottom()
        {
            return Location.Y+ Height;
        }
        public int getLeft()
        {
            return Location.X;
        }
        public int getRight()
        {
            return Location.X+ Width;
        }


        public void moveLeft()
        {
            Left -= enemySpeed;
        }
        public void moveRight()
        {
            Left += enemySpeed;
        }
        public void moveUp()
        {
            Top += enemySpeed;
        }
        public void moveDown()
        {
            Top -= enemySpeed;
        }
    }

    public class EnemyBot : GameObject
    {
        public static int enemyBotSpeed = 1;
        private int xEnemyBot = 0;
        private int yEnemyBot = 0;
        private int widthEnemyBot = 0;
        private int heightEnemyBot = 0;
        public void setPosition(int x, int y, Panel panel)
        {
            xEnemyBot = x;
            yEnemyBot = y;
            Location = new Point(xEnemyBot, yEnemyBot);
            Color temp = Color.FromArgb(0XFF8000);
            BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel.add(this);
            BringToFront();
        }
        public void setSize(int w, int h)
        {
            widthEnemyBot = w;
            heightEnemyBot = h;
            Width = widthEnemyBot;
            Height = heightEnemyBot;
        }
        public void setColor(Color color)
        {
            BackColor= color;
        }
        public void setSpeed(int speed)
        {
            enemyBotSpeed = speed;
        }

        public int getSpeed()
        {
            return enemyBotSpeed;
        }

        public int getTop()
        {
            return Top;
        }
        public int getLeft()
        {
            return Left;
        }

        public int getPositionX()
        {
            return xEnemyBot;
        }
        public int getPositionY()
        {
            return yEnemyBot;
        }

        public void moveLeft()
        {
            Left -= enemyBotSpeed;
        }
        public void moveRight()
        {
            Left += enemyBotSpeed;
        }
        public void moveUp()
        {
            Top += enemyBotSpeed;
        }
        public void moveDown()
        {
            Top -= enemyBotSpeed;
        }
    }

    public class Player : GameObject
    {

        private int playerSpeed = 0;
        private int xPlayer = 0;
        private int yPlayer = 0;
        private int startxPlayer = 0;
        private int startyPlayer = 0;
        private int widthPlayer = 0;
        private int heightPlayer = 0;
        private Boolean initial = true;

        public Player()
        {
            Visible = false;
        }
        public int getPositionX()
        {
            return xPlayer;
        }
        public int getPositionY()
        {
            return yPlayer;
        }
        public int getWidth()
        {
            return Width;
        }
        public int getHeight()
        {
            return Height;
        }
        public int getLeft()
        {
            return Left;
        }
        public int getTop()
        {
            return Top;
        }
        public int getSpeed()
        {
            return playerSpeed;
        }

        public void setSize(int w, int h)
        {
            widthPlayer = w;
            heightPlayer = h;
            Width = widthPlayer;
            Height = heightPlayer;
            Image = Image.FromFile("../Image/player.PNG");
            SendToBack();
        }

        public void setImage(string filePath)
        {
            Image = Image.FromFile(filePath);
        }

        public void setPosition(int x, int y)
        {
            xPlayer = x;
            yPlayer = y;
            if(initial)
            {
                startxPlayer = x;
                startyPlayer = y;
                initial = false;
            }
            

            Location = new Point(xPlayer, yPlayer);

        }
        public void setSpeed(int speed)
        {
            playerSpeed = speed;
        }

        public int moveLeft()
        {
            return xPlayer -= getSpeed();
        }
        public int moveRight()
        {
            return xPlayer += getSpeed();
        }
        public int moveUp()
        {
            return yPlayer -= getSpeed();
        }
        public int moveDown()
        {
            return yPlayer += getSpeed();
        }
        public void reset()
        {
            xPlayer= startxPlayer;
            yPlayer= startyPlayer;
            Location = new Point(xPlayer, yPlayer);
        }
    }


    public partial class Game : Form
    {
        /*
         * Private Variablen und Komponente auf die man von der anderen Klasse NICHT zugreifen kann
         */
        private Form Münzenjägerform = new Form();
        private List<Coin> coinList = new List<Coin>();
        private List<PictureBox> enemyList = new List<PictureBox>();
        private PictureBox picGameover = new PictureBox();
        private Text txtTime;
        private Text txtPoints;
        private Text txtHighscore;
        private Boolean highscoreistrue = true;
        private int highscore = 0;
        private int points = 0;
        private int time = 0;
        private int resetTime = 0;
        private int switchTime = 0;
        private int addedSpeed = 10;
        private int timeSpeedDelay=10;
        private int timeSpeed = 10;
        private List<Control> components = new List<Control>();
        private Panel panel;
        private Timer tmrSwitch = new Timer();

        /*
         * Öffentliche / Private Komponente auf die man von der anderen Klasse zugreifen kann
         */

        public Timer tmrCoin = new Timer();
        public Timer tmrGame = new Timer();
        public Timer tmrEnemy = new Timer();
        public Timer tmrSpeed = new Timer();


        /*
         * Setters (ohne Rückgabewert / mit Paramenter)
         */

        //Form-Setter
        public Boolean checkWallRight(GameObject gameObject, int speed)
        {
            GameObject posPosition = new GameObject();
            posPosition.Width = gameObject.Width;
            posPosition.Height = gameObject.Height;
            posPosition.Location = new Point(gameObject.Location.X + speed, gameObject.Location.Y);
            return colidesWithWalls(posPosition);
        }
        public Boolean checkWallLeft(GameObject gameObject, int speed)
        {
            GameObject posPosition = new GameObject();
            posPosition.Width = gameObject.Width;
            posPosition.Height = gameObject.Height;
            posPosition.Location = new Point(gameObject.Location.X - speed, gameObject.Location.Y );
            return colidesWithWalls(posPosition);
        }
        public Boolean checkWallTop(GameObject gameObject, int speed)
        {
            GameObject posPosition = new GameObject();
            posPosition.Width = gameObject.Width;
            posPosition.Height = gameObject.Height;
            posPosition.Location = new Point(gameObject.Location.X, gameObject.Location.Y - speed);
            return colidesWithWalls(posPosition);
        }
        public Boolean checkWallBottom(GameObject gameObject, int speed)
        {
            GameObject posPosition = new GameObject();
            posPosition.Width = gameObject.Width;
            posPosition.Height = gameObject.Height;
            posPosition.Location = new Point(gameObject.Location.X, gameObject.Location.Y + speed);
            return colidesWithWalls(posPosition);
        }

        private Boolean colidesWithWalls(GameObject gameObject)
        {
            Boolean result = false;
            foreach (Control c in panel.Controls)
            {
                if (c is Wall wall)
                {
                    if (gameObject.colidesWith(wall))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public void setPanel(Panel panel)
        {
            this.panel = panel;
            this.add(panel);
        }
        public void addPointsText(Text text)
        {
            txtPoints = text;
            add(text);
        }
        public void addHighscoreText(Text text)
        {
            txtHighscore = text;
            add(text);
        }
        public void addTimeText(Text txtTime)
        {
            this.txtTime= txtTime;
            add(txtTime);
        }

        public void add(Control component)
        {
            components.Add(component);
        }

        public List<Coin> getCoinList()
        {
            return coinList;
        }

        public int getTime()
        {
            return time;
        }

        //Punkte-Getter
        public int getPoints()
        {
            return points;
        }

        //Highscore-Getter
        public int getHighscore()
        {
            return highscore;
        }

        public void setTimerCoinInterval(int interval)
        {
            tmrCoin.Interval = interval;
        }
        public void setTimerGameInterval(int interval)
        {
            tmrGame.Interval = interval;
        }
        public void setTimerEnemyInterval(int interval)
        {
            tmrEnemy.Interval = interval;
        }




        /*
         * Methoden
         */


        //Spiel-Methode
        public void makeGame(Form form)
        {
            //Form            
            Münzenjägerform = form;
            form.WindowState = FormWindowState.Maximized;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1058, 497);
            foreach (Control c in components)
            {
                form.Controls.Add(c);
            }
            this.ResumeLayout(false);
            this.PerformLayout();

            //Spieltimer
            tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);

            tmrSpeed.Tick += new EventHandler(tmrSpeed_Tick);

            tmrSwitch.Tick += new System.EventHandler(tmrSwitch_Tick);
        }

        public void setFormColour(int r, int g, int b){
            Münzenjägerform.BackColor = Color.FromArgb(r,g,b);
        }
        //Stop-Methode
        public void stopGame()
        {
            if (points > highscore)
            {
                setHighscore(points);
            }

            foreach (Control c in components)
            {
                if (c is Panel panel)
                {
                    Player p = panel.getPlayer();
                    List<Wall> walls = panel.getWalls();
                    c.Controls.Clear();
                    c.Controls.Add(picGameover);
                    p.reset();
                    c.Controls.Add(p);
                    foreach(Wall control in walls)
                    {
                        c.Controls.Add(control);
                    }
                }
                if (c is Player player)
                {
                    player.reset();
                }
                if (c is Button)
                {
                    c.Enabled = !c.Enabled;
                    
                }
            }
            
            if (tmrSpeed.Enabled)
            {
                tmrSpeed.Enabled = false;
                panel.getPlayer().setSpeed(panel.getPlayer().getSpeed()- addedSpeed);

            }

            //GameOver
            picGameover.Visible = true;

            //Spieltimer
            tmrGame.Enabled = false;

            //Münzentimer
            tmrCoin.Enabled = false;

            //Gegnertimer
            tmrEnemy.Enabled = false;

            //Gegnerliste
            enemyList.Clear();

            //Münzenliste
            coinList.Clear();
        }

        //Panel-Methoden
        public Boolean checkPanelRight()
        {
            return !(panel.getPlayer().getPositionX() + panel.getPlayer().getWidth() >= panel.getWidth());
        }
        public Boolean checkPanelLeft()
        {
            return !(panel.getPlayer().getPositionX() <= 0);
        }
        public Boolean checkPanelTop()
        {
            return !(panel.getPlayer().getPositionY() <= 0);
        }
        public Boolean checkPanelBottom()
        {
            return !(panel.getPlayer().getPositionY() + panel.getPlayer().getHeight() >= panel.getHeight());
        }
        

        //Zeit-Methode
        public void timeIsUp()
        {
            txtTime.Text = (time + 1).ToString();
            picGameover.Image = Image.FromFile("../Image/timeisup.PNG");
        }

        //Münze<-->Münze-Kollision
        public Boolean checkCoinPosition(int xPosition, int yPosition)
        {
            Boolean test = true;

            Coin testCoin = new Coin();
            testCoin.Left= xPosition;
            testCoin.Top= yPosition;
            testCoin.setSize(20, 20);

            foreach (Control c in panel.Controls)
            {
                if (c is GameObject gameObject)
                {
                    if (testCoin.colidesWith(gameObject))
                    {
                        test = false;
                    }
                }
            }

            return test;
        }

        //Spieler<-->Münze-Kollision
        public void LookForCoin(int punkteProMuenze)
        {
            List<Coin> remove = new List<Coin>();
            foreach (Coin c in coinList)
            {
                if (panel.getPlayer().colidesWith(c))
                {
                    remove.Add(c);
                    points += punkteProMuenze;
                    switchTime = 1;
                    tmrSwitch.Interval = 1000;
                    tmrSwitch.Enabled = true;
                    panel.getPlayer().setImage("../Image/coinPlayer.png");
                }
            }
            foreach (Coin c in remove)
            {
                coinList.Remove(c);
                panel.Controls.Remove(c);
            }
        }

        public void tmrSwitch_Tick(object sender, EventArgs e)
        {
            switchTime--;

            if (switchTime <= 1)
            {
                panel.getPlayer().setImage("../Image/player.png");
                tmrSwitch.Enabled = false;
                
            }

        }

        /*
         * Evente
         */

        //Startknopf-Klickevent
        public void btnStart_Click(object sender, EventArgs e)
        {
            //Zeit setzen
            time = resetTime;
            txtTime.Text = time.ToString();

            //Highscore setzen
            if (highscoreistrue)
            {
                txtHighscore.Text = highscore.ToString();
                highscoreistrue = false;
            }

            //Punkte
            points = 0;


            picGameover.Image = Image.FromFile("../Image/gameover.PNG");
            picGameover.Width = 900;
            picGameover.Height = 600;
            picGameover.Left = 0;
            picGameover.Visible = false;
            Panel p =null;
            Wall w=null;
            foreach (Control c in components)
            {
                if(c is Panel panel)
                {
                    panel.add(picGameover);
                    panel.getPlayer().Visible = true;
                    foreach(Control control in panel.Controls)
                    {
                        if (control is Wall)
                        {
                            control.BringToFront();
                        }
                    }
                    p = panel;
                }
                if(c is Button)
                {
                            c.Enabled = !c.Enabled;
                        
                    
                    
                    
                }
                if(c is Wall wall)
                {
                    w =wall;
                }
            }
            foreach(PictureBox pB in enemyList)
            {
                pB.Visible = true;
            }
            //Puktetext
            txtPoints.Text = points.ToString();

            //Münzentimer
            tmrCoin.Enabled = true;

            //Spieltimer
            tmrGame.Enabled = true;

            //Gegnertimer
            tmrEnemy.Enabled = true;
        }

        //Stopknopf-Klickevent
        public void btnStop_Click(object sender, EventArgs e)
        {
            stopGame();
        }

        //Speedknopf-Klickevent
        public void speed()
        {
            panel.getPlayer().setSpeed(panel.getPlayer().getSpeed() + addedSpeed);
            tmrSpeed.Enabled = true;
        }


        public void tmrSpeed_Tick(object sender, EventArgs e)
        {

            timeSpeed--;


        }
        public int getSpeedTime()
        {
            return timeSpeed;
        }
        public int getSpeedDelay()
        {
            return timeSpeedDelay * -1;
        }
        public int getAddedPlayerSpeed()
        {
            return addedSpeed;

        }


        //Spieltimer-Tickevent    
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //Zeittext +1
            time = int.Parse(txtTime.Text);
            time -= 1;
            txtTime.Text = time.ToString();
        }

        



        public void setAddedPlayerSpeed(int speed){
            addedSpeed = speed;
        }

        public void setTimerSpeedInterval(int intervall){
            tmrSpeed.Interval = intervall;
        }
        public void setSpeedTime(int time){
            timeSpeed = time;
        }
        public void setSpeedDelay(int delay){
            timeSpeedDelay = delay;
        }
        public void setTime(int t){               
             time = t;
             resetTime = t;
        }

        //Punkte-Setters
        public void setScore(int points){
             txtPoints.Text = points.ToString();
        }
        public void setHighscore(int h)
        {
            highscore = h;
            txtHighscore.Text = "" + highscore;
            points = 0;
        }
    }
}
