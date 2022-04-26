/***********************************************************************************
* Author: Wonseok Han
* Date: 26/04/2022
* Program: A Bullet Hell Game
* Class: Entity
* Description: An abstract class to derive user player and enemy "AI"s
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
    abstract class Entity
    {
        protected PointF _pos { get; set; }         // Where the entity "spawns"
        protected Color _col { get; set; }          // Color to differentiate different entities
        protected virtual int _health { get; set; } // Life points of different entities

        public Entity(PointF pos, Color col, int health) : base()
        {
            _pos = pos;
            _col = col;
            _health = health;
        }

        /// <summary>
        /// Change vector of entity.
        /// </summary>
        public void Move()
        {
            vMove();
        }

        /// <summary>
        /// Fires a projectile from entity.
        /// </summary>
        public void Shoot()
        {
            vShoot();
        }

        /// <summary>
        /// Renders the entity.
        /// </summary>
        /// <param name="canvas">CDrawer reference.</param>
        public void Render(CDrawer canvas)
        {
            vRender(canvas);
            canvas.Render();
        }

        /// <summary>
        /// Check if entity is dead.
        /// </summary>
        /// <param name="life">Entity's current health.</param>
        /// <returns>Returns true if entity is dead. Otherwise, return false.</returns>
        public bool IsDead(int life)
        {
            return vIsDead(life);
        }

        protected abstract void vMove();

        protected abstract void vShoot();

        protected abstract void vRender(CDrawer canvas);

        protected abstract bool vIsDead(int life);
    }
}
