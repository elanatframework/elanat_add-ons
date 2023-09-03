// For Add-On Test

//using CodeBehind;
//using SetCodeBehind;

//var builder = WebApplication.CreateBuilder(args);

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//CodeBehindCompiler.Initialization();

//app.Run(async context =>
//{
//    CodeBehindExecute execute = new CodeBehindExecute();
//    await context.Response.WriteAsync(execute.Run(context));
//    await context.Response.CompleteAsync();
//});

//app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();

//app.Run();


// For Finally Publish

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run();