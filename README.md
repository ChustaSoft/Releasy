# Releasy

![GitHub](https://img.shields.io/github/license/ChustaSoft/Releasy)



| Package                              | NuGet Version                                                                                                    |  Pipeline                                                                                                                                                                                                                                                                                 |    Downloads                                                                                  |
|--------------------------------------|------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| ChustaSoft.Releasy                   | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/ChustaSoft.Releasy?style=for-the-badge)            | [![Build Status](https://dev.azure.com/chustasoft/SocialNET/_apis/build/status/OpenStack/Releasy/%5BRELEASE%5D%20-%20ChustaSoft%20Releasy%20(NuGet)?branchName=main)](https://dev.azure.com/chustasoft/SocialNET/_build/latest?definitionId=35&branchName=main)                           | ![Nuget](https://img.shields.io/nuget/dt/ChustaSoft.Releasy?style=for-the-badge)              |
| ChustaSoft.Releasy.FileParser        | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/ChustaSoft.Releasy.FileParser?style=for-the-badge) | [![Build Status](https://dev.azure.com/chustasoft/SocialNET/_apis/build/status/OpenStack/Releasy/%5BRELEASE%5D%20-%20ChustaSoft%20Releasy%20FileParser%20(NuGet)?branchName=main)](https://dev.azure.com/chustasoft/SocialNET/_build/latest?definitionId=36&branchName=main)              | ![Nuget](https://img.shields.io/nuget/dt/ChustaSoft.Releasy.FileParser?style=for-the-badge)   |
| ChustaSoft.Releasy.AspNet            | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/ChustaSoft.Releasy.AspNet?style=for-the-badge)     | [![Build Status](https://dev.azure.com/chustasoft/SocialNET/_apis/build/status/OpenStack/Releasy/%5BRELEASE%5D%20-%20ChustaSoft%20Releasy%20AspNet%20(NuGet)?branchName=main)](https://dev.azure.com/chustasoft/SocialNET/_build/latest?definitionId=37&branchName=main)                  | ![Nuget](https://img.shields.io/nuget/dt/ChustaSoft.Releasy.AspNet?style=for-the-badge)       |


## Description

Releasy is a tool for managing Release and versioning information for .Net Core applications.

It provides an abstract mechanims for retrieving information about Releases such as Version, Notes and Release Date

Target support: 
- .Net Core 3.1
- .NET 5.0

Implementations:
- File parsing (ChustaSoft.Releasy.FileParser)
    - Uses an internal changelog.md file (or specify another file name with same format) for manage Release information.
	- Implementation based on format documented by _[Keep a Changelog](https://keepachangelog.com/en/1.1.0/)_.
	- Allows easily to keep a changelog documented, independently from technical or functional members.
	- This mechanism allow the project to use the same changelog to be used as reference information inside the project, avoiding duplicity of information.

- _More new implementations would be welcome (SQL? Mongo? External provider?)_
	

## Getting started:

1. Install the NuGet package for the required implementation, for example ChustaSoft.Releasy.FileParser
	- Install-Package ChustaSoft.Releasy.FileParser
  
2. Place and manage a changelog.md file inside the solution, and mark the resource as "Copy always" inside VS Solution
	- Format reference [here](https://keepachangelog.com/en/1.1.0/)

3. Configuration at startup
	- `services.AddReleasy().FromFile();`
	By default, it will look for a changelog.md file placed in the same solution, if another name is required, could be added in the same extension method:
	- `services.AddReleasy().FromFile("otherfilename.md");`

4.1 Using Services:

  1. Inject IReleaseService contract where is required, it provides the following methods:
     - Task<ReleaseInfo> Get(string identifier);
     - Task<IEnumerable<ReleaseInfo>> GetAll();
     - Task<IEnumerable<ReleaseInfo>> GetFrom(DateTime dateFrom);
     - Task<IEnumerable<ReleaseInfo>> GetFrom(string identifierFrom);
 
4.2 Using AspNet package

  1. Install the AspNet package: 
     - Install-Package ChustaSoft.Releasy.AspNet
  2. Add required configuration using the same ImvcBuilder from AspNetCore:
     - `services.AddMvc().AddReleaseController();`
  3. Once done, a REST controller will be added to the project giving the same functionalities described for the Service, using the same configured 
     authentication in the project, with the following routes:
	 - */api/Release*: Provide all release versioning entries
	 - */api/Release/{identifier}*: Provide information for an speceific release version
	 - */api/Release/from-identifier/{identifier}*: Given a version, provide all release details about all newer versions
	 - ​*/api​/Release​/from-date​/{dateFrom}*: Provide all the release details from an specific date

### Examples and testing	
 
- Do you still need an example? [Here](https://github.com/ChustaSoft/Releasy/tree/main/ChustaSoft.Releasy/ChustaSoft.Releasy.AspNetExample) you can find it.
- Swagger or Postman is recommended in development process, in order to facilitate seeing results, but not mandatory.


*Thanks for using and contributing*
---
[![Twitter Follow](https://img.shields.io/twitter/follow/ChustaSoft?label=Follow%20us&style=social)](https://twitter.com/ChustaSoft)

	