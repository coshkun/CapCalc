
var fullHeigt, contentHeihgt = 0;
var frmDialogButtonWide = 0;

$(function(){
	$("#dialog").dialog();
});

$(document).ready(function(){
	// on page load
	calcHeights();
});

	// on window resize
	jQuery(window).resize(function(){
		calcHeights();
	});

function calcHeights(){
	fullHeigt = $(window).height() - $(".MenuBar").outerHeight();
	contentHeihgt = fullHeigt - $(".FrmDialogButtons").outerHeight();
	frmDialogButtonWide = $(window).width() - ($(".UWPmenu").width() + $(".UWPslider").width());
	
	$(".UWPmenu, .UWPslider").height(fullHeigt);
	$(".UWPcontent, .UWPright").height(contentHeihgt);
	$(".FrmDialogButtons").width(frmDialogButtonWide);
}