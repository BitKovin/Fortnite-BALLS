using WindowsInput;


namespace Fortnite_BALLS
{
    public partial class Form1 : Form
    {

        bool active = false;

        bool running = true;

        int targetX = 966;
        int targetY = 570;

        bool respawnClick = true;

        public Form1()
        {
            InitializeComponent();
            Task.Factory.StartNew(VisualLoop);
            Task.Factory.StartNew(KeyPressLoop);
        }

        InputSimulator simulator = new InputSimulator();

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            active = false;
            running = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            active = !active;

        }


        void KeyPressLoop()
        {

            while (running)
            {
                if (active == false) continue;
                simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);

                Thread.Sleep(1000);

                if (active == false) continue;
                simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);

                Thread.Sleep(200);

                if (active == false) continue;
                simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_S);

                Thread.Sleep(1000);

                if (active == false) continue;
                simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_S);

                Thread.Sleep(500);

                if (active == false) continue;
                simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.SPACE);

                Thread.Sleep(100);

                if (active == false) continue;
                simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.SPACE);

                Thread.Sleep(200);

                if (active == false) continue;
                ClickMouseAtLocation(targetX, targetY);

                Thread.Sleep(2000);

            }
        }

        void ClickMouseAtLocation(int x, int y)
        {
            if (respawnClick == false) return;
            int offsetY = -60;

            for (int i = 0; i < 10; i++)
            {
                if (active == false) continue;
                Cursor.Position = new Point(x, y + offsetY);
                Thread.Sleep(20);
                simulator.Mouse.LeftButtonClick();
                offsetY += 13;
                Thread.Sleep(10);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            label1.Text = Cursor.Position.X.ToString() + "  " + Cursor.Position.Y.ToString();
            label2.Text = active ? "RUNNING" : "not running";

            base.OnPaint(e);
        }

        void VisualLoop()
        {
            while (true)
            {


                this.Invalidate();

                Thread.Sleep(100);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out targetX);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out targetX);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            respawnClick = checkBox1.Checked;
        }
    }
}
