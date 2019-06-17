# Snakey

A website that fetches the source content from https://flipboard.com/@raimoseero/feed-nii8kd0sz.rss. 

Before displaying the article, it must be freed from clutter using Mercury API web parser. 

Simple POST request to https://uptime-mercury-api.azurewebsites.net/webparser returns the desired result. 

Clutter free article content is displayed in scalable modal /pop-up window. 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Setup

1. Install the following:
   - [.NET Core 3.0 >= preview 2](https://dotnet.microsoft.com/download/dotnet-core/3.0)
   - [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
2. Run the project and wait till all packages are installed
3. Browser will open and navigate to [http://localhost:63463/].

## Built With

* [.Net core and Vue.Js Single-File components]
* [Webpack](https://webpack.js.org/)
* [Axios](https://axios.nuxtjs.org/)

## Authors

* **Kamelija Sekulovska**
* **Eleni Mickovska**

## Issue

The second article throws 505 error exception because it redirects to a page where an authentication is required.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
