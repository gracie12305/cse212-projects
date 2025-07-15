using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities, then dequeue
    // Expected Result: The item with the highest priority is returned.
    // Defect(s) Found: The oiginal loop missed the last item; fixed in dequeue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("June", 1);
        priorityQueue.Enqueue("July", 3);
        priorityQueue.Enqueue("August", 8);
        var result = priorityQueue.Dequeue();


        Assert.AreEqual("August", result); // Highest priority should be returned
    }

    [TestMethod]
    // Scenario: Add items with the same priority, then dequeue.
    // Expected Result: The first added item with the highest priority is returned.
    // Defect(s) Found: Have incorrectly returned the last of the same-priority.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 10);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result); // FIFO should return the first of the same priority
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items of mixed priorities and dequeue repeatedly.
    // Expected Result: Items come out in descending priority order, FIFO within same priority.
    // Defect(s) Found: Confirmed order after multiple dequeues.
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("purple", 1);
        priorityQueue.Enqueue("blue", 3);
        priorityQueue.Enqueue("orange", 2);
        priorityQueue.Enqueue("green", 3); // Same priority as blue

        Assert.AreEqual("blue", priorityQueue.Dequeue()); // FIFO
        Assert.AreEqual("green", priorityQueue.Dequeue());
        Assert.AreEqual("orange", priorityQueue.Dequeue());
        Assert.AreEqual("purple", priorityQueue.Dequeue());
    }


    // Add more test cases as needed below.
}