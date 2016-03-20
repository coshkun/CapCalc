
var nw = require('nw.gui');
var win = nw.Window.get();
win.isMaximized = false;


var const_HeaderH = $("header").outerHeight();

// Min
document.getElementById('windowControlMinimize').onclick = function()
{
	win.minimize();
};

// Close
document.getElementById('windowControlClose').onclick = function()
{
	win.close();
};

//Max
document.getElementById('windowControlMaximize').onclick = function()
{
	if (win.isMaximized)
		win.unmaximize();
	else
		win.maximize();
};

win.on('maximize', function(){
	win.isMaximized = true;
});

win.on('unmaximize', function(){
	win.isMaximized = false;
});


// Calc iFrame Heights
$(document).ready(function(){
	// on page load
	calcHeights();
});

$(window).bind("resize", function(){
	// on window resize
    calcHeights();
});
/*
$(window).resize(function(){
	// on window resize
	calcHeights();
});
*/
var frameHeight, frameWidth = 0;
function calcHeights(){
	frameHeight = $(window).height() - const_HeaderH;
	frameWidth = $(window).width() - 1;
	
	// $(".iframe").height(frameHeight);
	// $(".iframe").width(frameWidth);

	$('.iframe').css('height', frameHeight);
	$('.iframe').css('width', frameWidth);
} // End of Calculation


//Change Hover Images
$(function()
{
	$('header>ul>li').hover(function()
	{
		// Mouse Enter
		$(this).find('a').removeClass('gorunur').addClass('gizli');
	},
	function()
	{
		// Mouse Leave
		$(this).find('a').removeClass('gizli').addClass('gorunur');
	});
});