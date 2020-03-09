import { Component } from '@angular/core';

import { environment } from '../environments/environment';


import { Error } from './Models/error';
import { ModalErrorsService } from './Services/modal-errors.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  applicationUrl = environment.siteBaseUrl;
  public errorList: Error[];

  constructor(
    private errorsService: ModalErrorsService,
  ) {
    this.errorsService.currentErrorList.subscribe(x => this.errorList = x);
  }

  public dismissErrors(): void {
    this.errorsService.clearErrors();
  }

  public modalClicked(event: any): void {
    event.preventDefault();
    event.stopPropagation();
  }
}
