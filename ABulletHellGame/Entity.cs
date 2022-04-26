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
        protected List<Bullet> _bulletList = new List<Bullet>();    // All bullets from Entity
        protected PointF _pos = new PointF();                       // Where the entity "spawns"
        protected Color _col;                                       // Color to differentiate different entities
        protected int _size;                                        // Size of Entity
        protected int _health;                                      // Life points of different entities
        protected int _speed;                                       // Speed of Player

        public virtual Color Col { get; set; }          
        public virtual int Size { get; set; }           
        public virtual int Health { get; set; }
        public virtual int Speed { get; set; }
        public List<Bullet> BulletList => _bulletList;

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

        public void Move(CDrawer canvas)
        {
            vMove(canvas);
        }

        /// <summary>
        /// Fires a projectile from entity.
        /// </summary>
        public void Shoot(Point aim)
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
        }

        /// <summary>
        /// Check if entity is dead.
        /// </summary>
        /// <param name="life">Entity's current health.</param>
        /// <returns>Returns true if entity is dead. Otherwise, return false.</returns>
        public bool IsDead()
        {
            return vIsDead();
        }

        protected virtual void vMove(Keys direction, CDrawer canvas)
        {
        }

        protected virtual void vMove(CDrawer canvas)
        {
            if ((int)_pos.X == 0 || (int)_pos.X == canvas.ScaledWidth)
                _health = 0;
            if ((int)_pos.Y == 0 || (int)_pos.Y == canvas.ScaledHeight)
                _health = 0;
        }

        protected virtual void vShoot(Point aim)
        {
            _bulletList.Add(new Bullet(_pos, aim, Color.Red, 1));
        }

        protected abstract void vRender(CDrawer canvas);

        protected virtual bool vIsDead()
        {
            if (_health == 0)
                return true;

            return false;
        }
    }
}
