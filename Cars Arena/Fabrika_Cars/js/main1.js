


var myButton = document.getElementById('my-button'),
	
	myInput = document.getElementById('my-input');

myButton.onclick = function () {
	
	'use strict';
	
	if (this.textContent === 'show password') {
		myInput.setAttribute('type', 'text');
		this.textconent = 'Hide Password';
	} else {
		myInput.setAttribute('type', 'password');
		this.textContent = 'Show Password';
		
	}
	
};
$('.submit').click(function () {
	
	'use strict';
	
	$('.popup .inner').fadeIn();
	
	
});

$('.popup .inner').click(function () {
	$(this).fadeOut();
	
});
$('.popup .inner').click(function (e) {
	e.stopPropagation();

});
$('.popup .close').click(function (e) {
	$('.popup .inner').fadeOut();

});