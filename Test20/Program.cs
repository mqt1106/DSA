using System;
using System.Collections.Generic;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    private Node head;

    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public LinkedList Concatenate(LinkedList otherList)
    {
        LinkedList result = new LinkedList();
        Node current = this.head;

        while (current != null)
        {
            result.Add(current.Data);
            current = current.Next;
        }

        current = otherList.head;
        while (current != null)
        {
            result.Add(current.Data);
            current = current.Next;
        }

        return result;
    }

    public LinkedList Difference(LinkedList otherList)
    {
        LinkedList result = new LinkedList();
        Node current = this.head;

        while (current != null)
        {
            if (!otherList.Contains(current.Data))
            {
                result.Add(current.Data);
            }
            current = current.Next;
        }

        return result;
    }

    public LinkedList Intersection(LinkedList otherList)
    {
        LinkedList result = new LinkedList();
        Node current = this.head;

        while (current != null)
        {
            if (otherList.Contains(current.Data))
            {
                result.Add(current.Data);
            }
            current = current.Next;
        }

        return result;
    }

    public LinkedList Union(LinkedList otherList)
    {
        LinkedList result = new LinkedList();
        Node current = this.head;

        while (current != null)
        {
            result.Add(current.Data);
            current = current.Next;
        }

        current = otherList.head;
        while (current != null)
        {
            if (!result.Contains(current.Data))
            {
                result.Add(current.Data);
            }
            current = current.Next;
        }

        return result;
    }

    public LinkedList Sum(LinkedList otherList)
    {
        LinkedList result = new LinkedList();
        Node current1 = this.head;
        Node current2 = otherList.head;

        while (current1 != null || current2 != null)
        {
            int sum = 0;
            if (current1 != null)
            {
                sum += current1.Data;
                current1 = current1.Next;
            }
            if (current2 != null)
            {
                sum += current2.Data;
                current2 = current2.Next;
            }
            result.Add(sum);
        }

        return result;
    }

    public bool Contains(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool HasCommonValues(LinkedList otherList)
    {
        Node current = this.head;
        while (current != null)
        {
            if (otherList.Contains(current.Data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void RemoveFirstGreaterThanSum(LinkedList otherList)
    {
        int sum = 0;
        Node current = otherList.head;

        while (current != null)
        {
            sum += current.Data;
            current = current.Next;
        }

        Node previous = null;
        current = this.head;

        while (current != null)
        {
            if (current.Data > sum)
            {
                if (previous == null)
                {
                    head = current.Next; // Xóa phần tử đầu
                }
                else
                {
                    previous.Next = current.Next; // Xóa phần tử giữa hoặc cuối
                }
                return;
            }
            previous = current;
            current = current.Next;
        }
    }

    public void RemoveAllMaxInList(LinkedList otherList)
    {
        if (otherList.head == null) return;

        int max = otherList.GetMax();

        Node current = head;
        Node previous = null;

        while (current != null)
        {
            if (current.Data == max)
            {
                if (previous == null)
                {
                    head = current.Next; // Xóa phần tử đầu
                }
                else
                {
                    previous.Next = current.Next; // Xóa phần tử giữa hoặc cuối
                }
            }
            else
            {
                previous = current;
            }
            current = current.Next;
        }
    }

    public int GetMax()
    {
        if (head == null) throw new InvalidOperationException("Danh sách rỗng");

        int max = head.Data;
        Node current = head.Next;

        while (current != null)
        {
            if (current.Data > max)
            {
                max = current.Data;
            }
            current = current.Next;
        }

        return max;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList L1 = new LinkedList();
        LinkedList L2 = new LinkedList();

        // Nhập danh sách L1
        Console.WriteLine("Nhập các phần tử cho danh sách L1 (nhập -1 để kết thúc):");
        while (true)
        {
            int value = int.Parse(Console.ReadLine());
            if (value == -1) break;
            L1.Add(value);
        }

        // Nhập danh sách L2
        Console.WriteLine("Nhập các phần tử cho danh sách L2 (nhập -1 để kết thúc):");
        while (true)
        {
            int value = int.Parse(Console.ReadLine());
            if (value == -1) break;
            L2.Add(value);
        }

        // a. Nối L2 vào sau L1
        LinkedList L3 = L1.Concatenate(L2);
        Console.WriteLine("Danh sách L3 (nối L1 và L2):");
        L3.Display();

        // b. Hiệu của L1 và L2
        L3 = L1.Difference(L2);
        Console.WriteLine("Danh sách L3 (hiệu của L1 và L2):");
        L3.Display();

        // c. Giao của L1 và L2
        L3 = L1.Intersection(L2);
        Console.WriteLine("Danh sách L3 (giao của L1 và L2):");
        L3.Display();

        // d. Hợp của L1 và L2
        L3 = L1.Union(L2);
        Console.WriteLine("Danh sách L3 (hợp của L1 và L2):");
        L3.Display();

        // e. Tổng giá trị các phần tử tương ứng
        L3 = L1.Sum(L2);
        Console.WriteLine("Danh sách L3 (tổng giá trị các phần tử tương ứng):");
        L3.Display();

        // f. Kiểm tra trùng giá trị
        bool hasCommon = L1.HasCommonValues(L2);
        Console.WriteLine("Hai danh sách L1 và L2 có trùng giá trị không? " + (hasCommon ? "Có" : "Không"));

        // g. Xóa phần tử lớn hơn tổng giá trị của L2
        L1.RemoveFirstGreaterThanSum(L2);
        Console.WriteLine("Danh sách L1 sau khi xóa phần tử lớn hơn tổng giá trị của L2:");
        L1.Display();

        // h. Xóa tất cả phần tử có giá trị lớn nhất trong L2
        L1.RemoveAllMaxInList(L2);
        Console.WriteLine("Danh sách L1 sau khi xóa tất cả phần tử có giá trị lớn nhất trong L2:");
        L1.Display();
    }
}
