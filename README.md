# NumberGuessingGame
********************************
Уровень: Beginner
Тип: CLI
Технологии: C#, .NET9
Источник задания: (NumberGuessingGame)[https://roadmap.sh/projects/number-guessing-game]
Статус: завершён


Игра работает следующим образом:
- Когда игра начинается, на экране появляется приветственное сообщение с правилами игры.
- Компьютер случайным образом выбирает число от 1 до 100.
- Пользователь выбирает уровень сложности (легкий, средний, сложный), который будет определять количество шансов, которые он получит, чтобы угадать число.
- Пользователь может ввести свое предположение.
- Если догадка пользователя верна, игра выводит на экран поздравительное сообщение вместе с количеством попыток, которые потребовались, чтобы угадать это число.
- Если предположение пользователя неверно, в игре должно появиться сообщение, указывающее, больше или меньше число, чем предположил пользователь.
- Игра заканчивается, когда пользователь угадывает правильное число или у него заканчиваются шансы.

```shell
Welcome to the Number Guessing Game!
I'm thinking of a number between 1 and 100.
You have 5 chances to guess the correct number.

Please select the difficulty level:
1. Easy (10 chances)
2. Medium (5 chances)
3. Hard (3 chances)

Enter your choice: 2

Great! You have selected the Medium difficulty level.
Let's start the game!

Enter your guess: 50
Incorrect! The number is less than 50.

Enter your guess: 25
Incorrect! The number is greater than 25.

Enter your guess: 35
Incorrect! The number is less than 35.

Enter your guess: 30
Congratulations! You guessed the correct number in 4 attempts.
```
********************************
Level: Beginner
Type: CLI
Technology: C#, .NET9
Source: (NumberGuessingGame)[https://roadmap.sh/projects/number-guessing-game]
Stage: Done


The game work as follows:
- When the game starts, it display a welcome message along with the rules of the game.
- The computer randomly select a number between 1 and 100.
- User select the difficulty level (easy, medium, hard) which will determine the number of chances they get to guess the number.
- The user be able to enter their guess.
- If the user's guess is correct, the game display a congratulatory message along with the number of attempts it took to guess the number.
- If the user's guess is incorrect, the game should display a message indicating whether the number is greater or less than the user's guess.
- The game end when the user guesses the correct number or runs out of chances.

```shell
Welcome to the Number Guessing Game!
I'm thinking of a number between 1 and 100.
You have 5 chances to guess the correct number.

Please select the difficulty level:
1. Easy (10 chances)
2. Medium (5 chances)
3. Hard (3 chances)

Enter your choice: 2

Great! You have selected the Medium difficulty level.
Let's start the game!

Enter your guess: 50
Incorrect! The number is less than 50.

Enter your guess: 25
Incorrect! The number is greater than 25.

Enter your guess: 35
Incorrect! The number is less than 35.

Enter your guess: 30
Congratulations! You guessed the correct number in 4 attempts.
```