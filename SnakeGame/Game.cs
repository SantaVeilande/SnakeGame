﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Game : Form
    {
        int horVelocity = 0; //horizontal
        int verVelocity = 0; // vertical
        int step = 20; // 20 tāpēc, ka viens pikselis ir 20 mūsu gadījumā

        Area area = new Area();
        Snake snake = new Snake();
        Timer mainTimer = new Timer();
      

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();

        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
        }

        private void InitializeGame()
        {
            this.Height = 600;
            this.Width = 600; 

            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100; // vai šādi area.Location = new Point(100, 100);

            // adding snake body 
            snake.Render(this);
            // add keyboard controller handler
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (snake.horizontalVelocity != -1)
                    {
                        snake.horizontalVelocity = 1;
                    }
                   
                    snake.verticallVelocity = 0;
                    break;

                case Keys.Left:
                    if(snake.horizontalVelocity != 1)
                    {
                        snake.horizontalVelocity = -1;
                    }
                    snake.verticallVelocity = 0;
                    break;

                case Keys.Down:
                   
                    snake.horizontalVelocity = 0;
                    if (snake.verticallVelocity != -1)
                    {
                        snake.verticallVelocity = 1;
                    }
                   
                    break;

                case Keys.Up:
                   
                    snake.horizontalVelocity = 0;
                    if (snake.verticallVelocity != 1)
                    {
                        snake.verticallVelocity = -1;
                    }
                  
                    break;

            }
        }
    }
}
