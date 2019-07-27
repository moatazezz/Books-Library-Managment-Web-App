"# Books-Library-Managment-Web-App" 
it is Library Mangment web app.

Developed with C# and Asp.net MVc 5.

it is 3 tier Architecture :
Data Access Layer (DAL), Business logic Layer (BLL) , User Interface Layer (UI)

Repository pattern , Autofac dependency injection and Automapping are used.


Application have dashboard for displaying Percentage of:
- borrowed book that still in allowed period 
- borrowed book that exceeds allowed period
- Available Books

Application have Auto notification for number of books exceeding allowed period
together with a report include borrower Name , borrow date and penalty

Application provide search by book title in available books list and present
number of available copies.

Prerequistes:

visual studio 2017 , local sql db 2014 or above (source file included in app
folder)
