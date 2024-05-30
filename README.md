# 078_CSharp_CleaningUpProgramFile
<div>
	<div>
		<img src=https://raw.githubusercontent.com/Byron2016/00_forImages/main/images/Logo_01_00.png align=left alt=MyLogo width=200>
	</div>
	&nbsp;
	<div>
		<h1>078_CSharp_CleaningUpProgramFile</h1>
	</div>
</div>

&nbsp;

# Table of contents

--- 

- [Table of contents](#table-of-contents)
- [Project Description](#project-description)
- [Technologies used](#technologies-used)
- [References](#references)
- [Steps](#steps)

  - <details> <summary>List of Steps</summary>

    - [Install & Setup Vite + React + Bootstrap 5](#-artificial-intelligence-and-bots)

   </details>

[⏪(Back to top)](#table-of-contents)

# Project Description

--- 

[⏪(Back to top)](#table-of-contents)
&nbsp;

# Technologies used

--- 

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![VisualStudio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)


[⏪(Back to top)](#table-of-contents)

# References

--- 

- Shields.io

  - [Shields.io](https://shields.io/)

  - [Github Ileriayo markdown-badges](https://github.com/Ileriayo/markdown-badges)

  - [Github Ileriayo markdown-badges WebSite](https://ileriayo.github.io/markdown-badges/)

[⏪(Back to top)](#table-of-contents)

# Steps

--- 
- Mirar
	- jondjones: "C_Sharp_Convirtiendo_Net6.txt"
		- MUST know Startup.cs To Program.cs REFACTORING tips in .NET 7
			- https://www.youtube.com/watch?v=YHrhO_Zkgvk
			
- IAmTimCorey: Cleaning Up The Program.cs File In .NET 6 Now That Startup.cs is Gone
	- https://www.youtube.com/watch?v=rhydGmLxfjQ
		- NET 6:
			- Crear un nuevo proyecto 
				- ASP.NET Core Web API 
					- name: ApiDemo
					- Sol: ApiDemoApp
				- Additional information
					- Framework: NET 6.0
					- Authentication type: None 
					- Configure for HTTPS: true
					- Enable Docker: false 
					- Use controllers (uncheck to use minimal APIs): false
					- Enable OpenAPI suppor: true
					- Do not use top-level statements: false 
					
		
		- NET 8:
			- Crear un nuevo proyecto 
				- ASP.NET Core Web API 
					- name: ApiDemo
					- Sol: ApiDemoApp
				- Additional information
					- Framework: NET 8.0
					- Authentication type: None 
					- Configure for HTTPS: true
					- Enable container suppor: false
						- Container OS: desabilitado
						- Container build type: desabilitado
					- Enable OpenAPI suppor: true
					- Do not use top-level statements: false 
					- Use controllers: false
					- Enllist in .NET Aspire orchestration: false
					- Enable Docker: false 
					- Use controllers (uncheck to use minimal APIs): false
					
					
	
		- Crear en la raíz del proyecto un nuevo folder "Startup"
		- Crer una nueva clase "Startup/DependencyInjectionSetup"
			- Usaremos extensionMethods. 
		
			namespace ApiDemo.Startup;
			
			public static class DependencyInjectionSetup
			{
				public static IServiceCollection RegisterServices(this IServiceCollection services)
				{
					services.AddEndpintsApiExplorer();
					services.AddSwaggerGen();
					return services;
				}
			}

		- Crer una nueva clase "Startup/SwaggerConfiguration"
			- Usaremos extensionMethods. 
		
			namespace ApiDemo.Startup;
			
			public static class SwaggerConfiguration
			{
				public static WebApplication ConfigureSwagger(this WebApplication app)
				{
					if (app.Environment.IsDevelopment())
					{
						app.UseSwagger();
						app.UseSwaggerUI();
					}
					return app;
				}
			}
			
		- Crer una nueva clase "Startup/MapEndpoints"
			- Usaremos extensionMethods. 
		
			namespace ApiDemo.Startup;
			
			public static class MapEndpoints
			{
				public static WebApplication MapUserEndpoints(this WebApplication app)
				{
					app.MapGet("/User", () => "Hello User");
					app.MapGet("/User/{name}", (string name) => $"Hello {name}");
					return app;
				}
				
				public static WebApplication MapDogEndpoints(this WebApplication app)
				{
					app.MapGet("/Dog", () => "Good boy");
					app.MapGet("/Dog/{name}", (string name) => $"Hello {name}");
					return app;
				}
			}

		- program.cs 

			using ApiDemo.Startup
			
			var builder = Webapplication.CreateBuilder(args);
			
			builder.Services.RegisterServices();
			
			var app = builder.Build()
			
			app.ConfigureSwagger();
			
			app.UseHttpsRedirection();
			
			....
			
			// End Points 
			
			app.MapUserEndpoints();
			app.MapDogEndpoints();
			
			// O
			
			app.MapUserEndpoints().MapDogEndpoints();
			
			// O
			app
				.MapUserEndpoints();
				.MapDogEndpoints();
				
			app.Run();

[⏪(Back to top)](#table-of-contents)
