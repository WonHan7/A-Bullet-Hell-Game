/***********************************************************************************
* Author: Wonseok Han
* Date: 26/04/2022
* Program: A Bullet Hell Game
* Class: Form
* Description: 
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace ABulletHellGame
{
    public partial class Form1 : Form
    {
        private Random _rnd = new Random();
        private CDrawer _canvas = null;
        private Timer _playerTimer = new Timer();
        private Player _p1 = null;
        private Keys _direction;

        public Form1()
        {
            InitializeComponent();

            // UI Properties
            {
                // Instantiate CDrawer
                _canvas = new CDrawer(bContinuousUpdate: false);

                // Timer
                _playerTimer.Interval = 30;

                // Start
                _startBtn.Text = $"Start Game";
            }

            // Event Handlers
            Shown += Form1_Shown;
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            _canvas.MouseLeftClick += _canvas_MouseLeftClick;
            _startBtn.Click += _startBtn_Click;
            _playerTimer.Tick += _playerTimer_Tick;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Set game canvas beside form window
            _canvas.Position = new Point(Location.X + Width, Location.Y);
            Activate();
        }

        private void _startBtn_Click(object sender, EventArgs e)
        {
            // Create a new instance of player 1
            _p1 = new Player(new Point(_canvas.ScaledWidth / 2, _canvas.ScaledHeight / 2), Color.Blue, 3);

            _playerTimer.Start();
        }

        private void _playerTimer_Tick(object sender, EventArgs e)
        {
            _canvas.Clear();

            // Move 
            _p1.Move(_direction, _canvas);
            // Move bullets
            _p1.BulletList.ForEach(b => b.Move(_canvas));
            // Render Player
            _p1.Render(_canvas);
            // Render bullets
            _p1.BulletList.ForEach(b => b.Render(_canvas));

            // Check health
            if (_p1.IsDead())
            {
                _playerTimer.Stop();
                _gameOverLabel.Text = $"Game Over!";
            }

            // Remove all bullets that have hit an Entity/boundary
            _p1.BulletList.RemoveAll(b => b.IsDead());
            
            // Stop Player movement if no keys are currently being pressed
            if (!IsAnyKeyDown())
                _direction = Keys.None;

            _canvas.Render();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            _direction = e.KeyCode;
            _p1.Move(_direction, _canvas);
        }

        private void _canvas_MouseLeftClick(Point pos, CDrawer dr)
        {
            _canvas.GetLastMouseLeftClickScaled(out Point aim);
            _p1.Shoot(aim);
            WriteLine(_p1?.BulletList.Count);
        }

        /// <summary>
        /// Checks if any key is currently being pressed.
        /// </summary>
        /// <returns>Returns true if a key is being pressed. Otherwise, return false.</returns>
        private bool IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(Key));

            foreach (var v in values)
                if (((Key)v) != Key.None && Keyboard.IsKeyDown((Key)v))
                    return true;

            return false;
        }
    }
}
