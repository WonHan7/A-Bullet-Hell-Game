/***********************************************************************************
* Author: Wonseok Han
* Date: 26/04/2022
* Program: A Bullet Hell Game
* Class: Bullet
* Description: A vectorized object that is derived from Entity.
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace ABulletHellGame
{
    class Bullet : Entity
    {
        private System.Drawing.Point _target;  // Used to calculation the trajectory
        protected Vector _vel;                 // Direction of Bullet
        private double _angle;                 // Angle of Bullet trajectory

        public Bullet(System.Drawing.PointF pos, System.Drawing.Point target, Color col, int health) : base(pos, col, health)
        {
            _size = 7;
            _speed = 10;
            _target = target;
            _angle = _target.X / _target.Y;
            _vel.X = (_target.X / _angle) + _speed;
            _vel.Y = (_target.Y / _angle) + _speed;
        }

        protected override void vRender(CDrawer canvas)
        {
            canvas.AddEllipse((int)_pos.X, (int)_pos.Y, _size, _size, _col);
        }

        protected override void vMove(CDrawer canvas)
        {
            _pos.X += (float)_vel.X;
            _pos.Y += (float)_vel.Y;
            base.vMove(canvas);
        }
    }
}
