using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;//
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MotoGame
{
    class Moto:Sprite
    {
        SoundEffect ronco;

        animacao andando;
        animacao correndo;
        //animacao animacao_atual;
        Vector2 gravidade = new Vector2(0,10);

        public int pontos = 0;
        private const float MIN_VELOCIDADE = 1.0f;
        private Vector2 freio = new Vector2(0.3f, 0);
        

        public Moto(ContentManager Content, GameWindow Window)
            :base(Content.Load<Texture2D>("moto"))
        {
            this.Window = Window;

            textura = Content.Load<Texture2D>("moto");

            Aceleracao = new Vector2(0.1f, 0);

            ronco = Content.Load<SoundEffect>("Sounds/SoundEffects/sound_effect");

            andando = new animacao();
            andando.quadro_X = 67;
            andando.quadro_Y = 47;
            andando.qtd_quadros = 3;
            andando.quadros_seg = 3;
            andando.Y_inicial = 0;

            correndo = new animacao();
            correndo.quadro_X = 67;
            correndo.quadro_Y = 47;
            correndo.qtd_quadros = 3;
            correndo.quadros_seg = 9;
            correndo.Y_inicial = 47;

            animacao_atual = andando;


        }

        //public override void Update(GameTime gameTime)
        //{}

        public override void Update(GameTime gameTime)
        {
            bool acelerando = false;

            if (Game1.mouse_atual.LeftButton == ButtonState.Pressed)
            {
                posicao.X = Game1.mouse_atual.X;
                posicao.Y = Game1.mouse_atual.Y;
                ronco.Play();
            }

            //if (Game1.gamepad_atual.ThumbSticks.Right.X == 1)
            //{
            //    posicao = Vector2.Zero;
            //}

            if (Game1.teclado_atual.IsKeyDown(Keys.Right))
            {
                acelerando = true;
                Velocidade += Aceleracao;
                Posicao += Velocidade;
                configurarVelocidade();
                direita = true;
            }
            if (Game1.teclado_atual.IsKeyDown(Keys.Left))
            {
                acelerando = true;
                if (Velocidade.Length() > MIN_VELOCIDADE)
                {
                    Velocidade -= freio;
                    configurarVelocidade();
                    posicao += Velocidade;
                }
            }
            if (Game1.teclado_atual.IsKeyDown(Keys.Up))
            {
                posicao.Y -= Velocidade.Y;
            }
            if (Game1.teclado_atual.IsKeyDown(Keys.Down))
            {
                posicao.Y += Velocidade.Y;
            }
            if (!acelerando && (Velocidade.Length() > MIN_VELOCIDADE))
            {
                Velocidade -= Aceleracao;
            }

            #region manter na tela
            
            //indo pra trás
            if (posicao.X < 0)
            {
                posicao.X = 0;
            }

            //indo pra cima
            if (posicao.Y <= 0)
            {
                posicao.Y = 0;
            }

            //indo pra baixo
            if (posicao.Y >= Window.ClientBounds.Height - textura.Height / 2)
            {
                posicao.Y = Window.ClientBounds.Height - textura.Height / 2;
            }
                                    
            #endregion
        }

        private void configurarVelocidade()
        {
            double moduloVelocidade = Math.Sqrt(Velocidade.X * Velocidade.X + Velocidade.Y * Velocidade.Y);
            double angulo = Math.Atan2(Velocidade.Y, Velocidade.X);
            //Console.WriteLine("Angulo = " + angulo * 180 / Math.PI);
            if (moduloVelocidade > 20)
            {
                Velocidade = new Vector2(20.0f * (float)Math.Cos(angulo), 20.0f * (float)Math.Sin(angulo));
            }
        }

        /*
          Namespaces, interfaces e membros de enumeração têm acesso implicitamente “public” e não pode ser modificado;
Tipos (incluindo classes) podem ser “public” ou “internal”, o padrão é “internal”, quase igual a public, visivel dentro do emsmo assembly;
Membros de classes podem ser de todos os tipos, o padrão é “private”;
Membros de estruturas podem ser “public”, “internal” ou “private”, o padrão é “private”;
         */
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch, animacao_atual);

            //spriteBatch.Draw(textura, new Rectangle((int)posicao.X, (int)posicao.Y, 67, 47), new Rectangle(0, 0, 67, 47), Color.White);
        }
    }
}
