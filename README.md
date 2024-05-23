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

  * .NET 8 (.NET 9 Preview if we have time)
  * Visual Studio 2022 (Community is fine)
  * Visual Studio Code
  * Microsoft Terminal
  * Windows Subsystem for Linux (Ubuntu is a fine distro)
  * Docker Desktop

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