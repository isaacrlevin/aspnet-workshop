# ASP.NET Core Workshop

<details>
  <summary>Official Description of this Workshop</summary>
In this workshop, we will explore the evolving landscape of web development and how ASP.NET Core 8 is poised to revolutionize the way we build modern web applications.

We will walk through a comprehensive journey that covers a diverse range of topics, including:

- ASP.NET Core 8 Overview: Gain an understanding of the latest version of ASP.NET Core and its role in the web development ecosystem.
- Performance and Scalability: Discover the performance enhancements and scalability improvements that ASP.NET Core 8 brings to the table, ensuring your applications can handle even greater workloads.
- Security and Identity: Learn about the enhanced security features and best practices for securing your ASP.NET Core 8 applications, including authentication and authorization.
- Containerization and Microservices: Explore how ASP.NET Core 8 embraces containerization and microservices architecture, enabling you to build modular and scalable applications.
- Blazor Enhancements: Dive into the latest advancements in Blazor, the web framework for building interactive web applications, and see how it can be seamlessly integrated with ASP.NET Core 8.
- Data Access and Entity Framework Core: Understand how to work with data effectively using Entity Framework Core and the improvements introduced in ASP.NET Core 8.
- API Development: Learn how to create robust APIs with ASP.NET Core 8 and leverage the latest features for building RESTful services.
- Modern Front-End Integration: Explore strategies for integrating ASP.NET Core 8 with modern front-end technologies like React, Angular, and Vue.js.
- Tooling and DevOps: Discover the tooling and DevOps support that makes development, testing, and deployment of ASP.NET Core 8 applications smoother and more efficient.

Whether you're an experienced ASP.NET developer or just getting started in web development, this workshop offers a diverse and comprehensive overview of ASP.NET Core 8, equipping you with the knowledge and skills to build powerful, secure, and high-performance web applications.
</details>

## Setup/Prerequisites

There are a few tools that you may or may not have to complete this workshop. They are listed below

<details>
  <summary>Prereqs for Workshop</summary>

  <h3>All OS</h3>

  * .NET 8 (.NET 9 Preview if we have time)
  * Docker Desktop
  * Visual Studio Code (C# Dev Kit Extension)

  <h3>Extras for Windows</h3>

  * Visual Studio 2022 (Community is fine)
  * Microsoft Terminal
  * Windows Subsystem for Linux (Ubuntu is a fine distro)

</details>

Since there are a few things here, I have supplied a Winget Desired State Configuration file in this repo. In order to use this, run this command after cloning the repo

```bash
git clone https://github.com/isaacrlevin/aspnet-workshop.git
cd aspnet-workshop
winget configure -f .\.winget\winget.dsc.yaml
```
This might take a little bit and if we have bandwidth issues I may have a USB stick with some tools on it.

## What you'll be building

In this workshop, you'll learn by building a full-featured ASP.NET Core application from scratch. We'll start from File/ New and build up to an API back-end application, a web front-end application, and a common library for shared data transfer objects.


### Application Architecture

![Architecture Diagram](/docs/architecture-diagram.png)

### Database Schema

![Database Schema Diagram](/docs/conference-planner-db-diagram.png)

## Sessions

| Session | Topics |
| ----- | ---- |
| [Session #1](/docs/1.%20Create%20BackEnd%20API%20project.md) | Build the back-end API with basic EF model |
| [Session #2](/docs/2.%20Build%20out%20BackEnd%20and%20Refactor.md) | Finish the back-end API and EF model, refactor into view models |  |
| [Session #3](/docs/3.%20Add%20front-end%2C%20render%20agenda%2C%20set%20up%20front-end%20models.md) | Add front-end, render agenda, set up front-end models |
| [Session #4](/docs/4.%20Add%20auth%20features.md) | Add authentication, add admin policy, allow editing sessions, users can sign-in with Identity, custom auth tag helper |
| [Session #5](/docs/5.%20Add%20personal%20agenda.md) | Add user association and personal agenda |
| [Session #6](docs/6.%20Final%20Touches.md) | Final touches to our app to make it shine |
| [Session #7](/docs/7.%20Containerization-Aspire.md) | Containerization and Intro to .NET Aspire |
| [Session #8](/docs/8.%20Challenges.md) | Extra Challenges |