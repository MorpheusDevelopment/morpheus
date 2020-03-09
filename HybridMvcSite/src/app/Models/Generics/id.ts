export class Id<T>{

  private _value: number = 0;
  get value(): number {
    return this._value;
  }
  set value(value: number) {
    this._value = value;
  }

  constructor(value: number) {
    this._value = value;
  }

  public toString = (): string => {
    return this._value.toString();
  }

  public toJSON = function () {
    return this._value;
  }
}
