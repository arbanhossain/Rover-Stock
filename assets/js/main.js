

// Preloader
$.holdReady( true );

$('body').imagesLoaded({ background: ".background-holder" }, function(){
    $('#preloader').removeClass("loading");
    $.holdReady( false );
    setTimeout(function() {
        $('#preloader').remove();
    }, 800);
});

// Zanimation
$(window).on('load', function(){
    $('*[data-inertia]').each(function(){
        $(this).inertia();
    });
});




// Two possibilities exist: either we are alone in the Universe or we are not. 
// Both are equally terrifying.
// And this is a strange fix for menu hover on iPad
$(document).ready(function() {
   $('body').bind('touchstart', function() {});
});