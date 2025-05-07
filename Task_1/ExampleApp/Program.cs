using RandomNumberLibrary;

var generator = new RandomNumberGenerator();
var runner = new RandomNumberTimerRunner();

var stream = generator.GenerateInfinite(1, 1000);
runner.GenerateRandomNumbers(stream, intervalSeconds: 0.5, totalDurationSeconds: 5.0);