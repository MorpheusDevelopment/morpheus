import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    })
};
let RecipeRequestsService = class RecipeRequestsService {
    constructor(httpClient) {
        this.httpClient = httpClient;
        this._baseUrl = '/Services/Recipe/';
    }
    getRecipes() {
        return this.httpClient.get(environment.siteBaseUrl + this._baseUrl + 'GetRecipes', httpOptions);
    }
    saveRecipe(request) {
        return this.httpClient.post(environment.siteBaseUrl + this._baseUrl + 'Add', request, httpOptions);
    }
    deleteRecipe(request) {
        return this.httpClient.post(environment.siteBaseUrl + this._baseUrl + 'Delete', request, httpOptions);
    }
};
RecipeRequestsService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], RecipeRequestsService);
export { RecipeRequestsService };
//# sourceMappingURL=recipe-requests.service.js.map