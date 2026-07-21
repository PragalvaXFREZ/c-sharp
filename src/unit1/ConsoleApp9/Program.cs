using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApp9
{
    // A custom delegate that our own event will use.
    public delegate void DelEventHandler();

    internal class Program : Form
    {
        // 'event' based on our custom delegate.
        public event DelEventHandler add;

        public Program()
        {
            // design a button over the form
            Button btn = new Button();
            btn.Parent = this;
            btn.Text = "Hit Me";
            btn.Location = new Point(100, 100);

            // built-in Click event -> onClcik handler
            btn.Click += new EventHandler(onClcik);

            // our custom event -> Initiate handler
            add += new DelEventHandler(Initiate);

            // invoke the event
            add();
        }

        private void Initiate()
        {
            Console.WriteLine("Event Initiated");
        }

        private void onClcik(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked me");
        }

        static void Main(string[] args)
        {
            Application.Run(new Program());
            Console.ReadLine();
        }
    }
}
