using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities, including a tie for the highest priority.
    // Expected Result: Items are dequeued in order of highest priority first. Tied priorities are dequeued in FIFO order.
    // Defect(s) Found: 1. Loop didn't check the last item. 2. Used >= instead of > causing ties to resolve LIFO instead of FIFO. 3. Dequeue didn't actually remove the item from the list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        // Enqueue items: Name, Priority
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("Mid", 2);
        priorityQueue.Enqueue("High2", 3);

        // Dequeue should return the highest priority first. Ties go to the first one added (FIFO).
        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Mid", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue an item from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None on this specific block. The exception was implemented correctly.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type caught: {e.GetType()}");
        }
    }
}