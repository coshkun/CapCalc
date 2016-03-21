
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
	initialButons();
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

// UWPmenuButtons
// Initialize Buttons
function initialButons()
{
	var btnCount = 0;
	var lnkList = $(document).find('.UWPmenuLink');
	// Dynamic load for each element by loop
	$('.UWPmenuLink').each(function(i, obj) {
    //test
    var chk = $(this).attr('href');
  		var _imgsrc = chk.substr(1, chk.lenght).toLowerCase();
  		var _tmp = "./img/uwp_btn_"+_imgsrc+".png";
  		$(this).css('background-image', 'url("' + _tmp + '")');
  		// Alert if no accesor on html. (debug purpose)
  		if (chk == "" || chk == "#") { alert("No selector on UWP buttons!"); }
    btnCount = i + 1;
	});

	/*  // Static load one-by-one for each element
	var _tmp = "./img/uwp_btn_Home.png";
    $(".UWPmenuLink").css('background-image', 'url("' + _tmp + '")');
    */
}
// Button Actions
  $(function() {
    $( ".UWPmenuLink" ) // "input[type=submit], a, button"
      .button()
      .click(function( event ) {

      	var targetElement = $(this).attr('href');

      	event.preventDefault();
      	if (targetElement == "#Home")
      	{
      		alert("Home ok!");
      	}
      	else
      	{
      		alert("unable to load broken UWP module :(");
      	}
      });
  });
