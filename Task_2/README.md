# Task 2: Implementing a Memoization Function

## Description

This project implements a memoization function that caches the results of any pure function calls. This avoids redundant computations and improves performance. It also supports various cache eviction strategies when the cache reaches its capacity.

---

## Features

- 🔁 **Basic Memoization:** Caches results of pure function calls based on input arguments.
- 📦 **Configurable Cache:** Allows setting a maximum cache size.
- 🧹 **Cache Eviction Strategies:**
  - **LRU (Least Recently Used):** Removes the least recently accessed items.
  - **LFU (Least Frequently Used):** Removes the least frequently accessed items.
  - **Time-Based Expiry:** Expires items after a configurable time limit.
  - **Custom:** Allows users to define a custom eviction policy.

---

## Technologies Used

- **C#** 
- **System.Timers** 
- **Generics** 
- **LINQ** 

---
