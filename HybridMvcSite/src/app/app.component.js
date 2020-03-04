import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { environment } from '../environments/environment';
let AppComponent = class AppComponent {
    constructor(errorsService) {
        this.errorsService = errorsService;
        this.applicationUrl = environment.siteBaseUrl;
        this.errorsService.currentErrorList.subscribe(x => this.errorList = x);
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map