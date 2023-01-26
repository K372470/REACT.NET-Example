# ASP.NET statistic service

## Description 
Good day programmers.
This is my first program on ASP.NET what does things what i expect from it.
It's point is to show some statistic information on chart + table  where you can download any data.
It was made in 2days, so it's code is probably bad, but I dont will not change anything rn, just after some time will come here and learn my mistakes one more time
## Realisation
I used only 2 things here: ASP.NET, React
Now i know that it's not a very a good idea, but when I made this project it was the best and fast solution.
Anyway it looks like this combination did it's job good enought

### ASP.NET
As you can imagine in this project, I used ASP.NET Core with Model-View-Controller scheme.
So my structure:
#### Controllers
> *HomeController.cs* - needed to tell server "hey, load pages for me"

> *BackendActionsController.cs* - Something WEB-API like. It takes data from Entity Framework by Linq expressions

#### Models
Everything inside "SqlData" folder is related to SQL databases, so i'll not mention it, just know what we had 2databases:
With "Id - Name" scheme and "Id\_From\_PreviousDB - description - link ..." - it seemed a good and popular solution
##### Actual models
> *CSV model* - used only on server, to build CSV file easier and faster

> *StartView* - used on startPage, each class contains information about dataObject with it's ID

> *DetailedView* - used to show links to founded objects

#### Views
Views here aren't for real interesting, just some html and css formating + "model ..." in razorDocument

### React
In that category, that was my first project too, connecting libraries was really painful...
Btw, now after finishing some amount of small React Projects, i think, that was my mistake...
On front I used only 2 libraries: 
> [chart.JS](https://www.chartjs.org/) for fast and simple graphics

> [bootstrap](https://getbootstrap.com/) only for some styles

#### React.NET
[That Library](https://github.com/reactjs/React.NET) I found in the E-Net by googling "Asp.Net updating page"
I used it 2-3 times, in views, where it did it's startup job
#### Babel & Webpack
> AAAAAAAAH PAIN

But without jokes, i just set it up by watching tutorials for [React.NET](https://github.com/reactjs/React.NET), nothing interesting, bcs now I usualy use other compilators
#### Scripts
Nothing special, some simple things:
> *script.jsx* - calling server for data

> *dataViewers.jsx* - contains chart.JS and table constructors

## Final
That was it for today, feel free to contact me or use some codes as examples for your projects (but better do not, code is actually not the best)

@K372470#7545
