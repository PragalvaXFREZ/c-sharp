using System;

namespace EventExample
{
    // 1. A delegate defines the "shape" of methods that can handle the event.
    public delegate void OrderHandler(string product);

    // 2. The PUBLISHER: it owns the event and decides when to "raise" it.
    public class Store
    {
        // 'event' wraps the delegate so subscribers can only += / -=,
        // they cannot raise it or overwrite other subscribers.
        public event OrderHandler? OnOrderPlaced;

        public void PlaceOrder(string product)
        {
            Console.WriteLine($"Store: order placed for '{product}'.");

            // Raise the event. The ?.Invoke guards against "no subscribers".
            OnOrderPlaced?.Invoke(product);
        }
    }

    // 3. The SUBSCRIBERS: they react when the event fires.
    public class EmailService
    {
        public void SendConfirmation(string product)
        {
            Console.WriteLine($"Email: confirmation sent for '{product}'.");
        }
    }

    public class Warehouse
    {
        public void Ship(string product)
        {
            Console.WriteLine($"Warehouse: shipping '{product}'.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            var email = new EmailService();
            var warehouse = new Warehouse();

            // 4. Subscribe: hook the handlers onto the event.
            store.OnOrderPlaced += email.SendConfirmation;
            store.OnOrderPlaced += warehouse.Ship;

            // Fire it: both subscribers run automatically.
            store.PlaceOrder("Keyboard");

            Console.WriteLine();

            // 5. Unsubscribe one handler, then fire again.
            store.OnOrderPlaced -= warehouse.Ship;
            store.PlaceOrder("Mouse");

            Console.ReadLine();
        }
    }
}
