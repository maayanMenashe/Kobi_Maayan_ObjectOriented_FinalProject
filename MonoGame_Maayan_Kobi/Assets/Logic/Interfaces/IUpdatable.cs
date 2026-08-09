using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public interface IUpdatable
{
    void Start();
    void Update(GameTime gameTime);
}