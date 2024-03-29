﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MotoGame.Estados.Fases.Fase1
{
    class Fundo
    {
        Texture2D texture;
        public Rectangle origem;
        Rectangle destino;

        GameWindow Window;

        public Boolean limesqueda = false;
        public Boolean limdireita = false;
        public Boolean limimitecima = false;
        public Boolean limitebaixo = false;
        
        public Fundo(Texture2D texture, GameWindow Window)
        {
            this.texture = texture;
            this.Window = Window;

            destino = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);

            origem = new Rectangle(0, texture.Height - Window.ClientBounds.Height, Window.ClientBounds.Width, Window.ClientBounds.Height);

        }

        public void Update(GameTime gameTime, Vector2 posicao)
        {
            origem.X += (int)(posicao.X );
            origem.Y += (int)(posicao.Y );

            if (origem.X + Window.ClientBounds.Width >= texture.Width)
          
            {
                limdireita = true;

            }
            else{
                limdireita = false;
            }

            if (origem.X + texture.Width <= texture.Width)
            {
                limesqueda = true;

            }
            else
            {
                limesqueda = false;
            }


            if (origem.Y <= 0  )
            {
                //(texture.Height - Window.ClientBounds.Height) + 300
                limimitecima = true;
            }
            else
            {
                limimitecima = false;
            }


            if (origem.Y >= (0 + (texture.Height - Window.ClientBounds.Height)))
            {
                limitebaixo = true;
            }
            else
            {
                limitebaixo = false;
            }

            

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destino, origem, Color.White);
        }

    }
}
