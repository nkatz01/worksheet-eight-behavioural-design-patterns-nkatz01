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
	This is required when implementing checkpoints and “undo” mechanisms that let users back out of 
	tentative operations or recover from errors. 
	You must save state information somewhere, so that you can restore objects to their previous conditions. 
	Objects normally encapsulate some or all of their state, making it inaccessible to other objects 
	and impossible to save externally. 
	Exposing this state would violate encapsulation, which can compromise the application’s 
	reliability and extensibility.

	The Memento design pattern can be used to accomplish this without exposing the object’s internal structure. 
	The object whose state needs to be captured is referred to as *the originator*.

	You will create a class that will contain two `double` type fields and we will run some 
	mathematical operations on it. 
	We will provide users with an `undo` operation. 
	If the results after some operations are not satisfactory for a user, 
	the user can call the `undo` operation which will restore the state of the object to the last saved point.
	(Please see the `Originator` class from the repository.)

	An instance of the `Originator` class should be saved in a memento. 
	The class contains two `double` type fields `x` and `y`, and also takes a reference to a `CareTaker`. 
	The `CareTaker` is used to *save* and *retrieve* the memento objects which represent the state of 
	the `Originator` object.

	In the constructor, you should save the initial state of the object using the `createSavepoint` method.
	This method creates a memento object and requests the caretaker to take care of the object. 
	You should use a `lastUndoSavepoint` variable which is used to store the key name of last saved memento 
	to implement the `undo` operation.

	The class provides three types of `undo` operations:
 	+ The `undo` method without any parameter restores the last saved state.
	+ The `undo` with the `savepoint` name as a parameter restores the state saved with that 
	particular `savepoint` name.
	+ The `undoAll` method asks the caretaker to clear all the savepoints and set it to the initial state 
	(the state at the time of the creation of the object).
	
	```java
	public class Memento {
		private double x;
		private double y;

		public Memento(double x, double y){
			this.x = x;
			this.y = y;
		}

		public double getX(){
			return x;
		}

		public double getY(){
			return y;
		}
	}
	```
	The `Memento` class is used to store the state of the `Originator` and stored by the caretaker. 
	The class does not have any setter methods; it is only used to get the state of the object.
	```java
	import java.util.HashMap;
	import java.util.Map;

	public class CareTaker {
		private final Map<String, Memento>savepointStorage = new HashMap<>();

		public void saveMemento(Memento memento,String savepointName){
			System.out.println("Saving state..."+savepointName);
			savepointStorage.put(savepointName, memento);
		}

		public Memento getMemento(String savepointName){
			System.out.println("Undo at ..."+savepointName);
			return savepointStorage.get(savepointName);
		}

		public void clearSavepoints(){
			System.out.println("Clearing all save points...");
			savepointStorage.clear();
		}
	}
	```
	The above class is the caretaker class used to store and provide the requested memento object. 
	The class contains 
	+ the `saveMemento` method is used to save the memento object, 
	+ the `getMemento` is used to return the request memento object, and 
	+ the `clearSavepoints` method which is used to clear all the savepoints and it deletes all 
	the saved memento objects.
	
	Your code should pass the indicative tests from the class `TestMementoPattern` on the repository.
	The code should produce the following output:
	```
	Saving state...INITIAL	Default State: X: 5.0, Y: 10.0	State: X: 510.0, Y: 10.0	Saving state...SAVE1	State: X: 510.0, Y: 23.181818181818183	Undo at ...SAVE1	State after undo: X: 510.0, Y: 10.0	Saving state...SAVE2	State: X: 1.32651E8, Y: 10.0	Saving state...SAVE3	State: X: 1.32651E8, Y: 1.3265097E8	Saving state...SAVE4	State: X: 1.32651E8, Y: 6029590.909090909	Undo at ...SAVE2	Retrieving at: X: 1.32651E8, Y: 10.0	Undo at ...INITIAL	Clearing all save points...	State after undo all: X: 5.0, Y: 10.0	
	```
	
7. This question concerns the *Observer* design pattern. 

	*Sports Lobby* is a sports website targeted at sport lovers. 
	They cover almost all kinds of sports and provide the latest news, 
	information, matches scheduled dates, information about a particular player or a team. 
	Now, they are planning to provide live commentary or scores of matches as an SMS service, 
	but only for their premium users. Their aim is to SMS the live score, match situation, 
	and important events after short intervals. As a user, you need to 
	subscribe to the package and when there is a live match you will get an SMS to the 
	live commentary. The site also provides an option to unsubscribe from the package 
	whenever a user wants to.

	As a developer, the Sport Lobby has asked you to provide this new feature for them. 
	The reporters of the Sport Lobby will sit in the commentary box in the match, and they will 
	update live commentary to a commentary object. As a developer your job is to 
	provide the commentary to the registered users by fetching it from the commentary 
	object when it's available. When there is an update, 
	the system should update the subscribed users by sending them the SMS.
	This situation clearly indicates a *one-to-many* mapping between the match and the users, 
	as there could be many users subscribed to a single match. The *Observer* design pattern 
	is best suited to this situation - you should implement this feature for 
	Sport Lobby using the *Observer* pattern. 

	Remember that there are four participants in the *Observer* pattern:
	+ `Subject` which is used to register observers. 
	Objects use this interface to register as observers and also to remove 
	themselves from being observers.
	+ `Observer` defines an updating interface for objects that should be notified of changes in a subject. 
	All observers need to implement the `Observer` interface. 
	This interface has a method `update()`, which gets called when the `Subject`'s state changes.
	+ `ConcreteSubject` stores the state of interest to `ConcreteObserver` objects. 
	It sends a notification to its observers when its state changes. 
	A concrete subject always implements the `Subject` interface. 
	The `notifyObservers()` method is used to update all the current observers whenever the state changes.
	+ `ConcreateObserver` maintains a reference to a `ConcreteSubject` object and implements the 
	`Observer` interface. Each observer registers with a concrete subject to receive updates.
	
	```java
	public interface Subject {

		public void subscribeObserver(Observer observer);
		public void unSubscribeObserver(Observer observer);
		public void notifyObservers();
		public String subjectDetails();
	}
	```
	The three key methods in the `Subject` interface are:
	+ `subscribeObserver`, which is used to subscribe observers or we can say register the observers so that if 
	there is a change in the state of the subject, all these observers should get notified.
	+ `unSubscribeObserver`, which is used to unsubscribe observers so that if there is a change in the state
	of the subject, this unsubscribed observer should not get notified.
	+ `notifyObservers`, this method notifies the registered observers when there is a change in the state 
	of the subject.

	And optionally there is one more method `subjectDetails()`, it is a trivial method and is 
	according to your need. Here, its job is to return the details of the subject.
	
	Now, let’s examine the `Observer` interface:
	```java
	public interface Observer {

		public void update(String desc);
		public void subscribe();
		public void unSubscribe();
	}
	```
	+ `update(String desc)`, method is called by the subject on the observer in order to notify it, 
	when there is a change in the state of the subject.
	+ `subscribe()`, method is used to subscribe itself with the subject.
	+ `unsubscribe()`, method is used to unsubscribe itself with the subject.
	
	```java
	public interface Commentary {
		public void setDesc(String desc);
	}
	```
	The above interface is used by the reporters to update the live commentary on the commentary object. 
	It’s an optional interface just to follow the *code to interface* principle, not related to the 
	*Observer* pattern. You should apply object-oriented programming principles along with the 
	design patterns wherever applicable. The interface contains only one method which is used 
	to change the state of the concrete subject object.
	
	We can test our implementations of:
	+ `CommentaryObject`
	+ `SMSUsers`
	+ etc.
	
	See the `TestObserver` class on the repository.


	It should produce the following output:
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
	As you can see, at first two users subscribed themselves for the football match and started 
	receiving the commentary. Later on a user unsubscribed it, so the user did not receive the commentary 
	again. Then, another user subscribed and starts receiving the commentary.

8. This question concerns the *State* design pattern.

	To illustrate this design pattern you will help a company which wishes to build a robot for cooking. 
	The company wants a simple robot that can simply *walk* and *cook*. 
	A user can operate a robot using a set of commands via remote control. 
	Currently, a robot can do three things, it can 
	1. walk, 
	2. cook, or 
	3. can be switched off.

	The company has set protocols to define the functionality of the robot. 
	If a robot is in an **on** state you can command it to walk. 
	If asked to cook, the state would change to **cook** or if set to **off**, it will be switched off.

	Similarly, when in **cook** state it can walk or cook, but cannot be switched off. 
	Finally, when in the **off** state it will automatically turn on and walk when the user commands 
	it to walk but cannot cook in the **off** state.

	This might look like an easy implementation: a robot class with a set of methods like 
	+ `walk`, 
	+ `cook`, 
	+ `off` 
	
	and states like 
	+ `on`, 
	+ `cook`, and 
	+ `off`. 
	
	We can use *if-else* branches, or *switches*, to implement the protocols set by the company. 
	Too many of these statements will create a maintenance nightmare as complexity might 
	increase in the future.

	You might think that we can implement this without issues using *if-else* statements, 
	but as a change comes the code would become more complex. 
	The requirement clearly shows that the behaviour of an object is truly based on the state of that object. 
	
	To achieve this you can use the *State* design pattern which encapsulates the states of the 
	object, by using another individual class and keeps the context class independent of any state change.
	
	The following is the interface which contains the behaviour of a robot:
	```java
	public interface RoboticState {
		public void walk();
		public void cook();
		public void off();
	}
	```
	The following class is a concrete class implements the interface. 
	The class contains the set of all possible states a robot can be in (`Robot` on the repository).
	The class initialises all the states and sets the current state as `on`.	Now, we will see all the concrete states of a robot. 
	A robot will be in one of these states at any time:
	+ `RoboticOn`
	+ `RoboticCook`
	+ `RoboticOff`


	We can test the code using the following:
	```java
	public class TestStatePattern {
		public static void main(String[] args) {
			Robot robot = new Robot();
			robot.walk();
			robot.cook();
			robot.walk();
			robot.off();

			robot.walk();
			robot.off();
			robot.cook();
		}	
	}
	```
	The above code should result to the following output:
	```
	Walking...	Cooking...	Walking...	Robot is switched off	Walking...	Robot is switched off	Cannot cook at Off state.
	```
	
9. This question concerns the *Strategy* design pattern. 

	Create a text formatter for a text editor. A text editor can have different text formatters to 
format text. We can create different text formatters and then pass the required one to the text editor, so that 
the editor will able to format the text as required.

	The text editor will hold a reference to a common interface for the text formatter and the editor's job 
	will be to pass the text to the formatter to format the text. You are required to implement this outline 
	using the *Strategy* design pattern which will make the code flexible and maintainable.

	Below is the `TextFormatter` interface which is implemented by all the concrete formatters, which
	contains only one method, `format`, used to format the text.
	```java
	public interface TextFormatter {	
		public void format(String text);
	}
	```
	Some sample test code might look like:
	```java
	public class TestStrategyPattern {
		public static void main(String[] args) {
		    TextFormatter formatter = new CapTextFormatter();
			TextEditor editor = new TextEditor(formatter);
			editor.publishText("Testing text in caps formatter");
		
			formatter = new LowerTextFormatter();
			editor = new TextEditor(formatter);
			editor.publishText("Testing text in lower formatter");
		}
	}
	```
	The above code should result to the following output:
	```
	CapTextFormatter: TESTING TEXT IN CAPS FORMATTER
	LowerTextFormatter: testing text in lower formatter
	```		


10. This question concerns the *Template* design pattern and, as the name suggests, 
	it provides a template or a structure of an algorithm which is used by users. 
	A user provides its own implementation without changing the algorithm’s structure.

	There will be many instances when you are required to connect to a relation database using a 
	Java application? 
	There are some important steps which are required to connect and insert data into the database. 
	First, we need a driver according to the database we want to connect with. 
	Then, we pass some credentials to the database, then, we prepare a statement, 
	set data into the insert statement and insert it using the insert command. 
	Later, we close all the connections, and optionally destroy all the connection objects.

	You need to write all these steps regardless of any vendor’s relational database. 
	Consider a problem where you need to insert some data into the different databases. 
	You need to fetch some data from a CSV file and have to insert it into a MySQL database. 
	Some data comes from a text file and which should be insert into an Oracle database. 
	The only difference is the driver and the data, the rest of the steps should be the same, 
	as JDBC provides a common set of interfaces to communicate to any vendor’s specific relation database.

	We can create a template, which will perform some steps for the client, 
	and we will leave some steps to let the client to implement them in its own specific way. 
	Optionally, a client can override the default behaviour of some already defined steps.

	Below we can see the connection template class used to provide a template for clients to connect 
	and communicate with the various databases. 
	```java
	public abstract class ConnectionTemplate {

		public final void run() {
			setDBDriver();
			setCredentials();
			connect();
			prepareStatement();
			setData();
			insert();
			close();
			destroy();
		}

		public abstract void setDBDriver();

		public abstract void setCredentials();

		public void connect() {
			System.out.println("Setting connection...");
		}

		public void prepareStatement() {
			System.out.println("Preparing insert statement...");
		}

		public abstract void setData();

		public void insert() {
			System.out.println("Inserting data...");
		}

		public void close() {
			System.out.println("Closing connections...");
		}

		public void destroy() {
			System.out.println("Destroying connection objects...");
		}
	}
	```
	The `abstract class` provides steps to connect, communicate and later to close the connections. 
	All these steps are required to get the work done. 
	The class provides default implementation to some common steps and leaves the specific steps 
	as abstract which force the client to provide an implementation to them.

	The `setDBDriver` method should be implemented by the user to provide database specific drivers. 
	The credentials could be different for different databases; therefore, `setCredentials` 
	is also left as abstract to let the user implement it.
	
	Similarly, connecting to the database using the JDBC API and preparing a statement is common. 
	Data would be specific so the user will provide it, and the rest of other steps, like running an 
	insert statement, closing connections, and destroying objects, are similar to any database, 
	therefore their implementations are kept common inside the template.
	
	The key method of the above class is the `run` method which is used to run these steps in order. 
	The method is set as `final` because the steps should be kept safe and should not be change by any user.

	The two classes below extend the template class and provide specific implementations to some methods:
	```java
	public class MySqLCSVCon extends ConnectionTemplate {

		@Override
		public void setDBDriver() {}

		@Override
		public void setCredentials() {}

		@Override
		public void setData() {}
	}
	```
	The above class is used to connect to a MySQL database and provides data by reading a CSV file.
	```java
	public class OracleTxtCon extends ConnectionTemplate {

		@Override
		public void setDBDriver() {}

		@Override
		public void setCredentials() {}

		@Override
		public void setData() {}
	}
	```
	The above class is used to connect to an Oracle database and provides data by reading a text file.
	
	Now, let’s test the code.
	```java
	public class TestTemplatePattern {
		public static void main(String[] args) {
			System.out.println("For MYSQL....");
			ConnectionTemplate template = new MySqLCSVCon();
			template.run();
			System.out.println("For Oracle...");
			template = new OracleTxtCon();
			template.run();
		}
	}
	```
	The above code should result in the following output:
	```
	For MYSQL....	Setting MySQL DB drivers...	Setting credentials for MySQL DB...	Setting connection...	Preparing insert statement...	Setting up data from csv file....	Inserting data...	Closing connections...	Destroying connection objects...
	For Oracle...	Setting Oracle DB drivers...	Setting credentials for Oracle DB...	Setting connection...	Preparing insert statement...	Setting up data from txt file....	Inserting data...	Closing connections...	Destroying connection objects...	
	```
	The above output clearly shows how the template pattern works to connect and communicate 
	with the different databases, using a similar set of steps. 
	The pattern keeps the common code under one class and promotes code reusability. 
	It sets a framework and controls it for the users and allows the users to extends the template 
	to provide their specific implementation to some of the steps.

11. This question concerns the *Visitor* design pattern.

	Implementing the pattern requires two interfaces, an `Element` interface which will contain an `accept` 
	method with an argument of type `Visitor`. 
	This interface will be implemented by all the classes that need 
	to allow visitors to visit them. 
	In our case, the class `HtmlTag`will implement the `Element` interface, as the 
	`HtmlTag` is the parent abstract class of all the concrete html classes, 
	the concrete classes will inherit and will override the `accept` 
	method of the `Element` interface.
	The other important interface is the `Visitor` interface; 
	this interface will contain `visit` methods with an argument of 
	a class that implements the `Element` interface. 
	Please also note that we have added two new methods in our `HtmlTag` class, 
	the `getStartTag` and `getEndTag`. 
	```java
	public interface Element {	
		public void accept(Visitor visitor);
	}
	```
	and
	```java
	public interface Visitor {
		public void visit(HtmlElement element);
		public void visit(HtmlParentElement parentElement);
	}
	```
	The supplemental classes are:
	```java
	import java.util.List;

	public abstract class HtmlTag implements Element{	
		public abstract String getTagName();
		public abstract void setStartTag(String tag);
		public abstract String getStartTag();
		public abstract String getEndTag();
		public abstract void setEndTag(String tag);
		public void setTagBody(String tagBody){
			throw new UnsupportedOperationException("Current operation is not support for this object");
		}
	
		public void addChildTag(HtmlTag htmlTag){
			throw new UnsupportedOperationException("Current operation is not support for this object");
		}
	
		public void removeChildTag(HtmlTag htmlTag){
			throw new UnsupportedOperationException("Current operation is not support for this object");
		}
	
		public List<HtmlTag>getChildren(){
			throw new UnsupportedOperationException("Current operation is not support for this object");
		}
	
		public abstract void generateHtml();
	}
	```
	The abstract `HtmlTag` class implements the `Element`interface. 
	The concrete classes below will override the `accept` method of the `Element` interface 
	and will call the `visit` method, and will pass this operator as an argument.
	This will allow the visitor method to get all the public members of the object, 
	and to add new operations based on it.
	Please see the `HtmlParentElement` and `HtmlElement` classes from the repository.

	Now we consider the concrete visitor classes. 
	We have created two concrete classes, one will add a css class visitor to all html tags, 
	and the other one will change the width of the tag using the `style` attribute of the html tag.
	```java
	public class CssClassVisitor implements Visitor{

		@Override
		public void visit(HtmlElement element) {
			element.setStartTag(element.getStartTag().replace(">", " class='visitor'>"));		
		}

		@Override
		public void visit(HtmlParentElement parentElement) {
			parentElement.setStartTag(parentElement.getStartTag().replace(">", " class='visitor'>"));
		}
	}
	```
	Now, let's test the code using the `TestVisitorPattern` class from the repository.
	The code should produce the following output:
	```
	Before visitor.........
	<html>	<body>	<P>Testing html tag library</P>	<P>Paragraph 2</P>	</body>	</html>

	After visitor.......

	<html style='width:58px;' class='visitor'>	<body style='width:58px;' class='visitor'>	<p style='width:46px;' class='visitor'>Testing html tag library</P>	<p style='width:46px;' class='visitor'>Paragraph 2</P>	</body>	</html>	

	```