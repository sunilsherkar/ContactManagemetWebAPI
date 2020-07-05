# ContactManagemetWebAPI
This Repository used for creating WebAPI with Dependancy Injection with MVC
In this project contains two solution in root folders 
In MVC folder which contain code for fontend , UI (datatable, Add & Update contact) andWebAPI calls.
In WebAPI folder contain Rest API for list , add& updation of contact.


Artitecture
Front END (MVC)
In this project frontend made up with MVC 5 with razor, Html ,css , Jquery .
I consume webapi in this layer
all data access from webAPI so I consume WEBAPI
all the get Post call using ajax which return json result
For Contact list Datatale pagination JQuery used for searhing, filtering & Sorting 

WEBAPI
In this application I used Rest API to access data from database 
for database connection create one dbcontext object which uses connectin string from web.config .
In WebApi I used dependancy Injection using Ninject dependancy Resolver. 
Web API that uses instance of a class that implements IContactRepository interface
IContactRepository interface implemented in contactSerice
Then we need one IDependencyResolver to resolve this service dependancy so I used NijectResolver.
In this way i inject dependancy into controller 
So the contactservice class access database using dbcontext and send data back to controller





