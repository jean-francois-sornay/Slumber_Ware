﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Slumber_Ware
{
    public class Button
    {
        Rectangle posSize; // Rectangle définnissant la zone de l'image clickable
        public Rectangle PosSize { get { return posSize; } set { posSize = value; } }

        bool clicked; // variable permettant de savoir si la souris est dans la zone clickable ou pas grace à la fonction update
        public bool Clicked { get { return clicked; } set { clicked = value; } }

        private Texture2D Image; // variable stockant l'image en texture2D
        public Texture2D image { get { return Image; } set { Image = value; } }

        //Constructeur de la classe button
        public Button(ContentManager content, string name)
        {
            image = content.Load<Texture2D>(name);
            //GERER LE RECTANGLE ICI ET PAS EN DEHORS
            clicked = false;
        }

        //Update
        public bool update(Vector2 mouse) // permet de changer la valeur de clicked pour savoir si il est à l'intérieur de la zone clikable
        {
            if (mouse.X >= posSize.X && mouse.X <= posSize.X + posSize.Width && mouse.Y >= posSize.Y && mouse.Y <= posSize.Y + posSize.Height) //si la souris est à l'intérieur
            {
                clicked = true; // c'est true
            }
            else
            {
                clicked = false; // si elle n'est pas dedans alors c'est false
            }
            return clicked;
        }

        public void draw(SpriteBatch sp) //Draw l'image et change sa couleur si la souris est dans la zone clickable
        {
            Color col = Color.White;
            if (clicked)
            {
                col = Color.Tan;
            }
            sp.Draw(image, posSize, col);
        }
    }
}
