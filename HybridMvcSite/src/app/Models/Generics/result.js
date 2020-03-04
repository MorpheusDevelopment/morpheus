export class Result {
    constructor() {
        this.errors = [];
    }
    get successful() {
        return this.errors === undefined || this.errors.length == 0;
    }
}
//# sourceMappingURL=result.js.map