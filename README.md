# Codefolio

This GitHub repository is a portfolio containing projects that I have built from 2017-2023 from when I attended Chemeketa Community College and 
Western Oregon University. It showcases a varitey of different projects such as WatchParty and Oregon Turtle App in which had me working with databases 
while working on a team with other individuals. Also GitHub Repos Viewer which was my introduction to using an external api which was GitHub's and making sure 
that I was following best practices while I was working on that project. It also includes Little Person Computer which was the very first application I made 
as a developer to showcase my growth as a developer.

## Table of Contents

- [Demo](#demo)
- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Documentation](#documentation)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgements](#acknowledgements)
- [Contact](#contact)

## Demo

Check out the live demo of the project: [Portfolio](https://ayportfolio.azurewebsites.net)

## Installation

1. Make sure you have .NET 7 installed. You can download it from the official .NET website: [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
2. Make sure you have NodeJS installed. You can download it from the offical NodeJS website: [NodeJS](https://nodejs.org/en/download)
3. Clone the repository: `git clone https://github.com/mondoyanez/PortfolioSite.git`
4. Navigate to the project directory: `cd PortfolioSite/Project`
5. Install the required dependencies using NuGet: `dotnet restore`
6. Install Tailwind CSS using npm: `npm install tailwindcss`
7. Build and run the project: `dotnet run`
8. The application will be accessible at `http://localhost:5150`

## Usage

### TLDR

The web application allows users to switch between Dark mode and Light mode. It features a navbar with links to different pages. Users can explore both deployed Team Projects and individual projects, with a separate link to the GitHub repository and Linkedin provided in the footer.

### Header 
- User can change the theme to Dark mode or Light mode if they chose to by clicking the icon on the top right.
- The AY link in the navbar will take the user back to the Index page containing all the projects.
- The Projects link in the navbar will take the user back to the Index page containing all the projects.
- Resume link in the navbar will take the user to the Resume page, where they can view my Resume instide a viewer and download it as well by poping out the window on the top right which will open the resume in a seperate tab allowing them to print out the resume or print it as a pdf which then is saved on their device that they are currently viewing the page from.
- The Acknowledgments link in the navbar will take the user to the Acknowledgements page, crediting the sources that were used to build the web application.

### Footer
- In the footer in the bottom right is a link to the GitHub repo page, when clicked it will open the repository on a seperate tab.
- Next to the GitHub icon is a Linkedin icon that will take the user to my Linkedin profile that will be opened on a seperate tab if they wish to visit my Linkedin.

### Oregon Turtles
- A description of the project and when I was apart of the team is included, the VIEW button on the bottom of the card navigates the user to the deployed Oregon Turtles
site so that the user the view the page if they wish to view it.

### Watch Party
- A description of the project and when I was apart of the team is included, the VIEW button on the bottom of the card takes the user to the deployed site so that the user
the view the deployed page in action and try out any of the features on the website.

### Pythagorean Theorem Calculator
- User enters a postive value greater than 0.00001 for Side A and Side B
- User then clicks the calculate button
- User is given the hypotenuse given a triangle with those two legs

### Conga Line Lab ([Conga Line Lab PDF](./misc/Conga%20Line/Zombie%20Conga%20Line%20Lab.pdf))
- User begins with a conga line of a length of either 10, 12, 14, or 16.
- Every five rounds the front and the end of the conga line loses a zombie.
- The game continues until the user wishes not to continue the game anymore.
- Zombies that are available to add to the conga line are:
    - Red
    - Yellow
    - Green
    - Blue
    - Magenta
    - Cyan
- Assume that this is the starting conga line: [R, Y, B, R, Y, M, C, G, Y, R]
- The following are actions available for the user to use, valid sample input, and sample output.
    - Engine! - This zombie becomes the first first in the conga line.
        - Engine(Red)
            - [R, R, Y, B, R, Y, M, C, G, Y, R]
        - Engine(Blue)
            - [B, R, Y, B, R, Y, M, C, G, Y, R]
        - Engine(Green)
            - [G, R, Y, B, R, Y, M, C, G, Y, R]
    - Caboose! - This zombie becomes the last zombie in the conga line.
        - Caboose(Magenta)
            - [R, Y, B, R, Y, M, C, G, Y, R, M]
        - Caboose(Yellow)
            - [R, Y, B, R, Y, M, C, G, Y, R, Y]
        - Caboose(Cyan)
            - [R, Y, B, R, Y, M, C, G, Y, R, C]
    - Jump in the Line! - This zombie joins the conga line at position X where X <= the length of the conga line + 1 [1 - 11].
        - Jump(Yellow, 2)
            - [R, Y, Y, B, R, Y, M, C, G, Y, R]
        - Jump(Red, 5)
            - [R, Y, B, R, R, Y, M, C, G, Y, R]
        - Jump(Blue, 11)
            - [R, Y, B, R, Y, M, C, G, Y, R, B]
    - Everyone Out! - All matching zombies from the conga line are removed.
        - Out(Red)
            - [Y, B, Y, M, C, G, Y]
        - Out (Yellow)
            - [R, B, R, M, C, G, R]
        - Out (Blue)
            - [R, Y, R, Y, M, C, G, Y, R]
    - You're Done! - First matching zombie from the conga line is removed.
        - Done(Red)
            - [Y, B, R, Y, M, C, G, Y, R]
        - Done(Cyan)
            - [R, Y, B, R, Y, M, G, Y, R]
        - Done(Green)
            - [R, Y, B, R, Y, M, C, Y, R]
    - Brains! - One zombie is added to the front and back of the conga line of the same color.
        - Brains()
            - [B, R, Y, B, R, Y, M, C, G, Y, R, B]
    - Rainbow Brains! - One zombie of each color is added to the end of the color line in random order.
        - Rainbow()
            - [R, Y, B, R, Y, M, C, G, Y, R, M, G, B, R, C, Y]
- Conga Line Wireframe:<br>
<img src="./misc/Conga Line/CongaLine_Index_WireFrame.png" title="Conga Line Wireframe" alt="Conga Line Wireframe Image" width="500" height="500"><br>
- SAMPLE GAME
    - Round 1 (Length: 16): [G, Y, C, R, G, R, M, Y, C, B, G, G, R, C, Y, G]
        - Brains()
    - Round 2 (Length: 18): [C, G, Y, C, R, G, R, M, Y, C, B, G, G, R, C, Y, G, C]
        - Out(Green)
    - Round 3 (Length: 13): [C, Y, C, R, R, M, Y, C, B, R, C, Y, C]
        - Done(Red)
    - Round 4 (Length: 12): [C, Y, C, R, M, Y, C, B, R, C, Y, C]
        - Rainbow()
    - Round 5 (Length: 16): [Y, C, R, M, Y, C, B, R, C, Y, C, G, R, B, M, Y]

### Color Interpolator
- Still being developed

### Mad Lib's Generator
- Still being developed

### Random Team Generator
- Still being developed

### GitHub Repos Viewer
- Still being developed

## Features

- Projects: Index page that has my projects in one page for the user to be able to navigate to each project from one location.
- Light/Dark mode: Light/Dark mode that changes the theme of the page for the user to theme that they prefer to use.
- Resume: User can view my Resume and download it as well by poping out the window that will allow them to download the resume.
- Acknowledgements: Credits page of where all the sources for the project were acquired

## Documentation

- [Dotnet Documentation](https://learn.microsoft.com/en-us/docs/)
- [Tailwind Documentation](https://tailwindcss.com/docs/installation)
- [Flowbite Documentation](https://flowbite.com/docs/getting-started/introduction/)
- [Tailwind Classes](https://tailwind.build/classes)

## Contributing

Thank you for your interest in contributing to this project. However, please note that we are currently not accepting any external contributions. This decision has been made to maintain the project's focus and ensure consistency in the codebase.

We appreciate your understanding and support. If you have any suggestions or feedback, feel free to open an issue in the repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- This project utilizes the ChatGPT language model developed by OpenAI. We would like to acknowledge the contributions of OpenAI and the developers of ChatGPT for providing this powerful language model.

## Contact

If you have any questions, suggestions, or feedback, feel free to reach out:
- Email: yanezdevelopment95@gmail.com
- LinkedIn: [Armando Yanez](https://www.linkedin.com/in/armando-yanez-706380178/)