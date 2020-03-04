import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recipes',
  templateUrl: '../AngularTemplates/recipe.component.html',
  styleUrls: ['../AngularStyleSheets/recipe.component.css']
})

export class RecipesComponent implements OnInit {

  public title: string;
  constructor() { }

  ngOnInit() {
    this.title = 'Recipes';
  }
}
