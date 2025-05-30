//******************************************************************
//**                                                              **
//**         STUDENT NAME : MUHAMMET BURAK ÖZYURT                 **
//**         STUDENT NUMBER: B231202062                           **
//**                                                              **
//******************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;

namespace b231202062
{
    public partial class Form1 : Form
    {
        private Polygon polygon;
        private Random random;      //reset butonu içerir

        private TextBox txtCenterX;           //metin kutuları
        private TextBox txtCenterY;
        private TextBox txtLength;
        private TrackBar trackBarRed;         //kaydırmaçubuğu
        private TrackBar trackBarGreen;
        private TrackBar trackBarBlue;
        private TextBox txtNumberOfEdges;   
        private TextBox txtRotationAngle;
        private ListBox listBoxVertices;
        private CheckBox checkBoxCCW;      //onay
        private PictureBox pictureBox;
        private Button btnDraw;             //butonlar
        private Button btnRotate;
        private Button btnReset;
        private Label lblCenterX;           //arayüzdeki etiketler
        private Label lblCenterY;
        private Label lblLength;
        private Label lblRed;
        private Label lblGreen;
        private Label lblBlue;
        private Label lblNumberOfEdges;
        private Label lblRotationAngle;

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();           //formun bileşenlerini serbest bırakır
            }
            base.Dispose(disposing);          //dispose metodunu çağırır
        }
        public Form1()
        {
            InitializeComponent();
            SetupAdditionalComponents();
            random = new Random();
            polygon = null;         //başlangıçta sıfır
        }
        private void SetupAdditionalComponents()
        {
            this.Text = "Proje";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;        //form kenarlarını sabitleştiirir
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblCenterX = new Label();
            lblCenterX.Text = "Center X:";
            lblCenterX.Location = new Point(20, 20);
            lblCenterX.Size = new Size(70, 20);
            this.Controls.Add(lblCenterX);              //etiketi forma ekler

            lblCenterY = new Label();
            lblCenterY.Text = "Center Y:";
            lblCenterY.Location = new Point(20, 50);
            lblCenterY.Size = new Size(70, 20);
            this.Controls.Add(lblCenterY);

            lblLength = new Label();
            lblLength.Text = "Length:";
            lblLength.Location = new Point(20, 80);
            lblLength.Size = new Size(70, 20);
            this.Controls.Add(lblLength);

            lblRed = new Label();
            lblRed.Text = "Red:";
            lblRed.Location = new Point(20, 110);
            lblRed.Size = new Size(70, 20);
            this.Controls.Add(lblRed);

            lblGreen = new Label();
            lblGreen.Text = "Green:";
            lblGreen.Location = new Point(20, 150);
            lblGreen.Size = new Size(70, 20);
            this.Controls.Add(lblGreen);

            lblBlue = new Label();
            lblBlue.Text = "Blue:";
            lblBlue.Location = new Point(20, 190);
            lblBlue.Size = new Size(70, 20);
            this.Controls.Add(lblBlue);

            lblNumberOfEdges = new Label();
            lblNumberOfEdges.Text = "Edges:";
            lblNumberOfEdges.Location = new Point(20, 240);
            lblNumberOfEdges.Size = new Size(70, 20);
            this.Controls.Add(lblNumberOfEdges);

            lblRotationAngle = new Label();
            lblRotationAngle.Text = "Angle:";
            lblRotationAngle.Location = new Point(20, 270);
            lblRotationAngle.Size = new Size(70, 20);
            this.Controls.Add(lblRotationAngle);

            txtCenterX = new TextBox();
            txtCenterX.Location = new Point(100, 20);
            txtCenterX.Size = new Size(50, 20);
            txtCenterX.Text = "0";
            this.Controls.Add(txtCenterX);

            txtCenterY = new TextBox();
            txtCenterY.Location = new Point(100, 50);
            txtCenterY.Size = new Size(50, 20);
            txtCenterY.Text = "0";
            this.Controls.Add(txtCenterY);

            txtLength = new TextBox();
            txtLength.Location = new Point(100, 80);
            txtLength.Size = new Size(50, 20);
            txtLength.Text = "4";
            this.Controls.Add(txtLength);

            trackBarRed = new TrackBar();
            trackBarRed.Location = new Point(100, 110);
            trackBarRed.Size = new Size(150, 30);
            trackBarRed.Minimum = 0;
            trackBarRed.Maximum = 255;
            trackBarRed.Value = 0;
            trackBarRed.TickStyle = TickStyle.None;
            this.Controls.Add(trackBarRed);

            trackBarGreen = new TrackBar();
            trackBarGreen.Location = new Point(100, 150);
            trackBarGreen.Size = new Size(150, 30);
            trackBarGreen.Minimum = 0;
            trackBarGreen.Maximum = 255;
            trackBarGreen.Value = 0;
            trackBarGreen.TickStyle = TickStyle.None;
            this.Controls.Add(trackBarGreen);

            trackBarBlue = new TrackBar();
            trackBarBlue.Location = new Point(100, 190);
            trackBarBlue.Size = new Size(150, 30);
            trackBarBlue.Minimum = 0;
            trackBarBlue.Maximum = 255;
            trackBarBlue.Value = 0;
            trackBarBlue.TickStyle = TickStyle.None;
            this.Controls.Add(trackBarBlue);

            txtNumberOfEdges = new TextBox();
            txtNumberOfEdges.Location = new Point(100, 240);
            txtNumberOfEdges.Size = new Size(50, 20);
            txtNumberOfEdges.Text = "5";
            this.Controls.Add(txtNumberOfEdges);

            txtRotationAngle = new TextBox();
            txtRotationAngle.Location = new Point(100, 270);
            txtRotationAngle.Size = new Size(50, 20);
            txtRotationAngle.Text = "30";
            this.Controls.Add(txtRotationAngle);

            listBoxVertices = new ListBox();
            listBoxVertices.Location = new Point(20, 300);
            listBoxVertices.Size = new Size(230, 200);
            this.Controls.Add(listBoxVertices);

            checkBoxCCW = new CheckBox();
            checkBoxCCW.Text = "CCW (Counter Clockwise)";
            checkBoxCCW.Location = new Point(20, 500);
            checkBoxCCW.Size = new Size(200, 20);
            checkBoxCCW.Checked = false;
            this.Controls.Add(checkBoxCCW);

            pictureBox = new PictureBox();
            pictureBox.Location = new Point(280, 20);
            pictureBox.Size = new Size(480, 480);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.BackColor = Color.White;
            this.Controls.Add(pictureBox);

            btnDraw = new Button();
            btnDraw.Text = "DRAW";
            btnDraw.Location = new Point(20, 530);
            btnDraw.Size = new Size(75, 30);
            btnDraw.Click += BtnDraw_Click;
            this.Controls.Add(btnDraw);

            btnRotate = new Button();
            btnRotate.Text = "ROTATE";
            btnRotate.Location = new Point(100, 530);
            btnRotate.Size = new Size(75, 30);
            btnRotate.Click += BtnRotate_Click;
            this.Controls.Add(btnRotate);

            btnReset = new Button();
            btnReset.Text = "RESET";
            btnReset.Location = new Point(180, 530);
            btnReset.Size = new Size(75, 30);
            btnReset.Click += BtnReset_Click;
            this.Controls.Add(btnReset);
        }
        private void BtnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                double centerX = Convert.ToDouble(txtCenterX.Text);
                double centerY = Convert.ToDouble(txtCenterY.Text);
                int length = Convert.ToInt32(txtLength.Text);
                int numberOfEdges = Convert.ToInt32(txtNumberOfEdges.Text);

                Point2D center = new Point2D(centerX, centerY);  ///merkezi gir

                ColorRGB color = new ColorRGB(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);  //rengi ayarlar

                polygon = new Polygon(center, length, color, numberOfEdges);      //çokgeni oluştur

                polygon.CalculateEdgeCoordinates();        //kenar kordinatlarını hesaplar

                DrawPolygon();

                UpdateVerticesList();       //köşe noktalarını günceller
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnRotate_Click(object sender, EventArgs e)
        {
            try
            {
                if (polygon == null)
                {
                    BtnDraw_Click(sender, e);    //eğer çokgen yoksa draw butonu gelir
                }

                double angle = Convert.ToDouble(txtRotationAngle.Text);

                if (angle < 0 || angle >= 360)              //açı kontrolü yapar
                {
                    MessageBox.Show("Rotation angle must be between 0 and 359 degrees.", "Invalid Angle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                           

                polygon.RotatePolygon(angle, checkBoxCCW.Checked);   //çokgeni döndürür

                DrawPolygon();

                UpdateVerticesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnReset_Click(object sender, EventArgs e)   
        {
            try
            {
                int randomCenterX = random.Next(0, 4);     //0 ile 3 arasında random değer atar
                int randomCenterY = random.Next(0, 4);     //0 ile 3 arasında random değer atar
                int randomLength = random.Next(3, 10);     //3 ile 9 arasında random değer atar
                int randomNumberOfEdges = random.Next(3, 11);  //3 ile 10 arasında random değer atar
                int randomRed = random.Next(0, 256);      //0 ile 255 arası random değer atar
                int randomGreen = random.Next(0, 256);     //0 ile 255 arası random değer atar
                int randomBlue = random.Next(0, 256);     //0 ile 255 arası random değer atar

                txtCenterX.Text = randomCenterX.ToString();
                txtCenterY.Text = randomCenterY.ToString();
                txtLength.Text = randomLength.ToString();
                txtNumberOfEdges.Text = randomNumberOfEdges.ToString();
                trackBarRed.Value = randomRed;
                trackBarGreen.Value = randomGreen;
                trackBarBlue.Value = randomBlue;

                Point2D center = new Point2D(randomCenterX, randomCenterY);

                ColorRGB color = new ColorRGB(randomRed, randomGreen, randomBlue);

                polygon = new Polygon(center, randomLength, color, randomNumberOfEdges);

                polygon.CalculateEdgeCoordinates();

                DrawPolygon();

                UpdateVerticesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DrawPolygon()
        {
            if (polygon == null || polygon.Vertices.Count == 0)
                return;

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);  //bitmap oluşturur

            using (Graphics g = Graphics.FromImage(bitmap))   //grafik oluşturur
            {
                g.Clear(Color.White);

                float scaleX = pictureBox.Width / 20f;
                float scaleY = pictureBox.Height / 20f;

                float originX = pictureBox.Width / 2f;
                float originY = pictureBox.Height / 2f;

                Pen axisPen = new Pen(Color.LightGray, 1);
                g.DrawLine(axisPen, 0, originY, pictureBox.Width, originY);  
                g.DrawLine(axisPen, originX, 0, originX, pictureBox.Height);

                Pen polygonPen = new Pen(polygon.Color.ToColor(), 2);

                PointF[] points = new PointF[polygon.Vertices.Count];

                for (int i = 0; i < polygon.Vertices.Count; i++)
                {                                             //kordinatları hesaplar
                    float screenX = originX + (float)polygon.Vertices[i].X * scaleX;  
                    float screenY = originY - (float)polygon.Vertices[i].Y * scaleY; 

                    points[i] = new PointF(screenX, screenY);
                }

                g.DrawPolygon(polygonPen, points);   //çokgeni çizer

                float centerX = originX + (float)polygon.Center.X * scaleX;      //merkezin kordinatları çizilir
                float centerY = originY - (float)polygon.Center.Y * scaleY; 
                g.FillEllipse(Brushes.Red, centerX - 3, centerY - 3, 6, 6);
            }
            pictureBox.Image = bitmap;
        }
        private void UpdateVerticesList()
        {
            if (polygon == null || polygon.Vertices.Count == 0)
                return;
            listBoxVertices.Items.Clear();

            for (int i = 0; i < polygon.Vertices.Count; i++)
            {
                string vertexText = $"V{i + 1} = {polygon.Vertices[i].PrintCoordinates()}";
                listBoxVertices.Items.Add(vertexText);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}