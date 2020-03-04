export class Id<T>{
  private _value: number

  constructor(value: number) {
    this._value = value;
  }

  get value() {
    return this._value;
  } 
}
