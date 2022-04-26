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

        public Form1()
        {
            InitializeComponent();

            // UI Properties
            {
                // Canvas
                _canvas = new CDrawer(bContinuousUpdate: false);

                // Timer
                _playerTimer.Enabled = true;
                _playerTimer.Interval = 30;
            }

            // Event Handlers
            Shown += Form1_Shown;
            _playerTimer.Tick += _playerTimer_Tick;
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Set game canvas beside form window
            _canvas.Position = new Point(Location.X + Width, Location.Y);

            // Create a new instance of player 1
            _p1 = new Player(new Point(_canvas.ScaledWidth / 2, _canvas.ScaledHeight / 2), Color.Blue, 3);
        }
               
        private void _playerTimer_Tick(object sender, EventArgs e)
        {
            _canvas.Clear();
            _p1.Render(_canvas);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:

                    break;
                case Keys.A:
                    break;
                case Keys.S:
                    break;
                case Keys.D:
                    break;
                default:
                    break;
            }
        }
    }
}
