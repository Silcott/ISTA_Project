using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TrackITManagementSystem
{
    public partial class MyToolTip : ToolTip 
    {
        //Create MyCaption & Font properties
        public string MyCaption { get; set; }
        private Font Font { get; }
        public MyToolTip()
        {
            InitializeComponent();
            OwnerDraw = true;
            Draw += new DrawToolTipEventHandler(OnDraw);
            Popup += new PopupEventHandler(OnPopup);
        }
        public MyToolTip(IContainer Cont)
            : base(Cont)
        {
            OwnerDraw = true;
            Draw += new DrawToolTipEventHandler(OnDraw);
            Popup += new PopupEventHandler(OnPopup);
        }
        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Font tooltipFont = new Font("Segoe UI Black", 30.0f);
            DrawToolTipEventArgs newArgs = new DrawToolTipEventArgs(e.Graphics,
                e.AssociatedWindow,
                e.AssociatedControl,
                e.Bounds,
                e.ToolTipText,
                BackColor = Color.White,
                ForeColor = Color.White,//small number - don't show
                Font);
            newArgs.DrawBackground();
            newArgs.DrawBorder();
            newArgs.DrawText();
            e.Graphics.DrawString(e.ToolTipText, tooltipFont, Brushes.DarkSlateGray, new PointF(8, 0));
        }
        private void OnPopup(object sender, PopupEventArgs e)
        {
            //e.ToolTipSize = TextRenderer.MeasureText(MyCaption, Font);
            e.ToolTipSize = TextRenderer.MeasureText(MyCaption, new Font("Segoe UI Black", 32.0f, FontStyle.Bold));
        }
        public void SetControlToolTip(Control control, string caption)
        {
            MyCaption = caption;
            SetToolTip(control, caption);
        }

    }
}
