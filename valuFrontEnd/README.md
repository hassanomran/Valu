# valuFrontEnd

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 10.2.1.

## Download Node_modules

Run 'npm install --force' to install the dependencies required for this package and its dependencies before continuing development with the latest version available in the repository.
 
## Development server

Run `npm start` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## backend configuration

Take the 'http://localhost:4200/' server and configure the backend int appsettings like so:
"Settings": {
  "AllowedOrginPortal": "https://localhost:4200,http://localhost:4200/"
}
to avoid cors origins issues with the default backend configuration you can configure the backend configuration yourself.

conncectionstring:put your server configuration here and the password for your server like that:
"ConnectionStrings": {
    "intalio": "Server=localhost;Database=intalio;User Id=sa;Password=123456Hi;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;"
  },

## configuration Clientside API
in environments where the default backend configuration : ApiUrl:"https://localhost:7208/api"
this is the default backend configuration put your local host and port into the configuration.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `npm run build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
