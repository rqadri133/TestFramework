'use strict';




app.service("TestFramworkService", function ($http ,$rootScope)  
  {  
    this.getTestCycles = function () {
        return $http.get("api/TestCycles")

    };





    this.addTestTypes = function (testTypeObj) {
        return $http(
          {
              method: 'post',
              data: testTypeObj,
              url: 'api/TestTypes'

          });
    };




    this.getTestTypes = function (tokenObj) {
        return $http(
          {
              method: 'post',
              data: tokenObj,
              url: 'load/testtypes'

          });
    };

    this.getTestOperands = function () {
        return $http.get("api/TestOperands")

    };


    this.getClientIpAddress = function () {
        var json = 'http://ipv4.myexternalip.com/json';
        var ipAddress = "";
        $http.get(json).then(function (result) {
            ipAddress= result.data.ip;
        });

        return ipAddress;
    };



    this.loadAllConnections = function (tokenObj) {
        return $http(
          {
              method: 'post',
              data: tokenObj,
              url: 'testconnections/LoadAll'

          });
    };


    this.loadAllAssociatedTables = function (tokenObj) {
        return $http(
          {
              method: 'post',
              data: tokenObj,
              url: 'associated/loadAllTables'

          });
    };





        
 this.saveTestCaseInfo = function (testCycleInfo) {
                    return $http(
                      {
                          method: 'post',
                          data: testCycleInfo,
                          url: 'api/TestCases'
                      });
                };
    



  this.saveTestConnectionInfo = function (testConnectionInfo) {
        return $http(
          {
              method: 'post',
              data: testConnectionInfo,
              url: 'api/TestConnections'
          });
    };


    this.loadAllConnectionTypes = function (tokenObj) {
        return $http(
          {
              method: 'post',
              data: tokenObj,
              url: 'testconnectiontype/LoadAll'
          });
    };

          // this doesnt need authorization token thats the public user requesting a demo
              this.saveUser = function (userInfo) {
                  return $http(
                    {
                        method: 'post',
                        data: userInfo,
                        url: 'api/Users'


                    });
              };

              // authroization token after login needed

              this.userInformations = function (usertoken) {
                  return $http(
                    {
                        method: 'get',
                        data: usertoken,
                        url: 'authenticate/User'
                    });
              };



              this.loginInfo = function (userInfo) {

                  return $http(
                    {
                        method: 'post',
                        data: userInfo,
                        url: 'login/User'

                    });
              };



});

     
