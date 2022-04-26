/***********************************************************************************
* Author: Wonseok Han
* Date: 26/04/2022
* Program: A Bullet Hell Game
* Class: Player
* Description: User controlled entity called Player
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
    class Player : Entity
    {
        protected Vector _vel;                      // Velocity + Direction of Player

        public Player(PointF pos, Color col, int health) : base(pos, col, health)
        {
            _vel = new Vector(0, 0);
            _size = 30;
            _speed = 7;
        }

        protected override void vMove(Keys direction, CDrawer canvas)
        {
            switch (direction)
            {
                // Up
                case Keys.W:
                    _vel.X = 0;
                    _vel.Y = _speed * -1;
                    if (_pos.Y < 0)
                        _pos.Y = 0;
                    break;
                // Left
                case Keys.A:
                    _vel.X = _speed * -1;
                    _vel.Y = 0;
                    if (_pos.X < 0)
                        _pos.X = 0;
                    break;
                // Down
                case Keys.S:
                    _vel.X = 0;
                    _vel.Y = _speed;
                    if (_pos.Y > canvas.ScaledHeight - _size)
                        _pos.Y = canvas.ScaledHeight - _size;
                    break;
                // Right
                case Keys.D:
                    _vel.X = _speed;
                    _vel.Y = 0;
                    if (_pos.X > canvas.ScaledWidth - _size)
                        _pos.X = canvas.ScaledWidth - _size;
                    break;
                default:
                    _vel.X = 0;
                    _vel.Y = 0;
                    break;
            }

            _pos.X += (float)_vel.X;
            _pos.Y += (float)_vel.Y;
        }

        protected override void vRender(CDrawer canvas)
        {
            canvas.AddEllipse((int)_pos.X, (int)_pos.Y, _size, _size, _col);
        }
    }
}
