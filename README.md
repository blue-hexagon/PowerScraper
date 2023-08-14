<a name="readme-top"></a>
<div align="center">

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]



</div>

<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src=".readme/logo.png" alt="Logo" height="120">
  </a>

![Windows][windows-badge]
![Linux][linux-badge]
![OSX][osx-badge]
![FreeBSD][freebsd-badge]
<h2>Important: Work in Progress ~ Pre-Alpha</h2>
<h3 align="center">PowerScraper</h3>
  <p align="center">
    An advanced, multi-platform, lightweight system query tool 
    <br />
    <a href="https://github.com/blue-hexagon/PowerScraper/releases"><strong>Get Latest Version »</strong></a>
    <br />
    <br />
    <a href="https://github.com/blue-hexagon/PowerScraper/#demo">View Screenshots</a>
    ·
    <a href="https://github.com/blue-hexagon/PowerScraper/issues">Report Bug</a>
    ·
    <a href="https://github.com/blue-hexagon/PowerScraper/issues">Request Feature</a>

  </p>

</div>

## About The Project

This project is the a reimplementation of a previous project I did in Python called [WinScraper](https://github.com/blue-hexagon/WinScraper); this version is build with C#11 and .NET Core 7.

It comes in two packages: a CLI tool which is a downloadable executable, and a library which is available as a NuGet package.

It collects information about devices running on Windows, Linux, OsX, and FreeBSD which is then serialized into a wide array of
data formats such as YAML, JSON, XML, CSV, TOML, INI and CSV.

### Development Status
| Scraper Name                             | Category <img width=500 height=1/>  | ![w-top] | ![l-top] | ![m-top] | ![b-top] |
|:-------------------------------------------|:------------------------------------|----------|----------|----------|----------|
| CPU                                        | All.Hardware                        | ![w]     | ![l2]    | ![m2]    | ![b2]    |
| RAM                                        | All.Hardware                        | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| Interface                                  | All.Network                         | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| SSID                                       | All.Network                         | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| PID                                        | All.Process                         | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| Installed Software                         | All.Software                        | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| Startup Software                           | All.Software                        | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| Computer                                   | All.System                          | ![w2]    | ![l2]    | ![m2]    | ![b2]    |
| Operating System                           | All.System                          | ![w2]    | ![l2]    | ![m2]    | ![b2]    |

## Demo & Screenshots

<a name="demo"></a>
Run the executable without any arguments for a brief overview of argument options.
Or run it with the `--help` option for more detailed help - example:

![](./.readme/help-screen.png)
<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started
### Installation

#### Install as Application

1. Download the latest binary
2. Manually add the path of the binary to your environment PATH variable.

#### Install as Library

1. Download the latest NuGet package

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contributing

The project is pretty easy to extend and you won't need to concern yourself with any of the codebase besides
all the scraping logic that is contained within `Core.Scraping.Modules.<ModuleName>`, where you find the modules and scrapers; a module is equivalent to a category and modules can be nested.

Modules can contain other modules or they can contain scrapers.
The whole datastructure for the modules and scrapers are set up as a generalized tree where the leafs are scrapers and any other node which is not a leaf is a module.
The only rule is that you cannot setup an empty module without at least one child that is a scraper (hence a category cannot be a leaf).

To add new modules or scrapers, the code should be self-explanatory enough I hope.

Since it was pretty easy to implement, I've added support for a few other operating systems in case someone would find it fun to implement scrapers for these.
I might do some for Linux once the Windows scrapers are completed.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also
simply open an issue. Also, don't forget to give the project a star ⭐!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/YourAwesomeNewScraper`)
3. Commit your Changes (`git commit -m '...'`)
4. Push to the Branch (`git push origin feature/YourAwesomeNewScraper`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see
the [tags on this repository](https://github.com/blue-hexagon/powerscraper/tags).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Authors

- **Blue-Hexagon** - *Initial work* - [Blue-Hexagon](https://github.com/blue-hexagon)

See also the list of [contributors](https://github.com/blue-hexagon/powerscraper/contributors) who participated in this
project.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contact

Contact me on Discord at `manjana#3559` for any matter related to this project.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## License

This project is distributed under the MIT License - see [LICENSE.md](LICENSE) for more details.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/blue-hexagon/PowerScraper.svg?style=for-the-badge

[contributors-url]: https://github.com/blue-hexagon/PowerScraper/graphs/contributors

[forks-shield]: https://img.shields.io/github/forks/blue-hexagon/PowerScraper.svg?style=for-the-badge

[forks-url]: https://github.com/blue-hexagon/PowerScraper/network/members

[stars-shield]: https://img.shields.io/github/stars/blue-hexagon/PowerScraper.svg?style=for-the-badge

[stars-url]: https://github.com/blue-hexagon/PowerScraper/stargazers

[issues-shield]: https://img.shields.io/github/issues/blue-hexagon/PowerScraper.svg?style=for-the-badge

[issues-url]: https://github.com/blue-hexagon/PowerScraper/issues

[license-shield]: https://img.shields.io/github/license/blue-hexagon/PowerScraper.svg?style=for-the-badge

[license-url]: https://github.com/blue-hexagon/PowerScraper/blob/master/LICENSE.md

[workflow-shield]: https://github.com/blue-hexagon/PowerScraper/actions/workflows/dotnet.yml/badge.svg

[workflow-url]: https://github.com/blue-hexagon/PowerScraper/actions/workflows/dotnet.yml/badge.svg

[product-screenshot]: .readme/logo.png


[windows-badge]: https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white
[linux-badge]: https://img.shields.io/badge/Linux-FCC624?style=for-the-badge&logo=linux&logoColor=black
[osx-badge]: https://img.shields.io/badge/mac%20os-000000?style=for-the-badge&logo=apple&logoColor=white
[freebsd-badge]: https://img.shields.io/badge/freebsd-AB2B28?style=for-the-badge&logo=freebsd&logoColor=white

[w-top]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/windows-enabled-icon.png "↓ Windows Feature Status ↓"
[l-top]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/linux-enabled-icon.png "↓ Linux Feature Status ↓"
[m-top]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/osx-enabled-icon.png "↓ macOS (OSX) Feature Status ↓"
[b-top]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/bsd-enabled-icon.png "↓ FreeBSD Feature Status ↓"

[w]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/windows-enabled-icon.png "Windows scraper is implemented ☺"
[l]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/linux-enabled-icon.png "Linux scraper is implemented ☺"
[m]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/osx-enabled-icon.png "macOS (OSX) scraper is implemented ☺"
[b]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/bsd-enabled-icon.png "FreeBSD scraper is implemented ☺"

[w2]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon//windows-disabled-icon.png "Windows scraper is not implemented"
[l2]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/linux-disabled-icon.png "Linux scraper is not implemeneted"
[m2]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/osx-disabled-icon.png "macOS (OSX) scraper is not implemented"
[b2]: https://raw.githubusercontent.com/blue-hexagon/PowerScraper/master/.readme/icon/bsd-disabled-icon.png "FreeBSD scraper is not implemented"