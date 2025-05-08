
# Infinite Generator and Timed Iterator

## 🔍 Overview  
**`RandomNumberGenerator`** — an infinite generator that produces random numbers within a specified range.  
**`RandomNumberTimerRunner`** — a timer-based runner that consumes numbers from the generator at fixed intervals and calculates their sum and average in real time.

## ✨ Key Features
- Infinite random number generation.
- Timed consumption with custom intervals.
- Real-time processing using `System.Timers` and `System.Diagnostics`.

## 💡 Example Output
```
Generating numbers for 10 seconds.

Random number: 30
Average: 30
Sum: 30

Random number: 448
Average: 239
Sum: 478

...

Time is over.
```

## 🧩 Technologies
- C#
- .NET Standard Libraries
- `System.Timers`, `System.Diagnostics`

## 📁 Structure

- **Library project**
  - `RandomNumberGenerator.cs`
  - `RandomNumberTimerRunner.cs`

- **Demo project**
  - `Program.cs` — example usage of the library
