# ASP.NET project

## Description
Good afternoon programmers.
</br>
<details>
<summary>This is my first program in REACT.NET and this is the first program that does exactly what I expect it to do.</summary>
(using REACT.NET is kind of painful, too hard to use any react dependency: 3/10 would not do it again)
</details>
The main task is to show some statistical information in the form of charts and tables.
From the program you can download any data for a selected period in the form of csv.
The program was made in 2 days, so the code is probably bad, but I will not change anything now, just after a while come back to the project and analyze it for mistakes.


## Implementation
Stack contains only 2 technologies here: ASP.NET and React
It's not the best solution, but when I made this project it was the best and fast solution.

### ASP.NET
In this project, I used ASP.NET MVC as backend solution
So my structure:
#### Controllers
> *HomeController.cs* - Needed to get pages from the server

> *BackendActionsController.cs* - Something like WEB-API. It takes data from Entity Framework by Linq expressions

#### Models
Everything inside "SqlData" folder is related to SQL databases
We had two SQL Databses:
> 1) There are only 2 columns: Id and Object-Name

> 2) There are 3 columns: Id as rowId, startId to match with previous table, URL to the object in the internet

Since each object can have many URLs

> *CSV model* - used as helping structure to build CSV file easier and faster

> *StartView* - used on startPage, each model-class contains information about dataObject (It's ID, Name and URLs count)

> *DetailedView* - used on detailedPage, each model-class contains detailed information about dataObject

#### Views
There are some razor documents, with html formating, wich purpose is to inject react-related scripts and set base formating

### React
On frontend I used only 2 libraries: 
> [chart.JS](https://www.chartjs.org/) for fast and simple graphics

> [bootstrap](https://getbootstrap.com/) only for some styles

#### React.NET
[That Library](https://github.com/reactjs/React.NET) I found in the E-Net by googling "Asp.Net updating page"
I used it 2-3 times, in views, where it did it's startup job
#### Babel & Webpack
I set up it up by watching tutorials for [React.NET](https://github.com/reactjs/React.NET), nothing interesting
#### Scripts
Some simple things:
> *script.jsx* - calling server for data

> *dataViewers.jsx* - contains chart.JS and table constructors

## Final
That was it for today, feel free to contact me or use some codes as examples for your projects (but better do not, code is actually not the best)

@K372470#7545
