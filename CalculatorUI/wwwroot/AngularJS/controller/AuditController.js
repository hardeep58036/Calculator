//audit controller
myapp.controller('auditcontroller', function ($scope, calculatorService) {
    $scope.Auditlist = [];
    $scope.showSpinner = false;

    //Loads all Audit records when page loads
    loadList();
    function loadList() {
        $scope.showSpinner = true;
        var response = calculatorService.getAuditList();
        response.then(function (d) {
            $scope.Auditlist = d.data;
            $scope.showSpinner = false;
        },
            function () {
                $scope.Auditlist = [];
                alert("Error occured while fetching audit list...");
            });
    };
});