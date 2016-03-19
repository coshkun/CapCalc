
var fullHeigt, contentHeihgt = 0;
var frmDialogButtonWide, contentWidth = 0;
// Resizer Func
var const_MenuBarH = $(".MenuBar").outerHeight() +2
var const_FrmDialogButtonsH = $(".FrmDialogButtons").outerHeight() -2;
var const_UWPmenu_sliderW = $(".UWPmenu").width() + $(".UWPslider").width() +3;
var const_UWPrightW = $(".UWPright").outerWidth();

$(function(){
	$("#dialog").dialog();
});

$(document).ready(function(){
	// on page load
	refreshSizes();
	initialSizes();
	calcPositions();
});

	// on window resize
	jQuery(window).bind('resize', function(){
		refreshSizes();
		renderSizes();
		calcPositions();
	});

function calcPositions()
{
	$( ".MenuBar" ).position({
	  my: "left top",
	  at: "left top",
	  of: ".UserRectangle"
	});

	$( ".UWPmenu" ).position({
	  my: "left top",
	  at: "left bottom",
	  of: ".MenuBar"
	});
	 
	$( ".UWPslider" ).position({
	  my: "left top",
	  at: "right top",
	  of: ".UWPmenu"
	});

	$( ".UWPcontent" ).position({
	  my: "left top",
	  at: "right top",
	  of: ".UWPslider"
	});

	$( ".UWPright" ).position({
	  my: "right top",
	  at: "right bottom",
	  of: ".MenuBar"
	});

	$( ".FrmDialogButtons" ).position({
	  my: "left bottom",
	  at: "right bottom",
	  of: ".UWPslider",
	  collision: "fit"
	});
}
function refreshSizes()
{
	fullHeigt = $(window).height() - const_MenuBarH;
	contentHeihgt = fullHeigt - const_FrmDialogButtonsH;
	frmDialogButtonWide = $(window).width() - const_UWPmenu_sliderW;
	contentWidth = frmDialogButtonWide - const_UWPrightW;
}
function initialSizes()
{
	$(".UWPmenu, .UWPslider").height(fullHeigt);
	$(".UWPcontent, .UWPright").height(contentHeihgt);
	$(".FrmDialogButtons").width(frmDialogButtonWide);
}
function renderSizes()
{
	$('.UWPmenu').css('height', fullHeigt);
	$('.UWPslider').css('height', fullHeigt);
	$('.UWPcontent').css('height', contentHeihgt);
	$('.UWPright').css('height', contentHeihgt);
	$('.FrmDialogButtons').css('width', frmDialogButtonWide);
}

// HELPERS
