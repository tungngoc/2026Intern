---

## ?? Assignment: **Library Management System (Console Application)**

### ?? Objectives

Practice the following OOP concepts in **C#**:

* Classes & Objects
* Encapsulation
* Inheritance
* Polymorphism
* Abstraction (abstract classes / interfaces)
* Basic collections (`List<T>`)

---

## ?? Problem Statement

Design a **Library Management System** where users can manage books and library members using object-oriented principles.

The system will run as a **console application**.

---

## ?? Requirements

### 1?? Base Class: `Person`

Create a base class called `Person` with:

* Properties:

  * `Id` (int)
  * `Name` (string)
* Method:

  * `DisplayInfo()` ? prints basic details

---

### 2?? Derived Classes

Create two classes that inherit from `Person`:

#### ?? `Student`

* Additional property:

  * `Grade` (string)
* Override `DisplayInfo()`

#### ?? `Librarian`

* Additional property:

  * `EmployeeNumber` (string)
* Override `DisplayInfo()`

---

### 3?? Abstract Class: `LibraryItem`

Create an **abstract class** `LibraryItem`:

* Properties:

  * `ItemId` (int)
  * `Title` (string)
* Abstract method:

  * `GetItemType()`

---

### 4?? Derived Classes from `LibraryItem`

#### ?? `Book`

* Additional property:

  * `Author` (string)
* Override `GetItemType()`

#### ?? `DVD`

* Additional property:

  * `Duration` (int in minutes)
* Override `GetItemType()`

---

### 5?? Encapsulation

* Make all fields `private`
* Use **public properties** with validation

  * Example: `Duration` cannot be negative

---

### 6?? Library Class

Create a `Library` class that:

* Stores a list of `LibraryItem`
* Has methods:

  * `AddItem(LibraryItem item)`
  * `RemoveItem(int itemId)`
  * `DisplayAllItems()`

Use **polymorphism** when displaying items.

---

### 7?? Program Execution (`Main`)

In `Main()`:

* Create at least:

  * 1 `Student`
  * 1 `Librarian`
  * 2 `Book`
  * 1 `DVD`
* Add items to the library
* Display all people and items

---

## ? Bonus Tasks (Optional)

* Add an `interface` called `IBorrowable`

  * Methods: `Borrow()`, `Return()`
* Implement it in `Book`
* Add a menu-driven system (Add / Remove / View items)


