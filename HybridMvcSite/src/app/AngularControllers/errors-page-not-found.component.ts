import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-errors-page-not-found',
  templateUrl: '../AngularTemplates/errors-page-not-found.component.html',
  styleUrls: []
})
export class ErrorsPageNotFoundComponent implements OnInit {

  public url: string = window.location.href;

  constructor() { }

  ngOnInit() { }
}
