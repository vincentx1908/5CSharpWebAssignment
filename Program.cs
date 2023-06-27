public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Previous { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
}

public class DoublyLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public void InsertAtHead(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
    }

    public void InsertAtTail(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void InsertAtPosition(T data, int position)
    {
        if (position < 0)
        {
            throw new ArgumentException("Position cannot be negative");
        }

        if (position == 0)
        {
            InsertAtHead(data);
            return;
        }

        Node<T> newNode = new Node<T>(data);
        Node<T> current = head;
        int currentPosition = 0;

        while (current != null && currentPosition < position - 1)
        {
            current = current.Next;
            currentPosition++;
        }

        if (current == null)
        {
            throw new ArgumentException("Position exceeds the list length");
        }

        newNode.Previous = current;
        newNode.Next = current.Next;

        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }

        current.Next = newNode;

        if (newNode.Next == null)
        {
            tail = newNode;
        }
    }

    public void Delete(T data)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                return;
            }

            current = current.Next;
        }
    }

    public bool Contains(T data)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void Traverse()
    {
        Node<T> current = head;

        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}
