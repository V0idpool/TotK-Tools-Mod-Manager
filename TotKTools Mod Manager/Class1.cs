using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using TotKModManager;
namespace TotKModManager
{


    // Name: Net Seal Theme
    // Created: 6/21/2013
    // Version: 1.0.0.1 beta

    abstract public class ThemeModule : ContainerControl
    {

        internal static Graphics G;

       

        public static Bitmap TextBitmap;
        public static Graphics TextGraphics;
        public ThemeModule()
        {
            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);
        }

        internal static SizeF MeasureString(string text, Font font)
        {
            return TextGraphics.MeasureString(text, font);
        }

        internal static SizeF MeasureString(string text, Font font, int width)
        {
            return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic);
        }

        public static GraphicsPath CreateRoundPath;
        public static Rectangle CreateRoundRectangle;

        internal static GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        internal static GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0f, 90.0f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0f, 90.0f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0f, 90.0f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0f, 90.0f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

    }

     class NSTheme : ThemeContainer154
    {

        public int _AccentOffset = 42;
        public int AccentOffset
        {
            get
            {
                return _AccentOffset;
            }
            set
            {
                _AccentOffset = value;
                this.Invalidate();
            }
        }

        public NSTheme()
        {
            this.Header = 30;
            this.BackColor = Color.FromArgb(50, 50, 50);

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(60, 60, 60));

            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
        }

        protected override void ColorHook()
        {

        }

        public Rectangle R1;

        public Pen P1, P2;
        public SolidBrush B1;

        public int Pad;

        protected override void PaintHook()
        {
            this.G.Clear(this.BackColor);
            this.DrawBorders(P2, 1);

            this.G.DrawLine(P1, 0, 26, this.Width, 26);
            this.G.DrawLine(P2, 0, 25, this.Width, 25);

            Pad = Math.Max(this.Measure().Width + 20, 80);
            R1 = new Rectangle(Pad, 17, this.Width - Pad * 2 + _AccentOffset, 8);

            this.G.DrawRectangle(P2, R1);
            this.G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height);

            this.G.DrawLine(P1, 0, 29, this.Width, 29);
            this.G.DrawLine(P2, 0, 30, this.Width, 30);

            this.DrawText(Brushes.Black, HorizontalAlignment.Left, 8, 1);
            this.DrawText(Brushes.White, HorizontalAlignment.Left, 7, 0);

            this.G.FillRectangle(B1, 0, 27, this.Width, 2);
            this.DrawBorders(Pens.Black);
        }

    }

   public class NSButton : Control
    {

        public NSButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(0, 0, 0));
            P2 = new Pen(Color.FromArgb(0, 0, 0));
        }

        public bool IsMouseDown;

        public GraphicsPath GP1, GP2;

        public SizeF SZ1;
        public PointF PT1;

        public Pen P1, P2;

        public PathGradientBrush PB1;
        public LinearGradientBrush GB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            if (IsMouseDown)
            {
                PB1 = new PathGradientBrush(GP1);
                PB1.CenterColor = Color.FromArgb(60, 60, 60);
                PB1.SurroundColors = new[] { Color.FromArgb(55, 55, 55) };
                PB1.FocusScales = new PointF(0.8f, 0.5f);

                ThemeModule.G.FillPath(PB1, GP1);
            }
            else
              //
            {//change dat button color!
            //
                GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(100, 100, 100), Color.FromArgb(90, 90, 90), 90.0f);
                ThemeModule.G.FillPath(GB1, GP1);
            }

            ThemeModule.G.DrawPath(P1, GP1);
            ThemeModule.G.DrawPath(P2, GP2);

            SZ1 = ThemeModule.G.MeasureString(Text, Font);
            PT1 = new PointF(5f, Height / 2 - SZ1.Height / 2f);

            if (IsMouseDown)
            {
                PT1.X += 1.0f;
                PT1.Y += 1.0f;
            }

            ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1f, PT1.Y + 1f);
            ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsMouseDown = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            IsMouseDown = false;
            Invalidate();
        }

    }

    public class NSProgressBar : Control
    {

        public int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        public int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        public int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        public void Increment(int amount)
        {
            Value += amount;
        }

        public NSProgressBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
            B1 = new SolidBrush(Color.FromArgb(200, 160, 0));
        }

        public GraphicsPath GP1, GP2, GP3;

        public Rectangle R1, R2;

        public Pen P1, P2;
        public SolidBrush B1;
        public LinearGradientBrush GB1, GB2;

        public int I1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0f);

            ThemeModule.G.SetClip(GP1);
            ThemeModule.G.FillRectangle(GB1, R1);

            I1 = (int)Math.Round((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 3));

            if (I1 > 1)
            {
                GP3 = ThemeModule.CreateRound(1, 1, I1, Height - 3, 7);

                R2 = new Rectangle(1, 1, I1, Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(205, 150, 0), Color.FromArgb(150, 110, 0), 90.0f);

                ThemeModule.G.FillPath(GB2, GP3);
                ThemeModule.G.DrawPath(P1, GP3);

                ThemeModule.G.SetClip(GP3);
                ThemeModule.G.SmoothingMode = SmoothingMode.None;

                ThemeModule.G.FillRectangle(B1, R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

                ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;
                ThemeModule.G.ResetClip();
            }

            ThemeModule.G.DrawPath(P2, GP1);
            ThemeModule.G.DrawPath(P1, GP2);
        }

    }

    public class NSLabel : Control
    {

        public NSLabel()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Segoe UI", 11.25f, FontStyle.Bold);

            B1 = new SolidBrush(Color.FromArgb(148, 0, 0));
        }

        public string _Value1 = "NET";
        public string Value1
        {
            get
            {
                return _Value1;
            }
            set
            {
                _Value1 = value;
                Invalidate();
            }
        }

        public string _Value2 = "SEAL";
        public string Value2
        {
            get
            {
                return _Value2;
            }
            set
            {
                _Value2 = value;
                Invalidate();
            }
        }

        public SolidBrush B1;

        public PointF PT1, PT2;
        public SizeF SZ1, SZ2;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);

            SZ1 = ThemeModule.G.MeasureString(Value1, Font, Width, StringFormat.GenericTypographic);
            SZ2 = ThemeModule.G.MeasureString(Value2, Font, Width, StringFormat.GenericTypographic);

            PT1 = new PointF(0f, Height / 2 - SZ1.Height / 2f);
            PT2 = new PointF(SZ1.Width + 1f, Height / 2 - SZ1.Height / 2f);

            ThemeModule.G.DrawString(Value1, Font, Brushes.Black, PT1.X + 1f, PT1.Y + 1f);
            ThemeModule.G.DrawString(Value1, Font, Brushes.White, PT1);

            ThemeModule.G.DrawString(Value2, Font, Brushes.Black, PT2.X + 1f, PT2.Y + 1f);
            ThemeModule.G.DrawString(Value2, Font, B1, PT2);
        }

    }

    [DefaultEvent("TextChanged")]
    public class NSTextBox : Control
    {

        public HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        public HorizontalAlignment TextAlign
        {
            get
            {
                return _TextAlign;
            }
            set
            {
                _TextAlign = value;
                if (Base is not null)
                {
                    Base.TextAlign = value;
                }
            }
        }

        public int _MaxLength = 32767;
        public int MaxLength
        {
            get
            {
                return _MaxLength;
            }
            set
            {
                _MaxLength = value;
                if (Base is not null)
                {
                    Base.MaxLength = value;
                }
            }
        }

        public bool _ReadOnly;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                if (Base is not null)
                {
                    Base.ReadOnly = value;
                }
            }
        }

        public bool _UseSystemPasswordChar;
        public bool UseSystemPasswordChar
        {
            get
            {
                return _UseSystemPasswordChar;
            }
            set
            {
                _UseSystemPasswordChar = value;
                if (Base is not null)
                {
                    Base.UseSystemPasswordChar = value;
                }
            }
        }

        public bool _Multiline;
        public bool Multiline
        {
            get
            {
                return _Multiline;
            }
            set
            {
                _Multiline = value;
                if (Base is not null)
                {
                    Base.Multiline = value;

                    if (value)
                    {
                        Base.Height = Height - 11;
                    }
                    else
                    {
                        Height = Base.Height + 11;
                    }
                }
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (Base is not null)
                {
                    Base.Text = value;
                }
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                if (Base is not null)
                {
                    Base.Font = value;
                    Base.Location = new Point(5, 5);
                    Base.Width = Width - 8;

                    if (!_Multiline)
                    {
                        Height = Base.Height + 11;
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!Controls.Contains(Base))
            {
                Controls.Add(Base);
            }

            base.OnHandleCreated(e);
        }

        public TextBox Base;
        public NSTextBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, true);

            Cursor = Cursors.IBeam;

            Base = new TextBox();
            Base.Font = Font;
            Base.Text = Text;
            Base.MaxLength = _MaxLength;
            Base.Multiline = _Multiline;
            Base.ReadOnly = _ReadOnly;
            Base.UseSystemPasswordChar = _UseSystemPasswordChar;

            Base.ForeColor = Color.White;
            Base.BackColor = Color.FromArgb(50, 50, 50);

            Base.BorderStyle = BorderStyle.None;

            Base.Location = new Point(5, 5);
            Base.Width = Width - 14;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }
            else
            {
                Height = Base.Height + 11;
            }

            Base.TextChanged += OnBaseTextChanged;
            Base.KeyDown += OnBaseKeyDown;

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
        }

        public GraphicsPath GP1, GP2;

        public Pen P1, P2;
        public PathGradientBrush PB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.9f, 0.5f);

            ThemeModule.G.FillPath(PB1, GP1);

            ThemeModule.G.DrawPath(P2, GP1);
            ThemeModule.G.DrawPath(P1, GP2);
        }

        public void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = Base.Text;
        }

        public void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Base.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Base.Location = new Point(5, 5);

            Base.Width = Width - 10;
            Base.Height = Height - 11;

            base.OnResize(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Base.Focus();
            base.OnMouseDown(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            Base.Focus();
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Invalidate();
            base.OnLeave(e);
        }

    }

    [DefaultEvent("CheckedChanged")]
    public class NSCheckBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;

        public delegate void CheckedChangedEventHandler(object sender);

        public NSCheckBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P11 = new Pen(Color.FromArgb(55, 55, 55));
            P22 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.Black, 2.0f);
            P4 = new Pen(Color.White, 2.0f);
        }

        public bool _Checked;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                CheckedChanged?.Invoke(this);

                Invalidate();
            }
        }

        public GraphicsPath GP1, GP2;

        public SizeF SZ1;
        public PointF PT1;

        public Pen P11, P22, P3, P4;

        public PathGradientBrush PB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 2, Height - 5, Height - 5, 5);
            GP2 = ThemeModule.CreateRound(1, 3, Height - 7, Height - 7, 5);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            ThemeModule.G.FillPath(PB1, GP1);
            ThemeModule.G.DrawPath(P11, GP1);
            ThemeModule.G.DrawPath(P22, GP2);

            if (_Checked)
            {
                ThemeModule.G.DrawLine(P3, 5, Height - 9, 8, Height - 7);
                ThemeModule.G.DrawLine(P3, 7, Height - 7, Height - 8, 7);

                ThemeModule.G.DrawLine(P4, 4, Height - 10, 7, Height - 8);
                ThemeModule.G.DrawLine(P4, 6, Height - 8, Height - 9, 6);
            }

            SZ1 = ThemeModule.G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2f);

            ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1f, PT1.Y + 1f);
            ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
        }

    }

    [DefaultEvent("CheckedChanged")]
    public class NSRadioButton : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;

        public delegate void CheckedChangedEventHandler(object sender);

        public NSRadioButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
        }

        public bool _Checked;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;

                if (_Checked)
                {
                    InvalidateParent();
                }

                CheckedChanged?.Invoke(this);
                Invalidate();
            }
        }

        public void InvalidateParent()
        {
            if (Parent is null)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!ReferenceEquals(C, this) && C is NSRadioButton)
                {
                    ((NSRadioButton)C).Checked = false;
                }
            }
        }

        public GraphicsPath GP1;

        public SizeF SZ1;
        public PointF PT1;

        public Pen P1, P2;

        public PathGradientBrush PB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = new GraphicsPath();
            GP1.AddEllipse(0, 2, Height - 5, Height - 5);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            ThemeModule.G.FillPath(PB1, GP1);

            ThemeModule.G.DrawEllipse(P1, 0, 2, Height - 5, Height - 5);
            ThemeModule.G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7);

            if (_Checked)
            {
                ThemeModule.G.FillEllipse(Brushes.Black, 6, 8, Height - 15, Height - 15);
                ThemeModule.G.FillEllipse(Brushes.White, 5, 7, Height - 15, Height - 15);
            }

            SZ1 = ThemeModule.G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2f);

            ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1f, PT1.Y + 1f);
            ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = true;
            base.OnMouseDown(e);
        }

    }

    public class NSComboBox : ComboBox
    {

        public NSComboBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.White, 2.0f);
            P3 = new Pen(Brushes.Black, 2.0f);
            P4 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B2 = new SolidBrush(Color.FromArgb(55, 55, 55));
        }

        public GraphicsPath GP1, GP2;

        public SizeF SZ1;
        public PointF PT1;

        public Pen P1, P2, P3, P4;
        public SolidBrush B1, B2;

        public LinearGradientBrush GB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0f);
            ThemeModule.G.SetClip(GP1);
            ThemeModule.G.FillRectangle(GB1, ClientRectangle);
            ThemeModule.G.ResetClip();

            ThemeModule.G.DrawPath(P1, GP1);
            ThemeModule.G.DrawPath(P4, GP2);

            SZ1 = ThemeModule.G.MeasureString(Text, Font);
            PT1 = new PointF(5f, Height / 2 - SZ1.Height / 2f);

            ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1f, PT1.Y + 1f);
            ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);

            ThemeModule.G.DrawLine(P3, Width - 15, 10, Width - 11, 13);
            ThemeModule.G.DrawLine(P3, Width - 7, 10, Width - 11, 13);
            ThemeModule.G.DrawLine(Pens.Black, Width - 11, 13, Width - 11, 14);

            ThemeModule.G.DrawLine(P2, Width - 16, 9, Width - 12, 12);
            ThemeModule.G.DrawLine(P2, Width - 8, 9, Width - 12, 12);
            ThemeModule.G.DrawLine(Pens.White, Width - 12, 12, Width - 12, 13);

            ThemeModule.G.DrawLine(P1, Width - 22, 0, Width - 22, Height);
            ThemeModule.G.DrawLine(P4, Width - 23, 1, Width - 23, Height - 2);
            ThemeModule.G.DrawLine(P4, Width - 21, 1, Width - 21, Height - 2);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(B1, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(B2, e.Bounds);
            }

            if (!(e.Index == -1))
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.White, e.Bounds);
            }
        }

    }

   public class NSTabControl : TabControl
    {

        public NSTabControl()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(28, 115);

            DrawMode = TabDrawMode.OwnerDrawFixed;

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.FromArgb(45, 45, 45), 2f);

            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
            B2 = new SolidBrush(Color.FromArgb(35, 35, 35));
            B3 = new SolidBrush(Color.FromArgb(205, 150, 0));
            B4 = new SolidBrush(Color.FromArgb(65, 65, 65));

            SF1 = new StringFormat();
            SF1.LineAlignment = StringAlignment.Center;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is TabPage)
            {
                e.Control.BackColor = Color.FromArgb(50, 50, 50);
            }

            base.OnControlAdded(e);
        }

        public GraphicsPath GP1, GP2, GP3, GP4;

        public Rectangle R1, R2;

        public Pen P1, P2, P3;
        public SolidBrush B1, B2, B3, B4;

        public PathGradientBrush PB1;

        public TabPage TP1;
        public StringFormat SF1;

        public int Offset;
        public int ItemHeight;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(Color.FromArgb(50, 50, 50));
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            ItemHeight = ItemSize.Height + 2;

            GP1 = ThemeModule.CreateRound(0, 0, ItemHeight + 3, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, ItemHeight + 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.8f, 0.95f);

            ThemeModule.G.FillPath(PB1, GP1);

            ThemeModule.G.DrawPath(P1, GP1);
            ThemeModule.G.DrawPath(P2, GP2);

            for (int I = 0, loopTo = TabCount - 1; I <= loopTo; I++)
            {
                R1 = GetTabRect(I);
                R1.Y += 2;
                R1.Height -= 3;
                R1.Width += 1;
                R1.X -= 1;

                TP1 = TabPages[I];
                Offset = 0;

                if (SelectedIndex == I)
                {
                    ThemeModule.G.FillRectangle(B1, R1);

                    for (int J = 0; J <= 1; J++)
                    {
                        ThemeModule.G.FillRectangle(B2, R1.X + 5 + J * 5, R1.Y + 6, 2, R1.Height - 9);

                        ThemeModule.G.SmoothingMode = SmoothingMode.None;
                        ThemeModule.G.FillRectangle(B3, R1.X + 5 + J * 5, R1.Y + 5, 2, R1.Height - 9);
                        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

                        Offset += 5;
                    }

                    ThemeModule.G.DrawRectangle(P3, R1.X + 1, R1.Y - 1, R1.Width, R1.Height + 2);
                    ThemeModule.G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2);
                    ThemeModule.G.DrawRectangle(P2, R1);
                }
                else
                {
                    for (int J = 0; J <= 1; J++)
                    {
                        ThemeModule.G.FillRectangle(B2, R1.X + 5 + J * 5, R1.Y + 6, 2, R1.Height - 9);

                        ThemeModule.G.SmoothingMode = SmoothingMode.None;
                        ThemeModule.G.FillRectangle(B4, R1.X + 5 + J * 5, R1.Y + 5, 2, R1.Height - 9);
                        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

                        Offset += 5;
                    }
                }

                R1.X += 5 + Offset;

                R2 = R1;
                R2.Y += 1;
                R2.X += 1;

                ThemeModule.G.DrawString(TP1.Text, Font, Brushes.Black, R2, SF1);
                ThemeModule.G.DrawString(TP1.Text, Font, Brushes.White, R1, SF1);
            }

            GP3 = ThemeModule.CreateRound(ItemHeight, 0, Width - ItemHeight - 1, Height - 1, 7);
            GP4 = ThemeModule.CreateRound(ItemHeight + 1, 1, Width - ItemHeight - 3, Height - 3, 7);

            ThemeModule.G.DrawPath(P2, GP3);
            ThemeModule.G.DrawPath(P1, GP4);
        }

    }

    [DefaultEvent("CheckedChanged")]
   public class NSOnOffBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;

        public delegate void CheckedChangedEventHandler(object sender);

        public NSOnOffBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(35, 35, 35));
            B2 = new SolidBrush(Color.FromArgb(85, 85, 85));
            B3 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B4 = new SolidBrush(Color.FromArgb(205, 150, 0));
            B5 = new SolidBrush(Color.FromArgb(40, 40, 40));

            SF1 = new StringFormat();
            SF1.LineAlignment = StringAlignment.Center;
            SF1.Alignment = StringAlignment.Near;

            SF2 = new StringFormat();
            SF2.LineAlignment = StringAlignment.Center;
            SF2.Alignment = StringAlignment.Far;

            Size = new Size(80, 30);
            MinimumSize = Size;
            MaximumSize = Size;
        }

        public bool _Checked;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                CheckedChanged?.Invoke(this);

                Invalidate();
            }
        }

        public GraphicsPath GP1, GP2, GP3, GP4;

        public Pen P1, P2, P3;
        public SolidBrush B1, B2, B3, B4, B5;

        public PathGradientBrush PB1;
        public LinearGradientBrush GB1;

        public Rectangle R1, R2, R3;
        public StringFormat SF1, SF2;

        public int Offset;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            ThemeModule.G.FillPath(PB1, GP1);
            ThemeModule.G.DrawPath(P1, GP1);
            ThemeModule.G.DrawPath(P2, GP2);

            R1 = new Rectangle(5, 0, Width - 10, Height + 2);
            R2 = new Rectangle(6, 1, Width - 10, Height + 2);

            R3 = new Rectangle(1, 1, Width / 2 - 1, Height - 3);

            if (_Checked)
            {
                ThemeModule.G.DrawString("\u2713", Font, Brushes.Black, R2, SF1);
                ThemeModule.G.DrawString("\u2713", Font, Brushes.White, R1, SF1);

                R3.X += Width / 2 - 1;
            }
            else
            {
                ThemeModule.G.DrawString("\u2717", Font, B1, R2, SF2);
                ThemeModule.G.DrawString("\u2717", Font, B2, R1, SF2);
            }

            GP3 = ThemeModule.CreateRound(R3, 7);
            GP4 = ThemeModule.CreateRound(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2, 7);

            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0f);

            ThemeModule.G.FillPath(GB1, GP3);
            ThemeModule.G.DrawPath(P2, GP3);
            ThemeModule.G.DrawPath(P3, GP4);

            Offset = R3.X + R3.Width / 2 - 3;

            for (int I = 0; I <= 1; I++)
            {
                if (_Checked)
                {
                    ThemeModule.G.FillRectangle(B1, Offset + I * 5, 7, 2, Height - 14);
                }
                else
                {
                    ThemeModule.G.FillRectangle(B3, Offset + I * 5, 7, 2, Height - 14);
                }

                ThemeModule.G.SmoothingMode = SmoothingMode.None;

                if (_Checked)
                {
                    ThemeModule.G.FillRectangle(B4, Offset + I * 5, 7, 2, Height - 14);
                }
                else
                {
                    ThemeModule.G.FillRectangle(B5, Offset + I * 5, 7, 2, Height - 14);
                }

                ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
            base.OnMouseDown(e);
        }

    }

   public class NSControlButton : Control
    {

        public enum Button : byte
        {
            None = 0,
            Minimize = 1,
            MaximizeRestore = 2,
            Close = 3
        }

        public Button _ControlButton = Button.Close;
        public Button ControlButton
        {
            get
            {
                return _ControlButton;
            }
            set
            {
                _ControlButton = value;
                Invalidate();
            }
        }

        public NSControlButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Width = 18;
            Height = 20;

            MinimumSize = Size;
            MaximumSize = Size;

            Margin = new Padding(0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.Clear(BackColor);

            switch (_ControlButton)
            {
                case Button.Minimize:
                    {
                        DrawMinimize(3, 10);
                        break;
                    }
                case Button.MaximizeRestore:
                    {
                        if (FindForm().WindowState == FormWindowState.Normal)
                        {
                            DrawMaximize(3, 5);
                        }
                        else
                        {
                            DrawRestore(3, 4);
                        }

                        break;
                    }
                case Button.Close:
                    {
                        DrawClose(4, 5);
                        break;
                    }
            }
        }

        public void DrawMinimize(int x, int y)
        {
            ThemeModule.G.FillRectangle(Brushes.White, x, y, 12, 5);
            ThemeModule.G.DrawRectangle(Pens.Black, x, y, 11, 4);
        }

        public void DrawMaximize(int x, int y)
        {
            ThemeModule.G.DrawRectangle(new Pen(Color.White, 2f), x + 2, y + 2, 8, 6);
            ThemeModule.G.DrawRectangle(Pens.Black, x, y, 11, 9);
            ThemeModule.G.DrawRectangle(Pens.Black, x + 3, y + 3, 5, 3);
        }

        public void DrawRestore(int x, int y)
        {
            ThemeModule.G.FillRectangle(Brushes.White, x + 3, y + 1, 8, 4);
            ThemeModule.G.FillRectangle(Brushes.White, x + 7, y + 5, 4, 4);
            ThemeModule.G.DrawRectangle(Pens.Black, x + 2, y + 0, 9, 9);

            ThemeModule.G.FillRectangle(Brushes.White, x + 1, y + 3, 2, 6);
            ThemeModule.G.FillRectangle(Brushes.White, x + 1, y + 9, 8, 2);
            ThemeModule.G.DrawRectangle(Pens.Black, x, y + 2, 9, 9);
            ThemeModule.G.DrawRectangle(Pens.Black, x + 3, y + 5, 3, 3);
        }

        public GraphicsPath ClosePath;
        public void DrawClose(int x, int y)
        {
            if (ClosePath is null)
            {
                ClosePath = new GraphicsPath();
                ClosePath.AddLine(x + 1, y, x + 3, y);
                ClosePath.AddLine(x + 5, y + 2, x + 7, y);
                ClosePath.AddLine(x + 9, y, x + 10, y + 1);
                ClosePath.AddLine(x + 7, y + 4, x + 7, y + 5);
                ClosePath.AddLine(x + 10, y + 8, x + 9, y + 9);
                ClosePath.AddLine(x + 7, y + 9, x + 5, y + 7);
                ClosePath.AddLine(x + 3, y + 9, x + 1, y + 9);
                ClosePath.AddLine(x + 0, y + 8, x + 3, y + 5);
                ClosePath.AddLine(x + 3, y + 4, x + 0, y + 1);
            }

            ThemeModule.G.FillPath(Brushes.White, ClosePath);
            ThemeModule.G.DrawPath(Pens.Black, ClosePath);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                var F = FindForm();

                switch (_ControlButton)
                {
                    case Button.Minimize:
                        {
                            F.WindowState = FormWindowState.Minimized;
                            break;
                        }
                    case Button.MaximizeRestore:
                        {
                            if (F.WindowState == FormWindowState.Normal)
                            {
                                F.WindowState = FormWindowState.Maximized;
                            }
                            else
                            {
                                F.WindowState = FormWindowState.Normal;
                            }

                            break;
                        }
                    case Button.Close:
                        {
                            F.Close();
                            break;
                        }
                }

            }

            Invalidate();
            base.OnMouseClick(e);
        }

    }

    public class NSGroupBox : ContainerControl
    {

        public bool _DrawSeperator;
        public bool DrawSeperator
        {
            get
            {
                return _DrawSeperator;
            }
            set
            {
                _DrawSeperator = value;
                Invalidate();
            }
        }

        public string _Title = "GroupBox";
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                Invalidate();
            }
        }

        public string _SubTitle = "Details";
        public string SubTitle
        {
            get
            {
                return _SubTitle;
            }
            set
            {
                _SubTitle = value;
                Invalidate();
            }
        }

        public Font _TitleFont;
        public Font _SubTitleFont;

        public NSGroupBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            _TitleFont = new Font("Verdana", 12.0f);
            _SubTitleFont = new Font("Verdana", 8f);

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(55, 55, 55));

            B1 = new SolidBrush(Color.FromArgb(205, 150, 0));
        }

        public GraphicsPath GP1, GP2;

        public PointF PT1;
        public SizeF SZ1, SZ2;

        public Pen P1, P2;
        public SolidBrush B1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            ThemeModule.G.DrawPath(P1, GP1);
            ThemeModule.G.DrawPath(P2, GP2);

            SZ1 = ThemeModule.G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic);
            SZ2 = ThemeModule.G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic);

            ThemeModule.G.DrawString(_Title, _TitleFont, Brushes.Black, 6f, 6f);
            ThemeModule.G.DrawString(_Title, _TitleFont, B1, 5f, 5f);

            PT1 = new PointF(6.0f, SZ1.Height + 4.0f);

            ThemeModule.G.DrawString(_SubTitle, _SubTitleFont, Brushes.Black, PT1.X + 1f, PT1.Y + 1f);
            ThemeModule.G.DrawString(_SubTitle, _SubTitleFont, Brushes.White, PT1.X, PT1.Y);

            if (_DrawSeperator)
            {
                int Y = (int)Math.Round(PT1.Y + SZ2.Height) + 8;

                ThemeModule.G.DrawLine(P1, 4, Y, Width - 5, Y);
                ThemeModule.G.DrawLine(P2, 4, Y + 1, Width - 5, Y + 1);
            }
        }

    }

    public class NSSeperator : Control
    {

        public NSSeperator()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Height = 10;

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
        }

        public Pen P1, P2;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.Clear(BackColor);

            ThemeModule.G.DrawLine(P1, 0, 5, Width, 5);
            ThemeModule.G.DrawLine(P2, 0, 6, Width, 6);
        }

    }

    [DefaultEvent("Scroll")]
    public class NSTrackBar : Control
    {

        public event ScrollEventHandler Scroll;

        public delegate void ScrollEventHandler(object sender);

        public int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        public int _Maximum = 10;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        public int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();

                Scroll?.Invoke(this);
            }
        }

        public NSTrackBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Height = 17;

            P1 = new Pen(Color.FromArgb(150, 110, 0), 2f);
            P2 = new Pen(Color.FromArgb(55, 55, 55));
            P3 = new Pen(Color.FromArgb(35, 35, 35));
            P4 = new Pen(Color.FromArgb(65, 65, 65));
        }

        public GraphicsPath GP1, GP2, GP3, GP4;

        public Rectangle R1, R2, R3;
        public int I1;

        public Pen P1, P2, P3, P4;

        public LinearGradientBrush GB1, GB2, GB3;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 5, Width - 1, 10, 5);
            GP2 = ThemeModule.CreateRound(1, 6, Width - 3, 8, 5);

            R1 = new Rectangle(0, 7, Width - 1, 5);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0f);

            I1 = (int)Math.Round((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 11));
            R2 = new Rectangle(I1, 0, 10, 20);

            ThemeModule.G.SetClip(GP2);
            ThemeModule.G.FillRectangle(GB1, R1);

            R3 = new Rectangle(1, 7, R2.X + R2.Width - 2, 8);
            GB2 = new LinearGradientBrush(R3, Color.FromArgb(205, 150, 0), Color.FromArgb(150, 110, 0), 90.0f);

            ThemeModule.G.SmoothingMode = SmoothingMode.None;
            ThemeModule.G.FillRectangle(GB2, R3);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            for (int I = 0, loopTo = R3.Width - 15; I <= loopTo; I += 5)
                ThemeModule.G.DrawLine(P1, I, 0, I + 15, Height);

            ThemeModule.G.ResetClip();

            ThemeModule.G.DrawPath(P2, GP1);
            ThemeModule.G.DrawPath(P3, GP2);

            GP3 = ThemeModule.CreateRound(R2, 5);
            GP4 = ThemeModule.CreateRound(R2.X + 1, R2.Y + 1, R2.Width - 2, R2.Height - 2, 5);
            GB3 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0f);

            ThemeModule.G.FillPath(GB3, GP3);
            ThemeModule.G.DrawPath(P3, GP3);
            ThemeModule.G.DrawPath(P4, GP4);
        }

        public bool TrackDown;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                I1 = (int)Math.Round((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 11));
                R2 = new Rectangle(I1, 0, 10, 20);

                TrackDown = R2.Contains(e.Location);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (TrackDown && e.X > -1 && e.X < Width + 1)
            {
                Value = _Minimum + (int)Math.Round((_Maximum - _Minimum) * (e.X / (double)Width));
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            TrackDown = false;
            base.OnMouseUp(e);
        }

    }

    [DefaultEvent("ValueChanged")]
   public class NSRandomPool : Control
    {

        public event ValueChangedEventHandler ValueChanged;

        public delegate void ValueChangedEventHandler(object sender);

        public StringBuilder _Value = new StringBuilder();
        public string Value
        {
            get
            {
                return _Value.ToString();
            }
        }

        public string _FullValue;
        public string FullValue
        {
            get
            {
                return BitConverter.ToString(Table).Replace("-", "");
            }
        }

        public Random RNG = new Random();

        public int ItemSize = 9;
        public int DrawSize = 8;

        public Rectangle WA;

        public int RowSize;
        public int ColumnSize;

        public NSRandomPool()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));

            B1 = new SolidBrush(Color.FromArgb(30, 30, 30));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            UpdateTable();
            base.OnHandleCreated(e);
        }

        public byte[] Table;
        public void UpdateTable()
        {
            WA = new Rectangle(5, 5, Width - 10, Height - 10);

            RowSize = WA.Width / ItemSize;
            ColumnSize = WA.Height / ItemSize;

            WA.Width = RowSize * ItemSize;
            WA.Height = ColumnSize * ItemSize;

            WA.X = Width / 2 - WA.Width / 2;
            WA.Y = Height / 2 - WA.Height / 2;

            Table = new byte[(RowSize * ColumnSize)];

            for (int I = 0, loopTo = Table.Length - 1; I <= loopTo; I++)
                Table[I] = (byte)RNG.Next(100);

            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateTable();
        }

        public int Index1 = -1;
        public int Index2;

        public bool InvertColors;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            HandleDraw(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            HandleDraw(e);
            base.OnMouseDown(e);
        }

        public void HandleDraw(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (!WA.Contains(e.Location))
                    return;

                InvertColors = e.Button == MouseButtons.Right;

                Index1 = GetIndex(e.X, e.Y);
                if (Index1 == Index2)
                    return;

                bool L = !(Index1 % RowSize == 0);
                bool R = !(Index1 % RowSize == RowSize - 1);

                Randomize(Index1 - RowSize);
                if (L)
                    Randomize(Index1 - 1);
                Randomize(Index1);
                if (R)
                    Randomize(Index1 + 1);
                Randomize(Index1 + RowSize);

                _Value.Append(Table[Index1].ToString("X"));
                if (_Value.Length > 32)
                    _Value.Remove(0, 2);

                ValueChanged?.Invoke(this);

                Index2 = Index1;
                Invalidate();
            }
        }

        public GraphicsPath GP1, GP2;

        public Pen P1, P2;
        public SolidBrush B1, B2;

        public PathGradientBrush PB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.9f, 0.5f);

            ThemeModule.G.FillPath(PB1, GP1);

            ThemeModule.G.DrawPath(P1, GP1);
            ThemeModule.G.DrawPath(P2, GP2);

            ThemeModule.G.SmoothingMode = SmoothingMode.None;

            for (int I = 0, loopTo = Table.Length - 1; I <= loopTo; I++)
            {
                int C = Math.Max((int)Table[I], 75);

                int X = I % RowSize * ItemSize + WA.X;
                int Y = I / RowSize * ItemSize + WA.Y;

                B2 = new SolidBrush(Color.FromArgb(C, C, C));

                ThemeModule.G.FillRectangle(B1, X + 1, Y + 1, DrawSize, DrawSize);
                ThemeModule.G.FillRectangle(B2, X, Y, DrawSize, DrawSize);

                B2.Dispose();
            }

        }

        public int GetIndex(int x, int y)
        {
            return (y - WA.Y) / ItemSize * RowSize + (x - WA.X) / ItemSize;
        }

        public void Randomize(int index)
        {
            if (index > -1 && index < Table.Length)
            {
                if (InvertColors)
                {
                    Table[index] = (byte)RNG.Next(100);
                }
                else
                {
                    Table[index] = (byte)RNG.Next(100, 256);
                }
            }
        }

    }

   public class NSKeyboard : Control
    {

        public Bitmap TextBitmap;
        public Graphics TextGraphics;

        public const string LowerKeys = @"1234567890-=qwertyuiop[]asdfghjkl\;'zxcvbnm,./`";
        public const string UpperKeys = "!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL|:\"ZXCVBNM<>?~";

        public NSKeyboard()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Verdana", 8.25f);

            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);

            MinimumSize = new Size(386, 162);
            MaximumSize = new Size(386, 162);

            Lower = LowerKeys.ToCharArray();
            Upper = UpperKeys.ToCharArray();

            PrepareCache();

            P1 = new Pen(Color.FromArgb(45, 45, 45));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
            P3 = new Pen(Color.FromArgb(35, 35, 35));

            B1 = new SolidBrush(Color.FromArgb(100, 100, 100));
        }

        public Control _Target;
        public Control Target
        {
            get
            {
                return _Target;
            }
            set
            {
                _Target = value;
            }
        }

        public bool Shift;

        public int Pressed = -1;
        public Rectangle[] Buttons;

        public char[] Lower;
        public char[] Upper;
        public string[] Other = new[] { "Shift", "Space", "Back" };

        public PointF[] UpperCache;
        public PointF[] LowerCache;

        public void PrepareCache()
        {
            Buttons = new Rectangle[51];
            UpperCache = new PointF[Upper.Length];
            LowerCache = new PointF[Lower.Length];

            int I;

            SizeF S;
            Rectangle R;

            for (int Y = 0; Y <= 3; Y++)
            {
                for (int X = 0; X <= 11; X++)
                {
                    I = Y * 12 + X;
                    R = new Rectangle(X * 32, Y * 32, 32, 32);

                    Buttons[I] = R;

                    if (!(I == 47) && !char.IsLetter(Upper[I]))
                    {
                        S = TextGraphics.MeasureString(Conversions.ToString(Upper[I]), Font);
                        UpperCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2f), R.Y + R.Height - S.Height - 2f);

                        S = TextGraphics.MeasureString(Conversions.ToString(Lower[I]), Font);
                        LowerCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2f), R.Y + R.Height - S.Height - 2f);
                    }
                }
            }

            Buttons[48] = new Rectangle(0, 4 * 32, 2 * 32, 32);
            Buttons[49] = new Rectangle(Buttons[48].Right, 4 * 32, 8 * 32, 32);
            Buttons[50] = new Rectangle(Buttons[49].Right, 4 * 32, 2 * 32, 32);
        }

        public GraphicsPath GP1;

        public SizeF SZ1;
        public PointF PT1;

        public Pen P1, P2, P3;
        public SolidBrush B1;

        public PathGradientBrush PB1;
        public LinearGradientBrush GB1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);

            Rectangle R;

            int Offset;
            ThemeModule.G.DrawRectangle(P1, 0, 0, 12 * 32 + 1, 5 * 32 + 1);

            for (int I = 0, loopTo = Buttons.Length - 1; I <= loopTo; I++)
            {
                R = Buttons[I];

                Offset = 0;
                if (I == Pressed)
                {
                    Offset = 1;

                    GP1 = new GraphicsPath();
                    GP1.AddRectangle(R);

                    PB1 = new PathGradientBrush(GP1);
                    PB1.CenterColor = Color.FromArgb(60, 60, 60);
                    PB1.SurroundColors = new[] { Color.FromArgb(55, 55, 55) };
                    PB1.FocusScales = new PointF(0.8f, 0.5f);

                    ThemeModule.G.FillPath(PB1, GP1);
                }
                else
                {
                    GB1 = new LinearGradientBrush(R, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0f);
                    ThemeModule.G.FillRectangle(GB1, R);
                }

                switch (I)
                {
                    case 48:
                    case 49:
                    case 50:
                        {
                            SZ1 = ThemeModule.G.MeasureString(Other[I - 48], Font);
                            ThemeModule.G.DrawString(Other[I - 48], Font, Brushes.Black, R.X + (R.Width / 2 - SZ1.Width / 2f) + Offset + 1f, R.Y + (R.Height / 2 - SZ1.Height / 2f) + Offset + 1f);
                            ThemeModule.G.DrawString(Other[I - 48], Font, Brushes.White, R.X + (R.Width / 2 - SZ1.Width / 2f) + Offset, R.Y + (R.Height / 2 - SZ1.Height / 2f) + Offset);
                            break;
                        }
                    case 47:
                        {
                            DrawArrow(Color.Black, R.X + Offset + 1, R.Y + Offset + 1);
                            DrawArrow(Color.White, R.X + Offset, R.Y + Offset);
                            break;
                        }

                    default:
                        {
                            if (Shift)
                            {
                                ThemeModule.G.DrawString(Conversions.ToString(Upper[I]), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                                ThemeModule.G.DrawString(Conversions.ToString(Upper[I]), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset);

                                if (!char.IsLetter(Lower[I]))
                                {
                                    PT1 = LowerCache[I];
                                    ThemeModule.G.DrawString(Conversions.ToString(Lower[I]), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                                }
                            }
                            else
                            {
                                ThemeModule.G.DrawString(Conversions.ToString(Lower[I]), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                                ThemeModule.G.DrawString(Conversions.ToString(Lower[I]), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset);

                                if (!char.IsLetter(Upper[I]))
                                {
                                    PT1 = UpperCache[I];
                                    ThemeModule.G.DrawString(Conversions.ToString(Upper[I]), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                                }
                            }

                            break;
                        }
                }

                ThemeModule.G.DrawRectangle(P2, R.X + 1 + Offset, R.Y + 1 + Offset, R.Width - 2, R.Height - 2);
                ThemeModule.G.DrawRectangle(P3, R.X + Offset, R.Y + Offset, R.Width, R.Height);

                if (I == Pressed)
                {
                    ThemeModule.G.DrawLine(P1, R.X, R.Y, R.Right, R.Y);
                    ThemeModule.G.DrawLine(P1, R.X, R.Y, R.X, R.Bottom);
                }
            }
        }

        public void DrawArrow(Color color, int rx, int ry)
        {
            var R = new Rectangle(rx + 8, ry + 8, 16, 16);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            var P = new Pen(color, 1f);
            var C = new AdjustableArrowCap(3f, 2f);
            P.CustomEndCap = C;

            ThemeModule.G.DrawArc(P, R, 0.0f, 290.0f);

            P.Dispose();
            C.Dispose();
            ThemeModule.G.SmoothingMode = SmoothingMode.None;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int Index = e.Y / 32 * 12 + e.X / 32;

            if (Index > 47)
            {
                for (int I = 48, loopTo = Buttons.Length - 1; I <= loopTo; I++)
                {
                    if (Buttons[I].Contains(e.X, e.Y))
                    {
                        Pressed = I;
                        break;
                    }
                }
            }
            else
            {
                Pressed = Index;
            }

            HandleKey();
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Pressed = -1;
            Invalidate();
        }

        public void HandleKey()
        {
            if (_Target is null)
                return;
            if (Pressed == -1)
                return;

            switch (Pressed)
            {
                case 47:
                    {
                        _Target.Text = string.Empty;
                        break;
                    }
                case 48:
                    {
                        Shift = !Shift;
                        break;
                    }
                case 49:
                    {
                        _Target.Text += " ";
                        break;
                    }
                case 50:
                    {
                        if (!(_Target.Text.Length == 0))
                        {
                            _Target.Text = _Target.Text.Remove(_Target.Text.Length - 1);
                        }

                        break;
                    }

                default:
                    {
                        if (Shift)
                        {
                            _Target.Text += Conversions.ToString(Upper[Pressed]);
                        }
                        else
                        {
                            _Target.Text += Conversions.ToString(Lower[Pressed]);
                        }

                        break;
                    }
            }
        }

    }

    [DefaultEvent("SelectedIndexChanged")]
   public class NSPaginator : Control
    {

        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

        public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);

        public Bitmap TextBitmap;
        public Graphics TextGraphics;

        public NSPaginator()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Size = new Size(202, 26);

            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);

            InvalidateItems();

            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
            B2 = new SolidBrush(Color.FromArgb(55, 55, 55));

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
            P3 = new Pen(Color.FromArgb(65, 65, 65));
        }

        public int _SelectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                _SelectedIndex = Math.Max(Math.Min(value, MaximumIndex), 0);
                Invalidate();
            }
        }

        public int _NumberOfPages;
        public int NumberOfPages
        {
            get
            {
                return _NumberOfPages;
            }
            set
            {
                _NumberOfPages = value;
                _SelectedIndex = Math.Max(Math.Min(_SelectedIndex, MaximumIndex), 0);
                Invalidate();
            }
        }

        public int MaximumIndex
        {
            get
            {
                return NumberOfPages - 1;
            }
        }

        public int ItemWidth;

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;

                InvalidateItems();
                Invalidate();
            }
        }

        public void InvalidateItems()
        {
            var S = TextGraphics.MeasureString("000 ..", Font).ToSize();
            ItemWidth = S.Width + 10;
        }

        public GraphicsPath GP1, GP2;

        public Rectangle R1;

        public Size SZ1;
        public Point PT1;

        public Pen P1, P2, P3;
        public SolidBrush B1, B2;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);
            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

            bool LeftEllipse, RightEllipse;

            if (_SelectedIndex < 4)
            {
                for (int I = 0, loopTo = Math.Min(MaximumIndex, 4); I <= loopTo; I++)
                {
                    RightEllipse = I == 4 && MaximumIndex > 4;
                    DrawBox(I * ItemWidth, I, false, RightEllipse);
                }
            }
            else if (_SelectedIndex > 3 && _SelectedIndex < MaximumIndex - 3)
            {
                for (int I = 0; I <= 4; I++)
                {
                    LeftEllipse = I == 0;
                    RightEllipse = I == 4;
                    DrawBox(I * ItemWidth, _SelectedIndex + I - 2, LeftEllipse, RightEllipse);
                }
            }
            else
            {
                for (int I = 0; I <= 4; I++)
                {
                    LeftEllipse = I == 0 && MaximumIndex > 4;
                    DrawBox(I * ItemWidth, MaximumIndex - (4 - I), LeftEllipse, false);
                }
            }
        }

        public void DrawBox(int x, int index, bool leftEllipse, bool rightEllipse)
        {
            R1 = new Rectangle(x, 0, ItemWidth - 4, Height - 1);

            GP1 = ThemeModule.CreateRound(R1, 7);
            GP2 = ThemeModule.CreateRound(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2, 7);

            string T = (index + 1).ToString();

            if (leftEllipse)
                T = ".. " + T;
            if (rightEllipse)
                T = T + " ..";

            SZ1 = ThemeModule.G.MeasureString(T, Font).ToSize();
            PT1 = new Point(R1.X + (R1.Width / 2 - SZ1.Width / 2), R1.Y + (R1.Height / 2 - SZ1.Height / 2));

            if (index == _SelectedIndex)
            {
                ThemeModule.G.FillPath(B1, GP1);

                var F = new Font(Font, FontStyle.Underline);
                ThemeModule.G.DrawString(T, F, Brushes.Black, PT1.X + 1, PT1.Y + 1);
                ThemeModule.G.DrawString(T, F, Brushes.White, PT1);
                F.Dispose();

                ThemeModule.G.DrawPath(P1, GP2);
                ThemeModule.G.DrawPath(P2, GP1);
            }
            else
            {
                ThemeModule.G.FillPath(B2, GP1);

                ThemeModule.G.DrawString(T, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
                ThemeModule.G.DrawString(T, Font, Brushes.White, PT1);

                ThemeModule.G.DrawPath(P3, GP2);
                ThemeModule.G.DrawPath(P1, GP1);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int NewIndex;
                int OldIndex = _SelectedIndex;

                if (_SelectedIndex < 4)
                {
                    NewIndex = e.X / ItemWidth;
                }
                else if (_SelectedIndex > 3 && _SelectedIndex < MaximumIndex - 3)
                {
                    NewIndex = e.X / ItemWidth;

                    switch (NewIndex)
                    {
                        case 2:
                            {
                                NewIndex = OldIndex;
                                break;
                            }
                        case var @case when @case < 2:
                            {
                                NewIndex = OldIndex - (2 - NewIndex);
                                break;
                            }
                        case var case1 when case1 > 2:
                            {
                                NewIndex = OldIndex + (NewIndex - 2);
                                break;
                            }
                    }
                }
                else
                {
                    NewIndex = MaximumIndex - (4 - e.X / ItemWidth);
                }

                if (NewIndex < _NumberOfPages && !(NewIndex == OldIndex))
                {
                    SelectedIndex = NewIndex;
                    SelectedIndexChanged?.Invoke(this, null);
                }
            }

            base.OnMouseDown(e);
        }

    }

    [DefaultEvent("Scroll")]
   public class NSVScrollBar : Control
    {

        public event ScrollEventHandler Scroll;

        public delegate void ScrollEventHandler(object sender);

        public int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;

                InvalidateLayout();
            }
        }

        public int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                    value = 1;

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;

                InvalidateLayout();
            }
        }

        public int _Value;
        public int Value
        {
            get
            {
                if (!ShowThumb)
                    return _Minimum;
                return _Value;
            }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                InvalidatePosition();

                Scroll?.Invoke(this);
            }
        }

        public double _Percent { get; set; }
        public double Percent
        {
            get
            {
                if (!ShowThumb)
                    return 0d;
                return GetProgress();
            }
        }

        public int _SmallChange = 1;
        public int SmallChange
        {
            get
            {
                return _SmallChange;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _SmallChange = value;
            }
        }

        public int _LargeChange = 10;
        public int LargeChange
        {
            get
            {
                return _LargeChange;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _LargeChange = value;
            }
        }

        public int ButtonSize = 16;
        public int ThumbSize = 24; // 14 minimum

        public Rectangle TSA;
        public Rectangle BSA;
        public Rectangle Shaft;
        public Rectangle Thumb;

        public bool ShowThumb;
        public bool ThumbDown;

        public NSVScrollBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Width = 18;

            B1 = new SolidBrush(Color.FromArgb(55, 55, 55));
            B2 = new SolidBrush(Color.FromArgb(35, 35, 35));

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
            P3 = new Pen(Color.FromArgb(55, 55, 55));
            P4 = new Pen(Color.FromArgb(40, 40, 40));
        }

        public GraphicsPath GP1, GP2, GP3, GP4;

        public Pen P1, P2, P3, P4;
        public SolidBrush B1, B2;

        public int I1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.Clear(BackColor);

            GP1 = DrawArrow(4, 6, false);
            GP2 = DrawArrow(5, 7, false);

            ThemeModule.G.FillPath(B1, GP2);
            ThemeModule.G.FillPath(B2, GP1);

            GP3 = DrawArrow(4, Height - 11, true);
            GP4 = DrawArrow(5, Height - 10, true);

            ThemeModule.G.FillPath(B1, GP4);
            ThemeModule.G.FillPath(B2, GP3);

            if (ShowThumb)
            {
                ThemeModule.G.FillRectangle(B1, Thumb);
                ThemeModule.G.DrawRectangle(P1, Thumb);
                ThemeModule.G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

                int Y;
                int LY = Thumb.Y + Thumb.Height / 2 - 3;

                for (int I = 0; I <= 2; I++)
                {
                    Y = LY + I * 3;

                    ThemeModule.G.DrawLine(P1, Thumb.X + 5, Y, Thumb.Right - 5, Y);
                    ThemeModule.G.DrawLine(P2, Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1);
                }
            }

            ThemeModule.G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);
            ThemeModule.G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3);
        }

        public GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            var GP = new GraphicsPath();

            int W = 9;
            int H = 5;

            if (flip)
            {
                GP.AddLine(x + 1, y, x + W + 1, y);
                GP.AddLine(x + W, y, x + H, y + H - 1);
            }
            else
            {
                GP.AddLine(x, y + H, x + W, y + H);
                GP.AddLine(x + W, y + H, x + H, y);
            }

            GP.CloseFigure();
            return GP;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
        }

        public void InvalidateLayout()
        {
            TSA = new Rectangle(0, 0, Width, ButtonSize);
            BSA = new Rectangle(0, Height - ButtonSize, Width, ButtonSize);
            Shaft = new Rectangle(0, TSA.Bottom + 1, Width, Height - ButtonSize * 2 - 1);

            ShowThumb = _Maximum - _Minimum > Shaft.Height;

            if (ShowThumb)
            {
                // ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
                Thumb = new Rectangle(1, 0, Width - 3, ThumbSize);
            }

            Scroll?.Invoke(this);
            InvalidatePosition();
        }

        public void InvalidatePosition()
        {
            Thumb.Y = (int)Math.Round(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (TSA.Contains(e.Location))
                {
                    I1 = _Value - _SmallChange;
                }
                else if (BSA.Contains(e.Location))
                {
                    I1 = _Value + _SmallChange;
                }
                else if (Thumb.Contains(e.Location))
                {
                    ThumbDown = true;
                    base.OnMouseDown(e);
                    return;
                }
                else if (e.Y < Thumb.Y)
                {
                    I1 = _Value - _LargeChange;
                }
                else
                {
                    I1 = _Value + _LargeChange;
                }

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ThumbDown && ShowThumb)
            {
                int ThumbPosition = e.Y - TSA.Height - ThumbSize / 2;
                int ThumbBounds = Shaft.Height - ThumbSize;

                I1 = (int)Math.Round(ThumbPosition / (double)ThumbBounds * (_Maximum - _Minimum)) + _Minimum;

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ThumbDown = false;
            base.OnMouseUp(e);
        }

        public double GetProgress()
        {
            return (_Value - _Minimum) / (double)(_Maximum - _Minimum);
        }

    }

    [DefaultEvent("Scroll")]
   public class NSHScrollBar : Control
    {

        public event ScrollEventHandler Scroll;

        public delegate void ScrollEventHandler(object sender);

        public int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;

                InvalidateLayout();
            }
        }

        public int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;

                InvalidateLayout();
            }
        }

        public int _Value;
        public int Value
        {
            get
            {
                if (!ShowThumb)
                    return _Minimum;
                return _Value;
            }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                InvalidatePosition();

                Scroll?.Invoke(this);
            }
        }

        public int _SmallChange = 1;
        public int SmallChange
        {
            get
            {
                return _SmallChange;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _SmallChange = value;
            }
        }

        public int _LargeChange = 10;
        public int LargeChange
        {
            get
            {
                return _LargeChange;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _LargeChange = value;
            }
        }

        public int ButtonSize = 16;
        public int ThumbSize = 24; // 14 minimum

        public Rectangle LSA;
        public Rectangle RSA;
        public Rectangle Shaft;
        public Rectangle Thumb;

        public bool ShowThumb;
        public bool ThumbDown;

        public NSHScrollBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Height = 18;

            B1 = new SolidBrush(Color.FromArgb(55, 55, 55));
            B2 = new SolidBrush(Color.FromArgb(35, 35, 35));

            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
            P3 = new Pen(Color.FromArgb(55, 55, 55));
            P4 = new Pen(Color.FromArgb(40, 40, 40));
        }

        public GraphicsPath GP1, GP2, GP3, GP4;

        public Pen P1, P2, P3, P4;
        public SolidBrush B1, B2;

        public int I1;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.Clear(BackColor);

            GP1 = DrawArrow(6, 4, false);
            GP2 = DrawArrow(7, 5, false);

            ThemeModule.G.FillPath(B1, GP2);
            ThemeModule.G.FillPath(B2, GP1);

            GP3 = DrawArrow(Width - 11, 4, true);
            GP4 = DrawArrow(Width - 10, 5, true);

            ThemeModule.G.FillPath(B1, GP4);
            ThemeModule.G.FillPath(B2, GP3);

            if (ShowThumb)
            {
                ThemeModule.G.FillRectangle(B1, Thumb);
                ThemeModule.G.DrawRectangle(P1, Thumb);
                ThemeModule.G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

                int X;
                int LX = Thumb.X + Thumb.Width / 2 - 3;

                for (int I = 0; I <= 2; I++)
                {
                    X = LX + I * 3;

                    ThemeModule.G.DrawLine(P1, X, Thumb.Y + 5, X, Thumb.Bottom - 5);
                    ThemeModule.G.DrawLine(P2, X + 1, Thumb.Y + 5, X + 1, Thumb.Bottom - 5);
                }
            }

            ThemeModule.G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);
            ThemeModule.G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3);
        }

        public GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            var GP = new GraphicsPath();

            int W = 5;
            int H = 9;

            if (flip)
            {
                GP.AddLine(x, y + 1, x, y + H + 1);
                GP.AddLine(x, y + H, x + W - 1, y + W);
            }
            else
            {
                GP.AddLine(x + W, y, x + W, y + H);
                GP.AddLine(x + W, y + H, x + 1, y + W);
            }

            GP.CloseFigure();
            return GP;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
        }

        public void InvalidateLayout()
        {
            LSA = new Rectangle(0, 0, ButtonSize, Height);
            RSA = new Rectangle(Width - ButtonSize, 0, ButtonSize, Height);
            Shaft = new Rectangle(LSA.Right + 1, 0, Width - ButtonSize * 2 - 1, Height);

            ShowThumb = _Maximum - _Minimum > Shaft.Width;

            if (ShowThumb)
            {
                // ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
                Thumb = new Rectangle(0, 1, ThumbSize, Height - 3);
            }

            Scroll?.Invoke(this);
            InvalidatePosition();
        }

        public void InvalidatePosition()
        {
            Thumb.X = (int)Math.Round(GetProgress() * (Shaft.Width - ThumbSize)) + LSA.Width;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (LSA.Contains(e.Location))
                {
                    I1 = _Value - _SmallChange;
                }
                else if (RSA.Contains(e.Location))
                {
                    I1 = _Value + _SmallChange;
                }
                else if (Thumb.Contains(e.Location))
                {
                    ThumbDown = true;
                    base.OnMouseDown(e);
                    return;
                }
                else if (e.X < Thumb.X)
                {
                    I1 = _Value - _LargeChange;
                }
                else
                {
                    I1 = _Value + _LargeChange;
                }

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ThumbDown && ShowThumb)
            {
                int ThumbPosition = e.X - LSA.Width - ThumbSize / 2;
                int ThumbBounds = Shaft.Width - ThumbSize;

                I1 = (int)Math.Round(ThumbPosition / (double)ThumbBounds * (_Maximum - _Minimum)) + _Minimum;

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ThumbDown = false;
            base.OnMouseUp(e);
        }

        public double GetProgress()
        {
            return (_Value - _Minimum) / (double)(_Maximum - _Minimum);
        }

    }

   public class NSContextMenu : ContextMenuStrip
    {

        public NSContextMenu()
        {
            Renderer = new ToolStripProfessionalRenderer(new NSColorTable());
            ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);
        }

    }

   public class NSColorTable : ProfessionalColorTable
    {

        public Color BackColor = Color.FromArgb(55, 55, 55);

        public override Color ButtonSelectedBorder
        {
            get
            {
                return BackColor;
            }
        }

        public override Color CheckBackground
        {
            get
            {
                return BackColor;
            }
        }

        public override Color CheckPressedBackground
        {
            get
            {
                return BackColor;
            }
        }

        public override Color CheckSelectedBackground
        {
            get
            {
                return BackColor;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return BackColor;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return BackColor;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return BackColor;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(25, 25, 25);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return BackColor;
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(65, 65, 65);
            }
        }

        public override Color SeparatorDark
        {
            get
            {
                return Color.FromArgb(35, 35, 35);
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return BackColor;
            }
        }

    }

    // If you have made it this far it's not too late to turn back, you must not continue on! If you are trying to fullfill some 
    // sick act of masochism by studying the source of the ListView then, may god have mercy on your soul.
    public class NSListView : Control
    {

        public class NSListViewItem
        {
            public string Text { get; set; }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public List<NSListViewSubItem> SubItems { get; set; } = new List<NSListViewSubItem>();

            protected Guid UniqueId;

            public NSListViewItem()
            {
                UniqueId = Guid.NewGuid();
            }

            public override string ToString()
            {
                return Text;
            }

            public override bool Equals(object obj)
            {
                if (obj is NSListViewItem)
                {
                    return ((NSListViewItem)obj).UniqueId == UniqueId;
                }

                return false;
            }

        }

        public class NSListViewSubItem
        {
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public class NSListViewColumnHeader
        {
            public string Text { get; set; }
            public int Width { get; set; } = 60;

            public override string ToString()
            {
                return Text;
            }
        }

        public List<NSListViewItem> _Items = new List<NSListViewItem>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NSListViewItem[] Items
        {
            get
            {
                return _Items.ToArray();
            }
            set
            {
                _Items = new List<NSListViewItem>(value);
                InvalidateScroll();
            }
        }

        public List<NSListViewItem> _SelectedItems = new List<NSListViewItem>();
        public NSListViewItem[] SelectedItems
        {
            get
            {
                return _SelectedItems.ToArray();
            }
        }

        public List<NSListViewColumnHeader> _Columns = new List<NSListViewColumnHeader>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NSListViewColumnHeader[] Columns
        {
            get
            {
                return _Columns.ToArray();
            }
            set
            {
                _Columns = new List<NSListViewColumnHeader>(value);
                InvalidateColumns();
            }
        }

        public bool _MultiSelect = true;
        public bool MultiSelect
        {
            get
            {
                return _MultiSelect;
            }
            set
            {
                _MultiSelect = value;

                if (_SelectedItems.Count > 1)
                {
                    _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);
                }

                Invalidate();
            }
        }

        public int ItemHeight = 24;
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                ItemHeight = (int)Math.Round(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6;

                if (VS is not null)
                {
                    VS.SmallChange = ItemHeight;
                    VS.LargeChange = ItemHeight;
                }

                base.Font = value;
                InvalidateLayout();
            }
        }

        #region  Item Helper Methods 

        // Ok, you've seen everything of importance at this point; I am begging you to spare yourself. You must not read any further!

        public void AddItem(string text, params string[] subItems)
        {
            var Items = new List<NSListViewSubItem>();
            foreach (string I in subItems)
            {
                var SubItem = new NSListViewSubItem();
                SubItem.Text = I;
                Items.Add(SubItem);
            }

            var Item = new NSListViewItem();
            Item.Text = text;
            Item.SubItems = Items;

            _Items.Add(Item);
            InvalidateScroll();
        }

        public void RemoveItemAt(int index)
        {
            _Items.RemoveAt(index);
            InvalidateScroll();
        }

        public void RemoveItem(NSListViewItem item)
        {
            _Items.Remove(item);
            InvalidateScroll();
        }

        public void RemoveItems(NSListViewItem[] items)
        {
            foreach (NSListViewItem I in items)
                _Items.Remove(I);

            InvalidateScroll();
        }

        #endregion

        private NSVScrollBar VS;

        public NSListView()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, true);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(35, 35, 35));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(62, 62, 62));
            B2 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B3 = new SolidBrush(Color.FromArgb(47, 47, 47));
            B4 = new SolidBrush(Color.FromArgb(50, 50, 50));

            VS = new NSVScrollBar();
            VS.SmallChange = ItemHeight;
            VS.LargeChange = ItemHeight;

            VS.Scroll += HandleScroll;
            VS.MouseDown += VS_MouseDown;
            Controls.Add(VS);

            InvalidateLayout();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        public void HandleScroll(object sender)
        {
            Invalidate();
        }

        public void InvalidateScroll()
        {
            VS.Maximum = _Items.Count * ItemHeight;
            Invalidate();
        }

        public void InvalidateLayout()
        {
            VS.Location = new Point(Width - VS.Width - 1, 1);
            VS.Size = new Size(18, Height - 2);

            Invalidate();
        }

        public int[] ColumnOffsets;
        public void InvalidateColumns()
        {
            int Width = 3;
            ColumnOffsets = new int[_Columns.Count];

            for (int I = 0, loopTo = _Columns.Count - 1; I <= loopTo; I++)
            {
                ColumnOffsets[I] = Width;
                Width += Columns[I].Width;
            }

            Invalidate();
        }

        public void VS_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();

            if (e.Button == MouseButtons.Left)
            {
                int Offset = (int)Math.Round(VS.Percent * (VS.Maximum - (Height - ItemHeight * 2)));
                int Index = (e.Y + Offset - ItemHeight) / ItemHeight;

                if (Index > _Items.Count - 1)
                    Index = -1;

                if (!(Index == -1))
                {
                    // TODO: Handle Shift key

                    if (ModifierKeys == Keys.Control && _MultiSelect)
                    {
                        if (_SelectedItems.Contains(_Items[Index]))
                        {
                            _SelectedItems.Remove(_Items[Index]);
                        }
                        else
                        {
                            _SelectedItems.Add(_Items[Index]);
                        }
                    }
                    else
                    {
                        _SelectedItems.Clear();
                        _SelectedItems.Add(_Items[Index]);
                    }
                }

                Invalidate();
            }

            base.OnMouseDown(e);
        }

        public Pen P1, P2, P3;
        public SolidBrush B1, B2, B3, B4;
        public LinearGradientBrush GB1;

        // I am so sorry you have to witness this. I tried warning you. ;.;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule.G = e.Graphics;
            ThemeModule.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            ThemeModule.G.Clear(BackColor);

            int X, Y;
            float H;

            ThemeModule.G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3);

            Rectangle R1;
            NSListViewItem CI;

            int Offset = (int)Math.Round(VS.Percent * (VS.Maximum - (Height - ItemHeight * 2)));

            int StartIndex;
            if (Offset == 0)
                StartIndex = 0;
            else
                StartIndex = Offset / ItemHeight;

            int EndIndex = Math.Min(StartIndex + Height / ItemHeight, _Items.Count - 1);

            for (int I = StartIndex, loopTo = EndIndex; I <= loopTo; I++)
            {
                CI = Items[I];

                R1 = new Rectangle(0, ItemHeight + I * ItemHeight + 1 - Offset, Width, ItemHeight - 1);

                H = ThemeModule.G.MeasureString(CI.Text, Font).Height;
                Y = R1.Y + (int)Math.Round(ItemHeight / 2d - (double)(H / 2f));

                if (_SelectedItems.Contains(CI))
                {
                    if (I % 2 == 0)
                    {
                        ThemeModule.G.FillRectangle(B1, R1);
                    }
                    else
                    {
                        ThemeModule.G.FillRectangle(B2, R1);
                    }
                }
                else if (I % 2 == 0)
                {
                    ThemeModule.G.FillRectangle(B3, R1);
                }
                else
                {
                    ThemeModule.G.FillRectangle(B4, R1);
                }

                ThemeModule.G.DrawLine(P2, 0, R1.Bottom, Width, R1.Bottom);

                if (Columns.Length > 0)
                {
                    R1.Width = Columns[0].Width;
                    ThemeModule.G.SetClip(R1);
                }

                // TODO: Ellipse text that overhangs seperators.
                ThemeModule.G.DrawString(CI.Text, Font, Brushes.Black, 10f, Y + 1);
                ThemeModule.G.DrawString(CI.Text, Font, Brushes.White, 9f, Y);

                if (CI.SubItems is not null)
                {
                    for (int I2 = 0, loopTo1 = Math.Min(CI.SubItems.Count, _Columns.Count) - 1; I2 <= loopTo1; I2++)
                    {
                        X = ColumnOffsets[I2 + 1] + 4;

                        R1.X = X;
                        R1.Width = Columns[I2].Width;
                        ThemeModule.G.SetClip(R1);

                        ThemeModule.G.DrawString(CI.SubItems[I2].Text, Font, Brushes.Black, X + 1, Y + 1);
                        ThemeModule.G.DrawString(CI.SubItems[I2].Text, Font, Brushes.White, X, Y);
                    }
                }

                ThemeModule.G.ResetClip();
            }

            R1 = new Rectangle(0, 0, Width, ItemHeight);

            GB1 = new LinearGradientBrush(R1, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0f);
            ThemeModule.G.FillRectangle(GB1, R1);
            ThemeModule.G.DrawRectangle(P3, 1, 1, Width - 22, ItemHeight - 2);

            int LH = Math.Min(VS.Maximum + ItemHeight - Offset, Height);

            NSListViewColumnHeader CC;
            for (int I = 0, loopTo2 = _Columns.Count - 1; I <= loopTo2; I++)
            {
                CC = Columns[I];

                H = ThemeModule.G.MeasureString(CC.Text, Font).Height;
                Y = (int)Math.Round(ItemHeight / 2d - (double)(H / 2f));
                X = ColumnOffsets[I];

                ThemeModule.G.DrawString(CC.Text, Font, Brushes.Black, X + 1, Y + 1);
                ThemeModule.G.DrawString(CC.Text, Font, Brushes.White, X, Y);

                ThemeModule.G.DrawLine(P2, X - 3, 0, X - 3, LH);
                ThemeModule.G.DrawLine(P3, X - 2, 0, X - 2, ItemHeight);
            }

            ThemeModule.G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1);

            ThemeModule.G.DrawLine(P2, 0, ItemHeight, Width, ItemHeight);
            ThemeModule.G.DrawLine(P2, VS.Location.X - 1, 0, VS.Location.X - 1, Height);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int Move = -(e.Delta * SystemInformation.MouseWheelScrollLines / 120 * (ItemHeight / 2));

            int Value = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum);
            VS.Value = Value;

            base.OnMouseWheel(e);
        }

    }
}

// Class NSMessageBox

// Public Shared Function ShowYesNo(text As String, caption As String) As DialogResult
// Dim F As Form = CreateDialog(text, caption)

// Dim B1 As New NSButton
// Dim B2 As New NSButton

// Dim S As New Size(90, 25)
// B1.Size = S
// B2.Size = S

// B1.Location = New Point(284, 119)
// B2.Location = New Point(188, 119)

// B1.Text = "Yes"
// B2.Text = "No"

// AddHandler B1.Click, Sub() F.DialogResult = DialogResult.Yes
// AddHandler B2.Click, Sub() F.DialogResult = DialogResult.No

// F.Controls(0).Controls.Add(B1)
// F.Controls(0).Controls.Add(B2)

// Return F.ShowDialog()
// End Function

// Public Shared Function ShowOk(text As String, caption As String) As DialogResult
// Dim F As Form = CreateDialog(text, caption)

// Dim B1 As New NSButton

// Dim S As New Size(90, 25)
// B1.Size = S

// B1.Location = New Point(284, 119)

// B1.Text = "Ok"

// AddHandler B1.Click, Sub() F.DialogResult = DialogResult.OK

// F.Controls(0).Controls.Add(B1)

// Return F.ShowDialog()
// End Function

// public Shared Function CreateDialog(text As String, caption As String) As Form
// Dim F As New Form

// Dim MTheme1 As New WindowsApplication1.NSTheme()
// Dim MControlButton1 As New WindowsApplication1.NSControlButton()
// Dim Label1 As New System.Windows.Forms.Label()

// MTheme1.Controls.Add(MControlButton1)
// MTheme1.Controls.Add(Label1)
// MTheme1.Sizable = False
// MTheme1.Size = New System.Drawing.Size(386, 156)
// MTheme1.Text = caption

// MControlButton1.ControlButton = WindowsApplication1.NSControlButton.Button.Close
// MControlButton1.Location = New System.Drawing.Point(360, 4)

// Label1.ForeColor = System.Drawing.Color.White
// Label1.Location = New System.Drawing.Point(12, 38)
// Label1.Size = New System.Drawing.Size(362, 78)
// Label1.Text = text

// F.StartPosition = FormStartPosition.CenterParent
// F.ClientSize = New System.Drawing.Size(386, 156)
// F.Controls.Add(MTheme1)
// F.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
// F.Text = caption

// Return F
// End Function

// End Class