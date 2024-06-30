# LibraryManagement

This is my repository for Technical assigment from Databac.</br>
This project has been uploaded to azure and also I made fron-end in react.</br>
front-end: https://library-management-57fr.vercel.app/  </br>
front-end repo: https://github.com/f1l1ph/libraryManagement

<h2>Design patterns:</h2>
Fot this project I chose CQRS and repository patterns.</br>
CQRS - command query responsibility segragation </br>
In project we have:</br>
<ul>
  <li>commands - responsible for writing into database</li> 
  <li>querys - resonsible for reading from database</li>    
</ul>
Every command and query has also handler - "AddBookCommandHandler"

<h3>We also have repositories.</h3>
Repository is responsible for communicating with database using entity framework

<strong>In theory we should also have 2 or more databases, one for reading and one writing.</strong> In project we have one database but 2 db contexts.

<h3>Validation</h3>
Added validation using Fluent validation library.
Validation works when adding/modifing book. Also when adding new BorrowOrder.

Also Emailworker checks every 24h for closeDate on each BorrowOrder and sends fake email.

<em>endpoints on the swagger screenshot.</em></br>
![Datapac-swagger](https://github.com/f1l1ph/Zadanie-Datapac/assets/50553234/c8a7a274-f3b1-4039-9956-f00a0ada7ec1)

<em>Db diagram, for this project I am using Postgres</em></br>
![Datapac-dbD](https://github.com/f1l1ph/Zadanie-Datapac/assets/50553234/941b34ef-381b-4295-83a6-b771bc16e377)
