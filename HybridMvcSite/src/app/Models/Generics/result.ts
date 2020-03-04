import { Error } from '../error';

export class Result<T>{
  public value: T
  public errors: Error[]
  get successful(): boolean {
    return this.errors === undefined || this.errors.length == 0;
  }

  constructor() {
    this.errors = [];
  }
}
