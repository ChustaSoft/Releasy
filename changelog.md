# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## [1.0.0] - 2021-04-10
### Added
- New package Releasy created, core functionalities are there
- FileParser package, implementing mechanism for parsing changelog.md files inside a project
- AspNet package created, providing a controller for WebAPI's
- IReleaseService and implementation, allowing the project to retrieve release verions information from the system
- ReleaseController implementing a REST Controller with the same functionalities than IReleaseService
- Configuration methods created, with an internal Builder
- Documentation added
