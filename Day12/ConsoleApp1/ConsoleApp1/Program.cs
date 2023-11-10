using System;
public class Queue
{
    private int[] queueArray;
    private int currentPosition;

    public Queue(int size)
    {
        queueArray = new int[size];
        currentPosition = 0;
    }

    public void Enqueue(int value)
    {
        if (currentPosition < queueArray.Length)
        {
            queueArray[currentPosition] = value;
            currentPosition++;
        }
    }
    public void Dequeue()
    {
        if (currentPosition > 0)
        {
            for (int i = 0; i < currentPosition - 1; i++)
            {
                queueArray[i] = queueArray[i + 1];
            }
            currentPosition--;
        }
    }

    public void PrintQueue()
    {
        for (int i = 0; i < currentPosition; i++)
        {
            Console.WriteLine(queueArray[i]);
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        Queue myQueue = new Queue(N);

        for (int i = 0; i < N; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            myQueue.Enqueue(value);
        }

        myQueue.PrintQueue();
        Console.ReadLine();
    }
}



