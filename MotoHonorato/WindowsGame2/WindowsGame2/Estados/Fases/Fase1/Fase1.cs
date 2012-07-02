using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MotoGame.Estados.Fases.Fase1;

namespace MotoGame.Estados.Jogo
{
    class Fase1:EstadoBase
    {
        Moto moto1;
        
        Song musica;
        
        SpriteFont arial;
        
        //GameWindow Window;

        bool firstTimeMusic = true;

        Fundo cenario;
        Fundo montanhas;
        Fundo nuvens;
        Fundo arbustos;

        public Fase1(ContentManager Content, GameWindow Window)
            :base(Content, Window)
        {
            this.Window = Window;

            moto1 = new Moto(Content, this.Window);

            musica = Content.Load<Song>("Sounds/Musics/music");

            arial = Content.Load<SpriteFont>("arial");

            cenario = new Fundo(Content.Load<Texture2D>("Fases/Fase1/Textures/cenario") , Window);

            montanhas = new Fundo(Content.Load<Texture2D>("Fases/Fase1/Textures/montanhas"), Window);

            nuvens = new Fundo(Content.Load<Texture2D>("Fases/Fase1/Textures/nuvens"), Window);

            arbustos = new Fundo(Content.Load<Texture2D>("Fases/Fase1/Textures/arbustos"), Window);

        }

        public override void Update(GameTime gameTime)
        {
            if (firstTimeMusic)
            {
                //MediaPlayer.Play(musica);
                firstTimeMusic = false;
            }

            moto1.Update(gameTime);
            Vector2 aux = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height/2);
            moto1.Posicao = aux;

            if(moto1.Posicao.X >= Window.ClientBounds.Width/2)
            {
                aux = new Vector2(moto1.Velocidade.X,0);
            }

            else if (moto1.Posicao.X < Window.ClientBounds.Width/2)
            {
                aux = new Vector2(-moto1.Velocidade.X, 0);
            }

            if (moto1.Posicao.Y < Window.ClientBounds.Height/2 && nuvens.limimitecima == false)
            {
                aux = new Vector2(0, -moto1.Velocidade.Y);
            }
            else if (moto1.Posicao.Y > Window.ClientBounds.Height/2 && nuvens.limitebaixo == false)
            {
                aux = new Vector2(0, moto1.Velocidade.Y);
            }
            cenario.Update(gameTime, aux);
            montanhas.Update(gameTime, aux / 4f);
            nuvens.Update(gameTime, aux / 5f);
            arbustos.Update(gameTime, aux);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            nuvens.Draw(gameTime, spriteBatch);
            montanhas.Draw(gameTime, spriteBatch);
            cenario.Draw(gameTime, spriteBatch);       
            moto1.Draw(gameTime, spriteBatch);
            arbustos.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(arial, "Pontos: " + moto1.pontos, new Vector2(10, 10), Color.Red);

        }

    }
}
