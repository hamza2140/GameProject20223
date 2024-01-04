﻿using GameProject20223.Classes.Character;
using GameProject20223.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes
{
    internal class KeyboardReader : IInputReader
    {
        public Movement movement { get; private set; } = new Movement();
        public bool Jump { get; private set; }

        private int speed = 1;


        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = new Vector2(0, 2);

            if (state.IsKeyDown(Keys.Left))
            {
                if (this.ReadMovement())
                {
                    direction.X = -speed;
                    movement.HDirection = HorizontalDirection.Left;
                }
            }
            if (state.IsKeyDown(Keys.Right))
            {
                if (this.ReadMovement())
                {
                    direction.X = speed;
                    movement.HDirection = HorizontalDirection.Right;
                }
            }
            if (state.IsKeyDown(Keys.Up))
            {
                Jump = true;
                movement.VDirection = VerticalDirection.Up;
            }
            else
            {
                Jump = false;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                movement.VDirection = VerticalDirection.Down;
            }
            return direction;
        }

        public bool ReadMovement()
        {
            // Toetsenbord inlezen
            KeyboardState state = Keyboard.GetState();

            // Als we links en recht ingedrukt hebben is movement false
            if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Right)) return false;
            // True als er beweging is
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right)) return true;

            return false;
        }

        public bool ReadAttack()
        {
            KeyboardState state = Keyboard.GetState();
            bool attack = false;

            if (state.IsKeyDown(Keys.Space))
            {
                attack = true;
            }

            return attack;
        }
    }
}
