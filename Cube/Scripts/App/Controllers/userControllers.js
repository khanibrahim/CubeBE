

angular.module('userControllers', [])

.controller('loginController', ['$scope','$rootScope', 'UserService', '$location', function ($scope,$rootScope, UserService, $location) {
    $scope.login = function () {
        $scope.user.grant_type = 'password';
        UserService.signin($scope.user).then(function (data) {
            localStorage.token = data.data.access_token;
          
            if (data && data.data.access_token) {
                $rootScope.loginpage = false;
                $location.path('/editdetails');

            }
            
        }
        ,
        function (data) {
            $scope.message = data.data.error_description;
           
        }
        )

    }

}])
.controller('registerController', ['$scope', 'UserService', function ($scope, UserService) {
    $scope.register= function () {
        UserService.register($scope.user).then(function (data) {
          console.log('done')
        })

    }

}])


.controller('changepasswordController', ['$scope', 'UserService', function ($scope, UserService) {
    $scope.submit = function () {
        UserService.changePassword($scope.item).then(function (data) {
            $scope.message = 'Successfully Changed';

        },
        function (data) {
            console.log(data)
            $scope.message = data.data.ModelState;
        }

        )

    }

}])


