// C# implementation

using System;
using System.Collections.Generic;

namespace G
{
    class Node
    {
        public Node next;
        public int value;
        public string name;
    }

    class LinkedList
    {
        private Node head;
        private Node current;
        public int NodeCount;

        public LinkedList()
        {
            head = new Node();
            current = head;
        }

        public void InsertNext(int value, string name)
        {
            Node newNode = new Node();
            newNode.value = value;
            newNode.name = name;
            current.next = newNode;
            current = newNode;
            NodeCount++;
        }

        public void PrintNodes()
        {
            Console.Write("Head->");
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
                Console.Write(current.name);
                Console.Write(current.value);
                Console.Write("->");
            }
            Console.WriteLine("NULL");
        }

        public int TraverseNodes(List<string> list)
        {
            // linked list i traverse et, en yakin noktayi bul
            // bu noktayi isaretli noktalar listesine ekle
            Node current = head;
            int minValue = 999999;

            while (current.next != null)
            {
                current = current.next;
                if (minValue > current.value && list.Contains(current.name) == false)
                {
                    minValue = current.value;
                    list.Add(current.name);
                }
            }
            return minValue;
        }
    }

    class Program
    {
        static List<string> visitedVertexList = new List<string>();
        static List<string> vertexList = new List<string> { "A", "B", "C", "D", "E", "F" };
        static int routeLength;

        static void Main(string[] args)
        {
            LinkedList A = new LinkedList();
            LinkedList B = new LinkedList();
            LinkedList C = new LinkedList();
            LinkedList D = new LinkedList();
            LinkedList E = new LinkedList();
            LinkedList F = new LinkedList();
            A.InsertNext(3, "B");
            A.InsertNext(1, "C");
            A.InsertNext(5, "D");
            B.InsertNext(3, "A");
            B.InsertNext(7, "F");
            B.InsertNext(13, "D");
            C.InsertNext(1, "A");
            C.InsertNext(2, "E");
            C.InsertNext(4, "D");
            C.InsertNext(6, "F");
            D.InsertNext(13, "B");
            D.InsertNext(5, "A");
            D.InsertNext(4, "B");
            D.InsertNext(6, "F");
            E.InsertNext(2, "C");
            E.InsertNext(12, "F");
            F.InsertNext(6, "C");
            F.InsertNext(7, "B");
            F.InsertNext(6, "D");
            F.InsertNext(12, "E");

            Dictionary<string, LinkedList> dict = new Dictionary<string, LinkedList>();
            dict.Add("A", A);
            dict.Add("B", B);
            dict.Add("C", C);
            dict.Add("D", D);
            dict.Add("E", E);
            dict.Add("F", F);

            Console.Write("Baslanacak noktayi giriniz: ");
            string startPoint = Console.ReadLine();
            visitedVertexList.Add(startPoint);
            FindShortestRoute(startPoint, dict,0);
            Console.WriteLine(routeLength);
            Console.ReadLine();

        }

        static void FindShortestRoute(string currentPoint, Dictionary<string, LinkedList> dict, int counter)
        {
            if (visitedVertexList.Count == 6)
            {
                return;
            }

            LinkedList currentLinkedList = dict[currentPoint];
            routeLength += currentLinkedList.TraverseNodes(visitedVertexList);
            counter++;
            FindShortestRoute(visitedVertexList[counter], dict, counter);
            Console.WriteLine(currentPoint);
        }
    }
}
