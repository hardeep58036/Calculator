//Service to get data from api
myapp.service('calculatorService', function ($http) {

    var baseUrl = "http://localhost:56873/"; //read from config. 
    var endPoint = "api/Calculate"; 

    this.calculate = function (number1, number2, operator) {
        var url = baseUrl + endPoint;
        var data = { "FirstNumber": parseFloat(number1), "SecondNumber": parseFloat(number2), "Operator": operator}, config = 'application/json';
        //var url = 'https://calculatorapi20200824162058.azurewebsites.net/api/Calculate', data = { "FirstNumber": parseInt(number1), "SecondNumber": parseInt(number2), "Operator": operator}, config = 'application/json';

        return $http.post(url, data, config);
    }

    this.getAuditList = function () {
        var url = baseUrl + endPoint;
        return $http.get(url);
    }
});