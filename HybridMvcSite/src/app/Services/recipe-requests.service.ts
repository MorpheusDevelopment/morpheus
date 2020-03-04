import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

import { Result } from '../Models/Generics/result';
import { Error } from '../Models/error';
import { Id } from '../Models/Generics/id';
import { RecipeModel } from '../Models/recipeModels';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Accept': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class RecipeRequestsService {
  private _baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this._baseUrl = '/Services/Recipe/';
  }

  public getRecipes() {
    return this.httpClient.get<Result<RecipeModel[]>>(
      environment.siteBaseUrl + this._baseUrl + 'GetRecipes', httpOptions);
  }

  public saveRecipe(request: RecipeModel) {
    return this.httpClient.post<Error>(
      environment.siteBaseUrl + this._baseUrl + 'Add', request, httpOptions);
  }

  public deleteRecipe(request: Id<RecipeModel>) {
    return this.httpClient.post<Error>(
      environment.siteBaseUrl + this._baseUrl + 'Delete', request, httpOptions);
  }
}
