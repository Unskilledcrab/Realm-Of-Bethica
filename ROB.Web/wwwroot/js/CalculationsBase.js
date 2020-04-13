var CalculationBase = function() {
    this.setup = function () {
        this.calcs = [];
        $.each($("[data-expression]"), function () {
            var variableName = $(this).attr("data-variable");
            var priority = $(this).attr("data-priority");
            window[variableName] = 0;

            var temp = {
                priority: parseInt(priority)
            };
            sheetCalculations.addUpdateFunction(variableName,temp);

            var expression = $(this).attr("data-expression");
            var enabled = $(this).attr("data-expression-enabled");
            if (enabled) {
                sheetCalculations.addCalculation(expression, temp);
            } else {
                sheetCalculations.addCalculation("console.log('function disabled')", temp);
            }
            sheetCalculations.calcs.push(temp);
            
        });
        // sort from 1 (run first) to higher (run later)
        this.calcs.sort(function (a, b) {
            return a.priority - b.priority;
        });
    }
    this.addCalculation = function (expression,temp) {
        temp.calculationFunction = function () {
            return Function('"use strict";return (' + expression + ')')();
        };
    }
    this.addUpdateFunction = function (variableName,temp) {
        temp.updateFunction = function () {
            var element = $("[data-variable=" + variableName + "]");
            element.val(window[variableName]);
            element.text(window[variableName]);
        };
    }
    this.runCalculations = function () {
        for (var i = 0; i < this.calcs.length; i++) {
            this.calcs[i].calculationFunction();
        }
    }
    this.runUpdates = function () {
        for (var i = 0; i < this.calcs.length; i++) {
            this.calcs[i].updateFunction();
        }
    }
    this.run = function () {
        this.runCalculations();
        this.runUpdates();
    }
}

var sheetCalculations = new CalculationBase();