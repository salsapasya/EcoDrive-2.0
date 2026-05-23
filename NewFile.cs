// File: EcoDrive_vol2/AdComponents.cs
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace EcoDrive_vol2
{
    // ROUNDED PANEL (unchanged, moved to EcoDrive_vol2 namespace)
    public class RoundedPanel : Panel
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(12)]
        public int CornerRadius { get; set; } = 12;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get; set; } = Color.Transparent;

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = MakePath(ClientRectangle, CornerRadius))
            {
                using (var b = new SolidBrush(BackColor))
                    e.Graphics.FillPath(b, path);
                if (BorderColor != Color.Transparent)
                    using (var p = new Pen(BorderColor, 1f))
                        e.Graphics.DrawPath(p, path);
            }
        }

        public static GraphicsPath MakePath(Rectangle r, int radius)
        {
            int d = radius * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }

    // ROUNDED BUTTON (attributes added for designer serialization)
    public class RoundedButton : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(8)]
        public int CornerRadius { get; set; } = 8;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "Empty")]
        public Color HoverColor { get; set; } = Color.Empty;

        private bool _hover;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnPaintBackground(PaintEventArgs e) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color fill = _hover && HoverColor != Color.Empty ? HoverColor : BackColor;
            using (var path = RoundedPanel.MakePath(ClientRectangle, CornerRadius))
            using (var b = new SolidBrush(fill))
                e.Graphics.FillPath(b, path);

            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine);
        }
    }

    // PLACEHOLDER TEXTBOX (attributes added)
    public class PlaceholderTextBox : TextBox
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        public string Placeholder { get; set; } = "";
        private bool _showing = true;

        public PlaceholderTextBox()
        {
            BorderStyle = BorderStyle.None;
            Font = new Font("Segoe UI", 9.5f);
        }

        public void InitPlaceholder()
        {
            if (string.IsNullOrEmpty(Text))
            {
                Text = Placeholder;
                ForeColor = EC.TextGray;
                _showing = true;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (_showing) { Text = ""; ForeColor = EC.TextDark; _showing = false; }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text)) { Text = Placeholder; ForeColor = EC.TextGray; _showing = true; }
            base.OnLostFocus(e);
        }

        public string SearchText => _showing ? "" : Text;
    }
}