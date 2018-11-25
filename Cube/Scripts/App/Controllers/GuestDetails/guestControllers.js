angular.module('guestControllers', [])

.controller('guestEditController', ['$scope', 'GuestService', function ($scope, GuestService) {

    $scope.getGuestDetail = function () {
        GuestService.getGuestDetail().then(function (data) {
            $scope.item = data.data;
        })

    }
    $scope.getGuestDetail();

}])