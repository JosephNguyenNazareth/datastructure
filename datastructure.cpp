#include <iostream>
#include <string>

class Node {
public:
  Node *prev;
  Node *next;
  int data;
  Node(){
	  next = 0;
	  prev= 0;
  };
  Node(int newdata) : data(newdata){
	  next = 0;
	  prev= 0;
  };
  ~Node(){};
};

class LinkedList {
public:
  Node *head = 0;
  Node *current = new Node();
  void setList() {
    // read list of data from input
    std::cout << "Enter list: ";
    std::string ReadAllLine;
    std::getline(std::cin, ReadAllLine);

    std::string EachValue = ""; // blank storing value in string
    int index = 0;              // index of input character

    while (ReadAllLine[index] != '\0') {
      if (ReadAllLine[index] == ',') {
        addLast(std::stoi(EachValue)); // add new item to last position
        EachValue = "";                // refresh the blank

      } else
        EachValue += ReadAllLine[index];
      index++;
    }
    addLast(std::stoi(
        EachValue)); // add the last new item in string to last position
  }
  void addLast(int NewData) {
    if (head == NULL) { // there is no head node yet
      head = new Node(NewData);
    } else if (head->next == NULL) { // there is only one node
      head->next = new Node();
      current = head->next;
      current->data = NewData;
    } else if (current->next == NULL) { // the next node afterwards
      current->next = new Node();
      current = current->next;
      current->data = NewData;
    }
  }
  void addHead(int NewData) {
    // create a new head node
    Node *HeadNode = new Node(NewData);
    if (head == NULL) { // there is no head node yet
      head = new Node(NewData);
    } else { // there is already a head node
      Node *SecondValue = new Node();
      SecondValue = head; // assign the original head node to temporary node
      head = HeadNode;    // renew head node
      head->next =
          SecondValue; // pass the original linked list to new head node
    }
  }
  void deleteNode(int RemoveData) {
    // bool for found the remove node
    bool found = false;
    Node *Value = new Node();
    // create this node for make link between the previous and the next of the
    // removed node
    Node *PrevValue = new Node();
    // start searching with the head node
    Value = head;
    while (Value != NULL) {
      if (head->data == RemoveData) {
        head = head->next; // new head node
        found = true;
        break;
      } else if (Value->data == RemoveData) {
        PrevValue->next =
            Value->next; // make link between the previous and the next node
        found = true;
        break;
      }
      PrevValue = Value;
      Value = Value->next;
    }
    if (!found)
      std::cout << "Value not found. Cannot delete." << std::endl;
  }
  void deleteNode(int position, int quantity) {
    // create a variable for running through the list
    int index = 0;
    // bool for checking if having found the position of removed node
    bool match = false;
    // adding 1 before removing
    quantity++;
    // create a temporary node
    Node *Value = new Node();
    // create a temporary node for pointing the position of remain nodes
    Node *PrevValue = new Node();
    // now start finding node to delete!
    Value = head;
    while (Value != NULL) {
      if (position == 0) { // delete head node
        match = true;
      } else if (position - index == 1) { // last position to keep
        PrevValue = Value;
        match = true;
      }
      if (match)
        quantity--; // start deletion
      if (quantity == 0) {
        if (position == 0)
          head = Value->next;
        else
          PrevValue->next = Value->next;
        break;
      }
      Value = Value->next; // move to next node to delete
      index++;
    }
    if (index < position)
      std::cout << "Position not Found" << std::endl;
  }
  void searchNode(int SearchData) {
    // set position index for node, with head node equal to 0
    int position = 0;
    bool found = false;
    // create temporary node for reading the whole list
    Node *Value = new Node();
    // start searching with the head node
    Value = head;
    while (Value->next != NULL) {
      if (Value->data == SearchData) {
        std::cout << "Found. Position: {0} " << position;
        found = true;
        break;
      }
      Value = Value->next;
      position++;
    }
    if (found == true) {
    } else if (Value->data == SearchData && found == false)
      std::cout << "Found. Position: {0} " << position;
    else
      std::cout << "Not found. No item match";
  }
  void printList() {
    // create temporary node for reading the whole list
    Node *Value = new Node();
    // start printing with the head node
    Value = head;
    while (Value->next != NULL) {
      std::cout << Value->data << "->";
      Value = Value->next;
    }
    // last node
    std::cout << Value->data << std::endl;
  }
  void printListReverse() {
    // create temporary node for reading the whole list backward from tail to
    // head
    Node *CurrValue = new Node();
    // create temporary node for reading the whole list forward from head to
    // CurrValue, which has been declared
    Node *PrevValue = new Node();

    // set CurrValue to the last position, the tail node
    CurrValue = current;

    // now start to read backwards
    while (CurrValue != head) {
      // assigned PrevValue to head node and begin running from head to
      // CurrValue
      PrevValue = head;
      while (PrevValue->next != CurrValue) {
        PrevValue = PrevValue->next; // move to next node
      }
      std::cout << CurrValue->data; // print the node backwards
      CurrValue = PrevValue;        // move to previous node backwards
    }
    std::cout << head->data; // print the "last" node backwards
  }
};

int main(int argc, char **argv) {
  LinkedList *newList = new LinkedList;
  newList->setList();
  /*newList->addLast(4);
  newList->addLast(5);
  newList->addLast(1);
  newList->addLast(2);
  newList->addLast(9);
  newList->addLast(7);
  */ newList->deleteNode(2);
  newList->deleteNode(1, 4);
  newList->printList();

  delete newList;

  return 0;
}