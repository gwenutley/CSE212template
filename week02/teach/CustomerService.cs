using System.IO.Pipes;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        

        // Test 1
        // Scenario: Test that the size of the queue is valid and if not it is set default to 10
        // Expected Result: Expect it will return 10, for the default size being 10
        Console.WriteLine("Test 1");
        var service = new CustomerService(-1);
        Console.WriteLine(service);

        // Defect(s) Found: no problems

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Test that a customer can be added and then served
        // Expected Result: expect for it to display the customer that was added
        Console.WriteLine("Test 2");
        service = new CustomerService(3);
        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found: required a change to the ServeCustomer method to get the customer before deleting from the list

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Check that when multiple customers are added that they are served in the correct order.
        // Expected Result: expect first customer added to be displayed first and then the next one
        Console.WriteLine("Test 3");
        service = new CustomerService(3);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");
        Console.WriteLine(service);

        // Defect(s) Found: no problems

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Make sure that a customer can be added normally when the queue is not full
        // Expected Result: return customer and then when full return an error message
        Console.WriteLine("Test 4");
        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine(service);

        // Defect(s) Found: queue size check was wrong, needed to do >= instead of > in AddNewCustomer 

        Console.WriteLine("=================");

        // Test 5
        // Scenario: make sure that an error is returned when the queue is empty and a customer is served
        // Expected Result: error message is returned when trying to serve a customer from an empty queue
        Console.WriteLine("Test 5");
        service = new CustomerService(2);
        service.ServeCustomer();
        Console.WriteLine(service);

        // Defect(s) Found: required a change to the ServeCustomer method to get the customer before deleting from the list

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        } else {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}