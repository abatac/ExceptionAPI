// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
$('[data-date]').each(function () {
    var usersTimezoneName = moment.tz.guess();
    var tzAbbr = moment.tz(usersTimezoneName).format('z');
    $(this).html(moment.utc($(this).attr('data-date')).local().format('MM/DD/YY hh:mm:ss a') + ' ' + tzAbbr);
});
});

