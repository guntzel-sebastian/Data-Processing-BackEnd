--- REQUIRED ---

dotnet 8(.0.100)
vscode
c# for vscode (duh)




--- NEW PROJECT SETUP ---


use commands in console (any):

"
dotnet new webapi --use-controllers -o {ApiName}
cd {ApiName}
dotnet add package Microsoft.EntityFrameworkCore.InMemory
code -r ../{ApiName}
"


trust certificates using command in console:

"
dotnet dev-certs https --trust
"


in order to scaffold the controller (only neccesary if you're making an endpoint), you need to run the following:

"
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator
"


--- RUN COMMAND ---

"
dotnet run --launch-profile https
"

go to "{link}/swagger" to get to the dev environment.



--- ADD NEW ENDPOINT ---

(for the following section, all {name} is the same word and does not change between steps for clarity.)

(this example is meant for completely new models from 0, some steps may be skipped/ modified)


MODEL CLASS ---

go to models folder
add {name}Item.cs file
add code for an container class.

example code is:
"
namespace {name}.Models;

public class {name}
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool somethingElse { get; set; }
}
"

DATABASE CONTEXT --- 

go to Models folder
add new file {name}Context.cs

add something like the following code:

"
using Microsoft.EntityFrameworkCore;

namespace {name}.Models;

public class TodoContext : DbContext
{
    public {name}Context(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> {name}Items { get; set; } = null!;
}
"


REGISTERING DATABASE CONTEXT ---

in order to register the context, go to Program.cs

if not yet present at the top, add:
"
using Microsoft.EntityFrameworkCore;
"

now add:
"
using TodoApi.Models;
"

now. the next step is to add the database connection. if you wish to add a false/test solution without database. use:

"
builder.Services.AddDbContext<{name}Context>(opt =>
    opt.UseInMemoryDatabase("{digitalTableName}"));
"


SCAFFOLD CONTROLLER ---

this essentially makes a bunch of code for you, including GET and POST endpoints.

use command: 
"
dotnet aspnet-codegenerator controller -name {name}ItemsController -async -api -m {name}Item -dc {name}Context -outDir Controllers
"


POTENTIAL UPDATE ---

you may need to update the return statement of Post{name}Item.

from:

"
return CreatedAtAction("Get{name}Item", new { id = {name}Item.Id }, {name}Item);
"

to:

"
return CreatedAtAction(nameof(Get{name}Item), new { id = {name}Item.Id }, {name}Item);
"

the significance of this is not known.




--- SOURCE ---

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio