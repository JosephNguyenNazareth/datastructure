using System;
namespace DataBase {
    public class Node {
        public Node next;
        public Node prev;
        public int data;
        // public int number;
        public Node (int NewData) {
            data = NewData;
        }
        public Node () { }
    }
    public class LinkedList {
        public Node head;
        public Node current = new Node ();
        public void setList () {
            // read list of data from input
            Console.Write ("Enter list: ");
            string ReadAllLine = Console.ReadLine ();

            string EachValue = ""; // blank storing value in string
            int index = 0; // index of input character

            while (index < ReadAllLine.Length) {
                if (ReadAllLine[index] == ',') {
                    addLast (Convert.ToInt32 (EachValue)); // add new item to last position
                    EachValue = ""; // refresh the blank

                } else EachValue += ReadAllLine[index];
                index++;
            }
            addLast (Convert.ToInt32 (EachValue)); // add the last new item in string to last position
        }
        public void addLast (int NewData) {
            if (head == null) { // there is no head node yet
                head = new Node (NewData);
            } else if (head.next == null) { // there is only one node
                head.next = new Node ();
                current = head.next;
                current.data = NewData;
            } else if (current.next == null) { // the next node afterwards
                current.next = new Node ();
                current = current.next;
                current.data = NewData;
            }
        }
        public void addHead (int NewData) {
            // create a new head node
            Node HeadNode = new Node (NewData);
            if (head == null) { // there is no head node yet
                head = new Node (NewData);
            } else { // there is already a head node
                Node SecondValue = new Node ();
                SecondValue = head; // assign the original head node to temporary node
                head = HeadNode; // renew head node
                head.next = SecondValue; // pass the original linked list to new head node
            }
        }
        public void deleteNode (int RemoveData) {
            // bool for found the remove node
            bool found = false;
            Node Value = new Node ();
            // create this node for make link between the previous and the next of the removed node
            Node PrevValue = new Node ();
            // start searching with the head node
            Value = head;
            while (Value != null) {
                if (head.data == RemoveData) {
                    head = head.next; // new head node
                    found = true;
                    break;
                } else if (Value.data == RemoveData) {
                    PrevValue.next = Value.next; // make link between the previous and the next node
                    found = true;
                    break;
                }
                PrevValue = Value;
                Value = Value.next;
            }
            if (!found) Console.WriteLine ("Value not found. Cannot delete.");
        }
        public void deleteNode (int position, int quantity) {
            // create a variable for running through the list
            int index = 0;
            // bool for checking if having found the position of removed node
            bool match = false;
            // adding 1 before removing
            quantity++;
            // create a temporary node
            Node Value = new Node ();
            // create a temporary node for pointing the position of remain nodes
            Node PrevValue = new Node ();
            // now start finding node to delete!
            Value = head;
            while (Value != null) {
                if (position == 0) { // delete head node
                    match = true;
                } else if (position - index == 1) { // last position to keep
                    PrevValue = Value;
                    match = true;
                }
                if (match) quantity--; // start deletion
                if (quantity == 0) {
                    if (position == 0) head = Value.next;
                    else PrevValue.next = Value.next;
                    break;
                }
                Value = Value.next; // move to next node to delete
                index++;
            }
            if (index < position) Console.WriteLine ("Position not Found");
        }
        public void searchNode (int SearchData) {
            // set position index for node, with head node equal to 0
            int position = 0;
            bool found = false;
            // create temporary node for reading the whole list
            Node Value = new Node ();
            // start searching with the head node
            Value = head;
            while (Value.next != null) {
                if (Value.data == SearchData) {
                    Console.Write ("Found. Position: {0} ", position);
                    found = true;
                    break;
                }
                Value = Value.next;
                position++;
            }
            if (found == true) { } else if (Value.data == SearchData && found == false) Console.Write ("Found. Position: {0} ", position);
            else Console.Write ("Not found. No item match");
        }
        public void printList () {
            // create temporary node for reading the whole list
            Node Value = new Node ();
            // start printing with the head node
            Value = head;
            while (Value.next != null) {
                Console.Write ("{0}->", Value.data);
                Value = Value.next;
            }
            // last node
            Console.WriteLine ("{0}", Value.data);
        }
        public void printListReverse () {
            // create temporary node for reading the whole list backward from tail to head
            Node CurrValue = new Node ();
            // create temporary node for reading the whole list forward from head to CurrValue, which has been declared
            Node PrevValue = new Node ();

            // set CurrValue to the last position, the tail node
            CurrValue = current;

            // now start to read backwards
            while (CurrValue != head) {
                // assigned PrevValue to head node and begin running from head to CurrValue
                PrevValue = head;
                while (PrevValue.next != CurrValue) {
                    PrevValue = PrevValue.next; // move to next node
                }
                Console.Write ("{0}<-", CurrValue.data); // print the node backwards
                CurrValue = PrevValue; // move to previous node backwards
            }
            Console.WriteLine ("{0}", head.data); // print the "last" node backwards
        }
        public void listCentre () {
            Console.WriteLine ("Select your options: ");
            string option = Console.ReadLine ();
            // switch (Convert.ToInt16 (option))
        }
    }
    public class BinaryTree {
        public Node root;
        public int quantity = 0;
        public void insert (int NewData) {
            if (root == null) {
                root = new Node ();
                root.data = NewData;
                quantity = 1;
            } else insertNode (root, NewData);
        }
        public void insertNode (Node current, int NewData) {
            if (NewData < current.data) {
                if (current.prev == null) {
                    current.prev = new Node ();
                    current.prev.data = NewData;
                    quantity++;
                } else insertNode (current.prev, NewData);
            } else if (NewData > current.data) {
                if (current.next == null) {
                    current.next = new Node ();
                    current.next.data = NewData;
                    quantity++;
                } else insertNode (current.next, NewData);
            }
        }
        public void search (int SearchData) {
            if (searchNode (SearchData, root) == null) Console.WriteLine ("Not found.");
            else Console.WriteLine ("Found.");
        }
        public Node searchNode (int SearchData, Node current) {
            if (current == null) return null;
            else if (current.data == SearchData) return current;
            else if (current.data < SearchData) return searchNode (SearchData, current.next);
            else return searchNode (SearchData, current.prev);
        }
        public Node searchParent (int SearchData, Node parent) {
            if (root.data == SearchData) return null;
            else if (parent.data > SearchData) {
                if (parent.prev == null) return null;
                else if (parent.prev.data == SearchData) return parent;
                else return searchParent (SearchData, parent.prev);
            } else {
                if (parent.next == null) return null;
                else if (parent.next.data == SearchData) return parent;
                else return searchParent (SearchData, parent.next);
            }
        }
        public void delete (int RemoveData) {
            // there are five cases can occur:
            // case 0: the remove data is not available in BNT
            // case 1: the remove data is the leaf node
            // case 1s: the remove data is the only node
            // case 2: the remove data has left edge only
            // case 3: the remove data has right edge only
            // case 4: the remove data has both edges
            // now, let's check all cases

            Node RemoveNode = new Node ();
            RemoveNode = searchNode (RemoveData, root);

            // case 0
            if (RemoveNode == null) Console.WriteLine ("No item to delete");

            Node RemoveParent = new Node ();
            RemoveParent = searchParent (RemoveData, root);

            // case 1s
            if (RemoveParent == null) root = null;

            // case 1
            else if (RemoveNode.prev == null && RemoveNode.next == null) {
                if (RemoveNode.data < RemoveParent.data) RemoveParent.prev = null;
                else RemoveParent.next = null;
            }

            // case 2
            else if (RemoveNode.prev != null && RemoveNode.next == null) {
                if (RemoveNode.data < RemoveParent.data) RemoveParent.prev = RemoveNode.prev;
                else RemoveParent.next = RemoveNode.prev;
            }

            // case 3
            else if (RemoveNode.prev == null && RemoveNode.next != null) {
                if (RemoveNode.data < RemoveParent.data) RemoveParent.prev = RemoveNode.next;
                else RemoveParent.next = RemoveNode.next;
            }

            // case 4
            else if (RemoveNode.prev != null && RemoveNode.next != null) {
                Node LargestNode = new Node ();
                LargestNode = RemoveNode.prev;
                while (LargestNode.next != null) LargestNode = LargestNode.next;

                searchParent (LargestNode.data, RemoveParent).next = null;
                RemoveParent.data = LargestNode.data;
            }
        }
        public void print () {
            Node printNode = new Node ();
            printNode = root;
            while (printNode.prev != null) {
                Console.Write ("{0},", printNode.data);
                printNode = printNode.prev;
            }
        }
    }
    class Test {
        static void Main (string[] args) {
            /* LinkedList newList = new LinkedList ();
            newList.setList ();
            newList.deleteNode (2);
            newList.deleteNode (1,4);
            newList.printList (); */
            BinaryTree newTree = new BinaryTree ();
            newTree.insert (4);
            newTree.insert (6);
            newTree.insert (2);
            newTree.insert (9);
            newTree.insert (7);
            newTree.insert (1);
            newTree.insert (5);
            newTree.search (1);
            newTree.delete (1);
            newTree.search (1);

            Console.ReadKey ();
        }
    }
}