$("#v-pills-home-tab").ready(function () {
    $.ajax({
        url: '/Apartment/LoadApartments',
        success: function (data) {
            $('#v-pills-home').html(data);
        }
    })
})

$("#v-pills-home-tab").click(function () {
    $.ajax({
        url: '/Apartment/LoadApartments',
        success: function (data) {
            $('#v-pills-home').html(data);
        }
    })
})

$("#v-pills-profile-tab").click(function () {
    $.ajax({
        url: '/Account/LoadAccounts',
        success: function (data) {
            $('#v-pills-home').html(data);
        }
    })
})