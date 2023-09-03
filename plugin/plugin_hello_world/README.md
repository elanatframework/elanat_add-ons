This package is a ready-made hello world package to quickly create a plugin add-on for Elanat.

To create an add-on for Elanat, just fill in an xml catalog file. The following steps are related to programming in the .NET environment, which even beginner programmers should master.

Plugins are placed in Elanat in wwwroot/add_on/plugin/yourplugin; your plugin will be automatically added to the directory you specify. This notification was for you to know about the path of your plugin!

## Steps

**Step 1:**
Create new project
Create new ASP.NET Core project and add all the files and directories in the plugin_hello_world directory to your project; then add CodeBehind NuGet to your project.
CodeBehind NuGet is available at the following link:
[https://www.nuget.org/packages/CodeBehind](https://www.nuget.org/packages/CodeBehind)

**Step 2:**
Change PluginHelloWorld names
Open below files list and then change PluginHelloWorld name to your plugin name:

 - wwwroot/Default.aspx
 - class/controller_and_model/PluginHelloWorldController.cs
 - class/controller_and_model/PluginHelloWorldModel.cs

**Step 3:**
Write your code and compile project
If you need to use Elanat libraries in your plugin, you can enter the following path and download your library in the available versions:
[https://github.com/elanatframework/Elanat_add-ons/tree/elanat_framework/dll](https://github.com/elanatframework/Elanat_add-ons/tree/elanat_framework/dll)

Before you compile the project, the Program.cs class should look like this:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run();
```

**Step 4:**
Fill catalog.xml file
In the directory with the same name as the add-on type, open the catalog.xml file for editing and change or add the necessary values such as add-on name, add-on path, add-on executable file name, etc. then Place the .dll file in the root/bin path

**Step 5:**
Create zip file
Finally, create a zip file containing the directory with the same name as the add-on type and the root directory.

**Notes:**
 - Note that you will only have two directories in the final zip file; one is the directory with the same name as the add-on type (if your project is a plugin, it is a plugin, if it is a module, it is a module, if it is an extra helper, it is extra_hepler, etc.) in which you have placed the catalog file along with other files such as Default.aspx ; the other is the root directory, where there should be a directory called bin to place the main dll file of the project, and other files and directories added to the root directory will all be copied to the root of the program.
 - The xml catalog file includes more features and you can use all the features of this file to create powerful add-ons.
 - Do not copy ElanatEmptyPlugin.dll file. Ignore this file.
 - When adding a add-on to Elanat, the CodeBehind framework will recompile all aspx pages and this process may take some time.

To test the project, the Program.cs class should look like this:

```csharp
using CodeBehind;
using SetCodeBehind;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

CodeBehindCompiler.Initialization();

app.Run(async context =>
{
    CodeBehindExecute execute = new CodeBehindExecute();
    await context.Response.WriteAsync(execute.Run(context));
    await context.Response.CompleteAsync();
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.Run();
```