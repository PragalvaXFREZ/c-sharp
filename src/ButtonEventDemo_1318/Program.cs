using System;

namespace ButtonEventDemo_1318
{
    // Lab 1, Q20: delegate + event. The original exercise asks for a
    // Windows Forms button, but WinForms only builds on Windows, so this
    // console version models the same pattern: a Button class raises a
    // Click event through a delegate, and a handler displays a message.
    public delegate void ClickHandler(object sender, EventArgs e);

    // The publisher: owns the event and raises it, just like a Forms button.
    public class Button
    {
        public event ClickHandler? Click;

        // Simulates the user clicking the button in the UI.
        public void PerformClick()
        {
            Console.WriteLine("Button was pressed...");
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class Program
    {
        // The subscriber: runs when the event is raised.
        private static void OnClick(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked! Event raised and message displayed.");
        }

        static void Main(string[] args)
        {
            Button button = new Button();
            button.Click += OnClick;   // subscribe the handler to the event

            Console.WriteLine("Press Enter to click the button.");
            Console.ReadLine();

            button.PerformClick();
        }
    }
}
