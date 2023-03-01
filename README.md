# IronChallenge

Inside this repository there's 2 projects:

* IronChallenge: contains the logic for translating keypad input to text
* IronChallengeTests: contains several unit tests

With regards to the IronChallenge project I've added a few more safeguards to ensure input is correct. For example I ensure the characters are all valid and the input string contains a hash. I also added a bit of documentation for clarity.

With regards to the tests project: initially it was saved outside the solution directory, of which I was unaware. So in a previous commit I moved the tests inside the solution directory. As with the IronChallenge project, I've added a few additional tests to ensure the input validation works as expected.

By the way, when developing I try to commit early & commit often. As such, you should be able to get a pretty decent idea of the steps that I followed in order to implement this project by just looking at the commit history.
