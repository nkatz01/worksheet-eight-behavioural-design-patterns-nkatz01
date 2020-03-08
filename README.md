# Worksheet Eight 
## Behavioural Design Patterns — Part I

on the original GoF Behavioural Design Patterns

--

In these exercises we will be examining the following design patterns:

1. Chain of Responsibility 
2. Command
3. Interpreter
4. Iterator
5. Mediator

--

1. This question concerns the *Chain of Responsibility* design pattern.

	Your company has won a contract to provide an analytical application to a health company. 
	The application should tell the user about a particular health problem, its history, its treatment, medicines, interview of the person suffering from it, etc.; basically everything that is required to know about it. 
	For this, your company receives a huge amount of data. 
	The data could be in any format, it could text files, doc files, excels, audio, images, videos, anything that you can think of would be there.

	Your task is to save this data in the company’s database. 
	Users will provide the data in any format and you should provide them a single interface to upload the data into the database. 
	The user is not interested, not even aware, to know that how you are saving the different unstructured data? 
	The problem here is that you need to develop different handlers to save the various formats of data. 
	For example, a text file save handler does not know how to save an mp3 file.

	To solve this problem you can use the "Chain of Responsibility" design pattern. 
	You can create different objects which process different formats of data and chain them together. 
	When a request comes to a single object, it will check whether it can process and handle the specific file format. 
	If it can, it will process it; otherwise, it will forward it to the next object chained to it. 
	This design pattern also decouples the user from the object that is serving the request; the user is not aware which object is actually serving its request.
	
	To implement the Chain of Responsibility (CoR) pattern to solve the above problem,  you will create an interface, `IHandler`.
	
	The `Handler` property is used to set the next handler in the chain, whereas; the `Process` method is used to process the request, but only if the handler is able process the request. 
	Optionally, we have the `HandlerName` property which is used to return the handler’s name. 
	The handlers are designed to process files which contain data. 
	The concrete handler checks if it’s able to handle the file by checking the file type, otherwise it forwards to the next handler in the chain.
	
	The `File` class creates simple file objects which contain the file name, file type, and the file path. 
	The file type would be used by the handler to check if the file can be handled by them or not. 
	If a handler can, it will process and save it, or it will forward it to the next handler in the chain.
	
	Your solution should satisfy the tests specified in the `TestChainOfResponsibility` class from the repository.
	The program should produce the following output:
	```
	Text Handler forwards request to Doc Handler
	Doc Handler forwards request to Excel Handler
	Excel Handler forwards request to Audio Handler
	Process and saving audio file... by Audio Handler

	Text Handler forwards request to Doc Handler
	Doc Handler forwards request to Excel Handler
	Excel Handler forwards request to Audio Handler
	Audio Handler forwards request to Video Handler
	Process and saving video file... by Video Handler

	Text Handler forwards request to Doc Handler
	Process and saving doc file... by Doc Handler

	Text Handler forwards request to Doc Handler
	Doc Handler forwards request to Excel Handler
	Excel Handler forwards request to Audio Handler
	Audio Handler forwards request to Video Handler
	Video Handler forwards request to Image Handler
	File not supported
	```
2. This question concerns the *Command* design pattern.

	You are required to create an application to execute different types of jobs. 
	A job can be anything in a system, for example, sending emails, SMS, logging, or performing some IO functions. 
	The Command pattern will help to decouple the invoker from a receiver and helps to execute any type of job without knowing its implementation. 
	We’ll make this example more interesting by creating threads which will help to execute these jobs concurrently. 
	As these jobs are independent of each other, so the sequence of execution of these jobs is not really important. 
	We will create a thread pool to limit the number of threads to execute jobs. 
	A command object will encapsulate jobs and will hand it over to a thread from the pool that will execute the job.
	
	The command object will be referenced by a common interface and will contain a method that will be used to execute the requests. 
	The concrete command classes will override that method and will provide their own specific implementation to execute the request.
	The `IJob` interface is the command interface, contains a single method `Run`, which is executed by a thread. 
	Our command’s `Execute` method is the `Run` method which will be used to execute by a thread to get the work done. 
	There would be different types of job that can be executed. 


	The implementation classes of the `IJob` interface hold a reference to their respective classes that will be used to carry out the task. 
	Each of the classes overrides the `Run` method and this details the work requested. 
	For example, the `SMSJob` class is used to send an sms. 
	Its `Run` method calls the `SendSMS` method of an `SMS` object to carry out the work.
	You can set different objects one by one to the same command object.
	
	For example, the `ThreadPool` class (from the repository) is used to create a pool of threads and allow a thread to fetch and execute the job from the job queue (worker threads).
	Each worker thread will wait for a job in a queue and then execute the job and then go back to a "waiting state". 
	The class contains a job queue; when a new job is added into the queue, a worker thread from the pool will execute the job.
	
	Your solution should satisfy the tests specified in the `TestCommandPattern` class from the repository.
	The code should result in (something like) the following output:
	```
	Job ID: 9 executing email jobs.
	Sending email.......
	Job ID: 12 executing logging jobs.
	Job ID: 17 executing email jobs.
	Sending email.......
	Job ID: 13 executing email jobs.
	Sending email.......
	Job ID: 10 executing sms jobs.
	Sending SMS...
	Job ID: 11 executing fileIO jobs.
	Executing File IO operations...
	Job ID: 18 executing sms jobs.
	Sending SMS...
	Logging...
	Job ID: 16 executing logging jobs.
	Logging...
	Job ID: 15 executing fileIO jobs.
	Executing File IO operations...
	Job ID: 14 executing sms jobs.
	Sending SMS...
	Job ID: 12 executing fileIO jobs.
	Executing File IO operations...
	Job ID: 10 executing logging jobs.
	Logging...
	Job ID: 18 executing email jobs.
	Sending email.......
	Job ID: 16 executing sms jobs.
	Sending SMS...
	Job ID: 14 executing fileIO jobs.
	Executing File IO operations...
	Job ID: 9 executing logging jobs.
	Logging...
	Job ID: 17 executing email jobs.
	Sending email.......
	Job ID: 13 executing sms jobs.
	Sending SMS...
	Job ID: 15 executing fileIO jobs.
	Executing File IO operations...
	Job ID: 11 executing logging jobs.
	Logging...

	```
	Due to the nature of concurrency the output may differ on subsequent executions.	
	
3. This question concerns the *Interpreter* design pattern.

	Given a language, provide a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.

	In general, languages are made up of a set of grammar rules. 
	Different sentences can be constructed by following these grammar rules. 
	Sometimes an application may need to process repeated occurrences of similar requests that are a combination of a set of grammar rules. 
	These requests are distinct but are similar in the sense that they are all composed using the same set of rules.

	A simple example of this would be the set of different arithmetic expressions submitted to a calculator program.
	Though each such expression is different, they are all constructed using the basic rules that comprise the grammar for the language of arithmetic expressions.

	In such cases, instead of treating every distinct combination of rules as a separate case, it may be beneficial for the application to have the ability to interpret a generic combination of rules. 
	The "Interpreter pattern" can be used to design this ability in an application so that other applications and users can specify operations using a simple language defined by a set of grammar rules.

	A class hierarchy can be designed to represent the set of grammar rules with every class in the hierarchy representing a separate grammar rule. 
	An Interpreter module can be designed to interpret the sentences constructed using the class hierarchy designed above and carries out the necessary operations.

	As a different class represents every grammar rule, the number of classes increases inline with the number of grammar rules. 
	A language with extensive, complex grammar rules requires a large number of classes. 
	The Interpreter pattern works best when the grammar is simple. 
	Having a simple grammar avoids the need to have many classes corresponding to the complex set of rules involved, which are hard to manage and maintain.

	Consider the interface specification `IExpression`, available from the repository, which is used by all the different concrete implementations of the expressions.
	The concrete implementations override the `Interpret` method to define their specific operation on the expression. 
	You need to complete the operation specific expression classes for `Add` and `Product` (`Add.cs` and `Product.cs`).

	Your solution should satisfy the tests specified in the `TestInterpreterPattern` class from the repository. 
	The tests should produce the following output:
	```
	( 7 3 -2 1 + * ):12
	```
	Please note that we are using [postfix notation](Postfix.md).
	
	In the example class, we declare a postfix of an expression in the `tokenString` variable. 
	Then we split the `tokenString` and assign it into an array, the `tokenArray`. 
	While iterating tokens one by one, first we have to check whether the token is an operator or an operand. 
	If the token is an *operand* we push it onto the stack, but if it is an *operator* we pop the first two operands from the stack. 

	`Operation` returns the appropriate expression class according to the operator passed to it. 
	We next interpret the result and push it back onto the stack. 
	After iterating over the complete `tokenList` we can obtain the final result.
	
4. 	This question concerns the *Iterator* design pattern which you are going to explore using a `Shape` class. 
	We will store and iterate through the `Shape` objects using an iterator (see `Shape.cs`).
	The simple `Shape` class has an `Id` and `Name` as its properties.

	We also have a `ShapeStorage` class which is used to store the `Shape` objects. 
	The class contains an array of `Shape` type; for simplicity we have initialised that array.
	The `AddShape` method is used to add a `Shape` object to the array and increment the index by one. 
	The `GetShapes` method returns an array of `Shape` type.
	
	The `ShapeIterator` class is an `Iterator` for the `Shape` class.
	The `HasNext` method returns a boolean if there’s an item left in the storage structure.
	The `Next` method returns the next item from the collection, and the `Remove` method removes the current item from the collection.
	
	You should test your code using the `TestIteratorPattern` from the repository, which should produce the following output:
	```
	ID: 0 Shape: Polygon	ID: 1 Shape: Hexagon	ID: 2 Shape: Circle	ID: 3 Shape: Rectangle	ID: 4 Shape: Square	Apply removing while iterating...	ID: 0 Shape: Polygon	ID: 2 Shape: Circle	ID: 4 Shape: Square	
	```
	
5. This question concerns the *Mediator* design pattern.

	A major electronic company has asked you to develop a piece of software to operate its new fully automatic washing machine. 
	The company has provided you with the hardware specification and the working knowledge of the machine. 
	In the specification, they have provided you the different washing programs the machine supports. 
	They want to produce a fully automatic washing machine that will require almost zero human intervention. 
	The user should only need to:
	+ connect the machine with a tap to supply water, 
	+ load the clothes to wash, 
	+ set the type of clothes in the machine, e.g., cotton, silk, or denims etc, 
	+ provide detergent and softener to their respective trays, and 
	+ press the start button.

	The machine should be smart enough to fill the water in the drum, as much as required. 
	It should adjust the wash temperature by itself by turning the heater on, according to the type of clothes in it. 
	It should start the motor and spin the drum as much required, rinse according to the clothes needs, use soil removal if required, and softener too.

	As an object oriented developer, you started analysing and classifying objects, classes, and their relationships. 
	Let’s check some of the important classes and parts of the system. 
	
	First of all, a `Machine` class, which has a drum. 
	The `Drum` class also has a heater, a sensor to check the temperature, and a motor. 
	Additionally, the machine also has a valve to control the water supply, soil removal, detergent, and a softener.

	These classes have a very complex relationship with each other, and the relationship also varies. 
	Please note that currently we are talking **only about** the high level abstraction of the machine. 
	If we try to design this system without keeping OOP principles and patterns in mind, then the initial design would be very tightly coupled and hard to maintain as the above classes should connect with each other to get the job done. 


	For example, the `Machine` class should ask the `Valve` class to open the valve, or the `Motor` should spin the `Drum` at certain number of rpm according to the wash program set (which is set by the type of clothes in the machine). 
	Some type of clothes require softener or soil removal, while others do not, or the temperature should be set according to the type of clothes.

	If we allow classes to connect to each other directly, that is, by providing a reference, the design will become very tightly coupled and hard to maintain (= bad); it would become very difficult to change one class without affecting the other. 
	Even worse, the relationship between the classes varies, according to the different wash programs, like different temperature for different type of clothes; so these classes won’t able to be reused.
	To support all the wash programs we need to put control statements like **if-else** in the code, which would make the code even more complex and difficult to maintain.

	To decouple these objects from each other we need a *mediator*, which will contact the object on behalf of the other object, hence providing loose coupling between them. 
	The object only needs to know about the mediator, and perform operations on it. 
	The mediator will perform operations on the required underlying object in order to get the work done.
	
	You will see how the **Mediator design pattern** will improve the washing machine design by making it reusable, maintainable, and loosely coupled:
	+ The `IMachineMediator` is an interface which acts as a generic mediator.
	+ The `IColleague` interface has one task, to set the mediator for the concrete colleague’s class.
	+ The `Button` class is a colleague class which holds a reference to a mediator.


	The user presses the button which calls the `Press` method of this class which, in turn, calls the `Start` method of the concrete mediator class. 
	The `Start` method of the mediator calls the `Start` method of the machine class on behalf of the `Button` class.

	As stated by the company, the washing machine has a set of wash programs and the software should support all these programs. 
	The following mediator is set as a washing program for cottons, so parameters such as "temperature", "drum spinning speed", "level of soil removal", etc., are set accordingly. 
	We can have different mediators for different washing programs without changing the existing colleague classes providing loose coupling and reusability. 
	All these *colleague* classes can be reused with the other washing machine programs. (See `CottonMediator` from the repository.)

	Hopefully, we can now see the advantages and power of the Mediator design pattern.
	We now consider another mediator that is used as a washing program for denim jeans. 
	We just need to create a new mediator and set the rules in it to wash denims: 
	+ rules for the temperature setting, 
	+ the speed at which the drum will spin, 
	+ whether softener is required or not, 
	+ the level of the soil removal, 
	+ etc. 
	
	We don’t need to change anything in the existing structure. 
	No conditional statements like **if-else** are required, something that would otherwise increase the complexity of the software. (See the `DenimMediator` class on the repository.)

	You should test these mediators using the `TestMediator` class (from the repository), which should produce the following output:
	```
	Setting up for COTTON program	Button pressed.	Valve is opened...	Filling water...	Valve is closed...	Heater is on...	Temperature reached 40 C	Temperature is set to 40	Heater is off...	Start motor...	Rotating drum at 700 rpm.	Adding detergent	Setting Soil Removal to low	Adding softener

	**********************************************************
		Setting up for DENIM program	Button pressed.	Valve is opened...	Filling water...	Valve is closed...	Heater is on...	Temperature reached 30 C	Temperature is set to 30	Heater is off...	Start motor...	Rotating drum at 1400 rpm.	Adding detergent	Setting Soil Removal to medium	No softener is required	
	```
	