# ContactManagemetWebAPI
This Repository used for creating WebAPI with Dependancy Injection with MVC.
In this project contains two solution in root folders .
In MVC folder which contain code for fontend , UI (datatable, Add & Update contact) andWebAPI calls.
In WebAPI folder contain Rest API for list , add& updation of contact.

Artitecture :

Front END (MVC)
In this project frontend made up with MVC 5 with razor, Html, css, Jquery. 
I consume WEBAPI in this layer.
All data access from webAPI so I consume WEBAPI.
All the GET Post actions are using ajax call which return json result.
For Contact list Datatale pagination JQuery used for searhing, filtering & Sorting.

WEBAPI
In this application I used Rest API to access data from database.
For database connection create one dbcontext object which uses connectin string from web.config.
In WebApi I used dependancy Injection using Ninject dependancy Resolver. 
Web API that uses instance of a class that implements IContactRepository interface.
IContactRepository interface implemented in contactSerice.
Then we need one IDependencyResolver to resolve this service dependancy so I used NijectResolver.
In this way i inject dependancy into controller.
So the contactservice class access database using dbcontext and send data back to controller.

Database
In this application Sql server database used, all the data access through stored procedure.

How to run application:

I deployed the application on testserver
For frontend you can acces using link 
http://sherkarsunil2-001-site1.atempurl.com/usercontact/index

For WEBAPI URL is :
http://sunilsherkar-001-site1.ftempurl.com/Help

To get all contact API URL is:
http://sunilsherkar-001-site1.ftempurl.com/api/contact

To get contact for specific user API URL is:
http://sunilsherkar-001-site1.ftempurl.com/api/contact?id=5

To add/Update contact API read 
http://sunilsherkar-001-site1.ftempurl.com/Help/Api/POST-api-Contact
to check POST API you can use Postman or Fiddler


Code Structure

Application contains two folder
MVC
WEBAPI

MVC : it contains code / UI for frontend and API Consumption

Now interesting Part is in API
In the ContactInfo.Models contain IContactRepository interface which can be implemented in ContactInfo.Service folder with file name ContactService.cs
Nijectresolver resolve dependancy which placed in ContactInfo.App_Start folder with file name NinjectWebCommon , which generate automatically when we add NInject from Nuget Packet manager.
lastly we used Icontactrepository in our contactcontroller and perform operations.

https://github.com/sunilsherkar/ContactManagemetWebAPI/blob/master/README.md#contactmanagemetwebapi









