

var getCookie = function (cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
var GuestService = {
    getValues: function () {
    $.ajax({
        url: '/api/Values',
        type: 'GET',
        headers: { "Authorization": 'Bearer ' + getCookie('access_token') },
        success: function (response) {
           
            console.log(response)
            return response;
        },
        error: function (data) {

        }
    })
    },
    getDetails: 
             $.ajax({
            url: '/api/Guest',
            type: 'GET',
            headers: { "Authorization": 'Bearer ' + getCookie('access_token') },
            success: function (response) {
                return response;
            },
            error: function (data) {

            }
        })
    

    
   

}