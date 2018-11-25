var app = angular.module('guestapp', [
      'ngStorage',
       'ngRoute',
  
    'guestControllers',
    'userControllers',
    'services',
    'angular-loading-bar'
    
])


.config(['$routeProvider', '$locationProvider', '$httpProvider', '$qProvider', 'cfpLoadingBarProvider',
   function ($routeProvider, $locationProvider, $httpProvider, $qProvider, cfpLoadingBarProvider) {
       
       $routeProvider.when('/signin', { templateUrl: 'Account/Login', controller: 'loginController' });
       $routeProvider.when('/register', { templateUrl: 'Account/Register', controller: 'registerController' });
       $routeProvider.when('/changepassword', { templateUrl: 'Account/changepassword', controller: 'changepasswordController' });

       $routeProvider.when('/guestedit', { templateUrl: 'Guest/EditDetail', controller: 'guestEditController' });
      
       $routeProvider.otherwise({ redirectTo: '/guestedit' });

      
       $httpProvider.interceptors.push(['$q', '$location', '$localStorage', function ($q, $location, $localStorage) {
           return {
               'request': function (config) {
                   config.headers = config.headers || {};
                   if (localStorage.token) {
                       config.headers.Authorization = 'Bearer ' + localStorage.token;
                   }
                   return config;
               },
               'responseError': function (response) {
          
                   if (response.status === 401 || response.status === 403) {
                  
                       $location.path('/signin');
                   }
                   return $q.reject(response);
               }
           };
       }]);

     
   }])
.run(['$rootScope','$location','UserService', function($rootScope,$location,UserService){
    $rootScope.logout=function(){
        localStorage.token='';
        $location.path('/signin');
        $rootScope.loginpage = true;

    }

}])


  