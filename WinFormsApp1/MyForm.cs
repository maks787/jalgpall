namespace WinFormsApp1
{
    public partial class MyForm : Form
    {
        Button btn;
        public MyForm()
        {
            //InitializeComponent();
            this.Height = 200;
            this.Width = 200;
            btn= new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text= "CLICk";
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);

            
        }
        public MyForm(int x,int y,string nimetus)
        {
            //InitializeComponent();
            this.Height = y;
            this.Width = x;
            this.Text= nimetus;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "CLICk";
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);
            btn.Click += Btn_Click;

        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            MyForm form = new MyForm();
            form.ShowDialog();
        }
    }
}