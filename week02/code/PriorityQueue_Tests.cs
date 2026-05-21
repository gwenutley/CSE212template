using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 people to the queue 2 with the same priority and dequeue all of them, make sure high priority dequeues first and if they have the same then the first one enqued should be dequeued first
    // Expected Result: dequeue should return people in the order Tim, Sue, Bob, from highest to lowest priority
    // Defect(s) Found: items aren't removed from the queue after dequeing, and the check for highest priority skips that last item in the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 4);
        priorityQueue.Enqueue("Sue", 4);

        var person1 = priorityQueue.Dequeue();
        var person2 = priorityQueue.Dequeue();
        var person3 = priorityQueue.Dequeue();
        
        Assert.AreEqual("Tim", person1);
        Assert.AreEqual("Sue", person2);
        Assert.AreEqual("Bob", person3);
    }

    [TestMethod]
    // Scenario: try to dequeue from and empty queue
    // Expected Result: return an error with a message
    // Defect(s) Found: no problems
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => {
            priorityQueue.Dequeue();
        });
    }

    // Add more test cases as needed below.
}