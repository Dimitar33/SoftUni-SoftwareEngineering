(function main() {

    Array.prototype.last = function () {

        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {

        if (n > 0 && n < this.length) {

            return this.slice(n);
        }
    }

    Array.prototype.take = function (n) {

        if (n > 0 && n < this.length) {

            return this.slice(0, n);
        }
    }

    Array.prototype.sum = function () {

        return this.reduce((sum, x) => sum + x);
    }

    Array.prototype.average = function () {

        return this.sum() / this.length;
    }
})();