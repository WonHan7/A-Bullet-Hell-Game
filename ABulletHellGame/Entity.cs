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
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace ABulletHellGame
{
    abstract class Entity
    {
        protected PointF _pos = new PointF();           // Where the entity "spawns"
        protected Color _col;                           // Color to differentiate different entities
        protected int _size;                            // Size of Entity
        protected int _health;                          // Life points of different entities
        protected int _speed;                           // Speed of Player

        public virtual Color Col { get; set; }          
        public virtual int Size { get; set; }           
        public virtual int Health { get; set; }
        public virtual int Speed { get; set; }

        public Entity(PointF pos, Color col, int health) : base()
        {
            _pos = pos;
            _col = col;
            _health = health;
        }

        /// <summary>
        /// Change vector of entity.
        /// </summary>
        public void Move(Keys direction, CDrawer canvas)
        {
            vMove(direction, canvas);
        }

        /// <summary>
        /// Fires a projectile from entity.
        /// </summary>
        public void Shoot(System.Drawing.Point aim)
        {
            vShoot(aim);
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

        protected abstract void vMove(Keys direction, CDrawer canvas);

        protected virtual void vShoot(System.Drawing.Point aim)
        {

        }

        protected abstract void vRender(CDrawer canvas);

        protected virtual bool vIsDead(int life)
        {
            if (_health == 0)
                return true;

            return false;
        }
    }
}
