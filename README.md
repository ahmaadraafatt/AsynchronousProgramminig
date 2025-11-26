Multithreading Concepts in C# – Educational Demo

This repository contains a collection of C# console projects demonstrating essential multithreading concepts in .NET, including threads, thread pools, tasks, race conditions, locking, deadlocks, and processor/thread behavior.

The goal of these projects is to provide clear, practical examples of how multithreading works and how to use it safely and efficiently.

📌 Projects Overview
1. ThreadPool vs Task

Demonstrates the difference between ThreadPool workers and Task-based asynchronous execution.
Includes examples of:

ThreadPool.QueueUserWorkItem

Passing objects/state to thread pool workers

Task.Run behavior

Checking thread metadata (ID, Name, IsBackground, IsThreadPoolThread)

Simple salary calculations using Employee

2. Sequential Transactions

Simple wallet system executed on one thread:

No concurrency → No race conditions

Demonstrates Processor ID + Thread ID logging

Shows correct behavior without synchronization

3. Race Condition Example

Two threads debit a wallet simultaneously without locking.
This produces inconsistent output and demonstrates why synchronization is necessary.

4. Locked Transaction

Safe version using:

lock

A shared _objectLock field

This ensures consistent values and correct behavior.

5. Process and Thread Info

Displays:

Process ID

Thread ID

Processor Core Number

Useful for understanding OS scheduling.

6. Basic Multithreading Example

Creates two threads transferring money:

Demonstrates thread naming

Thread states

Blocking with Join()

Randomized transactions

7. Deadlock Example

Realistic deadlock scenario:

Two wallets

Two transfers

Two threads locking in reverse order

Includes safe solution using ordered locking + optional Monitor.TryEnter.

📊 System Overview – ASCII Diagram
+-------------------------------------------------------------+
|                     Multithreading Samples                  |
+-------------------------------------------------------------+
         |                     |                       |
         |                     |                       |
         v                     v                       v

+-------------------+   +-------------------+   +---------------------+
|  ThreadPool Demo  |   |  Sequential Demo  |   | Race Condition Demo |
| - QueueUserWork   |   | - Single thread   |   | - No locks          |
| - Task.Run        |   | - Safe ops        |   | - Data corruption   |
+-------------------+   +-------------------+   +---------------------+
                                |                       |
                                v                       v

                      +--------------------+   +----------------------+
                      |   Locking Demo     |   |   Deadlock Demo      |
                      | - lock keyword     |   | - Wrong lock order   |
                      | - Safe access      |   | - Fixed version      |
                      +--------------------+   +----------------------+

                                 |
                                 v

                        +---------------------+
                        |  Thread & Process   |
                        | - IDs and Cores     |
                        | - Scheduling info   |
                        +---------------------+

📐 Mermaid Diagram (GitHub-rendered)
flowchart TD

A[Multithreading Samples] --> B[ThreadPool Demo]
A --> C[Sequential Transactions]
A --> D[Race Condition Demo]

C --> E[Locking Demo]
D --> F[Deadlock Demo]

A --> G[Process & Thread Info]

B:::node
C:::node
D:::node
E:::node
F:::node
G:::node

classDef node fill:#1f2937,stroke:#4b5563,stroke-width:1px,color:white,border-radius:6px;

💡 Key Concepts Demonstrated

Manual thread creation using Thread

ThreadPool worker execution

Tasks vs Threads

Race conditions and why they happen

Avoiding race conditions using lock

Deadlocks and safe locking patterns

ID logging (Thread, Process, CPU Core)

Passing state to worker threads

Background threads vs foreground threads

📚 Requirements

.NET 6 or later

Visual Studio / Rider / VS Code

🚀 How to Run

Open the solution → choose any project → Run.
All projects are independent and can be executed separately.

🤝 Contributions

This repository is open for extension. More demos like semaphores, mutexes, and parallel LINQ (PLINQ) can be added later.
