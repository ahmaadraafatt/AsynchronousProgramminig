# Multithreading Concepts in C# – Demo Projects

This repository contains a collection of C# console projects demonstrating essential multithreading concepts in .NET, including threads, thread pools, tasks, race conditions, deadlocks, and processor/thread behavior. Each project provides a practical example of common concurrency issues and solutions.

---

## Projects Overview

### 1. ThreadPool vs Task
Demonstrates the difference between using `ThreadPool` and `Task` for executing background operations.  
- `ThreadPool.QueueUserWorkItem(Print)` – schedules a method in the thread pool.  
- `Task.Run(Print)` – executes a method as a task.  
- Example includes calculating salary for an employee using a thread pool.  

**Key Concepts:**  
- ThreadPool, Task, Thread IDs, Background Threads, Thread Pool Threads.

---

### 2. Sequential Wallet Transactions
Simulates a wallet performing sequential credit and debit operations.  
- Random transactions are run on a single thread.  
- Shows how transaction amounts affect wallet balance.  

**Key Concepts:**  
- Sequential execution, thread processor info, wallet balance updates.

---

### 3. Race Condition Example
Demonstrates race conditions in multithreading.  
- Two threads attempt to debit money from the same wallet.  
- A `lock` is used to prevent inconsistent state.  

**Key Concepts:**  
- Race conditions, locking, `lock` keyword, thread safety.

---

### 4. Thread Properties and Basic Multithreading
Shows the properties of threads and how to create and start them.  
- Thread names, states, and joining threads.  
- Executes wallet transactions on separate threads.  

**Key Concepts:**  
- Thread states, joining threads, naming threads, background threads.

---

### 5. Deadlock Simulation
Simulates a deadlock scenario during money transfer between two wallets.  
- Two threads try to transfer funds simultaneously.  
- Demonstrates how locking order can prevent deadlocks.  

**Key Concepts:**  
- Deadlock, locking, transfer manager, Monitor.TryEnter, thread safety.

---

## Diagram

A high-level diagram of the Wallet and Threads interaction:

```mermaid
flowchart TD
    A[Main Thread] -->|Starts| B[Thread T1]
    A -->|Starts| C[Thread T2]
    B --> D[Wallet1 Debit/Credit]
    C --> E[Wallet2 Debit/Credit]
    D --> F[Wallet1 Balance]
    E --> G[Wallet2 Balance]

    subgraph Deadlock Scenario
        D --- E
    end

How to Run

### 1. Open the solution in Visual Studio.

### 2. Set the desired project as startup.

### 3. Build and run the project.

### 4. Observe the console output demonstrating thread behavior.

# Key Learning Points

Difference between ThreadPool and Task execution.

Sequential vs concurrent execution.

Race conditions and how lock prevents them.

Thread properties: Name, ID, IsBackground, ThreadState.

Deadlock detection and prevention techniques.
