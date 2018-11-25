angular.module('services', [])

.factory('UserService', ['$http', function ($http) {

    return {
        signin: function (user) {
            return $http({
                method: 'POST',
                data: user,
                //headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                //transformRequest: function (obj) {
                //    var str = [];
                //    for (var p in obj)
                //        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                //    return str.join("&");
                //},
                url: '/api/account/login' 
            });
        },
        logout: function () {
            return $http({
                method: 'POST',
                url: 'api/account/logout/'
            });
        },
        register: function (user) {
            return $http({
                method: 'POST',
                data: user,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                url: '/api/account/Register/'
            });
        },
        changePassword: function (item) {
            return $http({
                method: 'POST',
                data: item,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                url: '/api/account/ChangePassword/'
            });
        },
        getCurrentUser: function () {

            return $http({
                method: 'GET',
               url: '/api/account/GetCurrentUser/'
            });
        }


        

    }

}])
.factory('GuestService', ['$http', function ($http) {

    return {
        getGuestDetail: function () {
            console.log('')
            return $http({
                method: 'GET',
                url: 'api/guest/'
            });
        },
        updt: function (item) {
            return $http({
                method: 'POST',
                data:item,
                url: 'api/guest/'
            });
        }

    }

}])