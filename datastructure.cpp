#include <iostream>
#include <string>

class Node {
public:
  Node *prev;
  Node *next;
  int data;
  Node() {
    next = 0;
    prev = 0;
  };
  Node(int newdata) : data(newdata) {
    next = 0;
    prev = 0;
  };
  ~Node(){};
};

class LinkedList {
public:
  Node *head = 0;
  Node *current = 0;
  unsigned int listSize = 0;
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
      current = new Node();
      current = head->next;
      current->data = NewData;
    } else if (current->next == NULL) { // the next node afterwards
      current->next = new Node();
      current = current->next;
      current->data = NewData;
    }
    listSize++;
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
    listSize++;
  }

  bool isNull() {
    if (this->head == NULL)
      return true;
    else
      return false;
  }

  int getMax() {
    Node *valueMax = new Node();
    valueMax = this->head;

    int max = 0;
    while (valueMax != NULL) {
      if (max < valueMax->data)
        max = valueMax->data;
      valueMax = valueMax->next;
    }
    return max;
  }

  int getMin() {
    Node *valueMin = new Node();
    valueMin = this->head;

    int min = valueMin->data;
    while (valueMin != NULL) {
      if (min > valueMin->data)
        min = valueMin->data;
      valueMin = valueMin->next;
    }
    return min;
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
    if (found)
      listSize--;
    else
      std::cout << "Value not found. Cannot delete." << std::endl;
  }
  void clear() {
    if (head != NULL)
      head = NULL;
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
      if (match) {
        quantity--; // start deletion
        listSize--;
      }
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

  void replaceNode(unsigned int position, int value) {
    Node *ReplaceValue = new Node();
    ReplaceValue = head;
    while (position > 0) {
      ReplaceValue = ReplaceValue->next;
      position--;
    }
    ReplaceValue->data = value;
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
  LinkedList Reverse() {
    LinkedList reverse;
    ReverseCore(reverse, this->head);
    return reverse;
  }
  void ReverseCore(LinkedList &reverse, Node *MyNode) {
    if (MyNode->next == NULL) { // base case: original linked list reach
                                // its end, start assign original last node
                                // to the new list
      // add node to new list
      reverse.addLast(MyNode->data);
      return;
    }
    // BACKTRACK
    ReverseCore(reverse, MyNode->next);
    // after each return, the node of the original list
    // will be assigned to the new list
    reverse.addLast(MyNode->data);
  }

  void Merge(LinkedList afterList) {
    this->current->next = afterList.head;
    this->listSize += afterList.listSize;
  }
  void size() { std::cout << "List size is: " << listSize << std::endl; }
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
  void printListReverse() { printReverse(head); }
  void printReverse(Node *MyNode) {
    if (MyNode == NULL)
      return;

    printReverse(MyNode->next);
    if (MyNode->data == head->data)
      std::cout << MyNode->data << std::endl;
    else
      std::cout << MyNode->data << "<-";
  }
  LinkedList &operator=(LinkedList assignData);
};

LinkedList &LinkedList::operator=(LinkedList assignData) {
  // clear all the list
  this->clear();

  // create temporary node for browsing all data
  Node *assign = new Node();

  // assign to the start of list
  assign = assignData.head;

  // begin to assgin
  while (assign != NULL) { // if the temoprary node is not NULL, which mean not
                           // reach the last node, keep assigning
    // add value to new Node
    this->addLast(assign->data);
    // move to next assigned node
    assign = assign->next;
  }
  // finally, return the assigned linked list
  return *this;
}

int main(int argc, char **argv) {
  LinkedList newList;
  newList.setList();
  std::cout << &(newList.head->next) << std::endl;
  newList.printListReverse();

  LinkedList secondList;
  secondList.addLast(100);
  secondList.addLast(10);
  secondList.addLast(1);

  newList.Merge(secondList);
  newList.printList();
  std::cout << newList.getMax() << "," << newList.getMin() << std::endl;

  LinkedList thirdList;
  thirdList = newList.Reverse();
  thirdList.printList();
  return 0;
}
