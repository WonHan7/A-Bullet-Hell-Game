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
        public Bullet(System.Drawing.Point pos, Color col, int health) : base(pos, col, health)
        {
        }

        protected override void vMove(Keys direction, CDrawer canvas)
        {
            throw new NotImplementedException();
        }

        protected override void vRender(CDrawer canvas)
        {
            throw new NotImplementedException();
        }
    }
}
