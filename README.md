### Important takeaways:

Models: Classes that represent the data of the app. The model classes use validation logic to enforce business rules for that data.

Views: Views are the components that display the app's user interface (UI). Generally, this UI displays the model data.

Controllers: Classes that handle browser requests. They retrieve model data and call view templates that return a response.

The UI logic belongs in the view. Input logic belongs in the controller. Business logic belongs in the model.

Layout templates allow you to specify the HTML container layout of your site in one place and then apply it across multiple pages in your site.

Controller actions are invoked in response to an incoming URL request. A controller class is where the code is written that handles the incoming browser requests. The controller retrieves data from a data source and decides what type of response to send back to the browser. View templates can be used from a controller to generate and format an HTML response to the browser.

The ViewData dictionary is a dynamic object, and contains data that will be passed to the view.

The view model approach to passing data is generally much preferred over the ViewData dictionary approach.

You write the model classes first, and EF Core creates the database.

A database context class is needed to coordinate EF Core functionality (Create, Read, Update, Delete) for a model.

Use the scaffolding tool to produce Create, Read, Update, and Delete (CRUD) pages for the movie model.

The constructor uses Dependency Injection to inject the database context into the controller. The database context is used in each of the CRUD methods in the controller.

MVC also provides the ability to pass strongly typed model objects to a view.

A lambda expression is passed in to FirstOrDefaultAsync to select entities that match the route data or query string value.

The @model statement at the top of the view file specifies the type of object that the view expects.

Tag Helpers enable server-side code to participate in creating and rendering HTML elements in Razor files.

The [Bind] attribute is one way to protect against over-posting. You should only include properties in the [Bind] attribute that you want to change.

Before the form is posted to the server, client-side validation checks any validation rules on the fields. If there are any validation errors, an error message is displayed and the form isn't posted. If JavaScript is disabled, you won't have client-side validation but the server will detect the posted values that are not valid, and the form values will be redisplayed with error messages.

All the HttpGet methods in the movie controller follow a similar pattern. They get a object (or list of objects, in the case of Index), and pass the object (model) to the view.

One of the design tenets of MVC is DRY ("Don't Repeat Yourself"). ASP.NET Core MVC encourages you to specify functionality or behavior only once, and then have it be reflected everywhere in an app.

Having validation rules automatically enforced by ASP.NET Core helps make your app more robust. It also ensures that you can't forget to validate something and inadvertently let bad data into the database.

Performing a delete operation in response to a GET request (or for that matter, performing an edit operation, create operation, or any other operation that changes data) opens up a security hole.

An important security feature built into a C(R)UD method is that the code verifies that the search method has found a movie before it tries to do anything with it.

common work around for methods that have identical names and signatures is to artificially change the signature of the POST method to include an extra (unused) parameter.
