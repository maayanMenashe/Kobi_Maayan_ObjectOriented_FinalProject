using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Maayan_Kobi;

public class Spritesheet
{
    public int columns { get; set; }
    public int rows { get; set; }
    public Texture2D texture { get; set; }

    public Rectangle this[int row, int column]
    {
        get
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;

            int pos_x = width * column;
            int pos_y = height * row;
            
            return new Rectangle(
                pos_x,
                pos_y,
                width,
                height);
        }
    }
}