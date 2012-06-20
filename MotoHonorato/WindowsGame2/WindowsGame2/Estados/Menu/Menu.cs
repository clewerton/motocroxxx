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
using MotoGame.Estados.Intro;
using MotoGame.Estados.Jogo;


namespace MotoGame.Estados.Menu
{
    class Menu : EstadoBase
    {
        KeyboardState teclado_atual;
        Botao botaoIniciar;
        Botao botaoSair;
        Botao botaoCreditos;
        public Boolean sair = false;

        public Menu(ContentManager Content, GameWindow Window):base(Content, Window){

           this.Window = Window;

           botaoIniciar = new Botao(Content, Window, "iniciar", Window.ClientBounds.Height / 4);
           botaoCreditos = new Botao(Content, Window, "creditos", Window.ClientBounds.Height / 4 + 100);
           botaoSair = new Botao(Content, Window, "sair", Window.ClientBounds.Height / 4 + 200);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public void  Update(GameTime gameTime, MouseState Mouse)
        {
            teclado_atual = Keyboard.GetState();

            if (teclado_atual.IsKeyDown(Keys.Space))
            {
                //videoPlayer.Stop();
                Game1.estado_atual = Game1.Estado.FASE1;
            }

            botaoIniciar.Update(gameTime, Mouse);
            botaoCreditos.Update(gameTime, Mouse);
            botaoSair.Update(gameTime, Mouse);

            testaapertou();
 	
        }

        public override void  Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            botaoIniciar.Draw(gameTime, spriteBatch);
            botaoCreditos.Draw(gameTime, spriteBatch);
            botaoSair.Draw(gameTime, spriteBatch);



            //spriteBatch.Draw(botaoIniciar, new Rectangle(Window.ClientBounds.Width / 2 - botaoIniciar.Width/2, Window.ClientBounds.Height /4 , 177, 33), new Rectangle(0, 0, 177, 33), Color.White);
            //spriteBatch.Draw(botaoCreditos, new Rectangle(Window.ClientBounds.Width / 2 - botaoCreditos.Width / 2, Window.ClientBounds.Height / 4 + 100, 151, 33), new Rectangle(0, 0, 151, 33), Color.White);
            //spriteBatch.Draw(botaoSair, new Rectangle(Window.ClientBounds.Width / 2 - botaoSair.Width / 2, Window.ClientBounds.Height /4 +200 , 74, 32), new Rectangle(0, 0, 74, 32), Color.White);
 	
        }


        private void testaapertou()
        {
            if (botaoIniciar.selecionada == true)
            {

                Game1.estado_atual = Game1.Estado.FASE1;
            }
            else if (botaoCreditos.selecionada == true)
            {
                //wsGame1.estado_atual = Game1.Estado.CREDITOS;
            }

            else if (botaoSair.selecionada == true)
            {
                sair = true;


            }

        }




    }
}
