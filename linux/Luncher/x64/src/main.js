
// Variables for NW window and TitleBar
var nw = require('nw.gui');
var win = nw.Window.get();
win.isMaximized = false;

// Variables for Edge and .NET CLR
// var edge = require('edge');
var fs = require('fs');

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

});

$(window).bind("resize", function(){
	// on window resize

});



var getPerson = edge.func(function () {/*
    using System.Threading.Tasks;

    public class Person
    {
        public int anInteger = 1;
        public double aNumber = 3.1415;
        public string aString = "foo";
        public bool aBoolean = true;
        public byte[] aBuffer = new byte[10];
        public object[] anArray = new object[] { 1, "foo" };
        public object anObject = new { a = "foo", b = 12 };
    }

    public class Startup
    {
        public async Task<object> Invoke(dynamic input)
        {
            Person person = new Person();
            return person;
        }
    }
*/});