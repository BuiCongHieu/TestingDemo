
$('#btnlogout').on('click', function(){
    var pass = parseInt($('#pass2').val());
    console.log(pass);
    $.ajax({
        type: 'post',
        url: '/Account/logout',
        data: {passcode:pass},
        success: function (res) {
            if (res.status == 202) {
                sessionStorage['ServiceId'] = 0;
                window.location.href = '/Home';
            }
        }
    });
});
