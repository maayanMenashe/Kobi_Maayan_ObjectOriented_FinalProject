using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi
{
    public class Button : Sprite
    {
        public delegate void Clicked();
        //
        public Text content;
        bool isPressed;
        public Button() : base("Button")
        {
            content = new Text("Oswald");
        }

        public event Clicked ClickAction;

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            Rectangle textureBorder =
                new Rectangle((int)tm.position.X, (int)tm.position.Y, this.texture.Width, this.texture.Height); //This gives the area of the texture for hovering and clicking logic
            isPressed = mouseState.LeftButton == ButtonState.Pressed; //Checks for presses

            if (textureBorder.Contains(mousePoint)) //If hovering
            {
                base.color = Color.Black;
                if (isPressed)
                    ClickAction.Invoke();
            }
            else base.color = Color.White;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            content.tm.position = tm.position; // Font always in the center of a button
            base.Draw(spriteBatch);
            content.Draw(spriteBatch);
        }
    }
}
