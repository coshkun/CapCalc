
var nw = require('nw.gui');
var win = nw.Window.get();
win.isMaximized = false;

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

$(window).resize(function(){
	// on window resize
	calcHeights();
});

var frameHeigt = 0;
function calcHeights(){
	frameHeigt = $(window).height() - $("header").outerHeight();
	
	$(".iframe").height(frameHeigt);
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