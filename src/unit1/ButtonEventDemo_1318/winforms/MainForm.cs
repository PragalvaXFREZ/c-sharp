// Q20 — the actual Windows Forms version from the lab report.
// This folder is excluded from the net8.0 build (WinForms doesn't exist on
// Linux .NET); run it with Mono instead, which implements WinForms on Linux:
//
//   sudo apt install -y mono-devel
//   mcs -r:System.Windows.Forms -r:System.Drawing src/unit1/ButtonEventDemo_1318/winforms/MainForm.cs -out:ButtonEventDemo.exe
//   mono ButtonEventDemo.exe
//
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ButtonEventDemo_1318
{
    // A delegate defines the shape of methods that can handle the event.
    public delegate void MessageHandler(string message);

    public class MainForm : Form
    {
        // The event is raised through the delegate when the button is clicked.
        public event MessageHandler OnMessage;

        public MainForm()
        {
            Text = "Delegate and Event Demo";

            Button button = new Button();
            button.Text = "Click Me";
            button.Location = new Point(100, 60);
            button.Parent = this;
            button.Click += Button_Click;

            OnMessage += ShowMessage;   // subscribe the handler to the event
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Button clicked -> raise the custom event through the delegate.
            OnMessage?.Invoke("Button Clicked! Event raised successfully.");
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Event Raised");
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}
