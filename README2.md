# Worksheet Eight 
## Behavioural Design Patterns — Part II

on the original GoF Behavioural Design Patterns

--

This worksheet is in two parts `README.md` (this file), and `README2.md`; this is solely so that the document is not too long, it could equally be one long document.

In these exercises we will be examining the following design patterns:

6. Memento 
7. Observer 
8. State
9. Strategy 
10. Template method 
11. Visitor

--
6. This question concerns the *Memento* design pattern.

	Sometimes it’s necessary to record the internal state of an object. 
	This is required when implementing checkpoints and “undo” mechanisms that let users back out of tentative operations or recover from errors. 
	You must save state information somewhere, so that you can restore objects to their previous conditions. 
	Objects normally encapsulate some or all of their state, making it inaccessible to other objects and impossible to save externally. 
	Exposing this state would violate encapsulation, which can compromise the application’s reliability and extensibility.

	The "Memento" design pattern can be used to accomplish this without exposing the object’s internal structure. 
	The object whose state needs to be captured is referred to as *the originator*.

	You will create a class that will contain two `double` type fields and we will run some mathematical operations on it. 
	We will provide users with an `undo` operation. 
	If the results after some operations are not satisfactory for a user, the user can call the `undo` operation which will restore the state of the object to the last saved point. (Please see the `Originator` class from the repository.)

	An instance of the `Originator` class should be saved in a memento. 
	The class contains two `double` type properties `x` and `y`, and also takes a reference to a `CareTaker`. 
	The `CareTaker` is used to *save* and *retrieve* the memento objects which represent the state of the `Originator` object.

	In the constructor, you should save the initial state of the object using the `CreateSavepoint` method.
	This method creates a memento object and requests the caretaker to take care of the object. 
	You should have a `LastUndoSavepoint` variable which is used to store the key name of last saved memento to implement the `undo` operation.

	The class provides three types of `undo` operations:
 	+ The `undo` method without any parameter restores the last saved state.
	+ The `undo` with the `Savepoint` name as a parameter restores the state saved with that particular `Savepoint` name.
	+ The `undoAll` method asks the caretaker to clear all the "savepoints" and reset to the initial state (the state at the time of the creation of the object).
	
	The `Memento` class is used to store the state of the `Originator` stored by the caretaker. 
	The class does not have any mutator methods; it is only used to retrieve the state of the object.
	The class contains 
	+ the `SaveMemento` method which is used to save the memento object, 
	+ the `Memento` method/property is used to return the request memento object, and 
	+ the `ClearSavepoints` method which is used to clear all the "savepoints" by deleting all the saved memento objects.
	
	Your code should pass the indicative tests from the `TestMementoPattern` class on the repository, producing the following output:
	```
	Saving state...INITIAL	Default State: X: 5.0, Y: 10.0	State: X: 510.0, Y: 10.0	Saving state...SAVE1	State: X: 510.0, Y: 23.181818181818183	Undo at ...SAVE1	State after undo: X: 510.0, Y: 10.0	Saving state...SAVE2	State: X: 1.32651E8, Y: 10.0	Saving state...SAVE3	State: X: 1.32651E8, Y: 1.3265097E8	Saving state...SAVE4	State: X: 1.32651E8, Y: 6029590.909090909	Undo at ...SAVE2	Retrieving at: X: 1.32651E8, Y: 10.0	Undo at ...INITIAL	Clearing all save points...	State after undo all: X: 5.0, Y: 10.0	
	```
	
7. This question concerns the *Observer* design pattern; you may see a strong relationship to `delegate`s and `event`s form `C#`. 
Nevertheless, it is useful to see how to implement this design pattern.

	*Sports Direction* is a sports website targeted at sport lovers. 
	They cover almost all kinds of sports and provide the latest news, information, matches scheduled dates, information about a particular player or a team. 
	Now, they are planning to provide live commentary or scores of matches as an SMS service, but only for their premium users. 
	Their aim is to send SMS messages of the live score, match situation, and important events after short intervals. 
	As a user, you need to subscribe to the package and when there is a live match you will receive an SMS to the 
	live commentary. 
	The site also provides an option to unsubscribe from the package whenever a user wants to.

	As a hot-shot developer, Sports Direction has asked you to provide this new feature for them. 
	The reporters of the Sports Direction will sit in the commentary box in the match, and they will update live commentary to a commentary object. 
	As a developer your job is to provide the commentary to the registered users by fetching it from the commentary object when it's available. 
	When there is an update, the system should update the subscribed users by sending them the SMS.
	This situation clearly indicates a *one-to-many* mapping between the match and the users, as there could be many users subscribed to a single match. 
	The *Observer* design pattern is best suited to this situation - you should implement this feature for 
	Sports Direction using the *Observer* pattern. 

	Recall that there are four participants in the *Observer* pattern:
	+ `ISubject` which is used to register observers. 
	Objects use this interface to register as observers and also to remove themselves from being observers.
	+ `IObserver` defines an updating interface for objects that should be notified of changes in a subject. 
	All observers need to implement the `Observer` interface. 
	This interface has a method `Update`, which is called when the `Subject`'s state changes.
	+ `ConcreteSubject` stores the state of interest to `ConcreteObserver` objects. 
	It sends a notification to its observers when its state changes. 
	A concrete subject always implements the `Subject` interface. 
	The `NotifyObservers` method is used to update all the current observers whenever the state changes.
	+ `ConcreateObserver` maintains a reference to a `ConcreteSubject` object and implements the `Observer` interface. 
	Each observer registers with a concrete subject to receive updates.
	
	The three key methods/properties in the `ISubject` interface:
	+ `SubscribeObserver`, which is used to subscribe observers; if there is a change in the state of the subject, all these observers should get notified.
	+ `UnSubscribeObserver`, which is used to unsubscribe observers so that if there is a change in the state of the subject, this unsubscribed observer should not get notified.
	+ `NotifyObservers`, this method notifies the registered observers when there is a change in the state of the subject.

	Optionally there is one more method `SubjectDetails`; it is a trivial method and is application specific.
	For this example its task is to return the details of the subject.
	
	Now, let’s examine the `IObserver` interface:
	+ `Update(string desc)` — called by the subject on the observer in order to notify it, when there is a change in the state of the subject.
	+ `Subscribe` — used to subscribe itself with the subject.
	+ `Unsubscribe` — used to unsubscribe itself with the subject.
	
	The `ICommentary` interface is used by the reporters to update the live commentary on the commentary object. 
	It’s an optional interface just to follow the *code to an interface* principle, and is not related to the *IObserver* pattern. 
	The interface contains only one method which is used to change the state of the concrete subject object.


	In general, **you should apply object-oriented programming principles along with the design patterns wherever applicable**. 
	
	We can test our implementations of:
	+ `CommentaryObject`
	+ `SMSUsers`
	+ etc.
	
	using the `TestObserver` class on the repository, which should produce the following output:
	```
	Subscribing Adam Warner [Manchester] to Football Match [2019MAR24] ...
	Subscribed successfully.

	Subscribing Tim Ronney [London] to Football Match [2019MAR24] ...
	Subscribed successfully.

	[Adam Warner [Manchester]]: Welcome to live football match
	[Tim Ronney [London]]: Welcome to live football match

	[Adam Warner [Manchester]]: Current score 0-0
    [Tim Ronney [London]]: Current score 0-0

	Unsubscribing Tim Ronney [London] to football Match [2019MAR24] ...
	Unsubscribed successfully.

	[Adam Warner [Manchester]]: It's a goal!!

	[Adam Warner [Manchester]]: Current score 1-0

	Subscribing Marrie [Paris] to football Match [2019MAR24] ...
	Subscribed successfully.

	[Adam Warner [Manchester]]: It's another goal!!
	[Marrie [Paris]]: It's another goal!!

	[Adam Warner [Manchester]]: Half-time score 2-0
	[Marrie [Paris]]: Half-time score 2-0
	```
	As you can see, at first two users subscribed themselves for the football match and started receiving the commentary. 
	Later on a user unsubscribed it, so the user did not receive the commentary again. 
	Then, another user subscribed and starts receiving the commentary.

8. This question concerns the *State* design pattern.

	To illustrate this design pattern you will help a company which wishes to build a robot for cooking. 
	The company wants a simple robot that can simply *walk* and *cook*. 
	A user can operate a robot using a set of commands via remote control. 
	Currently, a robot can do three things, it can 
	+ walk, 
	+ cook, or 
	+ can be switched off.

	The company has set protocols to define the functionality of the robot. 
	If a robot is in an **ON** state you can command it to walk. 
	If asked to cook, the state would change to **COOK** or if set to **OFF**, it will be switched off.

	Similarly, when in **COOK** state it can walk or cook, but cannot be switched off. 
	Finally, when in the **OFF** state it will automatically turn on and walk when the user commands it to walk but cannot cook in the **OFF** state.

	This might look like an easy implementation: a robot class with a set of methods like 
	+ `Walk`, 
	+ `Cook`, 
	+ `Off` 
	
	and states like 
	+ `ON`, 
	+ `COOK`, and 
	+ `OFF`. 
	
	We can use **if-else** branches, or **switches**, to implement the protocols set by the company. 
	Too many of these statements will create a maintenance nightmare as complexity might increase in the future.

	You might think that we can implement this without issues using *if-else* statements, but as a change comes the code would become more complex. 
	The requirement clearly shows that the behaviour of an object is truly based on the state of that object. 
	
	To achieve this you can use the *State* design pattern which encapsulates the states of the object, by using another individual class and keeps the context class independent of any state change.
	
	The `IRoboticState` interface contains the behaviour of a robot.
	The `Robot` class is a concrete class which implements the interface. 
	The class contains the set of all possible states a robot can be in (`Robot` on the repository).
	The class initialises all the states and sets the current state as `ON`.	We will examine all the concrete states of a robot:
	+ `RoboticOn`
	+ `RoboticCook`
	+ `RoboticOff`


	We can test the code using the `TestStatePattern` class which should result to the following output:
	```
	Walking...	Cooking...	Walking...	Robot is switched off	Walking...	Robot is switched off	Cannot cook at Off state.
	```
	
9. This question concerns the *Strategy* design pattern. 

	We are required to create a text formatter for a text editor. 
	A text editor can have different text formatters to format text. 
	We can create different text formatters and then pass the required one to the text editor, so that the editor will able to format the text as required.

	The text editor will hold a reference to a common interface for the text formatter and the editor's job will be to pass the text to the formatter to format the text. 
	You are required to implement this outline using the *Strategy* design pattern which will make the code flexible and maintainable.

	The `ITextFormatter` interface is implemented by all the concrete formatters.
	It contains only one method, `Format`, which is used to format the text.

	We can test this code using the `TestStrategyPattern` class which should result to the following output:
	```
	CapTextFormatter: TESTING TEXT IN CAPS FORMATTER
	LowerTextFormatter: testing text in lower formatter
	```		


10. This question concerns the *Template* design pattern and, as the name suggests, it provides a template, or a structure, for an algorithm which is used by users. 
	A user provides its own implementation without changing the algorithm’s structure.

	There will be many instances when you are required to connect to a relation database using a `C#` application (we will ignore the use of LINQ here). 
	There are some important steps which are required to connect and insert data into the database. 
	+ First, we need a driver according to the database we want to connect with. 
	+ Then, we pass some credentials to the database. 
	+ Then, we prepare a statement, set data into the insert statement, and insert it into the database. 
	+ Later, we close all the connections, and optionally destroy all the connection objects.

	You need to write all these steps regardless of any vendor’s relational database. 
	Consider a problem where you need to insert some data into different databases. 
	You need to fetch some data from a `CSV` file and have to insert it into a `MySQL` database. 
	Some data comes from a text file, which should be inserted into an Oracle database. 
	The only difference is the driver and the data, the rest of the steps are the same.

	We can create a template, which will perform some of the steps for the client, and we will leave some steps "open" to enable the client to implement them in its own specific way. 
	Optionally, a client can override the default behaviour of some already defined steps.
	The `ConnectionTemplate` class is the connection template class used to provide a template for clients to connect and communicate with the various databases. 

	The abstract class provides steps to connect, communicate and later, to close the connections. 
	All these steps are required to get the work done. 
	The class provides default implementation to some common steps and leaves the specific steps as abstract which forces the client to provide an implementation for them.

	The `DBDriver` property should be implemented by the user to provide database specific drivers. 
	The credentials could be different for different databases; therefore, `Credentials` is also left as abstract to let the user implement it.
	
	Similarly, connecting to the database using an API and preparing a statement, is common. 
	Data would be application specific, so the user will provide it, but the rest of other steps, like running an insert statement, closing connections, and destroying objects, are similar for any database, therefore their implementations are kept common inside the template.
	
	The key method of the above class is the `Run` method which is used to run these steps in order. 
	The method is set final because the steps should be kept safe and should not be change by any user.

	The two classes `MySqLCSVCon` and `OracleTxtCon` extend the template class and provide specific implementations for some methods.
	To test the code we can use the `TestTemplatePattern` class which should result in the following output:
	```
	For MYSQL....	Setting MySQL DB drivers...	Setting credentials for MySQL DB...	Setting connection...	Preparing insert statement...	Setting up data from csv file....	Inserting data...	Closing connections...	Destroying connection objects...
	For Oracle...	Setting Oracle DB drivers...	Setting credentials for Oracle DB...	Setting connection...	Preparing insert statement...	Setting up data from txt file....	Inserting data...	Closing connections...	Destroying connection objects...	
	```
	The above output clearly shows how the template pattern works to connect and communicate with the different databases, using a similar set of steps. 
	The pattern keeps the common code under one class and promotes code reusability. 
	It sets a framework and controls it for the users and allows users to extend the template to provide their specific implementation for some of the steps.

11. This question concerns the *Visitor* design pattern.

	Implementing the pattern requires two interfaces, an `IElement` interface which will contain an `Accept` method with an argument of type `IVisitor`. 
	This interface will be implemented by all the classes that need to allow visitors to visit them. 
	In our case, the class `HtmlTag` will implement the `IElement` interface, as the `HtmlTag` is the parent abstract class of all the concrete html classes, the concrete classes will inherit and will override the `Accept` method.
	The other important interface is the `IVisitor` interface; this interface will contain `Visit` methods with an argument of a class that implements the `IElement` interface. 
	We have also added two new properties to our `HtmlTag` class, the `StartTag` and `EndTag`. 


	The abstract `HtmlTag` class implements the `IElement` interface. 
	The concrete classes will override the `Accept` method of the `IElement` interface and will call the `Visit` method, and will pass this operator as an argument.
	This will allow the visitor method to get all the public members of the object, and to add new operations based on it; see the `HtmlParentElement` and `HtmlElement` classes from the repository.

	Now we consider the concrete visitor classes. 
	We have created two concrete classes, one will add a `css` class visitor to all html tags, and the other one will change the width of the tag using the `style` attribute of the html tag. (See the `CssClassVisitor` class.)
	
	We can test the code using the `TestVisitorPattern` class from the repository, which should produce the following output:
	```
	Before visitor.........
	<html>	<body>	<P>Testing html tag library</P>	<P>Paragraph 2</P>	</body>	</html>

	After visitor.......

	<html style='width:58px;' class='visitor'>	<body style='width:58px;' class='visitor'>	<p style='width:46px;' class='visitor'>Testing html tag library</P>	<p style='width:46px;' class='visitor'>Paragraph 2</P>	</body>	</html>	

	```