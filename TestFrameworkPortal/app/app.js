
'use strict';


var app;
(function () {

    app = angular.module("TFApp", ['ng', 'ngMaterial', 'ngMessages' ]).run(function ($rootScope) {
        $rootScope.IsLogin = false;
        $rootScope.parentObj = {};
        $rootScope.parentObj.afterLogin = false;
        $rootScope.parentObj.beforeLogin = true;

        $rootScope.users = [];
      

        $rootScope.token = null;
        $rootScope.ValidationCommonThread = [];
        $rootScope.expressionAuthCode = ""  ;
        $rootScope.UserID = "";

        $rootScope.ValidationExpressions = {
            expressionbuilderObj: $rootScope.ValidationCommonThread,
            expressionAuthentication: $rootScope.expressionAuthCode 
            
        };

        $rootScope.testTypes = [];

        $rootScope.testConnectionTypes = [];

    
        $rootScope.testConnectionsAll = [];

        $rootScope.testTableSources = [];

        $rootScope.testColumnsSources = [];
        $rootScope.testOperands = [];
        

        $rootScope.testConnectionObj = {
            TestConnectionTypeID: "",
            TestConnectionName: "",
            TestConnectionString: "",
            CreatedBy: ""
        };

        

    });

    app.directive('showtab',
    function () {
        return {
            link: function (scope, element, attrs) {
                element.click(function (e) {
                    e.preventDefault();
                    $(element).tab('show');
                    
                });
            }
        };
    });



}

        )();


