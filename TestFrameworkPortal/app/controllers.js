﻿app.controller('TFController', function ($scope, $http, $rootScope, TestFramworkService) {


});

app.controller('LoginController', function ($scope, $http, $rootScope, TestFramworkService) {
  
  // its tokenization based so the service dependency injection applied
    $scope.testConTypeInfo = "";

    $scope.testTypeName = "";
    var token = {
        AuthenticationToken: $rootScope.UserID
    };
   
   

    $scope.addTestType = function () {
        $scope.typeSaved = "";

        var testType = {

            TestTypeName: $scope.testTypeName
        };
        var addTestType = TestFramworkService.addTestTypes(testType);

        addTestType.then(function (d) {

            $scope.typeSaved = "Test Type Saved";

             tokenObj = {
                AuthenticationToken: $rootScope.UserID
            };
            var testtypes = TestFramworkService.getTestTypes(tokenObj);

            testtypes.then(function (d) {
                $rootScope.testTypes = d.data; 
            }, function (error) {
                console.log('Oops! Something went wrong while saving the data.');


            });

        });

    }

    $scope.addConnectionType = function () {

        var testConnectionType = {
            
            TestConnctionTypeName: $scope.testConTypeInfo ,
            CreatedBy : $rootScope.UserID  
        };

        var addConnType = TestFramworkService.addTestConnectionType(testConnectionType);


        addConnType.then(function (d) {

            $scope.typeSaved = "Test Connection Type Saved";

            tokenObj = {
                AuthenticationToken: $rootScope.UserID
            };


            var testcontypes = TestFramworkService.loadAllConnectionTypes(tokenObj);

            testcontypes.then(function (d) {
                $rootScope.testConnectionTypes = d.data;
            }, function (error) {
                console.log('Oops! Something went wrong while saving the data.');


            });

        });

    }


    $scope.login = function () {

       /* test the screen only */
        var userInfo = {
            UserName: $scope.txtUserID,
            Pwd: $scope.txtPwd
        };


     
        var userinformation = TestFramworkService.loginInfo(userInfo);
       
        userinformation.then(function (d) {

         
            $rootScope.UserID = d.data.UserID;

               var token = {
            AuthenticationToken: $rootScope.UserID
        };


            if ($rootScope.UserID != "") {

        

               var testConnections = TestFramworkService.loadAllConnections(token);

               testConnections.then(function (d) {
                    $rootScope.testConnectionsAll = d.data;
                      $scope.expressionObj.TestConnectionSourceID = d.data[0].TestConnectionID;

                }, function (error) {
                    console.log('Oops! Something went wrong while saving the data.');
                });


            }






            $rootScope.parentObj.beforeLogin = false;
            $rootScope.parentObj.afterLogin = true;
            $rootScope.users = d.data.AllUsers;
       

        

        

            var testcontypes = TestFramworkService.loadAllConnectionTypes(token);

             testcontypes.then(function (d) {
             $rootScope.testConnectionTypes = d.data;

             $rootScope.testConnectionObj.TestConnectionTypeID = d.data[0].TestConnectionTypeID;


            }, function (error) {
                console.log('Oops! Something went wrong while saving the data.');


            });

             var testtypes = TestFramworkService.getTestTypes(token);

             testtypes.then(function (d) {
                 $rootScope.testTypes = d.data;
            }, function (error) {
                 console.log('Oops! Something went wrong while saving the data.');


             });




        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        });
    };

    
    


});






app.controller('DemoController', function ($scope, $http, $rootScope, TestFramworkService) {

    $scope.showDemo = true;

    $scope.addUserInformation = function () {

        var userInfo = {
            LoginName: $scope.loginName,
            PasswordHash: $scope.txtPwd,
            EmailAddress: $scope.emailAddress,
            PhoneNumber: $scope.phoneNumber,
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            CompanyName: $scope.companyName,
            CompanyWebSite: $scope.companyWebsite

        };



        

        var userinformation = TestFramworkService.saveUser(userInfo);
        userinformation.then(function (d) {
            var userToken = d.data.UserID; 
            $scope.showDemo = false;
            $scope.loginName = "";
            $scope.txtPwd = "";
            $scope.emailAddress = "";
            $scope.phoneNumber = "";
            $scope.firstName = "";
            $scope.lastName = "";
            $scope.companyName = "";
            $scope.companyWebsite = "";






            $scope.demoMessage = "You are now all set we will send you an email details after company and profile verification";
               
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
            $scope.demoMessage = "Sorry you missed out some information";

        })
    };

});


/*
 this.loadAllConnectionTypes = function (tokenObj) {
        return $http(
          {
              method: 'post',
              data: tokenObj,
              url: 'testconnectiontype/LoadAll'
          });
    };

*/


app.controller('TestCaseController', function ($scope, $http, $rootScope, TestFramworkService) {
    /* test the screen only */

    $scope.testCycleDate = null;
    $scope.testTypesAll = [];
    
    

     $scope.txtTestCaseName ="";
     $scope.testCycleDate = "";
     $scope.selectedTestType = "";

     
    $scope.addTestCase = function () {

    
        var testproxy = {
            TestCaseDescName: $scope.selTestCaseDescName,
            CreatedDate: $scope.selExecutionDate,
            CreatedBy: $rootScope.UserID,
            TestTypeID: $scope.selTestTypeID
        }

        
        /* test the screen only */

        var testcaseinformation = TestFramworkService.saveTestCaseInfo(testproxy);

        testcaseinformation.then(function (d) {

            $rootScope.parentObj.beforeLogin = false;
            $scope.testCaseCreationMessage = "Successfully Created Test Case , The Next Step to assign expression or multiple expressions to Test Case with a order sequence"
            $rootScope.parentObj.afterLogin = true;

        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        });
    };

    $scope.addTestCase = function () {

    
        var testproxy = {
            TestCaseDescName: $scope.selTestCaseDescName,
            CreatedDate: $scope.selExecutionDate,
            CreatedBy: $rootScope.UserID,
            TestTypeID: $scope.selTestTypeID
        }

        
        /* test the screen only */

        var testcaseinformation = TestFramworkService.saveTestCaseInfo(testproxy);

        testcaseinformation.then(function (d) {

            $rootScope.parentObj.beforeLogin = false;
            $scope.testCaseCreationMessage = "Successfully Created Test Case , The Next Step to assign expression or multiple expressions to Test Case with a order sequence"
            $rootScope.parentObj.afterLogin = true;

        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        });
    };




});




app.controller('TestConnectionController', function ($scope, $http, $rootScope, TestFramworkService) {
    /* test the screen only */

    $scope.testConnectionMessage = "";

    $scope.showSuccessCon = true;
    $scope.showFailedCon = false;
    
    $scope.addTestConnection = function (testConnectionObj) {

        /* test the screen only */
        testConnectionObj.CreatedBy = $rootScope.UserID;
        var testconinformation = TestFramworkService.saveTestConnectionInfo(testConnectionObj);
        testcaseinformation.then(function (d) {

            $rootScope.parentObj.beforeLogin = false;
            $scope.testCaseCreationMessage = "Successfully Created Test Case , The Next Step to assign expression or multiple expressions to Test Case with a order sequence"
            $rootScope.parentObj.afterLogin = true;

            $scope.testConnectionMessage = "Successfully Created Test Connection , The Next Step to assign this connection to the Test expression ";

            $scope.showSuccessCon = true;
            $scope.showFailedCon = false;


        }, function (error) {

            $rootScope.testConnectionMessage = "Failed to create test connection";
            $rootScope.showSuccessCon = false;
            $rootScope.showFailedCon = true;


            console.log('Oops! Something went wrong while saving the data.')
        });
    };





});


// Fuck China mother fucking chinese and russians long live America 

app.controller('TestExpressionController', function ($scope, $http, $rootScope, TestFramworkService) {
    /* test the screen only */

    $scope.showExpressionEdits = false;
    $scope.showColumnSelections = true;

    $scope.testConnectionsDefined = null;
    $scope.testTableSources = null;
    $scope.testColumnsSources = null;
    $scope.testOperands = null;
    $scope.testColumnsTarget = null;
    $scope.testExpressionMessage = null;
    $scope.showSuccessCon = false;
    $scope.showFailedCon = false;
    $scope.expressionObj = {
        TestConnectionID: "",
        TestConnectionDestID: "",
        TestTableID: "",
        TestTableTargetID: "",
        SourceColumnID: "",
        OperandIDApplied: "",
        TargetColumnID: "",
        Expression : ""



    }



   
    var token = {
        AuthenticationToken: $rootScope.UserID
    }

    if ($rootScope.UserID !=  "")
    {


        var testConnections = TestFramworkService.loadAllConnections(token);

        testConnections.then(function (d) {
            $scope.testConnectionsDefined = d.data;
            $scope.expressionObj.TestConnectionSourceID = d.data[0].TestConnectionID;

        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.');
        });


    }

    // here i don't need case info 
    $scope.areaVal = ""

    $scope.backToExpressionColumnRule = function () {

        $scope.showExpressionEdits = false;
        $scope.showColumnSelections = true;


    };

    $scope.showEditor = function() 
    {

        $scope.showExpressionEdits = true;
        $scope.showColumnSelections = false ;



    };







});


app.controller('TestScriptController', function ($scope, $http, $rootScope, TestFramworkService) {
    /* test script  screen only */
     // the expression will be send from this controller to Service to generate script





});



