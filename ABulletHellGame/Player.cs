/***********************************************************************************
* Author: Wonseok Han
* Date: 26/04/2022
* Program: A Bullet Hell Game
* Class: Player
* Description: User controlled entity called 
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
    class Player : Entity
    {
        protected virtual int _size { get; set; }

        public Player(PointF pos, Color col, int life) : base(pos, col, life)
        {
            _size = 30;
        }

        protected override bool vIsDead(int life)
        {
            if (_health == 0)
                return true;

            return false;
        }

        protected override void vMove()
        {

        }

        protected override void vRender(CDrawer canvas)
        {
            canvas.AddCenteredEllipse((int)_pos.X, (int)_pos.Y, _size, _size, _col);
        }

        protected override void vShoot()
        {

        }
    }
}
