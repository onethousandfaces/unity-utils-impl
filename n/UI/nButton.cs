using n.Gfx;
using UnityEngine;

namespace n.UI
{
  /** A simple helper for buttons */
  public class nButton {

    private nProp _button;

    private nProp _text;

    private bool _visible = false;

    public string Texture { get; set; }

    public string Text { get; set; }

    public string Font { get; set; }

    public float FontSize { get; set; }

    public Vector2 Position { get; set; }

    public Vector2 Size { get; set; }

    public nPropClick Action { get; set; }

    public Color Color { get; set; }

    public nCamera Camera { get; set; }

    public void Destroy() {
      if (_visible) {
        _visible = false;
        _button.Visible = false;
        _button = null;
        _text.Visible = false;
        _text = null;
      }
    }

    public void Manifest () {
      if (!_visible) {
        _visible = true;

        _button = new nProp (Texture, Size);
        _button.Visible = true;
        _button.Position = Position;
        _button.Depth = 1;

        var text = new nText (Size);
        text.Text = Text;
        text.Font = (Font) Resources.Load(Font);
        text.FontSize = FontSize;
        text.Color = Color;
        _text = new nProp (text);
        _text.Visible = true;
        _text.Position = new Vector2(Position[0] - Size[0] / 3, Position[1] + Size[1] / 3);
        _text.Depth = 0;

        _button.Listen (Camera, Action);
      }
    }
  }
}