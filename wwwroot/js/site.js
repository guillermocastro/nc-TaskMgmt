// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var baseURL = '';
var api = '/api/';
var config = {
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
    'cache-control': 'no-cache',
    Application: 'Valkian Intelligent Management',
  },
};
angular
  .module('VK', [])
  .run(function($rootScope, $window, $document) {
    $rootScope.company = 'Valkian';
    $rootScope.product = 'VKAPI .NET Core API';
    $rootScope.author = 'Guillermo Castro';
    $rootScope.version = 'V 2.0.0';
    $rootScope.UserName = $window.sessionStorage.getItem('UserName'); //;
    $rootScope.tokenKey = $window.sessionStorage.getItem('tokenKey');
    //$rootScope.usr = $window.sessionStorage.getItem("UserName");
    $rootScope.Messages = [];
    $rootScope.menus = [
      { link: '/', label: 'Home' },
      { link: '/help', label: 'API' },
    ];
    $rootScope.Rows = 10;
  })
  .controller('Authentication', function(
    $rootScope,
    $scope,
    $document,
    $window,
    $http
  ) {
    var apiserver = '';
    var header = {
      'content-type': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
      'Access-Control-Allow-Origin': '*',
    };
    $rootScope.token = $window.sessionStorage.getItem('tokenKey');
    if ($rootScope.token !== null) {
      $rootScope.logonstatus = 'connected';
      $scope.logonstatus = 'connected';
      $rootScope.UserName = $window.sessionStorage.getItem('UserName');
      $rootScope.token = $window.sessionStorage.getItem('tokenKey');
      //$rootScope.usr = $rootScope.UserName;
    } else {
      $rootScope.logonstatus = null;
    }
    $scope.checklogon = function() {
      $rootScope.token = $window.sessionStorage.getItem('tokenKey');
      if ($rootScope.token !== null) {
        $rootScope.logonstatus = 'connected';
        $scope.logonstatus = 'connected';
        $rootScope.UserName = $window.sessionStorage.getItem('UserName');
        $rootScope.token = $window.sessionStorage.getItem('tokenKey');
        //$rootScope.usr = $rootScope.UserName;
      } else {
        $rootScope.logonstatus = null;
      }
    };
    $scope.register = function(Username, Password1, Password2) {
      console.log('register');
      //var parameter = JSON.stringify({
      //    "username": Username,
      //    "Password": Password1,
      //    "ConfirmPassword": Password2
      //});
      //$http.post('/api/Account/Register', parameter)
      $http({
        method: 'POST',
        url: apiserver + '/api/Account/Register',
        contentType: 'application/json; charset=utf-8',
        data: {
          Email: Username,
          Password: Password1,
          ConfirmPassword: Password2,
        },
        header: header,
      }).then(
        function(response) {
          console.log('Success');
          $scope.login(Username, Password1);
        },
        function(response) {
          console.log('Error');
          console.log(response.data);
        }
      );
    };
    $scope.login = function(Username, Password) {
      console.log('$scope.login');
      var data = {
        grant_type: 'password',
        username: Username,
        password: Password,
      };
      $http({
        method: 'POST',
        url: apiserver + '/Token',
        data:
          'userName=' +
          encodeURIComponent(Username) +
          '&password=' +
          encodeURIComponent(Password) +
          '&grant_type=password',
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Methods':
            'GET, POST, DELETE, PUT, OPTIONS, HEAD',
        },
      }).then(
        function(response) {
          console.log('Success');
          //var tokenKey = JSON.stringify(response.data.access_token);
          //var UserName = JSON.stringify(response.data.userName);
          var tokenKey = response.data.access_token;
          var UserName = response.data.userName;
          var Expires = response.data.expires;
          var Issued = response.data.issued;
          console.log(response.data);
          $window.sessionStorage.setItem('tokenKey', tokenKey);
          $window.sessionStorage.setItem('UserName', UserName);
          $window.sessionStorage.setItem('Expires', UserName);
          $window.sessionStorage.setItem('Issued', UserName);
          $rootScope.UserName = data.userName;
          $rootScope.token = data.access_token;
          $rootScope.logonstatus = 'connected';
          $scope.logonstatus = 'connected';
          $scope.transaction = 0;
          //$rootScope.usr = $rootScope.UserName;
          $rootScope.tokenKey = $window.sessionStorage.getItem('tokenKey');
        },
        function(response) {
          console.log('Error');
          console.log(response.data);
        }
      );
    };
    $scope.checklogon();
  });
