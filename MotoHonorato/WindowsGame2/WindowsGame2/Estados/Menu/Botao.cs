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



namespace MotoGame.Estados.Menu
{
    class Botao
    {

        Texture2D botao;

        string imagem;

        Boolean sobre = false;

        public Boolean selecionada = false;

        GameWindow Window;

        float posicao;

        Vector2 quadroimagem;

        MouseState Mouseanterior;

        public Botao(ContentManager Content, GameWindow Window, string img, float Posicao)
        {
            this.Window = Window;

            imagem = img;

            botao = Content.Load<Texture2D>(imagem);

            posicao = Window.ClientBounds.Width / 2;
            posicao = Posicao;

            quadroimagem.X = 0;
            quadroimagem.Y = 0;

        }



        public void Update(GameTime gameTime, MouseState Mouse) {


            if ((Mouse.X >= (Window.ClientBounds.Width / 2 - botao.Width / 4) && Mouse.X <= (Window.ClientBounds.Width / 2 + botao.Width/4))&&(Mouse.Y >= posicao && Mouse.Y <= posicao + botao.Height))
            {
                if (Mouse.Y >= posicao && Mouse.Y <= posicao + botao.Height)
                {
                    quadroimagem.X = (botao.Width / 2);

                    if (Mouse.LeftButton == ButtonState.Pressed && Mouseanterior.LeftButton == ButtonState.Released) 
                    {
                        selecionada = true;

                    }


                }
                


            }

            else
            {
                quadroimagem.X = 0;
            }
            


            Mouseanterior = Mouse;

        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(botao, new Rectangle(Window.ClientBounds.Width / 2 - botao.Width / 4, (int)posicao, botao.Width / 2, botao.Height), new Rectangle((int)quadroimagem.X, 0,botao.Width/2, botao.Height), Color.White);


        }





    }


}
