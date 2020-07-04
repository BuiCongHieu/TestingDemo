// default service is 1 "Ve sinh"
let serviceNumber = 1;
$(".login-ser").on("click", function (event) {
    const serviceId = event.currentTarget.id;
    const numberId = serviceId.substr(serviceId.length - 1);
    $(".login-ser").css({ "background-color": "transparent", "color": "white" });
    $(`#${serviceId}`).css({ "background-color": "white", "color": "#c6254c" });
    serviceNumber = Number.parseInt(numberId);
});

$('#btnlogin').on('click', function () {
    var passcode = parseInt($('#pass').val());
    console.log(passcode);

    $.ajax({
        type: 'post',
        url: '/Account/accountlogin',
        data: {
            passcode: passcode,
            idService: serviceNumber
        },
        success: function (res) {
            if (res.status == 202) {
                if (serviceNumber == 1) {
                    window.location.href = '/Rating/Cleaning';
                    sessionStorage['ServiceId'] = serviceNumber;
                }
                else if (serviceNumber == 2) {
                    window.location.href = '/Rating/Protector';
                    sessionStorage['ServiceId'] = serviceNumber;
                }
            }
            else if (res.status == 404)
                alert('passcode chưa đúng');
            else {
                alert('Mời nhập password');
            }
        }
    });
});