import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
let ModalErrorsService = class ModalErrorsService {
    constructor() {
        this._errorListSubject = new BehaviorSubject([]);
        this.currentErrorList = this._errorListSubject.asObservable();
    }
    addErrorsByErrorArray(errorList) {
        var currentErrors = this._errorListSubject.value;
        for (var i = 0, len = errorList.length; i < len; ++i) {
            currentErrors.push(errorList[i]);
        }
        this._errorListSubject.next(currentErrors);
    }
    clearErrors() {
        this._errorListSubject.next([]);
    }
};
ModalErrorsService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], ModalErrorsService);
export { ModalErrorsService };
//# sourceMappingURL=modal-errors.service.js.map