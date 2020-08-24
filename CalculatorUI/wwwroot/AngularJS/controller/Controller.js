//Calculator controller
myapp.controller('calculator-controller', function ($scope, calculatorService) {
    $scope.displayVal = "";
    $scope.number1 = "";
    $scope.number2 = "";
    $scope.operatorActive = false;
    $scope.selectedOperator = "";
    $scope.errorMessage = "";
    $scope.showSpinner = false;
    $scope.operator = { add: "+", subtract: "-", multiply: "*", divide: "/", remainder: "%" };
    $scope.number = { zero: "0", one: "1", two: "2", three: "3", four: "4", five: "5", six: "6", seven: "7", eight: "8", nine: "9", dot: "." };

    $scope.operatorClick = function (operatorType) {
        if ($scope.operatorActive === true) {
            if ($scope.number2 === "") {
                $scope.operatorActive === true
                $scope.selectedOperator = operatorType;
            }
            else {
                $scope.performaCalculation(false);
                $scope.selectedOperator = operatorType;
            }
        }
        else {
            if ($scope.number1 === "") $scope.number1 = "0";
            $scope.operatorActive = true;
            $scope.selectedOperator = operatorType;
        }
    };

    $scope.numberClick = function (number) {
        if ($scope.operatorActive) {
            //Add to second number
            $scope.number2 = $scope.number2 + number;
        }
        else {
            //Add to first number
            $scope.number1 = $scope.number1 + number;
        }
    };

    $scope.performaCalculation = function (removeOperator) {
        $scope.errorMessage = "";
        if ($scope.number1 === "" || $scope.number2 === "" || $scope.selectedOperator == "") return;
        $scope.showSpinner = true;
        var obj = calculatorService.calculate($scope.number1, $scope.number2, $scope.selectedOperator);
        obj.then(function (d) {
            //success
            $scope.number1 = d.data.toString();
            $scope.number2 = "";
            if (removeOperator) {
                $scope.operatorActive = false;
                $scope.selectedOperator = "";
            }
            $scope.showSpinner = false;
        },
            function (error) {
                console.log(error);
                $scope.errorMessage = error.data == null ? 'Error occured  during calculation service call. Verify if service running!' : 'error : ' + error.data.substring(0,118);
                console.log("Error occured while during calculation service call");
                $scope.showSpinner = false;
            });
    };

    $scope.clear = function () {
        $scope.number1 = "";
        $scope.number2 = "";
        $scope.operatorActive = false;
        $scope.selectedOperator = "";
        $scope.errorMessage = "";
    };

    $scope.$watchGroup(['number1', 'number2', 'selectedOperator'], function () {
        $scope.displayVal = $scope.number1 + $scope.selectedOperator + $scope.number2;
    });

    $scope.clearLastValue = function () {
        if ($scope.operatorActive === true) {
            if ($scope.number2 !== "") {
                $scope.number2 = $scope.number2.substring(0, $scope.number2.length - 1);
            }
            else {
                $scope.operatorActive = false;
                $scope.selectedOperator = "";

            }
            return;
        }
        else if ($scope.number1 !== "") {
            $scope.number1 = $scope.number1.substring(0, $scope.number1.length - 1);
        }
    };
});