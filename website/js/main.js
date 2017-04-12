$(document).ready(function () {
    $(".dropdown-toggle").dropdown();
});

$(document).on('click', '.value-control', function () {
    var action = $(this).attr('data-action');
    var target = $(this).attr('data-target');
    var value = parseFloat($('[id="' + target + '"]').val());
    if (action === "plus") {
        value++;
    }
    if (action === "minus") {
        if (value === 0) {
            $button.addClass('inactive');
        }
        else {
            value--;
        }
    }
    $('[id="' + target + '"]').val(value);
});

function initMap() {
    var uluru = { lat: -25.363, lng: 131.044 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
        center: uluru
    });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}

var images = ['../Images/bg/bg_1.jpg', '../Images/bg/bg_2.jpg', '../Images/bg/bg_3.jpg', '../Images/bg/bg_4.jpg', '../Images/bg/bg_5.jpg', '../Images/bg/bg_6.jpg'];
$('html, body').css({background: 'url(' + images[Math.floor(Math.random() * images.length)] + ')' + ' center center fixed'});