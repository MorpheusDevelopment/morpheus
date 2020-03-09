import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { Error } from '../Models/error';

@Injectable({
  providedIn: 'root'
})

export class ModalErrorsService {

  private _errorListSubject: BehaviorSubject<Error[]>;
  public currentErrorList: Observable<Error[]>;

  constructor() {
    this._errorListSubject = new BehaviorSubject<Error[]>([]);
    this.currentErrorList = this._errorListSubject.asObservable();
  }

  addErrorsByError(error: Error) {
    var currentErrors = this._errorListSubject.value;
    currentErrors.push(error);
    this._errorListSubject.next(currentErrors);
  }

  addErrorsByErrorArray(errorList: Error[]) {
    var currentErrors = this._errorListSubject.value;
    for (var i = 0, len = errorList.length; i < len; ++i) {
      currentErrors.push(errorList[i]);
    }
    this._errorListSubject.next(currentErrors);
  }

  clearErrors() {
    this._errorListSubject.next([]);
  }
}
